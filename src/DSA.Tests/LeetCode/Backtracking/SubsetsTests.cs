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
