import { collectFrames, validateFrames } from "./engine.js";

export function deepEqual(a, b) {
  if (a === b) return true;
  if (typeof a !== typeof b) return false;
  if (a === null || b === null) return false;
  if (typeof a !== "object") return Number.isNaN(a) && Number.isNaN(b);
  if (Array.isArray(a) !== Array.isArray(b)) return false;
  const keysA = Object.keys(a);
  const keysB = Object.keys(b);
  if (keysA.length !== keysB.length) return false;
  return keysA.every((k) => Object.hasOwn(b, k) && deepEqual(a[k], b[k]));
}

/** Runs every preset input of one spec and reports a row per input. */
export function checkSpec(spec) {
  return spec.inputs.map((input) => {
    const row = {
      pattern: spec.title,
      input: input.label,
      expected: input.expect,
      actual: undefined,
      frames: 0,
      problems: [],
      pass: false,
    };

    try {
      const { frames, result } = collectFrames(spec, input.data);
      row.actual = result;
      row.frames = frames.length;
      row.problems.push(...validateFrames(spec, frames));
      if (!deepEqual(result, input.expect)) {
        row.problems.push(
          `expected ${JSON.stringify(input.expect)}, got ${JSON.stringify(result)}`,
        );
      }
    } catch (err) {
      row.problems.push(`threw: ${err.message}`);
    }

    row.pass = row.problems.length === 0;
    return row;
  });
}

export function runAllChecks(specs) {
  return specs.flatMap((spec) => checkSpec(spec));
}

export function formatText(rows) {
  const lines = rows.map((row) => {
    const status = row.pass ? "PASS" : "FAIL";
    const detail = row.pass
      ? `${row.frames} frames`
      : row.problems.join("; ");
    return `  ${status}  ${row.pattern} — ${row.input}  (${detail})`;
  });
  const passed = rows.filter((r) => r.pass).length;
  const failed = rows.length - passed;
  lines.push("", `  ${passed} passed, ${failed} failed, ${rows.length} total`);
  return lines.join("\n");
}
