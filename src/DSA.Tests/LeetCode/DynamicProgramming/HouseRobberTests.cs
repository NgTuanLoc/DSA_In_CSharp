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
