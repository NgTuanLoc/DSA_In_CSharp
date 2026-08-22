const SVG_NS = "http://www.w3.org/2000/svg";

function svgEl(tag) {
  return document.createElementNS(SVG_NS, tag);
}

/** Returns the single state class for a node, or null. Precedence: current > visited. */
function stateClass(id, current, visited) {
  if (current === id) return "is-current";
  if (visited.has(id)) return "is-visited";
  return null;
}

/** True when `activeEdge` names the same pair as [a, b], in either order. */
function isActiveEdge(a, b, activeEdge) {
  if (!activeEdge) return false;
  const [x, y] = activeEdge;
  return (x === a && y === b) || (x === b && y === a);
}

export function renderGraph(view, el) {
  const svg = svgEl("svg");
  svg.setAttribute("viewBox", "0 0 100 100");
  svg.setAttribute("preserveAspectRatio", "xMidYMid meet");
  svg.classList.add("viz-graph");

  const nodes = view.nodes ?? [];
  const edges = view.edges ?? [];
  const byId = Object.fromEntries(nodes.map((n) => [n.id, n]));
  const visited = new Set(view.visited ?? []);
  const distances = view.distances ?? {};

  // Edges paint first so nodes stack on top of them.
  for (const [fromId, toId] of edges) {
    const from = byId[fromId];
    const to = byId[toId];
    if (!from || !to) continue;

    const line = svgEl("line");
    line.classList.add("viz-graph__edge");
    if (isActiveEdge(fromId, toId, view.activeEdge)) line.classList.add("is-active");
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
    circle.classList.add("viz-graph__node");
    circle.setAttribute("cx", cx);
    circle.setAttribute("cy", cy);
    circle.setAttribute("r", 6);
    const state = stateClass(node.id, view.current, visited);
    if (state) circle.classList.add(state);
    svg.append(circle);

    const label = svgEl("text");
    label.classList.add("viz-graph__label");
    label.setAttribute("x", cx);
    label.setAttribute("y", cy);
    label.setAttribute("text-anchor", "middle");
    label.setAttribute("dominant-baseline", "central");
    label.textContent = String(node.label);
    svg.append(label);

    const dist = distances[node.id];
    if (dist !== undefined) {
      const distText = svgEl("text");
      distText.classList.add("viz-graph__dist");
      distText.setAttribute("x", cx);
      distText.setAttribute("y", cy + 13);
      distText.setAttribute("text-anchor", "middle");
      distText.textContent = `d=${dist}`;
      svg.append(distText);
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
