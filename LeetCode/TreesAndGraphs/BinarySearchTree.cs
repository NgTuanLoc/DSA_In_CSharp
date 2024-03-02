namespace DSA.LeetCode.TreesAndGraphs;

class State
{
    public TreeNode node;
    public long small;
    public long large;
    public State(TreeNode node, long small, long large)
    {
        this.node = node;
        this.small = small;
        this.large = large;
    }
}


public class BinarySearchTree
{
    public static int RangeSumBST(TreeNode? root, int low, int high)
    {
        if (root == null) return 0;

        int result = 0;
        if (root.val >= low && root.val <= high) result += root.val;

        if (root.val > low) result += RangeSumBST(root.left, low, high);

        if (root.val < high) result += RangeSumBST(root.right, low, high);

        return result;
    }
    public static int RangeSumBST_Iteration(TreeNode root, int low, int high)
    {
        // https://leetcode.com/problems/range-sum-of-bst/description/
        int result = 0;
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            var currNode = queue.Dequeue();
            Console.WriteLine(currNode.val);

            if (currNode.val >= low && currNode.val <= high) result += currNode.val;

            if (currNode.left != null && low < currNode.val) queue.Enqueue(currNode.left);

            if (currNode.right != null && high > currNode.val) queue.Enqueue(currNode.right);
        }

        return result;
    }

    public static int GetMinimumDifference(TreeNode root)
    {
        List<TreeNode> list = [];
        GetMinimumDifference_InOrder_DFS(root, list);
        int result = int.MaxValue;
        for (int i = 0; i < list.Count - 1; i++)
        {
            result = Math.Min(result, Math.Abs(list[i].val - list[i + 1].val));
        }
        return result;
    }

    private static void GetMinimumDifference_InOrder_DFS(TreeNode? root, List<TreeNode> list)
    {
        if (root == null) return;
        GetMinimumDifference_InOrder_DFS(root.left, list);
        list.Add(root);
        GetMinimumDifference_InOrder_DFS(root.right, list);
    }

    public static int GetMinimumDifference_Iteration(TreeNode root)
    {
        // https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/
        List<int> list = IterativeInOrder(root);
        int result = int.MaxValue;

        for (int i = 0; i < list.Count - 1; i++)
        {
            result = Math.Min(result, Math.Abs(list[i] - list[i + 1]));
        }
        return result;
    }

    private static List<int> IterativeInOrder(TreeNode root)
    {
        Stack<TreeNode> stack = [];
        List<int> list = [];
        TreeNode? curr = root;

        while (stack.Count != 0 || curr != null)
        {
            if (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }
            else
            {
                curr = stack.Pop();
                list.Add(curr.val);
                curr = curr.right;
            }
        }
        return list;
    }

    public static bool IsValidBST(TreeNode? root)
    {
        // https://leetcode.com/problems/validate-binary-search-tree/description/
        return IsValidBST_DFS(root, long.MinValue, long.MaxValue);
    }

    private static bool IsValidBST_DFS(TreeNode? root, long small, long large)
    {
        if (root == null) return true;

        if (root.val <= small || root.val >= large) return false;

        bool left = IsValidBST_DFS(root.left, small, root.val);
        bool right = IsValidBST_DFS(root.right, root.val, large);
        return left && right;
    }

    public static bool IsValidBST_Iteration(TreeNode root)
    {
        Stack<State> stack = [];
        stack.Push(new State(root, long.MinValue, long.MaxValue));

        while (stack.Count != 0)
        {
            State state = stack.Pop();
            TreeNode node = state.node;
            long small = state.small;
            long large = state.large;

            if (small >= node.val || node.val >= large)
            {
                return false;
            }

            if (node.left != null)
            {
                stack.Push(new State(node.left, small, node.val));
            }
            if (node.right != null)
            {
                stack.Push(new State(node.right, node.val, large));
            }
        }

        return true;
    }
}
