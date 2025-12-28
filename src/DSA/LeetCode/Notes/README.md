****# Data Structures and Algorithms Learning Guide

Welcome to my comprehensive guide for learning Data Structures and Algorithms! This README organizes my study notes and provides a structured path for understanding fundamental DSA concepts.

## 📚 Table of Contents

- [📚 Table of Contents](#-table-of-contents)
- [1. Introduction](#1-introduction)
  - [What You'll Learn](#what-youll-learn)
  - [Key Concepts](#key-concepts)
    - [Algorithm Fundamentals](#algorithm-fundamentals)
    - [Big O Notation](#big-o-notation)
    - [Analysis Rules](#analysis-rules)
  - [Time Complexity Examples](#time-complexity-examples)
  - [Space Complexity](#space-complexity)
- [2. Recursion](#2-recursion)
  - [Learning Objectives](#learning-objectives)
  - [Core Concepts](#core-concepts)
    - [Recursion Fundamentals](#recursion-fundamentals)
    - [Essential Components](#essential-components)
    - [Execution Order](#execution-order)
    - [Classic Example: Fibonacci](#classic-example-fibonacci)
  - [Problem-Solving Strategy](#problem-solving-strategy)
- [3. Arrays and Strings](#3-arrays-and-strings)
  - [Learning Objectives](#learning-objectives-1)
  - [Core Concepts](#core-concepts-1)
    - [Arrays vs Strings](#arrays-vs-strings)
    - [Time Complexity Reference](#time-complexity-reference)
  - [3.1 Two Pointers Technique](#31-two-pointers-technique)
    - [Concept](#concept)
    - [Two Main Patterns](#two-main-patterns)
    - [Common Use Cases](#common-use-cases)
    - [Example: Palindrome Check](#example-palindrome-check)
  - [3.2 Sliding Window](#32-sliding-window)
    - [Concept](#concept-1)
    - [General Template](#general-template)
    - [Why Sliding Window is Efficient](#why-sliding-window-is-efficient)
    - [Two Types of Sliding Window](#two-types-of-sliding-window)
    - [Common Patterns](#common-patterns)
  - [3.3 Prefix Sum](#33-prefix-sum)
    - [Concept](#concept-2)
    - [Mathematical Foundation](#mathematical-foundation)
    - [Implementation Patterns](#implementation-patterns)
    - [Complexity Analysis](#complexity-analysis)
    - [Common Applications](#common-applications)
- [3.4 Subarrays, Subsequences, and Subsets](#34-subarrays-subsequences-and-subsets)
  - [Definitions and Key Differences](#definitions-and-key-differences)
    - [Subarrays/Substrings](#subarrayssubstrings)
    - [Subsequences](#subsequences)
    - [Subsets](#subsets)
  - [Comparison Table](#comparison-table)
  - [Common Patterns and Solutions](#common-patterns-and-solutions)
    - [For Subarrays/Substrings](#for-subarrayssubstrings)
    - [For Subsequences](#for-subsequences)
    - [For Subsets](#for-subsets)
  - [Problem Type Recognition Guide](#problem-type-recognition-guide)
  - [Key Insights](#key-insights)
- [4. Hashing](#4-hashing)
  - [Learning Objectives](#learning-objectives-2)
  - [Hash Maps and Sets Fundamentals](#hash-maps-and-sets-fundamentals)
    - [What is Hashing?](#what-is-hashing)
    - [Hash Map vs Array Comparison](#hash-map-vs-array-comparison)
    - [When to Use Hash Maps](#when-to-use-hash-maps)
  - [4.1 Checking for Existence](#41-checking-for-existence)
    - [Core Concept](#core-concept)
    - [Common Pattern Template](#common-pattern-template)
    - [Key Applications](#key-applications)
  - [4.2 Counting Patterns](#42-counting-patterns)
    - [Core Concept](#core-concept-1)
    - [Frequency Counting Template](#frequency-counting-template)
    - [Advanced Counting Patterns](#advanced-counting-patterns)
    - [Complexity Analysis](#complexity-analysis-1)
    - [Common Counting Applications](#common-counting-applications)
  - [Key Insights](#key-insights-1)
  - [4.3 More Hashing Patterns](#43-more-hashing-patterns)
    - [Group Identification Patterns](#group-identification-patterns)
    - [Distance and Proximity Problems](#distance-and-proximity-problems)
    - [Digit Sum Grouping](#digit-sum-grouping)
    - [Array Conversion for Hashing](#array-conversion-for-hashing)
- [5. LinkedLists](#5-linkedlists)
  - [Learning Objectives](#learning-objectives-3)
  - [5.1 Introduction](#51-introduction)
    - [Node Structure and Basic Operations](#node-structure-and-basic-operations)
    - [Types of Linked Lists](#types-of-linked-lists)
    - [Advantages and Disadvantages](#advantages-and-disadvantages)
    - [Pointer Manipulation Fundamentals](#pointer-manipulation-fundamentals)
  - [5.2 Fast and Slow Pointers](#52-fast-and-slow-pointers)
    - [Two Pointer Technique for LinkedLists](#two-pointer-technique-for-linkedlists)
    - [Finding Middle Elements](#finding-middle-elements)
    - [Cycle Detection](#cycle-detection)
    - [Kth Node from End](#kth-node-from-end)
  - [5.3 Reversing LinkedLists](#53-reversing-linkedlists)
    - [Basic Reversal Algorithm](#basic-reversal-algorithm)
    - [Swapping Node Pairs](#swapping-node-pairs)
    - [Partial Reversals](#partial-reversals)
- [6. Stacks and Queues](#6-stacks-and-queues)
  - [Learning Objectives](#learning-objectives-4)
  - [6.1 Introduction to Stacks](#61-introduction-to-stacks)
    - [What is a Stack?](#what-is-a-stack)
    - [Stack Operations](#stack-operations)
    - [Implementation in C#](#implementation-in-c)
    - [The Characteristic of a Stack](#the-characteristic-of-a-stack)
    - [Stacks and Recursion](#stacks-and-recursion)
    - [When to Use Stacks](#when-to-use-stacks)
  - [6.2 String Problems with Stacks](#62-string-problems-with-stacks)
    - [Example 1: Valid Parentheses (LeetCode 20)](#example-1-valid-parentheses-leetcode-20)
    - [Example 2: Remove All Adjacent Duplicates (LeetCode 1047)](#example-2-remove-all-adjacent-duplicates-leetcode-1047)
    - [Example 3: Backspace String Compare (LeetCode 844)](#example-3-backspace-string-compare-leetcode-844)
  - [Key Insights for Stack Problems](#key-insights-for-stack-problems)
  - [Common Stack Problem Patterns](#common-stack-problem-patterns)
  - [6.3 Queues](#63-queues)
    - [What is a Queue?](#what-is-a-queue)
    - [Queue Operations](#queue-operations)
    - [Efficient Queue Implementation](#efficient-queue-implementation)
    - [Implementation in C#](#implementation-in-c-1)
    - [When to Use Queues](#when-to-use-queues)
    - [Example: Number of Recent Calls (LeetCode 933)](#example-number-of-recent-calls-leetcode-933)
  - [6.4 Monotonic Stacks and Queues](#64-monotonic-stacks-and-queues)
    - [What is Monotonic?](#what-is-monotonic)
    - [Monotonic Stack Template](#monotonic-stack-template)
    - [When to Use Monotonic Structures](#when-to-use-monotonic-structures)
    - [Example 1: Daily Temperatures (LeetCode 739)](#example-1-daily-temperatures-leetcode-739)
    - [Example 2: Sliding Window Maximum (LeetCode 239)](#example-2-sliding-window-maximum-leetcode-239)
    - [Example 3: Longest Continuous Subarray (LeetCode 1438)](#example-3-longest-continuous-subarray-leetcode-1438)
  - [Key Insights for Monotonic Structures](#key-insights-for-monotonic-structures)
  - [Monotonic Pattern Recognition](#monotonic-pattern-recognition)
- [7. Trees and Graphs](#7-trees-and-graphs)
  - [Learning Objectives](#learning-objectives-5)
  - [7.1 Introduction to Binary Trees](#71-introduction-to-binary-trees)
    - [Nodes and Graphs](#nodes-and-graphs)
    - [What is a Binary Tree?](#what-is-a-binary-tree)
    - [Real-World Examples](#real-world-examples)
    - [Binary Tree Terminology](#binary-tree-terminology)
    - [Code Representation](#code-representation)
  - [7.2 Depth-First Search (DFS)](#72-depth-first-search-dfs)
    - [What is DFS?](#what-is-dfs)
    - [Basic DFS Template](#basic-dfs-template)
    - [General DFS Structure](#general-dfs-structure)
    - [Three Types of DFS Traversal](#three-types-of-dfs-traversal)
    - [Example 1: Maximum Depth of Binary Tree (LeetCode 104)](#example-1-maximum-depth-of-binary-tree-leetcode-104)
    - [Example 2: Path Sum (LeetCode 112)](#example-2-path-sum-leetcode-112)
    - [Example 3: Count Good Nodes (LeetCode 1448)](#example-3-count-good-nodes-leetcode-1448)
    - [Example 4: Same Tree (LeetCode 100)](#example-4-same-tree-leetcode-100)
  - [Key Insights for Tree Problems](#key-insights-for-tree-problems)
  - [Common Time and Space Complexity](#common-time-and-space-complexity)
  - [DFS Pattern Recognition](#dfs-pattern-recognition)
  - [7.3 Breadth-First Search (BFS)](#73-breadth-first-search-bfs)
    - [What is BFS?](#what-is-bfs)
    - [When to Use BFS vs DFS](#when-to-use-bfs-vs-dfs)
    - [BFS Implementation Pattern](#bfs-implementation-pattern)
    - [Example 1: Binary Tree Right Side View (LeetCode 199)](#example-1-binary-tree-right-side-view-leetcode-199)
    - [Example 2: Find Largest Value in Each Tree Row (LeetCode 515)](#example-2-find-largest-value-in-each-tree-row-leetcode-515)
    - [Example 3: Deepest Leaves Sum (LeetCode 1302)](#example-3-deepest-leaves-sum-leetcode-1302)
    - [Example 4: Zigzag Level Order Traversal (LeetCode 103)](#example-4-zigzag-level-order-traversal-leetcode-103)
  - [Key Insights for BFS](#key-insights-for-bfs)
  - [7.4 Binary Search Trees (BST)](#74-binary-search-trees-bst)
    - [What is a Binary Search Tree?](#what-is-a-binary-search-tree)
    - [BST Operations Efficiency](#bst-operations-efficiency)
    - [Important BST Property: Inorder Traversal](#important-bst-property-inorder-traversal)
    - [Example 1: Range Sum of BST (LeetCode 938)](#example-1-range-sum-of-bst-leetcode-938)
    - [Example 2: Minimum Absolute Difference in BST (LeetCode 530)](#example-2-minimum-absolute-difference-in-bst-leetcode-530)
    - [Example 3: Validate Binary Search Tree (LeetCode 98)](#example-3-validate-binary-search-tree-leetcode-98)
  - [BST Key Insights](#bst-key-insights)
  - [BST Pattern Recognition](#bst-pattern-recognition)
  - [BFS vs DFS Summary](#bfs-vs-dfs-summary)
  - [7.5 Introduction to Graphs](#75-introduction-to-graphs)
    - [What is a Graph?](#what-is-a-graph)
    - [Real-World Graph Applications](#real-world-graph-applications)
    - [Graph Terminology](#graph-terminology)
    - [Graph Input Formats](#graph-input-formats)
      - [Format 1: Array of Edges](#format-1-array-of-edges)
      - [Format 2: Adjacency List](#format-2-adjacency-list)
      - [Format 3: Adjacency Matrix](#format-3-adjacency-matrix)
      - [Format 4: Matrix as Graph](#format-4-matrix-as-graph)
    - [Graph vs Tree Code Differences](#graph-vs-tree-code-differences)
    - [Preventing Cycles with `seen` Set](#preventing-cycles-with-seen-set)
    - [Graph Traversal Starting Point](#graph-traversal-starting-point)
  - [Graph Key Insights](#graph-key-insights)
  - [7.6 Graph DFS](#76-graph-dfs)
    - [DFS Implementation Patterns](#dfs-implementation-patterns)
      - [Recursive DFS Template](#recursive-dfs-template)
      - [Iterative DFS Template](#iterative-dfs-template)
    - [Time and Space Complexity](#time-and-space-complexity)
    - [Example 1: Number of Provinces (LeetCode 547)](#example-1-number-of-provinces-leetcode-547)
    - [Example 2: Number of Islands (LeetCode 200)](#example-2-number-of-islands-leetcode-200)
    - [Example 3: Reorder Routes (LeetCode 1466)](#example-3-reorder-routes-leetcode-1466)
    - [Example 4: Keys and Rooms (LeetCode 841)](#example-4-keys-and-rooms-leetcode-841)
    - [Example 5: Minimum Vertices to Reach All Nodes (LeetCode 1557)](#example-5-minimum-vertices-to-reach-all-nodes-leetcode-1557)
  - [Graph DFS Key Insights](#graph-dfs-key-insights)
  - [Graph DFS Pattern Recognition](#graph-dfs-pattern-recognition)
  - [DFS Code Checklist](#dfs-code-checklist)
  - [7.7 Graph BFS](#77-graph-bfs)
    - [When to Use BFS vs DFS on Graphs](#when-to-use-bfs-vs-dfs-on-graphs)
    - [BFS vs DFS Implementation Difference](#bfs-vs-dfs-implementation-difference)
    - [BFS Template for Graphs](#bfs-template-for-graphs)
    - [Time and Space Complexity](#time-and-space-complexity-1)
    - [Example 1: Shortest Path in Binary Matrix (LeetCode 1091)](#example-1-shortest-path-in-binary-matrix-leetcode-1091)
    - [Example 2: All Nodes Distance K in Binary Tree (LeetCode 863)](#example-2-all-nodes-distance-k-in-binary-tree-leetcode-863)
    - [Example 3: 01 Matrix (LeetCode 542)](#example-3-01-matrix-leetcode-542)
    - [State Variables in BFS](#state-variables-in-bfs)
    - [Example 4: Shortest Path with Obstacles Elimination (LeetCode 1293)](#example-4-shortest-path-with-obstacles-elimination-leetcode-1293)
    - [Example 5: Shortest Path with Alternating Colors (LeetCode 1129)](#example-5-shortest-path-with-alternating-colors-leetcode-1129)
  - [Graph BFS Key Insights](#graph-bfs-key-insights)
  - [BFS Pattern Recognition](#bfs-pattern-recognition)
  - [BFS Code Checklist](#bfs-code-checklist)
  - [BFS Implementation Tips](#bfs-implementation-tips)
  - [7.8 Implicit Graphs](#78-implicit-graphs)
    - [What Are Implicit Graphs?](#what-are-implicit-graphs)
    - [When to Recognize Implicit Graphs](#when-to-recognize-implicit-graphs)
    - [Implicit Graph vs Explicit Graph](#implicit-graph-vs-explicit-graph)
    - [Building Implicit Graphs](#building-implicit-graphs)
    - [Example 1: Open the Lock (LeetCode 752)](#example-1-open-the-lock-leetcode-752)
    - [Example 2: Evaluate Division (LeetCode 399)](#example-2-evaluate-division-leetcode-399)
  - [Implicit Graph Key Insights](#implicit-graph-key-insights)
  - [Implicit Graph Pattern Recognition](#implicit-graph-pattern-recognition)
  - [Common Implicit Graph Scenarios](#common-implicit-graph-scenarios)
    - [1. **Combinatorial States** (Lock, Puzzle)](#1-combinatorial-states-lock-puzzle)
    - [2. **String Transformations** (Word Ladder)](#2-string-transformations-word-ladder)
    - [3. **Mathematical Relationships** (Equations, Ratios)](#3-mathematical-relationships-equations-ratios)
    - [4. **Game States** (Chess, Tic-Tac-Toe)](#4-game-states-chess-tic-tac-toe)
  - [Implicit Graph Implementation Tips](#implicit-graph-implementation-tips)
  - [Implicit Graph Checklist](#implicit-graph-checklist)
- [Study Progress](#study-progress)
  - [✅ Completed Sections](#-completed-sections)
  - [🔄 Currently Studying](#-currently-studying)
  - [📋 Next Topics](#-next-topics)
- [Quick Reference](#quick-reference)
  - [Time Complexity Cheat Sheet](#time-complexity-cheat-sheet)
  - [Common Patterns Recognition](#common-patterns-recognition)
  - [Debugging Tips](#debugging-tips)
- [🎯 Study Tips](#-study-tips)

---

## 1. Introduction

### What You'll Learn

- Understanding algorithms and their fundamental properties
- Big O notation and complexity analysis
- Time and space complexity calculations

### Key Concepts

#### Algorithm Fundamentals

- **Definition**: A set of step-by-step instructions for solving a problem
- **Requirements**:
  - Deterministic (same input → same output)
  - Correct for any valid input
  - Finite execution time

#### Big O Notation

Big O describes the computational complexity of algorithms:

| Complexity | Name | Description | Example |
|------------|------|-------------|---------|
| O(1) | Constant | Same time regardless of input size | Array access |
| O(log n) | Logarithmic | Very fast, input reduced by percentage each step | Binary search |
| O(n) | Linear | Time grows proportionally with input | Single loop |
| O(n log n) | Linearithmic | Efficient sorting algorithms | Merge sort |
| O(n²) | Quadratic | Nested loops | Bubble sort |
| O(2ⁿ) | Exponential | Very slow, avoid if possible | Naive recursion |

#### Analysis Rules

1. **Ignore constants**: O(5n) = O(n)
2. **Focus on dominant terms**: O(n² + n) = O(n²)
3. **Consider worst-case scenario** (unless specified otherwise)

### Time Complexity Examples

```csharp
// O(n) - Linear time
for (int i = 0; i < n; i++) {
    Console.WriteLine(arr[i]);
}

// O(n²) - Quadratic time  
for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
        Console.WriteLine(arr[i] * arr[j]);
    }
}

// O(log n) - Logarithmic time
// Binary search: input halved each step
```

### Space Complexity

- **Don't count**: Input space, output space (unless specified)
- **Do count**: Additional variables, data structures created

---

## 2. Recursion

### Learning Objectives

- Recursive problem-solving approach
- Base cases and recursive cases
- Function call stack understanding

### Core Concepts

#### Recursion Fundamentals

- **Definition**: A function that calls itself to solve smaller subproblems
- **Alternative to**: Iterative approaches (loops)
- **Equivalence**: Any iterative algorithm can be written recursively

#### Essential Components

1. **Base Case**: Condition that stops the recursion
2. **Recursive Case**: Function calls itself with modified parameters
3. **Progress**: Each call should move closer to the base case

#### Execution Order

```csharp
function fn(i):
    if i > 3: return          // Base case
    
    print(i)                  // Before recursive call
    fn(i + 1)                 // Recursive call
    print($"End of {i}")      // After recursive call

fn(1)
```

**Output:**

```text
1
2  
3
End of 3
End of 2
End of 1
```

#### Classic Example: Fibonacci

```csharp
F(n) = F(n-1) + F(n-2)  // Recurrence relation
F(0) = 0, F(1) = 1      // Base cases

function fibonacci(n):
    if n <= 1: return n
    return fibonacci(n-1) + fibonacci(n-2)
```

### Problem-Solving Strategy

1. **Identify the subproblem**: What smaller version can solve the original?
2. **Define base cases**: When should recursion stop?
3. **Express recurrence relation**: How do subproblems combine?
4. **Implement and test**: Verify with small examples

---

## 3. Arrays and Strings

### Learning Objectives

- Fundamental array and string operations
- Common algorithmic patterns
- Efficient problem-solving techniques

### Core Concepts

#### Arrays vs Strings

| Aspect | Arrays | Strings |
|--------|--------|---------|
| **Mutability** | Usually mutable | Language-dependent |
| **Access** | O(1) by index | O(1) by index |
| **Modification** | Direct assignment | May require recreation |
| **Memory** | Contiguous | Contiguous |

#### Time Complexity Reference

| Operation | Array/List | String |
|-----------|------------|--------|
| Access | O(1) | O(1) |
| Search | O(n) | O(n) |
| Insertion | O(n) | O(n) |
| Deletion | O(n) | O(n) |
| Append | O(1) amortized | O(n) if immutable |

### 3.1 Two Pointers Technique

#### Concept

Use two integer variables to traverse the array/string efficiently.

#### Two Main Patterns

**Pattern 1: Opposite Ends (Convergent)**

Start pointers at edges and move toward each other:

```csharp
function fn(arr):
    left = 0
    right = arr.length - 1

    while left < right:
        // Do logic based on problem
        // Decide to move:
        // 1. left++
        // 2. right--
        // 3. Both left++ and right--
```

**Pattern 2: Same Direction (Parallel)**

Move along multiple inputs simultaneously:

```csharp
function fn(arr1, arr2):
    i = j = 0
    while i < arr1.length AND j < arr2.length:
        // Do logic based on problem
        // Decide to move:
        // 1. i++
        // 2. j++
        // 3. Both i++ and j++

    // Handle remaining elements
    while i < arr1.length:
        // Process remaining arr1[i]
        i++

    while j < arr2.length:
        // Process remaining arr2[j]
        j++
```

**Time Complexity:** O(n) for single array, O(n+m) for two arrays  
**Space Complexity:** O(1)

#### Common Use Cases

- **Palindrome checking**: Compare characters from both ends
- **Two sum in sorted array**: Adjust pointers based on sum comparison
- **Merging sorted arrays**: Compare and choose smaller element
- **Subsequence validation**: Track progress through both strings

#### Example: Palindrome Check

```csharp
bool IsPalindrome(string s) {
    int left = 0, right = s.Length - 1;
    
    while (left < right) {
        if (s[left] != s[right]) return false;
        left++;
        right--;
    }
    return true;
}
```

### 3.2 Sliding Window

#### Concept

Maintain a "window" (subarray) that expands and contracts based on conditions.

#### General Template

```csharp
function fn(arr):
    left = 0, ans = 0
    for right in range(len(arr)):
        // Add arr[right] to window
        
        while WINDOW_IS_INVALID:
            // Remove arr[left] from window
            left++
        
        // Update answer with current valid window
        ans = max(ans, right - left + 1)  // for maximum window
```

#### Why Sliding Window is Efficient

**Total subarrays in array of length n:**

```
∑(k=1 to n) k = n(n+1)/2 = O(n²)
```

**Sliding window iterations:** Maximum 2n (right moves n times, left moves n times)
**Time Complexity:** O(n) vs O(n²) for brute force

#### Two Types of Sliding Window

**1. Variable Size Window**

Find optimal window size based on constraints:

```csharp
// Example: Longest subarray with sum ≤ k
var findLength = function(nums, k) {
    let left = 0, curr = 0, ans = 0;
    
    for (let right = 0; right < nums.length; right++) {
        curr += nums[right];  // Expand window
        
        while (curr > k) {    // Contract when invalid
            curr -= nums[left];
            left++;
        }
        
        ans = Math.max(ans, right - left + 1);
    }
    return ans;
}
```

**2. Fixed Size Window**

Window size k is predetermined:

```csharp
function fn(arr, k):
    curr = // track window state
    
    // Build first window
    for (int i = 0; i < k; i++)
        curr += arr[i]  // or other logic
    
    ans = curr
    for (int i = k; i < arr.length; i++)
        curr += arr[i] - arr[i - k]  // slide window
        ans = max(ans, curr)
    
    return ans
```

#### Common Patterns

- **Constraint-based**: "Sum ≤ k", "At most k distinct elements"
- **Optimization**: "Longest/shortest valid subarray"
- **Counting**: "Number of valid subarrays"

### 3.3 Prefix Sum

#### Concept

Pre-compute cumulative sums to answer range queries in O(1).

#### Mathematical Foundation

For array `nums = [a₀, a₁, a₂, ..., aₙ₋₁]`:

```
prefix[i] = nums[0] + nums[1] + ... + nums[i]
```

**Range sum formula:**

```
sum(i, j) = prefix[j] - prefix[i] + nums[i]  
// works for all cases, no boundary check needed
```

#### Implementation Patterns

**Standard Prefix Sum:**

```csharp
int[] BuildPrefixSum(int[] nums) {
    int[] prefix = new int[nums.Length];
    prefix[0] = nums[0];
    
    for (int i = 1; i < nums.Length; i++) {
        prefix[i] = prefix[i-1] + nums[i];
    }
    return prefix;
}

// Query sum from index i to j (inclusive)
int RangeSum(int[] prefix, int[] nums, int i, int j) {
    return prefix[j] - prefix[i] + nums[i];
}
```

**Space-Optimized Version:**

When processing sequentially, use running sum instead of array:

```csharp
var optimizedSolution = function(nums) {
    let leftSection = 0, total = 0;
    
    // Calculate total sum
    for (const num of nums) {
        total += num;
    }
    
    for (let i = 0; i < nums.length - 1; i++) {
        leftSection += nums[i];
        let rightSection = total - leftSection;
        // Process with O(1) space
    }
}
```

#### Complexity Analysis

- **Preprocessing:** O(n) time, O(n) space
- **Range Queries:** O(1) time per query
- **Overall Improvement:** Factor of O(n) for multiple queries

#### Common Applications

- **Subarray sum problems**: "Find subarrays with sum = k"
- **Range queries**: "Sum between indices i and j"
- **Split problems**: "Valid ways to split array"
- **2D matrices**: Extend to 2D prefix sums

---

## 3.4 Subarrays, Subsequences, and Subsets

Understanding the differences between these concepts is crucial for choosing the right algorithmic approach.

### Definitions and Key Differences

#### Subarrays/Substrings

**Definition:** A contiguous section of an array or string.

**Examples:** For array `[1, 2, 3, 4]`:

- Valid subarrays: `[1]`, `[2, 3]`, `[1, 2, 3]`, `[3, 4]`
- Invalid: `[1, 3]` (not contiguous), `[4, 2]` (wrong order)

**Key Properties:**

- **Contiguity**: Elements must be adjacent in original array
- **Order preserved**: Elements maintain their relative positions
- **Size formula**: Subarray from index i to j has size `j - i + 1`
- **Total count**: Array of length n has `n(n+1)/2` subarrays

#### Subsequences

**Definition:** A set of elements that maintains relative order but doesn't need to be contiguous.

**Examples:** For array `[1, 2, 3, 4]`:

- Valid subsequences: `[1, 3]`, `[2, 4]`, `[1, 2, 4]`, `[]`
- Invalid: `[3, 2]` (wrong relative order), `[5]` (element not in original)

**Key Properties:**

- **Order matters**: Relative order from original array must be preserved
- **Non-contiguous**: Elements can have gaps between them
- **Total count**: Array of length n has `2ⁿ` subsequences (each element can be included or excluded)

#### Subsets

**Definition:** Any collection of elements from the original array where order doesn't matter.

**Examples:** For array `[1, 2, 3, 4]`:

- Valid subsets: `{3, 2}`, `{4, 1, 2}`, `{1}`, `{}`
- Note: `{1, 2, 4}` and `{4, 1, 2}` are considered the same subset

**Key Properties:**

- **Order irrelevant**: `{1, 2, 3}` = `{3, 1, 2}`
- **No duplicates**: Each element appears at most once
- **Total count**: Array of length n has `2ⁿ` subsets

### Comparison Table

| Aspect | Subarrays | Subsequences | Subsets |
|--------|-----------|-------------|---------|
| **Contiguous** | ✅ Required | ❌ Not required | ❌ Not required |
| **Order matters** | ✅ Yes | ✅ Yes (relative) | ❌ No |
| **Count for array[n]** | n(n+1)/2 | 2ⁿ | 2ⁿ |
| **Can sort input** | ❌ No | ❌ No | ✅ Yes |

### Common Patterns and Solutions

#### For Subarrays/Substrings

**When to use:**

- Problems mention "contiguous" elements
- Constraints like "sum ≤ k", "at most k unique elements"
- Looking for min/max length or count

**Common Techniques:**

```csharp
// Sliding Window - Variable size
int FindLongestSubarray(int[] nums, int k) {
    int left = 0, sum = 0, maxLen = 0;
    
    for (int right = 0; right < nums.Length; right++) {
        sum += nums[right];
        
        while (sum > k) {
            sum -= nums[left];
            left++;
        }
        
        maxLen = Math.Max(maxLen, right - left + 1);
    }
    return maxLen;
}

// Prefix Sum - Range queries
int[] BuildPrefixSum(int[] nums) {
    int[] prefix = new int[nums.Length];
    prefix[0] = nums[0];
    
    for (int i = 1; i < nums.Length; i++) {
        prefix[i] = prefix[i-1] + nums[i];
    }
    return prefix;
}
```

**Pattern Recognition:**

- "Subarray with sum equal to k" → Prefix Sum + HashMap
- "Longest subarray with constraint" → Sliding Window
- "Number of subarrays with property" → Sliding Window or Prefix Sum

#### For Subsequences

**When to use:**

- Order matters but contiguity doesn't
- Two arrays/strings comparison problems
- "Is X a subsequence of Y?" type questions

**Common Techniques:**

```csharp
// Two Pointers - Check if s is subsequence of t
bool IsSubsequence(string s, string t) {
    int i = 0, j = 0;
    
    while (i < s.Length && j < t.Length) {
        if (s[i] == t[j]) {
            i++;  // Move in s only when match found
        }
        j++;      // Always move in t
    }
    
    return i == s.Length;  // Found all characters of s
}

// Dynamic Programming - Longest Common Subsequence
int LCS(string text1, string text2) {
    int m = text1.Length, n = text2.Length;
    int[,] dp = new int[m + 1, n + 1];
    
    for (int i = 1; i <= m; i++) {
        for (int j = 1; j <= n; j++) {
            if (text1[i-1] == text2[j-1]) {
                dp[i,j] = dp[i-1,j-1] + 1;
            } else {
                dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
            }
        }
    }
    return dp[m,n];
}
```

**Pattern Recognition:**

- "Is subsequence" → Two Pointers
- "Longest common subsequence" → Dynamic Programming
- "Count subsequences with property" → Dynamic Programming

#### For Subsets

**When to use:**

- Order doesn't matter
- Need all possible combinations
- Can modify/sort input array

**Common Techniques:**

```csharp
// Backtracking - Generate all subsets
IList<IList<int>> Subsets(int[] nums) {
    var result = new List<IList<int>>();
    var current = new List<int>();
    
    void Backtrack(int start) {
        result.Add(new List<int>(current));  // Add current subset
        
        for (int i = start; i < nums.Length; i++) {
            current.Add(nums[i]);       // Include element
            Backtrack(i + 1);           // Recurse
            current.RemoveAt(current.Count - 1);  // Backtrack
        }
    }
    
    Backtrack(0);
    return result;
}

// Bit Manipulation - Generate all subsets
IList<IList<int>> SubsetsBitwise(int[] nums) {
    var result = new List<IList<int>>();
    int n = nums.Length;
    
    for (int mask = 0; mask < (1 << n); mask++) {
        var subset = new List<int>();
        for (int i = 0; i < n; i++) {
            if ((mask & (1 << i)) != 0) {
                subset.Add(nums[i]);
            }
        }
        result.Add(subset);
    }
    return result;
}
```

**Pattern Recognition:**

- "All possible subsets" → Backtracking or Bit Manipulation
- "Subset with target sum" → Dynamic Programming or Backtracking
- "K-size subsets" → Combinations (Backtracking)

### Problem Type Recognition Guide

| Problem Statement Contains | Likely Type | Suggested Approach |
|---------------------------|-------------|-------------------|
| "contiguous", "subarray", "substring" | Subarray | Sliding Window, Prefix Sum |
| "subsequence", "relative order" | Subsequence | Two Pointers, DP |
| "subset", "combination", "any order" | Subset | Backtracking, Bit Manipulation |
| "sum equals k" (contiguous) | Subarray | Prefix Sum + HashMap |
| "longest common" | Subsequence | Dynamic Programming |
| "all possible" | Subset | Backtracking |

### Key Insights

1. **Subarray problems** often use Sliding Window or Prefix Sum due to contiguity
2. **Subsequence problems** commonly require Dynamic Programming for optimization
3. **Subset problems** allow input sorting since order doesn't matter
4. **When order doesn't matter** in subsequence problems, treat as subset problems

---

## 4. Hashing

### Learning Objectives

- Understand hash maps and sets fundamentals
- Master existence checking patterns
- Learn counting and frequency tracking techniques
- Apply hashing to improve algorithm efficiency

### Hash Maps and Sets Fundamentals

#### What is Hashing?

**Hash Function**: A function that converts any input (key) into an integer within a fixed range.

**Hash Map (Dictionary)**: Data structure that stores key-value pairs using hashing.

- **Keys**: Can be almost any immutable type (strings, numbers, tuples)
- **Values**: Can be any data type
- **Time Complexity**: O(1) for add, remove, update, and lookup operations

**Set**: Similar to hash map but only stores keys (no values).

- **Purpose**: Check existence and eliminate duplicates
- **Time Complexity**: O(1) for add, remove, and lookup operations

#### Hash Map vs Array Comparison

| Operation | Hash Map | Array |
|-----------|----------|-------|
| **Access by key/index** | O(1) | O(1) |
| **Search for value** | O(1) if you have key | O(n) |
| **Insert** | O(1) | O(n) for arbitrary position |
| **Delete** | O(1) | O(n) for arbitrary position |
| **Space overhead** | Higher (hash table overhead) | Lower |
| **Key constraints** | Any immutable type | Integer indices only |

#### When to Use Hash Maps

✅ **Use hash maps when:**

- Need to check if elements exist
- Need to count frequencies
- Want to map relationships between data
- Need to eliminate duplicates
- Working with non-integer keys

❌ **Avoid hash maps when:**

- Input size is very small (overhead not worth it)
- Need to maintain order (unless language provides ordered maps)
- Memory is extremely constrained

### 4.1 Checking for Existence

#### Core Concept

Convert O(n) existence checks to O(1) using hash maps/sets, often improving overall time complexity from O(n²) to O(n).

#### Common Pattern Template

```csharp
// Pattern: Two Sum type problems
var twoSum = function(nums, target) {
    var seen = new Dictionary<int, int>();  // value -> index
    
    for (int i = 0; i < nums.Length; i++) {
        int complement = target - nums[i];
        
        if (seen.ContainsKey(complement)) {
            return new int[] { seen[complement], i };
        }
        
        seen[nums[i]] = i;
    }
    
    return new int[] { -1, -1 };
}

// Pattern: Existence checking
var checkExistence = function(nums) {
    var numSet = new HashSet<int>(nums);  // Preprocessing
    
    foreach (int num in nums) {
        if (numSet.Contains(num + 1) && numSet.Contains(num - 1)) {
            // Found what we're looking for
        }
    }
}
```

#### Key Applications

**1. Two Sum Problems**

- Use hash map to store seen values and their indices
- Check for complement in O(1) time

**2. Duplicate Detection**

- Add elements to set as you iterate
- If element already exists, you found a duplicate

**3. Intersection Problems**

- Convert one array to set for O(1) lookups
- Check existence of elements from other arrays

**4. Complement Finding**

- Store elements in hash map/set
- For each element, check if its complement exists

### 4.2 Counting Patterns

#### Core Concept

Use hash maps to count frequencies of elements, enabling constraint-based problems and frequency analysis.

#### Frequency Counting Template

```csharp
// Basic frequency counting
var countFrequencies = function(items) {
    var counts = new Dictionary<string, int>();
    
    foreach (var item in items) {
        counts[item] = counts.GetValueOrDefault(item, 0) + 1;
    }
    
    return counts;
}

// Sliding window with frequency constraints
var slidingWindowWithCounting = function(s, k) {
    var counts = new Dictionary<char, int>();
    int left = 0, result = 0;
    
    for (int right = 0; right < s.Length; right++) {
        // Add current character
        counts[s[right]] = counts.GetValueOrDefault(s[right], 0) + 1;
        
        // Shrink window if constraint violated
        while (counts.Count > k) {  // More than k distinct characters
            counts[s[left]]--;
            if (counts[s[left]] == 0) {
                counts.Remove(s[left]);
            }
            left++;
        }
        
        result = Math.Max(result, right - left + 1);
    }
    
    return result;
}
```

#### Advanced Counting Patterns

**1. Frequency-Based Constraints**

```csharp
// Check if all characters have equal frequency
bool AllEqualFrequency(string s) {
    var counts = new Dictionary<char, int>();
    
    // Count frequencies
    foreach (char c in s) {
        counts[c] = counts.GetValueOrDefault(c, 0) + 1;
    }
    
    // Check if all frequencies are the same
    var frequencies = new HashSet<int>(counts.Values);
    return frequencies.Count == 1;
}
```

**2. Multi-Array Intersection**

```csharp
// Find elements that appear in all arrays
List<int> IntersectionOfArrays(int[][] arrays) {
    var counts = new Dictionary<int, int>();
    
    // Count occurrences across all arrays
    foreach (var array in arrays) {
        foreach (int num in array) {
            counts[num] = counts.GetValueOrDefault(num, 0) + 1;
        }
    }
    
    // Find elements that appear in all arrays
    var result = new List<int>();
    foreach (var kvp in counts) {
        if (kvp.Value == arrays.Length) {
            result.Add(kvp.Key);
        }
    }
    
    result.Sort();
    return result;
}
```

#### Complexity Analysis

**Time Complexity:**

- Building frequency map: O(n)
- Checking constraints: O(1) per operation
- Overall: Usually O(n) instead of O(n²)

**Space Complexity:**

- O(k) where k is number of distinct elements
- In worst case: O(n) where all elements are unique

#### Common Counting Applications

1. **Character/Element Frequency**: Count how often each element appears
2. **Sliding Window with Constraints**: Maintain frequency while sliding window
3. **Anagram Detection**: Compare character frequency maps
4. **Intersection Problems**: Count occurrences across multiple collections
5. **Frequency-Based Filtering**: Find elements that meet frequency criteria

### Key Insights

1. **Hash maps trade space for time**: Convert O(n) searches to O(1)
2. **Preprocessing**: Build hash map once, use multiple times efficiently
3. **Frequency tracking**: Essential for constraint-based problems
4. **Sliding window enhancement**: Hash maps enable multi-element constraints
5. **Set vs Map**: Use sets for existence, maps for counting/relationships

### 4.3 More Hashing Patterns

Advanced hashing patterns for complex grouping, optimization, and data transformation problems.

#### Group Identification Patterns

**Pattern: Use characteristic properties as hash keys**

Example: Group Anagrams

```csharp
public IList<IList<string>> GroupAnagrams(string[] strs) {
    var groups = new Dictionary<string, List<string>>();
    
    foreach (string str in strs) {
        char[] chars = str.ToCharArray();
        Array.Sort(chars);
        string key = new string(chars);
        
        if (!groups.ContainsKey(key)) {
            groups[key] = new List<string>();
        }
        groups[key].Add(str);
    }
    
    return groups.Values.Cast<IList<string>>().ToList();
}
```

**Key Insight**: Use sorted string as canonical form for anagram identification.

#### Distance and Proximity Problems

**Pattern: Track elements to find minimum distances**

Example: Minimum Consecutive Cards (Basic Version)

```csharp
public int MinimumCardPickup(int[] cards) {
    var seen = new Dictionary<int, int>();
    int minDist = int.MaxValue;
    
    for (int i = 0; i < cards.Length; i++) {
        if (seen.ContainsKey(cards[i])) {
            minDist = Math.Min(minDist, i - seen[cards[i]] + 1);
        }
        seen[cards[i]] = i;
    }
    
    return minDist == int.MaxValue ? -1 : minDist;
}
```

**Optimization**: Track only the most recent occurrence to reduce space complexity for problems with many duplicates.

```csharp
public int MinimumCardPickupOptimized(int[] cards) {
    var lastSeen = new Dictionary<int, int>();
    int minDist = int.MaxValue;
    
    for (int i = 0; i < cards.Length; i++) {
        if (lastSeen.ContainsKey(cards[i])) {
            minDist = Math.Min(minDist, i - lastSeen[cards[i]] + 1);
        }
        lastSeen[cards[i]] = i;
    }
    
    return minDist == int.MaxValue ? -1 : minDist;
}
```

#### Digit Sum Grouping

**Pattern: Group numbers by computed properties**

Example: Max Sum of Equal Digit Sum Numbers

```csharp
public int MaximumSum(int[] nums) {
    var groups = new Dictionary<int, List<int>>();
    
    foreach (int num in nums) {
        int digitSum = GetDigitSum(num);
        
        if (!groups.ContainsKey(digitSum)) {
            groups[digitSum] = new List<int>();
        }
        groups[digitSum].Add(num);
    }
    
    int maxSum = -1;
    foreach (var group in groups.Values) {
        if (group.Count >= 2) {
            group.Sort((a, b) => b.CompareTo(a));
            maxSum = Math.Max(maxSum, group[0] + group[1]);
        }
    }
    
    return maxSum;
}

private int GetDigitSum(int num) {
    int sum = 0;
    while (num > 0) {
        sum += num % 10;
        num /= 10;
    }
    return sum;
}
```

**Optimization**: Track only the two largest numbers per group instead of storing all numbers.

```csharp
public int MaximumSumOptimized(int[] nums) {
    var maxTwo = new Dictionary<int, (int first, int second)>();
    
    foreach (int num in nums) {
        int digitSum = GetDigitSum(num);
        
        if (!maxTwo.ContainsKey(digitSum)) {
            maxTwo[digitSum] = (num, -1);
        } else {
            var (first, second) = maxTwo[digitSum];
            if (num > first) {
                maxTwo[digitSum] = (num, first);
            } else if (num > second) {
                maxTwo[digitSum] = (first, num);
            }
        }
    }
    
    int maxSum = -1;
    foreach (var (first, second) in maxTwo.Values) {
        if (second != -1) {
            maxSum = Math.Max(maxSum, first + second);
        }
    }
    
    return maxSum;
}
```

#### Array Conversion for Hashing

**Pattern: Convert arrays to strings for use as hash keys**

Example: Equal Row and Column Pairs

```csharp
public int EqualPairs(int[][] grid) {
    var rowMap = new Dictionary<string, int>();
    int n = grid.Length;
    
    // Count rows
    for (int i = 0; i < n; i++) {
        string rowKey = string.Join(",", grid[i]);
        rowMap[rowKey] = rowMap.GetValueOrDefault(rowKey, 0) + 1;
    }
    
    // Check columns against rows
    int count = 0;
    for (int j = 0; j < n; j++) {
        var column = new int[n];
        for (int i = 0; i < n; i++) {
            column[i] = grid[i][j];
        }
        
        string colKey = string.Join(",", column);
        if (rowMap.ContainsKey(colKey)) {
            count += rowMap[colKey];
        }
    }
    
    return count;
}
```

**Key Insight**: Convert arrays to comma-separated strings to enable hash table lookups for equality comparison.

**Complexity Considerations**:

- Time: O(n²) for grid traversal + O(n) for string operations per row/column
- Space: O(n²) for storing all row strings
- Alternative: Use tuple conversion for better performance in some languages

---

## 5. LinkedLists

### Learning Objectives

- Master linked list fundamentals and pointer manipulation
- Understand different types of linked lists (singly, doubly, with sentinels)
- Apply two-pointer techniques for cycle detection and traversal
- Implement efficient linked list reversal algorithms

### 5.1 Introduction

#### Node Structure and Basic Operations

**What is a Linked List?**

A linked list is a linear data structure where elements are stored in nodes, and each node contains:

- **Data**: The actual value (integer, string, etc.)
- **Next pointer**: Reference to the next node in the sequence

```csharp
public class ListNode {
    public int val;
    public ListNode next;
    
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}
```

**Basic Operations**:

```csharp
// Creating a linked list: 1 -> 2 -> 3
ListNode head = new ListNode(1);
head.next = new ListNode(2);
head.next.next = new ListNode(3);

// Traversal
public void PrintList(ListNode head) {
    ListNode current = head;
    while (current != null) {
        Console.Write(current.val + " -> ");
        current = current.next;
    }
    Console.WriteLine("null");
}
```

#### Types of Linked Lists

**1. Singly Linked List**

- Each node points to the next node
- Can only traverse forward
- Most common type used in interviews

**2. Doubly Linked List**

- Each node has both `next` and `prev` pointers
- Allows bidirectional traversal
- Useful for certain optimization problems

```csharp
public class DoublyListNode {
    public int val;
    public DoublyListNode next;
    public DoublyListNode prev;
    
    public DoublyListNode(int val = 0) {
        this.val = val;
        this.next = null;
        this.prev = null;
    }
}
```

**3. Linked Lists with Sentinel Nodes**

- Dummy head and tail nodes to simplify edge cases
- Makes insertion/deletion operations cleaner
- Reduces need for null checks

#### Advantages and Disadvantages

| Aspect | Linked List | Array |
|--------|-------------|-------|
| **Access by index** | O(n) - must traverse | O(1) - direct indexing |
| **Search** | O(n) - sequential search | O(n) - unless sorted |
| **Insertion at position** | O(1) with reference | O(n) - shifting required |
| **Deletion at position** | O(1) with reference | O(n) - shifting required |
| **Memory usage** | Higher (pointer overhead) | Lower (contiguous) |
| **Memory allocation** | Dynamic, as needed | Fixed size (static arrays) |

#### Pointer Manipulation Fundamentals

**Key Principles:**

1. **Assignment**: Variables point to objects in memory

```csharp
ListNode ptr = head;  // ptr points to same node as head
head = head.next;     // head moves, ptr stays at original node
```

2. **Safe Traversal**: Always check for null

```csharp
while (current != null && current.next != null) {
    // Safe to access current.next.next
    current = current.next;
}
```

3. **Insertion Pattern**: Save next before breaking links

```csharp
public void InsertAfter(ListNode node, int val) {
    ListNode newNode = new ListNode(val);
    newNode.next = node.next;  // Connect new node to rest of list
    node.next = newNode;       // Connect previous node to new node
}
```

4. **Deletion Pattern**: Bridge over node to delete

```csharp
public void DeleteNext(ListNode node) {
    if (node.next != null) {
        node.next = node.next.next;  // Skip over the node to delete
    }
}
```

### 5.2 Fast and Slow Pointers

#### Two Pointer Technique for LinkedLists

The fast and slow pointer technique (also called "tortoise and hare") uses two pointers moving at different speeds to solve various linked list problems efficiently.

**Basic Template:**

```csharp
public void FastSlowPattern(ListNode head) {
    ListNode slow = head;
    ListNode fast = head;
    
    while (fast != null && fast.next != null) {
        slow = slow.next;           // Move 1 step
        fast = fast.next.next;      // Move 2 steps
        
        // Process or check condition here
    }
}
```

#### Finding Middle Elements

**Problem**: Find the middle node of a linked list.

```csharp
public ListNode FindMiddle(ListNode head) {
    ListNode slow = head;
    ListNode fast = head;
    
    while (fast != null && fast.next != null) {
        slow = slow.next;
        fast = fast.next.next;
    }
    
    return slow;  // slow is at middle when fast reaches end
}
```

**Why it works**: When fast pointer travels 2n steps, slow pointer travels n steps, placing it at the middle.

#### Cycle Detection

**Problem**: Detect if a linked list has a cycle.

```csharp
public bool HasCycle(ListNode head) {
    if (head == null || head.next == null) return false;
    
    ListNode slow = head;
    ListNode fast = head;
    
    while (fast != null && fast.next != null) {
        slow = slow.next;
        fast = fast.next.next;
        
        if (slow == fast) {
            return true;  // Cycle detected
        }
    }
    
    return false;  // No cycle
}
```

**Alternative approach using HashSet** (uses O(n) space):

```csharp
public bool HasCycleWithSet(ListNode head) {
    HashSet<ListNode> seen = new HashSet<ListNode>();
    
    while (head != null) {
        if (seen.Contains(head)) {
            return true;
        }
        seen.Add(head);
        head = head.next;
    }
    
    return false;
}
```

#### Kth Node from End

**Problem**: Find the kth node from the end of the linked list.

```csharp
public ListNode FindKthFromEnd(ListNode head, int k) {
    ListNode fast = head;
    ListNode slow = head;
    
    // Move fast pointer k steps ahead
    for (int i = 0; i < k; i++) {
        if (fast == null) return null;  // List shorter than k
        fast = fast.next;
    }
    
    // Move both pointers until fast reaches end
    while (fast != null) {
        slow = slow.next;
        fast = fast.next;
    }
    
    return slow;  // slow is now k nodes from end
}
```

**Time Complexity**: O(n) where n is the length of the list
**Space Complexity**: O(1)

### 5.3 Reversing LinkedLists

#### Basic Reversal Algorithm

**Problem**: Reverse a singly linked list.

**Approach**: Use three pointers to iteratively reverse the direction of links.

```csharp
public ListNode ReverseList(ListNode head) {
    ListNode prev = null;
    ListNode current = head;
    
    while (current != null) {
        ListNode nextTemp = current.next;  // Save next node
        current.next = prev;               // Reverse the link
        prev = current;                    // Move prev forward
        current = nextTemp;                // Move current forward
    }
    
    return prev;  // prev is the new head
}
```

**Step-by-step visualization** for `1 -> 2 -> 3 -> null`:

```
Initial:  prev=null, current=1->2->3->null

Step 1:   prev=null, current=1, nextTemp=2->3->null
          After reversal: null<-1  2->3->null
          
Step 2:   prev=1, current=2, nextTemp=3->null  
          After reversal: null<-1<-2  3->null
          
Step 3:   prev=2, current=3, nextTemp=null
          After reversal: null<-1<-2<-3  current=null
          
Result:   3->2->1->null (prev=3 is new head)
```

#### Swapping Node Pairs

**Problem**: Swap every two adjacent nodes.
Example: `1->2->3->4` becomes `2->1->4->3`

```csharp
public ListNode SwapPairs(ListNode head) {
    // Edge case: 0 or 1 nodes
    if (head == null || head.next == null) {
        return head;
    }
    
    ListNode dummy = head.next;  // New head will be original second node
    ListNode prev = null;
    
    while (head != null && head.next != null) {
        ListNode nextPair = head.next.next;  // Save reference to next pair
        
        // Connect previous pair to current second node
        if (prev != null) {
            prev.next = head.next;
        }
        
        // Swap the pair
        head.next.next = head;
        head.next = nextPair;
        
        // Move to next pair
        prev = head;
        head = nextPair;
    }
    
    return dummy;
}
```

#### Partial Reversals

**Advanced Pattern**: Reverse only a portion of the linked list.

**Example**: Reverse nodes from position left to right.

```csharp
public ListNode ReverseBetween(ListNode head, int left, int right) {
    if (left == right) return head;
    
    ListNode dummy = new ListNode(0);
    dummy.next = head;
    ListNode prev = dummy;
    
    // Move to the node before the left position
    for (int i = 1; i < left; i++) {
        prev = prev.next;
    }
    
    // Start reversing from left position
    ListNode current = prev.next;
    for (int i = left; i < right; i++) {
        ListNode nextNode = current.next;
        current.next = nextNode.next;
        nextNode.next = prev.next;
        prev.next = nextNode;
    }
    
    return dummy.next;
}
```

**Key Insights**:

1. **Dummy nodes** simplify edge cases (especially when head might change)
2. **Three-pointer technique** is fundamental for most reversal problems
3. **Save references** before breaking links to avoid losing parts of the list
4. **Iterative solutions** are generally preferred over recursive for space efficiency

---

## 6. Stacks and Queues

### Learning Objectives

- Understand stack and queue fundamentals and their interfaces
- Recognize LIFO (Last In First Out) patterns in problems
- Apply stacks to string matching and processing problems
- Master stack-based algorithms for parentheses validation and character matching

### 6.1 Introduction to Stacks

#### What is a Stack?

A **stack** is an ordered collection of elements where elements are only added and removed from the same end. This is known as **LIFO (Last In, First Out)** - the last (most recent) element placed inside is the first element to come out.

**Physical World Example**: A stack of plates in a kitchen - you add plates or remove plates from the top of the pile.

**Software Example**: Browser history - when you click a link, you add to the stack. When you click back, you remove from the stack.

- Site A → click link → [A, B]
- Site B → click link → [A, B, C]
- Click back → [A, B]
- Click back → [A]

#### Stack Operations

Stacks are very simple to implement. Common operations include:

- **Push**: Add an element to the top of the stack
- **Pop**: Remove and return the top element
- **Peek**: Look at the element at the top without removing it
- **IsEmpty**: Check if the stack is empty
- **Size**: Get the number of elements in the stack

**Time Complexity**: All basic operations are O(1) when implemented with a dynamic array.

| Operation | Time Complexity |
|-----------|-----------------|
| Push | O(1) |
| Pop | O(1) |
| Peek | O(1) |
| Search | O(n) |
| Random Access | O(1) with array implementation |

#### Implementation in C#

```csharp
// Declaration: use a List or Stack<T>
var stack = new Stack<int>();

// Pushing elements:
stack.Push(1);
stack.Push(2);
stack.Push(3);

// Popping elements:
stack.Pop(); // 3
stack.Pop(); // 2

// Check if empty:
if (stack.Count == 0) {
    Console.WriteLine("Stack is empty!");
}

// Check element at top (peek):
if (stack.Count > 0) {
    Console.WriteLine($"Top element: {stack.Peek()}");
}

// Get size:
int size = stack.Count;
```

**Alternative: Using List as Stack**

```csharp
// Using List<T> for more flexibility
var stack = new List<int>();

// Pushing elements:
stack.Add(1);
stack.Add(2);
stack.Add(3);

// Popping elements:
int top = stack[stack.Count - 1];  // Peek
stack.RemoveAt(stack.Count - 1);   // Pop

// Check if empty:
bool isEmpty = stack.Count == 0;

// Check element at top:
if (stack.Count > 0) {
    int topElement = stack[stack.Count - 1];
}
```

#### The Characteristic of a Stack

The key characteristic that makes something a "stack" is that you can **only add and remove elements from the same end**. It doesn't matter how you implement it - a "stack" is just an abstract interface.

**Implementation Options**:
- Dynamic array (most common)
- Linked list with tail pointer
- Built-in Stack class (C#, Java)

#### Stacks and Recursion

Stacks and recursion are very similar because **recursion is actually implemented using a stack**. Function calls are pushed onto the call stack. The call at the top of the stack at any given moment is the "active" call. On a return statement or when the end of the function is reached, the current call is popped off the stack.

#### When to Use Stacks

For algorithm problems, a stack is a good option whenever you can recognize the **LIFO pattern**. Usually, there will be some component of the problem that involves elements in the input interacting with each other:

- **Matching elements together** (e.g., parentheses)
- **Querying properties** (e.g., "how far is the next largest element?")
- **Evaluating expressions** (e.g., mathematical equations as strings)
- **Comparing elements** against each other
- Any other **abstract interaction** following LIFO order

Sometimes the LIFO property is hard to see, but recognizing it is key to identifying stack-based solutions.

### 6.2 String Problems with Stacks

String questions involving stacks are popular interview topics. Normally, string questions that can utilize a stack will involve:

1. **Iterating over the string**
2. **Putting characters into the stack**
3. **Comparing the top of the stack with the current character** at each iteration

Stacks are useful for string matching because they save a "history" of the previous characters.

#### Example 1: Valid Parentheses (LeetCode 20)

**Problem**: Given a string `s` containing just the characters `'('`, `')'`, `'{'`, `'}'`, `'['` and `']'`, determine if the input string is valid. The string is valid if all open brackets are closed by the same type of closing bracket in the correct order, and each closing bracket closes exactly one open bracket.

**Examples**:
- Valid: `"({})"`, `"(){}[]"`
- Invalid: `"(]"`, `"({)}"`

**Key Insight**: The "correct" order is determined by the most recent opening bracket - this is LIFO behavior, perfect for a stack!

**Algorithm**:

1. Iterate over the string
2. If we see an opening bracket → push it onto the stack
3. If we see a closing bracket:
   - Pop from the stack to get the most recent opening bracket
   - Check if it matches (use a hash map to associate brackets)
   - If no match or stack is empty → string is invalid
4. At the end, the stack should be empty (all brackets matched)

```csharp
public bool IsValid(string s) {
    var stack = new Stack<char>();
    var matching = new Dictionary<char, char> {
        {'(', ')'},
        {'[', ']'},
        {'{', '}'}
    };
    
    foreach (char c in s) {
        if (matching.ContainsKey(c)) {
            // Opening bracket
            stack.Push(c);
        } else {
            // Closing bracket
            if (stack.Count == 0) {
                return false;  // No matching opening bracket
            }
            
            char previousOpening = stack.Pop();
            if (matching[previousOpening] != c) {
                return false;  // Mismatched brackets
            }
        }
    }
    
    return stack.Count == 0;  // All brackets should be matched
}
```

**Complexity**:
- **Time**: O(n) - each element can only be pushed or popped once
- **Space**: O(n) - stack can grow linearly with input size

**Key to Recognition**: The problem follows a LIFO nature where the last (most recent) opening bracket is the first to be closed.

#### Example 2: Remove All Adjacent Duplicates (LeetCode 1047)

**Problem**: You are given a string `s`. Continuously remove duplicates (two of the same character beside each other) until you can't anymore. Return the final string.

**Example**: Given `s = "abbaca"`:
1. Remove "bb" → `"aaca"`
2. Remove "aa" → `"ca"`
3. Final answer: `"ca"`

**Challenge**: Not all removals are available at the start. Some characters need to be deleted before others can be matched.

**Example**: `s = "abccba"`
- Deletion order: c → b → a (LIFO pattern!)
- As we delete characters, previously separated characters become adjacent

**Algorithm**: Use a stack to maintain history of characters that are "in the way" of each other.

```csharp
public string RemoveDuplicates(string s) {
    var stack = new Stack<char>();
    
    foreach (char c in s) {
        if (stack.Count > 0 && stack.Peek() == c) {
            stack.Pop();  // Remove duplicate
        } else {
            stack.Push(c);  // Add to history
        }
    }
    
    // Convert stack to string (reverse order)
    return new string(stack.Reverse().ToArray());
}
```

**Alternative using StringBuilder (more efficient for string building)**:

```csharp
public string RemoveDuplicatesOptimized(string s) {
    var stack = new StringBuilder();
    
    foreach (char c in s) {
        if (stack.Length > 0 && stack[stack.Length - 1] == c) {
            stack.Length--;  // Remove last character
        } else {
            stack.Append(c);
        }
    }
    
    return stack.ToString();
}
```

**Complexity**:
- **Time**: O(n) - single pass through the string
- **Space**: O(n) - stack can grow to size of input

**Key Insight**: The most recently seen character is the first one that needs to be deleted when a match is found.

#### Example 3: Backspace String Compare (LeetCode 844)

**Problem**: Given two strings `s` and `t`, return `true` if they are equal when both are typed into empty text editors. `'#'` means a backspace character.

**Example**: Given `s = "ab#c"` and `t = "ad#c"`:
- After processing: both become `"ac"`
- Return: `true`

**Recognition**: Backspace follows the LIFO pattern - the most recently typed character is the first to be deleted.

**Algorithm**: Simulate typing with a stack. Push characters onto the stack, and pop when encountering a backspace.

```csharp
public bool BackspaceCompare(string s, string t) {
    return BuildString(s) == BuildString(t);
}

private string BuildString(string str) {
    var stack = new Stack<char>();
    
    foreach (char c in str) {
        if (c != '#') {
            stack.Push(c);
        } else if (stack.Count > 0) {
            stack.Pop();  // Backspace: remove last character
        }
    }
    
    return new string(stack.Reverse().ToArray());
}
```

**Alternative using StringBuilder**:

```csharp
public bool BackspaceCompareOptimized(string s, string t) {
    return BuildStringOptimized(s) == BuildStringOptimized(t);
}

private string BuildStringOptimized(string str) {
    var result = new StringBuilder();
    
    foreach (char c in str) {
        if (c != '#') {
            result.Append(c);
        } else if (result.Length > 0) {
            result.Length--;  // Backspace
        }
    }
    
    return result.ToString();
}
```

**Complexity**:
- **Time**: O(n + m) - where n and m are the lengths of the strings
- **Space**: O(n + m) - for the stacks/string builders

**Edge Cases to Consider**:
1. Backspace on empty string (e.g., `"#abc"`)
2. Multiple consecutive backspaces (e.g., `"ab###c"`)
3. All characters deleted (e.g., `"abc###"`)

### Key Insights for Stack Problems

1. **LIFO Recognition**: Look for patterns where the most recent element needs to be processed first
2. **String Matching**: Stacks excel at problems involving character matching and adjacency
3. **History Tracking**: Use stacks to maintain a "memory" of previous elements
4. **Efficiency**: Stack operations are O(1), enabling O(n) solutions for many problems
5. **Implementation Flexibility**: Can use built-in Stack, List, or StringBuilder depending on needs

### Common Stack Problem Patterns

| Pattern | Characteristics | Examples |
|---------|----------------|----------|
| **Bracket Matching** | Pairs must match in order | Valid parentheses |
| **Adjacent Removal** | Remove consecutive duplicates | Remove duplicates |
| **Character Processing** | Process with backspace/delete | Backspace compare |
| **Next Greater Element** | Find next larger element | Monotonic stack |
| **Expression Evaluation** | Evaluate postfix/prefix | Calculator problems |

### 6.3 Queues

#### What is a Queue?

While a stack follows **LIFO (Last In First Out)**, a queue follows **FIFO (First In First Out)**. In a stack, elements are added and removed from the same side. In a queue, elements are added and removed from **opposite sides**.

**Physical World Example**: A line at a fast food restaurant - people leave from the front after ordering and people enter from the back.

**Software Example**: Job scheduling systems that handle tasks on a first-come, first-serve basis (e.g., printer queue).

#### Queue Operations

- **Enqueue**: Add an element to the back of the queue
- **Dequeue**: Remove and return the element from the front
- **Peek/Front**: Look at the front element without removing it
- **IsEmpty**: Check if the queue is empty
- **Size**: Get the number of elements in the queue

**Time Complexity**: O(1) for all operations when using an efficient implementation (doubly linked list or deque).

| Operation | Array Implementation | Deque Implementation |
|-----------|---------------------|---------------------|
| Enqueue (back) | O(1) amortized | O(1) |
| Dequeue (front) | O(n) | O(1) |
| Peek | O(1) | O(1) |

#### Efficient Queue Implementation

To achieve O(1) operations, use a **doubly linked list** with pointers to both head and tail. This allows:
- O(1) addition at the tail (enqueue)
- O(1) removal from the head (dequeue)

**Deque (Double-Ended Queue)**: A more flexible data structure that allows addition and removal from both ends in O(1) time.

#### Implementation in C#

```csharp
// Using Queue<T>
var queue = new Queue<int>();

// Enqueuing elements:
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

// Dequeuing elements:
int first = queue.Dequeue();  // 1
int second = queue.Dequeue(); // 2

// Check element at front:
if (queue.Count > 0) {
    int front = queue.Peek();  // 3
}

// Check if empty:
bool isEmpty = queue.Count == 0;

// Get size:
int size = queue.Count;
```

#### When to Use Queues

Queues are less common than stacks in algorithm problems but are essential for:
- **Breadth-First Search (BFS)** in trees and graphs
- **Level-order traversal** in trees
- **Sliding window** with specific removal patterns
- **Task scheduling** and processing in order

#### Example: Number of Recent Calls (LeetCode 933)

**Problem**: Implement `RecentCounter` class that supports `ping(int t)`, which records a call at time `t` and returns the number of calls in the range `[t - 3000, t]`. Calls have increasing `t`.

**Approach**: Use a queue to store timestamps, removing outdated ones (older than 3000 time units).

```csharp
public class RecentCounter {
    private Queue<int> queue;
    
    public RecentCounter() {
        queue = new Queue<int>();
    }
    
    public int Ping(int t) {
        // Remove all timestamps older than t - 3000
        while (queue.Count > 0 && queue.Peek() < t - 3000) {
            queue.Dequeue();
        }
        
        // Add current timestamp
        queue.Enqueue(t);
        
        // Return count of calls in valid range
        return queue.Count;
    }
}
```

**Why Queue Works**:
1. Timestamps come in sorted order (increasing `t`)
2. Oldest call is always at the front of queue
3. Can efficiently remove outdated calls from front in O(1)
4. Queue length is the answer after removing old calls

**Complexity**:
- **Time**: O(1) amortized per `ping` call
- **Space**: O(n) where n is number of calls in the 3000 time window

**Key Insight**: Queue maintains sorted order naturally when elements arrive in sorted order, making it perfect for sliding time window problems.

### 6.4 Monotonic Stacks and Queues

#### What is Monotonic?

**Monotonic**: A function or quantity that varies in such a way that it either never decreases or never increases.

A **monotonic stack or queue** is one whose elements are always sorted (either ascending or descending). The data structure maintains its sorted property by **removing elements that would violate the property** before adding new elements.

**Example**: Monotonically increasing stack = `[1, 5, 8, 15, 23]`
- To push `14`: First pop `23` and `15` → Result: `[1, 5, 8, 14]`

#### Monotonic Stack Template

```csharp
// Monotonic increasing stack
var stack = new Stack<int>();

foreach (int num in nums) {
    // Remove elements that violate monotonic property
    while (stack.Count > 0 && stack.Peek() >= num) {
        stack.Pop();
    }
    
    // Process logic here (problem-dependent)
    
    stack.Push(num);
}
```

**Time Complexity**: O(n) - despite nested loop, each element is pushed and popped at most once (amortized O(1) per iteration).

#### When to Use Monotonic Structures

Monotonic stacks/queues excel at problems involving:
1. **Next Greater/Smaller Element**: Finding the next element that satisfies a condition
2. **Dynamic Window Maximum/Minimum**: Maintaining min/max as window slides
3. **Range Queries**: Finding elements within a range that meet criteria
4. **Stock Span Problems**: Days since last higher/lower value

#### Example 1: Daily Temperatures (LeetCode 739)

**Problem**: Given daily temperatures, return an array where `answer[i]` is the number of days until a warmer temperature. Return `0` if no warmer day exists.

**Input**: `temperatures = [73, 74, 75, 71, 69, 72, 76, 73]`  
**Output**: `[1, 1, 4, 2, 1, 1, 0, 0]`

**Brute Force**: O(n²) - for each day, scan forward to find warmer temperature.

**Optimized Approach**: Use monotonic decreasing stack of indices.

**Key Insight**: 
- If `temp[2] < temp[1] < temp[0]`, then any temperature warmer than `temp[2]` will also be warmer than `temp[1]` and `temp[0]`
- Process in reverse order using stack - store indices of days waiting for warmer temperature
- When we find warmer temperature, pop all cooler days from stack

```csharp
public int[] DailyTemperatures(int[] temperatures) {
    var stack = new Stack<int>();
    var answer = new int[temperatures.Length];
    
    for (int i = 0; i < temperatures.Length; i++) {
        // Pop all days cooler than current day
        while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i]) {
            int j = stack.Pop();
            answer[j] = i - j;  // Days between
        }
        
        stack.Push(i);
    }
    
    return answer;
}
```

**How it Works**:
1. Stack holds indices of days without warmer temperature yet
2. Stack is monotonically decreasing (temperatures at indices)
3. When current temp is warmer, pop cooler days and calculate distance
4. Current day won't be answered until later (or never)

**Complexity**:
- **Time**: O(n) - each element pushed/popped once
- **Space**: O(n) - stack can hold all indices

#### Example 2: Sliding Window Maximum (LeetCode 239)

**Problem**: Given array `nums` and integer `k`, find the maximum element in each sliding window of size `k`.

**Input**: `nums = [1, 3, -1, -3, 5, 3, 6, 7]`, `k = 3`  
**Output**: `[3, 3, 5, 5, 6, 7]`

**Challenge**: When maximum leaves window, we need to know the second maximum, and so on.

**Approach**: Use monotonic decreasing deque (double-ended queue).

**Key Insights**:
1. **Monotonic Decreasing**: Largest element always at front
2. **Remove Smaller Elements**: If new element is larger, all smaller elements behind it are useless
3. **Remove Old Elements**: Remove front element when it's outside current window
4. **Use Deque**: Need to add/remove from both ends efficiently

```csharp
public int[] MaxSlidingWindow(int[] nums, int k) {
    var result = new List<int>();
    var deque = new LinkedList<int>();  // Store indices
    
    for (int i = 0; i < nums.Length; i++) {
        // Remove elements smaller than current (maintain decreasing order)
        while (deque.Count > 0 && nums[deque.Last.Value] < nums[i]) {
            deque.RemoveLast();
        }
        
        deque.AddLast(i);
        
        // Remove elements outside window
        if (deque.First.Value + k == i) {
            deque.RemoveFirst();
        }
        
        // Add to result once window is full
        if (i >= k - 1) {
            result.Add(nums[deque.First.Value]);
        }
    }
    
    return result.ToArray();
}
```

**Why This Works**:
- Deque maintains indices in **decreasing order** of their values
- Front element is always the maximum in current window
- When adding element, remove all smaller elements from back (they'll never be max)
- Remove front when it's outside window
- After processing k elements, front is always the answer

**Complexity**:
- **Time**: O(n) - each element added/removed once
- **Space**: O(k) - deque holds at most k elements

#### Example 3: Longest Continuous Subarray (LeetCode 1438)

**Problem**: Return the longest subarray where the absolute difference between any two elements is ≤ `limit`.

**Constraint**: `max(subarray) - min(subarray) <= limit`

**Approach**: Sliding window with two monotonic deques.

**Key Insight**: 
- Use **monotonic increasing** deque for minimum element
- Use **monotonic decreasing** deque for maximum element
- Apply sliding window: expand right, contract left when constraint violated

```csharp
public int LongestSubarray(int[] nums, int limit) {
    var increasing = new LinkedList<int>();  // Min at front
    var decreasing = new LinkedList<int>();  // Max at front
    int left = 0, ans = 0;
    
    for (int right = 0; right < nums.Length; right++) {
        // Maintain monotonic increasing (min)
        while (increasing.Count > 0 && increasing.Last.Value > nums[right]) {
            increasing.RemoveLast();
        }
        
        // Maintain monotonic decreasing (max)
        while (decreasing.Count > 0 && decreasing.Last.Value < nums[right]) {
            decreasing.RemoveLast();
        }
        
        increasing.AddLast(nums[right]);
        decreasing.AddLast(nums[right]);
        
        // Contract window if constraint violated
        while (decreasing.First.Value - increasing.First.Value > limit) {
            if (nums[left] == decreasing.First.Value) {
                decreasing.RemoveFirst();
            }
            if (nums[left] == increasing.First.Value) {
                increasing.RemoveFirst();
            }
            left++;
        }
        
        ans = Math.Max(ans, right - left + 1);
    }
    
    return ans;
}
```

**How It Works**:
1. **Two Deques**: Track both min and max in current window
2. **Monotonic Properties**: 
   - Increasing deque: minimum at front
   - Decreasing deque: maximum at front
3. **Sliding Window**: Expand right, contract left when `max - min > limit`
4. **Maintain Deques**: Remove elements as window slides

**Complexity**:
- **Time**: O(n) - each element processed once
- **Space**: O(n) - deques can grow to size n

### Key Insights for Monotonic Structures

1. **Efficient Next Element**: Find next greater/smaller in O(n) instead of O(n²)
2. **Window Min/Max**: Track extremes as window changes in O(1) per element
3. **Deque Flexibility**: Add/remove from both ends for maximum control
4. **Transitive Property**: Use sorted order to eliminate useless elements
5. **Amortized Analysis**: Despite nested loops, overall complexity is linear

### Monotonic Pattern Recognition

| Problem Type | Structure | Monotonic Order | Use Case |
|--------------|-----------|-----------------|----------|
| **Next Greater Element** | Stack | Decreasing | Find first element > current |
| **Next Smaller Element** | Stack | Increasing | Find first element < current |
| **Sliding Window Max** | Deque | Decreasing | Track maximum in window |
| **Sliding Window Min** | Deque | Increasing | Track minimum in window |
| **Stock Span** | Stack | Decreasing | Days since last higher price |

---

## 7. Trees and Graphs

### Learning Objectives

- Understand binary trees and their fundamental properties
- Master Depth-First Search (DFS) traversal techniques
- Apply recursive thinking to solve tree problems
- Learn preorder, inorder, and postorder traversals
- Implement both recursive and iterative solutions

### 7.1 Introduction to Binary Trees

#### Nodes and Graphs

A **graph** is any collection of nodes and their pointers to other nodes. Linked lists and trees are both types of graphs. The nodes of a graph are also called **vertices**, and the pointers that connect them are called **edges**.

A **tree** is a special type of graph. In this course, we focus on **binary trees**.

#### What is a Binary Tree?

A **binary tree** is a tree where each node has at most two children, referred to as the **left child** and **right child**.

**Key Properties**:
- The start of a binary tree is called the **root** (similar to the head in linked lists)
- Every node has between 0 to 2 children
- Every node except the root has exactly one parent
- A node cannot have more than one parent

**Example Structure**:
```
        3
      /   \
     1     2
    / \   /
   4   5 6
```

In this tree:
- Node `3` is the root
- Node `6` is the left child of node `2`
- Node `5` is the right child of node `1`
- Each node has exactly one parent

#### Real-World Examples

Trees are implemented all around us:

1. **File Systems**: Root directory → subfolders/files
2. **Comment Threads**: Original post → comments → replies
3. **Company Organization**: CEO → C-Suite → VPs → Directors

#### Binary Tree Terminology

**Root Node**: The topmost node; the starting point of the tree. Usually given as input in problems.

**Parent and Child**: If node A has an edge to node B (A → B), then A is the **parent** of B, and B is the **child** of A.

**Leaf Node**: A node with no children. The "leaves" of the tree.

**Depth**: How far a node is from the root. The root has depth 0. Each child has depth = parent's depth + 1.

**Subtree**: A node and all its descendants. This is the most fundamental concept for solving tree problems!

**Key Insight**: Any node can be treated as the root of its own subtree. This enables recursive problem-solving.

For example, in the tree above:
- The subtree rooted at node `1` contains nodes `1`, `4`, and `5`
- This subtree is a binary tree itself
- We can call this the "right subtree of the root"

#### Code Representation

Binary trees are implemented using a custom class:

```csharp
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
```

**Key Points**:
- In problems, you'll be given a reference to the `root`
- Access left subtree with `root.left`
- Access right subtree with `root.right`
- Each node carries data in `val`
- If `node.left == null`, the node has no left child
- If both children are `null`, the node is a leaf

### 7.2 Depth-First Search (DFS)

#### What is DFS?

**Depth-First Search (DFS)** prioritizes depth by traversing as far down the tree as possible in one direction before exploring the other direction.

**How it works**:
1. Choose a direction (typically left)
2. Move exclusively with `node.left` until reaching a leaf
3. Backtrack and explore the right subtree

**Implementation**: DFS is typically implemented using **recursion**, though it can also be done iteratively with a stack.

#### Basic DFS Template

```csharp
public void DFS(TreeNode node) {
    if (node == null) {
        return;
    }
    
    DFS(node.left);
    DFS(node.right);
    return;
}
```

#### General DFS Structure

Most tree problems follow this pattern:

1. **Handle base case(s)**: Usually empty tree (`node == null`)
2. **Do logic for current node**: Problem-specific operations
3. **Recursively call on children**: Process left and right subtrees
4. **Return the answer**: Each call solves for its subtree

**Important Concept**: Each function call solves and returns the answer as if the subtree rooted at the current node was the entire tree.

#### Three Types of DFS Traversal

The three types differ only in **when** logic is performed relative to recursive calls:

**1. Preorder Traversal** (Current → Left → Right)

Logic is done **before** moving to children.

```csharp
public void PreorderDFS(TreeNode node) {
    if (node == null) return;
    
    Console.WriteLine(node.val);    // Process current
    PreorderDFS(node.left);         // Process left
    PreorderDFS(node.right);        // Process right
}
```

For the example tree above: `3, 1, 4, 5, 2, 6`

**2. Inorder Traversal** (Left → Current → Right)

Logic is done **between** left and right children.

```csharp
public void InorderDFS(TreeNode node) {
    if (node == null) return;
    
    InorderDFS(node.left);          // Process left
    Console.WriteLine(node.val);    // Process current
    InorderDFS(node.right);         // Process right
}
```

For the example tree above: `4, 1, 5, 3, 6, 2`

**3. Postorder Traversal** (Left → Right → Current)

Logic is done **after** processing both children.

```csharp
public void PostorderDFS(TreeNode node) {
    if (node == null) return;
    
    PostorderDFS(node.left);        // Process left
    PostorderDFS(node.right);       // Process right
    Console.WriteLine(node.val);    // Process current
}
```

For the example tree above: `4, 5, 1, 6, 2, 3`

**Mnemonic**:
- **Pre** → before children
- **In** → in the middle of children
- **Post** → after children

#### Example 1: Maximum Depth of Binary Tree (LeetCode 104)

**Problem**: Find the length of the longest path from root to a leaf.

**Approach**: Use recursion with base case and recurrence relation.

**Base Case**: Empty tree has depth 0.

**Recurrence**: For any node, depth = 1 + max(left depth, right depth)

```csharp
public int MaxDepth(TreeNode root) {
    if (root == null) {
        return 0;
    }
    
    int left = MaxDepth(root.left);
    int right = MaxDepth(root.right);
    return Math.Max(left, right) + 1;
}
```

**How it works**:
1. DFS reaches a leaf (both children are null)
2. Leaf's children return 0 (base case)
3. Leaf returns `1 + max(0, 0) = 1`
4. Values propagate up: each parent adds 1 to max of its children

**Iterative Implementation**:

```csharp
public int MaxDepth(TreeNode root) {
    if (root == null) return 0;
    
    var stack = new Stack<(TreeNode node, int depth)>();
    stack.Push((root, 1));
    int maxDepth = 0;
    
    while (stack.Count > 0) {
        var (node, depth) = stack.Pop();
        maxDepth = Math.Max(maxDepth, depth);
        
        if (node.left != null) {
            stack.Push((node.left, depth + 1));
        }
        if (node.right != null) {
            stack.Push((node.right, depth + 1));
        }
    }
    
    return maxDepth;
}
```

**Complexity**:
- **Time**: O(n) - visit each node once
- **Space**: O(n) - recursion call stack (O(h) for balanced tree, where h is height)

#### Example 2: Path Sum (LeetCode 112)

**Problem**: Return true if there exists a path from root to leaf with sum equal to `targetSum`.

**Approach**: Track cumulative sum during DFS.

**Key Insight**: Keep a running sum `curr` as we traverse. At each leaf, check if `curr + node.val == targetSum`.

```csharp
public bool HasPathSum(TreeNode root, int targetSum) {
    return DFS(root, 0, targetSum);
}

private bool DFS(TreeNode node, int curr, int targetSum) {
    if (node == null) {
        return false;
    }
    
    // Check if leaf node
    if (node.left == null && node.right == null) {
        return (curr + node.val) == targetSum;
    }
    
    curr += node.val;
    bool left = DFS(node.left, curr, targetSum);
    bool right = DFS(node.right, curr, targetSum);
    return left || right;  // Need only ONE valid path
}
```

**Why it works**:
- All paths through a node must include that node
- Each call has its own `curr` value (recursion property)
- At leaves, we have the complete path sum
- Use OR (`||`) because we need just one valid path

**Complexity**:
- **Time**: O(n)
- **Space**: O(n)

#### Example 3: Count Good Nodes (LeetCode 1448)

**Problem**: A node is "good" if no node on the path from root has a greater value. Count all good nodes.

**Approach**: Track the maximum value seen so far on the current path.

```csharp
public int GoodNodes(TreeNode root) {
    return DFS(root, int.MinValue);
}

private int DFS(TreeNode node, int maxSoFar) {
    if (node == null) {
        return 0;
    }
    
    int left = DFS(node.left, Math.Max(maxSoFar, node.val));
    int right = DFS(node.right, Math.Max(maxSoFar, node.val));
    
    int ans = left + right;
    if (node.val >= maxSoFar) {
        ans++;  // Current node is good
    }
    
    return ans;
}
```

**How it works**:
- Pass `maxSoFar` to track largest value on path
- Update `maxSoFar` before calling children
- Count current node if `node.val >= maxSoFar`
- Sum counts from left and right subtrees

**Complexity**:
- **Time**: O(n)
- **Space**: O(n)

#### Example 4: Same Tree (LeetCode 100)

**Problem**: Check if two binary trees are structurally identical with same values.

**Recursive Definition**: Two trees are the same if:
1. `p.val == q.val`
2. `p.left` and `q.left` are the same tree
3. `p.right` and `q.right` are the same tree

```csharp
public bool IsSameTree(TreeNode p, TreeNode q) {
    // Both null - same empty tree
    if (p == null && q == null) {
        return true;
    }
    
    // One null, one not - different
    if (p == null || q == null) {
        return false;
    }
    
    // Values different
    if (p.val != q.val) {
        return false;
    }
    
    // Check subtrees recursively
    bool left = IsSameTree(p.left, q.left);
    bool right = IsSameTree(p.right, q.right);
    return left && right;
}
```

**Beauty of Recursion**: The function itself answers whether subtrees are the same!

**Complexity**:
- **Time**: O(n) where n = min(nodes in p, nodes in q)
- **Space**: O(n)

### Key Insights for Tree Problems

1. **Recursive Nature**: Every subtree is itself a tree
2. **Function Returns**: Each call returns the answer for its subtree
3. **Base Cases**: Usually `node == null` or leaf nodes
4. **Traversal Type**: Often doesn't matter - just visit all nodes
5. **Each Call Has Own Variables**: Recursion maintains separate state
6. **Think Bottom-Up**: Solutions build from leaves upward

### Common Time and Space Complexity

**Time Complexity**: Almost always **O(n)** where n = number of nodes
- Each node visited once
- Constant work per node (unless specified)

**Space Complexity**: **O(n)** in worst case
- Recursion call stack depth
- O(h) for balanced tree (h = height)
- O(n) for skewed tree (straight line)

### DFS Pattern Recognition

| Problem Type | Key Indicator | Typical Approach |
|--------------|---------------|------------------|
| **Path Problems** | Root to leaf paths | Track running sum/path |
| **Tree Properties** | Max depth, node count | Aggregate from children |
| **Validation** | Check tree properties | Compare with constraints |
| **Comparison** | Two trees | Simultaneous traversal |
| **Transformation** | Modify tree structure | Process then recurse |

### 7.3 Breadth-First Search (BFS)

#### What is BFS?

In **Breadth-First Search (BFS)**, we prioritize breadth over depth. Instead of going as deep as possible first, we traverse all nodes at a given depth before moving to the next depth level.

**Key Difference from DFS**:
- **DFS**: Depth progression: 0, 1, 2, 3, 4, 5, 6, ...
- **BFS**: Depth progression: 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, ...

Think of each depth as a **level** or **floor** in a building:
- Root is the top floor
- Each level down is connected by edges (staircases)
- BFS visits all rooms on one floor before going down

#### When to Use BFS vs DFS

**BFS is Better When**:
- Need to handle nodes by their level/depth
- Looking for shortest path in unweighted graphs
- Want to process tree level-by-level
- Problems explicitly mention "level" or "row"

**DFS is Often Preferred Because**:
- Easier to implement (especially with recursion)
- Uses less code
- For problems where BFS/DFS doesn't matter algorithmically

**Complexity Trade-offs**:

| Aspect | DFS | BFS |
|--------|-----|-----|
| **Space** | O(h) height of tree | O(w) width of tree |
| **Best Case** | Straight line: O(1) per level | Perfect tree: O(n) at last level |
| **Worst Case** | Perfect tree: O(n) | Straight line: O(1) |
| **Implementation** | Stack (recursion) | Queue (iterative) |

**Example**: In a perfect binary tree with 1 million nodes:
- DFS uses O(log n) ≈ 20 nodes in memory
- BFS uses O(n/2) = 500,000 nodes in memory (last level)

But in a straight line tree (skewed):
- DFS uses O(n) = 1 million nodes
- BFS uses O(1) only

#### BFS Implementation Pattern

BFS is implemented **iteratively** using a **queue**:

```csharp
public void BFS(TreeNode root) {
    if (root == null) return;
    
    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    
    while (queue.Count > 0) {
        int nodesInCurrentLevel = queue.Count;
        
        // Process all nodes at current level
        for (int i = 0; i < nodesInCurrentLevel; i++) {
            TreeNode node = queue.Dequeue();
            
            // Do logic here for current node
            Console.WriteLine(node.val);
            
            // Add next level to queue
            if (node.left != null) {
                queue.Enqueue(node.left);
            }
            if (node.right != null) {
                queue.Enqueue(node.right);
            }
        }
        // After this iteration, queue contains exactly the next level
    }
}
```

**Key Pattern Details**:
1. **At start of while loop**: Queue contains exactly one level
2. **Save level size**: `nodesInCurrentLevel` before processing
3. **Process current level**: For loop handles all nodes in this level
4. **Add children**: Queue fills with next level during iteration
5. **Loop invariant**: After for loop, queue has exactly next level

#### Example 1: Binary Tree Right Side View (LeetCode 199)

**Problem**: Return values of nodes visible when viewing tree from right side (rightmost node at each level).

**Approach**: Use BFS level-order traversal, take last node of each level.

```csharp
public IList<int> RightSideView(TreeNode root) {
    if (root == null) return new List<int>();
    
    List<int> ans = new List<int>();
    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    
    while (queue.Count > 0) {
        int currentLength = queue.Count;
        TreeNode rightmostNode = null;
        
        for (int i = 0; i < currentLength; i++) {
            TreeNode node = queue.Dequeue();
            rightmostNode = node;  // Last node processed will be rightmost
            
            if (node.left != null) {
                queue.Enqueue(node.left);
            }
            if (node.right != null) {
                queue.Enqueue(node.right);
            }
        }
        
        ans.Add(rightmostNode.val);
    }
    
    return ans;
}
```

**Why it Works**:
- Since we add left before right, nodes are in left-to-right order
- Last node processed in each level is the rightmost
- Each while iteration handles one level

**Complexity**:
- **Time**: O(n) - visit each node once
- **Space**: O(n) - queue can hold up to n/2 nodes (last level of perfect tree)

#### Example 2: Find Largest Value in Each Tree Row (LeetCode 515)

**Problem**: Return array of largest value in each row (level).

**Approach**: Track maximum value while processing each level.

```csharp
public IList<int> LargestValues(TreeNode root) {
    if (root == null) return new List<int>();
    
    List<int> ans = new List<int>();
    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    
    while (queue.Count > 0) {
        int currentLength = queue.Count;
        int currMax = int.MinValue;
        
        for (int i = 0; i < currentLength; i++) {
            TreeNode node = queue.Dequeue();
            currMax = Math.Max(currMax, node.val);
            
            if (node.left != null) {
                queue.Enqueue(node.left);
            }
            if (node.right != null) {
                queue.Enqueue(node.right);
            }
        }
        
        ans.Add(currMax);
    }
    
    return ans;
}
```

**How it Works**:
- Initialize `currMax` at start of each level
- Update `currMax` as we process nodes
- Add `currMax` to answer after processing complete level

**Complexity**:
- **Time**: O(n)
- **Space**: O(n)

#### Example 3: Deepest Leaves Sum (LeetCode 1302)

**Problem**: Return sum of values of deepest leaves.

**Approach**: Use BFS and keep updating sum for each level. Last level processed will be deepest.

```csharp
public int DeepestLeavesSum(TreeNode root) {
    Queue<TreeNode> queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    int ans = 0;
    
    while (queue.Count > 0) {
        int currentLength = queue.Count;
        ans = 0;  // Reset for each level
        
        for (int i = 0; i < currentLength; i++) {
            TreeNode node = queue.Dequeue();
            ans += node.val;
            
            if (node.left != null) {
                queue.Enqueue(node.left);
            }
            if (node.right != null) {
                queue.Enqueue(node.right);
            }
        }
    }
    
    return ans;  // Last level's sum
}
```

**Clever Insight**: We overwrite `ans` at each level. When loop ends, `ans` holds sum of deepest level.

**Complexity**:
- **Time**: O(n)
- **Space**: O(n)

#### Example 4: Zigzag Level Order Traversal (LeetCode 103)

**Problem**: Return level-order traversal alternating direction (left-to-right, then right-to-left).

**Approach**: Use BFS with a boolean flag to alternate direction.

```csharp
public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
    if (root == null) return new List<IList<int>>();
    
    var ans = new List<IList<int>>();
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    bool leftToRight = true;
    
    while (queue.Count > 0) {
        int currentLength = queue.Count;
        var currentLevel = new List<int>();
        
        for (int i = 0; i < currentLength; i++) {
            TreeNode node = queue.Dequeue();
            currentLevel.Add(node.val);
            
            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);
        }
        
        if (!leftToRight) {
            currentLevel.Reverse();
        }
        
        ans.Add(currentLevel);
        leftToRight = !leftToRight;
    }
    
    return ans;
}
```

**How it Works**:
- Process level normally (left to right)
- If current level should be right-to-left, reverse the list
- Toggle direction flag after each level

**Complexity**:
- **Time**: O(n) - reverse is O(w) per level, total O(n)
- **Space**: O(n)

### Key Insights for BFS

1. **Level-by-Level**: Perfect for problems that mention "level", "row", or "depth"
2. **Queue Invariant**: At start of while loop, queue has exactly one level
3. **For Loop Pattern**: Process exactly `queue.Count` nodes (saved before loop)
4. **Next Level Building**: Children added during current level processing
5. **Iterative Only**: BFS is rarely implemented recursively
6. **Space Consideration**: Can use O(n) space for wide trees (vs DFS's O(h))

### 7.4 Binary Search Trees (BST)

#### What is a Binary Search Tree?

A **Binary Search Tree (BST)** is a special binary tree with an ordering property:

**BST Property**: For every node:
- All values in the **left subtree** are **less than** the node's value
- All values in the **right subtree** are **greater than** the node's value
- This property holds for **every** node in the tree

**Important Implications**:
- All values in a BST must be **unique**
- The ordering property applies recursively to all subtrees

**Example BST**:
```
        23
       /  \
      8    37
     / \   / \
    6  17 29 50
      / \
     9  20
```

Verification:
- All values left of 23 (8, 6, 17, 9, 20) are less than 23
- All values right of 23 (37, 29, 50) are greater than 23
- Same property holds for every node

#### BST Operations Efficiency

The BST property enables efficient operations through **binary search**:

**Search for value 20**:
1. Start at root (23): 20 < 23 → go left
2. At 8: 20 > 8 → go right
3. At 17: 20 > 17 → go right
4. At 20: Found!

At each step, we **eliminate half** of the remaining tree!

**Time Complexity**:
- **Average case**: O(log n) for search, insert, delete
- **Worst case**: O(n) for unbalanced trees (like a straight line)

**Best Case**: Balanced tree where height h = log n
**Worst Case**: Skewed tree where height h = n

#### Important BST Property: Inorder Traversal

**Key Insight**: An **inorder DFS traversal** (left → node → right) on a BST visits nodes in **sorted ascending order**!

```csharp
public void InorderTraversal(TreeNode node, List<int> values) {
    if (node == null) return;
    
    InorderTraversal(node.left, values);   // Process left (smaller values)
    values.Add(node.val);                   // Process current
    InorderTraversal(node.right, values);  // Process right (larger values)
}
```

For the BST above: `6, 8, 9, 17, 20, 23, 29, 37, 50` (sorted!)

#### Example 1: Range Sum of BST (LeetCode 938)

**Problem**: Return sum of all node values in range `[low, high]`.

**Naive Approach**: Visit every node, add to sum if in range. Time: O(n)

**Optimized BST Approach**: Use BST property to prune search space!

**Key Optimizations**:
1. If `node.val < low`: All left subtree values are too small → skip left
2. If `node.val > high`: All right subtree values are too large → skip right

```csharp
public int RangeSumBST(TreeNode root, int low, int high) {
    if (root == null) return 0;
    
    int ans = 0;
    
    // Include current node if in range
    if (low <= root.val && root.val <= high) {
        ans += root.val;
    }
    
    // Only search left if there might be valid values
    if (low < root.val) {
        ans += RangeSumBST(root.left, low, high);
    }
    
    // Only search right if there might be valid values
    if (root.val < high) {
        ans += RangeSumBST(root.right, low, high);
    }
    
    return ans;
}
```

**Iterative Version**:

```csharp
public int RangeSumBST(TreeNode root, int low, int high) {
    Stack<TreeNode> stack = new Stack<TreeNode>();
    stack.Push(root);
    int ans = 0;
    
    while (stack.Count > 0) {
        TreeNode node = stack.Pop();
        
        if (low <= node.val && node.val <= high) {
            ans += node.val;
        }
        
        if (node.left != null && low < node.val) {
            stack.Push(node.left);
        }
        
        if (node.right != null && node.val < high) {
            stack.Push(node.right);
        }
    }
    
    return ans;
}
```

**Why This is Better**:
- Still O(n) worst case (all nodes in range)
- Average case much better - can skip entire subtrees
- Example: If root > high, skip 500,000 nodes in right subtree instantly!

**Complexity**:
- **Time**: O(n) worst, O(log n) average for balanced BST
- **Space**: O(h) for recursion stack

#### Example 2: Minimum Absolute Difference in BST (LeetCode 530)

**Problem**: Find minimum absolute difference between values of any two nodes.

**Naive Approach**: 
1. Get all values: O(n)
2. Check all pairs: O(n²)
Total: O(n²)

**Better Approach**:
1. Get all values: O(n)
2. Sort array: O(n log n)
3. Check adjacent pairs only: O(n)
Total: O(n log n)

**Optimal BST Approach**: Use inorder traversal to get sorted values in O(n)!

```csharp
public int GetMinimumDifference(TreeNode root) {
    List<int> values = new List<int>();
    InorderDFS(root, values);
    
    int ans = int.MaxValue;
    for (int i = 1; i < values.Count; i++) {
        ans = Math.Min(ans, values[i] - values[i - 1]);
    }
    
    return ans;
}

private void InorderDFS(TreeNode node, List<int> values) {
    if (node == null) return;
    
    InorderDFS(node.left, values);    // Left subtree
    values.Add(node.val);              // Current node
    InorderDFS(node.right, values);   // Right subtree
}
```

**Why Inorder Works**:
- Inorder on BST gives sorted values
- In sorted array, minimum difference must be between adjacent elements
- No need for O(n log n) sort!

**Iterative Inorder** (more complex):

```csharp
public int GetMinimumDifference(TreeNode root) {
    List<int> values = IterativeInorder(root);
    
    int ans = int.MaxValue;
    for (int i = 1; i < values.Count; i++) {
        ans = Math.Min(ans, values[i] - values[i - 1]);
    }
    
    return ans;
}

private List<int> IterativeInorder(TreeNode root) {
    var stack = new Stack<TreeNode>();
    var values = new List<int>();
    TreeNode curr = root;
    
    while (stack.Count > 0 || curr != null) {
        // Go as far left as possible
        while (curr != null) {
            stack.Push(curr);
            curr = curr.left;
        }
        
        // Process node
        curr = stack.Pop();
        values.Add(curr.val);
        
        // Move to right subtree
        curr = curr.right;
    }
    
    return values;
}
```

**Note**: Iterative inorder is much more complex. Use recursion when possible!

**Complexity**:
- **Time**: O(n)
- **Space**: O(n) for values array + O(h) for recursion

#### Example 3: Validate Binary Search Tree (LeetCode 98)

**Problem**: Determine if a binary tree is a valid BST.

**Key Insight**: Each node must satisfy:
1. `small < node.val < large` (value range constraint)
2. Both subtrees must also be valid BSTs

**Approach**: Use DFS with valid value range `(small, large)`:
- Root can be any value: `(-∞, +∞)`
- Left child must be less than parent: update `large = node.val`
- Right child must be greater than parent: update `small = node.val`

```csharp
public bool IsValidBST(TreeNode root) {
    return DFS(root, long.MinValue, long.MaxValue);
}

private bool DFS(TreeNode node, long small, long large) {
    if (node == null) {
        return true;  // Empty tree is valid BST
    }
    
    // Check if current node violates constraints
    if (small >= node.val || node.val >= large) {
        return false;
    }
    
    // Check if left subtree is valid BST with updated range
    bool left = DFS(node.left, small, node.val);
    
    // Check if right subtree is valid BST with updated range
    bool right = DFS(node.right, node.val, large);
    
    // Both subtrees must be valid
    return left && right;
}
```

**Why It Works**:
- Each recursive call maintains the valid range for its subtree
- Left subtree: `(small, node.val)` ensures all values < parent
- Right subtree: `(node.val, large)` ensures all values > parent
- Recursion handles all ancestor constraints automatically

**Iterative Version**:

```csharp
public bool IsValidBST(TreeNode root) {
    var stack = new Stack<(TreeNode node, long small, long large)>();
    stack.Push((root, long.MinValue, long.MaxValue));
    
    while (stack.Count > 0) {
        var (node, small, large) = stack.Pop();
        
        if (small >= node.val || node.val >= large) {
            return false;
        }
        
        if (node.left != null) {
            stack.Push((node.left, small, node.val));
        }
        
        if (node.right != null) {
            stack.Push((node.right, node.val, large));
        }
    }
    
    return true;
}
```

**Complexity**:
- **Time**: O(n) - visit each node once
- **Space**: O(h) for recursion stack

### BST Key Insights

1. **Inorder = Sorted**: Inorder traversal on BST gives sorted values
2. **Binary Search**: Can eliminate half the tree at each decision
3. **Validation Ranges**: Track valid range `(small, large)` for BST validation
4. **Pruning Opportunity**: Use BST property to skip entire subtrees
5. **Recursive Subtrees**: Each subtree must also be a valid BST

### BST Pattern Recognition

| Problem Type | Key Indicator | Approach |
|--------------|---------------|----------|
| **Range Queries** | Sum/count in range | Prune using BST property |
| **Sorted Order** | Min difference, kth smallest | Inorder traversal |
| **Validation** | Check if valid BST | Track valid ranges |
| **Search** | Find value/closest | Binary search on tree |
| **Insert/Delete** | Modify BST | Maintain BST property |

### BFS vs DFS Summary

**Choose BFS When**:
- ✅ Problem mentions "level", "row", "depth"
- ✅ Need shortest path (unweighted)
- ✅ Want to handle by distance from root
- ✅ Examples: rightmost nodes, level sums, zigzag traversal

**Choose DFS When**:
- ✅ Simpler to implement with recursion
- ✅ Path-based problems (root to leaf)
- ✅ Tree property validation
- ✅ Most other tree problems where order doesn't matter

**Implementation Preferences**:
- **DFS**: Recursive (cleaner, less code)
- **BFS**: Iterative with queue (level-by-level control)

---

### 7.5 Introduction to Graphs

Graphs are a fundamental data structure that represent relationships between objects. While binary trees are a specific type of graph with strict constraints, general graphs offer much more flexibility and power.

#### What is a Graph?

**Definition**: A graph is any collection of nodes (vertices) and connections (edges) between those nodes.

**Key Difference from Binary Trees**:
- Binary trees: Each node has at most one parent and at most two children
- Graphs: Nodes can have any number of connections, no parent-child hierarchy

#### Real-World Graph Applications

Graphs model countless real-world scenarios:
- 🌐 **Social Networks**: Facebook, Twitter, Instagram (users as nodes, friendships as edges)
- 🗺️ **Navigation**: Roads in cities (intersections as nodes, roads as edges)
- 💻 **Internet**: Network traffic routing
- 🔗 **Blockchain**: Cryptocurrency transaction chains
- 🧬 **Biology**: Molecular and genetic relationships
- 🔌 **Circuit Boards**: Electronic component connections

#### Graph Terminology

**Edges (Connections)**:
- **Directed Edge**: One-way connection (A → B, but not B → A)
  - Represented with arrows in diagrams
  - Example: Twitter follow relationship
- **Undirected Edge**: Two-way connection (A ↔ B)
  - Represented with straight lines
  - Example: Facebook friendship

> 💡 **Note**: Binary trees have directed edges (parent → child only)

**Connected Components**:
- **Definition**: A group of nodes connected by edges
- A graph can have multiple separate connected components
- Binary trees always have exactly one connected component (all nodes reachable from root)

**Node Degree**:
- **Indegree**: Number of edges entering a node
- **Outdegree**: Number of edges leaving a node
- **Neighbors**: Nodes directly connected by an edge

> 📊 **Binary Tree Context**: 
> - All nodes except root have indegree = 1 (from parent)
> - Outdegree: 0 (leaf), 1, or 2 (internal nodes)

**Cycles**:
- **Cyclic Graph**: Contains at least one cycle (path that leads back to same node)
- **Acyclic Graph**: No cycles exist
- **DAG**: Directed Acyclic Graph

> ⚠️ **Important**: Binary trees cannot have cycles by definition

#### Graph Input Formats

Unlike binary trees where you're given node objects, graphs are typically described through data. You need to construct the graph representation yourself.

> 🔑 **Key Insight**: With graphs, only the "idea" of the graph exists. The input gives you information, and you must determine how to represent and traverse it in code.

**Common Node Labeling**: Nodes are usually numbered from `0` to `n-1`

##### Format 1: Array of Edges

**Structure**: 2D array where each element `[x, y]` represents an edge from `x` to `y`

**Example**: `edges = [[0, 1], [1, 2], [2, 0], [2, 3]]`

**Challenge**: Finding neighbors requires iterating through entire array (inefficient!)

**Solution**: Pre-process into a hash map (adjacency list)

```csharp
// Build adjacency list from edge array
Dictionary<int, List<int>> BuildGraph(int[][] edges) {
    var graph = new Dictionary<int, List<int>>();
    
    foreach (var edge in edges) {
        int x = edge[0], y = edge[1];
        
        if (!graph.ContainsKey(x)) {
            graph[x] = new List<int>();
        }
        graph[x].Add(y);
        
        // For undirected graphs, also add reverse edge:
        // if (!graph.ContainsKey(y)) {
        //     graph[y] = new List<int>();
        // }
        // graph[y].Add(x);
    }
    
    return graph;
}
```

**Complexity**:
- Pre-processing: O(E) where E = number of edges
- Neighbor lookup after pre-processing: O(1)

##### Format 2: Adjacency List

**Structure**: Array where `graph[i]` contains all neighbors of node `i`

**Example**: `graph = [[1], [2], [0, 3], []]`
- Node 0 connects to: [1]
- Node 1 connects to: [2]  
- Node 2 connects to: [0, 3]
- Node 3 connects to: []

**Advantage**: Already in optimal format! No pre-processing needed.

```csharp
// Using adjacency list (already provided in input)
int[][] graph = new int[][] {
    new int[] {1},      // Node 0 neighbors
    new int[] {2},      // Node 1 neighbors
    new int[] {0, 3},   // Node 2 neighbors
    new int[] {}        // Node 3 neighbors
};

// Access neighbors directly
foreach (int neighbor in graph[node]) {
    // Process neighbor
}
```

##### Format 3: Adjacency Matrix

**Structure**: 2D matrix where `graph[i][j] = 1` means edge from `i` to `j`

**Example**:
```
     0  1  2  3
  0 [0, 1, 0, 0]
  1 [0, 0, 1, 0]
  2 [1, 0, 0, 1]
  3 [0, 0, 0, 0]
```

**Options**:
1. **Direct traversal**: Check `graph[node][i]` for all `i`
2. **Pre-process**: Convert to adjacency list (better if nodes have few neighbors and n is large)

**Complexity**: O(n²) for traversal or pre-processing

```csharp
// Option 1: Direct usage (check all potential neighbors)
for (int i = 0; i < n; i++) {
    if (graph[node][i] == 1) {
        // i is a neighbor of node
    }
}

// Option 2: Pre-process to adjacency list
Dictionary<int, List<int>> BuildGraphFromMatrix(int[][] matrix) {
    var graph = new Dictionary<int, List<int>>();
    int n = matrix.Length;
    
    for (int i = 0; i < n; i++) {
        graph[i] = new List<int>();
        for (int j = 0; j < n; j++) {
            if (matrix[i][j] == 1) {
                graph[i].Add(j);
            }
        }
    }
    
    return graph;
}
```

##### Format 4: Matrix as Graph

**Structure**: 2D matrix where each cell is a node, and edges are defined by problem rules

**Example**: "Villages trade with adjacent villages (up, down, left, right)"
- Each cell `(row, col)` is a node
- Neighbors: `(row±1, col)`, `(row, col±1)` if in bounds

**Common Pattern**: Grid-based problems

```csharp
// Direction vectors for 4-directional movement
int[][] directions = new int[][] {
    new int[] {0, 1},   // Right
    new int[] {1, 0},   // Down
    new int[] {0, -1},  // Left
    new int[] {-1, 0}   // Up
};

bool Valid(int row, int col, int rows, int cols) {
    return row >= 0 && row < rows && col >= 0 && col < cols;
}

// Find neighbors of (row, col)
foreach (var dir in directions) {
    int newRow = row + dir[0];
    int newCol = col + dir[1];
    
    if (Valid(newRow, newCol, rows, cols)) {
        // (newRow, newCol) is a valid neighbor
    }
}
```

#### Graph vs Tree Code Differences

| Aspect | Binary Tree | Graph |
|--------|-------------|-------|
| **Starting Point** | Given root node | May need to determine start |
| **Node Access** | `node.left`, `node.right` | `graph[node]` or hash map lookup |
| **Neighbor Iteration** | Fixed (2 children max) | Loop through all neighbors |
| **Cycle Prevention** | Not needed (no cycles) | **Required** (use `seen` set) |
| **Node Representation** | Object with pointers | Integer label (usually) |

#### Preventing Cycles with `seen` Set

**Problem**: In graphs with cycles or undirected edges, DFS can loop infinitely

**Solution**: Track visited nodes in a `seen` set

```csharp
HashSet<int> seen = new HashSet<int>();

void DFS(int node, Dictionary<int, List<int>> graph) {
    // Mark as visited before processing
    seen.Add(node);
    
    foreach (int neighbor in graph[node]) {
        if (!seen.Contains(neighbor)) {
            DFS(neighbor, graph);
        }
    }
}
```

**Why Trees Don't Need This**:
- Trees have directed edges pointing only downward
- Once you leave a node, no path leads back to it
- Graphs allow bidirectional movement (e.g., A ↔ B)

**Implementation Note**: 
- Languages like Python: `HashSet` is fast and easy
- Languages like C++: Boolean array may be faster when node range is known (0 to n-1)

```csharp
// Alternative: Boolean array (when nodes are 0 to n-1)
bool[] seen = new bool[n];

void DFS(int node, Dictionary<int, List<int>> graph) {
    seen[node] = true;
    
    foreach (int neighbor in graph[node]) {
        if (!seen[neighbor]) {
            DFS(neighbor, graph);
        }
    }
}
```

#### Graph Traversal Starting Point

Unlike trees (start at root), graphs may require you to:
1. **Determine the start node** based on problem requirements
2. **Traverse from multiple starts** (e.g., count connected components)
3. **Consider all nodes** as potential starting points

### Graph Key Insights

1. **Flexible Structure**: Graphs can model any relationship without tree restrictions
2. **Multiple Representations**: Choose format based on problem and efficiency needs
3. **Cycle Awareness**: Always consider whether cycles exist and use `seen` set
4. **Pre-processing Pays Off**: Converting to adjacency list enables O(1) neighbor lookup
5. **Real-World Power**: Most complex systems are graphs, not trees

---

### 7.6 Graph DFS

DFS on graphs follows similar principles to tree DFS, but with critical differences to handle cycles and flexible connections.

#### DFS Implementation Patterns

##### Recursive DFS Template

```csharp
void DFS(int node, Dictionary<int, List<int>> graph, HashSet<int> seen) {
    // Process current node (optional)
    
    foreach (int neighbor in graph[node]) {
        if (!seen.Contains(neighbor)) {
            seen.Add(neighbor);  // Mark before recursion
            DFS(neighbor, graph, seen);
        }
    }
}

// Usage
var seen = new HashSet<int>();
seen.Add(startNode);
DFS(startNode, graph, seen);
```

##### Iterative DFS Template

```csharp
void DFS(int startNode, Dictionary<int, List<int>> graph) {
    var seen = new HashSet<int>();
    var stack = new Stack<int>();
    
    stack.Push(startNode);
    seen.Add(startNode);
    
    while (stack.Count > 0) {
        int node = stack.Pop();
        
        // Process node here
        
        foreach (int neighbor in graph[node]) {
            if (!seen.Contains(neighbor)) {
                seen.Add(neighbor);
                stack.Push(neighbor);
            }
        }
    }
}
```

#### Time and Space Complexity

**Time Complexity: O(n + e)**
- `n` = number of nodes (vertices)
- `e` = number of edges

**Explanation**:
- Each node is visited at most once: O(n)
- Edges are traversed only when visiting their source node
- Total edge iterations across entire algorithm: O(e)

> 📊 **Worst Case**: Complete graph where every node connects to every other node: e = n²

**Space Complexity: O(n + e)**
- `graph` hash map: O(e) to store all edges
- `seen` set: O(n) to track visited nodes  
- Recursion stack: O(n) in worst case (linear path)

#### Example 1: Number of Provinces (LeetCode 547)

**Problem**: Given `n` cities and an `n x n` matrix where `isConnected[i][j] = 1` means cities `i` and `j` are connected. Find the number of provinces (connected components).

**Key Insights**:
- Each province = one connected component
- DFS from any city visits all cities in its province
- Use `seen` to track visited cities across all DFS calls
- Each new DFS needed = one new province

**Approach**:
1. Convert adjacency matrix to adjacency list
2. Iterate through all cities
3. For each unvisited city, start DFS (new province found)
4. DFS marks entire province as visited

```csharp
public int FindCircleNum(int[][] isConnected) {
    int n = isConnected.Length;
    
    // Build graph from adjacency matrix
    var graph = new Dictionary<int, List<int>>();
    for (int i = 0; i < n; i++) {
        graph[i] = new List<int>();
    }
    
    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n; j++) {
            if (isConnected[i][j] == 1) {
                graph[i].Add(j);
                graph[j].Add(i);  // Undirected edge
            }
        }
    }
    
    // DFS helper
    void DFS(int node) {
        foreach (int neighbor in graph[node]) {
            if (!seen.Contains(neighbor)) {
                seen.Add(neighbor);
                DFS(neighbor);
            }
        }
    }
    
    // Count connected components
    var seen = new HashSet<int>();
    int provinces = 0;
    
    for (int i = 0; i < n; i++) {
        if (!seen.Contains(i)) {
            provinces++;
            seen.Add(i);
            DFS(i);
        }
    }
    
    return provinces;
}
```

**Iterative Version**:

```csharp
void DFS(int start) {
    var stack = new Stack<int>();
    stack.Push(start);
    
    while (stack.Count > 0) {
        int node = stack.Pop();
        foreach (int neighbor in graph[node]) {
            if (!seen.Contains(neighbor)) {
                seen.Add(neighbor);
                stack.Push(neighbor);
            }
        }
    }
}
```

**Complexity**:
- **Time**: O(n²) - Building graph requires checking all matrix cells
- **Space**: O(n + e) - Graph storage and seen set

#### Example 2: Number of Islands (LeetCode 200)

**Problem**: Given an `m x n` grid of `'1'` (land) and `'0'` (water), count the number of islands. Islands are formed by connecting adjacent lands horizontally or vertically.

**Key Insights**:
- Matrix format: each cell is a node
- Edges: up/down/left/right connections between land cells
- Same problem as provinces: count connected components

**Approach**:
1. Treat each land cell as a node
2. Neighbors = adjacent cells (4-directional)
3. DFS from each unvisited land cell
4. Each DFS explores one complete island

```csharp
public int NumIslands(char[][] grid) {
    int rows = grid.Length;
    int cols = grid[0].Length;
    
    // Direction vectors: right, down, left, up
    int[][] directions = new int[][] {
        new int[] {0, 1}, new int[] {1, 0},
        new int[] {0, -1}, new int[] {-1, 0}
    };
    
    bool Valid(int row, int col) {
        return row >= 0 && row < rows && 
               col >= 0 && col < cols && 
               grid[row][col] == '1';
    }
    
    void DFS(int row, int col) {
        foreach (var dir in directions) {
            int newRow = row + dir[0];
            int newCol = col + dir[1];
            
            if (Valid(newRow, newCol) && !seen[newRow][newCol]) {
                seen[newRow][newCol] = true;
                DFS(newRow, newCol);
            }
        }
    }
    
    // Initialize seen matrix
    bool[][] seen = new bool[rows][];
    for (int i = 0; i < rows; i++) {
        seen[i] = new bool[cols];
    }
    
    int islands = 0;
    for (int row = 0; row < rows; row++) {
        for (int col = 0; col < cols; col++) {
            if (grid[row][col] == '1' && !seen[row][col]) {
                islands++;
                seen[row][col] = true;
                DFS(row, col);
            }
        }
    }
    
    return islands;
}
```

**Iterative Version**:

```csharp
void DFS(int startRow, int startCol) {
    var stack = new Stack<(int, int)>();
    stack.Push((startRow, startCol));
    
    while (stack.Count > 0) {
        var (row, col) = stack.Pop();
        
        foreach (var dir in directions) {
            int newRow = row + dir[0];
            int newCol = col + dir[1];
            
            if (Valid(newRow, newCol) && !seen[newRow][newCol]) {
                seen[newRow][newCol] = true;
                stack.Push((newRow, newCol));
            }
        }
    }
}
```

**Alternative**: Modify input instead of using `seen` (change `'1'` to `'0'`)

```csharp
// No seen array needed
void DFS(int row, int col) {
    grid[row][col] = '0';  // Mark as visited
    
    foreach (var dir in directions) {
        int newRow = row + dir[0];
        int newCol = col + dir[1];
        
        if (Valid(newRow, newCol)) {
            DFS(newRow, newCol);
        }
    }
}
```

**Complexity**:
- **Time**: O(m × n) - Each cell visited at most once (4 neighbors = constant)
- **Space**: O(m × n) - Seen matrix + recursion stack

> 💡 **Note**: Unlike general graphs where nodes can have any number of edges, matrix graphs typically have a constant number of neighbors (4 or 8), making work per node O(1).

#### Example 3: Reorder Routes (LeetCode 1466)

**Problem**: Given `n` cities (0 to n-1) and `n-1` directed roads. All roads must point toward city 0 so every city can reach it. Count minimum swaps needed.

**Key Insights**:
- Graph is a tree (n nodes, n-1 edges, no cycles)
- Want all edges to point toward 0
- Traverse away from 0: any edge pointing away needs swapping
- Convert to undirected for traversal, track original directions

**Approach**:
1. Build undirected graph (to reach all nodes from 0)
2. Store original directed edges in a set
3. DFS from 0 (traversing away from 0)
4. Each edge `(node → neighbor)` in original set needs swapping

```csharp
public int MinReorder(int n, int[][] connections) {
    // Build undirected graph
    var graph = new Dictionary<int, List<int>>();
    for (int i = 0; i < n; i++) {
        graph[i] = new List<int>();
    }
    
    // Store original directed edges
    var roads = new HashSet<string>();
    foreach (var conn in connections) {
        int x = conn[0], y = conn[1];
        graph[x].Add(y);
        graph[y].Add(x);  // Undirected for traversal
        roads.Add($"{x},{y}");  // Original direction
    }
    
    int swaps = 0;
    var seen = new HashSet<int>();
    
    void DFS(int node) {
        foreach (int neighbor in graph[node]) {
            if (!seen.Contains(neighbor)) {
                // Check if edge points away from 0
                if (roads.Contains($"{node},{neighbor}")) {
                    swaps++;
                }
                seen.Add(neighbor);
                DFS(neighbor);
            }
        }
    }
    
    seen.Add(0);
    DFS(0);
    return swaps;
}
```

**Iterative Version**:

```csharp
public int MinReorder(int n, int[][] connections) {
    // Build graph and roads set (same as above)
    var graph = new Dictionary<int, List<int>>();
    var roads = new HashSet<string>();
    for (int i = 0; i < n; i++) {
        graph[i] = new List<int>();
    }
    foreach (var conn in connections) {
        graph[conn[0]].Add(conn[1]);
        graph[conn[1]].Add(conn[0]);
        roads.Add($"{conn[0]},{conn[1]}");
    }
    
    int swaps = 0;
    var seen = new HashSet<int>();
    var stack = new Stack<int>();
    
    stack.Push(0);
    seen.Add(0);
    
    while (stack.Count > 0) {
        int node = stack.Pop();
        
        foreach (int neighbor in graph[node]) {
            if (!seen.Contains(neighbor)) {
                if (roads.Contains($"{node},{neighbor}")) {
                    swaps++;
                }
                seen.Add(neighbor);
                stack.Push(neighbor);
            }
        }
    }
    
    return swaps;
}
```

**Complexity**:
- **Time**: O(n) - Tree has n nodes and n-1 edges
- **Space**: O(n) - Graph, roads set, seen set

#### Example 4: Keys and Rooms (LeetCode 841)

**Problem**: Given `n` rooms (0 to n-1), all locked except room 0. `rooms[i]` contains keys found in room `i`. Can you visit all rooms?

**Key Insights**:
- Input is already an adjacency list!
- Graph format: `rooms[i]` = neighbors of node `i`
- Problem: Can we reach all nodes from node 0?
- Solution: DFS from 0, check if `seen.Count == n`

**Approach**:
1. Start DFS from room 0
2. Collect all reachable rooms in `seen`
3. Compare `seen.Count` with `n`

```csharp
public bool CanVisitAllRooms(IList<IList<int>> rooms) {
    int n = rooms.Count;
    var seen = new HashSet<int>();
    
    void DFS(int room) {
        foreach (int key in rooms[room]) {
            if (!seen.Contains(key)) {
                seen.Add(key);
                DFS(key);
            }
        }
    }
    
    seen.Add(0);
    DFS(0);
    
    return seen.Count == n;
}
```

**Iterative Version**:

```csharp
public bool CanVisitAllRooms(IList<IList<int>> rooms) {
    var seen = new HashSet<int>();
    var stack = new Stack<int>();
    
    stack.Push(0);
    seen.Add(0);
    
    while (stack.Count > 0) {
        int room = stack.Pop();
        
        foreach (int key in rooms[room]) {
            if (!seen.Contains(key)) {
                seen.Add(key);
                stack.Push(key);
            }
        }
    }
    
    return seen.Count == rooms.Count;
}
```

**Complexity**:
- **Time**: O(n + e) - Standard graph DFS
- **Space**: O(n) - Seen set + recursion stack

> 💡 **Adjacency List Advantage**: Input is already in optimal format - no pre-processing needed!

#### Example 5: Minimum Vertices to Reach All Nodes (LeetCode 1557)

**Problem**: Given a directed acyclic graph (DAG) with `n` nodes and array of edges, find the smallest set of vertices from which all nodes are reachable.

**Key Insights**:
- Smallest set = nodes that cannot be reached from other nodes
- A node is unreachable from others if **indegree = 0**
- Return all nodes with indegree 0

> ⚠️ **Why DAG matters**: If cycles existed, we'd have ambiguity (in a cycle, all nodes have indegree > 0, but we'd need to return at least one)

**Approach**:
1. Calculate indegree for all nodes
2. Return nodes with indegree = 0

```csharp
public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
    int[] indegree = new int[n];
    
    // Count incoming edges for each node
    foreach (var edge in edges) {
        indegree[edge[1]]++;
    }
    
    // Collect nodes with no incoming edges
    var result = new List<int>();
    for (int i = 0; i < n; i++) {
        if (indegree[i] == 0) {
            result.Add(i);
        }
    }
    
    return result;
}
```

**Complexity**:
- **Time**: O(n + e) - Process all edges + all nodes
- **Space**: O(n) - Indegree array

> 🎓 **Learning Note**: Not all graph problems require DFS/BFS. Understanding graph properties (like indegree) can lead to simpler solutions.

### Graph DFS Key Insights

1. **Seen Set is Critical**: Prevents infinite loops in cyclic/undirected graphs
2. **Pre-processing Matters**: Convert input to adjacency list for O(1) neighbor lookup
3. **Connected Components**: Each DFS explores one complete component
4. **Matrix = Graph**: Grid problems are graph problems in disguise
5. **Choose Format Wisely**: 
   - Array of edges → Build adjacency list
   - Adjacency list → Use directly
   - Matrix → Consider space vs. time tradeoffs
6. **Graph Properties**: Sometimes indegree/outdegree analysis is simpler than traversal

### Graph DFS Pattern Recognition

| Problem Type | Key Indicator | Approach |
|--------------|---------------|----------|
| **Connected Components** | Count islands, provinces, groups | DFS + count starts |
| **Reachability** | Can reach all nodes? | DFS + check seen.Count |
| **Cycle Detection** | Find cycles | DFS + track path |
| **Path Problems** | Find/count paths | DFS with backtracking |
| **Graph Properties** | Indegree, outdegree analysis | No traversal needed |

### DFS Code Checklist

✅ **Before Starting DFS**:
- [ ] Choose appropriate graph representation
- [ ] Build adjacency list if needed
- [ ] Initialize `seen` set/array
- [ ] Determine starting node(s)

✅ **During DFS**:
- [ ] Mark node as seen before visiting
- [ ] Check `!seen.Contains(neighbor)` before recursion
- [ ] Handle all neighbors in a loop

✅ **After DFS**:
- [ ] Verify all required nodes were visited
- [ ] Return/accumulate results correctly

---

### 7.7 Graph BFS

BFS on graphs follows the same principles as BFS on trees, but with additional considerations for cycles, multiple paths, and finding shortest paths.

#### When to Use BFS vs DFS on Graphs

**Use BFS When**:
- ✅ Problem asks for **shortest path** (unweighted graphs)
- ✅ Need to explore nodes by **distance from source**
- ✅ Want **minimum steps/moves** to reach target
- ✅ Multiple starting points (multi-source BFS)

**Use DFS When**:
- ✅ Simpler implementation preferred
- ✅ Path length doesn't matter
- ✅ Exploring all possibilities
- ✅ Most other scenarios

> 🔑 **Key Principle**: BFS visits nodes in order of their distance from the starting point. The first time you reach a node with BFS, you've reached it in the **minimum possible steps**.

#### BFS vs DFS Implementation Difference

| Aspect | DFS | BFS |
|--------|-----|-----|
| **Data Structure** | Stack (or recursion) | Queue |
| **Visit Order** | Depth-first | Level-by-level |
| **Shortest Path** | ❌ Not guaranteed | ✅ Guaranteed |
| **Implementation** | Often recursive | Almost always iterative |

#### BFS Template for Graphs

```csharp
void BFS(int startNode, Dictionary<int, List<int>> graph) {
    var seen = new HashSet<int>();
    var queue = new Queue<int>();
    
    queue.Enqueue(startNode);
    seen.Add(startNode);
    int steps = 0;
    
    while (queue.Count > 0) {
        int levelSize = queue.Count;
        
        for (int i = 0; i < levelSize; i++) {
            int node = queue.Dequeue();
            
            // Process node
            // If target found, return steps
            
            foreach (int neighbor in graph[node]) {
                if (!seen.Contains(neighbor)) {
                    seen.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        steps++;
    }
}
```

**Alternative**: Store steps with each node instead of using levels

```csharp
void BFS(int startNode, Dictionary<int, List<int>> graph) {
    var seen = new HashSet<int>();
    var queue = new Queue<(int node, int steps)>();
    
    queue.Enqueue((startNode, 0));
    seen.Add(startNode);
    
    while (queue.Count > 0) {
        var (node, steps) = queue.Dequeue();
        
        // Process node with steps
        
        foreach (int neighbor in graph[node]) {
            if (!seen.Contains(neighbor)) {
                seen.Add(neighbor);
                queue.Enqueue((neighbor, steps + 1));
            }
        }
    }
}
```

#### Time and Space Complexity

**Time Complexity: O(n + e)**
- Same as DFS
- Each node visited at most once
- Each edge traversed at most once

**Space Complexity: O(n + e)**
- `graph`: O(e) for edge storage
- `seen`: O(n) for tracking visited nodes
- `queue`: O(n) worst case (all nodes in queue)

#### Example 1: Shortest Path in Binary Matrix (LeetCode 1091)

**Problem**: Given an `n x n` binary matrix, find the length of the shortest clear path from top-left `(0,0)` to bottom-right `(n-1, n-1)`. Can move 8-directionally. Clear path means all visited cells are `0`.

**Key Insights**:
- Matrix graph with 8-directional movement
- Need **shortest** path → Use BFS
- DFS might find a longer path first
- First time BFS reaches bottom-right = minimum steps

**Why BFS, Not DFS?**
- DFS might explore a longer path and mark cells as visited
- Those cells won't be available for the shorter path
- BFS guarantees shortest path because it explores by distance

**Approach**:
1. Check if start or end is blocked (`grid[0][0] == 1` or `grid[n-1][n-1] == 1`)
2. BFS from `(0,0)` with 8 directions
3. Track distance/steps for each level
4. Return distance when reaching `(n-1, n-1)`

```csharp
public int ShortestPathBinaryMatrix(int[][] grid) {
    int n = grid.Length;
    
    if (grid[0][0] == 1 || grid[n-1][n-1] == 1) return -1;
    
    int[][] directions = new int[][] {
        new int[] {-1, -1}, new int[] {-1, 0}, new int[] {-1, 1},
        new int[] {0, 1}, new int[] {1, 1}, new int[] {1, 0},
        new int[] {1, -1}, new int[] {0, -1}
    };
    
    bool Valid(int row, int col) {
        return row >= 0 && row < n && col >= 0 && col < n && grid[row][col] == 0;
    }
    
    var queue = new Queue<(int row, int col)>();
    bool[][] seen = new bool[n][];
    for (int i = 0; i < n; i++) seen[i] = new bool[n];
    
    queue.Enqueue((0, 0));
    seen[0][0] = true;
    int distance = 1; // Starting cell counts
    
    while (queue.Count > 0) {
        int levelSize = queue.Count;
        
        for (int i = 0; i < levelSize; i++) {
            var (row, col) = queue.Dequeue();
            
            if (row == n - 1 && col == n - 1) return distance;
            
            foreach (var dir in directions) {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                
                if (Valid(newRow, newCol) && !seen[newRow][newCol]) {
                    seen[newRow][newCol] = true;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }
        
        distance++;
    }
    
    return -1;
}
```

**Complexity**:
- **Time**: O(n²) - Visit each cell at most once, constant neighbors (8)
- **Space**: O(n²) - Seen array and queue

#### Example 2: All Nodes Distance K in Binary Tree (LeetCode 863)

**Problem**: Given a binary tree root, a target node, and integer `k`, return all nodes at distance `k` from target.

**Key Insights**:
- Binary trees only have parent → child pointers
- Need to traverse **in all directions** (up to parent, down to children)
- Convert tree to **undirected graph** by adding parent pointers
- BFS from target for exactly `k` steps

**Approach**:
1. DFS to assign parent pointers (create undirected graph)
2. BFS from target node
3. Treat parent, left child, right child as neighbors
4. After `k` levels, return all nodes in queue

```csharp
public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
    // Build parent pointers
    var parents = new Dictionary<TreeNode, TreeNode>();
    
    void DFS(TreeNode node, TreeNode parent) {
        if (node == null) return;
        if (parent != null) parents[node] = parent;
        DFS(node.Left, node);
        DFS(node.Right, node);
    }
    
    DFS(root, null);
    
    // BFS from target
    var queue = new Queue<TreeNode>();
    var seen = new HashSet<TreeNode>();
    
    queue.Enqueue(target);
    seen.Add(target);
    int distance = 0;
    
    while (queue.Count > 0 && distance < k) {
        int levelSize = queue.Count;
        
        for (int i = 0; i < levelSize; i++) {
            var node = queue.Dequeue();
            
            // Check all three neighbors: left, right, parent
            TreeNode[] neighbors = new TreeNode[] { 
                node.Left, 
                node.Right, 
                parents.GetValueOrDefault(node) 
            };
            
            foreach (var neighbor in neighbors) {
                if (neighbor != null && !seen.Contains(neighbor)) {
                    seen.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        distance++;
    }
    
    // Return all nodes at distance k
    return queue.Select(node => node.Val).ToList();
}
```

**Complexity**:
- **Time**: O(n) - DFS visits all nodes, BFS visits each node at most once
- **Space**: O(n) - Parent map, queue, and seen set

#### Example 3: 01 Matrix (LeetCode 542)

**Problem**: Given an `m x n` binary matrix, find the distance of the nearest `0` for each cell.

**Key Insights**:
- Naive approach: BFS from each `1` → O(m² × n²) if matrix is mostly `1`
- Better approach: **Multi-source BFS** from all `0`s simultaneously
- Distance from `x` → `y` = Distance from `y` → `x`
- BFS from all `0`s ensures minimum distance to any `1`

**Multi-Source BFS**:
- Initialize queue with **all `0` cells** (level 0)
- These form the "source" together
- BFS explores outward from all sources simultaneously
- First time reaching a `1` = shortest distance from any `0`

**Approach**:
1. Add all `0` cells to initial queue
2. BFS to find all `1` cells
3. Distance increases by level
4. Update matrix with distances

```csharp
public int[][] UpdateMatrix(int[][] mat) {
    int m = mat.Length;
    int n = mat[0].Length;
    
    int[][] directions = new int[][] {
        new int[] {0, 1}, new int[] {1, 0},
        new int[] {0, -1}, new int[] {-1, 0}
    };
    
    bool Valid(int row, int col) {
        return row >= 0 && row < m && col >= 0 && col < n && mat[row][col] == 1;
    }
    
    var queue = new Queue<(int row, int col)>();
    bool[][] seen = new bool[m][];
    for (int i = 0; i < m; i++) seen[i] = new bool[n];
    
    // Initialize queue with all 0 cells (multi-source BFS)
    for (int row = 0; row < m; row++) {
        for (int col = 0; col < n; col++) {
            if (mat[row][col] == 0) {
                queue.Enqueue((row, col));
                seen[row][col] = true;
            }
        }
    }
    
    int distance = 0;
    
    while (queue.Count > 0) {
        int levelSize = queue.Count;
        distance++;
        
        for (int i = 0; i < levelSize; i++) {
            var (row, col) = queue.Dequeue();
            
            foreach (var dir in directions) {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                
                if (Valid(newRow, newCol) && !seen[newRow][newCol]) {
                    seen[newRow][newCol] = true;
                    mat[newRow][newCol] = distance;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }
    }
    
    return mat;
}
```

**Complexity**:
- **Time**: O(m × n) - Each cell visited once
- **Space**: O(m × n) - Queue and seen array

> 💡 **Multi-Source BFS**: When you need distances from multiple sources, initialize the queue with all source nodes at level 0.

#### State Variables in BFS

Sometimes nodes alone don't describe the complete state. We need additional variables.

**Common State Variables**:
1. **Steps/Distance**: How many steps taken to reach node
2. **Remaining Resources**: Moves, removals, keys left
3. **Previous Action**: Last color used, direction taken
4. **Path Information**: Cells visited, constraints satisfied

**Important**: When adding state variables, include them in `seen`!

```csharp
// State = (node, remainingMoves)
var seen = new HashSet<(int node, int remaining)>();
// OR
bool[,] seen = new bool[n, maxRemaining];
```

#### Example 4: Shortest Path with Obstacles Elimination (LeetCode 1293)

**Problem**: Given `m x n` grid with obstacles (`1`) and empty cells (`0`), find shortest path from top-left to bottom-right. Can eliminate at most `k` obstacles.

**Key Insights**:
- State = `(row, col, remainingRemovals)`
- Can walk on `1` if we have removals left
- Same position with different remainingRemovals = different states
- Track `(position, remaining)` in seen

**Approach**:
1. Start at `(0, 0, k)`
2. For each neighbor:
   - If `0`: move without using removal
   - If `1` and `remain > 0`: move and decrement remain
3. Track `(row, col, remain)` states in seen

```csharp
public int ShortestPath(int[][] grid, int k) {
    int m = grid.Length;
    int n = grid[0].Length;
    
    int[][] directions = new int[][] {
        new int[] {0, 1}, new int[] {1, 0},
        new int[] {0, -1}, new int[] {-1, 0}
    };
    
    bool Valid(int row, int col) {
        return row >= 0 && row < m && col >= 0 && col < n;
    }
    
    // State: (row, col, remainingRemovals)
    var queue = new Queue<(int row, int col, int remain)>();
    int[,] seen = new int[m, n]; // Stores max remain seen at each position
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            seen[i, j] = -1;
        }
    }
    
    queue.Enqueue((0, 0, k));
    int steps = 0;
    
    while (queue.Count > 0) {
        int levelSize = queue.Count;
        
        for (int i = 0; i < levelSize; i++) {
            var (row, col, remain) = queue.Dequeue();
            
            if (row == m - 1 && col == n - 1) return steps;
            
            // If current cell is obstacle, use a removal
            if (grid[row][col] == 1) {
                if (remain == 0) continue;
                remain--;
            }
            
            // Skip if we've been here with more removals
            if (seen[row, col] >= remain) continue;
            seen[row, col] = remain;
            
            foreach (var dir in directions) {
                int newRow = row + dir[0];
                int newCol = col + dir[1];
                
                if (Valid(newRow, newCol)) {
                    queue.Enqueue((newRow, newCol, remain));
                }
            }
        }
        
        steps++;
    }
    
    return -1;
}
```

**Complexity**:
- **Time**: O(m × n × k) - Number of states = positions × remaining values
- **Space**: O(m × n × k) - Seen array and queue

> ⚠️ **State Space**: With `s` state variables, complexity becomes O(states) where states = product of all variable ranges.

#### Example 5: Shortest Path with Alternating Colors (LeetCode 1129)

**Problem**: Directed graph with red/blue edges. Find shortest path from node `0` to all other nodes where edge colors must alternate. Return array where `ans[i]` = shortest alternating path to node `i`, or `-1` if impossible.

**Key Insights**:
- State = `(node, lastColor)`
- Need to track what color edge we just used
- Start BFS from both `(0, RED)` and `(0, BLUE)`
- Only traverse edges of alternating color
- May visit same node twice (once per color)

**Approach**:
1. Build separate graphs for red and blue edges
2. Multi-source BFS starting from `(0, RED)` and `(0, BLUE)`
3. For each state `(node, color)`, only traverse edges of `1 - color`
4. Track `seen[node][color]` as 2D array

```csharp
public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges) {
    const int RED = 0;
    const int BLUE = 1;
    
    // Build separate graphs for each color
    var graph = new Dictionary<int, List<int>>[2];
    graph[RED] = new Dictionary<int, List<int>>();
    graph[BLUE] = new Dictionary<int, List<int>>();
    
    for (int i = 0; i < n; i++) {
        graph[RED][i] = new List<int>();
        graph[BLUE][i] = new List<int>();
    }
    
    foreach (var edge in redEdges) {
        graph[RED][edge[0]].Add(edge[1]);
    }
    
    foreach (var edge in blueEdges) {
        graph[BLUE][edge[0]].Add(edge[1]);
    }
    
    // BFS with state (node, color)
    var queue = new Queue<(int node, int color)>();
    bool[][] seen = new bool[n][];
    for (int i = 0; i < n; i++) seen[i] = new bool[2];
    
    int[] ans = new int[n];
    Array.Fill(ans, int.MaxValue);
    
    // Start from node 0 with both colors
    queue.Enqueue((0, RED));
    queue.Enqueue((0, BLUE));
    seen[0][RED] = true;
    seen[0][BLUE] = true;
    
    int steps = 0;
    
    while (queue.Count > 0) {
        int levelSize = queue.Count;
        
        for (int i = 0; i < levelSize; i++) {
            var (node, color) = queue.Dequeue();
            ans[node] = Math.Min(ans[node], steps);
            
            // Traverse edges of opposite color
            int nextColor = 1 - color;
            foreach (int neighbor in graph[nextColor][node]) {
                if (!seen[neighbor][nextColor]) {
                    seen[neighbor][nextColor] = true;
                    queue.Enqueue((neighbor, nextColor));
                }
            }
        }
        
        steps++;
    }
    
    // Convert unreachable nodes to -1
    for (int i = 0; i < n; i++) {
        if (ans[i] == int.MaxValue) ans[i] = -1;
    }
    
    return ans;
}
```

**Complexity**:
- **Time**: O(n + e) - Color range is constant (2)
- **Space**: O(n + e) - Graphs, seen array, and queue

> 💡 **Color Switching Trick**: To flip between 0 and 1, use `1 - color`. Works because `1 - 0 = 1` and `1 - 1 = 0`.

### Graph BFS Key Insights

1. **Shortest Path Guarantee**: BFS always finds shortest path in unweighted graphs
2. **Level-by-Level Exploration**: Each while loop iteration = one level/distance
3. **Multi-Source BFS**: Initialize queue with multiple starting nodes for multiple sources
4. **State Variables**: Include additional data beyond node when needed
5. **Seen Must Match State**: If state = `(node, x)`, seen should track `(node, x)` pairs
6. **Queue vs Stack**: Queue (BFS) for shortest path, Stack/Recursion (DFS) for exploration

### BFS Pattern Recognition

| Problem Type | Key Indicator | Approach |
|--------------|---------------|----------|
| **Shortest Path** | Minimum steps, shortest distance | BFS from source |
| **Multi-Source** | Distance from multiple points | Initialize queue with all sources |
| **State Tracking** | Constraints, resources, colors | Add state variables to BFS |
| **Level Processing** | Same-level operations | Use level-size loop |
| **Alternating Constraints** | Must alternate actions | Track last action in state |

### BFS Code Checklist

✅ **Before Starting BFS**:
- [ ] Identify all state variables needed
- [ ] Choose queue element structure `(node)` or `(node, state...)`
- [ ] Initialize queue with starting state(s)
- [ ] Set up seen structure matching state
- [ ] Determine if you need level-by-level processing

✅ **During BFS**:
- [ ] Mark states as seen before adding to queue
- [ ] Process entire level if needed (level-size loop)
- [ ] Check if target reached (can return early)
- [ ] Validate neighbors before adding to queue

✅ **After BFS**:
- [ ] Handle unreachable nodes (return -1 or special value)
- [ ] Verify all required nodes were processed
- [ ] Return correct result format

### BFS Implementation Tips

```csharp
// Tip 1: Level-by-level processing
while (queue.Count > 0) {
    int levelSize = queue.Count; // Capture current level size
    for (int i = 0; i < levelSize; i++) {
        // Process one node
    }
    steps++; // Increment after each level
}

// Tip 2: Storing steps with each node
var queue = new Queue<(int node, int steps)>();
queue.Enqueue((start, 0));
while (queue.Count > 0) {
    var (node, steps) = queue.Dequeue();
    // Use steps directly, no level tracking needed
    queue.Enqueue((neighbor, steps + 1));
}

// Tip 3: Multi-source initialization
foreach (var source in allSources) {
    queue.Enqueue(source);
    seen.Add(source);
}

// Tip 4: State in seen
// If state = (node, color, remaining)
var seen = new HashSet<(int, int, int)>();
// Or use multi-dimensional array
bool[,,] seen = new bool[n, colors, maxRemaining];
```

---

### 7.8 Implicit Graphs

Implicit graphs are problems where the graph structure isn't explicitly given in the input. Instead, you need to recognize that states and transitions can be modeled as nodes and edges.

#### What Are Implicit Graphs?

**Definition**: A graph that exists conceptually based on problem rules, but isn't directly provided in standard graph formats (adjacency list, matrix, edge array).

**Key Recognition Signs**:
- Problem involves **transitioning between states**
- Asks for **minimum steps/operations/moves**
- No obvious graph in the input format
- Need to figure out what nodes and edges represent

> 🔑 **Remember**: A graph is ANY collection of elements (nodes) connected by relationships (edges). If you can define states and transitions, you have a graph!

#### When to Recognize Implicit Graphs

| Problem Characteristic | Graph Element | Example |
|------------------------|---------------|---------|
| **States/Configurations** | Nodes | Lock combinations, board positions |
| **Transitions/Rules** | Edges | Moving between states, transformations |
| **"Minimum steps to..."** | BFS needed | Shortest path in state space |
| **"Can we reach..."** | DFS/BFS | Reachability in state space |

#### Implicit Graph vs Explicit Graph

| Aspect | Explicit Graph | Implicit Graph |
|--------|----------------|----------------|
| **Input Format** | Adjacency list, matrix, edges | Problem description, rules |
| **Nodes Given** | ✅ Yes | ❌ Must identify |
| **Edges Given** | ✅ Yes | ❌ Must determine |
| **Graph Construction** | Direct from input | Infer from problem logic |
| **Neighbor Function** | Read from structure | Generate dynamically |

#### Building Implicit Graphs

**Step-by-Step Approach**:
1. **Identify Nodes**: What are the possible states?
2. **Define Edges**: What transitions are allowed between states?
3. **Determine Start**: What's the initial state?
4. **Determine Goal**: What's the target state or condition?
5. **Choose Traversal**: BFS for shortest path, DFS for exploration

#### Example 1: Open the Lock (LeetCode 752)

**Problem**: 4-wheel lock, each wheel has digits 0-9 (circular). Start at "0000", one move = turn one wheel by ±1. Given `deadends` (forbidden states) and `target`, return minimum moves to reach target, or -1.

**Implicit Graph Recognition**:
- **Nodes**: All possible lock combinations "0000" to "9999" (10,000 states)
- **Edges**: Two combinations are neighbors if they differ by exactly 1 in exactly 1 position
- **Start**: "0000"
- **Goal**: `target` string
- **Constraint**: Cannot visit `deadends`

**Why BFS?**: Need minimum number of moves → shortest path problem

**Neighbor Generation**:
- For each of 4 positions:
  - Increment digit: `(digit + 1) % 10` (handles 9→0 wrap)
  - Decrement digit: `(digit - 1 + 10) % 10` (handles 0→9 wrap)
- Each node has exactly 8 neighbors (4 positions × 2 directions)

**Approach**:
1. Initialize `seen` with all `deadends` (can't visit these)
2. BFS from "0000"
3. For each state, generate 8 neighbors
4. Return steps when reaching `target`

```csharp
public int OpenLock(string[] deadends, string target) {
    // Check if start is blocked
    if (deadends.Contains("0000")) return -1;
    
    // Helper: Generate all neighbors of a lock state
    List<string> GetNeighbors(string node) {
        var neighbors = new List<string>();
        
        for (int i = 0; i < 4; i++) {
            int digit = node[i] - '0';
            
            // Try incrementing and decrementing
            foreach (int change in new int[] { -1, 1 }) {
                int newDigit = (digit + change + 10) % 10;
                string neighbor = node.Substring(0, i) + newDigit + node.Substring(i + 1);
                neighbors.Add(neighbor);
            }
        }
        
        return neighbors;
    }
    
    // BFS
    var queue = new Queue<string>();
    var seen = new HashSet<string>(deadends);
    
    queue.Enqueue("0000");
    seen.Add("0000");
    int steps = 0;
    
    while (queue.Count > 0) {
        int levelSize = queue.Count;
        
        for (int i = 0; i < levelSize; i++) {
            string node = queue.Dequeue();
            
            if (node == target) return steps;
            
            foreach (string neighbor in GetNeighbors(node)) {
                if (!seen.Contains(neighbor)) {
                    seen.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        steps++;
    }
    
    return -1;
}
```

**Complexity**:
- **Time**: O(10^n × n²) where n = number of wheels (4)
  - 10^n possible states
  - O(n²) work per state (n wheels, O(n) string operations)
  - With n=4: O(10,000 × 16) ≈ O(160,000) = O(1) practically
- **Space**: O(10^n) for queue and seen

> 💡 **String Immutability**: In C#/Java, string concatenation is O(n). With mutable strings (StringBuilder), it's O(n) total instead of O(n²) per state.

#### Example 2: Evaluate Division (LeetCode 399)

**Problem**: Given equations like `a/b = 2` and `b/c = 3`, answer queries like "what is `a/c`?". Return -1 if can't determine.

**Implicit Graph Recognition**:
- **Nodes**: Variables (a, b, c, etc.)
- **Edges**: Equations define relationships with **weights**
- **Edge Weight**: The division value
- **Goal**: Find path from numerator to denominator, multiply weights along path

**Key Insight**: 
- If `a/b = 2`, then `a` is 2 times bigger than `b`
- Edge `a → b` has weight 2
- Edge `b → a` has weight 1/2 (reciprocal, since `b/a = 0.5`)
- Edges are **undirected** (bidirectional with reciprocal weights)

**Graph as Weighted Relationships**:
```
Given: a/b = 5, b/c = 2

Graph:
  a --5--> b --2--> c
  a <--0.2-- b <--0.5-- c

Path a → b → c:
  Start: ratio = 1
  a → b: ratio = 1 × 5 = 5
  b → c: ratio = 5 × 2 = 10
  Answer: a/c = 10
```

**Approach**:
1. Build weighted graph: for each `x/y = val`, add:
   - `graph[x][y] = val`
   - `graph[y][x] = 1/val`
2. For each query `(a, b)`:
   - Traverse from `a` to `b` (DFS or BFS)
   - Track cumulative ratio (multiply weights along path)
   - Return ratio if `b` reached, else -1

```csharp
public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
    // Build weighted graph
    var graph = new Dictionary<string, Dictionary<string, double>>();
    
    for (int i = 0; i < equations.Count; i++) {
        string numerator = equations[i][0];
        string denominator = equations[i][1];
        double value = values[i];
        
        if (!graph.ContainsKey(numerator)) {
            graph[numerator] = new Dictionary<string, double>();
        }
        if (!graph.ContainsKey(denominator)) {
            graph[denominator] = new Dictionary<string, double>();
        }
        
        graph[numerator][denominator] = value;
        graph[denominator][numerator] = 1.0 / value;
    }
    
    // Answer each query with DFS
    double AnswerQuery(string start, string end) {
        if (!graph.ContainsKey(start)) return -1.0;
        
        var seen = new HashSet<string>();
        var stack = new Stack<(string node, double ratio)>();
        
        stack.Push((start, 1.0));
        seen.Add(start);
        
        while (stack.Count > 0) {
            var (node, ratio) = stack.Pop();
            
            if (node == end) return ratio;
            
            if (graph.ContainsKey(node)) {
                foreach (var (neighbor, weight) in graph[node]) {
                    if (!seen.Contains(neighbor)) {
                        seen.Add(neighbor);
                        stack.Push((neighbor, ratio * weight));
                    }
                }
            }
        }
        
        return -1.0;
    }
    
    var result = new double[queries.Count];
    for (int i = 0; i < queries.Count; i++) {
        result[i] = AnswerQuery(queries[i][0], queries[i][1]);
    }
    
    return result;
}
```

**Complexity**:
- **Time**: O(q × (n + e)) where q = queries, n = variables, e = equations
  - Each query does one graph traversal: O(n + e)
  - q queries total
- **Space**: O(n + e) for graph, seen, and stack

> 🎓 **Weighted Graphs**: This is a simple weighted graph problem. More complex weighted graph algorithms (Dijkstra, Bellman-Ford) are typically out of scope for most interviews.

### Implicit Graph Key Insights

1. **State Space = Graph**: Any problem with states and transitions can be a graph
2. **Generate Don't Store**: For large state spaces, generate neighbors on-the-fly
3. **BFS for Shortest Path**: When asking "minimum X to reach Y", use BFS
4. **Define Clear Rules**: Clearly define what constitutes a node and an edge
5. **Watch State Size**: State space can grow exponentially (10^n for n-digit lock)
6. **Seen is Critical**: Even more important in implicit graphs to avoid revisiting states

### Implicit Graph Pattern Recognition

| Problem Keywords | Graph Elements | Likely Approach |
|------------------|----------------|-----------------|
| "Minimum moves/steps to" | States as nodes, moves as edges | BFS |
| "Transform A to B" | Configurations as nodes | BFS/DFS |
| "Can we reach/achieve" | States and transitions | DFS/BFS |
| "Shortest sequence" | Steps as nodes | BFS |
| "Given rules/operations" | Operations define edges | Generate neighbors |
| "Word ladder", "gene mutation" | Strings as nodes, 1-change as edge | BFS |

### Common Implicit Graph Scenarios

#### 1. **Combinatorial States** (Lock, Puzzle)
- Nodes: All possible configurations
- Edges: Valid moves/transformations
- Example: Rubik's cube, sliding puzzle, lock combinations

#### 2. **String Transformations** (Word Ladder)
- Nodes: Valid strings
- Edges: Single character change
- Example: "hit" → "hot" → "dot" → "dog" → "cog"

#### 3. **Mathematical Relationships** (Equations, Ratios)
- Nodes: Variables or numbers
- Edges: Mathematical operations or relationships
- Example: Equation chains, number transformations

#### 4. **Game States** (Chess, Tic-Tac-Toe)
- Nodes: Board configurations
- Edges: Valid moves
- Example: Chess positions, game trees

### Implicit Graph Implementation Tips

```csharp
// Tip 1: Neighbor generation function
List<State> GetNeighbors(State current) {
    var neighbors = new List<State>();
    // Generate all valid next states based on problem rules
    foreach (var operation in validOperations) {
        State next = ApplyOperation(current, operation);
        if (IsValid(next)) {
            neighbors.Add(next);
        }
    }
    return neighbors;
}

// Tip 2: Use appropriate data structure for states
// Simple states: strings, integers
var seen = new HashSet<string>();

// Complex states: tuples, custom classes with GetHashCode/Equals
var seen = new HashSet<(int x, int y, int z)>();

// Tip 3: Optimize string operations
// Instead of: s.Substring(0, i) + digit + s.Substring(i + 1)
// Use: char[] array, modify, then new string(array)
char[] arr = s.ToCharArray();
arr[i] = newDigit;
string neighbor = new string(arr);

// Tip 4: Early termination
if (current == target) {
    return steps; // Found answer, stop immediately
}

// Tip 5: Validate before adding to queue
if (IsValid(neighbor) && !seen.Contains(neighbor)) {
    seen.Add(neighbor);
    queue.Enqueue(neighbor);
}
```

### Implicit Graph Checklist

✅ **Problem Analysis**:
- [ ] Does problem involve states/configurations?
- [ ] Are there transitions/operations between states?
- [ ] Is there a starting state and goal state?
- [ ] Does "minimum/shortest" appear in the problem?

✅ **Graph Design**:
- [ ] What represents a node? (state definition)
- [ ] What represents an edge? (transition rules)
- [ ] How to generate neighbors? (operation logic)
- [ ] What's the state space size? (feasibility check)

✅ **Implementation**:
- [ ] Choose BFS (shortest path) or DFS (exploration)
- [ ] Implement neighbor generation function
- [ ] Handle invalid/blocked states
- [ ] Use appropriate data structure for seen
- [ ] Track steps/distance appropriately

---

## Study Progress

### ✅ Completed Sections

- [x] **Introduction & Big O** - Algorithm fundamentals and complexity analysis
- [x] **Recursion** - Recursive problem-solving and function calls  
- [x] **Array & String Basics** - Core concepts and time complexities
- [x] **Two Pointers** - Efficient traversal techniques
- [x] **Sliding Window** - Subarray optimization problems
- [x] **Prefix Sum** - Fast range query techniques
- [x] **Subarrays, Subsequences, and Subsets** - Understanding different data groupings
- [x] **Hashing Fundamentals** - Hash maps and sets concepts
- [x] **Existence Checking** - O(1) lookup patterns
- [x] **Counting Patterns** - Frequency tracking and constraints
- [x] **More Hashing Patterns** - Advanced grouping and optimization techniques
- [x] **LinkedList Fundamentals** - Node structures, types, and pointer manipulation
- [x] **Fast and Slow Pointers** - Two-pointer techniques for cycle detection and traversal
- [x] **LinkedList Reversals** - Algorithms for reversing entire or partial linked lists
- [x] **Stack Fundamentals** - LIFO structure, operations, and implementation
- [x] **String Problems with Stacks** - Parentheses validation, duplicate removal, and character matching
- [x] **Queue Fundamentals** - FIFO structure, implementations, and sliding time windows
- [x] **Monotonic Stacks and Queues** - Maintaining sorted order for next element and window extremes problems
- [x] **Binary Trees** - Tree fundamentals, terminology, and node structure
- [x] **Depth-First Search (DFS)** - Tree traversals (preorder, inorder, postorder) and recursive problem-solving
- [x] **Breadth-First Search (BFS)** - Level-order traversal and queue-based algorithms
- [x] **Binary Search Trees (BST)** - BST properties, inorder traversal, and optimized search operations
- [x] **Graph Introduction** - Graph fundamentals, terminology, and representations
- [x] **Graph DFS** - Depth-first search on graphs, connected components, and cycle detection
- [x] **Graph BFS** - Breadth-first search, shortest paths, and multi-source BFS
- [x] **Implicit Graphs** - State space search and recognizing hidden graph structures

### 🔄 Currently Studying

- Trees and Graphs - Advanced topics and practice problems

### 📋 Next Topics

- Graphs - DFS and BFS on graphs
- Implicit Graphs
- Heaps and Priority Queues
- Dynamic Programming
- Backtracking

---

## Quick Reference

### Time Complexity Cheat Sheet

```text
O(1) < O(log n) < O(n) < O(n log n) < O(n²) < O(2ⁿ)
```

### Common Patterns Recognition

| Problem Keywords | Technique | Time Complexity |
|------------------|-----------|-----------------|
| "Two sum", "Pair", "Palindrome" | Two Pointers | O(n) |
| "Subarray", "Substring", "Window" | Sliding Window | O(n) |
| "Range sum", "Subarray sum" | Prefix Sum | O(n) preprocessing, O(1) query |
| "Connected", "Path", "Tree" | DFS/BFS | O(V + E) |
| "Optimal", "Maximum", "Minimum" | Dynamic Programming | Varies |

### Debugging Tips

1. **Test with small examples** first
2. **Trace through step-by-step** for understanding
3. **Check edge cases**: empty arrays, single elements
4. **Verify time/space complexity** meets requirements
5. **Consider alternative approaches** if stuck

---

## 🎯 Study Tips

1. **Practice Consistently**: Solve problems daily, even if just 15-30 minutes
2. **Understand Before Memorizing**: Focus on the "why" behind each technique
3. **Start Simple**: Master basic patterns before moving to complex problems
4. **Code by Hand**: Practice writing algorithms without IDE assistance
5. **Review Regularly**: Revisit completed topics to reinforce learning

---

**Last Updated:** January 2025  
**Current Focus:** Trees and Graphs - Binary Trees and DFS Mastery

> 💡 **Remember**: The goal isn't just to solve problems, but to recognize patterns and choose the most efficient approach for each situation!
