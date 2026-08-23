import { test } from "node:test";
import assert from "node:assert/strict";
import { boot } from "../shared/page.js";
import { Player } from "../shared/engine.js";
import { installDomStub } from "./domstub.js";

// Covers the review finding on shared/page.js: `player` starts out `null`
// and is only assigned once `load()` succeeds. Before the fix, a spec whose
// very first load() failed left every control wired to a null `player`, so
// the keydown handler and the five transport buttons threw instead of
// no-op'ing, and a later load() failure never stopped an in-flight
// setInterval. These tests exercise the real boot() (not a re-implementation
// of it) against a hand-rolled DOM stub — see domstub.js — since page.js
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

test("boot(): moving the scrub input after a failed first load does not throw, even while disabled", () => {
  const stub = installDomStub();
  try {
    const root = stub.document.createElement("main");
    boot(brokenSpec(), root);

    const [scrub] = findByClass(root, "controls__scrub");
    assert.equal(scrub.disabled, true);
    scrub.value = "0";
    // Fires the handler directly rather than relying on `disabled` to stop
    // it, same as the transport-button case above. Before this round's fix
    // this threw "Cannot read properties of null (reading 'seek')".
    scrub.fire("input", {});

    const [note] = findByClass(root, "note");
    assert.equal(note.textContent, "boom", "the error state must be untouched by the no-op input event");
  } finally {
    stub.uninstall();
  }
});

test("boot(): changing the speed select after a failed first load does not throw, even while disabled", () => {
  const stub = installDomStub();
  try {
    const root = stub.document.createElement("main");
    boot(brokenSpec(), root);

    const [speed] = findByClass(root, "controls__speed");
    // Unlike the transport buttons and scrub, showError() does not disable
    // the speed select (pre-existing, out of scope here) — so this handler
    // has no "second line of defence" at all; the guard is the only thing
    // standing between this event and a null-player crash. Before this
    // round's fix this threw "Cannot read properties of null (reading
    // 'setSpeed')".
    speed.fire("change", {});

    const [note] = findByClass(root, "note");
    assert.equal(note.textContent, "boom", "the error state must be untouched by the no-op change event");
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

function lineSyncSpec() {
  return {
    title: "Line Sync Spec (test double)",
    folder: "Test",
    complexity: { time: "O(1)", space: "O(1)" },
    whenToUse: "exercises the happy-path line-highlight sync, counter, and secondary-view visibility",
    problems: ["test problem"],
    pseudocode: ["line zero", "line one", "line two"],
    inputs: [{ label: "only", data: "x", expect: true }],
    run(data, emit) {
      emit({
        line: 0,
        note: "frame one — no view2",
        view: { kind: "array", cells: ["a"], pointers: {}, colors: {} },
      });
      emit({
        line: 2,
        note: "frame two — has view2",
        view: { kind: "array", cells: ["a"], pointers: {}, colors: {} },
        view2: { kind: "array", cells: ["b"], pointers: {}, colors: {} },
      });
      emit({
        line: 1,
        note: "frame three — no view2 again",
        view: { kind: "array", cells: ["a"], pointers: {}, colors: {} },
      });
      return true;
    },
  };
}

test("boot(): showFrame marks exactly the active frame's pseudocode line active, updates the counter, and toggles the secondary view", () => {
  const stub = installDomStub();
  try {
    const root = stub.document.createElement("main");
    boot(lineSyncSpec(), root);

    const codeLines = findByClass(root, "code__line");
    assert.equal(codeLines.length, 3, "expected one <li> per pseudocode line");

    const [, , , nextButton] = findByClass(root, "controls__btn"); // first, prev, toggle, next, last
    const [counter] = findByClass(root, "controls__counter");
    const [viz2] = findByClass(root, "stage__viz--secondary");

    // Frame 0: line 0 active, no other line active; view2 absent -> hidden.
    assert.deepEqual(
      codeLines.map((l) => l.classList.contains("is-active")),
      [true, false, false],
    );
    assert.equal(counter.textContent, "1 / 3");
    assert.equal(viz2.hidden, true, "view2 must be hidden when frame.view2 is absent");

    // Advance to frame 1: line 2 active, and ONLY line 2; view2 present -> shown.
    nextButton.fire("click", {});
    assert.deepEqual(
      codeLines.map((l) => l.classList.contains("is-active")),
      [false, false, true],
    );
    assert.equal(counter.textContent, "2 / 3");
    assert.equal(viz2.hidden, false, "view2 must be shown when frame.view2 is present");

    // Advance to frame 2: line 1 active, and ONLY line 1; view2 absent again -> hidden again.
    nextButton.fire("click", {});
    assert.deepEqual(
      codeLines.map((l) => l.classList.contains("is-active")),
      [false, true, false],
    );
    assert.equal(counter.textContent, "3 / 3");
    assert.equal(viz2.hidden, true, "view2 must go back to hidden once frame.view2 is absent again");
  } finally {
    stub.uninstall();
  }
});
