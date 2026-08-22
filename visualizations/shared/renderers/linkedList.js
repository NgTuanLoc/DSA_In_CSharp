export function renderLinkedList(view, el) {
  const wrap = document.createElement("div");
  wrap.className = "viz-list";

  const nodes = view.nodes ?? [];

  if (nodes.length === 0) {
    const empty = document.createElement("div");
    empty.className = "viz-collection__empty";
    empty.textContent = "empty list";
    wrap.append(empty);
    el.append(wrap);
    return;
  }

  const pointersById = {};
  for (const [name, id] of Object.entries(view.pointers ?? {})) {
    if (id === null || id === undefined) continue;
    (pointersById[id] ??= []).push(name);
  }

  nodes.forEach((node, i) => {
    const col = document.createElement("div");
    col.className = "viz-list__col";

    const ptr = document.createElement("div");
    ptr.className = "viz-list__ptr";
    ptr.textContent = (pointersById[node.id] ?? []).join(" ");

    const box = document.createElement("div");
    box.className = "viz-list__node";
    box.dataset.id = node.id;
    if (view.colors?.[node.id]) box.classList.add(`is-${view.colors[node.id]}`);
    box.textContent = String(node.value);

    col.append(ptr, box);
    wrap.append(col);

    if (i < nodes.length - 1) {
      const next = nodes[i + 1];
      const arrow = document.createElement("div");
      arrow.className = "viz-list__arrow";
      // Direction-aware: read view.next to show which way this pair is
      // actually wired right now, rather than assuming forward order —
      // reversal (and any other in-place rewiring) needs the arrow to flip.
      if (view.next?.[node.id] === next.id) {
        arrow.textContent = "→";
      } else if (view.next?.[next.id] === node.id) {
        arrow.textContent = "←";
      } else {
        // Neither node points at the other in this frame (e.g. mid-rewire,
        // where the left node's next has already been redirected elsewhere).
        // "–" (en dash) is the quiet, non-directional connector.
        arrow.textContent = "–";
      }
      wrap.append(arrow);
    }
  });

  const lastNode = nodes[nodes.length - 1];
  const predecessor = nodes.length >= 2 ? nodes[nodes.length - 2] : null;
  const nextOfLast = view.next?.[lastNode.id];
  const pointsAtPredecessor = predecessor !== null && nextOfLast === predecessor.id;
  if (nextOfLast !== null && nextOfLast !== undefined && !pointsAtPredecessor) {
    const target = nodes.find((n) => n.id === nextOfLast);
    const cycle = document.createElement("div");
    cycle.className = "viz-list__cycle";
    cycle.textContent = `↩ back to ${target ? target.value : nextOfLast}`;
    wrap.append(cycle);
  }

  el.append(wrap);

  if (view.caption) {
    const caption = document.createElement("p");
    caption.className = "viz-caption";
    caption.textContent = view.caption;
    el.append(caption);
  }
}
