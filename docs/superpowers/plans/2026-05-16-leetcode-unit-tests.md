# LeetCode Section Unit Tests Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Close the unit-test gap in `src/DSA/LeetCode/` by adding xUnit test coverage for every untested production class: Backtracking (Permutation, Subsets, Combination), DynamicProgramming (MinCostClimbingStairs, HouseRobber, LongestIncreasingSubsequence, MostPoints, ClimbStairs, CoinChange), plus minor cleanup (delete an unused duplicate `Hashing` class and promote `Subsets_Solution` to `public`).

**Architecture:** All new tests live under `src/DSA.Tests/LeetCode/{Pattern}/{ClassName}Tests.cs` mirroring the existing convention (see `src/DSA.Tests/LeetCode/Hashing/CheckForExistenceTests.cs`). Each new test file uses `using DSA.LeetCode.{Pattern};` + `namespace DSA.Tests.LeetCode.{Pattern};`. Two new pattern folders are created where the test folder is missing: `Backtracking/` and `DynamicProgramming/`.

**Tech Stack:** .NET 10, C# with nullable reference types, xUnit (`[Fact]`, `[Theory]`, `[InlineData]`), coverlet for coverage.

---

## Coverage scope — what each section adds

| File | Production code | New test file | Test count |
|------|-----------------|---------------|------------|
| Source cleanup | Delete duplicate `Hashing` class in `Hashing/CheckForExistence.cs` | — | — |
| Source change | Make `Subsets_Solution` public in `Backtracking/Generation.cs` | — | — |
| Backtracking | `Permutation_Solution.Permute` | `Backtracking/PermutationTests.cs` | 5 |
| Backtracking | `Subsets_Solution.Subsets` | `Backtracking/SubsetsTests.cs` | 5 |
| Backtracking | `Combination_Solution.Combine` | `Backtracking/CombinationTests.cs` | 5 |
| DP | `MinCostClimbingStairsSolution` (3 entry points) | `DynamicProgramming/MinCostClimbingStairsTests.cs` | 7 |
| DP | `OneDirectionSolution` (Rob — 3 entry points) | `DynamicProgramming/HouseRobberTests.cs` | 6 |
| DP | `LongestIncreasingSubsequenceSolution` (3 entry points) | `DynamicProgramming/LongestIncreasingSubsequenceTests.cs` | 6 |
| DP | `SolvingQuestionsWithBrainpowerSolution.MostPoints` | `DynamicProgramming/MostPointsTests.cs` | 3 |
| DP | `ClimbStairsSolution` (2 entry points) | `DynamicProgramming/ClimbStairsTests.cs` | 5 |
| DP | `CoinChangeSolution.CoinChange` | `DynamicProgramming/CoinChangeTests.cs` | 5 |

**Why test-after-the-fact (not strict TDD):** Production code already exists. Tests are characterization tests that lock down current observable behavior. If a test fails on first run, treat it as a discovered bug — stop and ask before "fixing the test to match the bug."

---

## Conventions every task must follow

- **Test class name:** `{Method or Class}Tests`. **Test method name:** `MethodName_Condition_ExpectedBehavior`.
- **AAA pattern:** Arrange-Act-Assert with blank line between sections (see `src/DSA.Tests/LeetCode/Hashing/CheckForExistenceTests.cs`).
- **XML doc comments:** Each fact gets a `/// <summary>` describing what's tested plus the LeetCode URL where applicable.
- **`[Theory]` + `[InlineData]`** for the same assertion shape over multiple inputs; reserve `[Fact]` for one-of-a-kind scenarios.
- **Run a single test class:** `dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.<Pattern>.<TestClass>"`.
- **Run full suite after each task:** `dotnet test --nologo`.
- **Conventional commits:** `test: <imperative description>` for test-only changes; `refactor:` for source visibility/cleanup.
- **Working directory:** `D:\Projects\Data Structure and Algorithm\DSA_In_CSharp` (repo root).

---

# Section 1 — Source preparation

### Task 1: Delete the unused duplicate `Hashing` class

**Files:**
- Modify: `src/DSA/LeetCode/Hashing/CheckForExistence.cs`

The file `Hashing/CheckForExistence.cs` defines `public class Hashing` whose 6 methods (`TwoSum`, `RepeatedCharacter`, `FindNumbers`, `CheckIfPangram`, `MissingNumber`, `CountElements`) are duplicates of the actively-tested `CheckForExistence` class in `Hashing/Hashing.cs`. Every reference to `Hashing.X(...)` in the codebase is commented out in `Example.cs`. Safe to delete.

- [ ] **Step 1: Confirm there are no live references**

Run: `grep -rE "\bHashing\.(TwoSum|RepeatedCharacter|FindNumbers|CheckIfPangram|MissingNumber|CountElements)" src --include="*.cs"`
Expected: only matches in `src/DSA/LeetCode/Hashing/Example.cs`, and every match is inside a `//`-commented line.

