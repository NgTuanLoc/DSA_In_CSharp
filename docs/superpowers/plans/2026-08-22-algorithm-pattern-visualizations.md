# Algorithm Pattern Visualizations Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build a zero-build static site under `visualizations/` that animates 20 algorithmic patterns step by step, with pseudocode highlighting, complexity notes, and preset inputs.

**Architecture:** Every pattern page is a thin HTML shell plus a DOM-free JS module exporting one `PatternSpec`. A shared engine runs the spec's `run(data, emit)` once at load to collect an immutable array of complete state snapshots ("frames"), then a `Player` indexes into that array while six shared renderers paint each frame. Because pattern specs contain no DOM code, the same modules run under Node for a fast TDD loop and in the browser for the visuals.

**Tech Stack:** Vanilla ES modules, no dependencies, no bundler. Node's built-in test runner (`node --test`) for pure logic. Python's `http.server` for serving. Verified on this machine: Node v24.11.1, Python 3.13.9.

**Spec:** `docs/superpowers/specs/2026-08-22-algorithm-pattern-visualizations-design.md`

## Global Constraints

Every task's requirements implicitly include this section.

- **No dependencies, ever.** `visualizations/package.json` is a two-key marker file (`{"type":"module","private":true}`) that exists solely so Node treats `.js` as ESM. Never run `npm install`, never add a `dependencies` key, never create `node_modules`.
- **No build step.** No bundler, no transpiler, no minifier. What is on disk is what the browser runs.
- **Browser-loaded files must use the `.js` extension.** Verified on this machine: `python -m http.server` serves `.js` as `application/javascript` (module-safe) but serves `.mjs` as `text/plain`, which browsers refuse to execute as a module. Only `tests.node.mjs`, which the browser never fetches, uses `.mjs`.
- **`shared/kinds.js`, `shared/engine.js`, `shared/selftest.js`, `patterns/registry.js`, and all 20 `patterns/*.js` spec modules must be DOM-free** — no `document`, `window`, or DOM types. Node runs these directly. Only `shared/render.js`, `shared/renderers/*.js`, and `shared/page.js` may touch the DOM.
- **Frames are complete snapshots, not deltas.** Every emitted frame carries all state needed to draw it, so backward scrubbing never replays.
- **`MAX_FRAMES = 2000`.** `collectFrames` throws past this cap rather than hanging the tab.
- **Nothing under `src/` changes.** No `.csproj`, `.slnx`, or `.github/workflows` edits. `dotnet build` and `dotnet test` must be unaffected.
- **The six renderer kinds are fixed:** `array`, `linkedList`, `tree`, `graph`, `grid`, `collection`. No seventh renderer.
- **Commit after every task**, using conventional commit format (`feat:`, `test:`, `docs:`).

## Commands

Run from the repo root unless stated otherwise.

```bash
# Pure-logic tests (the TDD loop) — quote the glob so the shell does not expand it
node --test "visualizations/tests/*.test.js"

# Console spec table (all patterns, all inputs)
node visualizations/tests.node.mjs

# Serve the site, then open http://localhost:8000
cd visualizations && python -m http.server 8000

# Confirm the .NET side is untouched
dotnet build
```

## File Structure

```
visualizations/
  package.json                {"type":"module","private":true} — Node ESM marker only
  README.md                   how to serve and open the site
  index.html                  gallery of all 20 pages, grouped by source folder
  tests.html                  browser harness: spec table + renderer harness
  tests.node.mjs              Node console runner (prints the same spec table)
  shared/
    kinds.js                  RENDERER_KINDS — the six names, DOM-free
    engine.js                 collectFrames, validateFrames, Player — DOM-free
    selftest.js               deepEqual, checkSpec, runAllChecks, formatText — DOM-free
    render.js                 paint() dispatch + error banner
    renderers/
      array.js  linkedList.js  tree.js  graph.js  grid.js  collection.js
    page.js                   boot() — builds page chrome, wires Player
    styles.css                shared visual language
  patterns/
    registry.js               imports and re-exports all 20 specs
    <name>.html               20 shells (one line differs between them)
    <name>.js                 20 PatternSpec modules
  tests/
    engine.test.js  selftest.test.js  specs.test.js
```

Responsibilities are split so no file does two jobs: `kinds.js` holds the one constant both halves need (this is why `engine.js` can validate `view.kind` without importing renderer code); `engine.js` owns time and frames but never pixels; renderers own pixels but never algorithms; `page.js` owns chrome and wiring but neither.

## Conventions

### The PatternSpec shape

Every `patterns/<name>.js` default-exports exactly this shape:

```js
export default {
  title: "Two Pointers",
  folder: "ArrayAndString",              // one of the 9 src/DSA/LeetCode folders
  complexity: { time: "O(n)", space: "O(1)" },
  whenToUse: "One sentence: the signal that tells you to reach for this pattern.",
  problems: ["125. Valid Palindrome", "167. Two Sum II"],
  pseudocode: ["line 0", "line 1", "  line 2"],   // indentation via leading spaces
  inputs: [
    { label: "human-readable", data: <any>, expect: <any> },
  ],
  run(data, emit) { /* ... returns the algorithm's result ... */ },
};
```

`run` must return the value compared against `expect` (via `deepEqual`), and must call `emit` at least once.

### The frame shape

```js
emit({
  line: 2,                      // index into spec.pseudocode
  note: "compare 'r' vs 'r'",   // non-empty one-line narration
  view: { kind: "array", /* renderer state */ },
  view2: { kind: "collection", /* optional second renderer */ },
});
```

### Renderer view contracts

Every renderer receives `(view, el)` and repaints `el` from scratch. Coordinates `x`/`y` are normalized floats in `[0,1]` supplied by the spec — no layout algorithm computes them.

| kind | view fields |
|---|---|
| `array` | `cells: any[]`, `pointers: {name: index}`, `window: {start,end}\|null`, `colors: {index: "active"\|"pass"\|"fail"\|"dim"}`, `caption?: string` |
| `collection` | `label: string`, `items: [{value, key?}]`, `orientation: "vertical"\|"horizontal"`, `highlight: index[]`, `caption?: string` |
| `linkedList` | `nodes: [{id, value}]`, `next: {id: id\|null}`, `pointers: {name: id}`, `colors: {id: state}` |
| `tree` | `nodes: [{id, value, x, y}]`, `edges: [[parentId, childId]]`, `current: id\|null`, `visited: id[]`, `frontier: id[]`, `labels?: {id: string}` |
| `graph` | `nodes: [{id, label, x, y}]`, `edges: [[a,b]]`, `current: id\|null`, `visited: id[]`, `activeEdge: [a,b]\|null`, `distances?: {id: number}` |
| `grid` | `rows: any[][]`, `current: {r,c}\|null`, `colors: {"r,c": state}`, `rowLabels?: string[]`, `colLabels?: string[]` |

### The page shell template

All 20 shells are identical except for the pattern name in the `<title>` and the import. For `patterns/two-pointers.html`:

```html
<!doctype html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Two Pointers — DSA Pattern Visualizations</title>
<link rel="stylesheet" href="../shared/styles.css">
</head>
<body>
<main id="app"></main>
<script type="module">
  import { boot } from "../shared/page.js";
  import spec from "./two-pointers.js";
  boot(spec, document.getElementById("app"));
</script>
</body>
</html>
```

### How page tasks are specified

Tasks 6–10 give the page's `run()` in full, because each also introduces a renderer and the two must be read together. Task 11 and Tasks 12–16 give the complete spec data (title, folder, complexity, whenToUse, problems, pseudocode, inputs with verified `expect` values), the exact `view` shape to emit, and a numbered emit-point list keyed to pseudocode lines. The pseudocode array *is* the algorithm line by line, and `tests/specs.test.js` verifies every port against its `expect` values, so this is complete direction. Every `expect` value in this plan was computed by hand and checked before being written down.

Renderers follow the same split: `array` (Task 5) and `collection` (Task 7) are given as complete code and establish the house style; `linkedList`, `tree`, `graph`, and `grid` (Tasks 8–11) are given as a requirements list — element structure, class names, and state rules — since each is a variation on that established style.

---

### Task 1: Scaffolding and the assertion core

**Files:**
- Create: `visualizations/package.json`
- Create: `visualizations/shared/kinds.js`
- Create: `visualizations/shared/selftest.js`
- Create: `visualizations/patterns/registry.js`
- Test: `visualizations/tests/selftest.test.js`

**Interfaces:**
- Consumes: nothing.
- Produces: `RENDERER_KINDS: string[]`, `isKnownKind(kind: string): boolean` from `shared/kinds.js`; `deepEqual(a: any, b: any): boolean` from `shared/selftest.js`; `specs: PatternSpec[]` from `patterns/registry.js` (empty for now).

- [ ] **Step 1: Write the failing test**

Create `visualizations/tests/selftest.test.js`:

```js
import { test } from "node:test";
import assert from "node:assert/strict";
import { deepEqual } from "../shared/selftest.js";
import { RENDERER_KINDS, isKnownKind } from "../shared/kinds.js";

test("deepEqual: primitives", () => {
  assert.equal(deepEqual(1, 1), true);
  assert.equal(deepEqual("a", "a"), true);
  assert.equal(deepEqual("a", "b"), false);
  assert.equal(deepEqual(true, false), false);
  assert.equal(deepEqual(null, null), true);
  assert.equal(deepEqual(null, {}), false);
});

test("deepEqual: arrays are order-sensitive", () => {
  assert.equal(deepEqual([1, 2], [1, 2]), true);
  assert.equal(deepEqual([1, 2], [2, 1]), false);
  assert.equal(deepEqual([1, 2], [1, 2, 3]), false);
  assert.equal(deepEqual([[1], [2]], [[1], [2]]), true);
});

test("deepEqual: objects compare by key set and value", () => {
  assert.equal(deepEqual({ a: 1 }, { a: 1 }), true);
  assert.equal(deepEqual({ a: 1 }, { a: 2 }), false);
  assert.equal(deepEqual({ a: 1 }, { a: 1, b: 2 }), false);
  assert.equal(deepEqual({ a: { b: [1] } }, { a: { b: [1] } }), true);
});

test("deepEqual: arrays and objects are not interchangeable", () => {
  assert.equal(deepEqual([], {}), false);
});

test("kinds: exactly the six renderers are known", () => {
  assert.equal(RENDERER_KINDS.length, 6);
  assert.equal(isKnownKind("array"), true);
  assert.equal(isKnownKind("collection"), true);
  assert.equal(isKnownKind("nope"), false);
});
```

- [ ] **Step 2: Run test to verify it fails**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: FAIL — `Cannot find module .../shared/selftest.js`

- [ ] **Step 3: Write minimal implementation**

Create `visualizations/package.json`:

```json
{
  "type": "module",
  "private": true
}
```

Create `visualizations/shared/kinds.js`:

```js
// The six renderer names. Lives in its own module so the DOM-free half
// (engine, selftest, specs) can validate a view kind without importing
// any renderer code.
export const RENDERER_KINDS = ["array", "collection", "linkedList", "tree", "graph", "grid"];

export function isKnownKind(kind) {
  return RENDERER_KINDS.includes(kind);
}
```

Create `visualizations/shared/selftest.js`:

```js
export function deepEqual(a, b) {
  if (a === b) return true;
  if (typeof a !== typeof b) return false;
  if (a === null || b === null) return false;
  if (typeof a !== "object") return Number.isNaN(a) && Number.isNaN(b);
  if (Array.isArray(a) !== Array.isArray(b)) return false;
  const keysA = Object.keys(a);
  const keysB = Object.keys(b);
  if (keysA.length !== keysB.length) return false;
  return keysA.every((k) => Object.hasOwn(b, k) && deepEqual(a[k], b[k]));
}
```

Create `visualizations/patterns/registry.js`:

```js
// Every pattern spec is imported here. index.html, tests.html and
// tests/specs.test.js all read this one list.
export const specs = [];
```

- [ ] **Step 4: Run test to verify it passes**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: PASS — 5 tests, 0 failures

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: scaffold visualizations site with renderer kinds and deepEqual"
```

---

### Task 2: Frame collection and validation

**Files:**
- Create: `visualizations/shared/engine.js`
- Test: `visualizations/tests/engine.test.js`

**Interfaces:**
- Consumes: `isKnownKind` from `shared/kinds.js`.
- Produces: `MAX_FRAMES: 2000`, `collectFrames(spec, data): {frames: Frame[], result: any}`, `validateFrames(spec, frames): string[]` (empty array means clean).

- [ ] **Step 1: Write the failing test**

Create `visualizations/tests/engine.test.js`:

```js
import { test } from "node:test";
import assert from "node:assert/strict";
import { collectFrames, validateFrames, MAX_FRAMES } from "../shared/engine.js";

const okView = { kind: "array", cells: [1, 2], pointers: {} };

const fixture = {
  title: "Fixture",
  pseudocode: ["line zero", "line one"],
  run(data, emit) {
    emit({ line: 0, note: "start", view: okView });
    emit({ line: 1, note: "end", view: okView });
    return data * 2;
  },
};

test("collectFrames returns every emitted frame and the result", () => {
  const { frames, result } = collectFrames(fixture, 21);
  assert.equal(frames.length, 2);
  assert.equal(result, 42);
  assert.equal(frames[0].note, "start");
});

test("collectFrames throws past the frame cap instead of hanging", () => {
  const runaway = {
    title: "Runaway",
    pseudocode: ["loop"],
    run(_data, emit) {
      for (;;) emit({ line: 0, note: "spin", view: okView });
    },
  };
  assert.throws(() => collectFrames(runaway, null), /frame cap exceeded/);
});

test("MAX_FRAMES is 2000", () => {
  assert.equal(MAX_FRAMES, 2000);
});

test("validateFrames accepts a well-formed run", () => {
  const { frames } = collectFrames(fixture, 1);
  assert.deepEqual(validateFrames(fixture, frames), []);
});

