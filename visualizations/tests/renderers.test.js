import { test } from "node:test";
import assert from "node:assert/strict";
import { renderCollection } from "../shared/renderers/collection.js";
import { renderLinkedList } from "../shared/renderers/linkedList.js";
import { renderTree } from "../shared/renderers/tree.js";
import { renderGraph } from "../shared/renderers/graph.js";
import { renderGrid } from "../shared/renderers/grid.js";
import { installDomStub } from "./domstub.js";
import { collectFrames } from "../shared/engine.js";
import fastSlowPointers from "../patterns/fast-slow-pointers.js";

const SVG_NS = "http://www.w3.org/2000/svg";

/** Installs a fresh DOM stub, runs `fn(stub)`, and always uninstalls afterward. */
function withDom(fn) {
  const stub = installDomStub();
  try {
    return fn(stub);
  } finally {
    stub.uninstall();
  }
}

test("collection: renders one box per item", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "collection",
      label: "stack",
      items: [{ value: "(" }, { value: "[" }, { value: "{" }],
      orientation: "vertical",
      highlight: [],
    };

    renderCollection(view, el);

    const items = el.querySelectorAll(".viz-collection__item");
    assert.equal(items.length, 3, "expected three items");
  });
});

test("collection: highlight indices receive is-active class", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "collection",
      label: "stack",
      items: [{ value: "(" }, { value: "[" }, { value: "{" }],
      orientation: "vertical",
      highlight: [1],
    };

    renderCollection(view, el);

    const items = el.querySelectorAll(".viz-collection__item");
    assert.equal(items[0].classList.contains("is-active"), false);
    assert.equal(items[1].classList.contains("is-active"), true);
    assert.equal(items[2].classList.contains("is-active"), false);
  });
});

test("collection: empty items renders the empty state", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "collection",
      label: "stack",
      items: [],
      orientation: "vertical",
      highlight: [],
    };

    renderCollection(view, el);

    const emptyElement = el.querySelectorAll(".viz-collection__empty");
    assert.equal(emptyElement.length, 1, "expected one empty element");
    assert.equal(emptyElement[0].textContent, "empty");
  });
});

test("collection: vertical orientation is reflected in wrapper class", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "collection",
      label: "stack",
      items: [{ value: "(" }],
      orientation: "vertical",
      highlight: [],
    };

    renderCollection(view, el);

    const wrapper = el.querySelectorAll(".viz-collection--vertical");
    assert.equal(wrapper.length, 1, "expected vertical class on wrapper");
  });
});

test("collection: horizontal orientation is reflected in wrapper class", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "collection",
      label: "queue",
      items: [{ value: "(" }],
      orientation: "horizontal",
      highlight: [],
    };

    renderCollection(view, el);

    const wrapper = el.querySelectorAll(".viz-collection--horizontal");
    assert.equal(wrapper.length, 1, "expected horizontal class on wrapper");
  });
});

test("collection: key-value items render as 'key: value'", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "collection",
      label: "map",
      items: [{ key: "name", value: "Alice" }, { key: "age", value: 30 }],
      orientation: "vertical",
      highlight: [],
    };

    renderCollection(view, el);

    const items = el.querySelectorAll(".viz-collection__item");
    assert.equal(items[0].textContent, "name: Alice");
    assert.equal(items[1].textContent, "age: 30");
  });
});

test("collection: bare value items render just the value", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "collection",
      label: "stack",
      items: [{ value: "A" }, { value: "B" }],
      orientation: "vertical",
      highlight: [],
    };

    renderCollection(view, el);

    const items = el.querySelectorAll(".viz-collection__item");
    assert.equal(items[0].textContent, "A");
    assert.equal(items[1].textContent, "B");
  });
});

test("collection: label shows item count", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "collection",
      label: "stack",
      items: [{ value: "(" }, { value: "[" }],
      orientation: "vertical",
      highlight: [],
    };

    renderCollection(view, el);

    const label = el.querySelectorAll(".viz-collection__label");
    assert.equal(label.length, 1);
    assert.equal(label[0].textContent, "stack (2)");
  });
});

test("collection: caption is rendered if present", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "collection",
      label: "stack",
      items: [{ value: "(" }],
      orientation: "vertical",
      highlight: [],
      caption: "This is a caption",
    };

    renderCollection(view, el);

    const captions = el.querySelectorAll(".viz-caption");
    assert.equal(captions.length, 1);
    assert.equal(captions[0].textContent, "This is a caption");
  });
});