- [ ] **Step 2: Replace the file contents**

Overwrite `src/DSA/LeetCode/Hashing/CheckForExistence.cs` with the empty stub (file kept because the filename pairs with the test file name; the class it claims to define lives in `Hashing.cs`):

```csharp
namespace DSA.LeetCode.Hashing;

// The CheckForExistence class is defined in Hashing.cs (filename/class mismatch is pre-existing).
// This file previously held a duplicate `Hashing` class that has been removed.
```

- [ ] **Step 3: Build to verify nothing breaks**

Run: `dotnet build --nologo`
Expected: 0 errors.

- [ ] **Step 4: Run the full test suite**

Run: `dotnet test --nologo`
Expected: PASS, all existing tests still green.

- [ ] **Step 5: Commit**

```bash
git add src/DSA/LeetCode/Hashing/CheckForExistence.cs
git commit -m "refactor: remove unused duplicate Hashing class"
```

### Task 2: Make `Subsets_Solution` public

**Files:**
- Modify: `src/DSA/LeetCode/Backtracking/Generation.cs`

`Subsets_Solution` is declared without an access modifier, so it defaults to `internal` and cannot be referenced from the test assembly. The other two solution classes in the same file are `public` — this aligns with that convention.

- [ ] **Step 1: Edit the class declaration**

In `src/DSA/LeetCode/Backtracking/Generation.cs`, change:

```csharp
class Subsets_Solution
```

to:

```csharp
public class Subsets_Solution
```

- [ ] **Step 2: Build to verify**

Run: `dotnet build --nologo`
Expected: 0 errors.

- [ ] **Step 3: Run the full test suite**

Run: `dotnet test --nologo`
Expected: PASS, no regressions.

- [ ] **Step 4: Commit**

```bash
git add src/DSA/LeetCode/Backtracking/Generation.cs
git commit -m "refactor: make Subsets_Solution public for testability"
```

---

# Section 2 — Backtracking tests

### Task 3: PermutationTests

**Files:**
- Create: `src/DSA.Tests/LeetCode/Backtracking/PermutationTests.cs`

- [ ] **Step 1: Create the test file**

Create `src/DSA.Tests/LeetCode/Backtracking/PermutationTests.cs`:

```csharp
using DSA.LeetCode.Backtracking;

namespace DSA.Tests.LeetCode.Backtracking;

public class PermutationTests
{
    /// <summary>
    /// Tests Permute returns all n! permutations of a 3-element array.
    /// https://leetcode.com/problems/permutations/description/
    /// </summary>
    [Fact]
    public void Permute_ThreeElements_ReturnsSixPermutations()
    {
        var result = Permutation_Solution.Permute([1, 2, 3]);

        Assert.Equal(6, result.Count);
        Assert.Contains(result, p => p.SequenceEqual(new[] { 1, 2, 3 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 1, 3, 2 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 2, 1, 3 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 2, 3, 1 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 3, 1, 2 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 3, 2, 1 }));
    }

    /// <summary>
    /// Tests Permute on a single-element array — only the identity permutation exists.
    /// </summary>
    [Fact]
    public void Permute_SingleElement_ReturnsOnePermutation()
    {
        var result = Permutation_Solution.Permute([42]);

        Assert.Single(result);
        Assert.Equal(new[] { 42 }, result[0]);
    }

    /// <summary>
    /// Tests Permute on a two-element array returns both orderings.
    /// </summary>
    [Fact]
    public void Permute_TwoElements_ReturnsTwoPermutations()
    {
        var result = Permutation_Solution.Permute([0, 1]);

        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.SequenceEqual(new[] { 0, 1 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 1, 0 }));
    }

    /// <summary>
    /// Tests Permute returns 24 permutations for a 4-element array (4! = 24).
    /// </summary>
    [Fact]
    public void Permute_FourElements_ReturnsTwentyFourPermutations()
    {
        var result = Permutation_Solution.Permute([1, 2, 3, 4]);

        Assert.Equal(24, result.Count);
        Assert.Equal(24, result.Select(p => string.Join(",", p)).Distinct().Count());
    }

    /// <summary>
    /// Tests every permutation contains exactly the input elements.
    /// </summary>
    [Fact]
    public void Permute_AllResults_ContainOriginalElementsExactlyOnce()
    {
        var input = new[] { 5, 6, 7 };

        var result = Permutation_Solution.Permute(input);

        Assert.All(result, p =>
        {
            Assert.Equal(input.Length, p.Count);
            Assert.Equal(input.OrderBy(x => x), p.OrderBy(x => x));
        });
    }
}
```

- [ ] **Step 2: Run the test class**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.Backtracking.PermutationTests" --nologo`
Expected: PASS (5 tests).

- [ ] **Step 3: Commit**

