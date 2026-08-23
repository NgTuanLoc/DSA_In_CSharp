function views(nums, i, running, total, counts, highlightKey) {
  const items = [...counts.entries()].map(([key, value]) => ({ key, value }));

  let highlight = [];
  if (highlightKey !== undefined) {
    const idx = items.findIndex((item) => item.key === highlightKey);
    if (idx !== -1) highlight = [idx];
  }

  return {
    view: {
      kind: "array",
      cells: [...nums],
      pointers: i === undefined ? {} : { i },
      caption: `running = ${running}, total = ${total}`,
    },
    view2: {
      kind: "collection",
      label: "prefix counts",
      items,
      orientation: "horizontal",
      highlight,
    },
  };
}

export default {
  title: "Counting",
  slug: "counting",
  folder: "Hashing",
  complexity: { time: "O(n)", space: "O(n)" },
  whenToUse:
    "You need how many times something occurred, and a hash map of running counts turns a nested scan into one pass.",
  problems: [
    "560. Subarray Sum Equals K",
    "1248. Count Number of Nice Subarrays",
    "1. Two Sum",
    "2248. Intersection of Multiple Arrays",
  ],
  pseudocode: [
    "counts = {0: 1}, running = 0, total = 0",
    "for each num in nums:",
    "  running += num",
    "  total += counts.get(running - k, 0)",
    "  counts[running] += 1",
    "return total",
  ],
  inputs: [
    {
      label: "[1,2,1,2,1], k=3",
      data: { nums: [1, 2, 1, 2, 1], k: 3 },
      expect: 4,
    },
    {
      label: "[1,1,1], k=2",
      data: { nums: [1, 1, 1], k: 2 },
      expect: 2,
    },
    {
      label: "[1,2,3], k=7 (none)",
      data: { nums: [1, 2, 3], k: 7 },
      expect: 0,
    },
  ],
  run(data, emit) {
    const { nums, k } = data;
    const counts = new Map([[0, 1]]);
    let running = 0;
    let total = 0;

    emit({
      line: 0,
      note: "start with counts = {0: 1}, running = 0, total = 0",
      ...views(nums, undefined, running, total, counts),
    });

    for (let i = 0; i < nums.length; i += 1) {
      running += nums[i];
      emit({
        line: 2,
        note: `running += nums[${i}] (${nums[i]}) → running = ${running}`,
        ...views(nums, i, running, total, counts),
      });

      const need = running - k;
      const found = counts.get(need) ?? 0;
      total += found;
      emit({
        line: 3,
        note:
          found > 0
            ? `running - k = ${need} was seen ${found} time(s) — total += ${found} → total = ${total}`
            : `running - k = ${need} has not been seen — total stays ${total}`,
        ...views(nums, i, running, total, counts, need),
      });

      counts.set(running, (counts.get(running) ?? 0) + 1);
      emit({
        line: 4,
        note: `counts[${running}] becomes ${counts.get(running)}`,
        ...views(nums, i, running, total, counts, running),
      });
    }

    emit({
      line: 5,
      note: `return total = ${total}`,
      ...views(nums, nums.length - 1, running, total, counts),
    });

    return total;
  },
};
