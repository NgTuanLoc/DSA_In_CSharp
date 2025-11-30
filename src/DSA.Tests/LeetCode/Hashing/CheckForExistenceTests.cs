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
    [Fact]
    public void RepeatedCharacter_WithDuplicates_ReturnsFirstRepeated()
    {
        var result = CheckForExistence.RepeatedCharacter("abccbaacz");

        Assert.Equal('c', result);
    }

    /// <summary>
    /// Tests RepeatedCharacter with immediate duplicate.
    /// </summary>
    [Fact]
    public void RepeatedCharacter_WithImmediateDuplicate_ReturnsCharacter()
    {
        var result = CheckForExistence.RepeatedCharacter("abba");

        Assert.Equal('b', result);
    }

    /// <summary>
    /// Tests RepeatedCharacter with single character repeated.
    /// </summary>
    [Fact]
    public void RepeatedCharacter_WithSingleRepeated_ReturnsCharacter()
    {
        var result = CheckForExistence.RepeatedCharacter("aa");

        Assert.Equal('a', result);
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
    [Fact]
    public void CheckIfPangram_WithAllLetters_ReturnsTrue()
    {
        var result = CheckForExistence.CheckIfPangram("thequickbrownfoxjumpsoverthelazydog");

        Assert.True(result);
    }

    /// <summary>
    /// Tests CheckIfPangram with missing letters.
    /// </summary>
    [Fact]
    public void CheckIfPangram_WithMissingLetters_ReturnsFalse()
    {
        var result = CheckForExistence.CheckIfPangram("leetcode");

        Assert.False(result);
    }

    /// <summary>
    /// Tests CheckIfPangram with repeated letters but missing some.
    /// </summary>
    [Fact]
    public void CheckIfPangram_WithRepeatedButMissing_ReturnsFalse()
    {
        var result = CheckForExistence.CheckIfPangram("aaaaaaaaaa");

        Assert.False(result);
    }

    /// <summary>
    /// Tests CheckIfPangram with pangram containing duplicates.
    /// </summary>
    [Fact]
    public void CheckIfPangram_WithDuplicatesButAllLetters_ReturnsTrue()
    {
        var result = CheckForExistence.CheckIfPangram("abcdefghijklmnopqrstuvwxyzaabbcc");

        Assert.True(result);
    }

    /// <summary>
    /// Tests MissingNumber finding the missing number in range [0, n].
    /// https://leetcode.com/problems/missing-number/description/
    /// Pattern: Hash existence check - find missing number in sequence
    /// </summary>
    [Fact]
    public void MissingNumber_WithMissingInMiddle_ReturnsNumber()
    {
        var result = CheckForExistence.MissingNumber([3, 0, 1]);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests MissingNumber with missing at end.
    /// </summary>
    [Fact]
    public void MissingNumber_WithMissingAtEnd_ReturnsNumber()
    {
        var result = CheckForExistence.MissingNumber([0, 1]);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests MissingNumber with missing at start.
    /// </summary>
    [Fact]
    public void MissingNumber_WithMissingAtStart_ReturnsZero()
    {
        var result = CheckForExistence.MissingNumber([1, 2, 3]);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests MissingNumber with large array.
    /// </summary>
    [Fact]
    public void MissingNumber_WithLargeArray_ReturnsCorrectNumber()
    {
        var result = CheckForExistence.MissingNumber([9, 6, 4, 2, 3, 5, 7, 0, 1]);

        Assert.Equal(8, result);
    }

    /// <summary>
    /// Tests MissingNumber with single element.
    /// </summary>
    [Fact]
    public void MissingNumber_WithSingleElement_ReturnsCorrectNumber()
    {
        var result = CheckForExistence.MissingNumber([0]);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests CountElements counting elements where x+1 exists in array.
    /// https://leetcode.com/problems/counting-elements/description/
    /// Pattern: Hash existence check - count elements with successor
    /// </summary>
    [Fact]
    public void CountElements_WithValidSuccessors_ReturnsCount()
    {
        var result = CheckForExistence.CountElements([1, 2, 3]);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests CountElements with duplicates counting separately.
    /// </summary>
    [Fact]
    public void CountElements_WithDuplicates_CountsEachOccurrence()
    {
        var result = CheckForExistence.CountElements([1, 1, 3, 3, 5, 5, 7, 7]);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests CountElements with consecutive sequences.
    /// </summary>
    [Fact]
    public void CountElements_WithConsecutiveSequence_ReturnsAllButLast()
    {
        var result = CheckForExistence.CountElements([1, 2, 3, 4, 5]);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests CountElements with no valid successors.
    /// </summary>
    [Fact]
    public void CountElements_WithNoSuccessors_ReturnsZero()
    {
        var result = CheckForExistence.CountElements([1, 3, 5, 7]);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests CountElements with mixed scenarios.
    /// </summary>
    [Fact]
    public void CountElements_WithMixedScenarios_ReturnsCorrectCount()
    {
        var result = CheckForExistence.CountElements([1, 1, 2, 2]);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests CountElements with negative numbers.
    /// </summary>
    [Fact]
    public void CountElements_WithNegativeNumbers_ReturnsCorrectCount()
    {
        var result = CheckForExistence.CountElements([-1, 0, 1, 2]);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests CountElements with single element.
    /// </summary>
    [Fact]
    public void CountElements_WithSingleElement_ReturnsZero()
    {
        var result = CheckForExistence.CountElements([5]);

        Assert.Equal(0, result);
    }
}
