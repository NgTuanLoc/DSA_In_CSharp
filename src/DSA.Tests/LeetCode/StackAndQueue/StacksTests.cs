using DSA.LeetCode.StackAndQueue;

namespace DSA.Tests.LeetCode.StackAndQueue;

/// <summary>
/// Unit tests for Stack pattern implementations.
/// Stacks follow LIFO (Last In First Out) principle and are ideal for problems involving:
/// - Matching/balancing elements (parentheses, brackets)
/// - String manipulation with adjacency rules
/// - Backtracking operations
/// - Expression evaluation
/// Time Complexity: Usually O(n), Space Complexity: O(n) for stack storage.
/// </summary>
public class StacksTests
{
    #region IsValid Tests
    /// <summary>
    /// Test: Verify valid parentheses matching.
    /// Pattern: Use stack to track opening brackets, match with closing brackets in LIFO order.
    /// LeetCode: https://leetcode.com/problems/valid-parentheses/
    /// Algorithm:
    /// 1. Push opening brackets onto stack
    /// 2. For closing brackets, check if top of stack matches
    /// 3. Stack should be empty at end for valid string
    /// </summary>
    [Theory]
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("([])", true)]
    [InlineData("{[]}", true)]
    [InlineData("(]", false)]
    [InlineData("([)]", false)]
    [InlineData("{", false)]
    [InlineData("}", false)]
    [InlineData("((", false)]
    [InlineData("))", false)]
    [InlineData("(())", true)]
    [InlineData("((()))", true)]
    [InlineData("(){}}{", false)]
    public void IsValid_WithVariousParentheses_ReturnsCorrectResult(string input, bool expected)
    {
        // Act
        var result = Stacks.IsValid(input);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region RemoveDuplicates Tests
    /// <summary>
    /// Test: Verify removal of all adjacent duplicate characters.
    /// Pattern: Use stack to track characters, pop when duplicate found.
    /// LeetCode: https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/
    /// Algorithm:
    /// 1. Iterate through string
    /// 2. If current char equals top of stack, pop (remove duplicate)
    /// 3. Otherwise, push current char
    /// 4. Build result from stack in reverse order
    /// </summary>
    [Theory]
    [InlineData("abbaca", "ca")]
    [InlineData("azxxzy", "ay")]
    [InlineData("abccba", "")]
    [InlineData("a", "a")]
    [InlineData("aa", "")]
    [InlineData("abc", "abc")]
    [InlineData("aabbcc", "")]
    [InlineData("aabbc", "c")]
    [InlineData("abba", "")]
    [InlineData("abccde", "abde")]
    public void RemoveDuplicates_WithVariousStrings_RemovesCorrectly(string input, string expected)
    {
        // Act
        var result = Stacks.RemoveDuplicates(input);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region BackspaceCompare Tests
    /// <summary>
    /// Test: Verify string comparison after applying backspace operations.
    /// Pattern: Use stack to simulate text editor, '#' triggers pop operation.
    /// LeetCode: https://leetcode.com/problems/backspace-string-compare/
    /// Algorithm:
    /// 1. Process each string with stack
    /// 2. Push characters, pop on backspace '#'
    /// 3. Compare final stack contents
    /// </summary>
    [Theory]
    [InlineData("ab#c", "ad#c", true)]
    [InlineData("ab##", "c#d#", true)]
    [InlineData("a#c", "b", false)]
    [InlineData("a##c", "#a#c", true)]
    [InlineData("abc#", "ab", true)]
    [InlineData("abc", "abc", true)]
    [InlineData("abc", "def", false)]
    [InlineData("#", "", true)]
    [InlineData("##", "", true)]
    [InlineData("a#b#c#", "", true)]
    [InlineData("bxj##tw", "bxo#j##tw", true)]
    public void BackspaceCompare_WithVariousStrings_ComparesCorrectly(string s, string t, bool expected)
    {
        // Act
        var result = Stacks.BackspaceCompare(s, t);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region SimplifyPath Tests
    /// <summary>
    /// Test: Verify Unix path simplification.
    /// Pattern: Use stack to track valid directory names, handle '..' for parent directory.
    /// LeetCode: https://leetcode.com/problems/simplify-path/
    /// Algorithm:
    /// 1. Split path by '/'
    /// 2. Skip empty strings and '.'
    /// 3. Pop on '..' (go to parent)
    /// 4. Push valid directory names
    /// 5. Build canonical path from stack
    /// </summary>
    [Theory]
    [InlineData("/home/", "/home")]
    [InlineData("/home//foo/", "/home/foo")]
    [InlineData("/home/user/Documents/../Pictures", "/home/user/Pictures")]
    [InlineData("/../", "/")]
    [InlineData("/a/./b/../../c/", "/c")]
    [InlineData("/a//b////c/d//././/..", "/a/b/c")]
    [InlineData("/", "/")]
    [InlineData("/...", "/...")]
    [InlineData("/a/b/c", "/a/b/c")]
    [InlineData("/a/../../b", "/b")]
    public void SimplifyPath_WithVariousPaths_SimplifiesCorrectly(string input, string expected)
    {
        // Act
        var result = Stacks.SimplifyPath(input);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region MakeGood Tests
    /// <summary>
    /// Test: Verify removal of adjacent characters with same letter but different case.
    /// Pattern: Use stack to track characters, pop when case-insensitive match found.
    /// LeetCode: https://leetcode.com/problems/make-the-string-great/
    /// Algorithm:
    /// 1. Iterate through string
    /// 2. If current char and top of stack differ by 32 (ASCII case difference), pop
    /// 3. Otherwise, push current char
    /// 4. Build result from stack
    /// Note: ASCII difference between 'a' and 'A' is 32
    /// </summary>
    [Theory]
    [InlineData("leEeetcode", "leetcode")]
    [InlineData("abBAcC", "")]
    [InlineData("s", "s")]
    [InlineData("Pp", "")]
    [InlineData("abcd", "abcd")]
    [InlineData("aAbBcC", "")]
    [InlineData("AaBbCcDd", "")]
    [InlineData("abcCBA", "")]
    [InlineData("mC", "mC")]
    [InlineData("RrR", "R")]
    public void MakeGood_WithVariousStrings_MakesGoodCorrectly(string input, string expected)
    {
        // Act
        var result = Stacks.MakeGood(input);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion
}
