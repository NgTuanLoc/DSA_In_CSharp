import { test } from "node:test";
import assert from "node:assert/strict";
import { renderCollection } from "../shared/renderers/collection.js";
import { renderLinkedList } from "../shared/renderers/linkedList.js";
import { renderTree } from "../shared/renderers/tree.js";
import { installDomStub } from "./domstub.js";

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

test("linkedList: cycle marker appears when the last node's next is not null", () => {
  withDom((stub) => {
    const el = stub.document.createElement("div");
    const view = {
      kind: "linkedList",
      nodes: [
        { id: "n0", value: 3 },
        { id: "n1", value: 2 },
      ],
      next: { n0: "n1", n1: "n0" },
      pointers: {},
    };

    renderLinkedList(view, el);

    const cycle = el.querySelectorAll(".viz-list__cycle");
    assert.equal(cycle.length, 1, "expected the cycle marker");
    assert.equal(cycle[0].textContent, "↩ back to 3");
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
