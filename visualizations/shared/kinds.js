// The six renderer names. Lives in its own module so the DOM-free half
// (engine, selftest, specs) can validate a view kind without importing
// any renderer code.
export const RENDERER_KINDS = ["array", "collection", "linkedList", "tree", "graph", "grid"];

export function isKnownKind(kind) {
  return RENDERER_KINDS.includes(kind);
}
