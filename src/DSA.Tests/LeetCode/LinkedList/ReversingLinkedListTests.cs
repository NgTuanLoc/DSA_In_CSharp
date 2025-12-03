using DSA_In_CSharp.LeetCode.LinkedList;

namespace DSA.Tests.LeetCode.LinkedList;

/// <summary>
/// Unit tests for Reversing LinkedList pattern implementations.
/// LinkedList reversal is a fundamental technique that involves changing the direction of pointers.
/// Common use cases: reversing entire list, reversing portions, palindrome checking, and pair swapping.
/// Time Complexity: Usually O(n), Space Complexity: O(1) for iterative, O(n) for recursive.
/// </summary>
public class ReversingLinkedListTests
{
    #region Helper Methods
    /// <summary>
    /// Creates a linked list from an array of values.
    /// </summary>
    private static ListNode CreateLinkedList(int[] values)
    {
        if (values == null || values.Length == 0)
            throw new ArgumentException("Values cannot be null or empty");

        var head = new ListNode(values[0]);
        var current = head;

        for (int i = 1; i < values.Length; i++)
        {
            current.Next = new ListNode(values[i]);
            current = current.Next;
        }

        return head;
    }

    /// <summary>
    /// Converts a linked list to an array for comparison.
    /// </summary>
    private static int[] LinkedListToArray(ListNode? head)
    {
        var result = new List<int>();
        var current = head;

        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }

