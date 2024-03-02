using DSA.LeetCode.TreesAndGraphs;

namespace DSA;

public class BFS
{
    public static void PrintAllNodes(TreeNode root)
    {
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            var curr = queue.Dequeue();
            Console.WriteLine(curr.val);
            if (curr.left != null) queue.Enqueue(curr.left);
            if (curr.right != null) queue.Enqueue(curr.right);
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
            int prev = 0;
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var currNode = queue.Dequeue();
                prev = currNode.val;
                if (currNode.left != null) queue.Enqueue(currNode.left);
                if (currNode.right != null) queue.Enqueue(currNode.right);
            }
            result.Add(prev);
        }

        return result;
    }

    public static IList<int> LargestValues(TreeNode root)
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
                if (temp < curr.val) temp = curr.val;

                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
            }
            result.Add(temp);
        }

        return result;
    }

    public static int DeepestLeavesSum(TreeNode root)
    {
        // https://leetcode.com/problems/deepest-leaves-sum/description/
        Queue<TreeNode> queue = [];
        int result = 0;

        if (root == null) return result;

        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            int size = queue.Count;
            bool isTheLastLevel = true;
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                var curr = queue.Dequeue();
                sum += curr.val;
                if (curr.left != null)
                {
                    queue.Enqueue(curr.left);
                    isTheLastLevel = false;
                }
                if (curr.right != null)
                {
                    queue.Enqueue(curr.right);
                    isTheLastLevel = false;
                }
                if (isTheLastLevel) result = sum;
            }
        }

        return result;
    }

    public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        // https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
        IList<IList<int>> result = [];
        bool isReverse = false;
        if (root == null) return result;

        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            int size = queue.Count;
            IList<int> level = [];

            for (int i = 0; i < size; i++)
            {
                var currNode = queue.Dequeue();

                if (currNode.left != null) queue.Enqueue(currNode.left);
                if (currNode.right != null) queue.Enqueue(currNode.right);

                level.Add(currNode.val);
            }
            if (isReverse) level = level.Reverse<int>().ToList();

            result.Add(level);
            isReverse = !isReverse;
        }

        return result;
    }
}