```bash
git add src/DSA.Tests/LeetCode/Backtracking/PermutationTests.cs
git commit -m "test: cover Permutation_Solution.Permute"
```

### Task 4: SubsetsTests

**Files:**
- Create: `src/DSA.Tests/LeetCode/Backtracking/SubsetsTests.cs`

- [ ] **Step 1: Create the test file**

Create `src/DSA.Tests/LeetCode/Backtracking/SubsetsTests.cs`:

```csharp
using DSA.LeetCode.Backtracking;

namespace DSA.Tests.LeetCode.Backtracking;

public class SubsetsTests
{
    /// <summary>
    /// Tests Subsets returns all 2^n subsets including the empty set.
    /// https://leetcode.com/problems/subsets/
    /// </summary>
    [Fact]
    public void Subsets_ThreeElements_ReturnsEightSubsets()
    {
        var result = Subsets_Solution.Subsets([1, 2, 3]);

        Assert.Equal(8, result.Count);
        Assert.Contains(result, s => s.Count == 0);
        Assert.Contains(result, s => s.SequenceEqual(new[] { 1 }));
        Assert.Contains(result, s => s.SequenceEqual(new[] { 2 }));
        Assert.Contains(result, s => s.SequenceEqual(new[] { 3 }));
        Assert.Contains(result, s => s.SequenceEqual(new[] { 1, 2 }));
        Assert.Contains(result, s => s.SequenceEqual(new[] { 1, 3 }));
        Assert.Contains(result, s => s.SequenceEqual(new[] { 2, 3 }));
        Assert.Contains(result, s => s.SequenceEqual(new[] { 1, 2, 3 }));
    }

    /// <summary>
    /// Tests Subsets on an empty array returns a single empty subset.
    /// </summary>
    [Fact]
    public void Subsets_EmptyArray_ReturnsOneEmptySubset()
    {
        var result = Subsets_Solution.Subsets([]);

        Assert.Single(result);
        Assert.Empty(result[0]);
    }

    /// <summary>
    /// Tests Subsets on a single element returns [[], [x]].
    /// </summary>
    [Fact]
    public void Subsets_SingleElement_ReturnsTwoSubsets()
    {
        var result = Subsets_Solution.Subsets([7]);

        Assert.Equal(2, result.Count);
        Assert.Contains(result, s => s.Count == 0);
        Assert.Contains(result, s => s.SequenceEqual(new[] { 7 }));
    }

    /// <summary>
    /// Tests Subsets generates 2^n total subsets for n=4.
    /// </summary>
    [Fact]
    public void Subsets_FourElements_ReturnsSixteenSubsets()
    {
        var result = Subsets_Solution.Subsets([1, 2, 3, 4]);

        Assert.Equal(16, result.Count);
    }

    /// <summary>
    /// Tests all returned subsets preserve increasing positional order of input.
    /// </summary>
    [Fact]
    public void Subsets_AllSubsets_PreserveInputOrder()
    {
        var result = Subsets_Solution.Subsets([10, 20, 30]);

        Assert.All(result, s =>
        {
            for (var i = 1; i < s.Count; i++)
                Assert.True(s[i - 1] < s[i], "Subset elements should appear in input order");
        });
    }
}
```

- [ ] **Step 2: Run the test class**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.Backtracking.SubsetsTests" --nologo`
Expected: PASS (5 tests).

- [ ] **Step 3: Commit**

```bash
git add src/DSA.Tests/LeetCode/Backtracking/SubsetsTests.cs
git commit -m "test: cover Subsets_Solution.Subsets"
```

### Task 5: CombinationTests

**Files:**
- Create: `src/DSA.Tests/LeetCode/Backtracking/CombinationTests.cs`

- [ ] **Step 1: Create the test file**

Create `src/DSA.Tests/LeetCode/Backtracking/CombinationTests.cs`:

