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
