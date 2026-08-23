function views(temps, i, stack, colors = {}) {
  return {
    view: { kind: "array", cells: [...temps], pointers: { i }, colors },
    view2: {
      kind: "collection",
      label: "stack (indices)",
      items: stack.map((idx) => ({ key: idx, value: temps[idx] })),
      orientation: "vertical",
      highlight: stack.length > 0 ? [stack.length - 1] : [],
    },
  };
}

export default {
  title: "Monotonic Stack",
  slug: "monotonic-stack",
  folder: "StackAndQueue",
  complexity: { time: "O(n)", space: "O(n)" },
  whenToUse:
    "You need the next (or previous) element greater or smaller than each entry, and a plain stack kept in sorted order gives it in one pass.",
  problems: [
    "739. Daily Temperatures",
    "496. Next Greater Element I",
    "84. Largest Rectangle in Histogram",
    "901. Online Stock Span",
  ],
  pseudocode: [
    "answer = array of zeros, stack = []",
    "for i from 0 to n-1:",
    "  while stack and temps[stack.top] < temps[i]:",
    "    j = stack.pop(); answer[j] = i - j",
    "  stack.push(i)",
    "return answer",
  ],
  inputs: [
    {
      label: "[73,74,75,71,69,72,76,73]",
      data: [73, 74, 75, 71, 69, 72, 76, 73],
      expect: [1, 1, 4, 2, 1, 1, 0, 0],
    },
    {
      label: "[30,40,50,60] (rising)",
      data: [30, 40, 50, 60],
      expect: [1, 1, 1, 0],
    },
    {
      label: "[60,50,40] (falling)",
      data: [60, 50, 40],
      expect: [0, 0, 0],
    },
  ],
  run(temps, emit) {
    const n = temps.length;
    const answer = new Array(n).fill(0);
    const stack = [];

    emit({
      line: 0,
      note: "start with answer all zeros and an empty stack",
      ...views(temps, -1, stack),
    });

    for (let i = 0; i < n; i++) {
      while (stack.length > 0 && temps[stack.at(-1)] < temps[i]) {
        const top = stack.at(-1);
        emit({
          line: 2,
          note: `temps[${top}] = ${temps[top]} < temps[${i}] = ${temps[i]} — resolve the top of the stack`,
          ...views(temps, i, stack, { [top]: "active", [i]: "active" }),
        });

        const j = stack.pop();
        answer[j] = i - j;
        emit({
          line: 3,
          note: `answer[${j}] = ${i} - ${j} = ${answer[j]}`,
          ...views(temps, i, stack, { [j]: "pass", [i]: "active" }),
        });
      }

      stack.push(i);
      emit({
        line: 4,
        note: `push index ${i} (temps[${i}] = ${temps[i]})`,
        ...views(temps, i, stack, { [i]: "active" }),
      });
    }

    emit({
      line: 5,
      note: `return answer = [${answer.join(", ")}]`,
      ...views(temps, n - 1, stack),
    });

    return answer;
  },
};
