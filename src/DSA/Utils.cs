using System.Text;
using DSA_In_CSharp.LeetCode.LinkedList;

namespace DSA;

public static class Utils
{
    public static void Print(List<int> list)
    {
        foreach (int item in list)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\n====================");
    }

    public static string PrintLinkedList(ListNode? head)
    {
        if (head == null) return "";
        List<int> arr = [];
        while (head != null)
        {
            arr.Add(head.Value);
            head = head?.Next;
        }

        return string.Join(" = ", arr);
    }

    public static ListNode BuildLinkedList(List<int> arr)
    {
        var head = new ListNode(arr[0]);
        var dummy = head;

        for (int i = 1; i < arr.Count; i++)
        {
            dummy.Next = new ListNode(arr[i]);
            dummy = dummy.Next;
        }

        return head;
    }
}
