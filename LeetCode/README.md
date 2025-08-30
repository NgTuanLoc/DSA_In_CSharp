# LeetCode Algorithm Patterns & Cheat Sheet

This guide categorizes the most common algorithm patterns found in LeetCode problems, with a cheat sheet for each. Use this as a reference when solving problems or reviewing concepts.

---

## 1. Two Pointers
**Description:**
Used for problems involving arrays/strings where you need to scan from both ends or maintain a window.

**Cheat Sheet:**
```csharp
int left = 0, right = arr.Length - 1;
while (left < right) {
    // Do something with arr[left] and arr[right]
    left++;
    right--;
}
```
**Common Problems & Use-Cases:**
- Reverse array (LeetCode 344: Reverse String)
- Palindrome check (LeetCode 125: Valid Palindrome)
- Remove duplicates (LeetCode 26: Remove Duplicates from Sorted Array)
- Sorted array pair sum (LeetCode 167: Two Sum II)
- Move zeroes (LeetCode 283: Move Zeroes)
- Container With Most Water (LeetCode 11)

---

## 2. Sliding Window
**Description:**
Efficiently find subarrays/substrings that satisfy a condition (sum, length, etc.).

**Cheat Sheet:**
```csharp
int left = 0;
for (int right = 0; right < arr.Length; right++) {
    // Expand window
    // Shrink window if needed
    while (/* condition */) {
        left++;
    }
}
```
**Common Problems & Use-Cases:**
- Maximum sum subarray (LeetCode 53: Maximum Subarray)
- Longest substring without repeating characters (LeetCode 3)
- Minimum size subarray sum (LeetCode 209)
- Permutation in String (LeetCode 567)
- Longest repeating character replacement (LeetCode 424)

---

## 3. Prefix Sum
**Description:**
Precompute cumulative sums to answer range queries efficiently.

**Cheat Sheet:**
```csharp
int[] prefix = new int[arr.Length + 1];
for (int i = 0; i < arr.Length; i++) {
    prefix[i + 1] = prefix[i] + arr[i];
}
// Range sum: prefix[j+1] - prefix[i]
```
**Common Problems:**
- Range sum queries
- Subarray sum equals k

---

## 4. Backtracking
**Description:**
Explore all possible solutions by building candidates incrementally and abandoning them if they fail.

**Cheat Sheet:**
```csharp
void Backtrack(List<int> path) {
    if (/* goal reached */) {
        // Save solution
        return;
    }
    for (int i = 0; i < choices.Length; i++) {
        if (/* valid choice */) {
            path.Add(choices[i]);
            Backtrack(path);
            path.RemoveAt(path.Count - 1);
        }
    }
}
```
**Common Problems:**
- Permutations
- Combinations
- Subsets

---

## 5. Dynamic Programming
**Description:**
Break problems into subproblems and store their solutions to avoid recomputation.

**Cheat Sheet:**
```csharp
int[] dp = new int[n];
for (int i = 0; i < n; i++) {
    dp[i] = /* recurrence relation */;
}
```
**Common Problems:**
- Fibonacci sequence
- Knapsack problem
- Longest increasing subsequence

---

## 6. Hashing
**Description:**
Use hash tables (dictionaries) for fast lookups, counting, or existence checks.

**Cheat Sheet:**
```csharp
Dictionary<int, int> map = new();
foreach (var num in arr) {
    if (map.ContainsKey(num)) {
        // Found duplicate or do something
    }
    map[num] = map.GetValueOrDefault(num, 0) + 1;
}
```
**Common Problems:**
- Two sum
- Group anagrams
- Longest consecutive sequence

---

## 7. Trees & Graphs
**Description:**
Traverse or search tree/graph structures using DFS or BFS.

**Cheat Sheet:**
- **DFS:**
```csharp
void DFS(TreeNode node) {
    if (node == null) return;
    DFS(node.left);
    DFS(node.right);
}
```
- **BFS:**
```csharp
Queue<TreeNode> queue = new();
queue.Enqueue(root);
while (queue.Count > 0) {
    var node = queue.Dequeue();
    // Process node
    if (node.left != null) queue.Enqueue(node.left);
    if (node.right != null) queue.Enqueue(node.right);
}
```
**Common Problems:**
- Level order traversal
- Path sum
- Connected components

---

## 8. Heap / Priority Queue
**Description:**
Efficiently retrieve the smallest/largest element.

**Cheat Sheet:**
```csharp
var pq = new PriorityQueue<int, int>();
pq.Enqueue(value, priority);
var min = pq.Dequeue();
```
**Common Problems:**
- Kth largest/smallest element
- Merge k sorted lists

---

## 9. Subsets & Subsequences
**Description:**
Subsets: Any combination of elements (order doesn't matter).
Subsequences: Elements in original order (not necessarily contiguous).

**Cheat Sheet:**
- **Subsets (Backtracking):**
```csharp
void Subsets(List<int> path, int start) {
    // Save path
    for (int i = start; i < arr.Length; i++) {
        path.Add(arr[i]);
        Subsets(path, i + 1);
        path.RemoveAt(path.Count - 1);
    }
}
```
- **Subsequences (DP or Backtracking):**
```csharp
// Example: Longest Increasing Subsequence (DP)
int[] dp = new int[n];
for (int i = 0; i < n; i++) {
    dp[i] = 1;
    for (int j = 0; j < i; j++) {
        if (arr[j] < arr[i]) dp[i] = Math.Max(dp[i], dp[j] + 1);
    }
}
```

---

## References
- [LeetCode Patterns](https://leetcode.com/explore/learn/)
- [NeetCode Patterns](https://neetcode.io/roadmap)
- [LeetCode Discuss](https://leetcode.com/discuss/)

---

Happy coding!
