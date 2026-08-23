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

export default {
  title: "Tree DFS",
  slug: "tree-dfs",
  folder: "TreesAndGraphs",
  complexity: { time: "O(n)", space: "O(h)" },
  whenToUse:
    "The answer at a node is built from the answers of its subtrees — depth, path sums, or comparisons between two trees.",
  problems: [
    "104. Maximum Depth of Binary Tree",
    "112. Path Sum",
    "100. Same Tree",
    "543. Diameter of Binary Tree",
  ],
  pseudocode: [
    "function depth(node):",
    "  if node is null: return 0",
    "  left = depth(node.left)",
    "  right = depth(node.right)",
    "  return 1 + max(left, right)",
  ],
  inputs: [
    { label: "[3,9,20,null,null,15,7]", data: SAMPLE, expect: 3 },
    { label: "single node", data: SINGLE, expect: 1 },
  ],
  run(tree, emit) {
    const byId = index(tree);
    const edges = edgesOf(tree);
    const baseNodes = tree.nodes.map(({ id, value, x, y }) => ({ id, value, x, y }));
    const visited = [];
    const labels = {};
    const stack = [];

    function views(current) {
      const view = {
        kind: "tree",
        nodes: baseNodes.map((n) => ({ ...n })),
        edges: edges.map((e) => [...e]),
        visited: [...visited],
        labels: { ...labels },
      };
      if (current !== null && current !== undefined) view.current = current;

      return {
        view,
        view2: {
          kind: "collection",
          label: "call stack",
          items: stack.map((id) => ({ value: byId[id].value })),
          orientation: "vertical",
        },
      };
    }

    function depth(nodeId) {
      if (nodeId === null) {
        emit({
          line: 1,
          note: "empty child — depth 0",
          ...views(null),
        });
        return 0;
      }

      const node = byId[nodeId];
      stack.push(nodeId);

      emit({
        line: 2,
        note: `descend into ${node.value}'s left child`,
        ...views(nodeId),
      });
      const left = depth(node.left);

      emit({
        line: 3,
        note: `descend into ${node.value}'s right child`,
        ...views(nodeId),
      });
      const right = depth(node.right);

      const d = 1 + Math.max(left, right);
      visited.push(nodeId);
      labels[nodeId] = d;
      stack.pop();

      emit({
        line: 4,
        note: `depth(${node.value}) = ${d}`,
        ...views(nodeId),
      });
      return d;
    }

    const rootId = tree.nodes.length > 0 ? tree.nodes[0].id : null;
    return depth(rootId);
  },
};
