function buildList({ values, cycleTo }) {
  const nodes = values.map((value, i) => ({ id: `n${i}`, value }));
  const next = {};
  values.forEach((_, i) => {
    next[`n${i}`] = i < values.length - 1 ? `n${i + 1}` : cycleTo === null ? null : `n${cycleTo}`;
  });
  return { nodes, next };
}

function view(list, slow, fast, colors = {}) {
  return {
    kind: "linkedList",
    nodes: list.nodes,
    next: list.next,
    pointers: { slow, fast },
    colors,
  };
}

export default {
  title: "Fast and Slow Pointers",
  slug: "fast-slow-pointers",
  folder: "LinkedList",
  complexity: { time: "O(n)", space: "O(1)" },
  whenToUse:
    "You need a position defined relative to the list's length — its middle, its cycle, or the nth node from the end — in one pass and constant space.",
  problems: [
    "141. Linked List Cycle",
    "142. Linked List Cycle II",
    "876. Middle of the Linked List",
    "19. Remove Nth Node From End of List",
  ],
  pseudocode: [
    "slow = head, fast = head",
    "while fast and fast.next:",
    "  slow = slow.next",
    "  fast = fast.next.next",
    "  if slow == fast: return true",
    "return false",
  ],
  inputs: [
    { label: "3 → 2 → 0 → -4 → (back to index 1)", data: { values: [3, 2, 0, -4], cycleTo: 1 }, expect: true },
    { label: "1 → 2 (no cycle)", data: { values: [1, 2], cycleTo: null }, expect: false },
    { label: "1 → (back to itself)", data: { values: [1], cycleTo: 0 }, expect: true },
  ],
  run(data, emit) {
    const list = buildList(data);
    let slow = list.nodes[0]?.id ?? null;
    let fast = slow;

    emit({ line: 0, note: "both pointers start at the head", view: view(list, slow, fast) });

    while (fast !== null && list.next[fast] !== null && list.next[fast] !== undefined) {
      slow = list.next[slow];
      emit({ line: 2, note: `slow advances one step to ${slow}`, view: view(list, slow, fast) });

      fast = list.next[list.next[fast]];
      emit({ line: 3, note: `fast advances two steps to ${fast}`, view: view(list, slow, fast) });

      if (slow === fast) {
        emit({
          line: 4,
          note: `slow and fast met at ${slow} — the list has a cycle`,
          view: view(list, slow, fast, { [slow]: "pass" }),
        });
        return true;
      }
      emit({ line: 4, note: "pointers have not met yet — keep going", view: view(list, slow, fast) });
    }

    emit({
      line: 5,
      note: "fast ran off the end — no cycle",
      view: view(list, slow, fast),
    });
    return false;
  },
};
