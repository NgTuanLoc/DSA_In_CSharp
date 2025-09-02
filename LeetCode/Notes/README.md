# Data Structures and Algorithms Learning Guide

Welcome to my comprehensive guide for learning Data Structures and Algorithms! This README organizes my study notes and provides a structured path for understanding fundamental DSA concepts.

## 📚 Table of Contents

- [Data Structures and Algorithms Learning Guide](#data-structures-and-algorithms-learning-guide)
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

## Study Progress

### ✅ Completed Sections

- [x] **Introduction & Big O** - Algorithm fundamentals and complexity analysis
- [x] **Recursion** - Recursive problem-solving and function calls  
- [x] **Array & String Basics** - Core concepts and time complexities
- [x] **Two Pointers** - Efficient traversal techniques
- [x] **Sliding Window** - Subarray optimization problems
- [x] **Prefix Sum** - Fast range query techniques

### 🔄 Currently Studying

- More Common Patterns in Arrays/Strings

### 📋 Next Topics

- Trees and Graphs
- Binary Search Trees
- Depth-First Search (DFS)
- Breadth-First Search (BFS)
- Heaps and Priority Queues
- Hashing techniques
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

**Last Updated:** September 2, 2025  
**Current Focus:** Arrays and Strings Mastery

> 💡 **Remember**: The goal isn't just to solve problems, but to recognize patterns and choose the most efficient approach for each situation!