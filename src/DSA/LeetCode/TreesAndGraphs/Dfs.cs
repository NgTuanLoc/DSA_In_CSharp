namespace DSA.LeetCode.TreesAndGraphs;
// !DFS
public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
{
    public readonly int Val = val;
    public TreeNode? Left = left;
    public TreeNode? Right = right;
}

public class Pair<T>(TreeNode node, T value)
{
    // Some value needs to be saved for next layer verification
    public readonly T Value = value;
    public readonly TreeNode Node = node;

    // Keep track the value that need to compare for each iteration layer
}

public class BinaryTreeDeptFirstSearch
{
    public static void DFS_PreOrder(TreeNode? node)
    {
        if (node == null) return;
        Console.WriteLine(node.Val);
        DFS_PreOrder(node.Left);
        DFS_PreOrder(node.Right);
    }

    public static void DFS_InOrder(TreeNode? node)
    {
        if (node == null) return;
        DFS_InOrder(node.Left);
        Console.WriteLine(node.Val);
        DFS_InOrder(node.Right);
    }
    public static void DFS_PostOrder(TreeNode? node)
    {
        if (node == null) return;
        DFS_PostOrder(node.Left);
        DFS_PostOrder(node.Right);
        Console.WriteLine(node.Val);
    }

    public static int MaxDepth(TreeNode? root)
    {
        // https://leetcode.com/problems/maximum-depth-of-binary-tree/
        if (root == null) return 0;

        var leftValue = MaxDepth(root.Left);
        var rightValue = MaxDepth(root.Right);
        return 1 + Math.Max(leftValue, rightValue);
    }

    public static int MaxDepth_Iteration(TreeNode node)
    {
        // The "value" in Pair class now is the depth
        Pair<int> pair = new(node, 1);
        Stack<Pair<int>> stack = [];
        stack.Push(pair);
        var maxLength = 0;

        while (stack.Count != 0)
        {
            var currPair = stack.Pop();
            maxLength = Math.Max(maxLength, currPair.Value);
            if (currPair.Node.Right != null)
            {
                Pair<int> right = new(currPair.Node.Right, currPair.Value + 1);
                stack.Push(right);
            }

            if (currPair.Node.Left == null) continue;
            Pair<int> left = new(currPair.Node.Left, currPair.Value + 1);
            stack.Push(left);
        }
        return maxLength;
    }

    public static bool HasPathSum(TreeNode? root, int targetSum)
    {
        // https://leetcode.com/problems/path-sum/description/
        if (root == null) return false;

        var curr = targetSum - root.Val;
        if (root.Left == null && root.Right == null) return curr == 0;

        var left = HasPathSum(root.Left, curr);
        var right = HasPathSum(root.Right, curr);
        return left || right;
    }

    public static bool HasPathSum_Iteration(TreeNode root, int targetSum)
    {
        // https://leetcode.com/problems/path-sum/description/
        Pair<int> pair = new(root, root.Val);
        Stack<Pair<int>> stack = [];
        stack.Push(pair);

        while (stack.Count != 0)
        {
            var currPair = stack.Pop();
            if (currPair.Node.Left == null && currPair.Node.Right == null && currPair.Value + currPair.Node.Val == targetSum) return true;

            if (currPair.Node.Left != null)
            {
                stack.Push(new Pair<int>(currPair.Node.Left, currPair.Value + currPair.Node.Val));
            }
            if (currPair.Node.Right != null)
            {
                stack.Push(new Pair<int>(currPair.Node.Right, currPair.Value + currPair.Node.Val));
            }
        }

        return false;
    }

    public static int GoodNodes(TreeNode root)
    {
        // https://leetcode.com/problems/count-good-nodes-in-binary-tree/description/
        return DFS_GoodNodes(root, int.MinValue);
    }

    private static int DFS_GoodNodes(TreeNode? root, int maxSoFar)
    {
        if (root == null) return 0;

        var left = DFS_GoodNodes(root.Left, Math.Max(maxSoFar, root.Val));
        var right = DFS_GoodNodes(root.Right, Math.Max(maxSoFar, root.Val));

        var result = left + right;

        if (root.Val >= maxSoFar) result += 1;

        return result;
    }

    public static int GoodNodes_Iteration(TreeNode root)
    {
        // The "value" in Pair class now is the maxSoFar
        Stack<Pair<int>> stack = [];
        var count = 0;
        Pair<int> pair = new(root, int.MinValue);
        stack.Push(pair);

        while (stack.Count != 0)
        {
            var currPair = stack.Pop();
            int maxSoFar = currPair.Value;

            if (currPair.Node.Val >= maxSoFar) count++;

            if (currPair.Node.Left != null)
            {
                stack.Push(new Pair<int>(currPair.Node.Left, Math.Max(maxSoFar, currPair.Node.Val)));
            }
            if (currPair.Node.Right != null)
            {
                stack.Push(new Pair<int>(currPair.Node.Right, Math.Max(maxSoFar, currPair.Node.Val)));
            }
        }

        return count;
    }

    public static bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        // https://leetcode.com/problems/same-tree/description/
        if (p == null && q == null) return true;
        if (p == null || q == null) return false;

        var left = IsSameTree(p.Left, q.Left);
        var right = IsSameTree(p.Right, q.Right);

        return left && right && p.Val == q.Val;
    }

    public static TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode p, TreeNode q)
    {
        // https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
        if (root == null) return null;
        if (root == p || root == q) return root;

        var left = LowestCommonAncestor(root.Left, p, q);
        var right = LowestCommonAncestor(root.Right, p, q);

        if (left != null && right != null) return root;
        return left ?? right;
    }

    public static int MinDepth(TreeNode? root)
    {
        // https://leetcode.com/problems/minimum-depth-of-binary-tree/description/
        if (root == null) return 0;
        if (root.Left == null && root.Right == null) return 1;
        if (root.Right == null) return MinDepth(root.Left) + 1;
        if (root.Left == null) return MinDepth(root.Right) + 1;

        return Math.Min(MinDepth(root.Left), MinDepth(root.Right)) + 1;
    }

    public static int MaxAncestorDiff(TreeNode root)
    {
        // https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/
        return FindMaxAncestorDiff(root, root.Val, root.Val);
    }

    private static int FindMaxAncestorDiff(TreeNode? root, int minAncestor, int maxAncestor)
    {
        if (root == null) return 0;

        var currDiff = Math.Max(Math.Abs(root.Val - minAncestor), Math.Abs(root.Val - maxAncestor));
        var currMinAncestor = Math.Min(minAncestor, root.Val);
        var currMaxAncestor = Math.Max(maxAncestor, root.Val);

        var leftDiff = FindMaxAncestorDiff(root.Left, currMinAncestor, currMaxAncestor);
        var rightDiff = FindMaxAncestorDiff(root.Right, currMinAncestor, currMaxAncestor);

        return Math.Max(currDiff, Math.Max(leftDiff, rightDiff));
    }

    private int _diameter;
    public int DiameterOfBinaryTree(TreeNode? root)
    {
        // https://leetcode.com/problems/diameter-of-binary-tree/description/
        _diameter = 0;
        FindDiameterOfBinaryTree(root);
        return _diameter;
    }

    private int FindDiameterOfBinaryTree(TreeNode? root)
    {
        // https://leetcode.com/problems/diameter-of-binary-tree/description/
        if (root == null) return 0;

        var leftPath = FindDiameterOfBinaryTree(root.Left);
        var rightPath = FindDiameterOfBinaryTree(root.Right);

        _diameter = Math.Max(_diameter, leftPath + rightPath);

        return Math.Max(leftPath, rightPath) + 1;
    }
}
