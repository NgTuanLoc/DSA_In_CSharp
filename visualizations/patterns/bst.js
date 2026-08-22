const TREE = {
  nodes: [
    { id: "a", value: 8, x: 0.5, y: 0.1, left: "b", right: "c" },
    { id: "b", value: 3, x: 0.25, y: 0.5, left: "d", right: "e" },
    { id: "c", value: 10, x: 0.75, y: 0.5, left: null, right: "f" },
    { id: "d", value: 1, x: 0.12, y: 0.9, left: null, right: null },
    { id: "e", value: 6, x: 0.38, y: 0.9, left: null, right: null },
    { id: "f", value: 14, x: 0.9, y: 0.9, left: null, right: null },
  ],
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

function subtreeIds(byId, rootId) {
  if (rootId === null || rootId === undefined) return [];
  const node = byId[rootId];
  return [rootId, ...subtreeIds(byId, node.left), ...subtreeIds(byId, node.right)];
}

export default {
  title: "Binary Search Tree",
  slug: "bst",
  folder: "TreesAndGraphs",
  complexity: { time: "O(h) — O(log n) balanced, O(n) worst case", space: "O(1)" },
  whenToUse:
    "The tree's ordering invariant — everything left is smaller, everything right is larger — lets one comparison discard an entire subtree.",
  problems: [
    "700. Search in a Binary Search Tree",
    "98. Validate Binary Search Tree",
    "701. Insert into a Binary Search Tree",
    "230. Kth Smallest Element in a BST",
  ],
  pseudocode: [
    "node = root",
    "while node is not null:",
    "  if node.value == target: return true",
    "  if target < node.value: node = node.left",
    "  else: node = node.right",
    "return false",
  ],
  inputs: [
    { label: "search for 6 (present)", data: { tree: TREE, target: 6 }, expect: true },
    { label: "search for 7 (absent)", data: { tree: TREE, target: 7 }, expect: false },
    { label: "search for 8 (the root)", data: { tree: TREE, target: 8 }, expect: true },
  ],
  run(data, emit) {
    const { tree, target } = data;
    const byId = index(tree);
    const edges = edgesOf(tree);
    const baseNodes = tree.nodes.map(({ id, value, x, y }) => ({ id, value, x, y }));
    const visited = [];
    const frontier = [];

    function views(current) {
      const view = {
        kind: "tree",
        nodes: baseNodes.map((n) => ({ ...n })),
        edges: edges.map((e) => [...e]),
        visited: [...visited],
        frontier: [...frontier],
      };
      if (current !== null && current !== undefined) view.current = current;
      return { view };
    }

    let nodeId = tree.nodes.length > 0 ? tree.nodes[0].id : null;

    emit({
      line: 0,
      note: `start at the root (${byId[nodeId].value})`,
      ...views(nodeId),
    });

    while (nodeId !== null) {
      const node = byId[nodeId];
      visited.push(nodeId);

      if (node.value === target) {
        emit({
          line: 2,
          note: `node.value (${node.value}) == target (${target}) — found it`,
          ...views(nodeId),
        });
        return true;
      }

      emit({
        line: 2,
        note: `${node.value} != ${target} — check which side to go`,
        ...views(nodeId),
      });

      if (target < node.value) {
        frontier.push(...subtreeIds(byId, node.right));
        emit({
          line: 3,
          note: `target < ${node.value}, so everything right of ${node.value} is out`,
          ...views(nodeId),
        });
        nodeId = node.left;
      } else {
        frontier.push(...subtreeIds(byId, node.left));
        emit({
          line: 4,
          note: `target > ${node.value}, so everything left of ${node.value} is out`,
          ...views(nodeId),
        });
        nodeId = node.right;
      }
    }

    emit({
      line: 5,
      note: `walked off the tree — target ${target} is not present`,
      ...views(null),
    });
    return false;
  },
};