function threeNodeList() {
  return {
    kind: "linkedList",
    nodes: [
      { id: "n0", value: 3 },
      { id: "n1", value: 2 },
      { id: "n2", value: 0 },
    ],
    next: { n0: "n1", n1: "n2", n2: null },
    pointers: {},
  };
}

test("linkedList: renders one node per value with matching data-id", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = threeNodeList();

    renderLinkedList(view, el);

    const nodes = el.querySelectorAll(".viz-list__node");
    assert.equal(nodes.length, 3, "expected three nodes");
    assert.deepEqual(
      nodes.map((n) => n.dataset.id),
      ["n0", "n1", "n2"],
    );
    assert.deepEqual(
      nodes.map((n) => n.textContent),
      ["3", "2", "0"],
    );
  });
});

test("linkedList: pointer names render above the node they point to", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { ...threeNodeList(), pointers: { slow: "n0", fast: "n2" } };

    renderLinkedList(view, el);

    const ptrs = el.querySelectorAll(".viz-list__ptr");
    assert.equal(ptrs.length, 3);
    assert.equal(ptrs[0].textContent, "slow");
    assert.equal(ptrs[1].textContent, "");
    assert.equal(ptrs[2].textContent, "fast");
  });
});

test("linkedList: two pointers on the same node both render, space-separated", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { ...threeNodeList(), pointers: { slow: "n1", fast: "n1" } };

    renderLinkedList(view, el);

    const ptrs = el.querySelectorAll(".viz-list__ptr");
    assert.equal(ptrs[1].textContent, "slow fast");
  });
});

test("linkedList: colors add is-<state> class to the matching node", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { ...threeNodeList(), colors: { n1: "pass" } };

    renderLinkedList(view, el);

    const nodes = el.querySelectorAll(".viz-list__node");
    assert.equal(nodes[0].classList.contains("is-pass"), false);
    assert.equal(nodes[1].classList.contains("is-pass"), true);
    assert.equal(nodes[2].classList.contains("is-pass"), false);
  });
});

test("linkedList: a forward-linked list renders '→' between every adjacent pair", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = threeNodeList(); // next: n0 -> n1 -> n2 -> null

    renderLinkedList(view, el);

    const arrows = el.querySelectorAll(".viz-list__arrow");
    assert.deepEqual(
      arrows.map((a) => a.textContent),
      ["→", "→"],
    );
  });
});

test("linkedList: a fully reversed list renders '←' between every adjacent pair", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "linkedList",
      nodes: [
        { id: "n0", value: 3 },
        { id: "n1", value: 2 },
        { id: "n2", value: 0 },
      ],
      // view.nodes keeps its original document order while next now points
      // backward at every step, as a fully reversed list would mid-render.
      next: { n2: "n1", n1: "n0", n0: null },
      pointers: {},
    };

    renderLinkedList(view, el);

    const arrows = el.querySelectorAll(".viz-list__arrow");
    assert.deepEqual(
      arrows.map((a) => a.textContent),
      ["←", "←"],
    );
  });
});

test("linkedList: a mid-rewire list renders a mix of '←', the neutral connector, and '→'", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "linkedList",
      nodes: [
        { id: "n0", value: 1 },
        { id: "n1", value: 2 },
        { id: "n2", value: 3 },
        { id: "n3", value: 4 },
      ],
      // n0 and n1 have already been rewired (n1 -> n0); n2 -> n3 has not
      // been reached yet and is still forward; the n1/n2 pair no longer
      // points either way, since n1 now points backward at n0.
      next: { n0: null, n1: "n0", n2: "n3", n3: null },
      pointers: {},
    };

    renderLinkedList(view, el);

    const arrows = el.querySelectorAll(".viz-list__arrow");
    assert.deepEqual(
      arrows.map((a) => a.textContent),
      ["←", "–", "→"],
    );
  });
});

test("linkedList: neither node pointing at the other renders the neutral connector", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "linkedList",
      nodes: [
        { id: "n0", value: 1 },
        { id: "n1", value: 2 },
      ],
      next: { n0: null, n1: null },
      pointers: {},
    };

    renderLinkedList(view, el);

    const arrows = el.querySelectorAll(".viz-list__arrow");
    assert.deepEqual(
      arrows.map((a) => a.textContent),
      ["–"],
    );
  });
});

