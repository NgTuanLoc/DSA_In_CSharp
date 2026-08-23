const NODES = [
  { id: 0, label: "0", x: 0.1, y: 0.5 },
  { id: 1, label: "1", x: 0.32, y: 0.2 },
  { id: 2, label: "2", x: 0.32, y: 0.8 },
  { id: 3, label: "3", x: 0.55, y: 0.5 },
  { id: 4, label: "4", x: 0.78, y: 0.3 },
  { id: 5, label: "5", x: 0.95, y: 0.6 },
  { id: 6, label: "6", x: 0.78, y: 0.9 },
];

const EDGES = [[0, 1], [0, 2], [1, 3], [2, 3], [3, 4], [4, 5]];

function adjacency(edges) {
  const adj = {};
  for (const [a, b] of edges) {
    (adj[a] ??= []).push(b);
    (adj[b] ??= []).push(a);
  }
  return adj;
}

function views(current, visited, queue, distances, activeEdge) {
  return {
    view: {
      kind: "graph",
      nodes: NODES,
      edges: EDGES,
      current,
      visited: [...visited],
      activeEdge,
      distances: { ...distances },
    },
    view2: {
      kind: "collection",
      label: "queue",
      items: queue.map((id) => ({ value: id })),
      orientation: "horizontal",
      highlight: queue.length > 0 ? [0] : [],
    },
  };
}

export default {
  title: "Graph BFS",
  slug: "graph-bfs",
  folder: "TreesAndGraphs",
  complexity: { time: "O(V + E)", space: "O(V)" },
  whenToUse:
    "You need the fewest steps between two points in an unweighted graph or grid. BFS reaches every node in distance order, so the first time you touch the target you already hold the shortest distance.",
  problems: [
    "1091. Shortest Path in Binary Matrix",
    "542. 01 Matrix",
    "1926. Nearest Exit from Entrance in Maze",
    "909. Snakes and Ladders",
  ],
  pseudocode: [
    "queue = [(start, 0)], seen = {start}",
    "while queue is not empty:",
    "  node, dist = queue.pop_front()",
    "  if node == target: return dist",
    "  for neighbor of node:",
    "    if neighbor not in seen:",
    "      seen.add(neighbor); queue.push((neighbor, dist + 1))",
    "return -1",
  ],
  inputs: [
    { label: "0 → 5 (reachable)", data: { start: 0, target: 5 }, expect: 4 },
    { label: "0 → 6 (isolated node)", data: { start: 0, target: 6 }, expect: -1 },
  ],
  run({ start, target }, emit) {
    const adj = adjacency(EDGES);
    const seen = new Set([start]);
    const distances = { [start]: 0 };
    const queue = [start];
    const visited = [];

    emit({
      line: 0,
      note: `seed the queue with node ${start} at distance 0`,
      ...views(null, visited, queue, distances, null),
    });

    while (queue.length > 0) {
      const node = queue.shift();
      const dist = distances[node];
      visited.push(node);
      emit({
        line: 2,
        note: `dequeue node ${node} (distance ${dist})`,
        ...views(node, visited, queue, distances, null),
      });

      if (node === target) {
        emit({
          line: 3,
          note: `node ${node} is the target — shortest distance is ${dist}`,
          ...views(node, visited, queue, distances, null),
        });
        return dist;
      }

      for (const neighbor of adj[node] ?? []) {
        if (seen.has(neighbor)) {
          emit({
            line: 5,
            note: `neighbor ${neighbor} was already seen — skip it`,
            ...views(node, visited, queue, distances, [node, neighbor]),
          });
          continue;
        }
        seen.add(neighbor);
        distances[neighbor] = dist + 1;
        queue.push(neighbor);
        emit({
          line: 6,
          note: `discover node ${neighbor} at distance ${dist + 1} — enqueue it`,
          ...views(node, visited, queue, distances, [node, neighbor]),
        });
      }
    }

    emit({
      line: 7,
      note: `the queue drained without reaching node ${target} — unreachable`,
      ...views(null, visited, queue, distances, null),
    });
    return -1;
  },
};
