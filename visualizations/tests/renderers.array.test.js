import { test } from "node:test";
import assert from "node:assert/strict";
import { renderArray } from "../shared/renderers/array.js";
import { installDomStub } from "./domstub.js";

// renderArray is the most-used renderer (11 of 20 specs consume it: two-pointers,
// sliding-window, prefix-sum, binary-search, monotonic-stack, counting,
// check-existence, top-k, queues' secondary view, dp-1d's array-shaped inputs,
// and backtracking's path view) yet had zero dedicated tests before this file.
// Kept separate from renderers.test.js (925 lines and growing) rather than
// appended, per the final whole-branch review's ruling.

/** Installs a fresh DOM stub, runs `fn(stub)`, and always uninstalls afterward. */
function withDom(fn) {
  const stub = installDomStub();
  try {
    return fn(stub);
  } finally {
    stub.uninstall();
  }
}

test("array: renders one column (pointer row, cell, index label) per cell", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: [1, 2, 3], pointers: {}, colors: {} };

    renderArray(view, el);

    assert.equal(el.querySelectorAll(".viz-array__col").length, 3, "expected three columns");
    assert.equal(el.querySelectorAll(".viz-array__cell").length, 3, "expected three cells");
    assert.equal(el.querySelectorAll(".viz-array__ptr").length, 3, "expected three pointer rows");
    assert.equal(el.querySelectorAll(".viz-array__index").length, 3, "expected three index labels");
  });
});

test("array: each cell shows its own value as text", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: [7, 8, 9], pointers: {}, colors: {} };

    renderArray(view, el);

    const cells = el.querySelectorAll(".viz-array__cell");
    assert.deepEqual(
      cells.map((c) => c.textContent),
      ["7", "8", "9"],
    );
  });
});

test("array: index labels read 0, 1, 2, ... regardless of cell values", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: ["x", "y", "z", "w"], pointers: {}, colors: {} };

    renderArray(view, el);

    const labels = el.querySelectorAll(".viz-array__index");
    assert.deepEqual(
      labels.map((l) => l.textContent),
      ["0", "1", "2", "3"],
    );
  });
});

test("array: a single pointer at an index renders that pointer's name above it, and nowhere else", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: [1, 2, 3], pointers: { L: 0, R: 2 }, colors: {} };

    renderArray(view, el);

    const ptrs = el.querySelectorAll(".viz-array__ptr");
    assert.equal(ptrs[0].textContent, "L");
    assert.equal(ptrs[1].textContent, "", "no pointer targets index 1");
    assert.equal(ptrs[2].textContent, "R");
  });
});

test("array: two pointers landing on the SAME index both render, space-separated (the grouping path)", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    // L and R have met/crossed at the same index, which two-pointers.js does
    // on its closing frame — array.js groups pointer names by index rather
    // than assuming each index has at most one pointer.
    const view = { kind: "array", cells: [1, 2, 3], pointers: { L: 1, R: 1 }, colors: {} };

    renderArray(view, el);

    const ptrs = el.querySelectorAll(".viz-array__ptr");
    assert.equal(ptrs[0].textContent, "");
    assert.equal(ptrs[1].textContent, "L R", "both pointer names must appear on the shared index");
    assert.equal(ptrs[2].textContent, "");
  });
});

test("array: three pointers can all land on the same index and all three names render together", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: [1, 2], pointers: { slow: 0, fast: 0, mid: 0 }, colors: {} };

    renderArray(view, el);

    const [ptr0] = el.querySelectorAll(".viz-array__ptr");
    // Order follows Object.entries(view.pointers) insertion order.
    assert.equal(ptr0.textContent, "slow fast mid");
  });
});

test("array: view.colors[i] adds is-<color> to exactly that cell", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "array",
      cells: [1, 2, 3, 4],
      pointers: {},
      colors: { 1: "active", 2: "fail" },
    };

    renderArray(view, el);

    const cells = el.querySelectorAll(".viz-array__cell");
    assert.equal(cells[0].classList.contains("is-active"), false);
    assert.equal(cells[0].classList.contains("is-fail"), false);
    assert.equal(cells[1].classList.contains("is-active"), true);
    assert.equal(cells[2].classList.contains("is-fail"), true);
    assert.equal(cells[3].classList.contains("is-active"), false);
    assert.equal(cells[3].classList.contains("is-fail"), false);
  });
});

