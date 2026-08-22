const NODES = [
  { id: 0, label: "0", x: 0.15, y: 0.25 },
  { id: 1, label: "1", x: 0.45, y: 0.1 },
  { id: 2, label: "2", x: 0.45, y: 0.45 },
  { id: 3, label: "3", x: 0.75, y: 0.7 },
  { id: 4, label: "4", x: 0.95, y: 0.9 },
  { id: 5, label: "5", x: 0.15, y: 0.85 },
];

const EDGES = [[0, 1], [1, 2], [2, 0], [3, 4]];

function adjacency(edges) {
  const adj = {};
  for (const [a, b] of edges) {
    (adj[a] ??= []).push(b);
    (adj[b] ??= []).push(a);
  }
  return adj;
}

// Note: no `distances` field — DFS gives no distance guarantee, so it is
// deliberately omitted (graph.js reads `view.distances ?? {}`).
function views(current, visited, stack, activeEdge) {
  return {
    view: {
      kind: "graph",
      nodes: NODES,
      edges: EDGES,
      current,
      visited: [...visited],
      activeEdge,
    },
    view2: {
      kind: "collection",
      label: "stack",
      items: stack.map((id) => ({ value: id })),
      orientation: "vertical",
      highlight: stack.length > 0 ? [stack.length - 1] : [],
    },
  };
}

export default {
  title: "Graph DFS",
  slug: "graph-dfs",
  folder: "TreesAndGraphs",
  complexity: { time: "O(V + E)", space: "O(V)" },
  whenToUse:
    "You need to know whether something is reachable, or to explore each connected region fully — where you go deep matters more than how far.",
  problems: [
    "1971. Find if Path Exists in Graph",
    "547. Number of Provinces",
    "200. Number of Islands",
    "841. Keys and Rooms",
  ],
  pseudocode: [
    "stack = [source], seen = {source}",
    "while stack is not empty:",
    "  node = stack.pop()",
    "  if node == destination: return true",
    "  for neighbor of node:",
    "    if neighbor not in seen:",
    "      seen.add(neighbor); stack.push(neighbor)",
    "return false",
  ],
  inputs: [
    { label: "0 → 2 (same component)", data: { source: 0, destination: 2 }, expect: true },
    { label: "0 → 5 (isolated node)", data: { source: 0, destination: 5 }, expect: false },
    { label: "3 → 4 (other component)", data: { source: 3, destination: 4 }, expect: true },
  ],
  run({ source, destination }, emit) {
    const adj = adjacency(EDGES);
    const seen = new Set([source]);
    const stack = [source];
    const visited = [];

    emit({
      line: 0,
      note: `seed the stack with node ${source}`,
      ...views(null, visited, stack, null),
    });

    while (stack.length > 0) {
      const node = stack.pop();
      visited.push(node);
      emit({
        line: 2,
        note: `pop node ${node} from the stack`,
        ...views(node, visited, stack, null),
      });

      if (node === destination) {
        emit({
          line: 3,
          note: `node ${node} is the destination — reachable`,
          ...views(node, visited, stack, null),
        });
        return true;
      }

      for (const neighbor of adj[node] ?? []) {
        if (seen.has(neighbor)) {
          emit({
            line: 5,
            note: `neighbor ${neighbor} was already seen — skip it`,
            ...views(node, visited, stack, [node, neighbor]),
          });
          continue;
        }
        seen.add(neighbor);
        stack.push(neighbor);
        emit({
          line: 6,
          note: `discover node ${neighbor} — push it onto the stack`,
          ...views(node, visited, stack, [node, neighbor]),
        });
      }
    }

    emit({
      line: 7,
      note: `the stack drained without reaching node ${destination} — unreachable`,
      ...views(null, visited, stack, null),
    });
    return false;
  },
};
