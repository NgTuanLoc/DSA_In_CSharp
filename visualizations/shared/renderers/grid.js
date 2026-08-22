export function renderGrid(view, el) {
  const wrap = document.createElement("div");
  wrap.className = "viz-grid";

  const rows = view.rows ?? [];
  const rowLabels = view.rowLabels;
  const colLabels = view.colLabels;
  const current = view.current;
  const colors = view.colors ?? {};

  if (colLabels) {
    const header = document.createElement("div");
    header.className = "viz-grid__row viz-grid__row--header";

    if (rowLabels) {
      const corner = document.createElement("div");
      corner.className = "viz-grid__corner";
      header.append(corner);
    }

    colLabels.forEach((label) => {
      const colLabel = document.createElement("div");
      colLabel.className = "viz-grid__col-label";
      colLabel.textContent = String(label);
      header.append(colLabel);
    });

    wrap.append(header);
  }

  rows.forEach((row, r) => {
    const rowEl = document.createElement("div");
    rowEl.className = "viz-grid__row";

    if (rowLabels) {
      const rowLabel = document.createElement("div");
      rowLabel.className = "viz-grid__row-label";
      rowLabel.textContent = String(rowLabels[r] ?? "");
      rowEl.append(rowLabel);
    }

    row.forEach((value, c) => {
      const cell = document.createElement("div");
      cell.className = "viz-grid__cell";
      cell.dataset.r = String(r);
      cell.dataset.c = String(c);

      const state = colors[`${r},${c}`];
      if (state) cell.classList.add(`is-${state}`);
      if (current && current.r === r && current.c === c) cell.classList.add("is-current");

      cell.textContent = value === undefined ? "" : String(value);
      rowEl.append(cell);
    });

    wrap.append(rowEl);
  });

  el.append(wrap);

  if (view.caption) {
    const caption = document.createElement("p");
    caption.className = "viz-caption";
    caption.textContent = view.caption;
    el.append(caption);
  }
}