```csharp
using DSA.LeetCode.Backtracking;

namespace DSA.Tests.LeetCode.Backtracking;

public class CombinationTests
{
    /// <summary>
    /// Tests Combine(4, 2) returns C(4,2) = 6 combinations.
    /// https://leetcode.com/problems/combinations/
    /// </summary>
    [Fact]
    public void Combine_FourChooseTwo_ReturnsSixCombinations()
    {
        var result = Combination_Solution.Combine(4, 2);

        Assert.Equal(6, result.Count);
        Assert.Contains(result, c => c.SequenceEqual(new[] { 1, 2 }));
        Assert.Contains(result, c => c.SequenceEqual(new[] { 1, 3 }));
        Assert.Contains(result, c => c.SequenceEqual(new[] { 1, 4 }));
        Assert.Contains(result, c => c.SequenceEqual(new[] { 2, 3 }));
        Assert.Contains(result, c => c.SequenceEqual(new[] { 2, 4 }));
        Assert.Contains(result, c => c.SequenceEqual(new[] { 3, 4 }));
    }

    /// <summary>
    /// Tests Combine(n, 1) returns exactly n singleton combinations.
    /// </summary>
    [Theory]
    [InlineData(1, 1)]
    [InlineData(3, 3)]
    [InlineData(5, 5)]
    public void Combine_KEqualsOne_ReturnsNSingletons(int n, int expected)
    {
        var result = Combination_Solution.Combine(n, 1);

        Assert.Equal(expected, result.Count);
        Assert.All(result, c => Assert.Single(c));
    }

    /// <summary>
    /// Tests Combine(n, n) returns exactly one combination — the full range 1..n.
    /// </summary>
    [Fact]
    public void Combine_KEqualsN_ReturnsSingleFullCombination()
    {
        var result = Combination_Solution.Combine(4, 4);

        Assert.Single(result);
        Assert.Equal(new[] { 1, 2, 3, 4 }, result[0]);
    }

    /// <summary>
    /// Tests Combine(5, 3) returns C(5,3) = 10 combinations.
    /// </summary>
    [Fact]
    public void Combine_FiveChooseThree_ReturnsTenCombinations()
    {
        var result = Combination_Solution.Combine(5, 3);

        Assert.Equal(10, result.Count);
        Assert.All(result, c => Assert.Equal(3, c.Count));
    }

    /// <summary>
    /// Tests every produced combination is strictly ascending.
    /// </summary>
    [Fact]
    public void Combine_AllResults_AreStrictlyAscending()
    {
        var result = Combination_Solution.Combine(5, 3);

        Assert.All(result, c =>
        {
            for (var i = 1; i < c.Count; i++)
                Assert.True(c[i - 1] < c[i], "Combination elements should be strictly ascending");
        });
    }
}
```

- [ ] **Step 2: Run the test class**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.Backtracking.CombinationTests" --nologo`
Expected: PASS (7 tests: 1 + 3 theory rows + 3 facts).

- [ ] **Step 3: Commit**

```bash
git add src/DSA.Tests/LeetCode/Backtracking/CombinationTests.cs
git commit -m "test: cover Combination_Solution.Combine"
```

---

# Section 3 — DynamicProgramming/FrameworkForDP tests

### Task 6: MinCostClimbingStairsTests

**Files:**
- Create: `src/DSA.Tests/LeetCode/DynamicProgramming/MinCostClimbingStairsTests.cs`

`MinCostClimbingStairsSolution` exposes three entry points: the canonical `static MinCostClimbingStairs(int[] cost)`, an instance `MinCostClimbingStairsDPTopDown(int n, int[] cost)` (uses internal memo), and a `static MinCostClimbingStairsDPBottomUp(int n, int[] cost)`. All three must agree on the same inputs.

- [ ] **Step 1: Create the test file**

Create `src/DSA.Tests/LeetCode/DynamicProgramming/MinCostClimbingStairsTests.cs`:

```csharp
using DSA.LeetCode.DynamicProgramming;

namespace DSA.Tests.LeetCode.DynamicProgramming;

public class MinCostClimbingStairsTests
{
    /// <summary>
    /// Tests the canonical static entry point on the LeetCode example.
    /// https://leetcode.com/problems/min-cost-climbing-stairs/description/
    /// </summary>
    [Theory]
    [InlineData(new[] { 10, 15, 20 }, 15)]
    [InlineData(new[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
    public void MinCostClimbingStairs_LeetCodeExamples_ReturnsExpectedCost(int[] cost, int expected)
    {
        var result = MinCostClimbingStairsSolution.MinCostClimbingStairs(cost);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests bottom-up returns the same result as the canonical entry point.
    /// </summary>
    [Theory]
    [InlineData(new[] { 10, 15, 20 }, 15)]
    [InlineData(new[] { 0, 0, 0 }, 0)]
    [InlineData(new[] { 5 }, 0)]
    public void MinCostClimbingStairsDPBottomUp_VariousInputs_MatchesExpected(int[] cost, int expected)
    {
        var result = MinCostClimbingStairsSolution.MinCostClimbingStairsDPBottomUp(cost.Length, cost);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests top-down (instance method using memoization) on the LeetCode example.
    /// </summary>
    [Fact]
    public void MinCostClimbingStairsDPTopDown_FirstExample_ReturnsFifteen()
    {
        var solver = new MinCostClimbingStairsSolution();
        int[] cost = [10, 15, 20];

        var result = solver.MinCostClimbingStairsDPTopDown(cost.Length, cost);

        Assert.Equal(15, result);
    }

    /// <summary>
    /// Tests top-down on the longer example.
    /// </summary>
    [Fact]
    public void MinCostClimbingStairsDPTopDown_SecondExample_ReturnsSix()
    {
        var solver = new MinCostClimbingStairsSolution();
        int[] cost = [1, 100, 1, 1, 1, 100, 1, 1, 100, 1];

        var result = solver.MinCostClimbingStairsDPTopDown(cost.Length, cost);

        Assert.Equal(6, result);
    }

    /// <summary>
    /// Tests bottom-up returns 0 for a 2-step staircase (start at index 0 or 1, end at length).
    /// </summary>
    [Fact]
    public void MinCostClimbingStairsDPBottomUp_TwoElement_ReturnsMinOfFirstTwo()
    {
        int[] cost = [10, 15];

        var result = MinCostClimbingStairsSolution.MinCostClimbingStairsDPBottomUp(cost.Length, cost);

        Assert.Equal(10, result);
    }
}
```

