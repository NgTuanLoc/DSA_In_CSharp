import { test } from "node:test";
import assert from "node:assert/strict";
import { boot } from "../shared/page.js";
import { Player } from "../shared/engine.js";
import { installDomStub } from "./domstub.mjs";

// Covers the review finding on shared/page.js: `player` starts out `null`
// and is only assigned once `load()` succeeds. Before the fix, a spec whose
// very first load() failed left every control wired to a null `player`, so
// the keydown handler and the five transport buttons threw instead of
// no-op'ing, and a later load() failure never stopped an in-flight
// setInterval. These tests exercise the real boot() (not a re-implementation
// of it) against a hand-rolled DOM stub — see domstub.mjs — since page.js
// needs `document` and none is available under plain Node.

function findByClass(node, className) {
  const found = [];
  const walk = (n) => {
    if (n.classList?.contains(className)) found.push(n);
    for (const child of n.children ?? []) walk(child);
  };
  walk(node);
  return found;
}

function brokenSpec() {
  return {
    title: "Broken Spec (test double)",
    folder: "Test",
    complexity: { time: "O(1)", space: "O(1)" },
    whenToUse: "exercises the guard when the very first load() fails",
    problems: ["test problem"],
    pseudocode: ["line 0"],
    inputs: [{ label: "boom", data: null, expect: null }],
    run() {
      throw new Error("boom");
    },
  };
}

test("boot(): a spec that throws on the first load reaches the disabled error state instead of throwing", () => {
  const stub = installDomStub();
  try {
    const root = stub.document.createElement("main");
    boot(brokenSpec(), root); // pre-fix this already worked; this is the baseline.

    const buttons = findByClass(root, "controls__btn");
    assert.equal(buttons.length, 5, "expected all five transport buttons");
    for (const button of buttons) assert.equal(button.disabled, true);

    const [scrub] = findByClass(root, "controls__scrub");
    assert.equal(scrub.disabled, true);

    const [note] = findByClass(root, "note");
    assert.ok(note.classList.contains("viz-error"));
    assert.equal(note.textContent, "boom");
  } finally {
    stub.uninstall();
  }
});

test("boot(): keydown after a failed first load does not throw, because player is still null", () => {
  const stub = installDomStub();
  try {
    const root = stub.document.createElement("main");
    boot(brokenSpec(), root);

    // Not a select/input, so the handler's focus check falls through to the
    // player-null guard this fix adds. Before the fix this line threw
    // "Cannot read properties of null (reading 'toggle')".
    const target = stub.document.createElement("body");
    stub.document.fire("keydown", { target, key: " ", preventDefault() {} });

    const [note] = findByClass(root, "note");
    assert.equal(note.textContent, "boom", "the error state must be untouched by the no-op keydown");
  } finally {
    stub.uninstall();
  }
});

test("boot(): clicking a transport button after a failed first load does not throw, even while disabled", () => {
  const stub = installDomStub();
  try {
    const root = stub.document.createElement("main");
    boot(brokenSpec(), root);

    const [firstButton] = findByClass(root, "controls__btn");
    assert.equal(firstButton.disabled, true);
    // Fires the handler directly rather than relying on `disabled` to stop
    // it — the review explicitly calls out that the guard must not depend
    // solely on the disabled attribute. Before the fix this threw
    // "Cannot read properties of null (reading 'first')".
    firstButton.fire("click", {});
  } finally {
    stub.uninstall();
  }
});

test("boot(): showError() pauses an already-playing player instead of leaving its timer running", () => {
  const stub = installDomStub();
  let pauseCalls = 0;
  const originalPause = Player.prototype.pause;
  Player.prototype.pause = function (...args) {
    pauseCalls += 1;
    return originalPause.apply(this, args);
  };

  try {
    const spec = {
      title: "Two-Frame Spec (test double)",
      folder: "Test",
      complexity: { time: "O(1)", space: "O(1)" },
      whenToUse: "exercises showError pausing a running player",
      problems: ["test problem"],
      pseudocode: ["line 0"],
      inputs: [
        { label: "ok", data: "ok", expect: true },
        { label: "boom", data: null, expect: null },
      ],
      run(data, emit) {
        if (data === null) throw new Error("boom");
        emit({ line: 0, note: "frame one", view: { kind: "array", cells: ["a"], pointers: {}, colors: {} } });
        emit({ line: 0, note: "frame two", view: { kind: "array", cells: ["a"], pointers: {}, colors: {} } });
        return true;
      },
    };

    const root = stub.document.createElement("main");
    boot(spec, root);

    const [, , toggleButton] = findByClass(root, "controls__btn"); // first, prev, toggle, next, last
    toggleButton.fire("click", {});
    assert.equal(toggleButton.textContent, "❚❚ Pause", "playback should have started");
    assert.equal(pauseCalls, 0, "starting playback must not itself pause");

    const [picker] = findByClass(root, "inputs__select");
    picker.value = "1";
    picker.fire("change", {}); // switches to the input whose run() throws

    assert.equal(pauseCalls, 1, "showError must pause the running player exactly once");

    const [note] = findByClass(root, "note");
    assert.equal(note.textContent, "boom");
  } finally {
    Player.prototype.pause = originalPause;
    stub.uninstall();
  }
});