test("linkedList: a view with no next map at all falls back to '→' for every pair (does not render every arrow as the neutral connector)", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "linkedList",
      nodes: [
        { id: "n0", value: 1 },
        { id: "n1", value: 2 },
        { id: "n2", value: 3 },
      ],
      pointers: {},
      // no `next` field at all
    };

    renderLinkedList(view, el);

    const arrows = el.querySelectorAll(".viz-list__arrow");
    assert.deepEqual(
      arrows.map((a) => a.textContent),
      ["→", "→"],
    );
  });
});

test("linkedList: a next map that is explicitly supplied but simply lacks a pair still renders the neutral connector for that pair", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "linkedList",
      nodes: [
        { id: "n0", value: 1 },
        { id: "n1", value: 2 },
      ],
      // next IS supplied (not absent) — it just has no entry linking n0/n1
      // either way. This must keep today's neutral-connector behavior,
      // not the absent-map fallback.
      next: {},
      pointers: {},
    };

    renderLinkedList(view, el);

    const arrows = el.querySelectorAll(".viz-list__arrow");
    assert.deepEqual(
      arrows.map((a) => a.textContent),
      ["–"],
    );
  });
});

test("linkedList: cycle marker renders when the last node's next targets a non-adjacent node", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "linkedList",
      nodes: [
        { id: "n0", value: 3 },
        { id: "n1", value: 2 },
        { id: "n2", value: 0 },
      ],
      // n2 (the last node) points back to n0 — its predecessor's predecessor,
      // not the node immediately before it (n1) — so this is a genuine cycle,
      // not a reversal-in-progress artifact.
      next: { n0: "n1", n1: "n2", n2: "n0" },
      pointers: {},
    };

    renderLinkedList(view, el);

    const cycle = el.querySelectorAll(".viz-list__cycle");
    assert.equal(cycle.length, 1, "expected the cycle marker");
    assert.equal(cycle[0].textContent, "↩ back to 3");
  });
});

test("linkedList: cycle marker is suppressed when the last node's next targets its immediate predecessor, and the predecessor no longer points forward at it (the real mid-reversal shape)", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "linkedList",
      nodes: [
        { id: "n0", value: 3 },
        { id: "n1", value: 2 },
      ],
      // n1 (the last node) points back to n0, which is also the node
      // immediately before it in view.nodes order. Crucially, n0's own next
      // has ALREADY been rewired away from n1 (to null here) — this is the
      // shape reversal actually produces: by the time n1 is processed and
      // rewired backward, n0 (processed earlier, since traversal walks the
      // list forward) no longer points forward at n1. That is what makes
      // this a reversal artifact rather than a genuine cycle.
      next: { n0: null, n1: "n0" },
      pointers: {},
    };

    renderLinkedList(view, el);

    const cycle = el.querySelectorAll(".viz-list__cycle");
    assert.equal(cycle.length, 0, "did not expect a cycle marker for an adjacent-predecessor target");
  });
});

test("linkedList: cycle marker still renders for a genuine cycle whose back-edge targets the immediate predecessor", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "linkedList",
      nodes: [
        { id: "n0", value: 1 },
        { id: "n1", value: 2 },
        { id: "n2", value: 3 },
      ],
      // n2 (the last node) points back to n1, its immediate predecessor —
      // the same shape a reversal artifact has. But here n1 STILL points
      // forward at n2 (next.n1 === "n2") at the same time, which a
      // mid-reversal state can never produce (see the test above): this is
      // what distinguishes a genuine cycle whose back-edge happens to land
      // on the immediate predecessor from a reversal-in-progress artifact.
      next: { n0: "n1", n1: "n2", n2: "n1" },
      pointers: {},
    };

    renderLinkedList(view, el);

    const cycle = el.querySelectorAll(".viz-list__cycle");
    assert.equal(cycle.length, 1, "expected the cycle marker for a genuine cycle, even onto the immediate predecessor");
    assert.equal(cycle[0].textContent, "↩ back to 2");
  });
});

