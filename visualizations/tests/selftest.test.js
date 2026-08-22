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
