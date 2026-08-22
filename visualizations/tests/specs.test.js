import { test } from "node:test";
import assert from "node:assert/strict";
import { specs } from "../patterns/registry.js";
import { runAllChecks } from "../shared/selftest.js";

test("registry exports at least one spec", () => {
  assert.ok(specs.length > 0, "patterns/registry.js exports no specs");
});

test("every spec declares the required fields", () => {
  for (const spec of specs) {
    assert.equal(typeof spec.title, "string", "title");
    assert.equal(typeof spec.folder, "string", `${spec.title}: folder`);
    assert.equal(typeof spec.complexity?.time, "string", `${spec.title}: complexity.time`);
    assert.equal(typeof spec.complexity?.space, "string", `${spec.title}: complexity.space`);
    assert.equal(typeof spec.whenToUse, "string", `${spec.title}: whenToUse`);
    assert.ok(Array.isArray(spec.problems) && spec.problems.length > 0, `${spec.title}: problems`);
    assert.ok(Array.isArray(spec.pseudocode) && spec.pseudocode.length > 0, `${spec.title}: pseudocode`);
    assert.ok(Array.isArray(spec.inputs) && spec.inputs.length > 0, `${spec.title}: inputs`);
    assert.equal(typeof spec.run, "function", `${spec.title}: run`);
  }
});

test("spec titles are unique", () => {
  const titles = specs.map((s) => s.title);
  assert.equal(new Set(titles).size, titles.length);
});

for (const row of runAllChecks(specs)) {
  test(`${row.pattern} — ${row.input}`, () => {
    assert.deepEqual(row.problems, [], row.problems.join("; "));
  });
}
