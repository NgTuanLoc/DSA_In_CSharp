using DSA.LeetCode.StackAndQueue;

namespace DSA.Tests.LeetCode.StackAndQueue;

public class MonotonicTests
{
    #region DailyTemperatures Tests

    /// <summary>
    /// Tests DailyTemperatures with basic increasing temperatures.
    /// https://leetcode.com/problems/daily-temperatures/description/
    /// Pattern: Monotonic stack - track indices waiting for warmer days
    /// </summary>
    [Fact]
    public void DailyTemperatures_WithIncreasingTemps_ReturnsCorrectDays()
    {
        var result = Monotonic.DailyTemperatures([30, 40, 50, 60]);

        Assert.Equal([1, 1, 1, 0], result);
    }

    /// <summary>
    /// Tests DailyTemperatures with decreasing temperatures.
    /// </summary>
    [Fact]
    public void DailyTemperatures_WithDecreasingTemps_ReturnsCorrectDays()
    {
        var result = Monotonic.DailyTemperatures([60, 50, 40, 30]);

        Assert.Equal([0, 0, 0, 0], result);
    }

    /// <summary>
    /// Tests DailyTemperatures with mixed temperatures pattern.
    /// </summary>
    [Fact]
    public void DailyTemperatures_WithMixedPattern_ReturnsCorrectDays()
    {
        var result = Monotonic.DailyTemperatures([73, 74, 75, 71, 69, 72, 76, 73]);

        Assert.Equal([1, 1, 4, 2, 1, 1, 0, 0], result);
    }

    /// <summary>
    /// Tests DailyTemperatures with single temperature.
    /// </summary>
    [Fact]
    public void DailyTemperatures_WithSingleTemp_ReturnsZero()
    {
        var result = Monotonic.DailyTemperatures([30]);

        Assert.Equal([0], result);
    }

    /// <summary>
    /// Tests DailyTemperatures with all same temperatures.
    /// </summary>
    [Fact]
    public void DailyTemperatures_WithSameTemps_ReturnsAllZeros()
    {
        var result = Monotonic.DailyTemperatures([30, 30, 30, 30]);

        Assert.Equal([0, 0, 0, 0], result);
    }

    /// <summary>
    /// Tests DailyTemperatures with last day warmest.
    /// </summary>
    [Fact]
    public void DailyTemperatures_WithLastDayWarmest_ReturnsCorrectDays()
    {
        var result = Monotonic.DailyTemperatures([30, 60, 90]);

        Assert.Equal([1, 1, 0], result);
    }

    /// <summary>
    /// Tests DailyTemperatures with first day warmest.
    /// </summary>
    [Fact]
    public void DailyTemperatures_WithFirstDayWarmest_ReturnsAllZeros()
    {
        var result = Monotonic.DailyTemperatures([90, 60, 30]);

        Assert.Equal([0, 0, 0], result);
    }

    /// <summary>
    /// Tests DailyTemperatures with two temperatures.
    /// </summary>
    [Fact]
    public void DailyTemperatures_WithTwoTemps_ReturnsCorrectResult()
    {
        var result = Monotonic.DailyTemperatures([30, 40]);

        Assert.Equal([1, 0], result);
    }

    /// <summary>
    /// Tests DailyTemperatures with valleys and peaks.
    /// </summary>
    [Fact]
    public void DailyTemperatures_WithValleysAndPeaks_ReturnsCorrectDays()
    {
        var result = Monotonic.DailyTemperatures([89, 62, 70, 58, 47, 99]);

        Assert.Equal([5, 1, 3, 2, 1, 0], result);
    }

    #endregion

    #region MaxSlidingWindow Tests

    /// <summary>
    /// Tests MaxSlidingWindow with basic example.
    /// https://leetcode.com/problems/sliding-window-maximum/description/
    /// Pattern: Monotonic deque - maintain decreasing order for window maximum
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithBasicExample_ReturnsCorrectMaximums()
    {
        var result = Monotonic.MaxSlidingWindow([1, 3, -1, -3, 5, 3, 6, 7], 3);

        Assert.Equal([3, 3, 5, 5, 6, 7], result);
    }

    /// <summary>
    /// Tests MaxSlidingWindow with window size of 1.
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithWindowSizeOne_ReturnsOriginalArray()
    {
        var result = Monotonic.MaxSlidingWindow([1, 3, -1, -3, 5], 1);

        Assert.Equal([1, 3, -1, -3, 5], result);
    }

    /// <summary>
    /// Tests MaxSlidingWindow with window size equal to array length.
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithFullWindow_ReturnsSingleMax()
    {
        var result = Monotonic.MaxSlidingWindow([1, 3, -1, -3, 5], 5);

        Assert.Equal([5], result);
    }

    /// <summary>
    /// Tests MaxSlidingWindow with increasing sequence.
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithIncreasingSequence_ReturnsCorrectMaximums()
    {
        var result = Monotonic.MaxSlidingWindow([1, 2, 3, 4, 5], 3);

        Assert.Equal([3, 4, 5], result);
    }

    /// <summary>
    /// Tests MaxSlidingWindow with decreasing sequence.
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithDecreasingSequence_ReturnsCorrectMaximums()
    {
        var result = Monotonic.MaxSlidingWindow([5, 4, 3, 2, 1], 3);

        Assert.Equal([5, 4, 3], result);
    }

    /// <summary>
    /// Tests MaxSlidingWindow with all same values.
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithSameValues_ReturnsAllSame()
    {
        var result = Monotonic.MaxSlidingWindow([7, 7, 7, 7], 2);

        Assert.Equal([7, 7, 7], result);
    }

    /// <summary>
    /// Tests MaxSlidingWindow with negative numbers.
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithNegativeNumbers_ReturnsCorrectMaximums()
    {
        var result = Monotonic.MaxSlidingWindow([-7, -8, 7, 5, 7, 1, 6, 0], 4);

        Assert.Equal([7, 7, 7, 7, 7], result);
    }

    /// <summary>
    /// Tests MaxSlidingWindow with single element.
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithSingleElement_ReturnsThatElement()
    {
        var result = Monotonic.MaxSlidingWindow([1], 1);

        Assert.Equal([1], result);
    }

    /// <summary>
    /// Tests MaxSlidingWindow with two elements.
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithTwoElements_ReturnsCorrectResult()
    {
        var result = Monotonic.MaxSlidingWindow([1, -1], 1);

        Assert.Equal([1, -1], result);
    }

    /// <summary>
    /// Tests MaxSlidingWindow with maximum at start.
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithMaxAtStart_ReturnsCorrectMaximums()
    {
        var result = Monotonic.MaxSlidingWindow([9, 11], 2);

        Assert.Equal([11], result);
    }

    /// <summary>
    /// Tests MaxSlidingWindow with large window.
    /// </summary>
    [Fact]
    public void MaxSlidingWindow_WithLargeWindow_ReturnsCorrectMaximums()
    {
        var result = Monotonic.MaxSlidingWindow([1, 3, 1, 2, 0, 5], 3);

        Assert.Equal([3, 3, 2, 5], result);
    }

    #endregion

    #region LongestSubarray Tests

    /// <summary>
    /// Tests LongestSubarray placeholder method.
    /// https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/description/
    /// Pattern: Monotonic deques - maintain min and max for absolute difference check
    /// Note: This test is for the stub implementation and will need updating when implemented.
    /// </summary>
    [Fact]
    public void LongestSubarray_Placeholder_ReturnsOne()
    {
        var result = Monotonic.LongestSubarray([8, 2, 4, 7], 4);

        Assert.Equal(1, result);
    }

    #endregion
}
