function views(nums, i, seen, colors = {}) {
  return {
    view: {
      kind: "array",
      cells: [...nums],
      pointers: i === undefined ? {} : { i },
      colors: { ...colors },
    },
    view2: {
      kind: "collection",
      label: "seen (value → index)",
      items: [...seen.entries()].map(([key, value]) => ({ key, value })),
    },
  };
}

export default {
  title: "Checking for Existence",
  slug: "check-existence",
  folder: "Hashing",
  complexity: { time: "O(n)", space: "O(n)" },
  whenToUse:
    "You keep asking whether a value you have already seen exists — a set or map answers in O(1) what a rescan answers in O(n).",
  problems: [
    "1. Two Sum",
    "217. Contains Duplicate",
    "219. Contains Duplicate II",
    "2225. Find Players With Zero or One Losses",
  ],
  pseudocode: [
    "seen = {}",
    "for i from 0 to n-1:",
    "  need = target - nums[i]",
    "  if need in seen: return [seen[need], i]",
    "  seen[nums[i]] = i",
    "return []",
  ],
  inputs: [
    {
      label: "[2,7,11,15], target 9",
      data: { nums: [2, 7, 11, 15], target: 9 },
      expect: [0, 1],
    },
    {
      label: "[3,2,4], target 6",
      data: { nums: [3, 2, 4], target: 6 },
      expect: [1, 2],
    },
    {
      label: "[1,2], target 99 (no pair)",
      data: { nums: [1, 2], target: 99 },
      expect: [],
    },
  ],
  run(data, emit) {
    const { nums, target } = data;
    const seen = new Map();

    emit({
      line: 0,
      note: "start with an empty seen map",
      ...views(nums, undefined, seen),
    });

    for (let i = 0; i < nums.length; i += 1) {
      const need = target - nums[i];
      emit({
        line: 2,
        note: `need = target - nums[${i}] = ${target} - ${nums[i]} = ${need}`,
        ...views(nums, i, seen, { [i]: "active" }),
      });

      if (seen.has(need)) {
        const j = seen.get(need);
        emit({
          line: 3,
          note: `need = ${need} is in seen at index ${j} — pair found`,
          ...views(nums, i, seen, { [j]: "pass", [i]: "pass" }),
        });
        return [j, i];
      }

      emit({
        line: 3,
        note: `need = ${need} has not been seen — keep scanning`,
        ...views(nums, i, seen, { [i]: "active" }),
      });

      seen.set(nums[i], i);
      emit({
        line: 4,
        note: `seen[${nums[i]}] = ${i}`,
        ...views(nums, i, seen, { [i]: "active" }),
      });
    }

    emit({
      line: 5,
      note: "no pair sums to target — return []",
      ...views(nums, nums.length - 1, seen),
    });

    return [];
  },
};
