import { test } from "node:test";
import assert from "node:assert/strict";
import { specs } from "../patterns/registry.js";
import { runAllChecks } from "../shared/selftest.js";
import { collectFrames } from "../shared/engine.js";
import dp1d from "../patterns/dp-1d.js";
import monotonicStack from "../patterns/monotonic-stack.js";
import queues from "../patterns/queues.js";
import heapOperations from "../patterns/heap-operations.js";
import backtrackingGeneration from "../patterns/backtracking-generation.js";
import topK from "../patterns/top-k.js";

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

test("Monotonic Stack: emitted collection frames are snapshots, not aliases of the live stack array", () => {
  const { frames } = collectFrames(monotonicStack, [73, 74, 75, 71, 69, 72, 76, 73]);

  const midFrame = frames.find((f) => f.note === "answer[0] = 1 - 0 = 1");
  assert.ok(midFrame, "expected a frame emitted right after index 0 is resolved");
  assert.deepEqual(midFrame.view2.items, []);

  const finalFrame = frames.at(-1);
  assert.deepEqual(finalFrame.view2.items, [
    { key: 6, value: 76 },
    { key: 7, value: 73 },
  ]);

  // If the renderer's collection view aliased the live `stack` array instead of
  // copying it, the mid-loop frame captured above would show the final stack too.
  assert.notDeepEqual(midFrame.view2.items, finalFrame.view2.items);
});

test("Queues: emitted collection frames are snapshots, not aliases of the live queue array", () => {
  const { frames } = collectFrames(queues, [1, 100, 3001, 3002]);

  const midFrame = frames.find(
    (f) => f.note === "ping at t=3002 arrives — push it to the back of the queue",
  );
  assert.ok(midFrame, "expected a frame emitted right after t=3002 is pushed");
  assert.deepEqual(midFrame.view.items, [
    { value: 1 },
    { value: 100 },
    { value: 3001 },
    { value: 3002 },
  ]);

  const finalFrame = frames.at(-1);
  assert.deepEqual(finalFrame.view.items, [
    { value: 100 },
    { value: 3001 },
    { value: 3002 },
  ]);

  // If the renderer's collection view aliased the live `queue` array instead of
  // copying it, the mid-loop frame captured above would show the final (shrunk)
  // queue too, since the front expiry (t=1) happens later in the same tick.
  assert.notDeepEqual(midFrame.view.items, finalFrame.view.items);
});

test("Heap Operations: emitted tree/collection frames are snapshots, not aliases of the live heap array", () => {
  const { frames } = collectFrames(heapOperations, { op: "push", values: [5, 3, 8, 1] });

  // Right after pushing 1, it sifts past 5 first, landing transiently at [3,1,8,5]
  // (it has not yet sifted past 3 to reach the final [1,3,8,5]).
  const midFrame = frames.find(
    (f) => f.note === "1 < 5 — swap heap[3] and heap[1]; i becomes 1",
  );
  assert.ok(midFrame, "expected a frame emitted right after index 3 sifts past index 1");
  assert.deepEqual(midFrame.view2.items, [
    { value: 3 },
    { value: 1 },
    { value: 8 },
    { value: 5 },
  ]);
  assert.deepEqual(
    midFrame.view.nodes.map((n) => n.value),
    [3, 1, 8, 5],
  );

  const finalFrame = frames.at(-1);
  assert.deepEqual(finalFrame.view2.items, [
    { value: 1 },
    { value: 3 },
    { value: 8 },
    { value: 5 },
  ]);

  // If the renderer's views aliased the live `heap` array instead of copying it,
  // the mid-loop frame captured above would show the final heap too, since one
  // more swap (index 1 past index 0) happens later in the same push.
  assert.notDeepEqual(midFrame.view2.items, finalFrame.view2.items);
  assert.notDeepEqual(
    midFrame.view.nodes.map((n) => n.value),
    finalFrame.view.nodes.map((n) => n.value),
  );
});

test("Heap Operations: the tree view and the collection view agree at every frame, and the final frame matches the returned result", () => {
  const cases = [
    { op: "push", values: [5, 3, 8, 1] },
    { op: "pop", heap: [1, 3, 8, 5] },
  ];

  for (const data of cases) {
    const { frames, result } = collectFrames(heapOperations, data);
    frames.forEach((frame, i) => {
      // Tree nodes are id-ordered by construction (id === heap index), so reading
      // node values in id order reproduces heap-array order.
      const treeValues = [...frame.view.nodes]
        .sort((a, b) => a.id - b.id)
        .map((n) => n.value);
      const collectionValues = frame.view2.items.map((item) => item.value);
      assert.deepEqual(
        treeValues,
        collectionValues,
        `frame ${i} (${JSON.stringify(data)}): tree/collection disagree`,
      );
    });

    // The two views agreeing with each other is not enough — they could agree
    // while both are stale. Pin the last frame's heap state against what run()
    // actually returned, so a swap emitted before it happens (leaving the final
    // frame one step behind the real array) fails loudly instead of passing
    // because both views independently show the same wrong thing.
    const expectedFinalHeap = data.op === "pop" ? result.heap : result;
    const finalFrame = frames.at(-1);
    const finalTreeValues = [...finalFrame.view.nodes]
      .sort((a, b) => a.id - b.id)
      .map((n) => n.value);
    const finalCollectionValues = finalFrame.view2.items.map((item) => item.value);

    assert.deepEqual(
      finalTreeValues,
      expectedFinalHeap,
      `${JSON.stringify(data)}: final tree frame does not match run()'s returned heap`,
    );
    assert.deepEqual(
      finalCollectionValues,
      expectedFinalHeap,
      `${JSON.stringify(data)}: final collection frame does not match run()'s returned heap`,
    );
  }
});

