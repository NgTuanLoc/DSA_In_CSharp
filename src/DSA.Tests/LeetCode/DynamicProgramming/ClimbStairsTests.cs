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
