function numsView(nums, i) {
  return { kind: "array", cells: [...nums], pointers: { i } };
}

function tableView(P, opts = {}) {
  const view = { kind: "array", cells: [...P], colors: { ...(opts.colors ?? {}) } };
  if (opts.caption) view.caption = opts.caption;
  return view;
}

export default {
  title: "Prefix Sum",
  slug: "prefix-sum",
  folder: "ArrayAndString",
  complexity: { time: "O(n) build, O(1) per query", space: "O(n)" },
  whenToUse:
    "Many range-sum questions over an array that never changes — pay O(n) once so every query is O(1).",
  problems: [
    "303. Range Sum Query - Immutable",
    "1480. Running Sum of 1d Array",
    "2270. Number of Ways to Split Array",
    "560. Subarray Sum Equals K",
  ],
  pseudocode: [
    "P[0] = 0",
    "for i from 0 to n-1:",
    "  P[i+1] = P[i] + nums[i]",
    "for each query (lo, hi):",
    "  answer = P[hi+1] - P[lo]",
    "return answers",
  ],
  inputs: [
    {
      label: "[3,-1,4,1,5,-9,2], queries [1,3] [0,6] [4,6]",
      data: { nums: [3, -1, 4, 1, 5, -9, 2], queries: [[1, 3], [0, 6], [4, 6]] },
      expect: [4, 5, -2],
    },
    {
      label: "[1,2,3], query [0,2]",
      data: { nums: [1, 2, 3], queries: [[0, 2]] },
      expect: [6],
    },
  ],
  run(data, emit) {
    const { nums, queries } = data;
    const n = nums.length;
    const P = [0];
    let i = -1;

    emit({
      line: 0,
      note: "seed the table: P[0] = 0",
      view: numsView(nums, i),
      view2: tableView(P),
    });

    for (i = 0; i < n; i++) {
      P.push(P[i] + nums[i]);
      emit({
        line: 2,
        note: `P[${i + 1}] = P[${i}] + nums[${i}] = ${P[i]} + ${nums[i]} = ${P[i + 1]}`,
        view: numsView(nums, i),
        view2: tableView(P),
      });
    }

    const answers = [];

    for (const [lo, hi] of queries) {
      emit({
        line: 3,
        note: `query (lo=${lo}, hi=${hi}): need P[${hi + 1}] - P[${lo}]`,
        view: numsView(nums, i),
        view2: tableView(P, {
          colors: { [lo]: "active", [hi + 1]: "active" },
          caption: `P[${hi + 1}] - P[${lo}]`,
        }),
      });

      const answer = P[hi + 1] - P[lo];
      answers.push(answer);
      emit({
        line: 4,
        note: `P[${hi + 1}] - P[${lo}] = ${P[hi + 1]} - ${P[lo]} = ${answer}`,
        view: numsView(nums, i),
        view2: tableView(P, {
          colors: { [lo]: "pass", [hi + 1]: "pass" },
          caption: `P[${hi + 1}] - P[${lo}] = ${P[hi + 1]} - ${P[lo]} = ${answer}`,
        }),
      });
    }

    emit({
      line: 5,
      note: `return answers = [${answers.join(", ")}]`,
      view: numsView(nums, i),
      view2: tableView(P),
    });

    return answers;
  },
};
