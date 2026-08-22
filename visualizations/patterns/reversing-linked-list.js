function buildList(values) {
  const nodes = values.map((value, i) => ({ id: `n${i}`, value }));
  const next = {};
  values.forEach((_, i) => {
    next[`n${i}`] = i < values.length - 1 ? `n${i + 1}` : null;
  });
  return { nodes, next };
}

function valueOf(nodes, id) {
  if (id === null || id === undefined) return "null";
  return String(nodes.find((n) => n.id === id)?.value ?? id);
}

// `next` is the live, mutating map the algorithm itself rewires — each call
// here copies it (and `colors`) into the emitted frame so later mutations
// never retroactively change a frame already handed to the player.
function view(nodes, next, prev, curr, nextPtr, colors) {
  return {
    kind: "linkedList",
    nodes,
    next: { ...next },
    pointers: { prev, curr, next: nextPtr },
    colors: { ...colors },
  };
}

export default {
  title: "Reversing a Linked List",
  slug: "reversing-linked-list",
  folder: "LinkedList",
  complexity: { time: "O(n)", space: "O(1)" },
  whenToUse:
    "You need the list pointing the other way without allocating a second list — three pointers rewire it in place as they walk.",
  problems: [
    "206. Reverse Linked List",
    "92. Reverse Linked List II",
    "24. Swap Nodes in Pairs",
    "25. Reverse Nodes in k-Group",
  ],
  pseudocode: [
    "prev = null, curr = head",
    "while curr is not null:",
    "  nextNode = curr.next",
    "  curr.next = prev",
    "  prev = curr",
    "  curr = nextNode",
    "return prev",
  ],
  inputs: [
    { label: "1 → 2 → 3 → 4 → 5", data: [1, 2, 3, 4, 5], expect: [5, 4, 3, 2, 1] },
    { label: "single node", data: [1], expect: [1] },
    { label: "empty list", data: [], expect: [] },
  ],
  run(values, emit) {
    const { nodes, next } = buildList(values);
    const colors = {};
    let prev = null;
    let curr = nodes[0]?.id ?? null;

    emit({
      line: 0,
      note: "prev starts at null, curr starts at the head",
      view: view(nodes, next, prev, curr, null, colors),
    });

    while (curr !== null) {
      const nextNode = next[curr];
      emit({
        line: 2,
        note: `save curr.next — nextNode = ${valueOf(nodes, nextNode)}`,
        view: view(nodes, next, prev, curr, nextNode, colors),
      });

      next[curr] = prev;
      colors[curr] = "pass";
      emit({
        line: 3,
        note: `point ${valueOf(nodes, curr)} back at ${valueOf(nodes, prev)}`,
        view: view(nodes, next, prev, curr, nextNode, colors),
      });

      prev = curr;
      curr = nextNode;
      emit({
        line: 5,
        note: `advance — curr becomes ${valueOf(nodes, curr)}`,
        view: view(nodes, next, prev, curr, nextNode, colors),
      });
    }

    emit({
      line: 6,
      note: `reversal complete — the new head is ${valueOf(nodes, prev)}`,
      view: view(nodes, next, prev, curr, null, colors),
    });

    const result = [];
    for (let id = prev; id !== null; id = next[id]) {
      result.push(nodes.find((n) => n.id === id).value);
    }
    return result;
  },
};
