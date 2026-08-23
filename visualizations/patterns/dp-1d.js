const UNFILLED = "·"; // ·

function dpRow(dp, n) {
  return Array.from({ length: n }, (_, i) => (dp[i] === undefined ? UNFILLED : dp[i]));
}

function views(nums, dp, i) {
  const n = nums.length;
  const colors = {};
  if (i - 1 >= 0) colors[i - 1] = "dim";
  if (i - 2 >= 0) colors[i - 2] = "dim";

  return {
    view: {
      kind: "array",
      cells: [...nums],
      pointers: { i },
      colors,
    },
    view2: {
      kind: "grid",
      rows: [dpRow(dp, n)],
      current: { r: 0, c: i },
      rowLabels: ["dp"],
      colLabels: Array.from({ length: n }, (_, idx) => idx),
    },
  };
}

export default {
  title: "1D Dynamic Programming",
  slug: "dp-1d",
  folder: "DynamicProgramming",
  complexity: { time: "O(n)", space: "O(n)" },
  whenToUse:
    "Each state depends on a fixed number of earlier states, so you can fill a table left to right instead of re-exploring the same subproblems.",
  problems: [
    "198. House Robber",
    "70. Climbing Stairs",
    "746. Min Cost Climbing Stairs",
    "1137. N-th Tribonacci Number",
  ],
  pseudocode: [
    "dp = new array of length n",
    "dp[0] = nums[0]",
    "dp[1] = max(nums[0], nums[1])",
    "for i from 2 to n-1:",
    "  dp[i] = max(dp[i-1], dp[i-2] + nums[i])",
    "return dp[n-1]",
  ],
  inputs: [
    { label: "[2,7,9,3,1]", data: [2, 7, 9, 3, 1], expect: 12 },
    { label: "[1,2,3,1]", data: [1, 2, 3, 1], expect: 4 },
    { label: "[5] (single house)", data: [5], expect: 5 },
  ],
  run(nums, emit) {
    const n = nums.length;
    const dp = new Array(n);

    dp[0] = nums[0];
    emit({
      line: 1,
      note: "the first house is the only option so far",
      ...views(nums, dp, 0),
    });

    if (n === 1) {
      emit({
        line: 5,
        note: `the answer is dp[0] = ${dp[0]}`,
        ...views(nums, dp, 0),
      });
      return dp[0];
    }

    dp[1] = Math.max(nums[0], nums[1]);
    emit({
      line: 2,
      note: "take whichever of the first two houses is worth more",
      ...views(nums, dp, 1),
    });

    for (let i = 2; i < n; i++) {
      emit({
        line: 4,
        note: `compare skipping house ${i} (dp[${i - 1}]) against robbing it (dp[${i - 2}] + nums[${i}])`,
        ...views(nums, dp, i),
      });

      dp[i] = Math.max(dp[i - 1], dp[i - 2] + nums[i]);
      emit({
        line: 4,
        note: `dp[${i}] = ${dp[i]}`,
        ...views(nums, dp, i),
      });
    }

    emit({
      line: 5,
      note: `the answer is dp[${n - 1}] = ${dp[n - 1]}`,
      ...views(nums, dp, n - 1),
    });
    return dp[n - 1];
  },
};
