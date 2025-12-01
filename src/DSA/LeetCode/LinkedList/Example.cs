using DSA;

namespace DSA_In_CSharp.LeetCode.LinkedList;

public static class LinkedListExample
{
    public static void Run()
    {
        Console.WriteLine("+++++++++++++Linked List+++++++++++++");
        // // !=========Get Middle Node=========
        // Console.WriteLine("=========Get Middle Node=========");
        // Console.WriteLine(FastAndSlowPointers.GetMiddle(Utils.BuildLinkedList([1, 2, 3, 4, 5])));

        // // !=========Linked List Cycle=========
        // var node1 = new ListNode(3);
        // var node2 = new ListNode(2);
        // var node3 = new ListNode(0);
        // var node4 = new ListNode(-4);
        // node1.Next = node2;
        // node2.Next = node3;
        // node3.Next = node4;
        // node4.Next = node2;

        // Console.WriteLine("=========Linked List Cycle=========");
        // Console.WriteLine(FastAndSlowPointers.HasCycle(node1));
        // Console.WriteLine(FastAndSlowPointers.HasCycleWithHashSet(node1));

        // // !=========Return k-th node from the end=========
        // Console.WriteLine("=========Return k-th node from the end=========");
        // Console.WriteLine(FastAndSlowPointers.FindNode(Utils.BuildLinkedList([1, 2, 3, 4, 5]), 2)?.Value);

        // // !=========Middle of the Linked List=========
        // Console.WriteLine("=========Middle of the Linked List=========");
        // Console.WriteLine(FastAndSlowPointers.MiddleNode(Utils.BuildLinkedList([1, 2, 3, 4, 5]))?.Value);
        // Console.WriteLine(FastAndSlowPointers.MiddleNode(Utils.BuildLinkedList([1, 2, 3, 4, 5, 6]))?.Value);

        // // !=========Remove Duplicates from Sorted List=========
        // Console.WriteLine("=========Remove Duplicates from Sorted List=========");
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.DeleteDuplicates(Utils.BuildLinkedList([1, 1, 2]))));
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.DeleteDuplicates(Utils.BuildLinkedList([1, 1, 2, 3, 3]))));

        // // !=========Reverse a Linked List=========
        // Console.WriteLine("=========Reverse a Linked List=========");
        // Console.WriteLine(Utils.PrintLinkedList(ReversingLinkedList.ReverseLinkedList(Utils.BuildLinkedList([1, 2, 3, 4]))));

        // Console.WriteLine("=========Swap Pairs=========");
        // Console.WriteLine(Utils.PrintLinkedList(ReversingLinkedList.SwapPairs(Utils.BuildLinkedList([1, 2, 3, 4,]))));

        // Console.WriteLine("=========Reverse a Linked List II=========");
        // Console.WriteLine(Utils.PrintLinkedList(ReversingLinkedList.ReverseBetween(Utils.BuildLinkedList([1, 2, 3, 4, 5]), 2, 4)));

        // Console.WriteLine("=========Delete Middle=========");
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.DeleteMiddle(Utils.BuildLinkedList([1, 3, 4, 7, 1, 2, 6]))));
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.DeleteMiddle(Utils.BuildLinkedList([1, 2, 3, 4]))));
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.DeleteMiddle(Utils.BuildLinkedList([2, 1]))));

        // Console.WriteLine("=========RemoveNthFromEnd=========");
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.RemoveNthFromEnd(Utils.BuildLinkedList([1, 2, 3, 4, 5]), 2)));
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.RemoveNthFromEnd(Utils.BuildLinkedList([1]), 1)));
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.RemoveNthFromEnd(Utils.BuildLinkedList([1, 2]), 1)));
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.RemoveNthFromEnd(Utils.BuildLinkedList([1, 2]), 2)));

        // Console.WriteLine("=========Remove Duplicates from Sorted List II=========");
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.DeleteDuplicatesSecond(Utils.BuildLinkedList([1, 2, 3, 3, 4, 4, 5]))));
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.DeleteDuplicatesSecond(Utils.BuildLinkedList([1, 1, 1, 2, 3]))));

        // Console.WriteLine("=========Swapping Nodes in a Linked List=========");
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.SwapNodes(Utils.BuildLinkedList([1, 2, 3, 4, 5]), 2)));
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.SwapNodes(Utils.BuildLinkedList([7, 9, 6, 6, 7, 8, 3, 0, 9, 5]), 5)));
        // Console.WriteLine(Utils.PrintLinkedList(FastAndSlowPointers.SwapNodes(Utils.BuildLinkedList([1, 2]), 1)));

        // Console.WriteLine("=========Palindrome Linked List=========");
        // Console.WriteLine(ReversingLinkedList.IsPalindrome(Utils.BuildLinkedList([1, 2, 2, 1])));
        // Console.WriteLine(ReversingLinkedList.IsPalindrome(Utils.BuildLinkedList([1, 2])));
        // Console.WriteLine(ReversingLinkedList.IsPalindrome(Utils.BuildLinkedList([1, 1, 2, 1])));

        // Console.WriteLine("=========Reverse Nodes in Even Length Groups=========");
        // Console.WriteLine(Utils.PrintLinkedList(ReversingLinkedList.ReverseEvenLengthGroups(Utils.BuildLinkedList([5, 2, 6, 3, 9, 1, 7, 3, 8, 4]))));
        // Console.WriteLine(Utils.PrintLinkedList(ReversingLinkedList.ReverseEvenLengthGroups(Utils.BuildLinkedList([1, 1, 0, 6]))));

        Console.WriteLine("=========Maximum Twin Sum of a Linked List=========");
        Console.WriteLine(ReversingLinkedList.PairSum(Utils.BuildLinkedList([5,4,2,1])));
        Console.WriteLine(ReversingLinkedList.PairSum(Utils.BuildLinkedList([4,2,2,3])));
        Console.WriteLine(ReversingLinkedList.PairSum(Utils.BuildLinkedList([1, 100000])));
    }
}