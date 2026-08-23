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

import { Player } from "../shared/engine.js";

function fakeClock() {
  let callback = null;
  return {
    schedule: (fn) => {
      callback = fn;
      return 1;
    },
    cancel: () => {
      callback = null;
    },
    tick: () => callback && callback(),
    get running() {
      return callback !== null;
    },
  };
}

test("Player starts at frame 0", () => {
  const p = new Player(5);
  assert.equal(p.index, 0);
  assert.equal(p.count, 5);
  assert.equal(p.isPlaying, false);
});

test("Player.seek clamps to both ends", () => {
  const p = new Player(5);
  p.seek(99);
  assert.equal(p.index, 4);
  p.seek(-3);
  assert.equal(p.index, 0);
});

test("Player.next stops at the last frame, prev stops at 0", () => {
  const p = new Player(3);
  p.next(); p.next(); p.next(); p.next();
  assert.equal(p.index, 2);
  assert.equal(p.atEnd, true);
  p.prev(); p.prev(); p.prev();
  assert.equal(p.index, 0);
});

test("Player.play advances one frame per tick", () => {
  const clock = fakeClock();
  const p = new Player(5, { schedule: clock.schedule, cancel: clock.cancel });
  p.play();
  assert.equal(p.isPlaying, true);
  clock.tick();
  clock.tick();
  assert.equal(p.index, 2);
});

test("Player.play auto-pauses at the end", () => {
  const clock = fakeClock();
  const p = new Player(3, { schedule: clock.schedule, cancel: clock.cancel });
  p.play();
  clock.tick(); clock.tick(); clock.tick();
  assert.equal(p.index, 2);
  assert.equal(p.isPlaying, false);
  assert.equal(clock.running, false);
});

test("Player.onChange fires on every index change", () => {
  const seen = [];
  const p = new Player(4, { onChange: (i) => seen.push(i) });
  p.next();
  p.next();
  p.first();
  assert.deepEqual(seen, [1, 2, 0]);
});

test("Player.reset stops playback and returns to 0", () => {
  const clock = fakeClock();
  const p = new Player(4, { schedule: clock.schedule, cancel: clock.cancel });
  p.play();
  clock.tick();
  p.reset();
  assert.equal(p.index, 0);
  assert.equal(p.isPlaying, false);
});

test("Player handles an empty frame list without throwing", () => {
  const p = new Player(0);
  p.next();
  p.seek(3);
  assert.equal(p.index, 0);
});

// The browser's setInterval/clearInterval are WebIDL operations on the global:
// invoking them with any receiver other than the global object throws
// "TypeError: Illegal invocation". This clock models that brand check, so the
// node suite catches a call that would only fail in a real browser.
function brandCheckedClock() {
  let callback = null;
  function schedule(fn) {
    if (this !== undefined && this !== globalThis) throw new TypeError("Illegal invocation");
    callback = fn;
    return 1;
  }
  function cancel() {
    if (this !== undefined && this !== globalThis) throw new TypeError("Illegal invocation");
    callback = null;
  }
  return { schedule, cancel, tick: () => callback && callback(), get running() { return callback !== null; } };
}

test("Player.play invokes the scheduler without an object receiver", () => {
  const clock = brandCheckedClock();
  const p = new Player(5, { schedule: clock.schedule, cancel: clock.cancel });
  p.play();
  assert.equal(p.isPlaying, true);
  assert.equal(clock.running, true);
});

test("Player.pause invokes the canceller without an object receiver", () => {
  const clock = brandCheckedClock();
  const p = new Player(5, { schedule: clock.schedule, cancel: clock.cancel });
  p.play();
  p.pause();
  assert.equal(p.isPlaying, false);
  assert.equal(clock.running, false);
});