- [ ] **Step 2: Run the test class**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.DynamicProgramming.MinCostClimbingStairsTests" --nologo`
Expected: PASS (8 tests: 2 + 3 theory rows + 3 facts).

- [ ] **Step 3: Commit**

```bash
git add src/DSA.Tests/LeetCode/DynamicProgramming/MinCostClimbingStairsTests.cs
git commit -m "test: cover MinCostClimbingStairsSolution (static + top-down + bottom-up)"
```

---

# Section 4 — DynamicProgramming/OneDirectionProblems tests

### Task 7: HouseRobberTests

**Files:**
- Create: `src/DSA.Tests/LeetCode/DynamicProgramming/HouseRobberTests.cs`

`OneDirectionSolution.Rob` requires `nums.Length >= 2` (the bottom-up implementation indexes `nums[1]` before any branching). All test inputs honor this; do **not** add a `Rob([single])` test as it will throw `IndexOutOfRangeException` — that boundary is an existing source quirk, not something tests should normalize away.

- [ ] **Step 1: Create the test file**

Create `src/DSA.Tests/LeetCode/DynamicProgramming/HouseRobberTests.cs`:

```csharp
using DSA.LeetCode.DynamicProgramming;

namespace DSA.Tests.LeetCode.DynamicProgramming;

public class HouseRobberTests
{
    /// <summary>
    /// Tests the canonical static entry point on the LeetCode examples.
    /// https://leetcode.com/problems/house-robber/description/
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 3, 1 }, 4)]
    [InlineData(new[] { 2, 7, 9, 3, 1 }, 12)]
    [InlineData(new[] { 2, 1, 1, 2 }, 4)]
    public void Rob_LeetCodeExamples_ReturnsExpectedSum(int[] nums, int expected)
    {
        var result = OneDirectionSolution.Rob(nums);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests bottom-up on a 2-element input returns the larger of the two.
    /// </summary>
    [Fact]
    public void RobDPBottomUp_TwoElements_ReturnsMaxValue()
    {
        var result = OneDirectionSolution.RobDPBottomUp([5, 10]);

        Assert.Equal(10, result);
    }

    /// <summary>
    /// Tests top-down (instance + memo) matches bottom-up for a 4-element input.
    /// </summary>
    [Fact]
    public void RobDPTopDown_FourElements_ReturnsFour()
    {
        var solver = new OneDirectionSolution();
        int[] nums = [1, 2, 3, 1];

        var result = solver.RobDPTopDown(nums.Length - 1, nums);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests top-down with a longer input matches the LeetCode example.
    /// </summary>
    [Fact]
    public void RobDPTopDown_FiveElements_ReturnsTwelve()
    {
        var solver = new OneDirectionSolution();
        int[] nums = [2, 7, 9, 3, 1];

        var result = solver.RobDPTopDown(nums.Length - 1, nums);

        Assert.Equal(12, result);
    }

    /// <summary>
    /// Tests all three entry points agree on the same input.
    /// </summary>
    [Fact]
    public void AllEntryPoints_OnSameInput_AgreeOnAnswer()
    {
        int[] nums = [2, 7, 9, 3, 1];
        var solver = new OneDirectionSolution();

        var canonical = OneDirectionSolution.Rob(nums);
        var bottomUp = OneDirectionSolution.RobDPBottomUp(nums);
        var topDown = solver.RobDPTopDown(nums.Length - 1, nums);

        Assert.Equal(canonical, bottomUp);
        Assert.Equal(canonical, topDown);
    }
}
```

- [ ] **Step 2: Run the test class**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.DynamicProgramming.HouseRobberTests" --nologo`
Expected: PASS (7 tests: 3 theory rows + 4 facts).

- [ ] **Step 3: Commit**

```bash
git add src/DSA.Tests/LeetCode/DynamicProgramming/HouseRobberTests.cs
git commit -m "test: cover OneDirectionSolution.Rob entry points"
```

### Task 8: LongestIncreasingSubsequenceTests

**Files:**
- Create: `src/DSA.Tests/LeetCode/DynamicProgramming/LongestIncreasingSubsequenceTests.cs`

- [ ] **Step 1: Create the test file**

Create `src/DSA.Tests/LeetCode/DynamicProgramming/LongestIncreasingSubsequenceTests.cs`:

