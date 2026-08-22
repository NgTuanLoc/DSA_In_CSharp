export function renderArray(view, el) {
  const wrap = document.createElement("div");
  wrap.className = "viz-array";

  const pointersByIndex = {};
  for (const [name, index] of Object.entries(view.pointers ?? {})) {
    (pointersByIndex[index] ??= []).push(name);
  }

  (view.cells ?? []).forEach((cell, i) => {
    const col = document.createElement("div");
    col.className = "viz-array__col";

    const pointer = document.createElement("div");
    pointer.className = "viz-array__ptr";
    pointer.textContent = (pointersByIndex[i] ?? []).join(" ");

    const box = document.createElement("div");
    box.className = "viz-array__cell";
    if (view.colors?.[i]) box.classList.add(`is-${view.colors[i]}`);
    if (view.window && i >= view.window.start && i <= view.window.end) {
      box.classList.add("is-window");
    }
    box.textContent = String(cell);

    const index = document.createElement("div");
    index.className = "viz-array__index";
    index.textContent = String(i);

    col.append(pointer, box, index);
    wrap.append(col);
  });

  el.append(wrap);

  if (view.caption) {
    const caption = document.createElement("p");
    caption.className = "viz-caption";
    caption.textContent = view.caption;
    el.append(caption);
  }
}
