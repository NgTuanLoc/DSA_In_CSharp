import { renderArray } from "./renderers/array.js";
import { renderCollection } from "./renderers/collection.js";
import { renderLinkedList } from "./renderers/linkedList.js";
import { renderTree } from "./renderers/tree.js";

// Each renderer task adds one import above and one entry here.
const RENDERERS = {
  array: renderArray,
  collection: renderCollection,
  linkedList: renderLinkedList,
  tree: renderTree,
};

export function errorBanner(message) {
  const banner = document.createElement("div");
  banner.className = "viz-error";
  banner.textContent = message;
  return banner;
}

/** Repaints `el` from scratch for the given view. Never throws. */
export function paint(view, el) {
  el.replaceChildren();
  const renderer = RENDERERS[view?.kind];
  if (!renderer) {
    el.append(errorBanner(`unknown view kind: ${JSON.stringify(view?.kind)}`));
    return;
  }
  try {
    renderer(view, el);
  } catch (err) {
    el.replaceChildren(errorBanner(`renderer "${view.kind}" failed: ${err.message}`));
  }
}
