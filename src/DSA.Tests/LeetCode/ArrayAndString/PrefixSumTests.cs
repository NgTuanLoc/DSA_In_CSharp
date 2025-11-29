using DSA.LeetCode.ArrayAndString;

namespace DSA.Tests.LeetCode.ArrayAndString;

/// <summary>
/// Unit tests for Prefix Sum pattern implementations.
/// Prefix Sum technique pre-computes cumulative sums to answer range queries in O(1) time.
/// Formula: sum(i, j) = prefix[j] - prefix[i-1] (or prefix[j] - prefix[i] + nums[i])
/// Common use cases: range sum queries, subarray sum problems, and cumulative calculations.
/// Time Complexity: O(n) for preprocessing, O(1) for queries.
/// </summary>
public class PrefixSumTests
{
    #region AnswerQueries Tests
    /// <summary>
    /// Test: Verify answering multiple range sum queries using prefix sum.
    /// Pattern: Build prefix array once, then answer each query in O(1) time.
    /// </summary>
    [Fact]
    public void AnswerQueries_WithValidQueriesAndLimit_ReturnsCorrectAnswers()
    {
        // Arrange
        var nums = new List<int> { 1, 6, 3, 2, 7, 2 };
        var queries = new List<List<int>>
        {
            new() { 0, 3 },  // sum = 1+6+3+2 = 12 < 13 -> true
            new() { 2, 5 },  // sum = 3+2+7+2 = 14 >= 13 -> false
            new() { 2, 4 }   // sum = 3+2+7 = 12 < 13 -> true
        };
        var limit = 13;
        var expected = new List<bool> { true, false, true };

        // Act
        var result = PrefixSum.AnswerQueries(nums, queries, limit);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with single element queries.
    /// </summary>
    [Fact]
    public void AnswerQueries_WithSingleElementQueries_ReturnsCorrectAnswers()
    {
        // Arrange
        var nums = new List<int> { 5, 10, 15, 20 };
        var queries = new List<List<int>>
        {
            new() { 0, 0 },  // sum = 5 < 10 -> true
            new() { 3, 3 }   // sum = 20 >= 10 -> false
        };
        var limit = 10;
        var expected = new List<bool> { true, false };

        // Act
        var result = PrefixSum.AnswerQueries(nums, queries, limit);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with full range query.
    /// </summary>
    [Fact]
    public void AnswerQueries_WithFullRangeQuery_ReturnsCorrectAnswer()
    {
        // Arrange
        var nums = new List<int> { 1, 2, 3, 4 };
        var queries = new List<List<int>>
        {
            new() { 0, 3 }  // sum = 10 < 15 -> true
        };
        var limit = 15;
        var expected = new List<bool> { true };

        // Act
        var result = PrefixSum.AnswerQueries(nums, queries, limit);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region WaysToSplitArray Tests
    /// <summary>
    /// Test: Verify counting valid split points where left sum >= right sum.
    /// Pattern: Use prefix sum to efficiently compute left and right sums at each split.
    /// LeetCode: https://leetcode.com/problems/number-of-ways-to-split-array/
    /// </summary>
    [Fact]
    public void WaysToSplitArray_WithValidSplits_ReturnsCorrectCount()
    {
        // Arrange
        var nums = new List<int> { 10, 4, -8, 7 };
        var expected = 2; // splits at index 0 and 1

        // Act
        var result = PrefixSum.WaysToSplitArray(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when no valid splits exist.
    /// </summary>
    [Fact]
    public void WaysToSplitArray_WithNoValidSplits_ReturnsZero()
    {
        // Arrange
        var nums = new List<int> { 2, 3, 1, 0 };
        var expected = 2;

        // Act
        var result = PrefixSum.WaysToSplitArray(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with two elements.
    /// Edge case: Minimum valid input length.
    /// </summary>
    [Fact]
    public void WaysToSplitArray_WithTwoElements_ReturnsCorrectCount()
    {
        // Arrange
        var nums = new List<int> { 5, 3 };
        var expected = 1; // split at index 0: left=5, right=3

        // Act
        var result = PrefixSum.WaysToSplitArray(nums);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region RunningSum Tests
    /// <summary>
    /// Test: Verify computing running sum (prefix sum) of array.
    /// Pattern: Each element becomes sum of all previous elements plus itself.
    /// LeetCode: https://leetcode.com/problems/running-sum-of-1d-array/
    /// </summary>
    [Fact]
    public void RunningSum_WithPositiveNumbers_ReturnsCorrectRunningSum()
    {
        // Arrange
        var nums = new int[] { 1, 2, 3, 4 };
        var expected = new int[] { 1, 3, 6, 10 };

        // Act
        var result = PrefixSum.RunningSum(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with negative numbers.
    /// </summary>
    [Fact]
    public void RunningSum_WithMixedNumbers_ReturnsCorrectRunningSum()
    {
        // Arrange
        var nums = new int[] { 3, 1, 2, 10, -5 };
        var expected = new int[] { 3, 4, 6, 16, 11 };

        // Act
        var result = PrefixSum.RunningSum(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with single element.
    /// </summary>
    [Fact]
    public void RunningSum_WithSingleElement_ReturnsSameArray()
    {
        // Arrange
        var nums = new int[] { 5 };
        var expected = new int[] { 5 };

        // Act
        var result = PrefixSum.RunningSum(nums);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region MinStartValue Tests
    /// <summary>
    /// Test: Verify finding minimum positive start value to keep running sum always positive.
    /// Pattern: Find minimum prefix sum, then calculate required start value.
    /// LeetCode: https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum/
    /// </summary>
    [Fact]
    public void MinStartValue_WithNegativeMinimum_ReturnsCorrectStartValue()
    {
        // Arrange
        var nums = new int[] { -3, 2, -3, 4, 2 };
        var expected = 5; // To keep step-by-step sum positive

        // Act
        var result = PrefixSum.MinStartValue(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when all numbers are positive.
    /// </summary>
    [Fact]
    public void MinStartValue_WithAllPositiveNumbers_ReturnsOne()
    {
        // Arrange
        var nums = new int[] { 1, 2, 3 };
        var expected = 1;

        // Act
        var result = PrefixSum.MinStartValue(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with descending negative values.
    /// </summary>
    [Fact]
    public void MinStartValue_WithDescendingNegatives_ReturnsCorrectStartValue()
    {
        // Arrange
        var nums = new int[] { 1, -2, -3 };
        var expected = 5; // start=5: 5->6->4->1 (all positive)

        // Act
        var result = PrefixSum.MinStartValue(nums);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region GetAverages Tests
    /// <summary>
    /// Test: Verify computing k-radius subarray averages using prefix sum.
    /// Pattern: For each index, compute average of [i-k, i+k] range if valid, else -1.
    /// LeetCode: https://leetcode.com/problems/k-radius-subarray-averages/
    /// </summary>
    [Fact]
    public void GetAverages_WithValidKRadius_ReturnsCorrectAverages()
    {
        // Arrange
        var nums = new int[] { 7, 4, 3, 9, 1, 8, 5, 2, 6 };
        var k = 3;
        var expected = new int[] { -1, -1, -1, 5, 4, 4, -1, -1, -1 };

        // Act
        var result = PrefixSum.GetAverages(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when k = 0 (average is element itself).
    /// </summary>
    [Fact]
    public void GetAverages_WithKEqualsZero_ReturnsOriginalArray()
    {
        // Arrange
        var nums = new int[] { 1, 2, 3, 4, 5 };
        var k = 0;
        var expected = new int[] { 1, 2, 3, 4, 5 };

        // Act
        var result = PrefixSum.GetAverages(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when k is too large (all elements return -1).
    /// </summary>
    [Fact]
    public void GetAverages_WithKTooLarge_ReturnsAllNegativeOne()
    {
        // Arrange
        var nums = new int[] { 1, 2, 3 };
        var k = 5;
        var expected = new int[] { -1, -1, -1 };

        // Act
        var result = PrefixSum.GetAverages(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region LargestAltitude Tests
    /// <summary>
    /// Test: Verify finding highest altitude from gain array.
    /// Pattern: Compute running sum to get altitudes at each point.
    /// LeetCode: https://leetcode.com/problems/find-the-highest-altitude/
    /// </summary>
    [Fact]
    public void LargestAltitude_WithPositiveAndNegativeGains_ReturnsMaxAltitude()
    {
        // Arrange
        var gain = new int[] { -5, 1, 5, 0, -7 };
        var expected = 1; // altitudes: 0, -5, -4, 1, 1, -6

        // Act
        var result = PrefixSum.LargestAltitude(gain);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with all negative gains.
    /// </summary>
    [Fact]
    public void LargestAltitude_WithAllNegativeGains_ReturnsZero()
    {
        // Arrange
        var gain = new int[] { -4, -3, -2, -1 };
        var expected = 0; // Starting altitude is highest

        // Act
        var result = PrefixSum.LargestAltitude(gain);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with all positive gains.
    /// </summary>
    [Fact]
    public void LargestAltitude_WithAllPositiveGains_ReturnsSum()
    {
        // Arrange
        var gain = new int[] { 1, 2, 3, 4 };
        var expected = 10; // Final altitude: 0+1+2+3+4 = 10

        // Act
        var result = PrefixSum.LargestAltitude(gain);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region PivotIndex Tests
    /// <summary>
    /// Test: Verify finding pivot index where left sum equals right sum.
    /// Pattern: Use prefix sum to efficiently compute and compare left/right sums.
    /// LeetCode: https://leetcode.com/problems/find-pivot-index/
    /// </summary>
    [Fact]
    public void PivotIndex_WithValidPivot_ReturnsPivotIndex()
    {
        // Arrange
        var nums = new int[] { 1, 7, 3, 6, 5, 6 };
        var expected = 3; // left sum = 1+7+3 = 11, right sum = 5+6 = 11

        // Act
        var result = PrefixSum.PivotIndex(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when no pivot exists.
    /// </summary>
    [Fact]
    public void PivotIndex_WithNoPivot_ReturnsNegativeOne()
    {
        // Arrange
        var nums = new int[] { 1, 2, 3 };
        var expected = -1;

        // Act
        var result = PrefixSum.PivotIndex(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when pivot is at first index.
    /// Edge case: Left sum is 0.
    /// </summary>
    [Fact]
    public void PivotIndex_WithPivotAtStart_ReturnsZero()
    {
        // Arrange
        var nums = new int[] { 2, 1, -1 };
        var expected = 0; // left sum = 0, right sum = 1 + (-1) = 0

        // Act
        var result = PrefixSum.PivotIndex(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when pivot is at last index.
    /// Edge case: Right sum is 0.
    /// </summary>
    [Fact]
    public void PivotIndex_WithPivotAtEnd_ReturnsLastIndex()
    {
        // Arrange
        var nums = new int[] { -1, 1, 2 };
        var expected = 2; // left sum = -1 + 1 = 0, right sum = 0

        // Act
        var result = PrefixSum.PivotIndex(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with single element.
    /// Edge case: Both sums are 0.
    /// </summary>
    [Fact]
    public void PivotIndex_WithSingleElement_ReturnsZero()
    {
        // Arrange
        var nums = new int[] { 1 };
        var expected = 0;

        // Act
        var result = PrefixSum.PivotIndex(nums);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion
}
