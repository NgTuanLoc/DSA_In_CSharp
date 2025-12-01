namespace DSA_In_CSharp.LeetCode.LinkedList;

public static class ReversingLinkedList
{
    public static ListNode? ReverseLinkedList(ListNode head)
    {
        ListNode? prev = null;
        ListNode? current = head;

        while (current != null)
        {
            ListNode? nextTemp = current.Next;  // Save next node
            current.Next = prev;               // Reverse the link
            prev = current;                    // Move prev forward
            current = nextTemp;                // Move current forward
        }

        return prev;  // prev is the new head
    }

    // https://leetcode.com/problems /swap-nodes-in-pairs/
    public static ListNode? SwapPairs(ListNode? head)
    {
        if (head == null || head.Next == null) return head;
        var dummy = head.Next;
        ListNode? prev = null;

        while (head != null && head.Next != null)
        {
            if (prev != null)
            {
                prev.Next = head.Next;
            }

            prev = head;
            var nextNode = head.Next.Next;
            head.Next.Next = head;
            head.Next = nextNode;
            head = nextNode;
        }

        return dummy;
    }
    // https://leetcode.com/problems/reverse-linked-list-ii/
    public static ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (left == right) return head;

        var dummy = new ListNode(0)
        {
            Next = head
        };
        var prev = dummy;

        for (int i = 1; i < left; i++)
        {
            prev = prev!.Next;
        }

        var curr = prev!.Next;
        for (int i = left; i < right; i++)
        {
            var nextNode = curr!.Next;
            curr.Next = nextNode!.Next;
            nextNode.Next = prev.Next;
            prev.Next = nextNode;
        }

        return dummy.Next;
    }

    // https://leetcode.com/problems/palindrome-linked-list/description/
    public static bool IsPalindrome(ListNode head)
    {
        ListNode? prev = null;
        var curr = head;

        while (curr != null)
        {
            var next = curr.Next;
            var newNode = new ListNode(curr.Value)
            {
                Next = prev
            };
            prev = newNode;
            curr = next;
        }

        while (head != null)
        {
            if (head.Value != prev?.Value) return false;
            head = head.Next!;
            prev = prev.Next;
        }

        return true;
    }

    // https://leetcode.com/problems/reverse-nodes-in-even-length-groups/
    public static ListNode ReverseEvenLengthGroups(ListNode head)
    {
        var dummy = new ListNode(0) { Next = head };
        var prev = dummy;
        var groupLength = 1;

        while (prev.Next != null)
        {
            // Count actual nodes in current group (may be less than groupLength for last group)
            var curr = prev.Next;
            var actualLength = 0;
            var temp = curr;

            while (temp != null && actualLength < groupLength)
            {
                actualLength++;
                temp = temp.Next;
            }

            // Reverse if group has even length
            if (actualLength % 2 == 0)
            {
                // Reverse the group
                var groupPrev = prev.Next;
                var groupCurr = groupPrev!.Next;

                for (int i = 1; i < actualLength; i++)
                {
                    var nextNode = groupCurr!.Next;
                    groupCurr.Next = groupPrev;
                    groupPrev = groupCurr;
                    groupCurr = nextNode;
                }

                // Reconnect with the rest of the list
                var tail = prev.Next;
                prev.Next = groupPrev;
                tail!.Next = groupCurr;
                prev = tail;
            }
            else
            {
                // Skip odd-length group
                for (int i = 0; i < actualLength; i++)
                {
                    prev = prev.Next!;
                }
            }

            groupLength++;
        }

        return dummy.Next!;
    }

    // https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list/
    public static int PairSum(ListNode head)
    {
        // Find middle using fast and slow pointers
        var slow = head;
        var fast = head;

        while (fast != null && fast.Next != null)
        {
            slow = slow.Next!;
            fast = fast.Next.Next;
        }

        // Reverse second half in-place
        ListNode? prev = null;
        var curr = slow;

        while (curr != null)
        {
            var next = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = next;
        }

        // Calculate max twin sum
        var max = 0;
        var firstHalf = head;
        var secondHalf = prev;

        while (secondHalf != null)
        {
            max = Math.Max(max, firstHalf!.Value + secondHalf.Value);
            firstHalf = firstHalf.Next;
            secondHalf = secondHalf.Next;
        }

        return max;
    }
}