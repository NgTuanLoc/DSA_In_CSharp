function view(nums, left, right, best, sum) {
  return {
    kind: "array",
    cells: [...nums],
    pointers: { left, right },
    window: { start: left, end: right },
    caption: `sum = ${sum}, best = ${best}`,
  };
}

export default {
  title: "Sliding Window",
  slug: "sliding-window",
  folder: "ArrayAndString",
  complexity: { time: "O(n)", space: "O(1)" },
  whenToUse:
    "You need the best contiguous subarray under a constraint, and growing the window can only break the constraint while shrinking it can only restore it.",
  problems: [
    "209. Minimum Size Subarray Sum",
    "3. Longest Substring Without Repeating Characters",
    "643. Maximum Average Subarray I",
    "1004. Max Consecutive Ones III",
  ],
  pseudocode: [
    "left = 0, sum = 0, best = 0",
    "for right from 0 to n-1:",
    "  sum += nums[right]",
    "  while sum > k:",
    "    sum -= nums[left]; left += 1",
    "  best = max(best, right - left + 1)",
    "return best",
  ],
  inputs: [
    {
      label: "[3,1,2,7,4,2,1,1,5], k=8",
      data: { nums: [3, 1, 2, 7, 4, 2, 1, 1, 5], k: 8 },
      expect: 4,
    },
    { label: "[1,1,1,1], k=2", data: { nums: [1, 1, 1, 1], k: 2 }, expect: 2 },
    { label: "[9], k=3 (nothing fits)", data: { nums: [9], k: 3 }, expect: 0 },
  ],
  run(data, emit) {
    const { nums, k } = data;
    const n = nums.length;
    let left = 0;
    let sum = 0;
    let best = 0;

    emit({
      line: 0,
      note: `place left at 0 and start with sum = 0, best = 0`,
      view: view(nums, left, -1, best, sum),
    });

    for (let right = 0; right < n; right++) {
      sum += nums[right];
      emit({
        line: 2,
        note: `add nums[${right}] = ${nums[right]} to the running sum`,
        view: view(nums, left, right, best, sum),
      });

      while (sum > k) {
        sum -= nums[left];
        left += 1;
        emit({
          line: 4,
          note: `sum exceeds k = ${k} — shrink from the left; left moves to ${left}`,
          view: view(nums, left, right, best, sum),
        });
      }

      best = Math.max(best, right - left + 1);
      emit({
        line: 5,
        note: `window [${left}, ${right}] has length ${right - left + 1} — best = ${best}`,
        view: view(nums, left, right, best, sum),
      });
    }

    emit({
      line: 6,
      note: `return best = ${best}`,
      view: view(nums, left, n - 1, best, sum),
    });

    return best;
  },
};
