# Algorithm Pattern Visualizations — Design Spec

**Date:** 2026-08-22
**Status:** Approved (design)
**Scope:** New top-level `visualizations/` folder. No changes to `src/DSA` or `src/DSA.Tests`.

## Goal

Build an interactive, zero-build static site that animates each algorithmic
pattern implemented in this repo. A reader picks a pattern, presses Play, and
watches the algorithm run step by step on a sample input — pointers moving,
windows sliding, nodes being visited — with the matching pseudocode line
highlighted as it executes.

### Success criteria

- **20 pattern pages**, one per distinct sub-pattern in `src/DSA/LeetCode/`.
- Every page supports: play, pause, step forward, step back, scrub to any frame,
  reset.
- Every page shows time/space complexity, a "when to use this" signal, the
  LeetCode problems in this repo that use the pattern, pseudocode with the active
  line highlighted, and a dropdown of 2–3 preset inputs.
- `tests.html` runs every spec against every preset input and reports a green
  table — no red rows.
- No npm, no bundler, no build step. The .NET build and `dotnet test` are
  completely unaffected.

## Decisions (locked)

These were settled during brainstorming and are not open questions during
implementation.

| Decision | Choice | Rejected alternative |
|---|---|---|
| Interactivity | Step-through animator on fixed preset inputs | Free-form custom input; static diagrams |
| Coverage | All 20 sub-patterns in the first pass | One per folder; a 3-page pilot |
| Structure | Static site with a shared engine | 20 standalone self-contained files |
| Step source | JS port of each algorithm emits a trace | Hand-authored frame lists; instrumenting the C# |
| Page content | Pseudocode w/ active line, complexity + when-to-use, multiple preset inputs | Link back to the C# source file (dropped) |
| Serving | Local HTTP server (ES modules) | `file://` with `<script>` globals |
| Hosting | Local only | GitHub Pages deployment |

### On serving over HTTP

ES modules do not load over `file://` in Chrome — the page is opened with a
one-line local server:

```bash
cd visualizations && python -m http.server 8000
# then open http://localhost:8000
```

This was chosen deliberately over dropping modules for `file://`-compatible
global scripts: the shared engine stays cleanly importable, and the cost is one
command. `visualizations/README.md` documents it as the first thing a reader
sees.

## Architecture

```
visualizations/
  README.md               how to serve and open it
  index.html              gallery: 20 cards grouped by the 9 repo folders
  tests.html              runs every spec against every input, pass/fail table
  shared/
    engine.js             Player — frame list, play/pause/step/scrub, keyboard
    render.js             the six renderers
    page.js               boots a page from its spec
    selftest.js           assertion harness used by tests.html
    styles.css            shared visual language
  patterns/
    two-pointers.html            + .js
    sliding-window.html          + .js
    ... (20 pairs)
```

Each pattern is an HTML shell plus a sibling JS module holding its
`PatternSpec`. The HTML shell is near-identical across pages — it imports
`shared/page.js`, imports its own spec, and calls `boot(spec)`. All layout,
controls, and chrome are produced by the shared code.

`visualizations/` sits outside `src/`, so it is never picked up by the .NET
build. No `.csproj` changes are needed.

## The core abstraction: PatternSpec

The single shape that makes 20 pages tractable. Everything the engine needs to
render a complete page:

```js
export default {
  title: "Two Pointers",
  folder: "ArrayAndString",              // for gallery grouping
  complexity: { time: "O(n)", space: "O(1)" },
  whenToUse: "Sorted array, or comparing from both ends inward.",
  problems: ["125. Valid Palindrome", "167. Two Sum II", "392. Is Subsequence"],
  pseudocode: [
    "L = 0, R = n-1",
    "while L < R:",
    "  if s[L] != s[R]: return false",
    "  L++, R--",
    "return true",
  ],
  inputs: [
    { label: "racecar (passes)", data: "racecar", expect: true },
    { label: "hello (fails)",    data: "hello",   expect: false },
  ],
  run(data, emit) { /* JS port; calls emit() at each key moment; returns result */ },
};
```

`run` is a faithful JS port of the C# implementation, instrumented with `emit`:

```js
run(s, emit) {
  let L = 0, R = s.length - 1;
  emit({ line: 0, note: "initialize both pointers",
         view: { kind: "array", cells: [...s], pointers: { L, R } } });
  while (L < R) {
    emit({ line: 2, note: `compare '${s[L]}' vs '${s[R]}'`,
           view: { kind: "array", cells: [...s], pointers: { L, R } } });
    if (s[L] !== s[R]) {
      emit({ line: 2, note: "mismatch → not a palindrome",
             view: { kind: "array", cells: [...s], pointers: { L, R },
                     colors: { [L]: "fail", [R]: "fail" } } });
      return false;
    }
    L++; R--;
    emit({ line: 3, note: "match → move both inward",
           view: { kind: "array", cells: [...s], pointers: { L, R } } });
  }
  emit({ line: 4, note: "pointers crossed → palindrome", view: { /* … */ } });
  return true;
}
```

### Frame shape

`emit` receives one frame:

