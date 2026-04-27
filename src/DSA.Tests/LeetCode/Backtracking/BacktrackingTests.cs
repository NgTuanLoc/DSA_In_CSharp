using DSA.LeetCode.Backtracking;

namespace DSA.Tests.LeetCode.Backtracking;

public class BacktrackingTests
{
    #region Permute Tests

    [Fact]
    public void Permute_WithThreeElements_ReturnsAllPermutations()
    {
        var result = Permutation_Solution.Permute([1, 2, 3]);

        Assert.Equal(6, result.Count);
    }

    [Fact]
    public void Permute_WithTwoElements_ReturnsTwoPermutations()
    {
        var result = Permutation_Solution.Permute([0, 1]);

        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.SequenceEqual([0, 1]));
        Assert.Contains(result, p => p.SequenceEqual([1, 0]));
    }

    // Missing: single element → should return [[element]]
    // Missing: verify all permutations are distinct (no duplicates)

    #endregion

    #region Subsets Tests

    [Fact]
    public void Subsets_WithThreeElements_ReturnsPowerSet()
    {
        var result = Subsets_Solution.Subsets([1, 2, 3]);

        Assert.Equal(8, result.Count);
    }

    [Fact]
    public void Subsets_WithTwoElements_ReturnsFourSubsets()
    {
        var result = Subsets_Solution.Subsets([1, 2]);

        Assert.Equal(4, result.Count);
        Assert.Contains(result, s => s.Count == 0);
        Assert.Contains(result, s => s.SequenceEqual([1, 2]));
    }

    // Missing: empty array → should return [[]] (one subset: the empty set)
    // Missing: single element → should return [[], [element]]

    #endregion

    #region Combine Tests

    [Fact]
    public void Combine_WithNFourKTwo_ReturnsSixCombinations()
    {
        var result = Combination_Solution.Combine(4, 2);

        Assert.Equal(6, result.Count);
    }

    [Fact]
    public void Combine_WithKEqualsN_ReturnsOneCombination()
    {
        var result = Combination_Solution.Combine(3, 3);

        Assert.Equal(1, result.Count);
        Assert.Equal([1, 2, 3], result[0]);
    }

    // Missing: k = 1 → should return n combinations, each with one element
    // Missing: verify all combinations have exactly k elements
    // Missing: verify no duplicate combinations exist

    #endregion
}
