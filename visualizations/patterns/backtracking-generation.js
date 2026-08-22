/**
 * Builds the full recursion tree for `backtrack(0, [])` in a dry run (no
 * emitting), so node positions and path labels are known and stable before
 * any frame is produced. Each node is one call to `backtrack`; its id is
 * assigned in call order (pre-order), which the emitting replay below
 * reproduces exactly by incrementing its own counter in lockstep.
 */
function buildRecursionTree(nums) {
  const n = nums.length;
  const nodes = [];
  const edges = [];
  let nextId = 0;

  function visit(start, path, parentId) {
    const id = nextId;
    nextId += 1;
    nodes.push({
      id,
      depth: path.length,
      value: path.length > 0 ? String(path[path.length - 1]) : "∅",
      label: `[${path.join(",")}]`,
    });
    if (parentId !== null) edges.push([parentId, id]);

    for (let i = start; i < n; i += 1) {
      path.push(nums[i]);
      visit(i + 1, path, id);
      path.pop();
    }
  }

  visit(0, [], null);

  // Positions must be stable across frames: place every node once, here,
  // using its position within its own depth's group (in creation order).
  const byDepth = {};
  for (const node of nodes) {
    (byDepth[node.depth] ??= []).push(node);
  }
  for (const depth of Object.keys(byDepth)) {
    const group = byDepth[depth];
    group.forEach((node, orderIndex) => {
      node.x = (orderIndex + 0.5) / group.length;
      node.y = (node.depth + 0.5) / (n + 1);
    });
  }

  return { nodes, edges };
}

export default {
  title: "Backtracking",
  slug: "backtracking-generation",
  folder: "Backtracking",
  complexity: { time: "O(n · 2^n) for subsets", space: "O(n) recursion depth" },
  whenToUse:
    "You must enumerate every combination, permutation, or subset — build a candidate one choice at a time and undo the choice on the way back up.",
  problems: ["78. Subsets", "46. Permutations", "77. Combinations", "39. Combination Sum"],
  pseudocode: [
    "backtrack(start, path):",
    "  record a copy of path",
    "  for i from start to n-1:",
    "    path.push(nums[i])",
    "    backtrack(i + 1, path)",
    "    path.pop()          # undo the choice",
  ],
  inputs: [
    {
      label: "subsets of [1,2,3]",
      data: [1, 2, 3],
      expect: [[], [1], [1, 2], [1, 2, 3], [1, 3], [2], [2, 3], [3]],
    },
    { label: "subsets of [1,2]", data: [1, 2], expect: [[], [1], [1, 2], [2]] },
  ],
  run(nums, emit) {
    const { nodes, edges } = buildRecursionTree(nums);
    const baseNodes = nodes.map(({ id, value, x, y }) => ({ id, value, x, y }));
    const labelsMap = Object.fromEntries(nodes.map((node) => [node.id, node.label]));

    const results = [];
    const path = [];
    const recorded = [];
    let nextId = 0;

    function views(currentId) {
      return {
        view: {
          kind: "tree",
          nodes: baseNodes.map((node) => ({ ...node })),
          edges: edges.map((edge) => [...edge]),
          current: currentId,
          visited: [...recorded],
          labels: { ...labelsMap },
        },
        view2: {
          kind: "collection",
          label: "current path",
          items: path.map((v) => ({ value: v })),
          orientation: "horizontal",
        },
      };
    }

    function backtrack(start) {
      const id = nextId;
      nextId += 1;
      recorded.push(id);
      results.push([...path]);

      emit({
        line: 1,
        note: `record [${path.join(",")}] as a subset`,
        ...views(id),
      });

      for (let i = start; i < nums.length; i += 1) {
        path.push(nums[i]);
        emit({
          line: 3,
          note: `choose ${nums[i]} — path is now [${path.join(",")}]`,
          ...views(id),
        });

        emit({
          line: 4,
          note: `descend into backtrack(${i + 1}, [${path.join(",")}])`,
          ...views(id),
        });

        backtrack(i + 1);

        const removed = path.pop();
        emit({
          line: 5,
          note: `remove ${removed} and try the next branch`,
          ...views(id),
        });
      }
    }

    backtrack(0);
    return results;
  },
};