test("validateFrames rejects an empty run", () => {
  assert.deepEqual(validateFrames(fixture, []), ["no frames emitted"]);
});

test("validateFrames catches a line out of range", () => {
  const problems = validateFrames(fixture, [{ line: 9, note: "x", view: okView }]);
  assert.equal(problems.length, 1);
  assert.match(problems[0], /line 9 out of range 0\.\.1/);
});

test("validateFrames catches a blank note and an unknown kind", () => {
  const problems = validateFrames(fixture, [
    { line: 0, note: "   ", view: okView },
    { line: 0, note: "ok", view: { kind: "hologram" } },
    { line: 0, note: "ok", view: okView, view2: { kind: "hologram" } },
  ]);
  assert.equal(problems.length, 3);
  assert.match(problems[0], /note must be a non-empty string/);
  assert.match(problems[1], /unknown view kind/);
  assert.match(problems[2], /unknown view2 kind/);
});
```

- [ ] **Step 2: Run test to verify it fails**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: FAIL — `Cannot find module .../shared/engine.js`

- [ ] **Step 3: Write minimal implementation**

Create `visualizations/shared/engine.js`:

```js
import { isKnownKind } from "./kinds.js";

export const MAX_FRAMES = 2000;

/**
 * Runs a spec once and collects every emitted frame.
 * Frames are complete snapshots, so the player can seek freely.
 */
export function collectFrames(spec, data) {
  const frames = [];
  const emit = (frame) => {
    if (frames.length >= MAX_FRAMES) {
      throw new Error(
        `frame cap exceeded (${MAX_FRAMES}) in "${spec.title}" — check for a runaway loop`,
      );
    }
    frames.push(frame);
  };
  const result = spec.run(data, emit);
  return { frames, result };
}

