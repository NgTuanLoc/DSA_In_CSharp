namespace DSA.LeetCode.TreesAndGraphs;
// !DFS
public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Pair<T>
{
    // Some value need to be save for next layer verification
    public T value;
    public TreeNode node;

    public Pair(TreeNode node, T value)
    {
        // Keep track the value that need to compare for each iteration layer
        this.value = value;
        this.node = node;
    }
}

public class BinaryTreeDeptFirstSearch
{
    public static void DFS_PreOrder(TreeNode? node)
    {
        if (node == null)
        {
            return;
        }
        Console.WriteLine(node.val);
        DFS_PreOrder(node.left);
        DFS_PreOrder(node.right);
        return;
    }

    public static void DFS_InOrder(TreeNode? node)
    {
        if (node == null)
        {
            return;
        }
        DFS_InOrder(node.left);
        Console.WriteLine(node.val);
        DFS_InOrder(node.right);
        return;
    }
    public static void DFS_PostOrder(TreeNode? node)
    {
        if (node == null)
        {
            return;
        }
        DFS_PostOrder(node.left);
        DFS_PostOrder(node.right);
        Console.WriteLine(node.val);
        return;
    }

    public static int MaxDepth(TreeNode? root)
    {
        // https://leetcode.com/problems/maximum-depth-of-binary-tree/
        if (root == null) return 0;

        int leftValue = MaxDepth(root.left);
        int rightValue = MaxDepth(root.right);
        return 1 + Math.Max(leftValue, rightValue);
    }

    public static int MaxDepth_Iteration(TreeNode node)
    {
        // The "value" in Pair class now is the depth
        Pair<int> pair = new(node, 1);
        Stack<Pair<int>> stack = [];
        stack.Push(pair);
        int maxLength = 0;

        while (stack.Count != 0)
        {
            Pair<int> currPair = stack.Pop();
            maxLength = Math.Max(maxLength, currPair.value);
            Console.WriteLine(currPair.node.val);
            if (currPair.node.right != null)
            {
                Pair<int> right = new(currPair.node.right, currPair.value + 1);
                stack.Push(right);
            }

            if (currPair.node.left != null)
            {
                Pair<int> left = new(currPair.node.left, currPair.value + 1);
                stack.Push(left);
            }
        }
        return maxLength;
    }

    public static bool HasPathSum(TreeNode? root, int targetSum)
    {
        // https://leetcode.com/problems/path-sum/description/
        if (root == null) return false;

        int curr = targetSum - root.val;
        if (root.left == null && root.right == null) return curr == 0;

        bool left = HasPathSum(root.left, curr);
        bool right = HasPathSum(root.right, curr);
        return left || right;
    }

    public static bool HasPathSum_Iteration(TreeNode root, int targetSum)
    {
        // https://leetcode.com/problems/path-sum/description/
        Pair<int> pair = new(root, root.val);
        Stack<Pair<int>> stack = [];
        stack.Push(pair);

        while (stack.Count != 0)
        {
            var currPair = stack.Pop();
            if (currPair.node.left == null && currPair.node.right == null && currPair.value + currPair.node.val == targetSum) return true;

            if (currPair.node.left != null)
            {
                stack.Push(new Pair<int>(currPair.node.left, currPair.value + currPair.node.val));
            }
            if (currPair.node.right != null)
            {
                stack.Push(new Pair<int>(currPair.node.right, currPair.value + currPair.node.val));
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

        int left = DFS_GoodNodes(root.left, Math.Max(maxSoFar, root.val));
        int right = DFS_GoodNodes(root.right, Math.Max(maxSoFar, root.val));

        int result = left + right;

        if (root.val >= maxSoFar) result += 1;

        return result;
    }

    public static int GoodNodes_Iteration(TreeNode root)
    {
        // The "value" in Pair class now is the maxSoFar
        Stack<Pair<int>> stack = [];
        int count = 0;
        Pair<int> pair = new(root, int.MinValue);
        stack.Push(pair);

        while (stack.Count != 0)
        {
            var currPair = stack.Pop();
            int maxSoFar = currPair.value;

            if (currPair.node.val >= maxSoFar) count++;

            if (currPair.node.left != null)
            {
                stack.Push(new Pair<int>(currPair.node.left, Math.Max(maxSoFar, currPair.node.val)));
            }
            if (currPair.node.right != null)
            {
                stack.Push(new Pair<int>(currPair.node.right, Math.Max(maxSoFar, currPair.node.val)));
            }
        }

        return count;
    }

    public static bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        // https://leetcode.com/problems/same-tree/description/
        if (p == null && q == null) return true;
        if (p == null || q == null) return false;

        bool left = IsSameTree(p.left, q.left);
        bool right = IsSameTree(p.right, q.right);

        return left && right && p.val == q.val;
    }

    public static TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode p, TreeNode q)
    {
        // https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
        if (root == null) return null;
        if (root == p || root == q) return root;

        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);

        if (left != null && right != null) return root;
        if (left != null) return left;

        return right;
    }

    public static int MinDepth(TreeNode? root)
    {
        // https://leetcode.com/problems/minimum-depth-of-binary-tree/description/
        if (root == null) return 0;
        if (root.left == null && root.right == null) return 1;
        if (root.right == null) return MinDepth(root.left) + 1;
        if (root.left == null) return MinDepth(root.right) + 1;

        return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
    }

    public static int MaxAncestorDiff(TreeNode root)
    {
        // https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/
        return FindMaxAncestorDiff(root, root.val, root.val);
    }

    private static int FindMaxAncestorDiff(TreeNode? root, int minAncestor, int maxAncestor)
    {
        if (root == null) return 0;

        int currDiff = Math.Max(Math.Abs(root.val - minAncestor), Math.Abs(root.val - maxAncestor));
        int currMinAncestor = Math.Min(minAncestor, root.val);
        int currMaxAncestor = Math.Max(maxAncestor, root.val);

        int leftDiff = FindMaxAncestorDiff(root.left, currMinAncestor, currMaxAncestor);
        int rightDiff = FindMaxAncestorDiff(root.right, currMinAncestor, currMaxAncestor);

        return Math.Max(currDiff, Math.Max(leftDiff, rightDiff));
    }

    private int diameter;
    public int DiameterOfBinaryTree(TreeNode? root)
    {
        // https://leetcode.com/problems/diameter-of-binary-tree/description/
        diameter = 0;
        FindDiameterOfBinaryTree(root);
        return diameter;
    }

    public int FindDiameterOfBinaryTree(TreeNode? root)
    {
        // https://leetcode.com/problems/diameter-of-binary-tree/description/
        if (root == null) return 0;

        int leftPath = FindDiameterOfBinaryTree(root.left);
        int rightPath = FindDiameterOfBinaryTree(root.right);

        diameter = Math.Max(diameter, leftPath + rightPath);

        return Math.Max(leftPath, rightPath) + 1;
    }
}
