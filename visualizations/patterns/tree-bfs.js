const SAMPLE = {
  nodes: [
    { id: "a", value: 3, x: 0.5, y: 0.1, left: "b", right: "c" },
    { id: "b", value: 9, x: 0.25, y: 0.5, left: null, right: null },
    { id: "c", value: 20, x: 0.75, y: 0.5, left: "d", right: "e" },
    { id: "d", value: 15, x: 0.6, y: 0.9, left: null, right: null },
    { id: "e", value: 7, x: 0.9, y: 0.9, left: null, right: null },
  ],
};

const SINGLE = {
  nodes: [{ id: "a", value: 1, x: 0.5, y: 0.5, left: null, right: null }],
};

function index(tree) {
  return Object.fromEntries(tree.nodes.map((n) => [n.id, n]));
}

function edgesOf(tree) {
  const edges = [];
  for (const node of tree.nodes) {
    if (node.left) edges.push([node.id, node.left]);
    if (node.right) edges.push([node.id, node.right]);
  }
  return edges;
}

function views(tree, current, visited, queue, byId) {
  return {
    view: {
      kind: "tree",
      nodes: tree.nodes.map(({ id, value, x, y }) => ({ id, value, x, y })),
      edges: edgesOf(tree),
      current,
      visited: [...visited],
      frontier: [...queue],
    },
    view2: {
      kind: "collection",
      label: "queue",
      items: queue.map((id) => ({ value: byId[id].value })),
      orientation: "horizontal",
      highlight: queue.length > 0 ? [0] : [],
    },
  };
}

export default {
  title: "Tree BFS",
  slug: "tree-bfs",
  folder: "TreesAndGraphs",
  complexity: { time: "O(n)", space: "O(n)" },
  whenToUse:
    "The answer depends on depth — level order, the view from one side, or the shallowest node satisfying a condition.",
  problems: [
    "102. Binary Tree Level Order Traversal",
    "199. Binary Tree Right Side View",
    "515. Find Largest Value in Each Tree Row",
    "103. Binary Tree Zigzag Level Order Traversal",
  ],
  pseudocode: [
    "queue = [root], levels = []",
    "while queue is not empty:",
    "  level = []",
    "  for each node currently in queue:",
    "    pop it, append its value to level",
    "    push its children onto queue",
    "  levels.append(level)",
    "return levels",
  ],
  inputs: [
    { label: "[3,9,20,null,null,15,7]", data: SAMPLE, expect: [[3], [9, 20], [15, 7]] },
    { label: "single node", data: SINGLE, expect: [[1]] },
  ],
  run(tree, emit) {
    const byId = index(tree);
    const levels = [];
    const visited = [];
    let queue = tree.nodes.length > 0 ? [tree.nodes[0].id] : [];

    emit({
      line: 0,
      note: "seed the queue with the root",
      ...views(tree, null, visited, queue, byId),
    });

    while (queue.length > 0) {
      const width = queue.length;
      const level = [];
      emit({
        line: 3,
        note: `this level holds ${width} node(s)`,
        ...views(tree, null, visited, queue, byId),
      });

      for (let i = 0; i < width; i += 1) {
        const id = queue.shift();
        const node = byId[id];
        level.push(node.value);
        visited.push(id);
        emit({
          line: 4,
          note: `visit ${node.value} — add it to the current level`,
          ...views(tree, id, visited, queue, byId),
        });

        for (const child of [node.left, node.right]) {
          if (child) {
            queue.push(child);
            emit({
              line: 5,
              note: `enqueue child ${byId[child].value}`,
              ...views(tree, id, visited, queue, byId),
            });
          }
        }
      }

      levels.push(level);
      emit({
        line: 6,
        note: `level complete: [${level.join(", ")}]`,
        ...views(tree, null, visited, queue, byId),
      });
    }

    emit({
      line: 7,
      note: `all levels collected: ${JSON.stringify(levels)}`,
      ...views(tree, null, visited, queue, byId),
    });
    return levels;
  },
};
