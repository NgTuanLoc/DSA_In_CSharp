export function renderCollection(view, el) {
  const wrap = document.createElement("div");
  wrap.className = `viz-collection viz-collection--${view.orientation ?? "vertical"}`;

  const label = document.createElement("div");
  label.className = "viz-collection__label";
  label.textContent = `${view.label} (${(view.items ?? []).length})`;
  wrap.append(label);

  const items = document.createElement("div");
  items.className = "viz-collection__items";

  const highlight = new Set(view.highlight ?? []);
  (view.items ?? []).forEach((item, i) => {
    const box = document.createElement("div");
    box.className = "viz-collection__item";
    if (highlight.has(i)) box.classList.add("is-active");
    box.textContent = item.key === undefined ? String(item.value) : `${item.key}: ${item.value}`;
    items.append(box);
  });

  if ((view.items ?? []).length === 0) {
    const empty = document.createElement("div");
    empty.className = "viz-collection__empty";
    empty.textContent = "empty";
    items.append(empty);
  }

  wrap.append(items);
  el.append(wrap);

  if (view.caption) {
    const caption = document.createElement("p");
    caption.className = "viz-caption";
    caption.textContent = view.caption;
    el.append(caption);
  }
}
