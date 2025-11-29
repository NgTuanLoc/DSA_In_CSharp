namespace DSA_In_CSharp.LeetCode.LinkedList;

public class ListNode(int value)
{
    public int Value { get; set; } = value;
    public ListNode? Next { get; set; }
}

public static class FastAndSlowPointers
{
    // Example 1: Given the head of a linked list with an odd number of nodes head, return the value of the node in the middle.
    // For example, given a linked list that represents 1 -> 2 -> 3 -> 4 -> 5, return 3.
    public static int GetMiddle(ListNode head)
    {
        var dummy = head;
        var n = 0;

        while (dummy != null)
        {
            n++;
            dummy = dummy.Next;
        }

        for (var i = 0; i < n / 2; i++)
        {
            head = head.Next!;
        }

        return head!.Value;
    }

    // Example 2: 141. Linked List Cycle
    // Given the head of a linked list, determine if the linked list has a cycle.
    // There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer.
    public static bool HasCycle(ListNode head)
    {
        var slow = head;
        var fast = head;


        while (fast != null && fast.Next != null)
        {
            slow = slow!.Next;
            fast = fast.Next.Next;
            if (slow == fast) return true;
        }

        return false;
    }

    public static bool HasCycleWithHashSet(ListNode? head)
    {
        var seen = new HashSet<ListNode?>
        {
            head
        };

        while (head != null)
        {
            head = head.Next;
            if (!seen.Add(head)) return true;
        }
        return false;
    }

    // Example 3: Given the head of a linked list and an integer k, return the k-th node from the end.
    // For example, given the linked list that represents 1 -> 2 -> 3 -> 4 -> 5 and k = 2, return the node with value 4, as it is the 2nd node from the end.
    public static ListNode? FindNode(ListNode head, int n)
    {
        var slow = head;
        var fast = head;

        for (int i = 0; i < n; i++)
        {
            fast = fast?.Next;
        }

        while (fast != null)
        {
            fast = fast.Next;
            slow = slow!.Next;
        }

        return slow;
    }

    // https://leetcode.com/problems/middle-of-the-linked-list/description/
    public static ListNode MiddleNode(ListNode head)
    {
        var dummy = head;
        var length = 0;

        while (dummy != null)
        {
            length++;
            dummy = dummy.Next;
        }

        var targetNode = length / 2;
        dummy = head;

        for (int i = 0; i < targetNode; i++)
        {
            dummy = dummy!.Next;
        }

        return dummy!;
    }

    // https://leetcode.com/problems/remove-duplicates-from-sorted-list/description/
    public static ListNode DeleteDuplicates(ListNode head)
    {
        var dummy = head;
        var unique = head;

        while (dummy != null)
        {
            dummy = dummy.Next;
            if (unique?.Value != dummy?.Value)
            {
                unique!.Next = dummy;
                unique = dummy;
            }
        }

        return head;
    }

    // https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list/
    public static ListNode? DeleteMiddle(ListNode head)
    {
        // Edge case: only one node
        if (head?.Next == null) return null;

        var slow = head;
        var fast = head;
        var prev = (ListNode?)null;

        // Find middle node using fast/slow pointers
        while (fast != null && fast.Next != null)
        {
            prev = slow;
            slow = slow!.Next;
            fast = fast.Next.Next;
        }

        // Delete the middle node
        prev!.Next = slow!.Next;

        return head;
    }

    // https://leetcode.com/problems/remove-nth-node-from-end-of-list/
    public static ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        var dummy = new ListNode(0) { Next = head };
        var fast = dummy;
        var slow = dummy;

        // Move fast n+1 steps ahead
        for (int i = 0; i <= n; i++)
        {
            fast = fast!.Next;
        }

        // Move both pointers until fast reaches end
        while (fast != null)
        {
            slow = slow!.Next;
            fast = fast.Next;
        }

        // Remove the nth node from end
        slow!.Next = slow.Next?.Next;

        return dummy.Next;
    }

    // https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/description/
    public static ListNode? DeleteDuplicatesSecond(ListNode head)
    {
        // Create dummy node to handle edge cases (when head needs to be removed)
        var dummy = new ListNode(0) { Next = head };
        var prev = dummy;
        var current = head;

        while (current != null)
        {
            // Check if current node has duplicates
            if (current.Next != null && current.Value == current.Next.Value)
            {
                int duplicateValue = current.Value;

                // Skip all nodes with this duplicate value
                while (current != null && current.Value == duplicateValue)
                {
                    current = current.Next;
                }

                // Connect previous node to the node after all duplicates
                prev.Next = current;
            }
            else
            {
                // No duplicate found, move prev pointer
                prev = current;
                current = current.Next;
            }
        }

        return dummy.Next;
    }

    // https://leetcode.com/problems/swapping-nodes-in-a-linked-list/description/
    public static ListNode SwapNodes(ListNode head, int k)
    {
        var dummy = new ListNode(0) { Next = head };

        // Find kth from beginning and kth from end
        var first = head;
        var second = head;

        // Move first to kth position
        for (int i = 1; i < k; i++)
        {
            first = first!.Next;
        }

        // Use first to find kth from end
        var temp = first;
        while (temp!.Next != null)
        {
            second = second!.Next;
            temp = temp.Next;
        }

        // If same node, no swap needed
        if (first == second) return head;

        // Find previous nodes
        ListNode? prev1 = null, prev2 = null;
        var current = dummy;

        while (current!.Next != null)
        {
            if (current.Next == first) prev1 = current;
            if (current.Next == second) prev2 = current;
            current = current.Next;
        }

        // Swap the nodes
        if (prev1 != null) prev1.Next = second;
        if (prev2 != null) prev2.Next = first;

        // Swap next pointers
        (first!.Next, second!.Next) = (second.Next, first.Next);

        return dummy.Next;
    }
}