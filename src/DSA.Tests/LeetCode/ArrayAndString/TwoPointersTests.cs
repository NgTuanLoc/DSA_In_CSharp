using DSA.LeetCode.ArrayAndString;

namespace DSA.Tests.LeetCode.ArrayAndString;

/// <summary>
/// Unit tests for Two Pointers pattern implementations.
/// Two Pointers technique uses two pointers to iterate through data structure in tandem until one or both pointers hit a condition.
/// Common use cases: finding pairs with target sum, merging sorted arrays, palindrome checking, and array manipulation.
/// </summary>
public class TwoPointersTests
{
    #region CheckPalindrome Tests
    /// <summary>
    /// Test: Verify that a simple palindrome string "racecar" is correctly identified as a palindrome.
    /// Pattern: Two pointers moving from both ends towards the center.
    /// </summary>
    [Theory]
    [InlineData("racecar", true)]
    [InlineData("hello", false)]
    [InlineData("a", true)]
    [InlineData("abba", true)]
    public void CheckPalindrome_WithVariousInputs_ReturnsExpected(string input, bool expected)
    {
        // Act
        var result = TwoPointers.CheckPalindrome(input);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region CheckForTarget Tests
    /// <summary>
    /// Test: Verify that two numbers summing to target are found in a sorted array.
    /// Pattern: Two pointers approach on sorted array - move left pointer up if sum too small, right pointer down if sum too large.
    /// </summary>
    [Fact]
    public void CheckForTarget_WithValidPairInSortedArray_ReturnsTrue()
    {
        // Arrange
        var list = new List<int> { 1, 2, 4, 6, 8, 9, 14, 15 };
        var target = 13;

        // Act
        var result = TwoPointers.CheckForTarget(list, target);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Test: Verify that method returns false when no pair sums to target.
    /// </summary>
    [Fact]
    public void CheckForTarget_WithNoValidPair_ReturnsFalse()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var target = 100;

        // Act
        var result = TwoPointers.CheckForTarget(list, target);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Test: Verify correct behavior with minimum valid input (two elements).
    /// </summary>
    [Fact]
    public void CheckForTarget_WithTwoElements_WorksCorrectly()
    {
        // Arrange
        var list = new List<int> { 5, 10 };
        var target = 15;

        // Act
        var result = TwoPointers.CheckForTarget(list, target);

        // Assert
        Assert.True(result);
    }
    #endregion

    #region CombineTwoSortedList Tests
    /// <summary>
    /// Test: Verify that two sorted lists are correctly merged into one sorted list.
    /// Pattern: Two pointers on two arrays, comparing and selecting smaller element at each step.
    /// </summary>
    [Fact]
    public void CombineTwoSortedList_WithTwoValidLists_ReturnsMergedSortedList()
    {
        // Arrange
        var list1 = new List<int> { 1, 4, 7, 20 };
        var list2 = new List<int> { 3, 5, 6 };
        var expected = new List<int> { 1, 3, 4, 5, 6, 7, 20 };

        // Act
        var result = TwoPointers.CombineTwoSortedList(list1, list2);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior when one list is empty.
    /// Edge case: One empty input.
    /// </summary>
    [Fact]
    public void CombineTwoSortedList_WithOneEmptyList_ReturnsOtherList()
    {
        // Arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int>();
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var result = TwoPointers.CombineTwoSortedList(list1, list2);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct merging when lists have no overlapping ranges.
    /// </summary>
    [Fact]
    public void CombineTwoSortedList_WithNonOverlappingLists_ReturnsCombinedList()
    {
        // Arrange
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 10, 11, 12 };
        var expected = new List<int> { 1, 2, 3, 10, 11, 12 };

        // Act
        var result = TwoPointers.CombineTwoSortedList(list1, list2);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region IsSubSequence Tests
    /// <summary>
    /// Test: Verify that a valid subsequence is correctly identified.
    /// Pattern: Two pointers moving through both strings, matching characters in order.
    /// LeetCode: https://leetcode.com/problems/is-subsequence/
    /// </summary>
    [Theory]
    [InlineData("abc", "ahbgdc", true)]
    [InlineData("axc", "ahbgdc", false)]
    [InlineData("", "ahbgdc", true)]
    public void IsSubSequence_WithVariousInputs_ReturnsExpected(string s, string t, bool expected)
    {
        // Act
        var result = TwoPointers.IsSubSequence(s, t);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region ReverseString Tests
    /// <summary>
    /// Test: Verify that a character array is correctly reversed in-place.
    /// Pattern: Two pointers at both ends, swap and move towards center.
    /// LeetCode: https://leetcode.com/problems/reverse-string/
    /// </summary>
    [Fact]
    public void ReverseString_WithStandardArray_ReversesInPlace()
    {
        // Arrange
        var input = new char[] { 'h', 'e', 'l', 'l', 'o' };
        var expected = new char[] { 'o', 'l', 'l', 'e', 'h' };

        // Act
        TwoPointers.ReverseString(input);

        // Assert
        Assert.Equal(expected, input);
    }

    /// <summary>
    /// Test: Verify correct behavior with even-length array.
    /// </summary>
    [Fact]
    public void ReverseString_WithEvenLengthArray_ReversesCorrectly()
    {
        // Arrange
        var input = new char[] { 'H', 'a', 'n', 'n', 'a', 'h' };
        var expected = new char[] { 'h', 'a', 'n', 'n', 'a', 'H' };

        // Act
        TwoPointers.ReverseString(input);

        // Assert
        Assert.Equal(expected, input);
    }
    #endregion

    #region SortedSquares Tests
    /// <summary>
    /// Test: Verify that squares of sorted array (with negatives) are returned in sorted order.
    /// Pattern: Two pointers at both ends, comparing absolute values and filling result from right to left.
    /// LeetCode: https://leetcode.com/problems/squares-of-a-sorted-array/
    /// </summary>
    [Fact]
    public void SortedSquares_WithNegativeAndPositiveNumbers_ReturnsSortedSquares()
    {
        // Arrange
        var nums = new int[] { -4, -1, 0, 3, 10 };
        var expected = new int[] { 0, 1, 9, 16, 100 };

        // Act
        var result = TwoPointers.SortedSquares(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with all negative numbers.
    /// </summary>
    [Fact]
    public void SortedSquares_WithAllNegativeNumbers_ReturnsSortedSquares()
    {
        // Arrange
        var nums = new int[] { -7, -3, -1 };
        var expected = new int[] { 1, 9, 49 };

        // Act
        var result = TwoPointers.SortedSquares(nums);

        // Assert
        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Test: Verify correct behavior with all positive numbers.
    /// </summary>
    [Fact]
    public void SortedSquares_WithAllPositiveNumbers_ReturnsSortedSquares()
    {
        // Arrange
        var nums = new int[] { 1, 2, 3, 4 };
        var expected = new int[] { 1, 4, 9, 16 };

        // Act
        var result = TwoPointers.SortedSquares(nums);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region ReverseWords Tests
    /// <summary>
    /// Test: Verify that each word in a string is reversed while maintaining word order.
    /// LeetCode: https://leetcode.com/problems/reverse-words-in-a-string-iii/
    /// </summary>
    [Theory]
    [InlineData("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
    [InlineData("God", "doG")]
    public void ReverseWords_WithVariousInputs_ReturnsExpected(string input, string expected)
    {
        // Act
        var result = TwoPointers.ReverseWords(input);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region ReverseOnlyLetters Tests
    /// <summary>
    /// Test: Verify that only letters are reversed while non-letters stay in place.
    /// Pattern: Two pointers skip non-letter characters and swap only letters.
    /// LeetCode: https://leetcode.com/problems/reverse-only-letters/
    /// </summary>
    [Theory]
    [InlineData("a-bC-dEf-ghIj", "j-Ih-gfE-dCba")]
    [InlineData("Test", "tseT")]
    public void ReverseOnlyLetters_WithVariousInputs_ReturnsExpected(string input, string expected)
    {
        // Act
        var result = TwoPointers.ReverseOnlyLetters(input);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region GetCommon Tests
    /// <summary>
    /// Test: Verify that minimum common value is found in two sorted arrays.
    /// Pattern: Two pointers on two sorted arrays, advancing the pointer with smaller value.
    /// LeetCode: https://leetcode.com/problems/minimum-common-value/
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 3 }, new[] { 2, 4 }, 2)]
    [InlineData(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, -1)]
    public void GetCommon_WithVariousInputs_ReturnsExpected(int[] nums1, int[] nums2, int expected)
    {
        // Act
        var result = TwoPointers.GetCommon(nums1, nums2);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region MoveZeroes Tests
    /// <summary>
    /// Test: Verify that all zeros are moved to the end while maintaining relative order of non-zeros.
    /// Pattern: One pointer for non-zero position, another scanning through array.
    /// LeetCode: https://leetcode.com/problems/move-zeroes/
    /// </summary>
    [Fact]
    public void MoveZeroes_WithMixedNumbers_MovesZeroesToEnd()
    {
        // Arrange
        var nums = new int[] { 0, 1, 0, 3, 12 };
        var expected = new int[] { 1, 3, 12, 0, 0 };

        // Act
        TwoPointers.MoveZeroes(nums);

        // Assert
        Assert.Equal(expected, nums);
    }

    /// <summary>
    /// Test: Verify correct behavior when no zeros present.
    /// </summary>
    [Fact]
    public void MoveZeroes_WithNoZeros_RemainsUnchanged()
    {
        // Arrange
        var nums = new int[] { 1, 2, 3, 4 };
        var expected = new int[] { 1, 2, 3, 4 };

        // Act
        TwoPointers.MoveZeroes(nums);

        // Assert
        Assert.Equal(expected, nums);
    }
    #endregion

    #region ReversePrefix Tests
    /// <summary>
    /// Test: Verify that prefix up to first occurrence of character is reversed.
    /// Pattern: Find target character, then use two pointers to reverse prefix.
    /// LeetCode: https://leetcode.com/problems/reverse-prefix-of-word/
    /// </summary>
    [Theory]
    [InlineData("abcdefd", 'd', "dcbaefd")]
    [InlineData("abcd", 'z', "abcd")]
    [InlineData("abcd", 'a', "abcd")]
    public void ReversePrefix_WithVariousInputs_ReturnsExpected(string word, char ch, string expected)
    {
        // Act
        var result = TwoPointers.ReversePrefix(word, ch);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion
}
