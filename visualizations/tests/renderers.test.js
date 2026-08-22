import { test } from "node:test";
import assert from "node:assert/strict";
import { renderCollection } from "../shared/renderers/collection.js";
import { renderLinkedList } from "../shared/renderers/linkedList.js";
import { installDomStub } from "./domstub.js";

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
