import { specs } from "./patterns/registry.js";
import { runAllChecks, formatText } from "./shared/selftest.js";

if (specs.length === 0) {
  console.log("No pattern specs registered yet.");
  process.exit(0);
}

const rows = runAllChecks(specs);
console.log(formatText(rows));
process.exit(rows.every((row) => row.pass) ? 0 : 1);
