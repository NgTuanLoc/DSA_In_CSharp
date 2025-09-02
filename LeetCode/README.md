# LeetCode Algorithm Patterns & Cheat Sheet

> Fast pattern recall + practical C# snippets mapped to this repository's code.

## Table of Contents
1. How to Use This Guide
2. Core Problem-Solving Checklist
3. Complexity Quick Reference
4. Patterns
   - Two Pointers
   - Sliding Window
   - Prefix Sum
   - Binary Search
   - Backtracking
   - Dynamic Programming
   - Hashing / Counting
   - Trees & Graphs (DFS / BFS)
   - Heap / Priority Queue
   - Monotonic Stack / Next Greater
   - Monotonic Queue (Optimized Sliding Window)
   - Subsets & Subsequences
   - Greedy
   - Interval Scheduling / Sweeping
   - Union-Find (Disjoint Set)
   - Topological Sort (Kahn / DFS)
   - Shortest Path (Dijkstra)
   - Bit Manipulation
5. References
6. Appendix: C# Solution Template

---
## 1. How to Use This Guide
- Identify the minimal pattern that fits the constraints (time, memory, data shape).
- Skim the cheat form, map placeholders to your variable names.
- Adapt from existing implementations in this repo (see file links below).
- Test quickly in `LeetCode/Playground.cs` or a new file.

Repo pattern examples:
- Array & String: `ArrayAndString/TwoPointers.cs`, `SlidingWindow.cs`, `PrefixSum.cs`
- Backtracking: `Backtracking/Generation.cs`
- Hashing: `Hashing/Hashing.cs`, `Counting.cs`
- Heap: `Heap/HeapSolution.cs`
- Trees & Graphs: `TreesAndGraphs/Dfs.cs`, `Bfs.cs`, `BinarySearchTree.cs`
- Search Algorithms: `Algorithm/SearchAlgorithm/BinarySearch.cs`

---
## 2. Core Problem-Solving Checklist
1. Restate problem + constraints (n ≤ ?, values range?).
2. Clarify output format / edge cases (empty, single element, duplicates, negatives, sorted?).
3. Brute force (time & space) – keep as mental baseline.
4. Spot pattern(s): window? prefix? ordering? graph? combinatorial explosion? monotonicity?
5. Choose data structures: deque? heap? hashmap? union-find?
6. Write recurrence / invariant / state definition if DP or window.
7. Implement incrementally: skeleton → handle edges → optimize.
8. Validate with tiny cases + extreme boundaries.
9. Complexity verify (target vs constraints).
10. Refactor for clarity (naming, early exits) before submit.

---
## 3. Complexity Quick Reference
- O(1): Hash lookups, arithmetic, bit ops
- O(log n): Binary search, heap push/pop, balanced tree ops
- O(n): Single pass, counting, prefix sum build
- O(n log n): Sort-based strategies, heap building (k log n)
- O(n^2): DP over pairs, naive two loops
- O(2^n / n!): Backtracking (subsets, permutations)
- O(V + E): Graph traversals (DFS/BFS, Topo sort)

Memory patterns: in-place (two pointers), auxiliary arrays (prefix, DP), recursion stack (DFS/backtracking), disjoint set arrays.

---
## 4. Patterns

### 4.1 Two Pointers
Used for bidirectional scans, convergence, partitioning, or in-place transforms.
```csharp
int l = 0, r = arr.Length - 1;
while (l < r) {
    // compare/use arr[l], arr[r]
    l++; r--;
}
```
Common: Reverse, palindrome, deduplicate sorted, pair sum, container water, move zeros (variant with slow/fast).

### 4.2 Sliding Window
Fixed or variable window for subarray/substring constraints.
Invariant: maintain window validity; shrink when violated.
```csharp
int l = 0;
for (int r = 0; r < s.Length; r++) {
    // include s[r]
    while (/* invalid */) {
        // exclude s[l]
        l++;
    }
    // update answer
}
```
Variants: longest unique substring, min window with all chars, count anagrams, avg/sum thresholds.

### 4.3 Prefix Sum
Precompute cumulative aggregates for O(1) range queries or difference detection.
```csharp
int[] pref = new int[n + 1];
for (int i = 0; i < n; i++) pref[i + 1] = pref[i] + arr[i];
int rangeSum = pref[r + 1] - pref[l];
```
Extensions: 2D prefix, prefix XOR, difference arrays for range updates.

