using DSA.LeetCode.Hashing;

namespace DSA.Tests.LeetCode.Hashing;

public class CountingTests
{
    /// <summary>
    /// Tests FindLongestSubstring finding longest substring with at most k distinct characters.
    /// Pattern: Hash counting with sliding window - track character frequencies
    /// </summary>
    [Fact]
    public void FindLongestSubstring_WithMaxTwoDistinct_ReturnsLength()
    {
        var result = Counting.FindLongestSubstring("eceba", 2);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests FindLongestSubstring with k equal to string length.
    /// </summary>
    [Fact]
    public void FindLongestSubstring_WithKEqualsLength_ReturnsFullLength()
    {
        var result = Counting.FindLongestSubstring("abc", 3);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests FindLongestSubstring with k larger than distinct characters.
    /// </summary>
    [Fact]
    public void FindLongestSubstring_WithKLargerThanDistinct_ReturnsFullLength()
    {
        var result = Counting.FindLongestSubstring("aabbcc", 5);

        Assert.Equal(6, result);
    }

    /// <summary>
    /// Tests FindLongestSubstring with all same characters.
    /// </summary>
    [Fact]
    public void FindLongestSubstring_WithAllSameChars_ReturnsFullLength()
    {
        var result = Counting.FindLongestSubstring("aaaa", 1);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests FindLongestSubstring with k equals one.
    /// </summary>
    [Fact]
    public void FindLongestSubstring_WithKEqualsOne_ReturnsLongestSingleChar()
    {
        var result = Counting.FindLongestSubstring("abcabcbb", 1);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests Intersection finding common elements across multiple arrays.
    /// https://leetcode.com/problems/intersection-of-multiple-arrays/
    /// Pattern: Hash counting - count occurrences across arrays
    /// </summary>
    [Fact]
    public void Intersection_WithCommonElements_ReturnsSorted()
    {
        var result = Counting.Intersection([[3, 1, 2, 4, 5], [1, 2, 3, 4], [3, 4, 5, 6]]);

        Assert.Equal([3, 4], result);
    }

    /// <summary>
    /// Tests Intersection with no common elements.
    /// </summary>
    [Fact]
    public void Intersection_WithNoCommon_ReturnsEmpty()
    {
        var result = Counting.Intersection([[1, 2, 3], [4, 5, 6], [7, 8, 9]]);

        Assert.Empty(result);
    }

    /// <summary>
    /// Tests Intersection with single array.
    /// </summary>
    [Fact]
    public void Intersection_WithSingleArray_ReturnsAllElements()
    {
        var result = Counting.Intersection([[1, 2, 3]]);

        Assert.Equal([1, 2, 3], result);
    }

    /// <summary>
    /// Tests Intersection with identical arrays.
    /// </summary>
    [Fact]
    public void Intersection_WithIdenticalArrays_ReturnsAllElements()
    {
        var result = Counting.Intersection([[1, 2, 3], [1, 2, 3], [1, 2, 3]]);

        Assert.Equal([1, 2, 3], result);
    }

    /// <summary>
    /// Tests Intersection with single common element.
    /// </summary>
    [Fact]
    public void Intersection_WithSingleCommon_ReturnsSingleElement()
    {
        var result = Counting.Intersection([[5, 2, 7], [5, 9, 1], [5, 6, 8]]);

        Assert.Equal([5], result);
    }

    /// <summary>
    /// Tests AreOccurrencesEqual checking if all characters have equal frequency.
    /// https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences/description/
    /// Pattern: Hash counting - compare frequencies
    /// </summary>
    [Fact]
    public void AreOccurrencesEqual_WithEqualOccurrences_ReturnsTrue()
    {
        var result = Counting.AreOccurrencesEqual("abacbc");

        Assert.True(result);
    }

    /// <summary>
    /// Tests AreOccurrencesEqual with unequal occurrences.
    /// </summary>
    [Fact]
    public void AreOccurrencesEqual_WithUnequalOccurrences_ReturnsFalse()
    {
        var result = Counting.AreOccurrencesEqual("aaabb");

        Assert.False(result);
    }

    /// <summary>
    /// Tests AreOccurrencesEqual with single character.
    /// </summary>
    [Fact]
    public void AreOccurrencesEqual_WithSingleChar_ReturnsTrue()
    {
        var result = Counting.AreOccurrencesEqual("aaa");

        Assert.True(result);
    }

    /// <summary>
    /// Tests AreOccurrencesEqual with all unique characters.
    /// </summary>
    [Fact]
    public void AreOccurrencesEqual_WithAllUnique_ReturnsTrue()
    {
        var result = Counting.AreOccurrencesEqual("abc");

        Assert.True(result);
    }

    /// <summary>
    /// Tests SubArraySum counting subarrays with sum equal to k.
    /// https://leetcode.com/problems/subarray-sum-equals-k/description/
    /// Pattern: Hash counting with prefix sum - count subarrays
    /// </summary>
    [Fact]
    public void SubArraySum_WithMultipleMatches_ReturnsCount()
    {
        var result = Counting.SubArraySum([1, 1, 1], 2);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests SubArraySum with exact array sum.
    /// </summary>
    [Fact]
    public void SubArraySum_WithExactArraySum_ReturnsOne()
    {
        var result = Counting.SubArraySum([1, 2, 3], 3);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests SubArraySum with multiple overlapping subarrays.
    /// </summary>
    [Fact]
    public void SubArraySum_WithOverlapping_ReturnsAllMatches()
    {
        var result = Counting.SubArraySum([1, 2, 1, 2, 1], 3);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests SubArraySum with zero target.
    /// </summary>
    [Fact]
    public void SubArraySum_WithZeroTarget_ReturnsZero()
    {
        var result = Counting.SubArraySum([1], 0);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests SubArraySum with negative numbers summing to zero.
    /// </summary>
    [Fact]
    public void SubArraySum_WithNegativeNumbers_ReturnsCorrectCount()
    {
        var result = Counting.SubArraySum([-1, -1, 1], 0);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests SubArraySum with mixed positives and negatives.
    /// </summary>
    [Fact]
    public void SubArraySum_WithMixedNumbers_ReturnsCorrectCount()
    {
        var result = Counting.SubArraySum([1, -1, 0], 0);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests NumberOfSubArrays counting subarrays with k odd numbers.
    /// https://leetcode.com/problems/count-number-of-nice-subarrays/
    /// Pattern: Hash counting with prefix sum - count nice subarrays
    /// </summary>
    [Fact]
    public void NumberOfSubArrays_WithKOddNumbers_ReturnsCount()
    {
        var result = Counting.NumberOfSubArrays([1, 1, 2, 1, 1], 3);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests NumberOfSubArrays with no odd numbers possible.
    /// </summary>
    [Fact]
    public void NumberOfSubArrays_WithAllEven_ReturnsZero()
    {
        var result = Counting.NumberOfSubArrays([2, 4, 6], 1);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests NumberOfSubArrays with multiple nice subarrays.
    /// </summary>
    [Fact]
    public void NumberOfSubArrays_WithMultipleOdds_ReturnsCorrectCount()
    {
        var result = Counting.NumberOfSubArrays([2, 2, 2, 1, 2, 2, 1, 2, 2, 2], 2);

        Assert.Equal(16, result);
    }

    /// <summary>
    /// Tests NumberOfSubArrays with k equals zero.
    /// </summary>
    [Fact]
    public void NumberOfSubArrays_WithKZero_CountsEvenSubarrays()
    {
        var result = Counting.NumberOfSubArrays([2, 4, 6, 8], 0);

        Assert.Equal(10, result);
    }

    /// <summary>
    /// Tests FindWinners finding players with 0 or 1 losses.
    /// https://leetcode.com/problems/find-players-with-zero-or-one-losses/description/
    /// Pattern: Hash counting - track losses per player
    /// </summary>
    [Fact]
    public void FindWinners_WithVariousMatches_ReturnsSortedLists()
    {
        var result = Counting.FindWinners([[1, 3], [2, 3], [3, 6], [5, 6], [5, 7], [4, 5], [4, 8], [4, 9], [10, 4], [10, 9]]);

        Assert.Equal([1, 2, 10], result[0]);
        Assert.Equal([4, 5, 7, 8], result[1]);
    }

    /// <summary>
    /// Tests FindWinners with simple scenario.
    /// </summary>
    [Fact]
    public void FindWinners_WithSimpleMatches_ReturnsCorrectLists()
    {
        var result = Counting.FindWinners([[2, 3], [1, 8], [5, 4], [6, 7]]);

        Assert.Equal([1, 2, 5, 6], result[0]);
        Assert.Equal([3, 4, 7, 8], result[1]);
    }

    /// <summary>
    /// Tests FindWinners with no players losing exactly once.
    /// </summary>
    [Fact]
    public void FindWinners_WithNoOneLoss_ReturnsEmptySecondList()
    {
        var result = Counting.FindWinners([[1, 2], [1, 2], [1, 2]]);

        Assert.Equal([1], result[0]);
        Assert.Empty(result[1]);
    }

    /// <summary>
    /// Tests LargestUniqueNumber finding largest number with frequency 1.
    /// https://leetcode.com/problems/largest-unique-number/description/
    /// Pattern: Hash counting - find unique with max value
    /// </summary>
    [Fact]
    public void LargestUniqueNumber_WithUniques_ReturnsLargest()
    {
        var result = Counting.LargestUniqueNumber([5, 7, 3, 9, 4, 9, 8, 3, 1]);

        Assert.Equal(8, result);
    }

    /// <summary>
    /// Tests LargestUniqueNumber with no unique numbers.
    /// </summary>
    [Fact]
    public void LargestUniqueNumber_WithNoUniques_ReturnsMinusOne()
    {
        var result = Counting.LargestUniqueNumber([9, 9, 8, 8]);

        Assert.Equal(-1, result);
    }

    /// <summary>
    /// Tests LargestUniqueNumber with all unique.
    /// </summary>
    [Fact]
    public void LargestUniqueNumber_WithAllUnique_ReturnsMax()
    {
        var result = Counting.LargestUniqueNumber([1, 2, 3, 4, 5]);

        Assert.Equal(5, result);
    }

    /// <summary>
    /// Tests LargestUniqueNumber with single element.
    /// </summary>
    [Fact]
    public void LargestUniqueNumber_WithSingleElement_ReturnsElement()
    {
        var result = Counting.LargestUniqueNumber([7]);

        Assert.Equal(7, result);
    }

    /// <summary>
    /// Tests MaxNumberOfBalloons counting how many times "balloon" can be formed.
    /// https://leetcode.com/problems/maximum-number-of-balloons/
    /// Pattern: Hash counting - track character availability
    /// </summary>
    [Fact]
    public void MaxNumberOfBalloons_WithEnoughChars_ReturnsCount()
    {
        var result = Counting.MaxNumberOfBalloons("nlaebolko");

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests MaxNumberOfBalloons with multiple instances.
    /// </summary>
    [Fact]
    public void MaxNumberOfBalloons_WithMultipleInstances_ReturnsCount()
    {
        var result = Counting.MaxNumberOfBalloons("loonbalxballpoon");

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests MaxNumberOfBalloons with insufficient characters.
    /// </summary>
    [Fact]
    public void MaxNumberOfBalloons_WithInsufficientChars_ReturnsZero()
    {
        var result = Counting.MaxNumberOfBalloons("leetcode");

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests MaxNumberOfBalloons with extra characters.
    /// </summary>
    [Fact]
    public void MaxNumberOfBalloons_WithExtraChars_ReturnsCorrectCount()
    {
        var result = Counting.MaxNumberOfBalloons("balloonballoon");

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests FindMaxLength finding longest subarray with equal 0s and 1s.
    /// https://leetcode.com/problems/contiguous-array/description/
    /// Pattern: Hash counting with balance tracking - prefix sum technique
    /// </summary>
    [Fact]
    public void FindMaxLength_WithEqualZerosAndOnes_ReturnsLength()
    {
        var result = Counting.FindMaxLength([0, 1]);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests FindMaxLength with unequal counts.
    /// </summary>
    [Fact]
    public void FindMaxLength_WithUnequal_ReturnsLongestEqual()
    {
        var result = Counting.FindMaxLength([0, 1, 0]);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests FindMaxLength with longer array.
    /// </summary>
    [Fact]
    public void FindMaxLength_WithLongerArray_ReturnsMaxLength()
    {
        var result = Counting.FindMaxLength([0, 1, 0, 0, 1, 1, 0]);

        Assert.Equal(6, result);
    }

    /// <summary>
    /// Tests FindMaxLength with all zeros.
    /// </summary>
    [Fact]
    public void FindMaxLength_WithAllZeros_ReturnsZero()
    {
        var result = Counting.FindMaxLength([0, 0, 0, 0]);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests FindMaxLength with all ones.
    /// </summary>
    [Fact]
    public void FindMaxLength_WithAllOnes_ReturnsZero()
    {
        var result = Counting.FindMaxLength([1, 1, 1, 1]);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests FindMaxLength with single element.
    /// </summary>
    [Fact]
    public void FindMaxLength_WithSingleElement_ReturnsZero()
    {
        var result = Counting.FindMaxLength([0]);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests FindMaxLength with entire array equal.
    /// </summary>
    [Fact]
    public void FindMaxLength_WithEntireArrayEqual_ReturnsFullLength()
    {
        var result = Counting.FindMaxLength([0, 0, 1, 1]);

        Assert.Equal(4, result);
    }
}
