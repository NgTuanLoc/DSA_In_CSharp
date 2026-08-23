# DSA Pattern Visualizations

Self-contained, dependency-free browser visualizations of the algorithm
patterns implemented in `src/DSA/LeetCode/`. Each pattern has its own page
with a step-by-step, Play/Pause/scrub walkthrough synced to a pseudocode
listing. There is no build step and no npm dependency — every file is plain
HTML, CSS, and ES modules.

## Quick start

From the repository root:

```
cd visualizations && python -m http.server 8000
```

Then open `http://localhost:8000`. This leaves your shell's working directory
at `visualizations/` for the rest of this page — the command blocks below say
explicitly which directory each one expects, since `cd`ing here changes what
a bare relative path resolves to.

## Why a server, and not just double-clicking `index.html`

The pages load pattern code via native ES modules (`<script type="module">`,
`import`/`export`). Browsers refuse to resolve module imports from a `file://`
URL for security reasons, so opening the file directly leaves the gallery and
pattern pages blank. Any static file server works; `python -m http.server` is
the one assumed above because it ships with Python and needs no install.
`index.html` detects the `file://` case and shows an on-page warning pointing
back to this command.

## Running the tests

Two independent test harnesses cover this folder, and both should be run.
Mind the working directory for each — the glob path only resolves from the
repository root, and the other two only resolve from inside `visualizations/`:

**From the repository root** (one level above this folder):

```
node --test "visualizations/tests/*.test.js"
```

Node's built-in test runner, covering the shared renderers, the shared
engine, and every pattern spec's structure and frame-by-frame behavior. Run
from inside `visualizations/` instead, this glob matches zero files and
prints `tests 0 / pass 0 / fail 0` — a silent false green, not an error — so
double-check you're one level up before trusting a 0/0 result.

**From inside `visualizations/`:**

```
tests.html
```

Open this file the same way as `index.html` — as a URL served by the local
server started above (e.g. `http://localhost:8000/tests.html`), never via
`file://` — for a browser-based run of the same renderer and spec checks,
useful when you want to see a failure rendered rather than read from a
terminal.

```
node tests.node.mjs
```

Also run from inside `visualizations/` (it imports `./patterns/registry.js`
relatively). Runs just the spec self-checks and prints a pass/fail table —
it's what CI or a quick sanity check would use.

## Adding a new pattern

1. Write `patterns/<slug>.js` exporting a `PatternSpec` object (`title`,
   `slug`, `folder`, `complexity`, `whenToUse`, `problems`, `pseudocode`,
   `inputs`, `run`) — model it on an existing spec file. `slug` must match the
   filename exactly and be unique.
2. Copy an existing `patterns/<slug>.html` shell and update its two lines:
   the `<title>` and the `import spec from "./<slug>.js"` path.
3. Add one import and one line to the `specs` array in
   `patterns/registry.js`.

That's it — the gallery (`index.html`) and both test harnesses read the
registry, so a new entry is picked up everywhere automatically. Nothing else
needs to be hand-wired.

## The one rule for spec modules

Pattern spec modules (`patterns/*.js`), `shared/kinds.js`, `shared/engine.js`,
`shared/selftest.js`, and `patterns/registry.js` must stay DOM-free — never
reference `document` or `window`. This is what lets them run unmodified under
Node's test runner as well as in the browser. Any DOM manipulation belongs in
`shared/page.js`, `shared/render.js`, `index.html`, or `tests.html`.