```csharp
using DSA.LeetCode.DynamicProgramming;

namespace DSA.Tests.LeetCode.DynamicProgramming;

public class LongestIncreasingSubsequenceTests
{
    /// <summary>
    /// Tests LengthOfLIS on the LeetCode canonical example.
    /// https://leetcode.com/problems/longest-increasing-subsequence/description/
    /// </summary>
    [Theory]
    [InlineData(new[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
    [InlineData(new[] { 0, 1, 0, 3, 2, 3 }, 4)]
    [InlineData(new[] { 7, 7, 7, 7, 7, 7, 7 }, 1)]
    public void LengthOfLIS_LeetCodeExamples_ReturnsExpectedLength(int[] nums, int expected)
    {
        var solver = new LongestIncreasingSubsequenceSolution();

        var result = solver.LengthOfLIS(nums);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests LengthOfLIS on a single element — the LIS is length 1.
    /// </summary>
    [Fact]
    public void LengthOfLIS_SingleElement_ReturnsOne()
    {
        var solver = new LongestIncreasingSubsequenceSolution();

        var result = solver.LengthOfLIS([42]);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests the static bottom-up entry point directly.
    /// </summary>
    [Fact]
    public void LengthOfLISBottomUp_StrictlyIncreasing_ReturnsArrayLength()
    {
        var result = LongestIncreasingSubsequenceSolution.LengthOfLISBottomUp([1, 2, 3, 4, 5]);

        Assert.Equal(5, result);
    }

    /// <summary>
    /// Tests the static bottom-up entry point on a strictly decreasing array.
    /// </summary>
    [Fact]
    public void LengthOfLISBottomUp_StrictlyDecreasing_ReturnsOne()
    {
        var result = LongestIncreasingSubsequenceSolution.LengthOfLISBottomUp([5, 4, 3, 2, 1]);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests the top-down (instance + memo) helper on the canonical example.
    /// LengthOfLISTopDown(n, nums) returns the LIS length that ENDS at index n.
    /// </summary>
    [Fact]
    public void LengthOfLISTopDown_EndIndexThree_ReturnsTwo()
    {
        var solver = new LongestIncreasingSubsequenceSolution();
        int[] nums = [10, 9, 2, 5, 3, 7, 101, 18];

        var result = solver.LengthOfLISTopDown(3, nums);

        Assert.Equal(2, result);
    }
}
```

- [ ] **Step 2: Run the test class**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.DynamicProgramming.LongestIncreasingSubsequenceTests" --nologo`
Expected: PASS (7 tests: 3 theory rows + 4 facts).

- [ ] **Step 3: Commit**

```bash
git add src/DSA.Tests/LeetCode/DynamicProgramming/LongestIncreasingSubsequenceTests.cs
git commit -m "test: cover LongestIncreasingSubsequenceSolution entry points"
```

### Task 9: MostPointsTests

**Files:**
- Create: `src/DSA.Tests/LeetCode/DynamicProgramming/MostPointsTests.cs`

Only the public static `MostPoints` is reachable from tests — the top-down and bottom-up helpers are `private`, so we test through the public surface.

- [ ] **Step 1: Create the test file**

Create `src/DSA.Tests/LeetCode/DynamicProgramming/MostPointsTests.cs`:

```csharp
using DSA.LeetCode.DynamicProgramming;

namespace DSA.Tests.LeetCode.DynamicProgramming;

public class MostPointsTests
{
    /// <summary>
    /// Tests MostPoints on the LeetCode canonical example.
    /// https://leetcode.com/problems/solving-questions-with-brainpower/
    /// </summary>
    [Fact]
    public void MostPoints_CanonicalExample_ReturnsFive()
    {
        int[][] questions = [[3, 2], [4, 3], [4, 4], [2, 5]];

        var result = SolvingQuestionsWithBrainpowerSolution.MostPoints(questions);

        Assert.Equal(5, result);
    }

    /// <summary>
    /// Tests MostPoints on the second LeetCode example.
    /// </summary>
    [Fact]
    public void MostPoints_SecondExample_ReturnsSeven()
    {
        int[][] questions = [[1, 1], [2, 2], [3, 3], [4, 4], [5, 5]];

        var result = SolvingQuestionsWithBrainpowerSolution.MostPoints(questions);

        Assert.Equal(7, result);
    }

    /// <summary>
    /// Tests MostPoints on a single question with zero brainpower cost.
    /// </summary>
    [Fact]
    public void MostPoints_SingleQuestion_ReturnsItsPoints()
    {
        int[][] questions = [[10, 0]];

        var result = SolvingQuestionsWithBrainpowerSolution.MostPoints(questions);

        Assert.Equal(10, result);
    }
}
```

- [ ] **Step 2: Run the test class**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.DynamicProgramming.MostPointsTests" --nologo`
Expected: PASS (3 tests).

- [ ] **Step 3: Commit**

