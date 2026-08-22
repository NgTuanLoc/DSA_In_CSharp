/** Depth of index i in an array-backed binary heap: floor(log2(i + 1)). */
function depthOf(i) {
  return Math.floor(Math.log2(i + 1));
}

/** Spreads every index of a heap of the given size across depth-even x/y coordinates. */
function layoutOf(size) {
  const nodes = [];
  for (let i = 0; i < size; i += 1) {
    const d = depthOf(i);
    const levelStart = 2 ** d - 1;
    const slots = 2 ** d;
    const pos = i - levelStart;
    nodes.push({ id: i, x: (pos + 0.5) / slots, y: (d + 0.5) / 4 });
  }
  return nodes;
}

/** Parent/child index arithmetic edges for a heap of the given size. */
function edgesFor(size) {
  const edges = [];
  for (let i = 1; i < size; i += 1) {
    edges.push([Math.floor((i - 1) / 2), i]);
  }
  return edges;
}

function views(heap, current, highlight) {
  const layout = layoutOf(heap.length);
  const view = {
    kind: "tree",
    nodes: layout.map(({ id, x, y }) => ({ id, value: heap[id], x, y })),
    edges: edgesFor(heap.length),
  };
  if (current !== null && current !== undefined) view.current = current;

  return {
    view,
    view2: {
      kind: "collection",
      label: "heap array",
      items: heap.map((v) => ({ value: v })),
      orientation: "horizontal",
      highlight: [...highlight],
    },
  };
}

function pushOne(heap, v, emit) {
  heap.push(v);
  const i0 = heap.length - 1;
  emit({
    line: 0,
    note: `append ${v} at index ${i0}`,
    ...views(heap, i0, [i0]),
  });

  let i = i0;
  while (i > 0) {
    const p = Math.floor((i - 1) / 2);
    const childVal = heap[i];
    const parentVal = heap[p];
    emit({
      line: 2,
      note: `compare heap[${i}]=${childVal} to its parent heap[${p}]=${parentVal}`,
      ...views(heap, i, [i, p]),
    });

    if (childVal >= parentVal) break;

    [heap[i], heap[p]] = [heap[p], heap[i]];
    emit({
      line: 3,
      note: `${childVal} < ${parentVal} — swap heap[${i}] and heap[${p}]; i becomes ${p}`,
      ...views(heap, p, [i, p]),
    });
    i = p;
  }
}

function popOne(heap, emit) {
  const min = heap[0];
  const last = heap.pop();
  if (heap.length > 0) heap[0] = last;

  emit({
    line: 4,
    note: `save heap[0]=${min} as the min; move last item ${last} to index 0`,
    ...views(heap, heap.length > 0 ? 0 : null, heap.length > 0 ? [0] : []),
  });

  let i = 0;
  while (true) {
    const left = 2 * i + 1;
    const right = 2 * i + 2;
    if (left >= heap.length) break; // no children at all — the loop stops silently

    let smaller = i;
    if (heap[left] < heap[smaller]) smaller = left;
    if (right < heap.length && heap[right] < heap[smaller]) smaller = right;

    if (smaller === i) {
      emit({
        line: 5,
        note: `heap[${i}]=${heap[i]} is already smaller than its children — stop`,
        ...views(heap, i, [i, left, right].filter((idx) => idx < heap.length)),
      });
      break;
    }

    const parentVal = heap[i];
    const childVal = heap[smaller];
    [heap[i], heap[smaller]] = [heap[smaller], heap[i]];
    emit({
      line: 5,
      note: `heap[${i}]=${parentVal} > heap[${smaller}]=${childVal} — swap; i becomes ${smaller}`,
      ...views(heap, smaller, [i, smaller]),
    });
    i = smaller;
  }

  return { min, heap: [...heap] };
}

export default {
  title: "Heap Operations",
  slug: "heap-operations",
  folder: "Heap",
  complexity: { time: "O(log n) per push or pop", space: "O(n)" },
  whenToUse:
    "You repeatedly need the smallest (or largest) item while the collection keeps changing — a heap keeps that item at index 0 for O(log n) upkeep.",
  problems: [
    "703. Kth Largest Element in a Stream",
    "1046. Last Stone Weight",
    "215. Kth Largest Element in an Array",
    "621. Task Scheduler",
  ],
  pseudocode: [
    "push(v): append v at the end",
    "  i = last index",
    "  while i > 0 and heap[i] < heap[parent(i)]:",
    "    swap(i, parent(i)); i = parent(i)",
    "pop(): save heap[0], move the last item to index 0",
    "  sift down while a child is smaller than the node",
  ],
  inputs: [
    { label: "push 5, 3, 8, 1", data: { op: "push", values: [5, 3, 8, 1] }, expect: [1, 3, 8, 5] },
    {
      label: "pop the min from [1,3,8,5]",
      data: { op: "pop", heap: [1, 3, 8, 5] },
      expect: { min: 1, heap: [3, 5, 8] },
    },
  ],
  run(data, emit) {
    if (data.op === "push") {
      const heap = [];
      for (const v of data.values) {
        pushOne(heap, v, emit);
      }
      return [...heap];
    }

    if (data.op === "pop") {
      const heap = [...data.heap];
      return popOne(heap, emit);
    }

    throw new Error(`heap-operations: unknown op "${data.op}"`);
  },
};
