import { test } from "node:test";
import assert from "node:assert/strict";
import { renderCollection } from "../shared/renderers/collection.js";
import { installDomStub } from "./domstub.js";

test("collection: renders one box per item", () => {
  const stub = installDomStub();
  try {
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
  } finally {
    stub.uninstall();
  }
});

test("collection: highlight indices receive is-active class", () => {
  const stub = installDomStub();
  try {
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
  } finally {
    stub.uninstall();
  }
});

test("collection: empty items renders the empty state", () => {
  const stub = installDomStub();
  try {
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
  } finally {
    stub.uninstall();
  }
});

test("collection: vertical orientation is reflected in wrapper class", () => {
  const stub = installDomStub();
  try {
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
  } finally {
    stub.uninstall();
  }
});

test("collection: horizontal orientation is reflected in wrapper class", () => {
  const stub = installDomStub();
  try {
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
  } finally {
    stub.uninstall();
  }
});

test("collection: key-value items render as 'key: value'", () => {
  const stub = installDomStub();
  try {
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
  } finally {
    stub.uninstall();
  }
});

test("collection: bare value items render just the value", () => {
  const stub = installDomStub();
  try {
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
  } finally {
    stub.uninstall();
  }
});

test("collection: label shows item count", () => {
  const stub = installDomStub();
  try {
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
  } finally {
    stub.uninstall();
  }
});

test("collection: caption is rendered if present", () => {
  const stub = installDomStub();
  try {
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
  } finally {
    stub.uninstall();
  }
});
