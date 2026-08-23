const PAIRS = { ")": "(", "]": "[", "}": "{" };

function views(chars, i, stack, colors = {}) {
  return {
    view: { kind: "array", cells: chars, pointers: { i }, colors },
    view2: {
      kind: "collection",
      label: "stack",
      items: stack.map((value) => ({ value })),
      orientation: "vertical",
      highlight: stack.length > 0 ? [stack.length - 1] : [],
    },
  };
}

export default {
  title: "Stacks",
  slug: "stacks",
  folder: "StackAndQueue",
  complexity: { time: "O(n)", space: "O(n)" },
  whenToUse:
    "The most recent unmatched item is the one you need next — nesting, undo, or matching pairs.",
  problems: [
    "20. Valid Parentheses",
    "1047. Remove All Adjacent Duplicates In String",
    "71. Simplify Path",
    "155. Min Stack",
  ],
  pseudocode: [
    "stack = []",
    "for ch in s:",
    "  if ch is an opener: push ch",
    "  else if stack is empty or top != match(ch): return false",
    "  else: pop",
    "return stack is empty",
  ],
  inputs: [
    { label: "({[]}) — balanced", data: "({[]})", expect: true },
    { label: "(] — mismatched", data: "(]", expect: false },
    { label: "((( — never closed", data: "(((", expect: false },
  ],
  run(s, emit) {
    const chars = [...s];
    const stack = [];

    emit({ line: 0, note: "start with an empty stack", ...views(chars, -1, stack) });

    for (let i = 0; i < chars.length; i += 1) {
      const ch = chars[i];

      if (!(ch in PAIRS)) {
        stack.push(ch);
        emit({
          line: 2,
          note: `'${ch}' is an opener — push it`,
          ...views(chars, i, stack, { [i]: "active" }),
        });
        continue;
      }

      if (stack.length === 0 || stack.at(-1) !== PAIRS[ch]) {
        emit({
          line: 3,
          note:
            stack.length === 0
              ? `'${ch}' closes nothing — the stack is empty`
              : `'${ch}' does not match the top of the stack ('${stack.at(-1)}')`,
          ...views(chars, i, stack, { [i]: "fail" }),
        });
        return false;
      }

      stack.pop();
      emit({
        line: 4,
        note: `'${ch}' matches — pop it off`,
        ...views(chars, i, stack, { [i]: "pass" }),
      });
    }

    const balanced = stack.length === 0;
    emit({
      line: 5,
      note: balanced
        ? "every opener was closed — the stack is empty"
        : `${stack.length} opener(s) were never closed`,
      ...views(chars, chars.length - 1, stack),
    });
    return balanced;
  },
};
