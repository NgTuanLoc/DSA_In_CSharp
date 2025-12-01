using DSA.LeetCode.Hashing;

namespace DSA.Tests.LeetCode.Hashing;

public class CountingTests
{
    /// <summary>
    /// Tests FindLongestSubstring finding longest substring with at most k distinct characters.
    /// Pattern: Hash counting with sliding window - track character frequencies
    /// </summary>
    [Theory]
    [InlineData("eceba", 2, 3)]
    [InlineData("abc", 3, 3)]
    [InlineData("aabbcc", 5, 6)]
    [InlineData("aaaa", 1, 4)]
    [InlineData("abcabcbb", 1, 2)]
    public void FindLongestSubstring_WithVariousInputs_ReturnsExpected(string s, int k, int expected)
    {
        var result = Counting.FindLongestSubstring(s, k);

        Assert.Equal(expected, result);
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
    [Theory]
    [InlineData("abacbc", true)]
    [InlineData("aaabb", false)]
    [InlineData("aaa", true)]
    [InlineData("abc", true)]
    public void AreOccurrencesEqual_WithVariousInputs_ReturnsExpected(string s, bool expected)
    {
        var result = Counting.AreOccurrencesEqual(s);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests SubArraySum counting subarrays with sum equal to k.
    /// https://leetcode.com/problems/subarray-sum-equals-k/description/
    /// Pattern: Hash counting with prefix sum - count subarrays
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 1, 1 }, 2, 2)]
    [InlineData(new[] { 1, 2, 3 }, 3, 2)]
    [InlineData(new[] { 1, 2, 1, 2, 1 }, 3, 4)]
    [InlineData(new[] { 1 }, 0, 0)]
    [InlineData(new[] { -1, -1, 1 }, 0, 1)]
    [InlineData(new[] { 1, -1, 0 }, 0, 3)]
    public void SubArraySum_WithVariousInputs_ReturnsExpected(int[] nums, int k, int expected)
    {
        var result = Counting.SubArraySum(nums, k);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests NumberOfSubArrays counting subarrays with k odd numbers.
    /// https://leetcode.com/problems/count-number-of-nice-subarrays/
    /// Pattern: Hash counting with prefix sum - count nice subarrays
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 1, 2, 1, 1 }, 3, 2)]
    [InlineData(new[] { 2, 4, 6 }, 1, 0)]
    [InlineData(new[] { 2, 2, 2, 1, 2, 2, 1, 2, 2, 2 }, 2, 16)]
    [InlineData(new[] { 2, 4, 6, 8 }, 0, 10)]
    public void NumberOfSubArrays_WithVariousInputs_ReturnsExpected(int[] nums, int k, int expected)
    {
        var result = Counting.NumberOfSubArrays(nums, k);

        Assert.Equal(expected, result);
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
    [Theory]
    [InlineData(new[] { 5, 7, 3, 9, 4, 9, 8, 3, 1 }, 8)]
    [InlineData(new[] { 9, 9, 8, 8 }, -1)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 5)]
    [InlineData(new[] { 7 }, 7)]
    public void LargestUniqueNumber_WithVariousInputs_ReturnsExpected(int[] nums, int expected)
    {
        var result = Counting.LargestUniqueNumber(nums);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests MaxNumberOfBalloons counting how many times "balloon" can be formed.
    /// https://leetcode.com/problems/maximum-number-of-balloons/
    /// Pattern: Hash counting - track character availability
    /// </summary>
    [Theory]
    [InlineData("nlaebolko", 1)]
    [InlineData("loonbalxballpoon", 2)]
    [InlineData("leetcode", 0)]
    [InlineData("balloonballoon", 2)]
    public void MaxNumberOfBalloons_WithVariousInputs_ReturnsExpected(string text, int expected)
    {
        var result = Counting.MaxNumberOfBalloons(text);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests FindMaxLength finding longest subarray with equal 0s and 1s.
    /// https://leetcode.com/problems/contiguous-array/description/
    /// Pattern: Hash counting with balance tracking - prefix sum technique
    /// </summary>
    [Theory]
    [InlineData(new[] { 0, 1 }, 2)]
    [InlineData(new[] { 0, 1, 0 }, 2)]
    [InlineData(new[] { 0, 1, 0, 0, 1, 1, 0 }, 6)]
    [InlineData(new[] { 0, 0, 0, 0 }, 0)]
    [InlineData(new[] { 1, 1, 1, 1 }, 0)]
    [InlineData(new[] { 0 }, 0)]
    [InlineData(new[] { 0, 0, 1, 1 }, 4)]
    public void FindMaxLength_WithVariousInputs_ReturnsExpected(int[] nums, int expected)
    {
        var result = Counting.FindMaxLength(nums);

        Assert.Equal(expected, result);
    }
}
