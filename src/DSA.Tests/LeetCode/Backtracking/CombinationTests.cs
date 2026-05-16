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
