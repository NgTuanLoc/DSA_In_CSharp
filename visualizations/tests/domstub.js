// A minimal, hand-rolled DOM stub used only by tests/page.test.js and
// tests/renderers.test.js to exercise shared/page.js's boot() and the
// renderers under plain Node (no browser, no dependency).
// It implements only the small surface page.js/render.js/renderers/*.js
// actually touch: element creation (including namespaced SVG elements via
// createElementNS), className/classList, textContent, dataset,
// setAttribute/getAttribute/removeAttribute, append/prepend/replaceChildren,
// disabled/hidden flags, and event registration + manual firing. Nothing
// here is loaded by a browser.

class FakeClassList {
  constructor() {
    this._set = new Set();
  }
  add(...names) {
    for (const name of names) this._set.add(name);
  }
  remove(...names) {
    for (const name of names) this._set.delete(name);
  }
  toggle(name, force) {
    const has = this._set.has(name);
    const next = force === undefined ? !has : Boolean(force);
    next ? this._set.add(name) : this._set.delete(name);
    return next;
  }
  contains(name) {
    return this._set.has(name);
  }
  toString() {
    return [...this._set].join(" ");
  }
}

class FakeNode {
  constructor(tag) {
    this.tagName = String(tag).toUpperCase();
    this.children = [];
    this.classList = new FakeClassList();
    this._text = "";
    this._listeners = new Map();
    this.disabled = false;
    this.hidden = false;
    this.dataset = {};
    this.namespaceURI = null;
    this._attrs = new Map();
  }
  // Minimal generic attribute storage — needed by the SVG renderer (cx, cy,
  // r, x1/y1/x2/y2, viewBox, text-anchor, ...). Does not model any real
  // attribute semantics (no reflected properties, no validation).
  setAttribute(name, value) {
    this._attrs.set(name, String(value));
  }
  getAttribute(name) {
    return this._attrs.has(name) ? this._attrs.get(name) : null;
  }
  removeAttribute(name) {
    this._attrs.delete(name);
  }
  get className() {
    return this.classList.toString();
  }
  set className(value) {
    this.classList = new FakeClassList();
    if (value) this.classList.add(...String(value).split(/\s+/).filter(Boolean));
  }
  get textContent() {
    return this._text;
  }
  set textContent(value) {
    this._text = value;
    this.children = [];
  }
  append(...nodes) {
    this.children.push(...nodes);
  }
  prepend(...nodes) {
    this.children = [...nodes, ...this.children];
  }
  replaceChildren(...nodes) {
    this.children = [...nodes];
    this._text = "";
  }
  addEventListener(type, handler) {
    if (!this._listeners.has(type)) this._listeners.set(type, []);
    this._listeners.get(type).push(handler);
  }
  removeEventListener(type, handler) {
    const list = this._listeners.get(type);
    if (!list) return;
    const i = list.indexOf(handler);
    if (i >= 0) list.splice(i, 1);
  }
  /** Test-only helper: synchronously invokes every handler registered for `type`. */
  fire(type, event) {
    const list = this._listeners.get(type) ?? [];
    for (const handler of [...list]) handler(event);
  }
  /** Selector support: only a leading-class selector (e.g., ".viz-collection__item"); anything else returns []. */
  querySelectorAll(selector) {
    const results = [];
    const walk = (node) => {
      // Handle class selectors like ".class-name"
      if (selector.startsWith(".")) {
        const className = selector.slice(1);
        if (node.classList?.contains(className)) results.push(node);
      }
      for (const child of node.children ?? []) walk(child);
    };
    walk(this);
    return results;
  }
}

class FakeSelectElement extends FakeNode {
  // Mirrors real <select>.value: the value of whichever <option> child has
  // .selected === true, falling back to the first option (matching browser
  // behavior). buildControls()/buildInputPicker() in page.js only ever set
  // .selected on the option, never .value on the select itself, so without
  // this the select's value is undefined and Number(undefined) is NaN.
  get value() {
    const selected = this.children.find((child) => child.selected);
    if (selected) return selected.value;
    return this.children[0]?.value ?? "";
  }
  set value(next) {
    for (const child of this.children) child.selected = child.value === String(next);
  }
}
class FakeInputElement extends FakeNode {}

/**
 * Installs a fresh fake `document` (plus `HTMLSelectElement`/`HTMLInputElement`
 * for the `instanceof` checks in page.js's keydown handler) on `globalThis`.
 * Returns the fake document and an `uninstall()` to restore whatever was
 * there before — call it in a `finally` so one test's stub never leaks into
 * another.
 */
export function installDomStub() {
  const previous = {
    document: globalThis.document,
    HTMLSelectElement: globalThis.HTMLSelectElement,
    HTMLInputElement: globalThis.HTMLInputElement,
  };

  const fakeDocument = new FakeNode("document");
  fakeDocument.createElement = (tag) => {
    if (tag === "select") return new FakeSelectElement(tag);
    if (tag === "input") return new FakeInputElement(tag);
    return new FakeNode(tag);
  };
  // Records the namespace on the node (e.g. for the SVG renderer's
  // createElementNS(SVG_NS, tag) calls) — no other SVG semantics modeled.
  fakeDocument.createElementNS = (ns, tag) => {
    const node = new FakeNode(tag);
    node.namespaceURI = ns;
    return node;
  };

  globalThis.document = fakeDocument;
  globalThis.HTMLSelectElement = FakeSelectElement;
  globalThis.HTMLInputElement = FakeInputElement;

  return {
    document: fakeDocument,
    uninstall() {
      globalThis.document = previous.document;
      globalThis.HTMLSelectElement = previous.HTMLSelectElement;
      globalThis.HTMLInputElement = previous.HTMLInputElement;
    },
  };
}