```bash
git add src/DSA.Tests/LeetCode/DynamicProgramming/MostPointsTests.cs
git commit -m "test: cover SolvingQuestionsWithBrainpowerSolution.MostPoints"
```

### Task 10: ClimbStairsTests

**Files:**
- Create: `src/DSA.Tests/LeetCode/DynamicProgramming/ClimbStairsTests.cs`

`ClimbStairsSolution` exposes static `ClimbStairs(int n)` and instance `ClimbStairsTopDown(int n)`. The internal `ClaimStairsBottomUp` (note: typo in source — leave it) is private and only reachable via `ClimbStairs`.

- [ ] **Step 1: Create the test file**

Create `src/DSA.Tests/LeetCode/DynamicProgramming/ClimbStairsTests.cs`:

```csharp
using DSA.LeetCode.DynamicProgramming;

namespace DSA.Tests.LeetCode.DynamicProgramming;

public class ClimbStairsTests
{
    /// <summary>
    /// Tests the canonical static entry point follows the Fibonacci sequence.
    /// https://leetcode.com/problems/climbing-stairs/
    /// </summary>
    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 5)]
    [InlineData(5, 8)]
    [InlineData(6, 13)]
    public void ClimbStairs_VariousN_ReturnsFibonacciCount(int n, int expected)
    {
        var result = ClimbStairsSolution.ClimbStairs(n);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests top-down (instance + memo) returns 1 for n=1 (only one way).
    /// </summary>
    [Fact]
    public void ClimbStairsTopDown_NEqualsOne_ReturnsOne()
    {
        var solver = new ClimbStairsSolution();

        var result = solver.ClimbStairsTopDown(1);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests top-down returns 2 for n=2 (two singletons or one double).
    /// </summary>
    [Fact]
    public void ClimbStairsTopDown_NEqualsTwo_ReturnsTwo()
    {
        var solver = new ClimbStairsSolution();

        var result = solver.ClimbStairsTopDown(2);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests top-down agrees with the static entry point across small n values.
    /// </summary>
    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(10)]
    public void ClimbStairsTopDown_AgreesWithStatic(int n)
    {
        var solver = new ClimbStairsSolution();

        var topDown = solver.ClimbStairsTopDown(n);
        var canonical = ClimbStairsSolution.ClimbStairs(n);

        Assert.Equal(canonical, topDown);
    }
}
```

- [ ] **Step 2: Run the test class**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.DynamicProgramming.ClimbStairsTests" --nologo`
Expected: PASS (10 tests: 5 + 2 + 3 theory rows).

- [ ] **Step 3: Commit**

```bash
git add src/DSA.Tests/LeetCode/DynamicProgramming/ClimbStairsTests.cs
git commit -m "test: cover ClimbStairsSolution (static + top-down)"
```

### Task 11: CoinChangeTests

**Files:**
- Create: `src/DSA.Tests/LeetCode/DynamicProgramming/CoinChangeTests.cs`

Only the public static `CoinChange` is reachable from tests — top-down and bottom-up helpers are `private`.

- [ ] **Step 1: Create the test file**

Create `src/DSA.Tests/LeetCode/DynamicProgramming/CoinChangeTests.cs`:

```csharp
using DSA.LeetCode.DynamicProgramming;

namespace DSA.Tests.LeetCode.DynamicProgramming;

public class CoinChangeTests
{
    /// <summary>
    /// Tests CoinChange on the LeetCode canonical example.
    /// https://leetcode.com/problems/coin-change/
    /// </summary>
    [Fact]
    public void CoinChange_StandardCoinsForEleven_ReturnsThree()
    {
        var result = CoinChangeSolution.CoinChange([1, 2, 5], 11);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests CoinChange returns -1 when the amount cannot be formed.
    /// </summary>
    [Fact]
    public void CoinChange_AmountImpossible_ReturnsMinusOne()
    {
        var result = CoinChangeSolution.CoinChange([2], 3);

        Assert.Equal(-1, result);
    }

    /// <summary>
    /// Tests CoinChange returns 0 for amount=0 (no coins needed).
    /// </summary>
    [Fact]
    public void CoinChange_ZeroAmount_ReturnsZero()
    {
        var result = CoinChangeSolution.CoinChange([1, 2, 5], 0);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests CoinChange picks the largest denomination when possible.
    /// </summary>
    [Fact]
    public void CoinChange_AmountEqualsLargestCoin_ReturnsOne()
    {
        var result = CoinChangeSolution.CoinChange([1, 2, 5], 5);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests CoinChange with a single unit coin returns amount.
    /// </summary>
    [Theory]
    [InlineData(1, 1)]
    [InlineData(5, 5)]
    [InlineData(17, 17)]
    public void CoinChange_OnlyUnitCoin_ReturnsAmount(int amount, int expected)
    {
        var result = CoinChangeSolution.CoinChange([1], amount);

        Assert.Equal(expected, result);
    }
}
```

