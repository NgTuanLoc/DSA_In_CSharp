using DSA.LeetCode.Hashing;

namespace DSA.Tests.LeetCode.Hashing;

public class PracticeTests
{
    #region Group Anagrams and String Patterns

    /// <summary>
    /// Tests GroupAnagrams grouping strings that are anagrams.
    /// https://leetcode.com/problems/group-anagrams/
    /// Pattern: Hash grouping - sort characters as key
    /// </summary>
    [Fact]
    public void GroupAnagrams_WithMultipleGroups_ReturnsGroupedLists()
    {
        var result = Practice.GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]);

        Assert.Equal(3, result.Count);
        Assert.Contains(result, group => group.Count == 3 && group.Contains("eat") && group.Contains("tea") && group.Contains("ate"));
        Assert.Contains(result, group => group.Count == 2 && group.Contains("tan") && group.Contains("nat"));
        Assert.Contains(result, group => group.Count == 1 && group.Contains("bat"));
    }

    /// <summary>
    /// Tests GroupAnagrams with empty string.
    /// </summary>
    [Fact]
    public void GroupAnagrams_WithEmptyString_ReturnsSingleGroup()
    {
        var result = Practice.GroupAnagrams([""]);

        Assert.Single(result);
        Assert.Single(result[0]);
    }

    /// <summary>
    /// Tests GroupAnagrams with single character strings.
    /// </summary>
    [Fact]
    public void GroupAnagrams_WithSingleChars_ReturnsSingleGroup()
    {
        var result = Practice.GroupAnagrams(["a"]);

        Assert.Single(result);
    }

    #endregion

    #region Card and Pair Problems

    /// <summary>
    /// Tests MinimumCardPickup finding minimum consecutive cards with matching pair.
    /// https://leetcode.com/problems/minimum-consecutive-cards-to-pick-up/description/
    /// Pattern: Hash tracking - store last seen index
    /// </summary>
    [Fact]
    public void MinimumCardPickup_WithMatchingPairs_ReturnsMinDistance()
    {
        var result = Practice.MinimumCardPickup([3, 4, 2, 3, 4, 7]);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests MinimumCardPickup with no matching pairs.
    /// </summary>
    [Fact]
    public void MinimumCardPickup_WithNoMatching_ReturnsMinusOne()
    {
        var result = Practice.MinimumCardPickup([1, 2, 3, 4, 5]);

        Assert.Equal(-1, result);
    }

    /// <summary>
    /// Tests MinimumCardPickup with immediate pair.
    /// </summary>
    [Fact]
    public void MinimumCardPickup_WithImmediatePair_ReturnsTwo()
    {
        var result = Practice.MinimumCardPickup([1, 1]);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests MinimumCardPickup with multiple pairs.
    /// </summary>
    [Fact]
    public void MinimumCardPickup_WithMultiplePairs_ReturnsSmallest()
    {
        var result = Practice.MinimumCardPickup([1, 2, 6, 2, 1]);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests EqualPairs counting equal row and column pairs in grid.
    /// https://leetcode.com/problems/equal-row-and-column-pairs/
    /// Pattern: Hash comparison - serialize rows and columns
    /// </summary>
    [Fact]
    public void EqualPairs_WithMatchingPairs_ReturnsCount()
    {
        var result = Practice.EqualPairs([[3, 2, 1], [1, 7, 6], [2, 7, 7]]);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests EqualPairs with multiple matches.
    /// </summary>
    [Fact]
    public void EqualPairs_WithMultipleMatches_ReturnsCorrectCount()
    {
        var result = Practice.EqualPairs([[3, 1, 2, 2], [1, 4, 4, 5], [2, 4, 2, 2], [2, 4, 2, 2]]);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests EqualPairs with identity matrix.
    /// </summary>
    [Fact]
    public void EqualPairs_WithIdentityMatrix_ReturnsN()
    {
        var result = Practice.EqualPairs([[11, 1], [1, 11]]);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests EqualPairs with all same values.
    /// </summary>
    [Fact]
    public void EqualPairs_WithAllSame_ReturnsNSquared()
    {
        var result = Practice.EqualPairs([[1, 1], [1, 1]]);

        Assert.Equal(4, result);
    }

    #endregion

    #region String Construction and Character Matching

    /// <summary>
    /// Tests CanConstruct checking if ransom note can be built from magazine.
    /// https://leetcode.com/problems/ransom-note/
    /// Pattern: Hash counting - check character availability
    /// </summary>
    [Fact]
    public void CanConstruct_WithSufficientChars_ReturnsTrue()
    {
        var result = Practice.CanConstruct("aa", "aab");

        Assert.True(result);
    }

    /// <summary>
    /// Tests CanConstruct with insufficient characters.
    /// </summary>
    [Fact]
    public void CanConstruct_WithInsufficientChars_ReturnsFalse()
    {
        var result = Practice.CanConstruct("aa", "ab");

        Assert.False(result);
    }

    /// <summary>
    /// Tests CanConstruct with different characters.
    /// </summary>
    [Fact]
    public void CanConstruct_WithDifferentChars_ReturnsFalse()
    {
        var result = Practice.CanConstruct("a", "b");

        Assert.False(result);
    }

    /// <summary>
    /// Tests NumJewelsInStones counting jewels in stones.
    /// https://leetcode.com/problems/jewels-and-stones/description/
    /// Pattern: Hash existence - check membership
    /// </summary>
    [Fact]
    public void NumJewelsInStones_WithMultipleMatches_ReturnsCount()
    {
        var result = Practice.NumJewelsInStones("aA", "aAAbbbb");

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests NumJewelsInStones with no matches.
    /// </summary>
    [Fact]
    public void NumJewelsInStones_WithNoMatches_ReturnsZero()
    {
        var result = Practice.NumJewelsInStones("z", "ZZ");

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests NumJewelsInStones with all matching.
    /// </summary>
    [Fact]
    public void NumJewelsInStones_WithAllMatching_ReturnsAllCount()
    {
        var result = Practice.NumJewelsInStones("abc", "aabbcc");

        Assert.Equal(6, result);
    }

    /// <summary>
    /// Tests LengthOfLongestSubstring finding longest substring without repeating chars.
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
    /// Pattern: Hash with sliding window - track last seen index
    /// </summary>
    [Fact]
    public void LengthOfLongestSubstring_WithRepeats_ReturnsMaxLength()
    {
        var result = Practice.LengthOfLongestSubstring("abcabcbb");

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests LengthOfLongestSubstring with all same characters.
    /// </summary>
    [Fact]
    public void LengthOfLongestSubstring_WithAllSame_ReturnsOne()
    {
        var result = Practice.LengthOfLongestSubstring("bbbbb");

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests LengthOfLongestSubstring with no repeats.
    /// </summary>
    [Fact]
    public void LengthOfLongestSubstring_WithNoRepeats_ReturnsFullLength()
    {
        var result = Practice.LengthOfLongestSubstring("pwwkew");

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests LengthOfLongestSubstring with two characters.
    /// </summary>
    [Fact]
    public void LengthOfLongestSubstring_WithTwoChars_ReturnsTwo()
    {
        var result = Practice.LengthOfLongestSubstring("au");

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests LengthOfLongestSubstring with complex pattern.
    /// </summary>
    [Fact]
    public void LengthOfLongestSubstring_WithComplexPattern_ReturnsCorrectLength()
    {
        var result = Practice.LengthOfLongestSubstring("dvdf");

        Assert.Equal(3, result);
    }

    #endregion

    #region Duplicate and Existence Checks

    /// <summary>
    /// Tests ContainsDuplicate checking for duplicate elements.
    /// https://leetcode.com/problems/contains-duplicate/description/
    /// Pattern: Hash existence - detect duplicates
    /// </summary>
    [Fact]
    public void ContainsDuplicate_WithDuplicates_ReturnsTrue()
    {
        var result = Practice.ContainsDuplicate([1, 2, 3, 1]);

        Assert.True(result);
    }

    /// <summary>
    /// Tests ContainsDuplicate with no duplicates.
    /// </summary>
    [Fact]
    public void ContainsDuplicate_WithNoDuplicates_ReturnsFalse()
    {
        var result = Practice.ContainsDuplicate([1, 2, 3, 4]);

        Assert.False(result);
    }

    /// <summary>
    /// Tests ContainsDuplicate with multiple duplicates.
    /// </summary>
    [Fact]
    public void ContainsDuplicate_WithMultipleDuplicates_ReturnsTrue()
    {
        var result = Practice.ContainsDuplicate([1, 1, 1, 3, 3, 4, 3, 2, 4, 2]);

        Assert.True(result);
    }

    /// <summary>
    /// Tests DestCity finding destination city with no outgoing path.
    /// https://leetcode.com/problems/destination-city/description/
    /// Pattern: Hash tracking - find city not in source list
    /// </summary>
    [Fact]
    public void DestCity_WithMultiplePaths_ReturnsDestination()
    {
        var result = Practice.DestCity([["London", "New York"], ["New York", "Lima"], ["Lima", "Sao Paulo"]]);

        Assert.Equal("Sao Paulo", result);
    }

    /// <summary>
    /// Tests DestCity with complex routing.
    /// </summary>
    [Fact]
    public void DestCity_WithComplexRouting_ReturnsCorrectDest()
    {
        var result = Practice.DestCity([["B", "C"], ["D", "B"], ["C", "A"]]);

        Assert.Equal("A", result);
    }

    /// <summary>
    /// Tests DestCity with single path.
    /// </summary>
    [Fact]
    public void DestCity_WithSinglePath_ReturnsDestination()
    {
        var result = Practice.DestCity([["A", "Z"]]);

        Assert.Equal("Z", result);
    }

    /// <summary>
    /// Tests IsPathCrossing detecting if path crosses itself.
    /// https://leetcode.com/problems/path-crossing/
    /// Pattern: Hash tracking - store visited coordinates
    /// </summary>
    [Fact]
    public void IsPathCrossing_WithNoCrossing_ReturnsFalse()
    {
        var result = Practice.IsPathCrossing("NES");

        Assert.False(result);
    }

    /// <summary>
    /// Tests IsPathCrossing with crossing path.
    /// </summary>
    [Fact]
    public void IsPathCrossing_WithCrossing_ReturnsTrue()
    {
        var result = Practice.IsPathCrossing("NESWW");

        Assert.True(result);
    }

    /// <summary>
    /// Tests IsPathCrossing returning to origin.
    /// </summary>
    [Fact]
    public void IsPathCrossing_ReturningToOrigin_ReturnsTrue()
    {
        var result = Practice.IsPathCrossing("NSEW");

        Assert.True(result);
    }

    #endregion

    #region Counting and Frequency

    /// <summary>
    /// Tests SumOfUnique summing elements that appear exactly once.
    /// https://leetcode.com/problems/sum-of-unique-elements/
    /// Pattern: Hash counting - filter by frequency
    /// </summary>
    [Fact]
    public void SumOfUnique_WithUniqueElements_ReturnsSum()
    {
        var result = Practice.SumOfUnique([1, 2, 3, 2]);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests SumOfUnique with no unique elements.
    /// </summary>
    [Fact]
    public void SumOfUnique_WithNoUnique_ReturnsZero()
    {
        var result = Practice.SumOfUnique([1, 1, 1, 1, 1]);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests SumOfUnique with all unique.
    /// </summary>
    [Fact]
    public void SumOfUnique_WithAllUnique_ReturnsTotalSum()
    {
        var result = Practice.SumOfUnique([1, 2, 3, 4, 5]);

        Assert.Equal(15, result);
    }

    /// <summary>
    /// Tests MaxFrequencyElements counting elements with max frequency.
    /// https://leetcode.com/problems/count-elements-with-maximum-frequency/description/
    /// Pattern: Hash counting - find and count max frequency
    /// </summary>
    [Fact]
    public void MaxFrequencyElements_WithMultipleMaxFreq_ReturnsTotal()
    {
        var result = Practice.MaxFrequencyElements([1, 2, 2, 3, 1, 4]);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests MaxFrequencyElements with all unique.
    /// </summary>
    [Fact]
    public void MaxFrequencyElements_WithAllUnique_ReturnsCount()
    {
        var result = Practice.MaxFrequencyElements([1, 2, 3, 4, 5]);

        Assert.Equal(5, result);
    }

    /// <summary>
    /// Tests FindLucky finding largest lucky integer (value equals frequency).
    /// https://leetcode.com/problems/find-lucky-integer-in-an-array/description/
    /// Pattern: Hash counting - match value with frequency
    /// </summary>
    [Fact]
    public void FindLucky_WithLuckyNumber_ReturnsLargest()
    {
        var result = Practice.FindLucky([2, 2, 3, 4]);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests FindLucky with multiple lucky numbers.
    /// </summary>
    [Fact]
    public void FindLucky_WithMultipleLucky_ReturnsLargest()
    {
        var result = Practice.FindLucky([1, 2, 2, 3, 3, 3]);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests FindLucky with no lucky numbers.
    /// </summary>
    [Fact]
    public void FindLucky_WithNoLucky_ReturnsMinusOne()
    {
        var result = Practice.FindLucky([2, 2, 2, 3, 3]);

        Assert.Equal(-1, result);
    }

    /// <summary>
    /// Tests UniqueOccurrences checking if all frequencies are unique.
    /// https://leetcode.com/problems/unique-number-of-occurrences/description/
    /// Pattern: Hash counting - verify frequency uniqueness
    /// </summary>
    [Fact]
    public void UniqueOccurrences_WithUniqueFreqs_ReturnsTrue()
    {
        var result = Practice.UniqueOccurrences([1, 2, 2, 1, 1, 3]);

        Assert.True(result);
    }

    /// <summary>
    /// Tests UniqueOccurrences with duplicate frequencies.
    /// </summary>
    [Fact]
    public void UniqueOccurrences_WithDuplicateFreqs_ReturnsFalse()
    {
        var result = Practice.UniqueOccurrences([1, 2]);

        Assert.False(result);
    }

    /// <summary>
    /// Tests UniqueOccurrences with negative numbers.
    /// </summary>
    [Fact]
    public void UniqueOccurrences_WithNegatives_ReturnsTrue()
    {
        var result = Practice.UniqueOccurrences([-3, 0, 1, -3, 1, 1, 1, -3, 10, 0]);

        Assert.True(result);
    }

    /// <summary>
    /// Tests FrequencySort sorting characters by frequency.
    /// https://leetcode.com/problems/sort-characters-by-frequency/description/
    /// Pattern: Hash counting with sorting
    /// </summary>
    [Fact]
    public void FrequencySort_WithMixedFrequencies_ReturnsSorted()
    {
        var result = Practice.FrequencySort("tree");

        // "eert" or "eetr" are valid
        Assert.StartsWith("ee", result);
        Assert.Equal(4, result.Length);
    }

    /// <summary>
    /// Tests FrequencySort with equal frequencies.
    /// </summary>
    [Fact]
    public void FrequencySort_WithEqualFreqs_ReturnsValidOrder()
    {
        var result = Practice.FrequencySort("cccaaa");

        Assert.Equal(6, result.Length);
        Assert.True(result == "cccaaa" || result == "aaaccc");
    }

    /// <summary>
    /// Tests FrequencySort with case sensitivity.
    /// </summary>
    [Fact]
    public void FrequencySort_WithCaseSensitive_ReturnsSorted()
    {
        var result = Practice.FrequencySort("Aabb");

        Assert.Equal(4, result.Length);
        Assert.True(result.StartsWith("bb") || result.StartsWith("AA"));
    }

    #endregion

    #region Subarray Problems

    /// <summary>
    /// Tests MaxSubArrayLength finding longest subarray with at most k frequency.
    /// https://leetcode.com/problems/length-of-longest-subarray-with-at-most-k-frequency/description/
    /// Pattern: Hash counting with sliding window
    /// </summary>
    [Fact]
    public void MaxSubArrayLength_WithFrequencyLimit_ReturnsMaxLength()
    {
        var result = Practice.MaxSubArrayLength([1, 2, 3, 1, 2, 3, 1, 2], 2);

        Assert.Equal(6, result);
    }

    /// <summary>
    /// Tests MaxSubArrayLength with k equals one.
    /// </summary>
    [Fact]
    public void MaxSubArrayLength_WithKOne_ReturnsLongestUnique()
    {
        var result = Practice.MaxSubArrayLength([1, 2, 1, 2, 1, 2, 1, 2], 1);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests MaxSubArrayLength with high k value.
    /// </summary>
    [Fact]
    public void MaxSubArrayLength_WithHighK_ReturnsFullLength()
    {
        var result = Practice.MaxSubArrayLength([5, 5, 5, 5, 5, 5, 5], 4);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests NumIdenticalPairs counting good pairs (i < j and nums[i] == nums[j]).
    /// https://leetcode.com/problems/number-of-good-pairs/description/
    /// Pattern: Hash counting - combinatorial counting
    /// </summary>
    [Fact]
    public void NumIdenticalPairs_WithMultiplePairs_ReturnsCount()
    {
        var result = Practice.NumIdenticalPairs([1, 2, 3, 1, 1, 3]);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests NumIdenticalPairs with all identical.
    /// </summary>
    [Fact]
    public void NumIdenticalPairs_WithAllIdentical_ReturnsCombination()
    {
        var result = Practice.NumIdenticalPairs([1, 1, 1, 1]);

        Assert.Equal(6, result);
    }

    /// <summary>
    /// Tests NumIdenticalPairs with all unique.
    /// </summary>
    [Fact]
    public void NumIdenticalPairs_WithAllUnique_ReturnsZero()
    {
        var result = Practice.NumIdenticalPairs([1, 2, 3]);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests NumSubArraysWithSum counting subarrays with binary sum.
    /// https://leetcode.com/problems/binary-subarrays-with-sum/description/
    /// Pattern: Hash with prefix sum
    /// </summary>
    [Fact]
    public void NumSubArraysWithSum_WithGoalTwo_ReturnsCount()
    {
        var result = Practice.NumSubArraysWithSum([1, 0, 1, 0, 1], 2);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests NumSubArraysWithSum with goal zero.
    /// </summary>
    [Fact]
    public void NumSubArraysWithSum_WithGoalZero_CountsZeroSubarrays()
    {
        var result = Practice.NumSubArraysWithSum([0, 0, 0, 0, 0], 0);

        Assert.Equal(15, result);
    }

    /// <summary>
    /// Tests MaximumUniqueSubArray finding max sum of unique subarray.
    /// https://leetcode.com/problems/maximum-erasure-value/
    /// Pattern: Hash with sliding window - track unique elements
    /// </summary>
    [Fact]
    public void MaximumUniqueSubArray_WithDuplicates_ReturnsMaxSum()
    {
        var result = Practice.MaximumUniqueSubArray([4, 2, 4, 5, 6]);

        Assert.Equal(17, result);
    }

    /// <summary>
    /// Tests MaximumUniqueSubArray with multiple duplicates.
    /// </summary>
    [Fact]
    public void MaximumUniqueSubArray_WithManyDuplicates_ReturnsCorrectMax()
    {
        var result = Practice.MaximumUniqueSubArray([5, 2, 1, 2, 5, 2, 1, 2, 5]);

        Assert.Equal(8, result);
    }

    /// <summary>
    /// Tests CheckInclusion checking if s1's permutation is substring of s2.
    /// https://leetcode.com/problems/permutation-in-string/description/
    /// Pattern: Hash comparison with sliding window
    /// </summary>
    [Fact]
    public void CheckInclusion_WithPermutation_ReturnsTrue()
    {
        var result = Practice.CheckInclusion("ab", "eidbaooo");

        Assert.True(result);
    }

    /// <summary>
    /// Tests CheckInclusion with no permutation.
    /// </summary>
    [Fact]
    public void CheckInclusion_WithNoPermutation_ReturnsFalse()
    {
        var result = Practice.CheckInclusion("ab", "eidboaoo");

        Assert.False(result);
    }

    /// <summary>
    /// Tests CheckInclusion with single character.
    /// </summary>
    [Fact]
    public void CheckInclusion_WithSingleChar_ReturnsTrue()
    {
        var result = Practice.CheckInclusion("a", "ab");

        Assert.True(result);
    }

    #endregion

    #region Pattern Matching and Transformation

    /// <summary>
    /// Tests IsIsomorphic checking if two strings are isomorphic.
    /// https://leetcode.com/problems/isomorphic-strings/description/
    /// Pattern: Hash mapping - bijective character mapping
    /// </summary>
    [Fact]
    public void IsIsomorphic_WithValidMapping_ReturnsTrue()
    {
        var result = Practice.IsIsomorphic("egg", "add");

        Assert.True(result);
    }

    /// <summary>
    /// Tests IsIsomorphic with invalid mapping.
    /// </summary>
    [Fact]
    public void IsIsomorphic_WithInvalidMapping_ReturnsFalse()
    {
        var result = Practice.IsIsomorphic("foo", "bar");

        Assert.False(result);
    }

    /// <summary>
    /// Tests IsIsomorphic with complex pattern.
    /// </summary>
    [Fact]
    public void IsIsomorphic_WithComplexPattern_ReturnsTrue()
    {
        var result = Practice.IsIsomorphic("paper", "title");

        Assert.True(result);
    }

    /// <summary>
    /// Tests IsIsomorphic with collision.
    /// </summary>
    [Fact]
    public void IsIsomorphic_WithCollision_ReturnsFalse()
    {
        var result = Practice.IsIsomorphic("badc", "baba");

        Assert.False(result);
    }

    /// <summary>
    /// Tests WordPattern matching pattern to words.
    /// https://leetcode.com/problems/word-pattern/description/
    /// Pattern: Hash mapping - bijective word mapping
    /// </summary>
    [Fact]
    public void WordPattern_WithValidPattern_ReturnsTrue()
    {
        var result = Practice.WordPattern("abba", "dog cat cat dog");

        Assert.True(result);
    }

    /// <summary>
    /// Tests WordPattern with invalid pattern.
    /// </summary>
    [Fact]
    public void WordPattern_WithInvalidPattern_ReturnsFalse()
    {
        var result = Practice.WordPattern("abba", "dog cat cat fish");

        Assert.False(result);
    }

    /// <summary>
    /// Tests WordPattern with length mismatch.
    /// </summary>
    [Fact]
    public void WordPattern_WithLengthMismatch_ReturnsFalse()
    {
        var result = Practice.WordPattern("aaaa", "dog cat cat dog");

        Assert.False(result);
    }

    /// <summary>
    /// Tests WordPattern with word count mismatch.
    /// </summary>
    [Fact]
    public void WordPattern_WithWordCountMismatch_ReturnsFalse()
    {
        var result = Practice.WordPattern("aaa", "aa aa aa aa");

        Assert.False(result);
    }

    /// <summary>
    /// Tests CustomSortString sorting by custom order.
    /// https://leetcode.com/problems/custom-sort-string/description/
    /// Pattern: Hash ordering - custom sort with frequency
    /// </summary>
    [Fact]
    public void CustomSortString_WithCustomOrder_ReturnsSorted()
    {
        var result = Practice.CustomSortString("cba", "abcd");

        Assert.Equal("cbad", result);
    }

    /// <summary>
    /// Tests CustomSortString with partial order.
    /// </summary>
    [Fact]
    public void CustomSortString_WithPartialOrder_ReturnsCorrectSort()
    {
        var result = Practice.CustomSortString("bcafg", "abcd");

        Assert.StartsWith("bca", result);
        Assert.Equal(4, result.Length);
    }

    /// <summary>
    /// Tests CloseStrings checking if strings can be made equal with operations.
    /// https://leetcode.com/problems/determine-if-two-strings-are-close/
    /// Pattern: Hash comparison - character sets and frequency patterns
    /// </summary>
    [Fact]
    public void CloseStrings_WithCloseStrings_ReturnsTrue()
    {
        var result = Practice.CloseStrings("abc", "bca");

        Assert.True(result);
    }

    /// <summary>
    /// Tests CloseStrings with different lengths.
    /// </summary>
    [Fact]
    public void CloseStrings_WithDifferentLengths_ReturnsFalse()
    {
        var result = Practice.CloseStrings("a", "aa");

        Assert.False(result);
    }

    /// <summary>
    /// Tests CloseStrings with different character sets.
    /// </summary>
    [Fact]
    public void CloseStrings_WithDifferentSets_ReturnsFalse()
    {
        var result = Practice.CloseStrings("aua", "bbz");

        Assert.False(result);
    }

    /// <summary>
    /// Tests CloseStrings with same frequency distribution.
    /// </summary>
    [Fact]
    public void CloseStrings_WithSameFreqDistribution_ReturnsTrue()
    {
        var result = Practice.CloseStrings("cabbba", "abbccc");

        Assert.True(result);
    }

    /// <summary>
    /// Tests CloseStrings2 (alternative implementation) with close strings.
    /// </summary>
    [Fact]
    public void CloseStrings2_WithCloseStrings_ReturnsTrue()
    {
        var result = Practice.CloseStrings2("abc", "bca");

        Assert.True(result);
    }

    /// <summary>
    /// Tests CloseStrings2 with different character sets.
    /// </summary>
    [Fact]
    public void CloseStrings2_WithDifferentSets_ReturnsFalse()
    {
        var result = Practice.CloseStrings2("aua", "bbz");

        Assert.False(result);
    }

    #endregion
}