test("array: a cell with no color entry gets no is-<color> class at all", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: [1], pointers: {}, colors: {} };

    renderArray(view, el);

    const [cell] = el.querySelectorAll(".viz-array__cell");
    // className is exactly the base class — no extra "is-" token appended.
    assert.equal(cell.className, "viz-array__cell");
  });
});

test("array: view.window shades every cell in [start, end] inclusive, and nothing outside it", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "array",
      cells: [0, 1, 2, 3, 4],
      pointers: {},
      colors: {},
      window: { start: 1, end: 3 },
    };

    renderArray(view, el);

    const cells = el.querySelectorAll(".viz-array__cell");
    assert.equal(cells[0].classList.contains("is-window"), false, "before the window");
    assert.equal(cells[1].classList.contains("is-window"), true, "window start, inclusive");
    assert.equal(cells[2].classList.contains("is-window"), true, "window middle");
    assert.equal(cells[3].classList.contains("is-window"), true, "window end, inclusive");
    assert.equal(cells[4].classList.contains("is-window"), false, "after the window");
  });
});

test("array: a window pinned to the array's start edge (start === 0) shades from index 0", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "array",
      cells: [0, 1, 2, 3],
      pointers: {},
      colors: {},
      window: { start: 0, end: 1 },
    };

    renderArray(view, el);

    const cells = el.querySelectorAll(".viz-array__cell");
    assert.equal(cells[0].classList.contains("is-window"), true, "index 0 is the window start");
    assert.equal(cells[1].classList.contains("is-window"), true);
    assert.equal(cells[2].classList.contains("is-window"), false);
    assert.equal(cells[3].classList.contains("is-window"), false);
  });
});

test("array: a window pinned to the array's end edge (end === last index) shades through the last cell", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "array",
      cells: [0, 1, 2, 3],
      pointers: {},
      colors: {},
      window: { start: 2, end: 3 },
    };

    renderArray(view, el);

    const cells = el.querySelectorAll(".viz-array__cell");
    assert.equal(cells[0].classList.contains("is-window"), false);
    assert.equal(cells[1].classList.contains("is-window"), false);
    assert.equal(cells[2].classList.contains("is-window"), true);
    assert.equal(cells[3].classList.contains("is-window"), true, "last index is the window end");
  });
});

test("array: no view.window at all shades nothing", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: [0, 1, 2], pointers: {}, colors: {} };

    renderArray(view, el);

    const cells = el.querySelectorAll(".viz-array__cell");
    assert.ok(
      cells.every((c) => !c.classList.contains("is-window")),
      "no cell should carry is-window when view.window is absent",
    );
  });
});

test("array: view.caption renders a <p class=\"viz-caption\"> with the caption text", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: [1], pointers: {}, colors: {}, caption: "lo > hi — search space exhausted" };

    renderArray(view, el);

    const captions = el.querySelectorAll(".viz-caption");
    assert.equal(captions.length, 1, "expected exactly one caption element");
    assert.equal(captions[0].textContent, "lo > hi — search space exhausted");
  });
});

test("array: no view.caption renders no caption element", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: [1], pointers: {}, colors: {} };

    renderArray(view, el);

    assert.equal(el.querySelectorAll(".viz-caption").length, 0);
  });
});

test("array: a cell holding the falsy value 0 renders '0', not an empty cell", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: [0, 1], pointers: {}, colors: {} };

    renderArray(view, el);

    const cells = el.querySelectorAll(".viz-array__cell");
    assert.equal(cells[0].textContent, "0");
  });
});

test("array: an empty cells array renders no columns and does not throw", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "array", cells: [], pointers: {}, colors: {} };

    assert.doesNotThrow(() => renderArray(view, el));
    assert.equal(el.querySelectorAll(".viz-array__col").length, 0);
  });
});

test("array: repainting the same element clears the previous render instead of appending to it", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderArray({ kind: "array", cells: [1, 2, 3], pointers: {}, colors: {} }, el);
    assert.equal(el.querySelectorAll(".viz-array__col").length, 3);

    // Mirrors how shared/render.js repaints: clear the container, then render again.
    el.replaceChildren();
    renderArray({ kind: "array", cells: [9], pointers: {}, colors: {} }, el);

    assert.equal(el.querySelectorAll(".viz-array__col").length, 1, "the stale 3-column render must not remain");
  });
});