- [ ] **Step 2: Run the test class**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.DynamicProgramming.CoinChangeTests" --nologo`
Expected: PASS (7 tests: 4 + 3 theory rows).

- [ ] **Step 3: Commit**

```bash
git add src/DSA.Tests/LeetCode/DynamicProgramming/CoinChangeTests.cs
git commit -m "test: cover CoinChangeSolution.CoinChange"
```

---

# Section 5 — Final verification

### Task 12: Full suite + coverage + Release build

**Files:** None modified (verification only).

- [ ] **Step 1: Run the full test suite**

Run: `dotnet test --nologo`
Expected: ALL tests pass. Total test count grows by ≈58 from the baseline (`711` → ≈`769`).

- [ ] **Step 2: Run coverage collection**

Run: `dotnet test --collect:"XPlat Code Coverage" --nologo`
Expected: Coverage report generated. Line coverage should exceed the baseline (`71.82%` after the prior data-structure additions). Locate the cobertura XML under `src/DSA.Tests/TestResults/<guid>/coverage.cobertura.xml` and confirm `line-rate` ≥ `0.71`.

- [ ] **Step 3: Confirm Release build**

Run: `dotnet build --configuration Release --nologo`
Expected: 0 errors. Pre-existing warnings (5 in `GraphBfsTests.cs` and `TopKTests.cs`) are unchanged — do not silence them in this plan.

- [ ] **Step 4: No final commit needed**

Verification only — every prior task already committed its own change.

---

## Self-review notes

- **Spec coverage:** All four gap categories are covered: source cleanup (Task 1), source visibility fix (Task 2), Backtracking tests (Tasks 3-5), DynamicProgramming tests (Tasks 6-11). `CommonPatterns.cs` is intentionally excluded — it contains only doc comments and no executable code.
- **Placeholder scan:** No TBD/TODO/"add appropriate"/"similar to" markers. Every test file is fully written out, every command is complete, every expected outcome is specific.
- **Type consistency:**
  - All `Permutation_Solution`, `Subsets_Solution`, `Combination_Solution`, `MinCostClimbingStairsSolution`, `OneDirectionSolution`, `LongestIncreasingSubsequenceSolution`, `SolvingQuestionsWithBrainpowerSolution`, `ClimbStairsSolution`, `CoinChangeSolution` class names match `src/DSA/LeetCode/...` exactly.
  - Public-method signatures (`int`, `int[]`, `int[][]`, `IList<IList<int>>`) match the source file.
  - Test namespace `DSA.Tests.LeetCode.{Pattern}` and source namespace `DSA.LeetCode.{Pattern}` mirror existing convention.
- **Edge cases acknowledged:**
  - `OneDirectionSolution.RobDPBottomUp` throws on single-element arrays — tests use length ≥ 2.
  - `Subsets_Solution.Subsets([])` returns `[[]]` — covered.
  - `ClimbStairsSolution.ClaimStairsBottomUp` (private, typo'd) is left alone — characterized through public `ClimbStairs`.

---

## Execution sequence summary

| # | Task | Files (key) | Commit message |
|---|------|------|----------------|
| 1 | Delete duplicate Hashing | `Hashing/CheckForExistence.cs` | `refactor: remove unused duplicate Hashing class` |
| 2 | Make Subsets_Solution public | `Backtracking/Generation.cs` | `refactor: make Subsets_Solution public for testability` |
| 3 | PermutationTests | `Backtracking/PermutationTests.cs` | `test: cover Permutation_Solution.Permute` |
| 4 | SubsetsTests | `Backtracking/SubsetsTests.cs` | `test: cover Subsets_Solution.Subsets` |
| 5 | CombinationTests | `Backtracking/CombinationTests.cs` | `test: cover Combination_Solution.Combine` |
| 6 | MinCostClimbingStairsTests | `DynamicProgramming/MinCostClimbingStairsTests.cs` | `test: cover MinCostClimbingStairsSolution (static + top-down + bottom-up)` |
| 7 | HouseRobberTests | `DynamicProgramming/HouseRobberTests.cs` | `test: cover OneDirectionSolution.Rob entry points` |
| 8 | LongestIncreasingSubsequenceTests | `DynamicProgramming/LongestIncreasingSubsequenceTests.cs` | `test: cover LongestIncreasingSubsequenceSolution entry points` |
| 9 | MostPointsTests | `DynamicProgramming/MostPointsTests.cs` | `test: cover SolvingQuestionsWithBrainpowerSolution.MostPoints` |
| 10 | ClimbStairsTests | `DynamicProgramming/ClimbStairsTests.cs` | `test: cover ClimbStairsSolution (static + top-down)` |
| 11 | CoinChangeTests | `DynamicProgramming/CoinChangeTests.cs` | `test: cover CoinChangeSolution.CoinChange` |
| 12 | Final verify | (verification only) | (none) |
