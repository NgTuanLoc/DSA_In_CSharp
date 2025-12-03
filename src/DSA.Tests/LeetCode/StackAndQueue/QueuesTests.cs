using DSA.LeetCode.StackAndQueue;

namespace DSA.Tests.LeetCode.StackAndQueue;

/// <summary>
/// Unit tests for Queue pattern implementations.
/// Queues follow FIFO (First In First Out) principle and are ideal for problems involving:
/// - Sliding time windows
/// - Level-order traversal
/// - Task scheduling and processing in order
/// - Moving averages and streaming data
/// Time Complexity: Usually O(1) per operation, Space Complexity: O(n) for queue storage.
/// </summary>
public class QueuesTests
{
    #region RecentCounter Tests
    /// <summary>
    /// Test: Verify recent call counting within 3000 time units.
    /// Pattern: Use queue to maintain sliding time window, remove outdated timestamps.
    /// LeetCode: https://leetcode.com/problems/number-of-recent-calls/
    /// Algorithm:
    /// 1. Remove all timestamps older than t - 3000 from front
    /// 2. Add current timestamp to back
    /// 3. Queue size is the count of recent calls
    /// Note: Timestamps arrive in increasing order
    /// </summary>
    [Fact]
    public void RecentCounter_SingleCall_ReturnsOne()
    {
        // Arrange
        var counter = new Queues.RecentCounter();

        // Act
        var result = counter.Ping(1);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void RecentCounter_MultipleCalls_WithinWindow_ReturnsCorrectCount()
    {
        // Arrange
        var counter = new Queues.RecentCounter();

        // Act & Assert
        Assert.Equal(1, counter.Ping(1));      // [1]
        Assert.Equal(2, counter.Ping(100));    // [1, 100]
        Assert.Equal(3, counter.Ping(3001));   // [1, 100, 3001]
        Assert.Equal(3, counter.Ping(3002));   // [1, 100, 3001, 3002]
    }

    [Fact]
    public void RecentCounter_CallsOutsideWindow_RemovesOldCalls()
    {
        // Arrange
        var counter = new Queues.RecentCounter();

        // Act & Assert
        Assert.Equal(1, counter.Ping(1));      // [1]
        Assert.Equal(2, counter.Ping(100));    // [1, 100]
        Assert.Equal(3, counter.Ping(3001));   // [1, 100, 3001]
        Assert.Equal(3, counter.Ping(3002));   // [1, 100, 3001, 3002]
        Assert.Equal(3, counter.Ping(4000));   // [100, 3001, 3002, 4000] (1 removed as 4000 - 3000 = 1000)
    }

    [Fact]
    public void RecentCounter_LargeGapBetweenCalls_RemovesAllOldCalls()
    {
        // Arrange
        var counter = new Queues.RecentCounter();

        // Act & Assert
        Assert.Equal(1, counter.Ping(1));
        Assert.Equal(2, counter.Ping(100));
        Assert.Equal(3, counter.Ping(3001));
        Assert.Equal(1, counter.Ping(10000));  // All previous calls removed
    }

    [Fact]
    public void RecentCounter_ConsecutiveCalls_AtWindowBoundary()
    {
        // Arrange
        var counter = new Queues.RecentCounter();

        // Act & Assert
        Assert.Equal(1, counter.Ping(1));
        Assert.Equal(2, counter.Ping(3000));   // Exactly 3000 apart
        Assert.Equal(3, counter.Ping(3001));   // Still includes first call
        Assert.Equal(3, counter.Ping(3002));   // First call still in window
    }

    [Fact]
    public void RecentCounter_RapidCalls_MaintainsCorrectWindow()
    {
        // Arrange
        var counter = new Queues.RecentCounter();

        // Act & Assert
        Assert.Equal(1, counter.Ping(1));
        Assert.Equal(2, counter.Ping(2));
        Assert.Equal(3, counter.Ping(3));
        Assert.Equal(4, counter.Ping(4));
        Assert.Equal(5, counter.Ping(5));
        Assert.Equal(1, counter.Ping(5000));   // All previous calls outside window
    }
    #endregion

    #region MovingAverage Tests
    /// <summary>
    /// Test: Verify moving average calculation over sliding window.
    /// Pattern: Use queue to maintain fixed-size window, track running sum.
    /// LeetCode: https://leetcode.com/problems/moving-average-from-data-stream/
    /// Algorithm:
    /// 1. If queue is full (size == window size), remove oldest element and subtract from sum
    /// 2. Add new element to queue and add to sum
    /// 3. Return average (sum / current queue size)
    /// </summary>
    [Fact]
    public void MovingAverage_SingleElement_ReturnsValue()
    {
        // Arrange
        var ma = new Queues.MovingAverage(3);

        // Act
        var result = ma.Next(1);

        // Assert
        Assert.Equal(1.0, result);
    }

    [Fact]
    public void MovingAverage_WithinWindowSize_ReturnsCorrectAverage()
    {
        // Arrange
        var ma = new Queues.MovingAverage(3);

        // Act & Assert
        Assert.Equal(1.0, ma.Next(1));           // [1] -> 1/1
        Assert.Equal(5.5, ma.Next(10));          // [1, 10] -> 11/2
        Assert.Equal(4.666666666666667, ma.Next(3), 10);  // [1, 10, 3] -> 14/3
    }

    [Fact]
    public void MovingAverage_ExceedsWindowSize_MaintainsSlidingWindow()
    {
        // Arrange
        var ma = new Queues.MovingAverage(3);

        // Act & Assert
        Assert.Equal(1.0, ma.Next(1));           // [1] -> 1/1
        Assert.Equal(5.5, ma.Next(10));          // [1, 10] -> 11/2
        Assert.Equal(4.666666666666667, ma.Next(3), 10);  // [1, 10, 3] -> 14/3
        Assert.Equal(6.0, ma.Next(5));           // [10, 3, 5] -> 18/3 (1 removed)
    }

    [Fact]
    public void MovingAverage_WindowSizeOne_ReturnsCurrentValue()
    {
        // Arrange
        var ma = new Queues.MovingAverage(1);

        // Act & Assert
        Assert.Equal(5.0, ma.Next(5));
        Assert.Equal(10.0, ma.Next(10));
        Assert.Equal(15.0, ma.Next(15));
    }

    [Fact]
    public void MovingAverage_WithNegativeNumbers_HandlesCorrectly()
    {
        // Arrange
        var ma = new Queues.MovingAverage(3);

        // Act & Assert
        Assert.Equal(10.0, ma.Next(10));         // [10] -> 10/1
        Assert.Equal(0.0, ma.Next(-10));         // [10, -10] -> 0/2
        Assert.Equal(5.0, ma.Next(15));          // [10, -10, 15] -> 15/3
        Assert.Equal(-3.333333333333333, ma.Next(-15), 10);  // [-10, 15, -15] -> -10/3
    }

    [Fact]
    public void MovingAverage_WithZeros_HandlesCorrectly()
    {
        // Arrange
        var ma = new Queues.MovingAverage(3);

        // Act & Assert
        Assert.Equal(0.0, ma.Next(0));           // [0] -> 0/1
        Assert.Equal(0.0, ma.Next(0));           // [0, 0] -> 0/2
        Assert.Equal(0.0, ma.Next(0));           // [0, 0, 0] -> 0/3
        Assert.Equal(5.0, ma.Next(15));          // [0, 0, 15] -> 15/3
    }

    [Fact]
    public void MovingAverage_LargeWindowSize_AccumulatesUntilFull()
    {
        // Arrange
        var ma = new Queues.MovingAverage(5);

        // Act & Assert
        Assert.Equal(2.0, ma.Next(2));           // [2] -> 2/1
        Assert.Equal(3.0, ma.Next(4));           // [2, 4] -> 6/2
        Assert.Equal(4.0, ma.Next(6));           // [2, 4, 6] -> 12/3
        Assert.Equal(5.0, ma.Next(8));           // [2, 4, 6, 8] -> 20/4
        Assert.Equal(6.0, ma.Next(10));          // [2, 4, 6, 8, 10] -> 30/5
        Assert.Equal(8.0, ma.Next(12));          // [4, 6, 8, 10, 12] -> 40/5 (2 removed)
    }

    [Fact]
    public void MovingAverage_DecimalPrecision_ReturnsCorrectAverage()
    {
        // Arrange
        var ma = new Queues.MovingAverage(3);

        // Act & Assert
        Assert.Equal(1.0, ma.Next(1));
        Assert.Equal(1.5, ma.Next(2));
        Assert.Equal(2.0, ma.Next(3));
        Assert.Equal(3.0, ma.Next(4));           // [2, 3, 4] -> 9/3
    }

    [Fact]
    public void MovingAverage_RepeatedValues_HandlesCorrectly()
    {
        // Arrange
        var ma = new Queues.MovingAverage(4);

        // Act & Assert
        Assert.Equal(5.0, ma.Next(5));           // [5] -> 5/1
        Assert.Equal(5.0, ma.Next(5));           // [5, 5] -> 10/2
        Assert.Equal(5.0, ma.Next(5));           // [5, 5, 5] -> 15/3
        Assert.Equal(5.0, ma.Next(5));           // [5, 5, 5, 5] -> 20/4
        Assert.Equal(5.0, ma.Next(5));           // [5, 5, 5, 5] -> 20/4 (one 5 removed, one 5 added)
    }
    #endregion
}
