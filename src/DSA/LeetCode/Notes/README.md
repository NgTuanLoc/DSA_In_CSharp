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

**Last Updated:** September 2, 2025  
**Current Focus:** Arrays and Strings Mastery

> 💡 **Remember**: The goal isn't just to solve problems, but to recognize patterns and choose the most efficient approach for each situation!