        return result.ToArray();
    }
    #endregion

    #region ReverseLinkedList Tests
    /// <summary>
    /// Test: Verify reversing entire linked list iteratively.
    /// Pattern: Maintain three pointers (prev, current, next), reverse links one by one.
    /// Algorithm: 
    /// 1. Initialize prev = null, current = head
    /// 2. While current != null:
    ///    - Save next node
    ///    - Reverse current.Next to prev
    ///    - Move prev and current forward
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 1, 2 }, new[] { 2, 1 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
    public void ReverseLinkedList_WithVariousInputs_ReversesCorrectly(int[] input, int[] expected)
    {
        // Arrange
        var head = CreateLinkedList(input);

        // Act
        var result = ReversingLinkedList.ReverseLinkedList(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }
    #endregion

    #region SwapPairs Tests
    /// <summary>
    /// Test: Verify swapping every two adjacent nodes in linked list.
    /// Pattern: For each pair, reverse the links between them while maintaining connection to rest of list.
    /// LeetCode: https://leetcode.com/problems/swap-nodes-in-pairs/
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 2, 1, 4, 3 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 2, 1, 4, 3, 5 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 1, 2 }, new[] { 2, 1 })]
    public void SwapPairs_WithVariousInputs_SwapsCorrectly(int[] input, int[] expected)
    {
        // Arrange
        var head = CreateLinkedList(input);

        // Act
        var result = ReversingLinkedList.SwapPairs(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with empty list.
    /// Edge case: Null input should return null.
    /// </summary>
    [Fact]
    public void SwapPairs_WithNullHead_ReturnsNull()
    {
        // Arrange
        ListNode? head = null;

        // Act
        var result = ReversingLinkedList.SwapPairs(head);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region ReverseBetween Tests
    /// <summary>
    /// Test: Verify reversing portion of linked list between positions left and right.
    /// Pattern: Navigate to position, then reverse nodes in range, reconnect with rest of list.
    /// LeetCode: https://leetcode.com/problems/reverse-linked-list-ii/
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 4, new[] { 1, 4, 3, 2, 5 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 1, 3, new[] { 3, 2, 1, 4, 5 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 3, 5, new[] { 1, 2, 5, 4, 3 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 3, 3, new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 1, 5, new[] { 5, 4, 3, 2, 1 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, 3, new[] { 1, 3, 2, 4, 5 })]
    public void ReverseBetween_WithVariousRanges_ReversesCorrectly(int[] input, int left, int right, int[] expected)
    {
        // Arrange
        var head = CreateLinkedList(input);

        // Act
        var result = ReversingLinkedList.ReverseBetween(head, left, right);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }
    #endregion

    #region IsPalindrome Tests
    /// <summary>
    /// Test: Verify checking if linked list is a palindrome by reversing and comparing.
    /// Pattern: Create reversed copy of list, compare values node by node.
    /// LeetCode: https://leetcode.com/problems/palindrome-linked-list/
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 3, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, false)]
    [InlineData(new[] { 1 }, true)]
    [InlineData(new[] { 1, 1 }, true)]
    [InlineData(new[] { 1, 2 }, false)]
    [InlineData(new[] { 1, 2, 3, 4, 3, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 4, 2, 1 }, false)]
    public void IsPalindrome_WithVariousInputs_ReturnsCorrectResult(int[] input, bool expected)
    {
        // Arrange
        var head = CreateLinkedList(input);

        // Act
        var result = ReversingLinkedList.IsPalindrome(head);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region ReverseEvenLengthGroups Tests
    /// <summary>
    /// Test: Verify reversing nodes in even-length groups.
    /// Pattern: Groups are formed with lengths 1, 2, 3, 4, etc. Reverse only even-length groups.
    /// LeetCode: https://leetcode.com/problems/reverse-nodes-in-even-length-groups/
    /// Example: [5,2,6,3,9,1,7,3,8,4] -> Groups: [5], [2,6], [3,9,1], [7,3,8,4]
    ///          Reverse even groups: [5], [6,2], [3,9,1], [4,8,3,7]
    /// </summary>
    [Theory]
    [InlineData(new[] { 5, 2, 6, 3, 9, 1, 7, 3, 8, 4 }, new[] { 5, 6, 2, 3, 9, 1, 4, 8, 3, 7 })]
    [InlineData(new[] { 1, 1, 0, 6 }, new[] { 1, 0, 1, 6 })]
    [InlineData(new[] { 1, 1, 0, 6, 5 }, new[] { 1, 0, 1, 5, 6 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 1, 2 }, new[] { 1, 2 })]
    [InlineData(new[] { 1, 2, 3 }, new[] { 1, 3, 2 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 1, 3, 2, 4, 5, 6, 7 })]
    [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 0, 2, 1, 3, 4, 5, 9, 8, 7, 6 })]
    public void ReverseEvenLengthGroups_WithVariousInputs_ReversesCorrectly(int[] input, int[] expected)
    {
        // Arrange
        var head = CreateLinkedList(input);

        // Act
        var result = ReversingLinkedList.ReverseEvenLengthGroups(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }
    #endregion

    #region PairSum Tests
    /// <summary>
    /// Test: Verify finding maximum twin sum in a linked list.
    /// Pattern: Use fast/slow pointers to find middle, reverse second half, calculate twin sums.
    /// Twin nodes are n-1 and 0, n-2 and 1, etc.
    /// LeetCode: https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/
    /// Algorithm:
    /// 1. Find middle using fast/slow pointers
    /// 2. Reverse second half in-place
    /// 3. Calculate sums of twin pairs and track maximum
    /// Time: O(n), Space: O(1)
    /// </summary>
    [Theory]
    [InlineData(new[] { 5, 4, 2, 1 }, 6)]
    [InlineData(new[] { 4, 2, 2, 3 }, 7)]
    [InlineData(new[] { 1, 2 }, 3)]
    [InlineData(new[] { 1, 100, 200, 99 }, 300)]
    [InlineData(new[] { 5, 5, 5, 5 }, 10)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, 7)]
    [InlineData(new[] { 1, 1, 1000, 1000 }, 1001)]
    public void PairSum_WithVariousInputs_ReturnsMaximumTwinSum(int[] input, int expected)
    {
        // Arrange
        var head = CreateLinkedList(input);

        // Act
        var result = ReversingLinkedList.PairSum(head);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region RemoveElements Tests
    /// <summary>
    /// Test: Verify removing all nodes with specified value from linked list.
    /// Pattern: Traverse list, skip nodes matching target value, maintain links.
    /// LeetCode: https://leetcode.com/problems/remove-linked-list-elements/
    /// Algorithm:
    /// 1. Track prev and curr pointers
    /// 2. When curr.Value == val, remove node by updating prev.Next
    /// 3. Handle head removal separately
    /// Time: O(n), Space: O(1)
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 6, 3, 4, 5, 6 }, 6, new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { 7, 7, 7, 7 }, 7, new int[] { })]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 6, new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { 1 }, 1, new int[] { })]
    [InlineData(new[] { 1, 2, 2, 1 }, 2, new[] { 1, 1 })]
    [InlineData(new[] { 2, 2, 1, 2, 2 }, 2, new[] { 1 })]
    public void RemoveElements_WithVariousInputs_RemovesCorrectly(int[] input, int val, int[] expected)
    {
        // Arrange
        var head = CreateLinkedList(input);

        // Act
        var result = ReversingLinkedList.RemoveElements(head, val);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with null input.
    /// Edge case: Null input should return null.
    /// </summary>
    [Fact]
    public void RemoveElements_WithNullHead_ReturnsNull()
    {
        // Arrange
        ListNode? head = null;

        // Act
        var result = ReversingLinkedList.RemoveElements(head, 1);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region GetDecimalValue Tests
    /// <summary>
    /// Test: Verify converting binary number represented as linked list to decimal integer.
    /// Pattern: Traverse list left to right, shift and accumulate binary digits.
    /// LeetCode: https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/
    /// Algorithm:
    /// 1. Initialize sum = 0
    /// 2. For each node: sum = sum * 2 + node.Value
    /// 3. Return sum
    /// Example: [1,0,1] represents 101₂ = 5₁₀
    /// Time: O(n), Space: O(1)
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 0, 1 }, 5)]
    [InlineData(new[] { 0 }, 0)]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0 }, 151078)]
    [InlineData(new[] { 1, 1, 1, 1 }, 15)]
    [InlineData(new[] { 1, 0, 0, 0 }, 8)]
    [InlineData(new[] { 1, 1, 0, 1, 0 }, 26)]
    public void GetDecimalValue_WithVariousInputs_ReturnsCorrectDecimal(int[] input, int expected)
    {
        // Arrange
        var head = CreateLinkedList(input);

        // Act
        var result = ReversingLinkedList.GetDecimalValue(head);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region OddEvenList Tests
    /// <summary>
    /// Test: Verify grouping all odd-indexed nodes together followed by even-indexed nodes.
    /// Pattern: Maintain two separate chains (odd and even), then connect them.
    /// LeetCode: https://leetcode.com/problems/odd-even-linked-list/
    /// Algorithm:
    /// 1. Keep track of odd and even node chains
    /// 2. Traverse list, alternating between odd and even updates
    /// 3. Connect odd tail to even head
    /// Note: First node is considered odd (index 1), second is even (index 2), etc.
    /// Time: O(n), Space: O(1)
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 3, 5, 2, 4 })]
    [InlineData(new[] { 2, 1, 3, 5, 6, 4, 7 }, new[] { 2, 3, 6, 7, 1, 5, 4 })]
    [InlineData(new[] { 1, 2 }, new[] { 1, 2 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 3, 2, 4 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 1, 3, 5, 2, 4, 6 })]
    public void OddEvenList_WithVariousInputs_GroupsCorrectly(int[] input, int[] expected)
    {
        // Arrange
        var head = CreateLinkedList(input);

        // Act
        var result = ReversingLinkedList.OddEvenList(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with null input.
    /// Edge case: Null input should return null.
    /// </summary>
    [Fact]
    public void OddEvenList_WithNullHead_ReturnsNull()
    {
        // Arrange
        ListNode? head = null;

        // Act
        var result = ReversingLinkedList.OddEvenList(head!);

        // Assert
        Assert.Null(result);
    }
    #endregion
}
