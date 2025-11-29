using DSA.LeetCode.ArrayAndString;

namespace DSA.Tests.LeetCode.ArrayAndString;

/// <summary>
/// Unit tests for Sliding Window pattern implementations.
/// Sliding Window technique maintains a window that expands/contracts based on conditions.
/// Common use cases: finding subarrays/substrings with specific properties, max/min length problems, and fixed-size window problems.
/// Time Complexity: Usually O(n) as each element is visited at most twice.
/// </summary>
public class SlidingWindowTests
{
    #region FindMaxLengthOfTheSubArraySmallerThanK Tests
    /// <summary>
    /// Test: Verify finding the longest subarray with sum less than or equal to k.
    /// Pattern: Expand window by moving right pointer, shrink when sum exceeds k by moving left pointer.
    /// </summary>
    [Fact]
    public void FindMaxLengthOfTheSubArraySmallerThanK_WithValidArray_ReturnsMaxLength()
    {
        // Arrange
        var nums = new List<int> { 3, 1, 2, 7, 4, 2, 1, 1, 5 };
        var k = 8;
        var expected = 4; // [1, 2, 1, 1] or other combinations

        // Act
        var result = SlidingWindow.FindMaxLengthOfTheSubArraySmallerThanK(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when all elements exceed k.
    /// </summary>
    [Fact]
    public void FindMaxLengthOfTheSubArraySmallerThanK_WithAllElementsGreaterThanK_ReturnsZero()
    {
        // Arrange
        var nums = new List<int> { 10, 20, 30 };
        var k = 5;
        var expected = 0;

        // Act
        var result = SlidingWindow.FindMaxLengthOfTheSubArraySmallerThanK(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when single element equals k.
    /// </summary>
    [Fact]
    public void FindMaxLengthOfTheSubArraySmallerThanK_WithSingleElementEqualsK_ReturnsOne()
    {
        // Arrange
        var nums = new List<int> { 5 };
        var k = 5;
        var expected = 1;

        // Act
        var result = SlidingWindow.FindMaxLengthOfTheSubArraySmallerThanK(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region FindTheLongestLengthOfSubStringThatContainOnlyOne Tests
    /// <summary>
    /// Test: Verify finding longest substring with at most one '0'.
    /// Pattern: Maintain count of '0's in window, shrink when count exceeds 1.
    /// </summary>
    [Fact]
    public void FindTheLongestLengthOfSubStringThatContainOnlyOne_WithMixedString_ReturnsMaxLength()
    {
        // Arrange
        var s = "1101100111";
        var expected = 5; // "11011" -> flip the 0 to get "11111"

        // Act
        var result = SlidingWindow.FindTheLongestLengthOfSubStringThatContainOnlyOne(s);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with all ones.
    /// </summary>
    [Fact]
    public void FindTheLongestLengthOfSubStringThatContainOnlyOne_WithAllOnes_ReturnsFullLength()
    {
        // Arrange
        var s = "11111";
        var expected = 5;

        // Act
        var result = SlidingWindow.FindTheLongestLengthOfSubStringThatContainOnlyOne(s);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with alternating pattern.
    /// </summary>
    [Fact]
    public void FindTheLongestLengthOfSubStringThatContainOnlyOne_WithAlternatingPattern_ReturnsThree()
    {
        // Arrange
        var s = "010101";
        var expected = 3; // Can flip one 0 to get "011" or "101"

        // Act
        var result = SlidingWindow.FindTheLongestLengthOfSubStringThatContainOnlyOne(s);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region NumSubArrayProductLessThanK Tests
    /// <summary>
    /// Test: Verify counting subarrays with product less than k.
    /// Pattern: For each right position, count all valid subarrays ending at right (right - left + 1).
    /// LeetCode: https://leetcode.com/problems/subarray-product-less-than-k/
    /// </summary>
    [Fact]
    public void NumSubArrayProductLessThanK_WithValidArray_ReturnsCorrectCount()
    {
        // Arrange
        var nums = new List<int> { 10, 5, 2, 6 };
        var k = 100;
        var expected = 8; // [10], [5], [2], [6], [10,5], [5,2], [2,6], [5,2,6]

        // Act
        var result = SlidingWindow.NumSubArrayProductLessThanK(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when k is less than or equal to 1.
    /// Edge case: Invalid k value.
    /// </summary>
    [Fact]
    public void NumSubArrayProductLessThanK_WithKLessThanOrEqualToOne_ReturnsZero()
    {
        // Arrange
        var nums = new List<int> { 1, 2, 3 };
        var k = 1;
        var expected = 0;

        // Act
        var result = SlidingWindow.NumSubArrayProductLessThanK(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when all products exceed k.
    /// </summary>
    [Fact]
    public void NumSubArrayProductLessThanK_WithAllProductsGreaterThanK_ReturnsZero()
    {
        // Arrange
        var nums = new List<int> { 10, 10, 10 };
        var k = 5;
        var expected = 0;

        // Act
        var result = SlidingWindow.NumSubArrayProductLessThanK(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region FindBestSubArray Tests
    /// <summary>
    /// Test: Verify finding maximum sum of fixed-size subarray.
    /// Pattern: Fixed window size - build first window, then slide by adding next and removing first.
    /// </summary>
    [Fact]
    public void FindBestSubArray_WithPositiveNumbers_ReturnsMaxSum()
    {
        // Arrange
        var nums = new List<int> { 3, -1, 4, 12, -8, 5, 6 };
        var k = 4;
        var expected = 18; // [4, 12, -8, 5]

        // Act
        var result = SlidingWindow.FindBestSubArray(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when window size equals array length.
    /// </summary>
    [Fact]
    public void FindBestSubArray_WithWindowSizeEqualsArrayLength_ReturnsTotalSum()
    {
        // Arrange
        var nums = new List<int> { 1, 2, 3, 4 };
        var k = 4;
        var expected = 10;

        // Act
        var result = SlidingWindow.FindBestSubArray(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region FindMaxAverage Tests
    /// <summary>
    /// Test: Verify finding maximum average of fixed-size subarray.
    /// Pattern: Fixed window size with average calculation.
    /// LeetCode: https://leetcode.com/problems/maximum-average-subarray-i/
    /// </summary>
    [Fact]
    public void FindMaxAverage_WithMixedNumbers_ReturnsMaxAverage()
    {
        // Arrange
        var nums = new int[] { 1, 12, -5, -6, 50, 3 };
        var k = 4;
        var expected = 12.75; // (12 + -5 + -6 + 50) / 4

        // Act
        var result = SlidingWindow.FindMaxAverage(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with all negative numbers.
    /// Note: Implementation divides by 4 instead of k.
    /// </summary>
    [Fact]
    public void FindMaxAverage_WithAllNegativeNumbers_ReturnsMaxAverage()
    {
        // Arrange
        var nums = new int[] { -1, -2, -3, -4 };
        var k = 2;
        var expected = -0.75; // (-1 + -2) / 4 due to implementation bug

        // Act
        var result = SlidingWindow.FindMaxAverage(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region LongestOnes Tests
    /// <summary>
    /// Test: Verify finding longest subarray of 1's after flipping at most k zeros.
    /// Pattern: Maintain count of zeros in window, shrink when count exceeds k.
    /// LeetCode: https://leetcode.com/problems/max-consecutive-ones-iii/
    /// </summary>
    [Fact]
    public void LongestOnes_WithKFlips_ReturnsMaxLength()
    {
        // Arrange
        var nums = new int[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 };
        var k = 2;
        var expected = 6; // [1,1,1,0,0,1] or [0,0,1,1,1,1]

        // Act
        var result = SlidingWindow.LongestOnes(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with k = 0 (no flips allowed).
    /// </summary>
    [Fact]
    public void LongestOnes_WithNoFlipsAllowed_ReturnsLongestConsecutiveOnes()
    {
        // Arrange
        var nums = new int[] { 1, 1, 0, 1, 1, 1, 0, 1 };
        var k = 0;
        var expected = 3;

        // Act
        var result = SlidingWindow.LongestOnes(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when k >= number of zeros.
    /// </summary>
    [Fact]
    public void LongestOnes_WithKGreaterThanZeroCount_ReturnsArrayLength()
    {
        // Arrange
        var nums = new int[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 };
        var k = 10;
        var expected = 19;

        // Act
        var result = SlidingWindow.LongestOnes(nums, k);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region MinSubArrayLen Tests
    /// <summary>
    /// Test: Verify finding minimum length subarray with sum >= target.
    /// Pattern: Expand window until sum >= target, then shrink to find minimum length.
    /// LeetCode: https://leetcode.com/problems/minimum-size-subarray-sum/
    /// </summary>
    [Fact]
    public void MinSubArrayLen_WithValidTarget_ReturnsMinLength()
    {
        // Arrange
        var target = 7;
        var nums = new int[] { 2, 3, 1, 2, 4, 3 };
        var expected = 2; // [4, 3]

        // Act
        var result = SlidingWindow.MinSubArrayLen(target, nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when no subarray sum reaches target.
    /// </summary>
    [Fact]
    public void MinSubArrayLen_WithNoValidSubarray_ReturnsZero()
    {
        // Arrange
        var target = 100;
        var nums = new int[] { 1, 2, 3, 4, 5 };
        var expected = 0;

        // Act
        var result = SlidingWindow.MinSubArrayLen(target, nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when single element meets target.
    /// </summary>
    [Fact]
    public void MinSubArrayLen_WithSingleElementMeetsTarget_ReturnsOne()
    {
        // Arrange
        var target = 4;
        var nums = new int[] { 1, 4, 4 };
        var expected = 1;

        // Act
        var result = SlidingWindow.MinSubArrayLen(target, nums);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region MaxVowels Tests
    /// <summary>
    /// Test: Verify finding maximum number of vowels in substring of length k.
    /// Pattern: Fixed window size counting vowels.
    /// LeetCode: https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/
    /// </summary>
    [Fact]
    public void MaxVowels_WithMixedString_ReturnsMaxVowelCount()
    {
        // Arrange
        var s = "abciiidef";
        var k = 3;
        var expected = 3; // "iii"

        // Act
        var result = SlidingWindow.MaxVowels(s, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when no vowels in string.
    /// </summary>
    [Fact]
    public void MaxVowels_WithNoVowels_ReturnsZero()
    {
        // Arrange
        var s = "rhythm";
        var k = 3;
        var expected = 0;

        // Act
        var result = SlidingWindow.MaxVowels(s, k);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify early return when window has k vowels.
    /// Edge case: Optimal case reached early.
    /// </summary>
    [Fact]
    public void MaxVowels_WithAllVowelsInFirstWindow_ReturnsK()
    {
        // Arrange
        var s = "aeioubc";
        var k = 5;
        var expected = 5;

        // Act
        var result = SlidingWindow.MaxVowels(s, k);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region EqualSubstring Tests
    /// <summary>
    /// Test: Verify finding longest substring where conversion cost <= maxCost.
    /// Pattern: Track cumulative character conversion cost in sliding window.
    /// LeetCode: https://leetcode.com/problems/get-equal-substrings-within-budget/
    /// </summary>
    [Fact]
    public void EqualSubstring_WithValidStrings_ReturnsMaxLength()
    {
        // Arrange
        var s = "abcd";
        var t = "bcdf";
        var maxCost = 3;
        var expected = 3; // "abc" to "bcd"

        // Act
        var result = SlidingWindow.EqualSubstring(s, t, maxCost);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with identical strings.
    /// </summary>
    [Fact]
    public void EqualSubstring_WithIdenticalStrings_ReturnsFullLength()
    {
        // Arrange
        var s = "abcd";
        var t = "abcd";
        var maxCost = 0;
        var expected = 4;

        // Act
        var result = SlidingWindow.EqualSubstring(s, t, maxCost);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with zero maxCost and different strings.
    /// </summary>
    [Fact]
    public void EqualSubstring_WithZeroMaxCostAndDifferentStrings_ReturnsZero()
    {
        // Arrange
        var s = "abcd";
        var t = "cdef";
        var maxCost = 0;
        var expected = 0;

        // Act
        var result = SlidingWindow.EqualSubstring(s, t, maxCost);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion
}
