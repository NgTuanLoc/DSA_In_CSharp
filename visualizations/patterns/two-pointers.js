const CODE = {
  init: 0,
  loop: 1,
  compare: 2,
  advance: 3,
  done: 4,
};

function arrayView(chars, L, R, colors = {}) {
  return { kind: "array", cells: chars, pointers: { L, R }, colors };
}

export default {
  title: "Two Pointers",
  slug: "two-pointers",
  folder: "ArrayAndString",
  complexity: { time: "O(n)", space: "O(1)" },
  whenToUse:
    "The input is sorted, or the answer depends on comparing the two ends of a sequence and working inward.",
  problems: [
    "125. Valid Palindrome",
    "167. Two Sum II — Input Array Is Sorted",
    "392. Is Subsequence",
    "344. Reverse String",
  ],
  pseudocode: [
    "L = 0, R = n - 1",
    "while L < R:",
    "  if s[L] != s[R]: return false",
    "  L += 1, R -= 1",
    "return true",
  ],
  inputs: [
    { label: "racecar (palindrome)", data: "racecar", expect: true },
    { label: "hello (not a palindrome)", data: "hello", expect: false },
    { label: "abba (even length)", data: "abba", expect: true },
  ],
  run(s, emit) {
    const chars = [...s];
    let L = 0;
    let R = chars.length - 1;

    emit({
      line: CODE.init,
      note: `place L at 0 and R at ${R}`,
      view: arrayView(chars, L, R),
    });

    while (L < R) {
      emit({
        line: CODE.compare,
        note: `compare '${chars[L]}' with '${chars[R]}'`,
        view: arrayView(chars, L, R, { [L]: "active", [R]: "active" }),
      });

      if (chars[L] !== chars[R]) {
        emit({
          line: CODE.compare,
          note: `'${chars[L]}' != '${chars[R]}' — not a palindrome`,
          view: arrayView(chars, L, R, { [L]: "fail", [R]: "fail" }),
        });
        return false;
      }

      L += 1;
      R -= 1;
      emit({
        line: CODE.advance,
        note: `characters match — move both pointers inward to L=${L}, R=${R}`,
        view: arrayView(chars, L, R),
      });
    }

    emit({
      line: CODE.done,
      note: "pointers met or crossed — every pair matched",
      view: arrayView(chars, L, R, Object.fromEntries(chars.map((_, i) => [i, "pass"]))),
    });
    return true;
  },
};