test("Backtracking: emitted collection frames are snapshots, not aliases of the live path array", () => {
  const { frames, result } = collectFrames(backtrackingGeneration, [1, 2, 3]);

  // Right after choosing 2 (still inside backtrack(1)'s first iteration), the
  // path is [1,2] — it has not yet grown to [1,2,3], nor shrunk back to [].
  const midFrame = frames.find((f) => f.note === "choose 2 — path is now [1,2]");
  assert.ok(midFrame, "expected a frame emitted right after 2 is pushed onto the path");
  assert.deepEqual(midFrame.view2.items, [{ value: 1 }, { value: 2 }]);

  // The very last emitted frame is the final undo, back at the empty path.
  const finalFrame = frames.at(-1);
  assert.equal(finalFrame.note, "remove 3 and try the next branch");
  assert.deepEqual(finalFrame.view2.items, []);

  // If the collection view aliased the live `path` array instead of copying it,
  // the mid-loop frame captured above would show the final (emptied) path too.
  assert.notDeepEqual(midFrame.view2.items, finalFrame.view2.items);

  // Pin against run()'s own independently-computed result, per the heap-pop lesson:
  // two views agreeing with each other is not proof either one is correct.
  assert.deepEqual(result, [[], [1], [1, 2], [1, 2, 3], [1, 3], [2], [2, 3], [3]]);
});

test("Backtracking: every tree frame carries edges connecting each node to its parent, and positions are stable across frames", () => {
  for (const input of backtrackingGeneration.inputs) {
    const { frames } = collectFrames(backtrackingGeneration, input.data);
    const nodeCount = frames[0].view.nodes.length;

    frames.forEach((frame, i) => {
      assert.equal(frame.view.kind, "tree", `frame ${i}: expected a tree view`);
      assert.ok(Array.isArray(frame.view.edges), `frame ${i}: view.edges must be an array`);
      assert.equal(
        frame.view.edges.length,
        nodeCount - 1,
        `frame ${i}: a tree of ${nodeCount} nodes must have ${nodeCount - 1} edges`,
      );
      for (const edge of frame.view.edges) {
        const [parentId, childId] = edge;
        assert.ok(
          Number.isInteger(parentId) && parentId >= 0 && parentId < nodeCount,
          `frame ${i}: edge parent id ${parentId} out of range`,
        );
        assert.ok(
          Number.isInteger(childId) && childId >= 0 && childId < nodeCount,
          `frame ${i}: edge child id ${childId} out of range`,
        );
      }

      // Every current-path collection item must be a {value} object, not a raw number.
      for (const item of frame.view2.items) {
        assert.equal(typeof item, "object", `frame ${i}: collection item must be an object`);
        assert.ok("value" in item, `frame ${i}: collection item must have a "value" key`);
      }
    });

    // Node positions must be identical across every frame (assigned once, in the dry run).
    const firstPositions = frames[0].view.nodes.map(({ id, x, y }) => ({ id, x, y }));
    frames.forEach((frame, i) => {
      const positions = frame.view.nodes.map(({ id, x, y }) => ({ id, x, y }));
      assert.deepEqual(positions, firstPositions, `frame ${i}: node positions moved`);
    });
  }
});

test("Top K Elements: emitted collection frames are snapshots, not aliases of the live heap array", () => {
  const { frames, result } = collectFrames(topK, { nums: [3, 2, 1, 5, 6, 4], k: 2 });

  // Right after dropping 1 (the third push overflows the size-2 heap), the
  // heap is transiently [2,3] — not yet the final [5,6].
  const midFrame = frames.find((f) => f.note === "heap exceeded k — drop the smallest, 1");
  assert.ok(midFrame, "expected a frame emitted right after 1 is evicted");
  assert.deepEqual(midFrame.view2.items, [{ value: 2 }, { value: 3 }]);

  const finalFrame = frames.at(-1);
  assert.deepEqual(finalFrame.view2.items, [{ value: 5 }, { value: 6 }]);

  // If the collection view aliased the live `heap` array instead of copying it,
  // the mid-loop frame captured above would show the final heap too.
  assert.notDeepEqual(midFrame.view2.items, finalFrame.view2.items);

  // Pin against run()'s own independently-computed result.
  assert.equal(result, 5);
});

test("Top K Elements: every array frame's pointer is in range, and collection highlight indices are valid", () => {
  for (const input of topK.inputs) {
    const { frames } = collectFrames(topK, input.data);

    frames.forEach((frame, i) => {
      assert.equal(frame.view.kind, "array", `frame ${i}: expected an array view`);
      const pointerIndex = frame.view.pointers.i;
      assert.ok(
        Number.isInteger(pointerIndex) &&
          pointerIndex >= 0 &&
          pointerIndex < frame.view.cells.length,
        `frame ${i}: pointer i=${pointerIndex} out of range for ${frame.view.cells.length} cells`,
      );

      for (const item of frame.view2.items) {
        assert.equal(typeof item, "object", `frame ${i}: heap item must be an object`);
        assert.ok("value" in item, `frame ${i}: heap item must have a "value" key`);
      }

      for (const idx of frame.view2.highlight ?? []) {
        assert.ok(
          Number.isInteger(idx) && idx >= 0 && idx < frame.view2.items.length,
          `frame ${i}: highlight index ${idx} out of range for ${frame.view2.items.length} heap items`,
        );
      }
    });
  }
});
