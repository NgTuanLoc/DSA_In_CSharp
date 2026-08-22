import { test } from "node:test";
import assert from "node:assert/strict";
import { collectFrames, validateFrames, MAX_FRAMES } from "../shared/engine.js";

const okView = { kind: "array", cells: [1, 2], pointers: {} };

const fixture = {
  title: "Fixture",
  pseudocode: ["line zero", "line one"],
  run(data, emit) {
    emit({ line: 0, note: "start", view: okView });
    emit({ line: 1, note: "end", view: okView });
    return data * 2;
  },
};

test("collectFrames returns every emitted frame and the result", () => {
  const { frames, result } = collectFrames(fixture, 21);
  assert.equal(frames.length, 2);
  assert.equal(result, 42);
  assert.equal(frames[0].note, "start");
});

test("collectFrames throws past the frame cap instead of hanging", () => {
  const runaway = {
    title: "Runaway",
    pseudocode: ["loop"],
    run(_data, emit) {
      for (;;) emit({ line: 0, note: "spin", view: okView });
    },
  };
  assert.throws(() => collectFrames(runaway, null), /frame cap exceeded/);
});

test("MAX_FRAMES is 2000", () => {
  assert.equal(MAX_FRAMES, 2000);
});

test("validateFrames accepts a well-formed run", () => {
  const { frames } = collectFrames(fixture, 1);
  assert.deepEqual(validateFrames(fixture, frames), []);
});

test("validateFrames rejects an empty run", () => {
  assert.deepEqual(validateFrames(fixture, []), ["no frames emitted"]);
});

test("validateFrames catches a line out of range", () => {
  const problems = validateFrames(fixture, [{ line: 9, note: "x", view: okView }]);
  assert.equal(problems.length, 1);
  assert.match(problems[0], /line 9 out of range 0\.\.1/);
});

test("validateFrames catches a blank note and an unknown kind", () => {
  const problems = validateFrames(fixture, [
    { line: 0, note: "   ", view: okView },
    { line: 0, note: "ok", view: { kind: "hologram" } },
    { line: 0, note: "ok", view: okView, view2: { kind: "hologram" } },
  ]);
  assert.equal(problems.length, 3);
  assert.match(problems[0], /note must be a non-empty string/);
  assert.match(problems[1], /unknown view kind/);
  assert.match(problems[2], /unknown view2 kind/);
});
