const SVG_NS = "http://www.w3.org/2000/svg";

function svgEl(tag) {
  return document.createElementNS(SVG_NS, tag);
}

/** Returns the single state class for a node, or null. Precedence: current > visited > frontier > pruned. */
function stateClass(id, current, visited, frontier, pruned) {
  if (current === id) return "is-current";
  if (visited.has(id)) return "is-visited";
  if (frontier.has(id)) return "is-frontier";
  if (pruned.has(id)) return "is-pruned";
  return null;
}

export function renderTree(view, el) {
  const svg = svgEl("svg");
  svg.setAttribute("viewBox", "0 0 100 100");
  svg.setAttribute("preserveAspectRatio", "xMidYMid meet");
  svg.classList.add("viz-tree");

  const nodes = view.nodes ?? [];
  const edges = view.edges ?? [];
  const byId = Object.fromEntries(nodes.map((n) => [n.id, n]));
  const visited = new Set(view.visited ?? []);
  const frontier = new Set(view.frontier ?? []);
  const pruned = new Set(view.pruned ?? []);

  // Edges paint first so nodes stack on top of them.
  for (const [fromId, toId] of edges) {
    const from = byId[fromId];
    const to = byId[toId];
    if (!from || !to) continue;

    const line = svgEl("line");
    line.classList.add("viz-tree__edge");
    line.setAttribute("x1", from.x * 100);
    line.setAttribute("y1", from.y * 100);
    line.setAttribute("x2", to.x * 100);
    line.setAttribute("y2", to.y * 100);
    svg.append(line);
  }

  for (const node of nodes) {
    const cx = node.x * 100;
    const cy = node.y * 100;

    const circle = svgEl("circle");
    circle.classList.add("viz-tree__node");
    circle.setAttribute("cx", cx);
    circle.setAttribute("cy", cy);
    circle.setAttribute("r", 7);
    const state = stateClass(node.id, view.current, visited, frontier, pruned);
    if (state) circle.classList.add(state);
    svg.append(circle);

    const value = svgEl("text");
    value.classList.add("viz-tree__value");
    value.setAttribute("x", cx);
    value.setAttribute("y", cy);
    value.setAttribute("text-anchor", "middle");
    value.setAttribute("dominant-baseline", "central");
    value.textContent = String(node.value);
    svg.append(value);

    const labelText = view.labels?.[node.id];
    if (labelText !== undefined && labelText !== null) {
      const label = svgEl("text");
      label.classList.add("viz-tree__label");
      label.setAttribute("x", cx);
      label.setAttribute("y", cy + 12);
      label.setAttribute("text-anchor", "middle");
      label.textContent = String(labelText);
      svg.append(label);
    }
  }

  el.append(svg);

  if (view.caption) {
    const caption = document.createElement("p");
    caption.className = "viz-caption";
    caption.textContent = view.caption;
    el.append(caption);
  }
}
