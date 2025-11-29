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
    [Fact]
    public void ReverseLinkedList_WithMultipleNodes_ReversesEntireList()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var expected = new[] { 5, 4, 3, 2, 1 };

        // Act
        var result = ReversingLinkedList.ReverseLinkedList(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with single node.
    /// Edge case: List with one element should remain unchanged.
    /// </summary>
    [Fact]
    public void ReverseLinkedList_WithSingleNode_ReturnsSameNode()
    {
        // Arrange
        var head = new ListNode(1);
        var expected = new[] { 1 };

        // Act
        var result = ReversingLinkedList.ReverseLinkedList(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with two nodes.
    /// </summary>
    [Fact]
    public void ReverseLinkedList_WithTwoNodes_SwapsNodes()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2 });
        var expected = new[] { 2, 1 };

        // Act
        var result = ReversingLinkedList.ReverseLinkedList(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with longer list.
    /// </summary>
    [Fact]
    public void ReverseLinkedList_WithLongerList_ReversesCorrectly()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        var expected = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

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
    [Fact]
    public void SwapPairs_WithEvenNumberOfNodes_SwapsAllPairs()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4 });
        var expected = new[] { 2, 1, 4, 3 };

        // Act
        var result = ReversingLinkedList.SwapPairs(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with odd number of nodes (last node remains).
    /// </summary>
    [Fact]
    public void SwapPairs_WithOddNumberOfNodes_LeavesLastNodeUnchanged()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var expected = new[] { 2, 1, 4, 3, 5 };

        // Act
        var result = ReversingLinkedList.SwapPairs(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with single node.
    /// Edge case: Cannot swap, should return same node.
    /// </summary>
    [Fact]
    public void SwapPairs_WithSingleNode_ReturnsSameNode()
    {
        // Arrange
        var head = new ListNode(1);
        var expected = new[] { 1 };

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

    /// <summary>
    /// Test: Verify correct behavior with two nodes.
    /// </summary>
    [Fact]
    public void SwapPairs_WithTwoNodes_SwapsThem()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2 });
        var expected = new[] { 2, 1 };

        // Act
        var result = ReversingLinkedList.SwapPairs(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }
    #endregion

    #region ReverseBetween Tests
    /// <summary>
    /// Test: Verify reversing portion of linked list between positions left and right.
    /// Pattern: Navigate to position, then reverse nodes in range, reconnect with rest of list.
    /// LeetCode: https://leetcode.com/problems/reverse-linked-list-ii/
    /// </summary>
    [Fact]
    public void ReverseBetween_WithMiddleRange_ReversesSublist()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var left = 2;
        var right = 4;
        var expected = new[] { 1, 4, 3, 2, 5 };

        // Act
        var result = ReversingLinkedList.ReverseBetween(head, left, right);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify reversing from head.
    /// </summary>
    [Fact]
    public void ReverseBetween_ReversalStartsAtHead_ReversesFromBeginning()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var left = 1;
        var right = 3;
        var expected = new[] { 3, 2, 1, 4, 5 };

        // Act
        var result = ReversingLinkedList.ReverseBetween(head, left, right);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify reversing to end of list.
    /// </summary>
    [Fact]
    public void ReverseBetween_ReversalEndsAtTail_ReversesToEnd()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var left = 3;
        var right = 5;
        var expected = new[] { 1, 2, 5, 4, 3 };

        // Act
        var result = ReversingLinkedList.ReverseBetween(head, left, right);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior when left equals right (no reversal needed).
    /// Edge case: Single position, list should remain unchanged.
    /// </summary>
    [Fact]
    public void ReverseBetween_WithSameLeftAndRight_RemainsUnchanged()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var left = 3;
        var right = 3;
        var expected = new[] { 1, 2, 3, 4, 5 };

        // Act
        var result = ReversingLinkedList.ReverseBetween(head, left, right);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify reversing entire list.
    /// </summary>
    [Fact]
    public void ReverseBetween_ReversingEntireList_ReversesAll()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var left = 1;
        var right = 5;
        var expected = new[] { 5, 4, 3, 2, 1 };

        // Act
        var result = ReversingLinkedList.ReverseBetween(head, left, right);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify reversing two adjacent nodes.
    /// </summary>
    [Fact]
    public void ReverseBetween_WithTwoAdjacentNodes_SwapsThem()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var left = 2;
        var right = 3;
        var expected = new[] { 1, 3, 2, 4, 5 };

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
    [Fact]
    public void IsPalindrome_WithPalindromeList_ReturnsTrue()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 2, 1 });

        // Act
        var result = ReversingLinkedList.IsPalindrome(head);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Test: Verify correct behavior with even-length palindrome.
    /// </summary>
    [Fact]
    public void IsPalindrome_WithEvenLengthPalindrome_ReturnsTrue()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 2, 1 });

        // Act
        var result = ReversingLinkedList.IsPalindrome(head);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Test: Verify correct behavior with non-palindrome list.
    /// </summary>
    [Fact]
    public void IsPalindrome_WithNonPalindromeList_ReturnsFalse()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });

        // Act
        var result = ReversingLinkedList.IsPalindrome(head);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Test: Verify correct behavior with single node.
    /// Edge case: Single element is always a palindrome.
    /// </summary>
    [Fact]
    public void IsPalindrome_WithSingleNode_ReturnsTrue()
    {
        // Arrange
        var head = new ListNode(1);

        // Act
        var result = ReversingLinkedList.IsPalindrome(head);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Test: Verify correct behavior with two identical nodes.
    /// </summary>
    [Fact]
    public void IsPalindrome_WithTwoIdenticalNodes_ReturnsTrue()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 1 });

        // Act
        var result = ReversingLinkedList.IsPalindrome(head);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Test: Verify correct behavior with two different nodes.
    /// </summary>
    [Fact]
    public void IsPalindrome_WithTwoDifferentNodes_ReturnsFalse()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2 });

        // Act
        var result = ReversingLinkedList.IsPalindrome(head);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Test: Verify correct behavior with longer palindrome.
    /// </summary>
    [Fact]
    public void IsPalindrome_WithLongerPalindrome_ReturnsTrue()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 3, 2, 1 });

        // Act
        var result = ReversingLinkedList.IsPalindrome(head);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Test: Verify correct behavior when middle value differs.
    /// </summary>
    [Fact]
    public void IsPalindrome_WithDifferentMiddleValue_ReturnsFalse()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 2, 1 });

        // Act
        var result = ReversingLinkedList.IsPalindrome(head);

        // Assert
        Assert.False(result);
    }
    #endregion
}
