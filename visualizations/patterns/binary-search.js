function view(nums, lo, mid, hi, extraColors = {}) {
  const colors = { ...extraColors };
  nums.forEach((_, idx) => {
    if (idx < lo || idx > hi) colors[idx] = "dim";
  });

  const pointers = mid === undefined ? { lo, hi } : { lo, mid, hi };

  return {
    kind: "array",
    cells: [...nums],
    pointers,
    window: { start: lo, end: hi },
    colors,
  };
}

export default {
  title: "Binary Search",
  slug: "binary-search",
  folder: "BinarySearch",
  complexity: { time: "O(log n)", space: "O(1)" },
  whenToUse:
    "The search space is sorted or monotonic, so one comparison lets you discard half of what is left.",
  problems: [
    "704. Binary Search",
    "35. Search Insert Position",
    "74. Search a 2D Matrix",
    "278. First Bad Version",
  ],
  pseudocode: [
    "lo = 0, hi = n - 1",
    "while lo <= hi:",
    "  mid = lo + (hi - lo) / 2",
    "  if nums[mid] == target: return mid",
    "  if nums[mid] < target: lo = mid + 1",
    "  else: hi = mid - 1",
    "return -1",
  ],
  inputs: [
    {
      label: "find 11 in [1,3,5,7,9,11,13]",
      data: { nums: [1, 3, 5, 7, 9, 11, 13], target: 11 },
      expect: 5,
    },
    {
      label: "find 4 (absent)",
      data: { nums: [1, 3, 5, 7, 9, 11, 13], target: 4 },
      expect: -1,
    },
    {
      label: "find 1 (first element)",
      data: { nums: [1, 3, 5, 7, 9, 11, 13], target: 1 },
      expect: 0,
    },
  ],
  run(data, emit) {
    const { nums, target } = data;
    const n = nums.length;
    let lo = 0;
    let hi = n - 1;

    emit({
      line: 0,
      note: `search between lo=0 and hi=${hi}`,
      view: view(nums, lo, undefined, hi),
    });

    while (lo <= hi) {
      const mid = lo + Math.floor((hi - lo) / 2);
      emit({
        line: 2,
        note: `mid = ${mid} → nums[${mid}] = ${nums[mid]}`,
        view: view(nums, lo, mid, hi),
      });

      if (nums[mid] === target) {
        emit({
          line: 3,
          note: `nums[${mid}] == target (${target}) — found it`,
          view: view(nums, lo, mid, hi, { [mid]: "pass" }),
        });
        return mid;
      }

      if (nums[mid] < target) {
        const discardedLo = lo;
        lo = mid + 1;
        emit({
          line: 4,
          note: `nums[${mid}] = ${nums[mid]} < target — discard the lower half [${discardedLo}, ${mid}], lo becomes ${lo}`,
          view: view(nums, lo, undefined, hi),
        });
      } else {
        const discardedHi = hi;
        hi = mid - 1;
        emit({
          line: 5,
          note: `nums[${mid}] = ${nums[mid]} > target — discard the upper half [${mid}, ${discardedHi}], hi becomes ${hi}`,
          view: view(nums, lo, undefined, hi),
        });
      }
    }

    emit({
      line: 6,
      note: `lo > hi — target ${target} is not in the array`,
      view: view(nums, lo, undefined, hi),
    });
    return -1;
  },
};