test("linkedList: fast-slow-pointers' cycle inputs still render the cycle marker on every frame (regression)", () => {
  withDom((stub) => {
    const cases = [
      { label: "4-node cycle back to index 1", data: { values: [3, 2, 0, -4], cycleTo: 1 }, expectedTarget: "2" },
      { label: "single-node self-cycle", data: { values: [1], cycleTo: 0 }, expectedTarget: "1" },
    ];

    for (const { label, data, expectedTarget } of cases) {
      const { frames } = collectFrames(fastSlowPointers, data);
      assert.ok(frames.length > 0, `${label}: expected at least one frame`);
      frames.forEach((frame, i) => {
        const el = stub.document.createElement("div");
        renderLinkedList(frame.view, el);
        const cycle = el.querySelectorAll(".viz-list__cycle");
        assert.equal(cycle.length, 1, `${label}, frame ${i}: expected the cycle marker to render`);
        assert.equal(cycle[0].textContent, `↩ back to ${expectedTarget}`, `${label}, frame ${i}: wrong cycle target`);
      });
    }
  });
});

test("linkedList: cycle marker is absent for a plain (non-cyclic) list", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = threeNodeList();

    renderLinkedList(view, el);

    const cycle = el.querySelectorAll(".viz-list__cycle");
    assert.equal(cycle.length, 0, "did not expect a cycle marker");
  });
});

test("linkedList: empty nodes renders the empty-list state", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "linkedList", nodes: [], next: {}, pointers: {} };

    renderLinkedList(view, el);

    const empty = el.querySelectorAll(".viz-collection__empty");
    assert.equal(empty.length, 1, "expected one empty element");
    assert.equal(empty[0].textContent, "empty list");
  });
});

function fiveNodeTree() {
  return {
    kind: "tree",
    nodes: [
      { id: "a", value: 3, x: 0.5, y: 0.1 },
      { id: "b", value: 9, x: 0.25, y: 0.5 },
      { id: "c", value: 20, x: 0.75, y: 0.5 },
      { id: "d", value: 15, x: 0.6, y: 0.9 },
      { id: "e", value: 7, x: 0.9, y: 0.9 },
    ],
    edges: [
      ["a", "b"],
      ["a", "c"],
      ["c", "d"],
      ["c", "e"],
    ],
    current: null,
    visited: [],
    frontier: [],
  };
}

test("tree: renders one node circle and one edge line per input", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderTree(fiveNodeTree(), el);

    assert.equal(el.querySelectorAll(".viz-tree__node").length, 5, "expected five nodes");
    assert.equal(el.querySelectorAll(".viz-tree__edge").length, 4, "expected four edges");
  });
});

test("tree: builds every SVG element with createElementNS and the SVG namespace", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderTree(fiveNodeTree(), el);

    const svg = el.children[0];
    assert.equal(svg.tagName, "SVG");
    assert.equal(svg.namespaceURI, SVG_NS, "svg root must carry the SVG namespace");

    const [edge] = el.querySelectorAll(".viz-tree__edge");
    const [node] = el.querySelectorAll(".viz-tree__node");
    assert.equal(edge.namespaceURI, SVG_NS, "edges must be created with createElementNS");
    assert.equal(node.namespaceURI, SVG_NS, "nodes must be created with createElementNS");
  });
});

test("tree: edges are painted before nodes so nodes stack on top", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderTree(fiveNodeTree(), el);

    const svg = el.children[0];
    const tagsInOrder = svg.children.map((child) => child.tagName);
    const firstNonLineIndex = tagsInOrder.findIndex((tag) => tag !== "LINE");

    assert.equal(firstNonLineIndex, 4, "all four edge lines must precede any node element");
    assert.ok(
      tagsInOrder.slice(0, 4).every((tag) => tag === "LINE"),
      "the first four children must be the edge lines",
    );
    assert.equal(tagsInOrder[4], "CIRCLE", "the first node element after the edges must be a circle");
  });
});

test("tree: current/visited/frontier ids each receive their matching state class", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { ...fiveNodeTree(), current: "a", visited: ["b"], frontier: ["c", "d"] };

    renderTree(view, el);

    // renderTree emits node circles in view.nodes document order: a, b, c, d, e.
    const [a, b, c, d, e] = el.querySelectorAll(".viz-tree__node");

    assert.equal(a.classList.contains("is-current"), true);
    assert.equal(b.classList.contains("is-visited"), true);
    assert.equal(c.classList.contains("is-frontier"), true);
    assert.equal(d.classList.contains("is-frontier"), true);
    assert.equal(e.classList.contains("is-current"), false);
    assert.equal(e.classList.contains("is-visited"), false);
    assert.equal(e.classList.contains("is-frontier"), false);
  });
});

