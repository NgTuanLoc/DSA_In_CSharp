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

### 🔄 Currently Studying

- Trees and Graphs fundamentals

### 📋 Next Topics

- Binary Search Trees
- Depth-First Search (DFS)
- Breadth-First Search (BFS)
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
**Current Focus:** Stacks and Queues Mastery

> 💡 **Remember**: The goal isn't just to solve problems, but to recognize patterns and choose the most efficient approach for each situation!
