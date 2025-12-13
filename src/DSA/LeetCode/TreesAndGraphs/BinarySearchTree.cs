namespace DSA.LeetCode.TreesAndGraphs;

class State(TreeNode node, long small, long large)
{
    public TreeNode node = node;
    public long small = small;
    public long large = large;
}


public static class BinarySearchTree
{
    public static int RangeSumBST(TreeNode? root, int low, int high)
    {
        // https://leetcode.com/problems/range-sum-of-bst/description/
        if (root == null) return 0;

        var result = 0;
        if (root.Val >= low && root.Val <= high) result += root.Val;

        if (root.Val >= low) result += RangeSumBST(root.Left, low, high);

        if (root.Val <= high) result += RangeSumBST(root.Right, low, high);

        return result;
    }
    public static int RangeSumBST_Iteration(TreeNode root, int low, int high)
    {
        var result = 0;
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            var currNode = queue.Dequeue();

            if (currNode.Val >= low && currNode.Val <= high) result += currNode.Val;

            if (currNode.Left != null && low <= currNode.Val) queue.Enqueue(currNode.Left);

            if (currNode.Right != null && high >= currNode.Val) queue.Enqueue(currNode.Right);
        }

        return result;
    }

    public static int GetMinimumDifference(TreeNode root)
    {
        // https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/
        List<TreeNode> list = [];
        GetMinimumDifference_InOrder_DFS(root, list);
        var result = int.MaxValue;
        for (var i = 0; i < list.Count - 1; i++)
        {
            result = Math.Min(result, Math.Abs(list[i].Val - list[i + 1].Val));
        }
        return result;
    }

    private static void GetMinimumDifference_InOrder_DFS(TreeNode? root, List<TreeNode> list)
    {
        if (root == null) return;
        GetMinimumDifference_InOrder_DFS(root.Left, list);
        list.Add(root);
        GetMinimumDifference_InOrder_DFS(root.Right, list);
    }

    public static int GetMinimumDifference_Iteration(TreeNode root)
    {
        List<int> list = IterativeInOrder(root);
        var result = int.MaxValue;

        for (var i = 0; i < list.Count - 1; i++)
        {
            result = Math.Min(result, Math.Abs(list[i] - list[i + 1]));
        }
        return result;
    }

    private static List<int> IterativeInOrder(TreeNode root)
    {
        Stack<TreeNode> stack = [];
        List<int> list = [];
        var curr = root;

        while (stack.Count != 0 || curr != null)
        {
            if (curr != null)
            {
                stack.Push(curr);
                curr = curr.Left;
            }
            else
            {
                curr = stack.Pop();
                list.Add(curr.Val);
                curr = curr.Right;
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

        if (root.Val <= small || root.Val >= large) return false;

        var left = IsValidBST_DFS(root.Left, small, root.Val);
        var right = IsValidBST_DFS(root.Right, root.Val, large);
        return left && right;
    }

    public static bool IsValidBST_Iteration(TreeNode root)
    {
        Stack<State> stack = [];
        stack.Push(new State(root, long.MinValue, long.MaxValue));

        while (stack.Count != 0)
        {
            var state = stack.Pop();
            var node = state.node;
            var small = state.small;
            var large = state.large;

            if (small >= node.Val || node.Val >= large)
            {
                return false;
            }

            if (node.Left != null)
            {
                stack.Push(new State(node.Left, small, node.Val));
            }
            if (node.Right != null)
            {
                stack.Push(new State(node.Right, node.Val, large));
            }
        }

        return true;
    }

    // https://leetcode.com/problems/insert-into-a-binary-search-tree/description/
    public static TreeNode? InsertIntoBST(TreeNode? root, int val)
    {
        if (root == null) return root;

        if (root.Val >= val)
        {
            if (root.Left != null)
            {
                InsertIntoBST(root.Left, val);
            }
            else
            {
                root.Left = new TreeNode(val);
            }
        }
        if (root.Val < val)
        {
            if (root.Right != null)
            {
                InsertIntoBST(root.Right, val);
            }
            else
            {
                root.Right = new TreeNode(val);
            }
        }

        return root;
    }

    // https://leetcode.com/problems/closest-binary-search-tree-value/description/
    public static int ClosestValue(TreeNode? root, double target)
    {
        if (root == null) return 0;
        var result = root.Val;
        var min = Math.Abs(target - result);
        const double epsilon = 1e-9;

        while (root != null)
        {
            var temp = Math.Abs(target - root.Val);

            if (temp < min || (Math.Abs(temp - min) < epsilon && root.Val < result))
            {
                min = temp;
                result = root.Val;
            }

            root = target < root.Val ? root.Left : root.Right;
        }

        return result;
    }
}