test("tree: is-current wins when a node is in more than one set", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { ...fiveNodeTree(), current: "a", visited: ["a"], frontier: ["a"] };

    renderTree(view, el);

    const [a] = el.querySelectorAll(".viz-tree__node");
    assert.equal(a.classList.contains("is-current"), true);
    assert.equal(a.classList.contains("is-visited"), false);
    assert.equal(a.classList.contains("is-frontier"), false);
  });
});

test("tree: pruned ids receive the is-pruned state class, distinct from is-frontier", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { ...fiveNodeTree(), pruned: ["d", "e"] };

    renderTree(view, el);

    const [a, b, c, d, e] = el.querySelectorAll(".viz-tree__node");
    assert.equal(d.classList.contains("is-pruned"), true);
    assert.equal(e.classList.contains("is-pruned"), true);
    assert.equal(d.classList.contains("is-frontier"), false);
    assert.equal(e.classList.contains("is-frontier"), false);

    assert.equal(a.classList.contains("is-pruned"), false);
    assert.equal(b.classList.contains("is-pruned"), false);
    assert.equal(c.classList.contains("is-pruned"), false);
  });
});

test("tree: frontier and pruned can be set independently on the same view without colliding", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { ...fiveNodeTree(), frontier: ["b"], pruned: ["d"] };

    renderTree(view, el);

    const [, b, , d] = el.querySelectorAll(".viz-tree__node");
    assert.equal(b.classList.contains("is-frontier"), true);
    assert.equal(b.classList.contains("is-pruned"), false);
    assert.equal(d.classList.contains("is-pruned"), true);
    assert.equal(d.classList.contains("is-frontier"), false);
  });
});

test("tree: is-visited wins over is-pruned when a node is in both sets", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { ...fiveNodeTree(), visited: ["b"], pruned: ["b"] };

    renderTree(view, el);

    const [, b] = el.querySelectorAll(".viz-tree__node");
    assert.equal(b.classList.contains("is-visited"), true);
    assert.equal(b.classList.contains("is-pruned"), false);
  });
});

test("tree: a view with no pruned field renders no is-pruned nodes (default empty)", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderTree(fiveNodeTree(), el);

    const nodes = el.querySelectorAll(".viz-tree__node");
    assert.ok(
      nodes.every((n) => !n.classList.contains("is-pruned")),
      "no node should carry is-pruned when view.pruned is absent",
    );
  });
});

test("tree: view.labels renders an optional label only for ids present in the map", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { ...fiveNodeTree(), labels: { b: "queued" } };

    renderTree(view, el);

    const labels = el.querySelectorAll(".viz-tree__label");
    assert.equal(labels.length, 1, "expected exactly one label");
    assert.equal(labels[0].textContent, "queued");
  });
});

test("tree: an empty nodes array renders no nodes or edges and does not throw", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "tree", nodes: [], edges: [], current: null, visited: [], frontier: [] };

    assert.doesNotThrow(() => renderTree(view, el));
    assert.equal(el.querySelectorAll(".viz-tree__node").length, 0);
    assert.equal(el.querySelectorAll(".viz-tree__edge").length, 0);
  });
});

test("tree: the svg root declares viewBox and preserveAspectRatio", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderTree(fiveNodeTree(), el);

    const svg = el.children[0];
    assert.equal(svg.getAttribute("viewBox"), "0 0 100 100");
    assert.equal(svg.getAttribute("preserveAspectRatio"), "xMidYMid meet");
  });
});

function sevenNodeGraph(extra = {}) {
  return {
    kind: "graph",
    nodes: [
      { id: 0, label: "0", x: 0.1, y: 0.5 },
      { id: 1, label: "1", x: 0.32, y: 0.2 },
      { id: 2, label: "2", x: 0.32, y: 0.8 },
      { id: 3, label: "3", x: 0.55, y: 0.5 },
      { id: 4, label: "4", x: 0.78, y: 0.3 },
      { id: 5, label: "5", x: 0.95, y: 0.6 },
      { id: 6, label: "6", x: 0.78, y: 0.9 },
    ],
    edges: [[0, 1], [0, 2], [1, 3], [2, 3], [3, 4], [4, 5]],
    current: null,
    visited: [],
    activeEdge: null,
    distances: {},
    ...extra,
  };
}

test("graph: renders one node circle per node and one edge line per edge", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGraph(sevenNodeGraph(), el);

    assert.equal(el.querySelectorAll(".viz-graph__node").length, 7, "expected seven nodes");
    assert.equal(el.querySelectorAll(".viz-graph__edge").length, 6, "expected six edges");
  });
});

