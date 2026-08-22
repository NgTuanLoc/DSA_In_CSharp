import { test } from "node:test";
import assert from "node:assert/strict";
import { deepEqual, checkSpec, runAllChecks, formatText } from "../shared/selftest.js";
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

const okView = { kind: "array", cells: [1], pointers: {} };

const goodSpec = {
  title: "Doubler",
  pseudocode: ["double it"],
  inputs: [
    { label: "two", data: 2, expect: 4 },
    { label: "three", data: 3, expect: 6 },
  ],
  run(data, emit) {
    emit({ line: 0, note: "doubling", view: okView });
    return data * 2;
  },
};

const wrongSpec = {
  title: "Broken",
  pseudocode: ["double it"],
  inputs: [{ label: "two", data: 2, expect: 4 }],
  run(data, emit) {
    emit({ line: 0, note: "doubling", view: okView });
    return data * 3;
  },
};

const throwingSpec = {
  title: "Thrower",
  pseudocode: ["boom"],
  inputs: [{ label: "any", data: 1, expect: 1 }],
  run() {
    throw new Error("kaboom");
  },
};

test("checkSpec passes a correct spec and reports frame counts", () => {
  const rows = checkSpec(goodSpec);
  assert.equal(rows.length, 2);
  assert.equal(rows[0].pass, true);
  assert.equal(rows[0].frames, 1);
  assert.equal(rows[0].pattern, "Doubler");
  assert.equal(rows[0].input, "two");
});

test("checkSpec fails a spec whose result differs from expect", () => {
  const [row] = checkSpec(wrongSpec);
  assert.equal(row.pass, false);
  assert.match(row.problems[0], /expected 4, got 6/);
});

test("checkSpec turns a thrown error into a failing row", () => {
  const [row] = checkSpec(throwingSpec);
  assert.equal(row.pass, false);
  assert.match(row.problems[0], /threw: kaboom/);
});

test("runAllChecks flattens rows across specs", () => {
  assert.equal(runAllChecks([goodSpec, wrongSpec]).length, 3);
});

test("formatText reports a summary line", () => {
  const text = formatText(runAllChecks([goodSpec, wrongSpec]));
  assert.match(text, /Doubler/);
  assert.match(text, /2 passed/);
  assert.match(text, /1 failed/);
});