/** Returns a list of human-readable problems; an empty array means clean. */
export function validateFrames(spec, frames) {
  const problems = [];
  if (frames.length === 0) problems.push("no frames emitted");

  frames.forEach((frame, i) => {
    const maxLine = spec.pseudocode.length - 1;
    if (!Number.isInteger(frame.line) || frame.line < 0 || frame.line > maxLine) {
      problems.push(`frame ${i}: line ${frame.line} out of range 0..${maxLine}`);
    }
    if (typeof frame.note !== "string" || frame.note.trim() === "") {
      problems.push(`frame ${i}: note must be a non-empty string`);
    }
    if (!frame.view || !isKnownKind(frame.view.kind)) {
      problems.push(`frame ${i}: unknown view kind ${JSON.stringify(frame.view?.kind)}`);
    }
    if (frame.view2 && !isKnownKind(frame.view2.kind)) {
      problems.push(`frame ${i}: unknown view2 kind ${JSON.stringify(frame.view2.kind)}`);
    }
  });

  return problems;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: PASS — 12 tests total, 0 failures

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add frame collection with cap and frame validation"
```

---

### Task 3: The Player

**Files:**
- Modify: `visualizations/shared/engine.js` (append the `Player` class)
- Modify: `visualizations/tests/engine.test.js` (append Player tests)

**Interfaces:**
- Consumes: nothing new.
- Produces: `class Player` from `shared/engine.js` with constructor `(count, { onChange, intervalMs = 700, schedule = setInterval, cancel = clearInterval })`; getters `index`, `count`, `isPlaying`, `atEnd`; methods `seek(i)`, `next()`, `prev()`, `first()`, `last()`, `play()`, `pause()`, `toggle()`, `reset()`, `setSpeed(ms)`.

The scheduler is injected so tests drive time deterministically without real timers.

- [ ] **Step 1: Write the failing test**

Append to `visualizations/tests/engine.test.js`:

```js
import { Player } from "../shared/engine.js";

function fakeClock() {
  let callback = null;
  return {
    schedule: (fn) => {
      callback = fn;
      return 1;
    },
    cancel: () => {
      callback = null;
    },
    tick: () => callback && callback(),
    get running() {
      return callback !== null;
    },
  };
}

test("Player starts at frame 0", () => {
  const p = new Player(5);
  assert.equal(p.index, 0);
  assert.equal(p.count, 5);
  assert.equal(p.isPlaying, false);
});

test("Player.seek clamps to both ends", () => {
  const p = new Player(5);
  p.seek(99);
  assert.equal(p.index, 4);
  p.seek(-3);
  assert.equal(p.index, 0);
});

test("Player.next stops at the last frame, prev stops at 0", () => {
  const p = new Player(3);
  p.next(); p.next(); p.next(); p.next();
  assert.equal(p.index, 2);
  assert.equal(p.atEnd, true);
  p.prev(); p.prev(); p.prev();
  assert.equal(p.index, 0);
});

test("Player.play advances one frame per tick", () => {
  const clock = fakeClock();
  const p = new Player(5, { schedule: clock.schedule, cancel: clock.cancel });
  p.play();
  assert.equal(p.isPlaying, true);
  clock.tick();
  clock.tick();
  assert.equal(p.index, 2);
});

test("Player.play auto-pauses at the end", () => {
  const clock = fakeClock();
  const p = new Player(3, { schedule: clock.schedule, cancel: clock.cancel });
  p.play();
  clock.tick(); clock.tick(); clock.tick();
  assert.equal(p.index, 2);
  assert.equal(p.isPlaying, false);
  assert.equal(clock.running, false);
});

test("Player.onChange fires on every index change", () => {
  const seen = [];
  const p = new Player(4, { onChange: (i) => seen.push(i) });
  p.next();
  p.next();
  p.first();
  assert.deepEqual(seen, [1, 2, 0]);
});

test("Player.reset stops playback and returns to 0", () => {
  const clock = fakeClock();
  const p = new Player(4, { schedule: clock.schedule, cancel: clock.cancel });
  p.play();
  clock.tick();
  p.reset();
  assert.equal(p.index, 0);
  assert.equal(p.isPlaying, false);
});

test("Player handles an empty frame list without throwing", () => {
  const p = new Player(0);
  p.next();
  p.seek(3);
  assert.equal(p.index, 0);
});
```

- [ ] **Step 2: Run test to verify it fails**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: FAIL — `The requested module '../shared/engine.js' does not provide an export named 'Player'`

- [ ] **Step 3: Write minimal implementation**

Append to `visualizations/shared/engine.js`:

```js
/** Owns the current frame index and playback timing. Knows nothing about the DOM. */
export class Player {
  #index = 0;
  #count;
  #timer = null;
  #onChange;
  #intervalMs;
  #schedule;
  #cancel;

  constructor(count, options = {}) {
    const {
      onChange = () => {},
      intervalMs = 700,
      schedule = setInterval,
      cancel = clearInterval,
    } = options;
    this.#count = Math.max(0, count);
    this.#onChange = onChange;
    this.#intervalMs = intervalMs;
    this.#schedule = schedule;
    this.#cancel = cancel;
  }

  get index() { return this.#index; }
  get count() { return this.#count; }
  get isPlaying() { return this.#timer !== null; }
  get atEnd() { return this.#index >= this.#count - 1; }

  seek(target) {
    const last = Math.max(0, this.#count - 1);
    const next = Math.min(last, Math.max(0, target));
    if (next === this.#index) return;
    this.#index = next;
    this.#onChange(this.#index);
  }

  next() { this.seek(this.#index + 1); }
  prev() { this.seek(this.#index - 1); }
  first() { this.seek(0); }
  last() { this.seek(this.#count - 1); }

  play() {
    if (this.isPlaying || this.#count === 0) return;
    if (this.atEnd) this.first();
    this.#timer = this.#schedule(() => {
      this.next();
      if (this.atEnd) this.pause();
    }, this.#intervalMs);
    this.#onChange(this.#index);
  }

  pause() {
    if (!this.isPlaying) return;
    this.#cancel(this.#timer);
    this.#timer = null;
    this.#onChange(this.#index);
  }

  toggle() { this.isPlaying ? this.pause() : this.play(); }

  reset() {
    this.pause();
    this.first();
  }

  setSpeed(intervalMs) {
    this.#intervalMs = intervalMs;
    if (this.isPlaying) {
      this.pause();
      this.play();
    }
  }
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: PASS — 20 tests total, 0 failures

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add Player with injectable scheduler for deterministic tests"
```

---

### Task 4: Spec checking and the console runner

**Files:**
- Modify: `visualizations/shared/selftest.js` (append checking and formatting)
- Modify: `visualizations/tests/selftest.test.js` (append fixture-driven tests)
- Create: `visualizations/tests.node.mjs`

**Interfaces:**
- Consumes: `collectFrames`, `validateFrames` from `shared/engine.js`; `deepEqual` from `shared/selftest.js`.
- Produces: `checkSpec(spec): Row[]`, `runAllChecks(specs): Row[]`, `formatText(rows): string` from `shared/selftest.js`, where `Row = { pattern, input, expected, actual, frames, problems: string[], pass: boolean }`.

- [ ] **Step 1: Write the failing test**

Append to `visualizations/tests/selftest.test.js`:

```js
import { checkSpec, runAllChecks, formatText } from "../shared/selftest.js";

const okView = { kind: "array", cells: [1], pointers: {} };

const goodSpec = {
  title: "Doubler",
  pseudocode: ["double it"],
  inputs: [
    { label: "two", data: 2, expect: 4 },
    { label: "three", data: 3, expect: 6 },
  ],
  run(data, emit) {
    emit({ line: 0, note: "doubling", view: okView });
    return data * 2;
  },
};

const wrongSpec = {
  title: "Broken",
  pseudocode: ["double it"],
  inputs: [{ label: "two", data: 2, expect: 4 }],
  run(data, emit) {
    emit({ line: 0, note: "doubling", view: okView });
    return data * 3;
  },
};

const throwingSpec = {
  title: "Thrower",
  pseudocode: ["boom"],
  inputs: [{ label: "any", data: 1, expect: 1 }],
  run() {
    throw new Error("kaboom");
  },
};

test("checkSpec passes a correct spec and reports frame counts", () => {
  const rows = checkSpec(goodSpec);
  assert.equal(rows.length, 2);
  assert.equal(rows[0].pass, true);
  assert.equal(rows[0].frames, 1);
  assert.equal(rows[0].pattern, "Doubler");
  assert.equal(rows[0].input, "two");
});

test("checkSpec fails a spec whose result differs from expect", () => {
  const [row] = checkSpec(wrongSpec);
  assert.equal(row.pass, false);
  assert.match(row.problems[0], /expected 4, got 6/);
});

test("checkSpec turns a thrown error into a failing row", () => {
  const [row] = checkSpec(throwingSpec);
  assert.equal(row.pass, false);
  assert.match(row.problems[0], /threw: kaboom/);
});

test("runAllChecks flattens rows across specs", () => {
  assert.equal(runAllChecks([goodSpec, wrongSpec]).length, 3);
});

test("formatText reports a summary line", () => {
  const text = formatText(runAllChecks([goodSpec, wrongSpec]));
  assert.match(text, /Doubler/);
  assert.match(text, /2 passed/);
  assert.match(text, /1 failed/);
});
```

- [ ] **Step 2: Run test to verify it fails**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: FAIL — `does not provide an export named 'checkSpec'`

- [ ] **Step 3: Write minimal implementation**

Append to `visualizations/shared/selftest.js`:

```js
import { collectFrames, validateFrames } from "./engine.js";

/** Runs every preset input of one spec and reports a row per input. */
export function checkSpec(spec) {
  return spec.inputs.map((input) => {
    const row = {
      pattern: spec.title,
      input: input.label,
      expected: input.expect,
      actual: undefined,
      frames: 0,
      problems: [],
      pass: false,
    };

    try {
      const { frames, result } = collectFrames(spec, input.data);
      row.actual = result;
      row.frames = frames.length;
      row.problems.push(...validateFrames(spec, frames));
      if (!deepEqual(result, input.expect)) {
        row.problems.push(
          `expected ${JSON.stringify(input.expect)}, got ${JSON.stringify(result)}`,
        );
      }
    } catch (err) {
      row.problems.push(`threw: ${err.message}`);
    }

    row.pass = row.problems.length === 0;
    return row;
  });
}

export function runAllChecks(specs) {
  return specs.flatMap((spec) => checkSpec(spec));
}

export function formatText(rows) {
  const lines = rows.map((row) => {
    const status = row.pass ? "PASS" : "FAIL";
    const detail = row.pass
      ? `${row.frames} frames`
      : row.problems.join("; ");
    return `  ${status}  ${row.pattern} — ${row.input}  (${detail})`;
  });
  const passed = rows.filter((r) => r.pass).length;
  const failed = rows.length - passed;
  lines.push("", `  ${passed} passed, ${failed} failed, ${rows.length} total`);
  return lines.join("\n");
}
```

Note the import sits mid-file, which is valid ESM (imports hoist), but move it to the top of `selftest.js` alongside the others for readability.

Create `visualizations/tests.node.mjs`:

```js
import { specs } from "./patterns/registry.js";
import { runAllChecks, formatText } from "./shared/selftest.js";

if (specs.length === 0) {
  console.log("No pattern specs registered yet.");
  process.exit(0);
}

const rows = runAllChecks(specs);
console.log(formatText(rows));
process.exit(rows.every((row) => row.pass) ? 0 : 1);
```

- [ ] **Step 4: Run test to verify it passes**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: PASS — 25 tests total, 0 failures

Run: `node visualizations/tests.node.mjs`
Expected: prints `No pattern specs registered yet.` and exits 0

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add spec checking harness and node console runner"
```

---

### Task 5: Render dispatch, the array renderer, and the browser harness

**Files:**
- Create: `visualizations/shared/render.js`
- Create: `visualizations/shared/renderers/array.js`
- Create: `visualizations/tests.html`

**Interfaces:**
- Consumes: nothing from earlier tasks (renderers are standalone DOM code).
- Produces: `paint(view, el): void` and `errorBanner(message): HTMLElement` from `shared/render.js`; `renderArray(view, el): void` from `shared/renderers/array.js`.

Later renderer tasks add exactly one import line and one `RENDERERS` entry to `render.js`, and one harness case to `tests.html`.

- [ ] **Step 1: Write `shared/renderers/array.js`**

```js
export function renderArray(view, el) {
  const wrap = document.createElement("div");
  wrap.className = "viz-array";

  const pointersByIndex = {};
  for (const [name, index] of Object.entries(view.pointers ?? {})) {
    (pointersByIndex[index] ??= []).push(name);
  }

  (view.cells ?? []).forEach((cell, i) => {
    const col = document.createElement("div");
    col.className = "viz-array__col";

    const pointer = document.createElement("div");
    pointer.className = "viz-array__ptr";
    pointer.textContent = (pointersByIndex[i] ?? []).join(" ");

    const box = document.createElement("div");
    box.className = "viz-array__cell";
    if (view.colors?.[i]) box.classList.add(`is-${view.colors[i]}`);
    if (view.window && i >= view.window.start && i <= view.window.end) {
      box.classList.add("is-window");
    }
    box.textContent = String(cell);

    const index = document.createElement("div");
    index.className = "viz-array__index";
    index.textContent = String(i);

    col.append(pointer, box, index);
    wrap.append(col);
  });

  el.append(wrap);

  if (view.caption) {
    const caption = document.createElement("p");
    caption.className = "viz-caption";
    caption.textContent = view.caption;
    el.append(caption);
  }
}
```

- [ ] **Step 2: Write `shared/render.js`**

```js
import { renderArray } from "./renderers/array.js";

// Each renderer task adds one import above and one entry here.
const RENDERERS = {
  array: renderArray,
};

export function errorBanner(message) {
  const banner = document.createElement("div");
  banner.className = "viz-error";
  banner.textContent = message;
  return banner;
}

/** Repaints `el` from scratch for the given view. Never throws. */
export function paint(view, el) {
  el.replaceChildren();
  const renderer = RENDERERS[view?.kind];
  if (!renderer) {
    el.append(errorBanner(`unknown view kind: ${JSON.stringify(view?.kind)}`));
    return;
  }
  try {
    renderer(view, el);
  } catch (err) {
    el.replaceChildren(errorBanner(`renderer "${view.kind}" failed: ${err.message}`));
  }
}
```

- [ ] **Step 3: Write `tests.html` with the spec table and the renderer harness**

```html
<!doctype html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>Tests — DSA Pattern Visualizations</title>
<link rel="stylesheet" href="shared/styles.css">
</head>
<body>
<main class="page">
  <h1>Test harness</h1>
  <section>
    <h2>Renderers</h2>
    <table id="renderer-results"></table>
  </section>
  <section>
    <h2>Pattern specs</h2>
    <table id="spec-results"></table>
  </section>
</main>
<script type="module">
  import { specs } from "./patterns/registry.js";
  import { runAllChecks } from "./shared/selftest.js";
  import { paint } from "./shared/render.js";

  // Each renderer task appends one case here.
  const rendererCases = [
    {
      name: "array renders one cell per entry",
      view: { kind: "array", cells: [1, 2, 3, 4, 5], pointers: { L: 0, R: 4 } },
      check: (el) => el.querySelectorAll(".viz-array__cell").length === 5,
    },
    {
      name: "array reports an unknown kind instead of blanking",
      view: { kind: "hologram" },
      check: (el) => el.querySelectorAll(".viz-error").length === 1,
    },
  ];

  function row(cells, pass) {
    const tr = document.createElement("tr");
    tr.className = pass ? "is-pass" : "is-fail";
    for (const text of cells) {
      const td = document.createElement("td");
      td.textContent = text;
      tr.append(td);
    }
    return tr;
  }

  const rendererTable = document.getElementById("renderer-results");
  const sandbox = document.createElement("div");
  for (const testCase of rendererCases) {
    let pass = false;
    let detail = "";
    try {
      paint(testCase.view, sandbox);
      pass = testCase.check(sandbox) === true;
    } catch (err) {
      detail = err.message;
    }
    rendererTable.append(row([pass ? "PASS" : "FAIL", testCase.name, detail], pass));
  }

  const specTable = document.getElementById("spec-results");
  if (specs.length === 0) {
    specTable.append(row(["—", "no pattern specs registered yet", ""], true));
  } else {
    for (const result of runAllChecks(specs)) {
      specTable.append(
        row(
          [
            result.pass ? "PASS" : "FAIL",
            `${result.pattern} — ${result.input}`,
            result.pass ? `${result.frames} frames` : result.problems.join("; "),
          ],
          result.pass,
        ),
      );
    }
  }
</script>
</body>
</html>
```

- [ ] **Step 4: Verify in the browser**

Run: `cd visualizations && python -m http.server 8000`
Open: `http://localhost:8000/tests.html`
Expected: two green rows under **Renderers**; one neutral row under **Pattern specs** reading "no pattern specs registered yet". No console errors. (Styling is unstyled at this point — Task 6 adds `styles.css`. A 404 for the stylesheet here is expected.)

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add render dispatch, array renderer, and browser test harness"
```

---

### Task 6: Page chrome, styles, and the first pattern page

**Files:**
- Create: `visualizations/shared/styles.css`
- Create: `visualizations/shared/page.js`
- Create: `visualizations/patterns/two-pointers.js`
- Create: `visualizations/patterns/two-pointers.html`
- Modify: `visualizations/patterns/registry.js`
- Test: `visualizations/tests/specs.test.js`

**Interfaces:**
- Consumes: `collectFrames`, `validateFrames`, `Player` from `shared/engine.js`; `paint`, `errorBanner` from `shared/render.js`.
- Produces: `boot(spec, root): void` from `shared/page.js`; the first entry in `patterns/registry.js`.

This is the task that proves the whole stack end to end.

- [ ] **Step 1: Write the failing test**

Create `visualizations/tests/specs.test.js`:

```js
import { test } from "node:test";
import assert from "node:assert/strict";
import { specs } from "../patterns/registry.js";
import { runAllChecks } from "../shared/selftest.js";

test("registry exports at least one spec", () => {
  assert.ok(specs.length > 0, "patterns/registry.js exports no specs");
});

test("every spec declares the required fields", () => {
  for (const spec of specs) {
    assert.equal(typeof spec.title, "string", "title");
    assert.equal(typeof spec.folder, "string", `${spec.title}: folder`);
    assert.equal(typeof spec.complexity?.time, "string", `${spec.title}: complexity.time`);
    assert.equal(typeof spec.complexity?.space, "string", `${spec.title}: complexity.space`);
    assert.equal(typeof spec.whenToUse, "string", `${spec.title}: whenToUse`);
    assert.ok(Array.isArray(spec.problems) && spec.problems.length > 0, `${spec.title}: problems`);
    assert.ok(Array.isArray(spec.pseudocode) && spec.pseudocode.length > 0, `${spec.title}: pseudocode`);
    assert.ok(Array.isArray(spec.inputs) && spec.inputs.length > 0, `${spec.title}: inputs`);
    assert.equal(typeof spec.run, "function", `${spec.title}: run`);
  }
});

test("spec titles are unique", () => {
  const titles = specs.map((s) => s.title);
  assert.equal(new Set(titles).size, titles.length);
});

for (const row of runAllChecks(specs)) {
  test(`${row.pattern} — ${row.input}`, () => {
    assert.deepEqual(row.problems, [], row.problems.join("; "));
  });
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: FAIL — `patterns/registry.js exports no specs`

- [ ] **Step 3: Write the two-pointers spec**

Create `visualizations/patterns/two-pointers.js`:

```js
const CODE = {
  init: 0,
  loop: 1,
  compare: 2,
  advance: 3,
  done: 4,
};

function arrayView(chars, L, R, colors = {}) {
  return { kind: "array", cells: chars, pointers: { L, R }, colors };
}

export default {
  title: "Two Pointers",
  folder: "ArrayAndString",
  complexity: { time: "O(n)", space: "O(1)" },
  whenToUse:
    "The input is sorted, or the answer depends on comparing the two ends of a sequence and working inward.",
  problems: [
    "125. Valid Palindrome",
    "167. Two Sum II — Input Array Is Sorted",
    "392. Is Subsequence",
    "344. Reverse String",
  ],
  pseudocode: [
    "L = 0, R = n - 1",
    "while L < R:",
    "  if s[L] != s[R]: return false",
    "  L += 1, R -= 1",
    "return true",
  ],
  inputs: [
    { label: "racecar (palindrome)", data: "racecar", expect: true },
    { label: "hello (not a palindrome)", data: "hello", expect: false },
    { label: "abba (even length)", data: "abba", expect: true },
  ],
  run(s, emit) {
    const chars = [...s];
    let L = 0;
    let R = chars.length - 1;

    emit({
      line: CODE.init,
      note: `place L at 0 and R at ${R}`,
      view: arrayView(chars, L, R),
    });

    while (L < R) {
      emit({
        line: CODE.compare,
        note: `compare '${chars[L]}' with '${chars[R]}'`,
        view: arrayView(chars, L, R, { [L]: "active", [R]: "active" }),
      });

      if (chars[L] !== chars[R]) {
        emit({
          line: CODE.compare,
          note: `'${chars[L]}' != '${chars[R]}' — not a palindrome`,
          view: arrayView(chars, L, R, { [L]: "fail", [R]: "fail" }),
        });
        return false;
      }

      L += 1;
      R -= 1;
      emit({
        line: CODE.advance,
        note: `characters match — move both pointers inward to L=${L}, R=${R}`,
        view: arrayView(chars, L, R),
      });
    }

    emit({
      line: CODE.done,
      note: "pointers met or crossed — every pair matched",
      view: arrayView(chars, L, R, Object.fromEntries(chars.map((_, i) => [i, "pass"]))),
    });
    return true;
  },
};
```

Update `visualizations/patterns/registry.js`:

```js
import twoPointers from "./two-pointers.js";

export const specs = [twoPointers];
```

- [ ] **Step 4: Run the test to verify the spec passes**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: PASS — the three structural tests plus three `Two Pointers — …` cases

Run: `node visualizations/tests.node.mjs`
Expected: three PASS rows, exit 0

- [ ] **Step 5: Write `shared/page.js`**

```js
import { collectFrames, validateFrames, Player } from "./engine.js";
import { paint, errorBanner } from "./render.js";

const SPEEDS = [
  { label: "0.5×", ms: 1400 },
  { label: "1×", ms: 700 },
  { label: "2×", ms: 350 },
  { label: "4×", ms: 175 },
];

function el(tag, className, text) {
  const node = document.createElement(tag);
  if (className) node.className = className;
  if (text !== undefined) node.textContent = text;
  return node;
}

function buildHeader(spec) {
  const header = el("header", "page__header");
  header.append(el("p", "page__folder", spec.folder));
  header.append(el("h1", "page__title", spec.title));
  header.append(el("p", "page__when", spec.whenToUse));

  const meta = el("dl", "page__meta");
  meta.append(el("dt", null, "Time"), el("dd", null, spec.complexity.time));
  meta.append(el("dt", null, "Space"), el("dd", null, spec.complexity.space));
  header.append(meta);

  const problems = el("ul", "page__problems");
  for (const problem of spec.problems) problems.append(el("li", null, problem));
  header.append(el("h2", "page__problems-title", "Problems using this pattern"), problems);

  const home = el("a", "page__home", "← All patterns");
  home.href = "../index.html";
  header.prepend(home);
  return header;
}

function buildPseudocode(spec) {
  const list = el("ol", "code");
  for (const line of spec.pseudocode) {
    const item = el("li", "code__line");
    item.textContent = line;
    list.append(item);
  }
  return list;
}

function buildControls() {
  const bar = el("div", "controls");
  const buttons = {
    first: el("button", "controls__btn", "|◀"),
    prev: el("button", "controls__btn", "◀"),
    toggle: el("button", "controls__btn controls__btn--play", "▶ Play"),
    next: el("button", "controls__btn", "▶"),
    last: el("button", "controls__btn", "▶|"),
  };
  for (const button of Object.values(buttons)) bar.append(button);

  const scrub = el("input", "controls__scrub");
  scrub.type = "range";
  scrub.min = "0";
  scrub.step = "1";
  bar.append(scrub);

  const counter = el("span", "controls__counter");
  bar.append(counter);

  const speed = el("select", "controls__speed");
  for (const option of SPEEDS) {
    const opt = el("option", null, option.label);
    opt.value = String(option.ms);
    if (option.ms === 700) opt.selected = true;
    speed.append(opt);
  }
  bar.append(speed);

  return { bar, buttons, scrub, counter, speed };
}

function buildInputPicker(spec) {
  const wrap = el("div", "inputs");
  const label = el("label", "inputs__label", "Example input");
  label.htmlFor = "input-picker";

  const picker = el("select", "inputs__select");
  picker.id = "input-picker";
  spec.inputs.forEach((input, i) => {
    const option = el("option", null, input.label);
    option.value = String(i);
    picker.append(option);
  });

  wrap.append(label, picker);
  return { wrap, picker };
}

export function boot(spec, root) {
  root.replaceChildren();

  const viz = el("div", "stage__viz");
  const viz2 = el("div", "stage__viz stage__viz--secondary");
  viz2.hidden = true;
  const panels = el("div", "stage__panels");
  panels.append(viz, viz2);

  const codeList = buildPseudocode(spec);
  const stage = el("section", "stage");
  stage.append(panels, codeList);

  const note = el("p", "note");
  const controls = buildControls();
  const inputs = buildInputPicker(spec);
  const picker = inputs.picker;

  root.append(buildHeader(spec), inputs.wrap, stage, note, controls.bar);

  let player = null;
  let frames = [];

  function showFrame(index) {
    const frame = frames[index];
    if (!frame) return;

    paint(frame.view, viz);
    if (frame.view2) {
      viz2.hidden = false;
      paint(frame.view2, viz2);
    } else {
      viz2.hidden = true;
      viz2.replaceChildren();
    }

    for (const [i, line] of [...codeList.children].entries()) {
      line.classList.toggle("is-active", i === frame.line);
    }

    note.textContent = frame.note;
    note.classList.remove("viz-error");
    controls.scrub.value = String(index);
    controls.counter.textContent = `${index + 1} / ${frames.length}`;
    controls.buttons.toggle.textContent = player?.isPlaying ? "❚❚ Pause" : "▶ Play";
  }

  function showError(message) {
    frames = [];
    viz.replaceChildren(errorBanner(message));
    viz2.hidden = true;
    note.textContent = message;
    note.classList.add("viz-error");
    for (const button of Object.values(controls.buttons)) button.disabled = true;
    controls.scrub.disabled = true;
  }

  function load(inputIndex) {
    const input = spec.inputs[inputIndex];
    try {
      const collected = collectFrames(spec, input.data);
      const problems = validateFrames(spec, collected.frames);
      if (problems.length > 0) {
        showError(`Invalid frames: ${problems.join("; ")}`);
        return;
      }
      frames = collected.frames;
    } catch (err) {
      showError(err.message);
      return;
    }

    for (const button of Object.values(controls.buttons)) button.disabled = false;
    controls.scrub.disabled = false;
    controls.scrub.max = String(frames.length - 1);

    player?.pause();
    player = new Player(frames.length, {
      onChange: showFrame,
      intervalMs: Number(controls.speed.value),
    });
    showFrame(0);
  }

  controls.buttons.first.addEventListener("click", () => player.first());
  controls.buttons.prev.addEventListener("click", () => player.prev());
  controls.buttons.next.addEventListener("click", () => player.next());
  controls.buttons.last.addEventListener("click", () => player.last());
  controls.buttons.toggle.addEventListener("click", () => {
    player.toggle();
    showFrame(player.index);
  });
  controls.scrub.addEventListener("input", () => player.seek(Number(controls.scrub.value)));
  controls.speed.addEventListener("change", () => player.setSpeed(Number(controls.speed.value)));
  picker.addEventListener("change", () => load(Number(picker.value)));

  document.addEventListener("keydown", (event) => {
    if (event.target instanceof HTMLSelectElement || event.target instanceof HTMLInputElement) return;
    const actions = {
      " ": () => { player.toggle(); showFrame(player.index); },
      ArrowRight: () => player.next(),
      ArrowLeft: () => player.prev(),
      Home: () => player.first(),
      End: () => player.last(),
    };
    const action = actions[event.key];
    if (action) {
      event.preventDefault();
      action();
    }
  });

  load(0);
}
```

- [ ] **Step 6: Write `shared/styles.css`**

Write a stylesheet covering the class names used above: `.page`, `.page__header`, `.page__folder`, `.page__title`, `.page__when`, `.page__meta`, `.page__problems`, `.page__home`, `.stage`, `.stage__viz`, `.code`, `.code__line`, `.code__line.is-active`, `.note`, `.controls`, `.controls__btn`, `.controls__scrub`, `.controls__counter`, `.controls__speed`, `.inputs`, `.inputs__label`, `.inputs__select`, `.stage__panels`, `.stage__viz`, `.viz-error`, `.viz-caption`, `.viz-array`, `.viz-array__col`, `.viz-array__ptr`, `.viz-array__cell`, `.viz-array__index`, and the cell states `.is-active`, `.is-pass`, `.is-fail`, `.is-dim`, `.is-window`.

Requirements:
- Desktop-first layout: header across the top, then a two-column stage (visualization left, pseudocode right) that collapses to one column under 900px.
- Define every color as a custom property on `:root` so later renderers reuse them: at minimum `--bg`, `--fg`, `--muted`, `--line`, `--accent`, `--pass`, `--fail`, `--window`.
- `.code__line.is-active` must be unmistakable — background fill plus a left border, not just a color shift.
- `.viz-array__cell` is a fixed-size monospace box (min 2.5rem square) so cells do not jump width as values change.
- `.viz-error` is a bordered block in `--fail`.
- Use `prefers-color-scheme: dark` to swap the `:root` custom properties. Do not define any color outside a custom property.

- [ ] **Step 7: Write the page shell**

Create `visualizations/patterns/two-pointers.html` using the shell template from the Conventions section verbatim.

- [ ] **Step 8: Verify in the browser**

Run: `cd visualizations && python -m http.server 8000`
Open: `http://localhost:8000/patterns/two-pointers.html`
Confirm each of these:
- The page shows title, folder, complexity, when-to-use, and four problems.
- Pressing Play steps through and stops at the last frame.
- The active pseudocode line moves as it plays.
- `◀` walks backward without a visual glitch, and Home/End/Space/arrows work.
- Switching the dropdown to "hello (not a palindrome)" restarts at frame 1 and ends on a red mismatch.
- `http://localhost:8000/tests.html` now shows three green spec rows.

- [ ] **Step 9: Commit**

```bash
git add visualizations/
git commit -m "feat: add page chrome, styles, and the two-pointers visualization"
```

---

### Task 7: Collection renderer and the stacks page

**Files:**
- Create: `visualizations/shared/renderers/collection.js`
- Create: `visualizations/patterns/stacks.js`
- Create: `visualizations/patterns/stacks.html`
- Modify: `visualizations/shared/render.js`, `visualizations/patterns/registry.js`, `visualizations/tests.html`

**Interfaces:**
- Produces: `renderCollection(view, el): void`, registered under kind `collection`.

- [ ] **Step 1: Add the failing spec**

Create `visualizations/patterns/stacks.js`:

```js
const PAIRS = { ")": "(", "]": "[", "}": "{" };

function views(chars, i, stack, colors = {}) {
  return {
    view: { kind: "array", cells: chars, pointers: { i }, colors },
    view2: {
      kind: "collection",
      label: "stack",
      items: stack.map((value) => ({ value })),
      orientation: "vertical",
      highlight: stack.length > 0 ? [stack.length - 1] : [],
    },
  };
}

export default {
  title: "Stacks",
  folder: "StackAndQueue",
  complexity: { time: "O(n)", space: "O(n)" },
  whenToUse:
    "The most recent unmatched item is the one you need next — nesting, undo, or matching pairs.",
  problems: [
    "20. Valid Parentheses",
    "1047. Remove All Adjacent Duplicates In String",
    "71. Simplify Path",
    "155. Min Stack",
  ],
  pseudocode: [
    "stack = []",
    "for ch in s:",
    "  if ch is an opener: push ch",
    "  else if stack is empty or top != match(ch): return false",
    "  else: pop",
    "return stack is empty",
  ],
  inputs: [
    { label: "({[]}) — balanced", data: "({[]})", expect: true },
    { label: "(] — mismatched", data: "(]", expect: false },
    { label: "((( — never closed", data: "(((", expect: false },
  ],
  run(s, emit) {
    const chars = [...s];
    const stack = [];

    emit({ line: 0, note: "start with an empty stack", ...views(chars, -1, stack) });

    for (let i = 0; i < chars.length; i += 1) {
      const ch = chars[i];

      if (!(ch in PAIRS)) {
        stack.push(ch);
        emit({
          line: 2,
          note: `'${ch}' is an opener — push it`,
          ...views(chars, i, stack, { [i]: "active" }),
        });
        continue;
      }

      if (stack.length === 0 || stack.at(-1) !== PAIRS[ch]) {
        emit({
          line: 3,
          note:
            stack.length === 0
              ? `'${ch}' closes nothing — the stack is empty`
              : `'${ch}' does not match the top of the stack ('${stack.at(-1)}')`,
          ...views(chars, i, stack, { [i]: "fail" }),
        });
        return false;
      }

      stack.pop();
      emit({
        line: 4,
        note: `'${ch}' matches — pop it off`,
        ...views(chars, i, stack, { [i]: "pass" }),
      });
    }

    const balanced = stack.length === 0;
    emit({
      line: 5,
      note: balanced
        ? "every opener was closed — the stack is empty"
        : `${stack.length} opener(s) were never closed`,
      ...views(chars, chars.length - 1, stack),
    });
    return balanced;
  },
};
```

Add to `visualizations/patterns/registry.js`:

```js
import stacks from "./stacks.js";
// ...
export const specs = [twoPointers, stacks];
```

- [ ] **Step 2: Run the tests to verify the port, then see the missing renderer fail**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: PASS — the three `Stacks — …` cases confirm the algorithm port is correct. (`collection` is already a known kind in `kinds.js`, so `validateFrames` is satisfied; only the drawing is missing.)

Then create `visualizations/patterns/stacks.html` from the shell template, substituting `Stacks` and `./stacks.js`, and open `http://localhost:8000/patterns/stacks.html`.
Expected: the array renders, but the second panel shows the error banner `unknown view kind: "collection"`. That banner is this task's RED — Step 3 turns it green.

- [ ] **Step 3: Write `shared/renderers/collection.js`**

```js
export function renderCollection(view, el) {
  const wrap = document.createElement("div");
  wrap.className = `viz-collection viz-collection--${view.orientation ?? "vertical"}`;

  const label = document.createElement("div");
  label.className = "viz-collection__label";
  label.textContent = `${view.label} (${(view.items ?? []).length})`;
  wrap.append(label);

  const items = document.createElement("div");
  items.className = "viz-collection__items";

  const highlight = new Set(view.highlight ?? []);
  (view.items ?? []).forEach((item, i) => {
    const box = document.createElement("div");
    box.className = "viz-collection__item";
    if (highlight.has(i)) box.classList.add("is-active");
    box.textContent = item.key === undefined ? String(item.value) : `${item.key}: ${item.value}`;
    items.append(box);
  });

  if ((view.items ?? []).length === 0) {
    const empty = document.createElement("div");
    empty.className = "viz-collection__empty";
    empty.textContent = "empty";
    items.append(empty);
  }

  wrap.append(items);
  el.append(wrap);

  if (view.caption) {
    const caption = document.createElement("p");
    caption.className = "viz-caption";
    caption.textContent = view.caption;
    el.append(caption);
  }
}
```

Register it in `shared/render.js`:

```js
import { renderCollection } from "./renderers/collection.js";
// ...
const RENDERERS = {
  array: renderArray,
  collection: renderCollection,
};
```

Add the styles for `.viz-collection`, `.viz-collection--vertical` (column, newest on top — use `flex-direction: column-reverse` so the stack top sits at the top), `.viz-collection--horizontal` (row, oldest at left), `.viz-collection__label`, `.viz-collection__items`, `.viz-collection__item`, `.viz-collection__item.is-active`, `.viz-collection__empty` to `shared/styles.css`, reusing the existing custom properties.

Add a harness case to the `rendererCases` array in `tests.html`:

```js
{
  name: "collection renders one box per item",
  view: {
    kind: "collection",
    label: "stack",
    items: [{ value: "(" }, { value: "[" }],
    orientation: "vertical",
    highlight: [1],
  },
  check: (el) => el.querySelectorAll(".viz-collection__item").length === 2,
},
```

- [ ] **Step 4: Verify the renderer**

Run: `node --test "visualizations/tests/*.test.js"` → PASS
Reload `http://localhost:8000/patterns/stacks.html` — the error banner is gone. Confirm the stack grows and shrinks alongside the string, and that `(]` ends red.
Open `http://localhost:8000/tests.html` and confirm the new renderer case and three new spec rows are green.

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add collection renderer and the stacks visualization"
```

---

### Task 8: LinkedList renderer and the fast/slow pointers page

**Files:**
- Create: `visualizations/shared/renderers/linkedList.js`
- Create: `visualizations/patterns/fast-slow-pointers.js`
- Create: `visualizations/patterns/fast-slow-pointers.html`
- Modify: `visualizations/shared/render.js`, `visualizations/patterns/registry.js`, `visualizations/tests.html`, `visualizations/shared/styles.css`

**Interfaces:**
- Produces: `renderLinkedList(view, el): void`, registered under kind `linkedList`.

Input data shape for both linked-list pages: `{ values: any[], cycleTo: number | null }` — `cycleTo` is the index the last node points back to, or `null` for a plain list.

- [ ] **Step 1: Write the spec**

Create `visualizations/patterns/fast-slow-pointers.js`:

```js
function buildList({ values, cycleTo }) {
  const nodes = values.map((value, i) => ({ id: `n${i}`, value }));
  const next = {};
  values.forEach((_, i) => {
    next[`n${i}`] = i < values.length - 1 ? `n${i + 1}` : cycleTo === null ? null : `n${cycleTo}`;
  });
  return { nodes, next };
}

function view(list, slow, fast, colors = {}) {
  return {
    kind: "linkedList",
    nodes: list.nodes,
    next: list.next,
    pointers: { slow, fast },
    colors,
  };
}

export default {
  title: "Fast and Slow Pointers",
  folder: "LinkedList",
  complexity: { time: "O(n)", space: "O(1)" },
  whenToUse:
    "You need a position defined relative to the list's length — its middle, its cycle, or the nth node from the end — in one pass and constant space.",
  problems: [
    "141. Linked List Cycle",
    "142. Linked List Cycle II",
    "876. Middle of the Linked List",
    "19. Remove Nth Node From End of List",
  ],
  pseudocode: [
    "slow = head, fast = head",
    "while fast and fast.next:",
    "  slow = slow.next",
    "  fast = fast.next.next",
    "  if slow == fast: return true",
    "return false",
  ],
  inputs: [
    { label: "3 → 2 → 0 → -4 → (back to index 1)", data: { values: [3, 2, 0, -4], cycleTo: 1 }, expect: true },
    { label: "1 → 2 (no cycle)", data: { values: [1, 2], cycleTo: null }, expect: false },
    { label: "1 → (back to itself)", data: { values: [1], cycleTo: 0 }, expect: true },
  ],
  run(data, emit) {
    const list = buildList(data);
    let slow = list.nodes[0]?.id ?? null;
    let fast = slow;

    emit({ line: 0, note: "both pointers start at the head", view: view(list, slow, fast) });

    while (fast !== null && list.next[fast] !== null && list.next[fast] !== undefined) {
      slow = list.next[slow];
      emit({ line: 2, note: `slow advances one step to ${slow}`, view: view(list, slow, fast) });

      fast = list.next[list.next[fast]];
      emit({ line: 3, note: `fast advances two steps to ${fast}`, view: view(list, slow, fast) });

      if (slow === fast) {
        emit({
          line: 4,
          note: `slow and fast met at ${slow} — the list has a cycle`,
          view: view(list, slow, fast, { [slow]: "pass" }),
        });
        return true;
      }
      emit({ line: 4, note: "pointers have not met yet — keep going", view: view(list, slow, fast) });
    }

    emit({
      line: 5,
      note: "fast ran off the end — no cycle",
      view: view(list, slow, fast),
    });
    return false;
  },
};
```

Register it in `patterns/registry.js`.

- [ ] **Step 2: Run the test to verify the port is correct**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: the three `Fast and Slow Pointers — …` cases PASS. If any fails, fix `run` — not the `expect` values, which are correct.

- [ ] **Step 3: Write `shared/renderers/linkedList.js`**

Render nodes left to right in `view.nodes` order as `.viz-list__node` boxes separated by `.viz-list__arrow` elements. Requirements:
- Each node carries `data-id` and shows its value.
- Pointer names from `view.pointers` render in a `.viz-list__ptr` slot above the node whose id they match; two pointers on the same node both show, space-separated.
- `view.colors[id]` adds `is-<state>` to that node.
- When `view.next[lastId]` is not `null`, append a `.viz-list__cycle` element after the last node reading `↩ back to <value>` instead of drawing a curved edge — this keeps the renderer to plain block layout with no SVG.
- Guard against an empty `nodes` array by rendering `.viz-collection__empty` with the text `empty list`.

Register `linkedList: renderLinkedList` in `shared/render.js`, add the matching styles, and add a harness case to `tests.html` asserting a three-node list produces three `.viz-list__node` elements.

- [ ] **Step 4: Create the shell and verify in the browser**

Create `visualizations/patterns/fast-slow-pointers.html` from the template.
Open the page and confirm slow and fast separate, that the cycle marker appears for input 1, and that input 2 ends with "no cycle".

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add linked list renderer and the fast/slow pointers visualization"
```

---

### Task 9: Tree renderer and the tree BFS page

**Files:**
- Create: `visualizations/shared/renderers/tree.js`
- Create: `visualizations/patterns/tree-bfs.js`
- Create: `visualizations/patterns/tree-bfs.html`
- Modify: `visualizations/shared/render.js`, `visualizations/patterns/registry.js`, `visualizations/tests.html`, `visualizations/shared/styles.css`

**Interfaces:**
- Produces: `renderTree(view, el): void`, registered under kind `tree`.

Tree input data shape, shared by all four tree pages: `{ nodes: [{id, value, x, y, left, right}] }` where `left`/`right` are child ids or `null`, and `x`/`y` are normalized `[0,1]` positions authored by hand.

- [ ] **Step 1: Write the spec**

Create `visualizations/patterns/tree-bfs.js`:

```js
const SAMPLE = {
  nodes: [
    { id: "a", value: 3, x: 0.5, y: 0.1, left: "b", right: "c" },
    { id: "b", value: 9, x: 0.25, y: 0.5, left: null, right: null },
    { id: "c", value: 20, x: 0.75, y: 0.5, left: "d", right: "e" },
    { id: "d", value: 15, x: 0.6, y: 0.9, left: null, right: null },
    { id: "e", value: 7, x: 0.9, y: 0.9, left: null, right: null },
  ],
};

const SINGLE = {
  nodes: [{ id: "a", value: 1, x: 0.5, y: 0.5, left: null, right: null }],
};

function index(tree) {
  return Object.fromEntries(tree.nodes.map((n) => [n.id, n]));
}

function edgesOf(tree) {
  const edges = [];
  for (const node of tree.nodes) {
    if (node.left) edges.push([node.id, node.left]);
    if (node.right) edges.push([node.id, node.right]);
  }
  return edges;
}

function views(tree, current, visited, queue, byId) {
  return {
    view: {
      kind: "tree",
      nodes: tree.nodes.map(({ id, value, x, y }) => ({ id, value, x, y })),
      edges: edgesOf(tree),
      current,
      visited: [...visited],
      frontier: [...queue],
    },
    view2: {
      kind: "collection",
      label: "queue",
      items: queue.map((id) => ({ value: byId[id].value })),
      orientation: "horizontal",
      highlight: queue.length > 0 ? [0] : [],
    },
  };
}

export default {
  title: "Tree BFS",
  folder: "TreesAndGraphs",
  complexity: { time: "O(n)", space: "O(n)" },
  whenToUse:
    "The answer depends on depth — level order, the view from one side, or the shallowest node satisfying a condition.",
  problems: [
    "102. Binary Tree Level Order Traversal",
    "199. Binary Tree Right Side View",
    "515. Find Largest Value in Each Tree Row",
    "103. Binary Tree Zigzag Level Order Traversal",
  ],
  pseudocode: [
    "queue = [root], levels = []",
    "while queue is not empty:",
    "  level = []",
    "  for each node currently in queue:",
    "    pop it, append its value to level",
    "    push its children onto queue",
    "  levels.append(level)",
    "return levels",
  ],
  inputs: [
    { label: "[3,9,20,null,null,15,7]", data: SAMPLE, expect: [[3], [9, 20], [15, 7]] },
    { label: "single node", data: SINGLE, expect: [[1]] },
  ],
  run(tree, emit) {
    const byId = index(tree);
    const levels = [];
    const visited = [];
    let queue = tree.nodes.length > 0 ? [tree.nodes[0].id] : [];

    emit({
      line: 0,
      note: "seed the queue with the root",
      ...views(tree, null, visited, queue, byId),
    });

    while (queue.length > 0) {
      const width = queue.length;
      const level = [];
      emit({
        line: 3,
        note: `this level holds ${width} node(s)`,
        ...views(tree, null, visited, queue, byId),
      });

      for (let i = 0; i < width; i += 1) {
        const id = queue.shift();
        const node = byId[id];
        level.push(node.value);
        visited.push(id);
        emit({
          line: 4,
          note: `visit ${node.value} — add it to the current level`,
          ...views(tree, id, visited, queue, byId),
        });

        for (const child of [node.left, node.right]) {
          if (child) {
            queue.push(child);
            emit({
              line: 5,
              note: `enqueue child ${byId[child].value}`,
              ...views(tree, id, visited, queue, byId),
            });
          }
        }
      }

      levels.push(level);
      emit({
        line: 6,
        note: `level complete: [${level.join(", ")}]`,
        ...views(tree, null, visited, queue, byId),
      });
    }

    emit({
      line: 7,
      note: `all levels collected: ${JSON.stringify(levels)}`,
      ...views(tree, null, visited, queue, byId),
    });
    return levels;
  },
};
```

Register it in `patterns/registry.js`.

- [ ] **Step 2: Run the test to verify the port is correct**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: both `Tree BFS — …` cases PASS.

- [ ] **Step 3: Write `shared/renderers/tree.js`**

This renderer uses inline SVG, since edges are diagonal lines. Requirements:
- Create an `<svg>` with `viewBox="0 0 100 100"` and `preserveAspectRatio="xMidYMid meet"`, class `viz-tree`.
- Map each node's normalized `x`/`y` to `x * 100`, `y * 100`.
- Draw `view.edges` first as `<line>` elements with class `viz-tree__edge` so nodes paint on top.
- Draw each node as a `<circle r="7">` with class `viz-tree__node`, plus a `<text>` with class `viz-tree__value`, `text-anchor="middle"`, `dominant-baseline="central"`.
- Add `is-current` to the node matching `view.current`, `is-visited` to every id in `view.visited`, `is-frontier` to every id in `view.frontier`. When a node is in more than one set, `is-current` wins — apply it last.
- If `view.labels?.[id]` exists, render it as a second `<text>` offset below the circle with class `viz-tree__label`.
- Colors come from the CSS custom properties via `fill`/`stroke` on the classes in `styles.css`, not from inline attributes.

Register `tree: renderTree`, add styles, and add a harness case asserting a five-node tree yields five `.viz-tree__node` circles and four `.viz-tree__edge` lines.

- [ ] **Step 4: Create the shell and verify in the browser**

Confirm the tree lays out without overlapping nodes, the queue fills and drains, and the final frame reports `[[3],[9,20],[15,7]]`.

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add tree renderer and the tree BFS visualization"
```

---

### Task 10: Graph renderer and the graph BFS page

**Files:**
- Create: `visualizations/shared/renderers/graph.js`
- Create: `visualizations/patterns/graph-bfs.js`
- Create: `visualizations/patterns/graph-bfs.html`
- Modify: `visualizations/shared/render.js`, `visualizations/patterns/registry.js`, `visualizations/tests.html`, `visualizations/shared/styles.css`

**Interfaces:**
- Produces: `renderGraph(view, el): void`, registered under kind `graph`.

Graph input data shape, shared with `graph-dfs`: `{ nodes: [{id, label, x, y}], edges: [[a,b]], start: id, target: id }`.

- [ ] **Step 1: Write the spec**

Create `visualizations/patterns/graph-bfs.js`:

```js
const NODES = [
  { id: 0, label: "0", x: 0.1, y: 0.5 },
  { id: 1, label: "1", x: 0.32, y: 0.2 },
  { id: 2, label: "2", x: 0.32, y: 0.8 },
  { id: 3, label: "3", x: 0.55, y: 0.5 },
  { id: 4, label: "4", x: 0.78, y: 0.3 },
  { id: 5, label: "5", x: 0.95, y: 0.6 },
  { id: 6, label: "6", x: 0.78, y: 0.9 },
];

const EDGES = [[0, 1], [0, 2], [1, 3], [2, 3], [3, 4], [4, 5]];

function adjacency(edges) {
  const adj = {};
  for (const [a, b] of edges) {
    (adj[a] ??= []).push(b);
    (adj[b] ??= []).push(a);
  }
  return adj;
}

function views(current, visited, queue, distances, activeEdge) {
  return {
    view: {
      kind: "graph",
      nodes: NODES,
      edges: EDGES,
      current,
      visited: [...visited],
      activeEdge,
      distances: { ...distances },
    },
    view2: {
      kind: "collection",
      label: "queue",
      items: queue.map((id) => ({ value: id })),
      orientation: "horizontal",
      highlight: queue.length > 0 ? [0] : [],
    },
  };
}

export default {
  title: "Graph BFS",
  folder: "TreesAndGraphs",
  complexity: { time: "O(V + E)", space: "O(V)" },
  whenToUse:
    "You need the fewest steps between two points in an unweighted graph or grid. BFS reaches every node in distance order, so the first time you touch the target you already hold the shortest distance.",
  problems: [
    "1091. Shortest Path in Binary Matrix",
    "542. 01 Matrix",
    "1926. Nearest Exit from Entrance in Maze",
    "909. Snakes and Ladders",
  ],
  pseudocode: [
    "queue = [(start, 0)], seen = {start}",
    "while queue is not empty:",
    "  node, dist = queue.pop_front()",
    "  if node == target: return dist",
    "  for neighbor of node:",
    "    if neighbor not in seen:",
    "      seen.add(neighbor); queue.push((neighbor, dist + 1))",
    "return -1",
  ],
  inputs: [
    { label: "0 → 5 (reachable)", data: { start: 0, target: 5 }, expect: 4 },
    { label: "0 → 6 (isolated node)", data: { start: 0, target: 6 }, expect: -1 },
  ],
  run({ start, target }, emit) {
    const adj = adjacency(EDGES);
    const seen = new Set([start]);
    const distances = { [start]: 0 };
    const queue = [start];
    const visited = [];

    emit({
      line: 0,
      note: `seed the queue with node ${start} at distance 0`,
      ...views(null, visited, queue, distances, null),
    });

    while (queue.length > 0) {
      const node = queue.shift();
      const dist = distances[node];
      visited.push(node);
      emit({
        line: 2,
        note: `dequeue node ${node} (distance ${dist})`,
        ...views(node, visited, queue, distances, null),
      });

      if (node === target) {
        emit({
          line: 3,
          note: `node ${node} is the target — shortest distance is ${dist}`,
          ...views(node, visited, queue, distances, null),
        });
        return dist;
      }

      for (const neighbor of adj[node] ?? []) {
        if (seen.has(neighbor)) {
          emit({
            line: 5,
            note: `neighbor ${neighbor} was already seen — skip it`,
            ...views(node, visited, queue, distances, [node, neighbor]),
          });
          continue;
        }
        seen.add(neighbor);
        distances[neighbor] = dist + 1;
        queue.push(neighbor);
        emit({
          line: 6,
          note: `discover node ${neighbor} at distance ${dist + 1} — enqueue it`,
          ...views(node, visited, queue, distances, [node, neighbor]),
        });
      }
    }

    emit({
      line: 7,
      note: `the queue drained without reaching node ${target} — unreachable`,
      ...views(null, visited, queue, distances, null),
    });
    return -1;
  },
};
```

Register it in `patterns/registry.js`.

- [ ] **Step 2: Run the test to verify the port is correct**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: both `Graph BFS — …` cases PASS. (Node 6 has no edge, so the second input must return -1.)

- [ ] **Step 3: Write `shared/renderers/graph.js`**

Same inline-SVG approach as the tree renderer, with these differences:
- Edges are undirected `<line class="viz-graph__edge">`; the pair in `view.activeEdge` (in either order) also gets `is-active`.
- Nodes are `<circle r="6" class="viz-graph__node">` with `is-current` / `is-visited` states, plus a `<text class="viz-graph__label">` showing `node.label`.
- When `view.distances[id]` is defined, render a second `<text class="viz-graph__dist">` below the circle reading `d=<n>`.
- Nodes with no entry in `distances` must render plainly — undiscovered nodes are the point of the "unreachable" example.

Register `graph: renderGraph`, add styles, add a harness case asserting seven nodes and six edges render.

- [ ] **Step 4: Create the shell and verify in the browser**

Confirm distance labels appear as nodes are discovered, the active edge highlights, node 6 stays unlabeled, and the second input ends on "unreachable".

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add graph renderer and the graph BFS visualization"
```

---

### Task 11: Grid renderer and the 1D DP page

**Files:**
- Create: `visualizations/shared/renderers/grid.js`
- Create: `visualizations/patterns/dp-1d.js`
- Create: `visualizations/patterns/dp-1d.html`
- Modify: `visualizations/shared/render.js`, `visualizations/patterns/registry.js`, `visualizations/tests.html`, `visualizations/shared/styles.css`

**Interfaces:**
- Produces: `renderGrid(view, el): void`, registered under kind `grid`.

- [ ] **Step 1: Write the spec**

Create `visualizations/patterns/dp-1d.js` implementing House Robber (198) as bottom-up tabulation. Spec data:

- `title`: `"1D Dynamic Programming"`
- `folder`: `"DynamicProgramming"`
- `complexity`: `{ time: "O(n)", space: "O(n)" }`
- `whenToUse`: `"Each state depends on a fixed number of earlier states, so you can fill a table left to right instead of re-exploring the same subproblems."`
- `problems`: `["198. House Robber", "70. Climbing Stairs", "746. Min Cost Climbing Stairs", "1137. N-th Tribonacci Number"]`
- `pseudocode`:
  ```
  0: dp = new array of length n
  1: dp[0] = nums[0]
  2: dp[1] = max(nums[0], nums[1])
  3: for i from 2 to n-1:
  4:   dp[i] = max(dp[i-1], dp[i-2] + nums[i])
  5: return dp[n-1]
  ```
- `inputs`:
  - `{ label: "[2,7,9,3,1]", data: [2, 7, 9, 3, 1], expect: 12 }` (dp fills to `2, 7, 11, 11, 12`)
  - `{ label: "[1,2,3,1]", data: [1, 2, 3, 1], expect: 4 }` (dp fills to `1, 2, 4, 4`)
  - `{ label: "[5] (single house)", data: [5], expect: 5 }`
- Emit `view` = the input as `array` (with `pointers: { i }` and `colors` marking `i-1` and `i-2` as `"dim"` while they are being read), and `view2` = `grid` with `rows: [dp]`, `current: { r: 0, c: i }`, `rowLabels: ["dp"]`, and `colLabels` set to the indices. Unfilled `dp` entries render as `"·"`.

Emit points:
1. line 1, after `dp[0] = nums[0]` — "the first house is the only option so far"
2. line 2, after `dp[1] = max(...)` (guard: skip when `n === 1`) — "take whichever of the first two houses is worth more"
3. line 4, once per `i`, before assigning — "compare skipping house i (dp[i-1]) against robbing it (dp[i-2] + nums[i])"
4. line 4, once per `i`, after assigning — "dp[i] = <value>"
5. line 5, final — "the answer is dp[n-1] = <value>"

Handle `n === 1` by emitting the line 1 frame then jumping straight to the line 5 frame.

Register it in `patterns/registry.js`.

- [ ] **Step 2: Run the test to verify the port is correct**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: all three `1D Dynamic Programming — …` cases PASS.

- [ ] **Step 3: Write `shared/renderers/grid.js`**

Plain HTML table-style layout, no SVG:
- `<div class="viz-grid">` containing one `.viz-grid__row` per entry in `view.rows`.
- When `view.rowLabels` is present, prefix each row with a `.viz-grid__row-label`. Same for `.viz-grid__col-label` across the top when `view.colLabels` is present.
- Each cell is a `.viz-grid__cell` carrying `data-r` and `data-c`.
- `view.colors["r,c"]` adds `is-<state>`; `view.current` adds `is-current` to that one cell.
- Cells are fixed-width so the table does not reflow as values grow.

Register `grid: renderGrid`, add styles, and add a harness case asserting a 2×3 grid renders six `.viz-grid__cell` elements.

- [ ] **Step 4: Create the shell and verify in the browser**

Confirm the dp row fills left to right, the two cells being compared dim, and the final frame highlights `dp[n-1]`.

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add grid renderer and the 1D dynamic programming visualization"
```

---

### Task 12: Four more array-renderer pages

**Files:**
- Create: `visualizations/patterns/{sliding-window,prefix-sum,binary-search,monotonic-stack}.js` and matching `.html` shells
- Modify: `visualizations/patterns/registry.js`

**Interfaces:**
- Consumes: `array` and `collection` renderers (both already registered). No new renderers.
- Produces: four new registry entries.

Build these one at a time, running `node --test "visualizations/tests/*.test.js"` after each. All `expect` values below were computed by hand.

**sliding-window**
- `title`: `"Sliding Window"`, `folder`: `"ArrayAndString"`, `complexity`: `{ time: "O(n)", space: "O(1)" }`
- `whenToUse`: `"You need the best contiguous subarray under a constraint, and growing the window can only break the constraint while shrinking it can only restore it."`
- `problems`: `["209. Minimum Size Subarray Sum", "3. Longest Substring Without Repeating Characters", "643. Maximum Average Subarray I", "1004. Max Consecutive Ones III"]`
- `pseudocode`:
  ```
  0: left = 0, sum = 0, best = 0
  1: for right from 0 to n-1:
  2:   sum += nums[right]
  3:   while sum > k:
  4:     sum -= nums[left]; left += 1
  5:   best = max(best, right - left + 1)
  6: return best
  ```
- Problem: longest subarray whose sum is at most `k`.
- `inputs`:
  - `{ label: "[3,1,2,7,4,2,1,1,5], k=8", data: { nums: [3,1,2,7,4,2,1,1,5], k: 8 }, expect: 4 }`
  - `{ label: "[1,1,1,1], k=2", data: { nums: [1,1,1,1], k: 2 }, expect: 2 }`
  - `{ label: "[9], k=3 (nothing fits)", data: { nums: [9], k: 3 }, expect: 0 }`
- View: `array` with `cells: nums`, `pointers: { left, right }`, `window: { start: left, end: right }`, and `caption` showing `sum = <n>, best = <n>`.
- Emit points: line 0 (initial), line 2 after each add, line 4 on each shrink step, line 5 after each `best` update, line 6 final.

**prefix-sum**
- `title`: `"Prefix Sum"`, `folder`: `"ArrayAndString"`, `complexity`: `{ time: "O(n) build, O(1) per query", space: "O(n)" }`
- `whenToUse`: `"Many range-sum questions over an array that never changes — pay O(n) once so every query is O(1)."`
- `problems`: `["303. Range Sum Query - Immutable", "1480. Running Sum of 1d Array", "2270. Number of Ways to Split Array", "560. Subarray Sum Equals K"]`
- `pseudocode`:
  ```
  0: P[0] = 0
  1: for i from 0 to n-1:
  2:   P[i+1] = P[i] + nums[i]
  3: for each query (lo, hi):
  4:   answer = P[hi+1] - P[lo]
  5: return answers
  ```
- `inputs`:
  - `{ label: "[3,-1,4,1,5,-9,2], queries [1,3] [0,6] [4,6]", data: { nums: [3,-1,4,1,5,-9,2], queries: [[1,3],[0,6],[4,6]] }, expect: [4, 5, -2] }`
    (prefix table is `0, 3, 2, 6, 7, 12, 3, 5`)
  - `{ label: "[1,2,3], query [0,2]", data: { nums: [1,2,3], queries: [[0,2]] }, expect: [6] }`
- View: `array` of `nums` with `pointers: { i }`; `view2`: `array` of the prefix table `P` with `caption` naming the two entries being subtracted during the query phase.
- Emit points: line 0 (empty table), line 2 per build step, line 3 per query start, line 4 per query answer, line 5 final.

**binary-search**
- `title`: `"Binary Search"`, `folder`: `"BinarySearch"`, `complexity`: `{ time: "O(log n)", space: "O(1)" }`
- `whenToUse`: `"The search space is sorted or monotonic, so one comparison lets you discard half of what is left."`
- `problems`: `["704. Binary Search", "35. Search Insert Position", "74. Search a 2D Matrix", "278. First Bad Version"]`
- `pseudocode`:
  ```
  0: lo = 0, hi = n - 1
  1: while lo <= hi:
  2:   mid = lo + (hi - lo) / 2
  3:   if nums[mid] == target: return mid
  4:   if nums[mid] < target: lo = mid + 1
  5:   else: hi = mid - 1
  6: return -1
  ```
- `inputs`:
  - `{ label: "find 11 in [1,3,5,7,9,11,13]", data: { nums: [1,3,5,7,9,11,13], target: 11 }, expect: 5 }`
  - `{ label: "find 4 (absent)", data: { nums: [1,3,5,7,9,11,13], target: 4 }, expect: -1 }`
  - `{ label: "find 1 (first element)", data: { nums: [1,3,5,7,9,11,13], target: 1 }, expect: 0 }`
- View: `array` with `pointers: { lo, mid, hi }`, `window: { start: lo, end: hi }` for the live search space, and `colors` marking everything outside `[lo, hi]` as `"dim"`.
- Emit points: line 0, line 2 per midpoint, line 3 on a hit, line 4 or 5 per discard (note which half was thrown away), line 6 when not found.

**monotonic-stack**
- `title`: `"Monotonic Stack"`, `folder`: `"StackAndQueue"`, `complexity`: `{ time: "O(n)", space: "O(n)" }`
- `whenToUse`: `"You need the next (or previous) element greater or smaller than each entry, and a plain stack kept in sorted order gives it in one pass."`
- `problems`: `["739. Daily Temperatures", "496. Next Greater Element I", "84. Largest Rectangle in Histogram", "901. Online Stock Span"]`
- `pseudocode`:
  ```
  0: answer = array of zeros, stack = []
  1: for i from 0 to n-1:
  2:   while stack and temps[stack.top] < temps[i]:
  3:     j = stack.pop(); answer[j] = i - j
  4:   stack.push(i)
  5: return answer
  ```
- `inputs`:
  - `{ label: "[73,74,75,71,69,72,76,73]", data: [73,74,75,71,69,72,76,73], expect: [1,1,4,2,1,1,0,0] }`
  - `{ label: "[30,40,50,60] (rising)", data: [30,40,50,60], expect: [1,1,1,0] }`
  - `{ label: "[60,50,40] (falling)", data: [60,50,40], expect: [0,0,0] }`
- View: `array` of temperatures with `pointers: { i }`; `view2`: `collection` labelled `stack (indices)` holding `{ key: index, value: temperature }` items, `orientation: "vertical"`.
- Emit points: line 0, line 2 per comparison, line 3 per resolved index (note `answer[j] = <n>`), line 4 per push, line 5 final.

- [ ] **Step 1: Write `patterns/sliding-window.js`, register it, run `node --test "visualizations/tests/*.test.js"`, confirm its three cases pass**
- [ ] **Step 2: Write `patterns/prefix-sum.js`, register it, run the tests, confirm its two cases pass**
- [ ] **Step 3: Write `patterns/binary-search.js`, register it, run the tests, confirm its three cases pass**
- [ ] **Step 4: Write `patterns/monotonic-stack.js`, register it, run the tests, confirm its three cases pass**
- [ ] **Step 5: Create the four `.html` shells from the template and open each in the browser**

Confirm on each page: Play runs to the end, the pseudocode highlight tracks the narration, and the dropdown switches inputs cleanly.

- [ ] **Step 6: Commit**

```bash
git add visualizations/
git commit -m "feat: add sliding window, prefix sum, binary search, and monotonic stack pages"
```

---

### Task 13: Three more collection-renderer pages

**Files:**
- Create: `visualizations/patterns/{queues,counting,check-existence}.js` and matching `.html` shells
- Modify: `visualizations/patterns/registry.js`

**Interfaces:**
- Consumes: `array` and `collection` renderers. No new renderers.
- Produces: three new registry entries.

**queues**
- `title`: `"Queues"`, `folder`: `"StackAndQueue"`, `complexity`: `{ time: "O(1) amortized per call", space: "O(n)" }`
- `whenToUse`: `"Work must be handled oldest-first, or a sliding time window means old entries expire from the front while new ones arrive at the back."`
- `problems`: `["933. Number of Recent Calls", "346. Moving Average from Data Stream", "622. Design Circular Queue", "239. Sliding Window Maximum"]`
- Problem: 933 — count pings within the last 3000ms.
- `pseudocode`:
  ```
  0: queue = []
  1: for each ping t:
  2:   queue.push_back(t)
  3:   while queue.front < t - 3000:
  4:     queue.pop_front()
  5:   record queue.length
  6: return the recorded counts
  ```
- `inputs`:
  - `{ label: "pings 1, 100, 3001, 3002", data: [1, 100, 3001, 3002], expect: [1, 2, 3, 3] }`
  - `{ label: "pings 1, 5000", data: [1, 5000], expect: [1, 1] }`
- View: `collection` labelled `queue` with `orientation: "horizontal"`; `view2`: `array` of the counts recorded so far with `pointers: { ping }`.
- Emit points: line 0, line 2 per push, line 4 per expiry (note which timestamp fell out of the window), line 5 per recorded count, line 6 final.

**counting**
- `title`: `"Counting"`, `folder`: `"Hashing"`, `complexity`: `{ time: "O(n)", space: "O(n)" }`
- `whenToUse`: `"You need how many times something occurred, and a hash map of running counts turns a nested scan into one pass."`
- `problems`: `["560. Subarray Sum Equals K", "1248. Count Number of Nice Subarrays", "1. Two Sum", "2248. Intersection of Multiple Arrays"]`
- Problem: 560 — count subarrays summing to `k`, using a prefix-sum count map.
- `pseudocode`:
  ```
  0: counts = {0: 1}, running = 0, total = 0
  1: for each num in nums:
  2:   running += num
  3:   total += counts.get(running - k, 0)
  4:   counts[running] += 1
  5: return total
  ```
- `inputs`:
  - `{ label: "[1,2,1,2,1], k=3", data: { nums: [1,2,1,2,1], k: 3 }, expect: 4 }`
  - `{ label: "[1,1,1], k=2", data: { nums: [1,1,1], k: 2 }, expect: 2 }`
  - `{ label: "[1,2,3], k=7 (none)", data: { nums: [1,2,3], k: 7 }, expect: 0 }`
- View: `array` of `nums` with `pointers: { i }` and `caption` showing `running = <n>, total = <n>`; `view2`: `collection` labelled `prefix counts` with `{ key, value }` items, `orientation: "horizontal"`, highlighting the entry looked up this step.
- Emit points: line 0, line 2 per running-sum update, line 3 per lookup (note whether `running - k` was found and how many subarrays it contributed), line 4 per count bump, line 5 final.

**check-existence**
- `title`: `"Checking for Existence"`, `folder`: `"Hashing"`, `complexity`: `{ time: "O(n)", space: "O(n)" }`
- `whenToUse`: `"You keep asking whether a value you have already seen exists — a set or map answers in O(1) what a rescan answers in O(n)."`
- `problems`: `["1. Two Sum", "217. Contains Duplicate", "219. Contains Duplicate II", "2225. Find Players With Zero or One Losses"]`
- Problem: 1 — Two Sum with a seen-map.
- `pseudocode`:
  ```
  0: seen = {}
  1: for i from 0 to n-1:
  2:   need = target - nums[i]
  3:   if need in seen: return [seen[need], i]
  4:   seen[nums[i]] = i
  5: return []
  ```
- `inputs`:
  - `{ label: "[2,7,11,15], target 9", data: { nums: [2,7,11,15], target: 9 }, expect: [0, 1] }`
  - `{ label: "[3,2,4], target 6", data: { nums: [3,2,4], target: 6 }, expect: [1, 2] }`
  - `{ label: "[1,2], target 99 (no pair)", data: { nums: [1,2], target: 99 }, expect: [] }`
- View: `array` of `nums` with `pointers: { i }`, colouring the found pair `"pass"` on the success frame; `view2`: `collection` labelled `seen (value → index)`.
- Emit points: line 0, line 2 per complement computed, line 3 per lookup (hit or miss), line 4 per insert, line 5 when the loop ends empty-handed.

- [ ] **Step 1: Write `patterns/queues.js`, register it, run `node --test "visualizations/tests/*.test.js"`, confirm its two cases pass**
- [ ] **Step 2: Write `patterns/counting.js`, register it, run the tests, confirm its three cases pass**
- [ ] **Step 3: Write `patterns/check-existence.js`, register it, run the tests, confirm its three cases pass**
- [ ] **Step 4: Create the three `.html` shells and open each in the browser**
- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add queues, counting, and check-existence pages"
```

---

### Task 14: Three more tree-renderer pages

**Files:**
- Create: `visualizations/patterns/{tree-dfs,bst,heap-operations}.js` and matching `.html` shells
- Modify: `visualizations/patterns/registry.js`

**Interfaces:**
- Consumes: `tree`, `collection` renderers, and the tree data shape from Task 9 (`{ nodes: [{id, value, x, y, left, right}] }`).
- Produces: three new registry entries.

**tree-dfs**
- `title`: `"Tree DFS"`, `folder`: `"TreesAndGraphs"`, `complexity`: `{ time: "O(n)", space: "O(h)" }`
- `whenToUse`: `"The answer at a node is built from the answers of its subtrees — depth, path sums, or comparisons between two trees."`
- `problems`: `["104. Maximum Depth of Binary Tree", "112. Path Sum", "100. Same Tree", "543. Diameter of Binary Tree"]`
- Problem: 104 — maximum depth, traced as preorder recursion.
- `pseudocode`:
  ```
  0: function depth(node):
  1:   if node is null: return 0
  2:   left = depth(node.left)
  3:   right = depth(node.right)
  4:   return 1 + max(left, right)
  ```
- Reuse the same five-node `SAMPLE` tree from Task 9 (values 3, 9, 20, 15, 7).
- `inputs`:
  - `{ label: "[3,9,20,null,null,15,7]", data: SAMPLE, expect: 3 }`
  - `{ label: "single node", data: SINGLE, expect: 1 }`
- Copy the `SAMPLE` and `SINGLE` constants into this file rather than importing them from `tree-bfs.js` — spec modules stay independent so one page can never break another.
- View: `tree` with `current` on the node being entered, `visited` for nodes whose depth is already resolved, and `labels` showing each resolved depth; `view2`: `collection` labelled `call stack`, `orientation: "vertical"`, holding the node values currently on the stack.
- Emit points: line 1 on each null child (note "empty child — depth 0"), line 2 on descending left, line 3 on descending right, line 4 on returning (note `depth(<value>) = <n>`).

**bst**
- `title`: `"Binary Search Tree"`, `folder`: `"TreesAndGraphs"`, `complexity`: `{ time: "O(h) — O(log n) balanced, O(n) worst case", space: "O(1)" }`
- `whenToUse`: `"The tree's ordering invariant — everything left is smaller, everything right is larger — lets one comparison discard an entire subtree."`
- `problems`: `["700. Search in a Binary Search Tree", "98. Validate Binary Search Tree", "701. Insert into a Binary Search Tree", "230. Kth Smallest Element in a BST"]`
- `pseudocode`:
  ```
  0: node = root
  1: while node is not null:
  2:   if node.value == target: return true
  3:   if target < node.value: node = node.left
  4:   else: node = node.right
  5: return false
  ```
- Tree (values 8, 3, 10, 1, 6, 14):
  ```js
  const TREE = {
    nodes: [
      { id: "a", value: 8,  x: 0.5,  y: 0.1, left: "b", right: "c" },
      { id: "b", value: 3,  x: 0.25, y: 0.5, left: "d", right: "e" },
      { id: "c", value: 10, x: 0.75, y: 0.5, left: null, right: "f" },
      { id: "d", value: 1,  x: 0.12, y: 0.9, left: null, right: null },
      { id: "e", value: 6,  x: 0.38, y: 0.9, left: null, right: null },
      { id: "f", value: 14, x: 0.9,  y: 0.9, left: null, right: null },
    ],
  };
  ```
- `inputs`:
  - `{ label: "search for 6 (present)", data: { tree: TREE, target: 6 }, expect: true }`
  - `{ label: "search for 7 (absent)", data: { tree: TREE, target: 7 }, expect: false }`
  - `{ label: "search for 8 (the root)", data: { tree: TREE, target: 8 }, expect: true }`
- View: `tree` with `current` on the node under comparison and `visited` on the path already walked. On each branch decision, collect every id in the discarded subtree into `frontier` — the tree renderer's `is-frontier` state is styled dimmed here, so the half being thrown away reads at a glance. `frontier` accumulates across frames; once a subtree is discarded it stays dimmed.
- Emit points: line 0, line 2 per comparison, line 3 or 4 per branch (note "target < 8, so everything right of 8 is out"), line 5 when the walk falls off the tree.

**heap-operations**
- `title`: `"Heap Operations"`, `folder`: `"Heap"`, `complexity`: `{ time: "O(log n) per push or pop", space: "O(n)" }`
- `whenToUse`: `"You repeatedly need the smallest (or largest) item while the collection keeps changing — a heap keeps that item at index 0 for O(log n) upkeep."`
- `problems`: `["703. Kth Largest Element in a Stream", "1046. Last Stone Weight", "215. Kth Largest Element in an Array", "621. Task Scheduler"]`
- `pseudocode`:
  ```
  0: push(v): append v at the end
  1:   i = last index
  2:   while i > 0 and heap[i] < heap[parent(i)]:
  3:     swap(i, parent(i)); i = parent(i)
  4: pop(): save heap[0], move the last item to index 0
  5:   sift down while a child is smaller than the node
  ```
- `inputs`:
  - `{ label: "push 5, 3, 8, 1", data: { op: "push", values: [5, 3, 8, 1] }, expect: [1, 3, 8, 5] }`
  - `{ label: "pop the min from [1,3,8,5]", data: { op: "pop", heap: [1, 3, 8, 5] }, expect: { min: 1, heap: [3, 5, 8] } }`
- Both `expect` values were traced by hand: pushing 5, 3, 8, 1 sifts 3 above 5, then sifts 1 past 5 and past 3, landing at `[1,3,8,5]`; popping moves 5 to the root and swaps it with its smaller child 3, landing at `[3,5,8]`.
- View: `tree` built from the heap array — node `i` sits at depth `floor(log2(i+1))`, so author `x`/`y` with a helper that spreads level `d` evenly across `[0,1]` and sets `y = (d + 0.5) / 4`; `view2`: `collection` labelled `heap array`, `orientation: "horizontal"`, highlighting the indices being compared or swapped.
- Emit points: line 0 per append, line 2 per parent comparison, line 3 per swap, line 4 on the pop's root removal, line 5 per sift-down step.

- [ ] **Step 1: Write `patterns/tree-dfs.js`, register it, run `node --test "visualizations/tests/*.test.js"`, confirm its two cases pass**
- [ ] **Step 2: Write `patterns/bst.js`, register it, run the tests, confirm its three cases pass**
- [ ] **Step 3: Write `patterns/heap-operations.js`, register it, run the tests, confirm its two cases pass**
- [ ] **Step 4: Create the three `.html` shells and open each in the browser**

Pay particular attention to the heap page: confirm the tree view and the array view agree at every frame.

- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add tree DFS, BST, and heap operations pages"
```

---

### Task 15: Graph DFS and linked list reversal

**Files:**
- Create: `visualizations/patterns/{graph-dfs,reversing-linked-list}.js` and matching `.html` shells
- Modify: `visualizations/patterns/registry.js`

**Interfaces:**
- Consumes: `graph`, `linkedList`, `collection` renderers.
- Produces: two new registry entries.

**graph-dfs**
- `title`: `"Graph DFS"`, `folder`: `"TreesAndGraphs"`, `complexity`: `{ time: "O(V + E)", space: "O(V)" }`
- `whenToUse`: `"You need to know whether something is reachable, or to explore each connected region fully — where you go deep matters more than how far."`
- `problems`: `["1971. Find if Path Exists in Graph", "547. Number of Provinces", "200. Number of Islands", "841. Keys and Rooms"]`
- `pseudocode`:
  ```
  0: stack = [source], seen = {source}
  1: while stack is not empty:
  2:   node = stack.pop()
  3:   if node == destination: return true
  4:   for neighbor of node:
  5:     if neighbor not in seen:
  6:       seen.add(neighbor); stack.push(neighbor)
  7: return false
  ```
- Graph (six nodes, two components):
  ```js
  const NODES = [
    { id: 0, label: "0", x: 0.15, y: 0.25 },
    { id: 1, label: "1", x: 0.45, y: 0.1 },
    { id: 2, label: "2", x: 0.45, y: 0.45 },
    { id: 3, label: "3", x: 0.75, y: 0.7 },
    { id: 4, label: "4", x: 0.95, y: 0.9 },
    { id: 5, label: "5", x: 0.15, y: 0.85 },
  ];
  const EDGES = [[0, 1], [1, 2], [2, 0], [3, 4]];
  ```
- `inputs`:
  - `{ label: "0 → 2 (same component)", data: { source: 0, destination: 2 }, expect: true }`
  - `{ label: "0 → 5 (isolated node)", data: { source: 0, destination: 5 }, expect: false }`
  - `{ label: "3 → 4 (other component)", data: { source: 3, destination: 4 }, expect: true }`
- View: `graph` with `current`, `visited`, `activeEdge` and no `distances` (DFS gives no distance guarantee — leaving the field off is the point); `view2`: `collection` labelled `stack`, `orientation: "vertical"`.
- Emit points: line 0, line 2 per pop, line 3 on reaching the destination, line 5 per already-seen skip, line 6 per discovery, line 7 when the stack drains.

**reversing-linked-list**
- `title`: `"Reversing a Linked List"`, `folder`: `"LinkedList"`, `complexity`: `{ time: "O(n)", space: "O(1)" }`
- `whenToUse`: `"You need the list pointing the other way without allocating a second list — three pointers rewire it in place as they walk."`
- `problems`: `["206. Reverse Linked List", "92. Reverse Linked List II", "24. Swap Nodes in Pairs", "25. Reverse Nodes in k-Group"]`
- `pseudocode`:
  ```
  0: prev = null, curr = head
  1: while curr is not null:
  2:   nextNode = curr.next
  3:   curr.next = prev
  4:   prev = curr
  5:   curr = nextNode
  6: return prev
  ```
- `inputs`:
  - `{ label: "1 → 2 → 3 → 4 → 5", data: [1, 2, 3, 4, 5], expect: [5, 4, 3, 2, 1] }`
  - `{ label: "single node", data: [1], expect: [1] }`
  - `{ label: "empty list", data: [], expect: [] }`
- `run` returns the reversed values as an array (walk from `prev` following the rewired `next` map), which is what `expect` compares against.
- View: `linkedList` whose `next` map is the live, mutating one — so the arrows visibly flip as the walk proceeds — with `pointers: { prev, curr, next }`. Nodes already reversed get `colors[id] = "pass"`.
- Emit points: line 0, line 2 per saved `next`, line 3 per rewire (note "point <value> back at <value or null>"), line 5 per advance, line 6 final (note the new head).
- The empty-list input must emit at least one frame — emit the line 0 frame with an empty node list, then the line 6 frame — otherwise `validateFrames` reports "no frames emitted".

- [ ] **Step 1: Write `patterns/graph-dfs.js`, register it, run `node --test "visualizations/tests/*.test.js"`, confirm its three cases pass**
- [ ] **Step 2: Write `patterns/reversing-linked-list.js`, register it, run the tests, confirm its three cases pass**
- [ ] **Step 3: Create the two `.html` shells and open each in the browser**

On the reversal page, confirm the arrows actually flip direction frame by frame rather than the list simply re-rendering in a new order.

- [ ] **Step 4: Commit**

```bash
git add visualizations/
git commit -m "feat: add graph DFS and linked list reversal pages"
```

---

### Task 16: Backtracking and Top-K

**Files:**
- Create: `visualizations/patterns/{backtracking-generation,top-k}.js` and matching `.html` shells
- Modify: `visualizations/patterns/registry.js`

**Interfaces:**
- Consumes: `tree`, `collection`, `array` renderers.
- Produces: the final two registry entries — the registry now holds all 20.

**backtracking-generation**
- `title`: `"Backtracking"`, `folder`: `"Backtracking"`, `complexity`: `{ time: "O(n · 2^n) for subsets", space: "O(n) recursion depth" }`
- `whenToUse`: `"You must enumerate every combination, permutation, or subset — build a candidate one choice at a time and undo the choice on the way back up."`
- `problems`: `["78. Subsets", "46. Permutations", "77. Combinations", "39. Combination Sum"]`
- `pseudocode`:
  ```
  0: backtrack(start, path):
  1:   record a copy of path
  2:   for i from start to n-1:
  3:     path.push(nums[i])
  4:     backtrack(i + 1, path)
  5:     path.pop()          # undo the choice
  ```
- `inputs`:
  - `{ label: "subsets of [1,2,3]", data: [1, 2, 3], expect: [[], [1], [1,2], [1,2,3], [1,3], [2], [2,3], [3]] }`
  - `{ label: "subsets of [1,2]", data: [1, 2], expect: [[], [1], [1,2], [2]] }`
- The expected order is exactly what the start-index recursion above produces — record on entry, then recurse in index order. Do not sort the output.
- View: `tree` built as the recursion tree, with node positions assigned as the search runs. Author a helper that places a node at `x = (order index + 0.5) / totalNodesAtThatDepth` and `y = (depth + 0.5) / (n + 1)`. Because positions must be stable across frames, build the full recursion tree first in a dry run, then replay it emitting frames. `labels` shows each node's path as a string. `view2`: `collection` labelled `current path`, `orientation: "horizontal"`.
- Emit points: line 1 per recorded subset, line 3 per choice made, line 4 on descending, line 5 per undo (note "remove <value> and try the next branch").

**top-k**
- `title`: `"Top K Elements"`, `folder`: `"Heap"`, `complexity`: `{ time: "O(n log k)", space: "O(k)" }`
- `whenToUse`: `"You want the k best items out of n, and k is much smaller than n — keep a heap of size k instead of sorting everything."`
- `problems`: `["215. Kth Largest Element in an Array", "347. Top K Frequent Elements", "973. K Closest Points to Origin", "658. Find K Closest Elements"]`
- `pseudocode`:
  ```
  0: minHeap = []
  1: for each num in nums:
  2:   push num onto minHeap
  3:   if minHeap.size > k:
  4:     pop the smallest
  5: return minHeap[0]      # the kth largest
  ```
- `inputs`:
  - `{ label: "[3,2,1,5,6,4], k=2", data: { nums: [3,2,1,5,6,4], k: 2 }, expect: 5 }`
  - `{ label: "[3,2,3,1,2,4,5,5,6], k=4", data: { nums: [3,2,3,1,2,4,5,5,6], k: 4 }, expect: 4 }`
  - `{ label: "[1], k=1", data: { nums: [1], k: 1 }, expect: 1 }`
- Both non-trivial `expect` values were traced by hand: the 2nd largest of `[3,2,1,5,6,4]` is 5; the 4th largest of `[3,2,3,1,2,4,5,5,6]` (descending: 6,5,5,4,…) is 4.
- View: `array` of `nums` with `pointers: { i }` and processed entries coloured `"dim"`; `view2`: `collection` labelled `min-heap (size ≤ k)`, `orientation: "horizontal"`, highlighting index 0 — the element that gets evicted next.
- Emit points: line 2 per push, line 3 per size check, line 4 per eviction (note "heap exceeded k — drop the smallest, <value>"), line 5 final.
- Reuse the sift logic from `heap-operations` by writing it again locally in this file. Spec modules never import each other.

- [ ] **Step 1: Write `patterns/backtracking-generation.js`, register it, run `node --test "visualizations/tests/*.test.js"`, confirm its two cases pass**
- [ ] **Step 2: Write `patterns/top-k.js`, register it, run the tests, confirm its three cases pass**
- [ ] **Step 3: Verify the registry holds all 20 specs**

Run: `node -e "import('./visualizations/patterns/registry.js').then(m => console.log(m.specs.length))"`
Expected: `20`

- [ ] **Step 4: Create the two `.html` shells and open each in the browser**
- [ ] **Step 5: Commit**

```bash
git add visualizations/
git commit -m "feat: add backtracking and top-K pages, completing all 20 patterns"
```

---

### Task 17: Gallery and README

**Files:**
- Create: `visualizations/index.html`
- Create: `visualizations/README.md`

**Interfaces:**
- Consumes: `specs` from `patterns/registry.js` — each spec's `title`, `folder`, `complexity`, and `whenToUse`.
- Produces: nothing other tasks consume.

The gallery derives everything from the registry, so no list of 20 links is hand-maintained. It needs each spec's page URL; derive it from the title by slugifying — but the slugs must match the filenames exactly, and three do not (`"Checking for Existence"` → `check-existence`, `"1D Dynamic Programming"` → `dp-1d`, `"Backtracking"` → `backtracking-generation`). Rather than guess, add a `slug` field to all 20 specs.

- [ ] **Step 1: Add a `slug` field to every spec**

Add `slug: "<filename without extension>"` to each of the 20 spec modules, matching its `.js` filename exactly.

- [ ] **Step 2: Extend the structural test**

Add to `visualizations/tests/specs.test.js`:

```js
test("every spec has a unique slug", () => {
  const slugs = specs.map((s) => s.slug);
  for (const slug of slugs) {
    assert.match(slug, /^[a-z0-9-]+$/, `bad slug: ${slug}`);
  }
  assert.equal(new Set(slugs).size, slugs.length, "duplicate slug");
});

test("all 20 patterns are registered", () => {
  assert.equal(specs.length, 20);
});
```

Run: `node --test "visualizations/tests/*.test.js"` → PASS

- [ ] **Step 3: Write `index.html`**

```html
<!doctype html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>DSA Pattern Visualizations</title>
<link rel="stylesheet" href="shared/styles.css">
</head>
<body>
<main class="page">
  <h1>Algorithm pattern visualizations</h1>
  <p class="page__when">
    Twenty interactive walkthroughs of the patterns implemented in
    <code>src/DSA/LeetCode/</code>. Pick one, press Play, and step through it.
  </p>
  <div id="file-warning" hidden class="viz-error">
    This page was opened from the filesystem, so ES modules cannot load.
    Run <code>python -m http.server 8000</code> inside <code>visualizations/</code>
    and open <code>http://localhost:8000</code> instead.
  </div>
  <div id="gallery"></div>
</main>
<script>
  if (location.protocol === "file:") {
    document.getElementById("file-warning").hidden = false;
  }
</script>
<script type="module">
  import { specs } from "./patterns/registry.js";

  const byFolder = new Map();
  for (const spec of specs) {
    if (!byFolder.has(spec.folder)) byFolder.set(spec.folder, []);
    byFolder.get(spec.folder).push(spec);
  }

  const gallery = document.getElementById("gallery");
  for (const [folder, group] of [...byFolder].sort((a, b) => a[0].localeCompare(b[0]))) {
    const section = document.createElement("section");
    section.className = "gallery__group";

    const heading = document.createElement("h2");
    heading.textContent = folder;
    section.append(heading);

    const cards = document.createElement("div");
    cards.className = "gallery__cards";
    for (const spec of group) {
      const card = document.createElement("a");
      card.className = "card";
      card.href = `patterns/${spec.slug}.html`;

      const title = document.createElement("h3");
      title.className = "card__title";
      title.textContent = spec.title;

      const when = document.createElement("p");
      when.className = "card__when";
      when.textContent = spec.whenToUse;

      const meta = document.createElement("p");
      meta.className = "card__meta";
      meta.textContent = `${spec.complexity.time} time · ${spec.complexity.space} space`;

      card.append(title, when, meta);
      cards.append(card);
    }
    section.append(cards);
    gallery.append(section);
  }
</script>
</body>
</html>
```

Add `.gallery__group`, `.gallery__cards` (responsive grid, `repeat(auto-fill, minmax(260px, 1fr))`), `.card`, `.card__title`, `.card__when`, `.card__meta` to `shared/styles.css`. Cards are links — give them a visible hover and focus state.

- [ ] **Step 4: Write `README.md`**

Cover, in this order: what the folder is; the two-line quick start (`cd visualizations && python -m http.server 8000`, then open `http://localhost:8000`); why a server is needed rather than opening the file directly (ES modules); how to run the tests (`node --test "visualizations/tests/*.test.js"` and `tests.html`); how to add a new pattern (write `patterns/<slug>.js` exporting a PatternSpec, copy a `.html` shell, add one line to `patterns/registry.js` — the gallery and both test harnesses pick it up automatically); and the rule that spec modules stay DOM-free.

- [ ] **Step 5: Verify in the browser**

Open `http://localhost:8000/` and confirm 20 cards across 9 groups, every link resolving to a working page, and no console errors. Double-click `index.html` in Explorer and confirm the `file://` warning appears.

- [ ] **Step 6: Commit**

```bash
git add visualizations/
git commit -m "feat: add pattern gallery and README"
```

---

### Task 18: Final verification

**Files:**
- Modify: whatever the checks below turn up.

**Interfaces:**
- Consumes: everything.
- Produces: a verified, complete site.

- [ ] **Step 1: Run the full pure-logic suite**

Run: `node --test "visualizations/tests/*.test.js"`
Expected: 0 failures. Record the total test count in the commit message.

- [ ] **Step 2: Run the console spec table**

Run: `node visualizations/tests.node.mjs`
Expected: every row PASS, exit code 0. Confirm with `echo $?`.

- [ ] **Step 3: Confirm the browser harness is green**

Open `http://localhost:8000/tests.html`.
Expected: every renderer case green (one per renderer plus the unknown-kind case) and every spec row green.

- [ ] **Step 4: Walk all 20 pages**

From the gallery, open each page and confirm: it loads without console errors, Play reaches the end and stops, the pseudocode highlight tracks the narration, backward scrubbing shows no stale state, and every preset input runs.

- [ ] **Step 5: Confirm the .NET side is untouched**

```bash
dotnet build
dotnet test
git status --short src/
```
Expected: build and tests behave exactly as before; `git status` reports no changes under `src/`.

- [ ] **Step 6: Confirm no dependencies crept in**

```bash
test ! -d visualizations/node_modules && echo "no node_modules: ok"
cat visualizations/package.json
```
Expected: no `node_modules`, and `package.json` still holds only `type` and `private`.

- [ ] **Step 7: Commit**

```bash
git add visualizations/
git commit -m "test: verify all 20 pattern visualizations and harnesses"
```

---

## Self-Review Notes

**The code in this plan was executed before the plan was committed.** `shared/kinds.js`, `shared/engine.js` (including `Player` with an injected clock), `shared/selftest.js`, and the five fully-written specs — two-pointers, stacks, graph-bfs, tree-bfs, fast-slow-pointers — were assembled in a scratch directory and run under Node. All 13 spec cases passed and the Player auto-paused correctly at the last frame, which confirms both the shared modules and the hand-computed `expect` values for those five pages. The remaining 15 pages are specified rather than written out; their `expect` values were computed by hand but not executed.

Also verified on this machine before writing: Node resolves `.js` as ESM given the `package.json` type marker; `node --test` discovers a quoted glob; `python -m http.server` serves `.js` as `application/javascript` and `.mjs` as `text/plain`.

Checked against the spec after writing:

- **Spec coverage.** All 20 pages appear in Tasks 6–16. The six renderers land in Tasks 5 and 7–11. The `PatternSpec` and frame contracts are Tasks 1–4. All five failure modes from the spec have a home: the frame cap and unknown-kind checks in Task 2, the renderer error banner in Task 5, the collect/validate error path in `page.js` in Task 6, the out-of-range line check in Task 2, and the `file://` banner in Task 17. The testing section maps to Tasks 4, 5, and 6 plus the per-page checks. Everything in the spec's "Out of scope" list stays absent.
- **One deviation from the spec, deliberate.** The spec named a single `shared/render.js` holding all six drawers; this plan keeps `render.js` as the dispatch module and moves each drawer to `shared/renderers/<kind>.js`. Six renderers in one file would run past the repo's own 400-line guidance in `CLAUDE.md`, and per-file renderers mean each renderer task touches one new file plus one line of dispatch.
- **Two additions the spec did not name.** `slug` on each spec (Task 17) — the gallery needs a filename that title-slugification gets wrong for three pages. `shared/kinds.js` (Task 1) — `engine.js` must validate `view.kind` without importing DOM code, which a shared constants module solves cleanly.
- **Type consistency.** `collectFrames` returns `{frames, result}` everywhere it is used (Tasks 2, 4, 6). `validateFrames` returns `string[]` everywhere. `paint(view, el)` keeps that argument order in `render.js`, `page.js`, and `tests.html`. Renderer exports are consistently `render<Kind>` and registry keys consistently match `RENDERER_KINDS`.
- **Placeholder scan.** No "TBD", no "handle edge cases", no "similar to Task N". Two code blocks that were awkward on the first pass — the stage assembly in Task 6's `page.js` and the gallery loop in Task 17 — were rewritten in place rather than left with a note to fix them later.
- **Where a page task's `run()` is not spelled out** (Tasks 12–16), the task instead carries the full pseudocode, the exact view shape, numbered emit points keyed to pseudocode lines, and hand-verified `expect` values. That is a specification, not a placeholder: `tests/specs.test.js` fails loudly if the port disagrees with it.