test("graph: builds every SVG element with createElementNS and the SVG namespace", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGraph(sevenNodeGraph(), el);

    const svg = el.children[0];
    assert.equal(svg.tagName, "SVG");
    assert.equal(svg.namespaceURI, SVG_NS, "svg root must carry the SVG namespace");

    const [edge] = el.querySelectorAll(".viz-graph__edge");
    const [node] = el.querySelectorAll(".viz-graph__node");
    assert.equal(edge.namespaceURI, SVG_NS, "edges must be created with createElementNS");
    assert.equal(node.namespaceURI, SVG_NS, "nodes must be created with createElementNS");
  });
});

test("graph: the svg root declares viewBox and preserveAspectRatio", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGraph(sevenNodeGraph(), el);

    const svg = el.children[0];
    assert.equal(svg.getAttribute("viewBox"), "0 0 100 100");
    assert.equal(svg.getAttribute("preserveAspectRatio"), "xMidYMid meet");
  });
});

test("graph: edges are painted before nodes so nodes stack on top", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGraph(sevenNodeGraph(), el);

    const svg = el.children[0];
    const tagsInOrder = svg.children.map((child) => child.tagName);
    const firstNonLineIndex = tagsInOrder.findIndex((tag) => tag !== "LINE");

    assert.equal(firstNonLineIndex, 6, "all six edge lines must precede any node element");
    assert.ok(
      tagsInOrder.slice(0, 6).every((tag) => tag === "LINE"),
      "the first six children must be the edge lines",
    );
    assert.equal(tagsInOrder[6], "CIRCLE", "the first node element after the edges must be a circle");
  });
});

test("graph: current/visited ids each receive their matching state class", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = sevenNodeGraph({ current: 0, visited: [1, 2] });

    renderGraph(view, el);

    // renderGraph emits node circles in view.nodes document order: 0..6.
    const nodeCircles = el.querySelectorAll(".viz-graph__node");

    assert.equal(nodeCircles[0].classList.contains("is-current"), true);
    assert.equal(nodeCircles[1].classList.contains("is-visited"), true);
    assert.equal(nodeCircles[2].classList.contains("is-visited"), true);
    assert.equal(nodeCircles[3].classList.contains("is-current"), false);
    assert.equal(nodeCircles[3].classList.contains("is-visited"), false);
  });
});

test("graph: is-current wins when a node is in both current and visited", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = sevenNodeGraph({ current: 0, visited: [0] });

    renderGraph(view, el);

    const [node0] = el.querySelectorAll(".viz-graph__node");
    assert.equal(node0.classList.contains("is-current"), true);
    assert.equal(node0.classList.contains("is-visited"), false);
  });
});

test("graph: activeEdge [a, b] marks the matching edge is-active", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = sevenNodeGraph({ activeEdge: [0, 1] });

    renderGraph(view, el);

    const edges = el.querySelectorAll(".viz-graph__edge");
    // edges[0] corresponds to [0, 1] in EDGES document order.
    assert.equal(edges[0].classList.contains("is-active"), true);
    assert.equal(edges[1].classList.contains("is-active"), false);
  });
});

test("graph: activeEdge [b, a] (reversed order) still marks the matching edge is-active", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = sevenNodeGraph({ activeEdge: [1, 0] });

    renderGraph(view, el);

    const edges = el.querySelectorAll(".viz-graph__edge");
    assert.equal(edges[0].classList.contains("is-active"), true);
    assert.equal(edges[1].classList.contains("is-active"), false);
  });
});

test("graph: no activeEdge marks no edge is-active", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGraph(sevenNodeGraph({ activeEdge: null }), el);

    const edges = el.querySelectorAll(".viz-graph__edge");
    assert.ok(edges.every((edge) => edge.classList.contains("is-active") === false));
  });
});

test("graph: nodes present in view.distances render a d=<n> label", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = sevenNodeGraph({ distances: { 0: 0, 1: 1, 2: 1 } });

    renderGraph(view, el);

    const distLabels = el.querySelectorAll(".viz-graph__dist");
    assert.equal(distLabels.length, 3, "expected exactly three distance labels");
    assert.deepEqual(
      distLabels.map((n) => n.textContent),
      ["d=0", "d=1", "d=1"],
    );
  });
});

