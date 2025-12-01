using DSA.LeetCode.Hashing;

namespace DSA.Tests.LeetCode.Hashing;

public class CheckForExistenceTests
{
    /// <summary>
    /// Tests TwoSum finding two numbers that add up to target.
    /// https://leetcode.com/problems/two-sum/description/
    /// Pattern: Hash existence check - store complement and find match
    /// </summary>
    [Fact]
    public void TwoSum_WithValidPair_ReturnsIndices()
    {
        var result = CheckForExistence.TwoSum([2, 7, 11, 15], 9);

        Assert.Equal(2, result.Count);
        Assert.Contains(0, result);
        Assert.Contains(1, result);
    }

    /// <summary>
    /// Tests TwoSum with multiple valid pairs, returns first match.
    /// </summary>
    [Fact]
    public void TwoSum_WithMultiplePairs_ReturnsFirstMatch()
    {
        var result = CheckForExistence.TwoSum([3, 3], 6);

        Assert.Equal(2, result.Count);
        Assert.Contains(0, result);
        Assert.Contains(1, result);
    }

    /// <summary>
    /// Tests TwoSum with negative numbers.
    /// </summary>
    [Fact]
    public void TwoSum_WithNegativeNumbers_ReturnsCorrectIndices()
    {
        var result = CheckForExistence.TwoSum([-1, -2, -3, -4, -5], -8);

        Assert.Equal(2, result.Count);
        Assert.Contains(2, result);
        Assert.Contains(4, result);
    }

    /// <summary>
    /// Tests TwoSum when no valid pair exists.
    /// </summary>
    [Fact]
    public void TwoSum_WithNoValidPair_ReturnsMinusOne()
    {
        var result = CheckForExistence.TwoSum([1, 2, 3], 7);

        Assert.Equal([-1, -1], result);
    }

    /// <summary>
    /// Tests TwoSum with zero target.
    /// </summary>
    [Fact]
    public void TwoSum_WithZeroTarget_ReturnsCorrectIndices()
    {
        var result = CheckForExistence.TwoSum([-3, 4, 3, 90], 0);

        Assert.Equal(2, result.Count);
        Assert.Contains(0, result);
        Assert.Contains(2, result);
    }

    /// <summary>
    /// Tests RepeatedCharacter finding first letter to appear twice.
    /// https://leetcode.com/problems/first-letter-to-appear-twice/description/
    /// Pattern: Hash existence check - detect first duplicate
    /// </summary>
    [Theory]
    [InlineData("abccbaacz", 'c')]
    [InlineData("abba", 'b')]
    [InlineData("aa", 'a')]
    public void RepeatedCharacter_WithVariousInputs_ReturnsExpected(string s, char expected)
    {
        var result = CheckForExistence.RepeatedCharacter(s);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests FindNumbers finding isolated numbers (no neighbors).
    /// Pattern: Hash existence check - check if x-1 and x+1 exist
    /// </summary>
    [Fact]
    public void FindNumbers_WithIsolatedNumbers_ReturnsAllIsolated()
    {
        var result = CheckForExistence.FindNumbers([1, 3, 5, 7]);

        Assert.Equal(4, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(3, result);
        Assert.Contains(5, result);
        Assert.Contains(7, result);
    }

    /// <summary>
    /// Tests FindNumbers with consecutive sequences.
    /// </summary>
    [Fact]
    public void FindNumbers_WithConsecutiveNumbers_ReturnsEmpty()
    {
        var result = CheckForExistence.FindNumbers([1, 2, 3, 4, 5]);

        Assert.Empty(result);
    }

    /// <summary>
    /// Tests FindNumbers with mixed isolated and consecutive.
    /// </summary>
    [Fact]
    public void FindNumbers_WithMixedNumbers_ReturnsOnlyIsolated()
    {
        var result = CheckForExistence.FindNumbers([10, 6, 5, 8]);

        Assert.Equal(2, result.Count);
        Assert.Contains(10, result);
        Assert.Contains(8, result);
    }

    /// <summary>
    /// Tests FindNumbers with duplicate isolated numbers.
    /// </summary>
    [Fact]
    public void FindNumbers_WithDuplicateIsolated_ReturnsOnlyUnique()
    {
        var result = CheckForExistence.FindNumbers([5, 5, 5]);

        Assert.Equal(3, result.Count);
        Assert.All(result, n => Assert.Equal(5, n));
    }

    /// <summary>
    /// Tests FindNumbers with negative numbers.
    /// </summary>
    [Fact]
    public void FindNumbers_WithNegativeNumbers_ReturnsCorrectNumbers()
    {
        var result = CheckForExistence.FindNumbers([-5, -3, -1]);

        Assert.Equal(3, result.Count);
    }

    /// <summary>
    /// Tests CheckIfPangram with valid pangram containing all 26 letters.
    /// https://leetcode.com/problems/check-if-the-sentence-is-pangram/
    /// Pattern: Hash existence check - verify all alphabet letters present
    /// </summary>
    [Theory]
    [InlineData("thequickbrownfoxjumpsoverthelazydog", true)]
    [InlineData("leetcode", false)]
    [InlineData("aaaaaaaaaa", false)]
    [InlineData("abcdefghijklmnopqrstuvwxyzaabbcc", true)]
    public void CheckIfPangram_WithVariousInputs_ReturnsExpected(string sentence, bool expected)
    {
        var result = CheckForExistence.CheckIfPangram(sentence);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests MissingNumber finding the missing number in range [0, n].
    /// https://leetcode.com/problems/missing-number/description/
    /// Pattern: Hash existence check - find missing number in sequence
    /// </summary>
    [Theory]
    [InlineData(new[] { 3, 0, 1 }, 2)]
    [InlineData(new[] { 0, 1 }, 2)]
    [InlineData(new[] { 1, 2, 3 }, 0)]
    [InlineData(new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
    [InlineData(new[] { 0 }, 1)]
    public void MissingNumber_WithVariousInputs_ReturnsExpected(int[] nums, int expected)
    {
        var result = CheckForExistence.MissingNumber(nums);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests CountElements counting elements where x+1 exists in array.
    /// https://leetcode.com/problems/counting-elements/description/
    /// Pattern: Hash existence check - count elements with successor
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 2)]
    [InlineData(new[] { 1, 1, 3, 3, 5, 5, 7, 7 }, 0)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 4)]
    [InlineData(new[] { 1, 3, 5, 7 }, 0)]
    [InlineData(new[] { 1, 1, 2, 2 }, 2)]
    [InlineData(new[] { -1, 0, 1, 2 }, 3)]
    [InlineData(new[] { 5 }, 0)]
    public void CountElements_WithVariousInputs_ReturnsExpected(int[] arr, int expected)
    {
        var result = CheckForExistence.CountElements(arr);

        Assert.Equal(expected, result);
    }
}
