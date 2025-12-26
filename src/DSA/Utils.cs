using System.Text;
using DSA_In_CSharp.LeetCode.LinkedList;
using DSA.LeetCode.TreesAndGraphs;

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

    public static void Print(int[] list)
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

    /// <summary>
    /// Builds a binary tree from level-order array representation.
    /// Example: [10,5,15,3,7,null,18] creates:
    ///       10
    ///      /  \
    ///     5    15
    ///    / \     \
    ///   3   7    18
    /// </summary>
    /// <param name="values">Array of nullable integers representing the tree in level-order</param>
    /// <returns>Root node of the constructed tree, or null if array is empty</returns>
    public static TreeNode? BuildBinaryTree(int?[] values)
    {
        if (values.Length == 0 || values[0] == null) return null;

        TreeNode root = new(values[0]!.Value);
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        int i = 1;
        while (queue.Count > 0 && i < values.Length)
        {
            TreeNode current = queue.Dequeue();

            // Process left child
            if (i < values.Length && values[i].HasValue)
            {
                current.Left = new TreeNode(values[i]!.Value);
                queue.Enqueue(current.Left);
            }
            i++;

            // Process right child
            if (i < values.Length && values[i].HasValue)
            {
                current.Right = new TreeNode(values[i]!.Value);
                queue.Enqueue(current.Right);
            }
            i++;
        }

        return root;
    }

    /// <summary>
    /// Prints the binary tree as a level-order array string.
    /// </summary>
    public static void PrintBinaryTree(TreeNode? root)
    {
        Console.WriteLine(TreeToString(root));
    }

    /// <summary>
    /// Returns the binary tree as a level-order array string.
    /// </summary>
    public static string TreeToString(TreeNode? root)
    {
        if (root == null) return "[]";

        List<string> result = [];
        Queue<TreeNode?> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode? current = queue.Dequeue();

            if (current == null)
            {
                result.Add("null");
            }
            else
            {
                result.Add(current.Val.ToString());
                queue.Enqueue(current.Left);
                queue.Enqueue(current.Right);
            }
        }

        // Remove trailing nulls
        while (result.Count > 0 && result[^1] == "null")
        {
            result.RemoveAt(result.Count - 1);
        }

        return $"[{string.Join(",", result)}]";
    }

    /// <summary>
    /// Finds a TreeNode with the specified value in a binary tree using BFS.
    /// </summary>
    /// <param name="root">Root node of the binary tree</param>
    /// <param name="value">Value to search for</param>
    /// <returns>TreeNode with the specified value, or null if not found</returns>
    public static TreeNode? FindTreeNode(TreeNode? root, int value)
    {
        if (root == null) return null;

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();

            if (current.Val == value) return current;

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }

        return null;
    }
}