### 4.4 Binary Search
Requires monotonic predicate (false...true or vice versa) or sorted structure.
Forms: index search, lower/upper bound, answer-on-range (binary search the answer), first true.
```csharp
int lo = 0, hi = n - 1;
while (lo <= hi) {
    int mid = lo + (hi - lo) / 2;
    if (arr[mid] == target) return mid;
    if (arr[mid] < target) lo = mid + 1; else hi = mid - 1;
}
return -1; // not found
```
Answer range template:
```csharp
int lo = minPossible, hi = maxPossible;
while (lo < hi) {
    int mid = lo + (hi - lo) / 2;
    if (Can(mid)) hi = mid; else lo = mid + 1;
}
return lo; // minimal feasible
```

### 4.5 Backtracking
Systematically explore decision tree; prune invalid or dominated branches.
State: path, position/index, constraint counters. Use revert-on-return pattern.
```csharp
void Dfs(int idx) {
    if (idx == n) { /* record */ return; }
    for (/* each choice */) {
        // choose
        Dfs(idx + 1);
        // unchoose
    }
}
```
Optimizations: ordering, early pruning, bitmasks for presence.

### 4.6 Dynamic Programming
Define state + transitions. Decide dimension order so dependencies computed earlier.
Checklist: state meaning, base cases, transition formula, iteration order, answer location.
1D Example (LIS O(n^2)) in file `ArrayAndString/Example.cs` variant:
```csharp
int[] dp = new int[n]; Array.Fill(dp, 1);
for (int i = 0; i < n; i++)
    for (int j = 0; j < i; j++)
        if (a[j] < a[i]) dp[i] = Math.Max(dp[i], dp[j] + 1);
int ans = dp.Max();
```
Memory optimization: compress DP rolling arrays, store only last row/col.

### 4.7 Hashing / Counting
Fast frequency, presence, grouping. Use Dictionary / HashSet.
Idioms:
```csharp
var freq = new Dictionary<int,int>();
foreach (var x in arr) freq[x] = freq.GetValueOrDefault(x, 0) + 1;
```
Applications: two-sum complement, anagram signature grouping, sliding window char counts, prefix sum map to count subarrays.

### 4.8 Trees & Graphs (DFS / BFS)
Traversal skeletons; see `TreesAndGraphs/Dfs.cs` & `Bfs.cs`.
DFS (recursive or stack) for exhaustive path / depth metrics; BFS for shortest edges path in unweighted.
```csharp
void Dfs(Node u) {
    if (u == null) return;
    Dfs(u.Left); Dfs(u.Right);
}
```
Level-order BFS:
```csharp
var q = new Queue<Node>(); q.Enqueue(root);
while (q.Count > 0) {
    int levelSize = q.Count;
    for (int i = 0; i < levelSize; i++) {
        var cur = q.Dequeue();
        // process cur
        if (cur.Left!=null) q.Enqueue(cur.Left);
        if (cur.Right!=null) q.Enqueue(cur.Right);
    }
}
```

### 4.9 Heap / Priority Queue
Use for streaming extremes, k-selection, merging sorted sequences.
Min-heap built-in priority queue:
```csharp
var pq = new PriorityQueue<(int val,int idx), int>();
pq.Enqueue((value, idx), value); // priority = value
var (v,i) = pq.Dequeue();
```
Max-heap: invert priority (use -value).

### 4.10 Monotonic Stack / Next Greater
Maintain decreasing or increasing structure to answer span/next queries in O(n).
```csharp
var st = new Stack<int>(); // store indices
for (int i = 0; i < n; i++) {
    while (st.Count > 0 && arr[st.Peek()] < arr[i]) {
        int idx = st.Pop(); // next greater for idx is i
    }
    st.Push(i);
}
```
Uses: next greater element, daily temperatures, largest rectangle in histogram (with heights + sentinel), stock span.

### 4.11 Monotonic Queue (Optimized Sliding Window)
Deque maintains decreasing (or increasing) values for O(1) window extrema.
```csharp
var dq = new LinkedList<int>(); // store indices
for (int r = 0; r < n; r++) {
    while (dq.Count > 0 && arr[dq.Last!.Value] <= arr[r]) dq.RemoveLast();
    dq.AddLast(r);
    if (dq.First!.Value <= r - k) dq.RemoveFirst();
    if (r >= k - 1) {
        int maxVal = arr[dq.First!.Value];
    }
}
```

