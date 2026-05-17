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
