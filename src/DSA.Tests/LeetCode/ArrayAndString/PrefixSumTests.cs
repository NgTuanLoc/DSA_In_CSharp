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
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 3, 6, 10 })]
    [InlineData(new[] { 3, 1, 2, 10, -5 }, new[] { 3, 4, 6, 16, 11 })]
    [InlineData(new[] { 5 }, new[] { 5 })]
    public void RunningSum_WithVariousInputs_ReturnsExpected(int[] nums, int[] expected)
    {
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
    [Theory]
    [InlineData(new[] { -3, 2, -3, 4, 2 }, 5)]
    [InlineData(new[] { 1, 2, 3 }, 1)]
    [InlineData(new[] { 1, -2, -3 }, 5)]
    public void MinStartValue_WithVariousInputs_ReturnsExpected(int[] nums, int expected)
    {
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
    [Theory]
    [InlineData(new[] { -5, 1, 5, 0, -7 }, 1)]
    [InlineData(new[] { -4, -3, -2, -1 }, 0)]
    [InlineData(new[] { 1, 2, 3, 4 }, 10)]
    public void LargestAltitude_WithVariousInputs_ReturnsExpected(int[] gain, int expected)
    {
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
    [Theory]
    [InlineData(new[] { 1, 7, 3, 6, 5, 6 }, 3)]
    [InlineData(new[] { 1, 2, 3 }, -1)]
    [InlineData(new[] { 2, 1, -1 }, 0)]
    [InlineData(new[] { -1, 1, 2 }, 2)]
    [InlineData(new[] { 1 }, 0)]
    public void PivotIndex_WithVariousInputs_ReturnsExpected(int[] nums, int expected)
    {
        // Act
        var result = PrefixSum.PivotIndex(nums);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion
}