test("graph: a node with no distances entry renders plainly, with no d= label", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    // Node 6 (the isolated node in the sample graph) never appears in distances.
    const view = sevenNodeGraph({ distances: { 0: 0 } });

    renderGraph(view, el);

    const distLabels = el.querySelectorAll(".viz-graph__dist");
    assert.equal(distLabels.length, 1, "only node 0 should carry a distance label");
    assert.equal(distLabels[0].textContent, "d=0");

    const labels = el.querySelectorAll(".viz-graph__label");
    assert.equal(labels.length, 7, "every node, including undiscovered ones, still renders its label");
    assert.equal(labels[6].textContent, "6");
  });
});

test("graph: an empty nodes array renders no nodes or edges and does not throw", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "graph", nodes: [], edges: [], current: null, visited: [], activeEdge: null, distances: {} };

    assert.doesNotThrow(() => renderGraph(view, el));
    assert.equal(el.querySelectorAll(".viz-graph__node").length, 0);
    assert.equal(el.querySelectorAll(".viz-graph__edge").length, 0);
  });
});

function threeByTwoGrid(extra = {}) {
  return {
    kind: "grid",
    rows: [
      [1, 2, 3],
      [4, 5, 6],
    ],
    ...extra,
  };
}

test("grid: renders one cell per entry for a 2x3 grid", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGrid(threeByTwoGrid(), el);

    const cells = el.querySelectorAll(".viz-grid__cell");
    assert.equal(cells.length, 6, "expected six cells");
  });
});

test("grid: every cell carries matching data-r and data-c", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGrid(threeByTwoGrid(), el);

    const cells = el.querySelectorAll(".viz-grid__cell");
    const coords = cells.map((cell) => `${cell.dataset.r},${cell.dataset.c}`).sort();
    assert.deepEqual(coords, ["0,0", "0,1", "0,2", "1,0", "1,1", "1,2"]);
  });
});

test("grid: row labels render when view.rowLabels is present", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGrid(threeByTwoGrid({ rowLabels: ["a", "b"] }), el);

    const labels = el.querySelectorAll(".viz-grid__row-label");
    assert.equal(labels.length, 2, "expected one row label per row");
    assert.deepEqual(labels.map((l) => l.textContent), ["a", "b"]);
  });
});

test("grid: row labels are absent when view.rowLabels is not present", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGrid(threeByTwoGrid(), el);

    const labels = el.querySelectorAll(".viz-grid__row-label");
    assert.equal(labels.length, 0, "did not expect any row labels");
  });
});

test("grid: col labels render across the top when view.colLabels is present", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGrid(threeByTwoGrid({ colLabels: [0, 1, 2] }), el);

    const labels = el.querySelectorAll(".viz-grid__col-label");
    assert.equal(labels.length, 3, "expected one col label per column");
    assert.deepEqual(labels.map((l) => l.textContent), ["0", "1", "2"]);
  });
});

test("grid: col labels are absent when view.colLabels is not present", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    renderGrid(threeByTwoGrid(), el);

    const labels = el.querySelectorAll(".viz-grid__col-label");
    assert.equal(labels.length, 0, "did not expect any col labels");
  });
});

test("grid: view.colors['r,c'] adds is-<state> to exactly that cell", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = threeByTwoGrid({ colors: { "0,1": "dim" } });

    renderGrid(view, el);

    const cells = el.querySelectorAll(".viz-grid__cell");
    const dimmed = cells.filter((c) => c.classList.contains("is-dim"));
    assert.equal(dimmed.length, 1, "expected exactly one dimmed cell");
    assert.equal(dimmed[0].dataset.r, "0");
    assert.equal(dimmed[0].dataset.c, "1");
  });
});

test("grid: view.current adds is-current to exactly that cell", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = threeByTwoGrid({ current: { r: 1, c: 2 } });

    renderGrid(view, el);

    const cells = el.querySelectorAll(".viz-grid__cell");
    const current = cells.filter((c) => c.classList.contains("is-current"));
    assert.equal(current.length, 1, "expected exactly one current cell");
    assert.equal(current[0].dataset.r, "1");
    assert.equal(current[0].dataset.c, "2");
  });
});

test("grid: a cell holding the falsy value 0 renders '0', not an empty cell", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = { kind: "grid", rows: [[0, 1]] };

    renderGrid(view, el);

    const cells = el.querySelectorAll(".viz-grid__cell");
    assert.equal(cells[0].textContent, "0");
    assert.equal(cells[1].textContent, "1");
  });
});