| Field | Type | Meaning |
|---|---|---|
| `line` | number | index into `pseudocode` to highlight |
| `note` | string | one-line narration shown under the controls |
| `view` | object | `{ kind: <renderer>, ...renderer-specific state }` |

A frame may carry a second view under `view2` when a page composes two
renderers (e.g. a graph plus its BFS queue).

Frames are **snapshots, not deltas** — each carries the complete state needed to
draw it. This is what makes backward scrubbing free.

## The six renderers

The shared visual vocabulary. Each frame's `view.kind` selects one; the engine
itself knows nothing about any algorithm.

| Renderer | Draws | State fields | Used by |
|---|---|---|---|
| `array` | cells in a row, pointer markers above, window shading, per-cell colors | `cells`, `pointers`, `window`, `colors` | two-pointers, sliding-window, prefix-sum, binary-search, monotonic-stack, dp-1d |
| `linkedList` | nodes + arrows, rewiring on reversal | `nodes`, `next`, `pointers` | fast-slow-pointers, reversing-linked-list |
| `tree` | binary tree layout, node coloring | `nodes`, `current`, `visited`, `frontier` | tree-dfs, tree-bfs, bst, heap-operations |
| `graph` | fixed-position nodes, edge highlight | `nodes`, `edges`, `current`, `visited`, `activeEdge` | graph-dfs, graph-bfs |
| `grid` | 2D matrix cells | `rows`, `current`, `colors` | dp-1d (tabulation table view) |
| `collection` | ordered box list — stack, queue, heap array, hash map | `items`, `label`, `orientation`, `highlight` | stacks, queues, counting, check-existence, top-k, backtracking |

Node positions for `tree` and `graph` are supplied by the spec, not computed —
each pattern uses a small fixed example whose layout is authored once. No
force-directed layout, no auto-balancing.

## The 20 pages

Grouped by their source folder in `src/DSA/LeetCode/`:

| Folder | Pages |
|---|---|
| ArrayAndString | `two-pointers`, `sliding-window`, `prefix-sum` |
| Hashing | `counting`, `check-existence` |
| BinarySearch | `binary-search` |
| LinkedList | `fast-slow-pointers`, `reversing-linked-list` |
| StackAndQueue | `stacks`, `monotonic-stack`, `queues` |
| TreesAndGraphs | `tree-dfs`, `tree-bfs`, `bst`, `graph-dfs`, `graph-bfs` |
| Heap | `heap-operations`, `top-k` |
| Backtracking | `backtracking-generation` |
| DynamicProgramming | `dp-1d` |

## Data flow

1. The page shell imports `shared/page.js` and its own spec module.
2. `boot(spec)` renders the static chrome: title, complexity, when-to-use,
   problem list, pseudocode block, input dropdown, controls.
3. On load (and on every input-dropdown change) the engine runs
   `spec.run(input.data, emit)` **once**, collecting frames into an immutable
   array.
4. The `Player` holds an index into that array. Play advances it on a timer;
   step/scrub/reset set it directly.
5. On every index change the engine paints frame `i`: highlight
   `pseudocode[frame.line]`, write `frame.note`, and hand `frame.view` to the
   matching renderer.

Because frames are precomputed snapshots, there is no reverse-step logic and no
replay-from-start on backward scrub.

## Failure modes

| Risk | Handling |
|---|---|
| A buggy JS port loops forever | `emit` caps at 2000 frames, then throws a labeled error; the page shows it in the note area instead of hanging the tab |
| Malformed or unknown `view.kind` | Renderer shows an inline error banner naming the frame index and kind — never a blank canvas |
| A pattern page is missing or fails to import | The gallery card links out anyway; the page shows a load error rather than a white screen |
| `line` out of range for `pseudocode` | No highlight, plus a console warning; the rest of the frame still renders |
| Opened over `file://` | `README.md` states the server command up front; `index.html` detects `location.protocol === "file:"` and shows the command in a banner |

## Testing

This is a .NET repo with xUnit and no JS test runner, and the design deliberately
avoids adding npm to it.

Instead, every preset input carries an `expect` value — the algorithm's correct
return value for that input. `tests.html` imports all 20 specs, runs each input
through `spec.run`, and prints a table:

| Pattern | Input | Expected | Actual | Frames | Result |
|---|---|---|---|---|---|
| two-pointers | racecar (passes) | `true` | `true` | 15 | PASS |
| two-pointers | hello (fails) | `false` | `false` | 4 | PASS |

Each row also asserts structural invariants: at least one frame emitted, every
`frame.line` within `pseudocode` bounds, every `view.kind` a known renderer.

This catches the failure that matters most — a JS port that diverges from the
C# and produces a plausible-looking but wrong animation. It runs in the browser,
needs no dependencies, and is not wired into `dotnet test` or CI.

## Out of scope

Explicitly not part of this work:

- Custom user input (the trace-generator design leaves the door open; the UI does not expose it)
- Links from pages back to the C# source files
- GitHub Pages deployment or any CI wiring
- Any modification to the C# implementations, including trace instrumentation
- Mobile-optimized layouts (desktop-first; pages should not break on narrow screens, but no dedicated mobile design)
