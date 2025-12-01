using DSA_In_CSharp.LeetCode.LinkedList;

namespace DSA.Tests.LeetCode.LinkedList;

/// <summary>
/// Unit tests for Fast and Slow Pointers (Floyd's Cycle Detection) pattern on LinkedList.
/// Fast and Slow Pointers technique uses two pointers moving at different speeds to detect cycles,
/// find middle nodes, and solve k-th from end problems.
/// Common use cases: cycle detection, finding middle element, removing nth from end, and detecting intersections.
/// Time Complexity: Usually O(n), Space Complexity: O(1).
/// </summary>
public class FastAndSlowPointersTests
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

    /// <summary>
    /// Creates a linked list with a cycle at the specified position.
    /// </summary>
    private static ListNode CreateLinkedListWithCycle(int[] values, int cyclePos)
    {
        if (values == null || values.Length == 0)
            throw new ArgumentException("Values cannot be null or empty");

        var head = new ListNode(values[0]);
        var current = head;
        ListNode? cycleNode = cyclePos == 0 ? head : null;

        for (int i = 1; i < values.Length; i++)
        {
            current.Next = new ListNode(values[i]);
            current = current.Next;

            if (i == cyclePos)
                cycleNode = current;
        }

        if (cycleNode != null)
            current.Next = cycleNode;

        return head;
    }
    #endregion

    #region GetMiddle Tests
    /// <summary>
    /// Test: Verify finding middle value in odd-length linked list.
    /// Pattern: Count nodes first, then traverse to middle position.
    /// </summary>
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 3)]
    [InlineData(new[] { 1, 2, 3 }, 2)]
    [InlineData(new[] { 42 }, 42)]
    public void GetMiddle_WithVariousInputs_ReturnsMiddleValue(int[] input, int expected)
    {
        // Arrange
        var head = CreateLinkedList(input);

        // Act
        var result = FastAndSlowPointers.GetMiddle(head);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #region HasCycle Tests
    /// <summary>
    /// Test: Verify detecting a cycle in linked list using Floyd's algorithm.
    /// Pattern: Fast pointer moves 2 steps, slow moves 1. If they meet, cycle exists.
    /// LeetCode: https://leetcode.com/problems/linked-list-cycle/
    /// </summary>
    [Fact]
    public void HasCycle_WithCyclePresent_ReturnsTrue()
    {
        // Arrange
        var head = CreateLinkedListWithCycle(new[] { 3, 2, 0, -4 }, cyclePos: 1);

        // Act
        var result = FastAndSlowPointers.HasCycle(head);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Test: Verify correct behavior when no cycle exists.
    /// </summary>
    [Fact]
    public void HasCycle_WithNoCycle_ReturnsFalse()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });

        // Act
        var result = FastAndSlowPointers.HasCycle(head);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Test: Verify correct behavior with single node and no cycle.
    /// </summary>
    [Fact]
    public void HasCycle_WithSingleNodeNoCycle_ReturnsFalse()
    {
        // Arrange
        var head = new ListNode(1);

        // Act
        var result = FastAndSlowPointers.HasCycle(head);

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Test: Verify detecting cycle using HashSet approach.
    /// Alternative pattern: Track visited nodes in HashSet.
    /// </summary>
    [Fact]
    public void HasCycleWithHashSet_WithCyclePresent_ReturnsTrue()
    {
        // Arrange
        var head = CreateLinkedListWithCycle(new[] { 1, 2 }, cyclePos: 0);

        // Act
        var result = FastAndSlowPointers.HasCycleWithHashSet(head);

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Test: Verify HashSet approach with no cycle.
    /// </summary>
    [Fact]
    public void HasCycleWithHashSet_WithNoCycle_ReturnsFalse()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3 });

        // Act
        var result = FastAndSlowPointers.HasCycleWithHashSet(head);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region FindNode Tests
    /// <summary>
    /// Test: Verify finding k-th node from the end using two-pointer technique.
    /// Pattern: Move fast pointer k steps ahead, then move both until fast reaches end.
    /// </summary>
    [Fact]
    public void FindNode_WithKthFromEnd_ReturnsCorrectNode()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var k = 2;
        var expected = 4;

        // Act
        var result = FastAndSlowPointers.FindNode(head, k);

        // Assert
        Assert.Equal(expected, result?.Value);
    }

    /// <summary>
    /// Test: Verify finding last node (k=0 returns null since fast pointer goes past end).
    /// </summary>
    [Fact]
    public void FindNode_WithKEqualsZero_ReturnsNull()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var k = 0;

        // Act
        var result = FastAndSlowPointers.FindNode(head, k);

        // Assert
        Assert.Null(result);
    }

    /// <summary>
    /// Test: Verify finding first node from end (k equals list length - 1).
    /// </summary>
    [Fact]
    public void FindNode_WithKEqualsLength_ReturnsFirstNode()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3 });
        var k = 3;
        var expected = 1;

        // Act
        var result = FastAndSlowPointers.FindNode(head, k);

        // Assert
        Assert.Equal(expected, result?.Value);
    }
    #endregion

    #region MiddleNode Tests
    /// <summary>
    /// Test: Verify finding middle node of linked list.
    /// Pattern: Count length, then traverse to middle position.
    /// LeetCode: https://leetcode.com/problems/middle-of-the-linked-list/
    /// </summary>
    [Fact]
    public void MiddleNode_WithOddLengthList_ReturnsMiddleNode()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var expected = new[] { 3, 4, 5 };

        // Act
        var result = FastAndSlowPointers.MiddleNode(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with even-length list (returns second middle).
    /// </summary>
    [Fact]
    public void MiddleNode_WithEvenLengthList_ReturnsSecondMiddleNode()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5, 6 });
        var expected = new[] { 4, 5, 6 };

        // Act
        var result = FastAndSlowPointers.MiddleNode(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }
    #endregion

    #region DeleteDuplicates Tests
    /// <summary>
    /// Test: Verify removing duplicates from sorted linked list (keeping one occurrence).
    /// Pattern: Compare current with next, skip next if values are equal.
    /// LeetCode: https://leetcode.com/problems/remove-duplicates-from-sorted-list/
    /// </summary>
    [Fact]
    public void DeleteDuplicates_WithDuplicates_RemovesDuplicatesKeepingOne()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 1, 2, 3, 3 });
        var expected = new[] { 1, 2, 3 };

        // Act
        var result = FastAndSlowPointers.DeleteDuplicates(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with no duplicates.
    /// </summary>
    [Fact]
    public void DeleteDuplicates_WithNoDuplicates_RemainsUnchanged()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4 });
        var expected = new[] { 1, 2, 3, 4 };

        // Act
        var result = FastAndSlowPointers.DeleteDuplicates(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior when all nodes are duplicates.
    /// </summary>
    [Fact]
    public void DeleteDuplicates_WithAllDuplicates_ReturnsOneNode()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 1, 1, 1 });
        var expected = new[] { 1 };

        // Act
        var result = FastAndSlowPointers.DeleteDuplicates(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }
    #endregion

    #region DeleteMiddle Tests
    /// <summary>
    /// Test: Verify deleting the middle node from linked list.
    /// Pattern: Use fast/slow pointers to find middle, track previous to perform deletion.
    /// LeetCode: https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list/
    /// </summary>
    [Fact]
    public void DeleteMiddle_WithOddLengthList_DeletesMiddleNode()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 3, 4, 7, 1, 2, 6 });
        var expected = new[] { 1, 3, 4, 1, 2, 6 };

        // Act
        var result = FastAndSlowPointers.DeleteMiddle(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with even-length list.
    /// </summary>
    [Fact]
    public void DeleteMiddle_WithEvenLengthList_DeletesSecondMiddleNode()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4 });
        var expected = new[] { 1, 2, 4 };

        // Act
        var result = FastAndSlowPointers.DeleteMiddle(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior with single node (returns null).
    /// Edge case: Deleting only node results in empty list.
    /// </summary>
    [Fact]
    public void DeleteMiddle_WithSingleNode_ReturnsNull()
    {
        // Arrange
        var head = new ListNode(1);

        // Act
        var result = FastAndSlowPointers.DeleteMiddle(head);

        // Assert
        Assert.Null(result);
    }

    /// <summary>
    /// Test: Verify correct behavior with two nodes.
    /// </summary>
    [Fact]
    public void DeleteMiddle_WithTwoNodes_DeletesSecondNode()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2 });
        var expected = new[] { 1 };

        // Act
        var result = FastAndSlowPointers.DeleteMiddle(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }
    #endregion

    #region RemoveNthFromEnd Tests
    /// <summary>
    /// Test: Verify removing nth node from end of list.
    /// Pattern: Move fast pointer n+1 steps, then move both pointers together.
    /// LeetCode: https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    /// </summary>
    [Fact]
    public void RemoveNthFromEnd_WithValidN_RemovesCorrectNode()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var n = 2;
        var expected = new[] { 1, 2, 3, 5 };

        // Act
        var result = FastAndSlowPointers.RemoveNthFromEnd(head, n);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify removing first node (n equals length).
    /// Edge case: Removing head node.
    /// </summary>
    [Fact]
    public void RemoveNthFromEnd_RemovingFirstNode_ReturnsListWithoutHead()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3 });
        var n = 3;
        var expected = new[] { 2, 3 };

        // Act
        var result = FastAndSlowPointers.RemoveNthFromEnd(head, n);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify removing last node (n = 1).
    /// </summary>
    [Fact]
    public void RemoveNthFromEnd_RemovingLastNode_ReturnsListWithoutLast()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var n = 1;
        var expected = new[] { 1, 2, 3, 4 };

        // Act
        var result = FastAndSlowPointers.RemoveNthFromEnd(head, n);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify removing only node.
    /// Edge case: Single node list.
    /// </summary>
    [Fact]
    public void RemoveNthFromEnd_WithSingleNode_ReturnsNull()
    {
        // Arrange
        var head = new ListNode(1);
        var n = 1;

        // Act
        var result = FastAndSlowPointers.RemoveNthFromEnd(head, n);

        // Assert
        Assert.Null(result);
    }
    #endregion

    #region DeleteDuplicatesSecond Tests
    /// <summary>
    /// Test: Verify removing all nodes with duplicate values (not keeping any occurrence).
    /// Pattern: Track previous pointer, skip all nodes with duplicate value.
    /// LeetCode: https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/
    /// </summary>
    [Fact]
    public void DeleteDuplicatesSecond_WithDuplicates_RemovesAllDuplicateNodes()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 3, 4, 4, 5 });
        var expected = new[] { 1, 2, 5 };

        // Act
        var result = FastAndSlowPointers.DeleteDuplicatesSecond(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior when head nodes are duplicates.
    /// </summary>
    [Fact]
    public void DeleteDuplicatesSecond_WithDuplicatesAtStart_RemovesHeadNodes()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 1, 1, 2, 3 });
        var expected = new[] { 2, 3 };

        // Act
        var result = FastAndSlowPointers.DeleteDuplicatesSecond(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior when all nodes are duplicates.
    /// Edge case: Entire list should be removed.
    /// </summary>
    [Fact]
    public void DeleteDuplicatesSecond_WithAllDuplicates_ReturnsNull()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 1, 1, 1 });

        // Act
        var result = FastAndSlowPointers.DeleteDuplicatesSecond(head);

        // Assert
        Assert.Null(result);
    }

    /// <summary>
    /// Test: Verify correct behavior with no duplicates.
    /// </summary>
    [Fact]
    public void DeleteDuplicatesSecond_WithNoDuplicates_RemainsUnchanged()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var expected = new[] { 1, 2, 3, 4, 5 };

        // Act
        var result = FastAndSlowPointers.DeleteDuplicatesSecond(head);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }
    #endregion

    #region SwapNodes Tests
    /// <summary>
    /// Test: Verify swapping kth node from beginning with kth node from end.
    /// Pattern: Find both nodes using fast/slow technique, then swap them.
    /// LeetCode: https://leetcode.com/problems/swapping-nodes-in-a-linked-list/
    /// </summary>
    [Fact]
    public void SwapNodes_WithValidK_SwapsCorrectNodes()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var k = 2;
        var expected = new[] { 1, 4, 3, 2, 5 };

        // Act
        var result = FastAndSlowPointers.SwapNodes(head, k);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify correct behavior when k points to same node from both ends.
    /// Edge case: Middle node in odd-length list.
    /// </summary>
    [Fact]
    public void SwapNodes_WithKPointingToMiddle_RemainsUnchanged()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3 });
        var k = 2;
        var expected = new[] { 1, 2, 3 };

        // Act
        var result = FastAndSlowPointers.SwapNodes(head, k);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }

    /// <summary>
    /// Test: Verify swapping first and last nodes.
    /// </summary>
    [Fact]
    public void SwapNodes_WithKEqualsOne_SwapsFirstAndLast()
    {
        // Arrange
        var head = CreateLinkedList(new[] { 1, 2, 3, 4, 5 });
        var k = 1;
        var expected = new[] { 5, 2, 3, 4, 1 };

        // Act
        var result = FastAndSlowPointers.SwapNodes(head, k);

        // Assert
        Assert.Equal(expected, LinkedListToArray(result));
    }
    #endregion
}
