/**
 * Min-heap push/pop written locally (not imported from heap-operations —
 * spec modules never import each other).
 */
function pushMinHeap(heap, v) {
  heap.push(v);
  let i = heap.length - 1;
  while (i > 0) {
    const p = Math.floor((i - 1) / 2);
    if (heap[i] >= heap[p]) break;
    [heap[i], heap[p]] = [heap[p], heap[i]];
    i = p;
  }
}

function popMinHeap(heap) {
  const min = heap[0];
  const last = heap.pop();
  if (heap.length === 0) return min;

  heap[0] = last;
  let i = 0;
  while (true) {
    const left = 2 * i + 1;
    const right = 2 * i + 2;
    if (left >= heap.length) break;

    let smallest = i;
    if (heap[left] < heap[smallest]) smallest = left;
    if (right < heap.length && heap[right] < heap[smallest]) smallest = right;
    if (smallest === i) break;

    [heap[i], heap[smallest]] = [heap[smallest], heap[i]];
    i = smallest;
  }

  return min;
}

export default {
  title: "Top K Elements",
  slug: "top-k",
  folder: "Heap",
  complexity: { time: "O(n log k)", space: "O(k)" },
  whenToUse:
    "You want the k best items out of n, and k is much smaller than n — keep a heap of size k instead of sorting everything.",
  problems: [
    "215. Kth Largest Element in an Array",
    "347. Top K Frequent Elements",
    "973. K Closest Points to Origin",
    "658. Find K Closest Elements",
  ],
  pseudocode: [
    "minHeap = []",
    "for each num in nums:",
    "  push num onto minHeap",
    "  if minHeap.size > k:",
    "    pop the smallest",
    "return minHeap[0]      # the kth largest",
  ],
  inputs: [
    { label: "[3,2,1,5,6,4], k=2", data: { nums: [3, 2, 1, 5, 6, 4], k: 2 }, expect: 5 },
    {
      label: "[3,2,3,1,2,4,5,5,6], k=4",
      data: { nums: [3, 2, 3, 1, 2, 4, 5, 5, 6], k: 4 },
      expect: 4,
    },
    { label: "[1], k=1", data: { nums: [1], k: 1 }, expect: 1 },
  ],
  run(data, emit) {
    const { nums, k } = data;
    const heap = [];

    function views(pointerIndex, dimUpTo) {
      const colors = {};
      for (let j = 0; j < dimUpTo; j += 1) colors[j] = "dim";
      return {
        view: {
          kind: "array",
          cells: [...nums],
          pointers: { i: pointerIndex },
          colors,
        },
        view2: {
          kind: "collection",
          label: "min-heap (size ≤ k)",
          items: heap.map((v) => ({ value: v })),
          orientation: "horizontal",
          highlight: heap.length > 0 ? [0] : [],
        },
      };
    }

    for (let i = 0; i < nums.length; i += 1) {
      pushMinHeap(heap, nums[i]);
      emit({
        line: 2,
        note: `push ${nums[i]} onto the min-heap`,
        ...views(i, i),
      });

      emit({
        line: 3,
        note: `minHeap.size is ${heap.length} — compare against k=${k}`,
        ...views(i, i),
      });

      if (heap.length > k) {
        const smallest = popMinHeap(heap);
        emit({
          line: 4,
          note: `heap exceeded k — drop the smallest, ${smallest}`,
          ...views(i, i),
        });
      }
    }

    const kth = heap[0];
    emit({
      line: 5,
      note: `minHeap[0] = ${kth} — the kth largest`,
      ...views(nums.length - 1, nums.length),
    });

    return kth;
  },
};
