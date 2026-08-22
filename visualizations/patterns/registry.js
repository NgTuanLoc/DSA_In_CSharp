// Every pattern spec is imported here. index.html, tests.html and
// tests/specs.test.js all read this one list.
import twoPointers from "./two-pointers.js";
import stacks from "./stacks.js";
import fastSlowPointers from "./fast-slow-pointers.js";
import treeBfs from "./tree-bfs.js";
import graphBfs from "./graph-bfs.js";
import dp1d from "./dp-1d.js";

export const specs = [twoPointers, stacks, fastSlowPointers, treeBfs, graphBfs, dp1d];
