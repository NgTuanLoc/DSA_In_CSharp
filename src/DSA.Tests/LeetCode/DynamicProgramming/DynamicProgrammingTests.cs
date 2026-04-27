using DSA.LeetCode.DynamicProgramming;

namespace DSA.Tests.LeetCode.DynamicProgramming;

public class DynamicProgrammingTests
{
    #region Rob Tests

    [Fact]
    public void Rob_WithBasicInput_ReturnsMaxRob()
    {
        var result = OneDirectionSolution.Rob([1, 2, 3, 1]);

        Assert.Equal(4, result);
    }

    [Fact]
    public void Rob_WithSecondExample_ReturnsMaxRob()
    {
        var result = OneDirectionSolution.Rob([2, 7, 9, 3, 1]);

        Assert.Equal(12, result);
    }

    // Missing: single house → Rob([5]) crashes because RobDPBottomUp accesses dp[1] (nums[1]) which doesn't exist
    // Missing: two houses → Rob([2, 1]) should return 2

    #endregion

    #region ClimbStairs Tests

    [Fact]
    public void ClimbStairs_WithThreeSteps_ReturnsFibonacciCount()
    {
        var result = ClimbStairsSolution.ClimbStairs(3);

        Assert.Equal(3, result);
    }

    [Fact]
    public void ClimbStairs_WithFiveSteps_ReturnsCorrectCount()
    {
        var result = ClimbStairsSolution.ClimbStairs(5);

        Assert.Equal(8, result);
    }

    // Missing: n = 1 → crashes because ClaimStairsBottomUp calls dp[n-1] = dp[0] but only seeds dp[1] and dp[2]
    // Missing: n = 2 → should return 2

    #endregion

    #region LengthOfLIS Tests

    [Fact]
    public void LengthOfLIS_WithBasicInput_ReturnsLongestLength()
    {
        var solution = new LongestIncreasingSubsequenceSolution();
        var result = solution.LengthOfLIS([10, 9, 2, 5, 3, 7, 101, 18]);

        Assert.Equal(4, result);
    }

    [Fact]
    public void LengthOfLIS_WithAlreadySorted_ReturnsFullLength()
    {
        var solution = new LongestIncreasingSubsequenceSolution();
        var result = solution.LengthOfLIS([1, 2, 3, 4, 5]);

        Assert.Equal(5, result);
    }

    // Missing: all same elements → LIS should be 1
    // Missing: single element → should return 1
    // Missing: descending order → should return 1

    #endregion

    #region CoinChange Tests

    [Fact]
    public void CoinChange_WithBasicInput_ReturnsMinCoins()
    {
        var result = CoinChangeSolution.CoinChange([1, 5, 10], 11);

        Assert.Equal(2, result);
    }

    [Fact]
    public void CoinChange_WithImpossibleAmount_ReturnsNegativeOne()
    {
        var result = CoinChangeSolution.CoinChange([2], 3);

        Assert.Equal(-1, result);
    }

    // Missing: amount = 0 → should return 0
    // Missing: coin denomination equals amount → should return 1

    #endregion
}
