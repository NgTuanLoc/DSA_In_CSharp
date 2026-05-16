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
