namespace DSA.LeetCode.TreesAndGraphs;

public static class Bfs
{
    public static void PrintAllNodes(TreeNode root)
    {
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var curr = queue.Dequeue();
            if (curr.Left != null) queue.Enqueue(curr.Left);
            if (curr.Right != null) queue.Enqueue(curr.Right);
        }
    }

    public static IList<int> RightSideView(TreeNode? root)
    {
        IList<int> result = [];

        if (root == null) return result;

        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            var prev = 0;
            var size = queue.Count;
            for (var i = 0; i < size; i++)
            {
                var currNode = queue.Dequeue();
                prev = currNode.Val;
                if (currNode.Left != null) queue.Enqueue(currNode.Left);
                if (currNode.Right != null) queue.Enqueue(currNode.Right);
            }
            result.Add(prev);
        }

        return result;
    }

    public static IList<int> LargestValues(TreeNode? root)
    {
        // https://leetcode.com/problems/find-largest-value-in-each-tree-row/
        IList<int> result = [];

        if (root == null) return result;

        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            int size = queue.Count;
            int temp = int.MinValue;
            for (int i = 0; i < size; i++)
            {
                var curr = queue.Dequeue();
                if (temp < curr.Val) temp = curr.Val;

                if (curr.Left != null) queue.Enqueue(curr.Left);
                if (curr.Right != null) queue.Enqueue(curr.Right);
            }
            result.Add(temp);
        }

        return result;
    }

    public static int DeepestLeavesSum(TreeNode? root)
    {
        // https://leetcode.com/problems/deepest-leaves-sum/description/
        Queue<TreeNode> queue = [];
        var result = 0;

        if (root == null) return result;

        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            var size = queue.Count;
            var isTheLastLevel = true;
            var sum = 0;

            for (var i = 0; i < size; i++)
            {
                var curr = queue.Dequeue();
                sum += curr.Val;
                if (curr.Left != null)
                {
                    queue.Enqueue(curr.Left);
                    isTheLastLevel = false;
                }
                if (curr.Right != null)
                {
                    queue.Enqueue(curr.Right);
                    isTheLastLevel = false;
                }
                if (isTheLastLevel) result = sum;
            }
        }

        return result;
    }

    public static IList<IList<int>> ZigzagLevelOrder(TreeNode? root)
    {
        // https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
        IList<IList<int>> result = [];
        var isReverse = false;
        if (root == null) return result;

        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            var size = queue.Count;
            List<int> level = [];

            for (var i = 0; i < size; i++)
            {
                var currNode = queue.Dequeue();

                if (currNode.Left != null) queue.Enqueue(currNode.Left);
                if (currNode.Right != null) queue.Enqueue(currNode.Right);

                level.Add(currNode.Val);
            }
            if (isReverse) level = level.Reverse<int>().ToList();

            result.Add(level);
            isReverse = !isReverse;
        }

        return result;
    }
}
