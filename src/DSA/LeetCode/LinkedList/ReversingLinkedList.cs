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
}