### 4.12 Subsets & Subsequences
Subsets = power set (2^n). Use depth-first choose/skip. Subsequences maintain order.
Already covered backtracking + LIS DP. Another subset template:
```csharp
void Gen(int i) {
    if (i == n) { /* record */ return; }
    // include
    Gen(i + 1);
    // exclude
    Gen(i + 1);
}
```

### 4.13 Greedy
Pick locally optimal choice; prove with exchange argument or invariants.
Typical: interval scheduling (earliest finish), jump game (furthest reach), Huffman coding (merge two smallest), assign tasks.
Checklist: Is the optimal substructure preserved when making best immediate choice? If yes, greedy likely valid.

### 4.14 Interval Scheduling / Sweep Line
Sort by start or end; detect overlaps, merge windows, count active intervals.
Merge intervals:
```csharp
intervals.Sort((a,b)=> a.start.CompareTo(b.start));
var res = new List<Interval>();
foreach (var cur in intervals) {
    if (res.Count == 0 || res[^1].end < cur.start) res.Add(cur);
    else res[^1] = new Interval(res[^1].start, Math.Max(res[^1].end, cur.end));
}
```
Sweep line: convert to events (time, +1/-1), sort, accumulate for max concurrency.

### 4.15 Union-Find (Disjoint Set)
Maintain partition sets with path compression + union by rank for near O(α(n)).
```csharp
int[] parent = Enumerable.Range(0, n).ToArray();
int[] rank = new int[n];
int Find(int x) => parent[x]==x ? x : parent[x] = Find(parent[x]);
void Union(int a,int b) {
    a = Find(a); b = Find(b);
    if (a==b) return;
    if (rank[a] < rank[b]) (a,b) = (b,a);
    parent[b] = a;
    if (rank[a]==rank[b]) rank[a]++;
}
```
Uses: connected components, cycle detection (undirected), Kruskal MST, number of islands (with mapping 2D→id).

### 4.16 Topological Sort (Kahn / DFS)
Directed Acyclic Graph ordering.
Kahn:
```csharp
var indeg = new int[n];
foreach (var (u,v) in edges) indeg[v]++;
var q = new Queue<int>(Enumerable.Range(0,n).Where(i=>indeg[i]==0));
var order = new List<int>();
while (q.Count>0) {
    int u = q.Dequeue(); order.Add(u);
    foreach (var v in adj[u]) if (--indeg[v]==0) q.Enqueue(v);
}
bool hasCycle = order.Count != n;
```

### 4.17 Shortest Path (Dijkstra for Weighted Non-Negative)
```csharp
var dist = Enumerable.Repeat(int.MaxValue, n).ToArray();
dist[src] = 0;
var pq = new PriorityQueue<int,int>();
pq.Enqueue(src, 0);
while (pq.Count>0) {
    var u = pq.Dequeue();
    foreach (var (v,w) in adj[u]) if (dist[u] + w < dist[v]) {
        dist[v] = dist[u] + w;
        pq.Enqueue(v, dist[v]);
    }
}
```
Use BFS for unweighted (all weights = 1). Use 0-1 BFS deque for weights {0,1}. Use Bellman-Ford if negative edges.

### 4.18 Bit Manipulation
Compact state, parity, subsets, fast multiply/divide by powers of two.
Idioms:
```csharp
int lowestBit = x & -x; // isolate rightmost set bit
bool isPow2 = x > 0 && (x & (x - 1)) == 0;
int maskInclude = state | (1 << bit);
int maskRemove = state & ~(1 << bit);
bool has = (state & (1 << bit)) != 0;
```
Tricks: XOR for single number, XOR accumulation to swap without temp, iterate subsets: `for (int s = mask; s > 0; s = (s - 1) & mask) { ... }`.

---
## 5. References
- LeetCode Explore & Discuss
- NeetCode Roadmap
- CLRS (Cormen et al.) for formal proofs
- Competitive Programming Handbook (Laaksonen) for pattern reinforcement

---
## 6. Appendix: C# Solution Template
```csharp
public class Solution {
    // Time: O(n)  Space: O(1)
    public int Example(int[] nums) {
        if (nums == null || nums.Length == 0) return 0; // edge
        int result = 0;
        // core logic
        return result;
    }
}
```
Checklist at top of file (optional):
```csharp
/*
Problem: <name / link>
Pattern: <two pointers / dp / ...>
State / Invariant:
Edge Cases: empty, single, all same, extremes
Complexity Goal: O(n log n)
*/
```
---
Happy coding! Iterate, pattern-match, optimize, explain.
