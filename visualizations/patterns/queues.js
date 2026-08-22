function views(queue, counts, { highlight = [], pingIndex } = {}) {
  return {
    view: {
      kind: "collection",
      label: "queue",
      items: queue.map((t) => ({ value: t })),
      orientation: "horizontal",
      highlight: [...highlight],
    },
    view2: {
      kind: "array",
      cells: [...counts],
      pointers: pingIndex === undefined ? {} : { ping: pingIndex },
    },
  };
}

export default {
  title: "Queues",
  slug: "queues",
  folder: "StackAndQueue",
  complexity: { time: "O(1) amortized per call", space: "O(n)" },
  whenToUse:
    "Work must be handled oldest-first, or a sliding time window means old entries expire from the front while new ones arrive at the back.",
  problems: [
    "933. Number of Recent Calls",
    "346. Moving Average from Data Stream",
    "622. Design Circular Queue",
    "239. Sliding Window Maximum",
  ],
  pseudocode: [
    "queue = []",
    "for each ping t:",
    "  queue.push_back(t)",
    "  while queue.front < t - 3000:",
    "    queue.pop_front()",
    "  record queue.length",
    "return the recorded counts",
  ],
  inputs: [
    {
      label: "pings 1, 100, 3001, 3002",
      data: [1, 100, 3001, 3002],
      expect: [1, 2, 3, 3],
    },
    {
      label: "pings 1, 5000",
      data: [1, 5000],
      expect: [1, 1],
    },
  ],
  run(pings, emit) {
    const queue = [];
    const counts = [];

    emit({
      line: 0,
      note: "start with an empty queue",
      ...views(queue, counts),
    });

    for (let i = 0; i < pings.length; i += 1) {
      const t = pings[i];

      queue.push(t);
      emit({
        line: 2,
        note: `ping at t=${t} arrives — push it to the back of the queue`,
        ...views(queue, counts, { highlight: [queue.length - 1] }),
      });

      while (queue[0] < t - 3000) {
        const expired = queue[0];
        emit({
          line: 4,
          note: `t=${expired} falls outside the window (< ${t} - 3000) — pop it from the front`,
          ...views(queue, counts, { highlight: [0] }),
        });
        queue.shift();
      }

      counts.push(queue.length);
      emit({
        line: 5,
        note: `record queue.length = ${queue.length} (pings within the last 3000ms of t=${t})`,
        ...views(queue, counts, { pingIndex: i }),
      });
    }

    emit({
      line: 6,
      note: `return the recorded counts = [${counts.join(", ")}]`,
      ...views(queue, counts, { pingIndex: pings.length - 1 }),
    });

    return counts;
  },
};
