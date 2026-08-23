import { test } from "node:test";
import assert from "node:assert/strict";
import { paint } from "../shared/render.js";
import { RENDERER_KINDS } from "../shared/kinds.js";
import { specs } from "../patterns/registry.js";
import { collectFrames } from "../shared/engine.js";
import { installDomStub } from "./domstub.js";

// This file stands in for the two checks task-18-brief.md's Steps 3 and 4
// require a browser for: opening tests.html and walking all 20 pages to
// confirm each "loads without console errors". Neither check can be
// performed here (no browser is available), so instead this exercises the
// REAL render dispatch (shared/render.js) and the REAL renderer modules
// under shared/renderers/*.js, against a hand-rolled DOM stub, for every
// frame every spec's every preset input produces. It cannot replace human
// eyes on the rendered page (see task-18-report.md for the residual
// human-verification list), but it is the strongest mechanical proxy
// available: if any renderer throws an uncaught error, or silently paints
// nothing, or (because paint() itself swallows renderer exceptions into an
// error banner rather than propagating them — see shared/render.js) falls
// back to the error banner for a view a spec produced, this catches it.

/** One minimal, valid view per renderer kind, used only to prove dispatch coverage. */
function minimalViewFor(kind) {
  switch (kind) {
    case "array":
      return { kind, cells: [1, 2, 3], pointers: { i: 0 } };
    case "collection":
      return { kind, label: "stack", items: [{ value: 1 }], orientation: "vertical", highlight: [] };
    case "linkedList":
      return { kind, nodes: [{ id: "n0", value: 1 }], next: { n0: null }, pointers: {} };
    case "tree":
      return { kind, nodes: [{ id: "a", value: 1, x: 0.5, y: 0.5 }], edges: [], current: null, visited: [], frontier: [] };
    case "graph":
      return {
        kind,
        nodes: [{ id: 0, label: "0", x: 0.5, y: 0.5 }],
        edges: [],
        current: null,
        visited: [],
        activeEdge: null,
        distances: {},
      };
    case "grid":
      return { kind, rows: [[1, 2]] };
    default:
      throw new Error(`minimalViewFor: no fixture for kind "${kind}"`);
  }
}

/**
 * Paints `view` into a fresh element and asserts the real dispatch/renderer
 * pipeline behaved: no exception escaped, some output was produced, and (for
 * views expected to be legitimate, i.e. not the deliberate unknown-kind
 * case) no error banner was produced. A `.viz-error` banner is the one
 * signal a defect would leave behind, since paint() catches renderer
 * exceptions internally instead of letting them propagate.
 */
function paintAndCheck(view, { expectError = false, context = "" } = {}) {
  const stub = installDomStub();
  try {
    const el = stub.document.createElement("div");
    assert.doesNotThrow(() => paint(view, el), `${context}: paint() threw`);

    const errorBanners = el.querySelectorAll(".viz-error");
    if (expectError) {
      assert.equal(errorBanners.length, 1, `${context}: expected exactly one error banner`);
    } else {
      assert.equal(errorBanners.length, 0, `${context}: unexpected error banner (renderer likely threw internally)`);
      assert.ok(el.children.length > 0, `${context}: paint() produced no output`);
    }
  } finally {
    stub.uninstall();
  }
}

test("paint dispatch covers every kind in RENDERER_KINDS", () => {
  assert.ok(RENDERER_KINDS.length > 0, "RENDERER_KINDS is empty");
  for (const kind of RENDERER_KINDS) {
    paintAndCheck(minimalViewFor(kind), { context: `dispatch coverage for kind "${kind}"` });
  }
});

test("paint(): an unknown view kind produces the error banner rather than throwing", () => {
  paintAndCheck({ kind: "hologram" }, { expectError: true, context: "unknown kind" });
});

// For every spec in the registry and every one of its preset inputs, collect
// every frame and paint each one (view, and view2 when present) through the
// real renderer pipeline. One test per spec/input pair so a failure names
// exactly which page and which preset input it came from.
for (const spec of specs) {
  for (const input of spec.inputs) {
    test(`paint every frame: ${spec.title} — ${input.label}`, () => {
      const { frames } = collectFrames(spec, input.data);
      assert.ok(frames.length > 0, `${spec.title} — ${input.label}: expected at least one frame`);

      frames.forEach((frame, i) => {
        const context = `${spec.title} — ${input.label}, frame ${i}`;
        paintAndCheck(frame.view, { context: `${context} (view)` });
        if (frame.view2) {
          paintAndCheck(frame.view2, { context: `${context} (view2)` });
        }
      });
    });
  }
}
