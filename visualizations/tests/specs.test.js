import { test } from "node:test";
import assert from "node:assert/strict";
import { specs } from "../patterns/registry.js";
import { runAllChecks } from "../shared/selftest.js";
import { collectFrames } from "../shared/engine.js";
import dp1d from "../patterns/dp-1d.js";

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

test("1D Dynamic Programming: emitted grid frames are snapshots, not aliases of the live dp array", () => {
  const { frames } = collectFrames(dp1d, [2, 7, 9, 3, 1]);

  const midFrame = frames.find((f) => f.note === "dp[2] = 11");
  assert.ok(midFrame, "expected a frame emitted right after dp[2] is assigned");
  assert.deepEqual(midFrame.view2.rows[0], [2, 7, 11, "·", "·"]);

  const finalFrame = frames.at(-1);
  assert.deepEqual(finalFrame.view2.rows[0], [2, 7, 11, 11, 12]);

  // If the renderer's grid view aliased the live `dp` array instead of copying it,
  // the mid-loop frame captured above would show the final filled row too.
  assert.notDeepEqual(midFrame.view2.rows[0], finalFrame.view2.rows[0]);
});
