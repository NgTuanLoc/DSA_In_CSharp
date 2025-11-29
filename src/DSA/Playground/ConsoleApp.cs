namespace DSA.Playground;

public static class ConsoleApp
{
    public static void Run()
    {
        Console.WriteLine("Test Console App");
        // var root = BuildBinaryTree([0, 1, 2, 3, 4, null, 5, 6, null, 7, 8]);
        // Bfs(root);
        // Console.WriteLine();
        // Bfs_Recursive(root);
        // Console.WriteLine();
        // PreOrder(root);
        // Console.WriteLine();
        // InOrder(root);
        // Console.WriteLine();
        // PostOrder(root);
        // Console.WriteLine();

        // var root1 = BuildBinaryTree([3,9,20,null,null,15,7]);
        var root2 = BuildBinaryTree([2,null,3,null,4,null,5,null,6]);
        // Console.WriteLine(MinDepth(root1));
        Console.WriteLine(MinDepth(root2));
        Bfs(root2);
    }

    private static void Bfs(TreeNode? root)
    {
        if (root is null) return;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            var node = queue.Dequeue();
            Console.Write($"{node.Value}  ");
            
            if(node.Left != null) queue.Enqueue(node.Left);
            if(node.Right != null) queue.Enqueue(node.Right);
        }
    }

    private static void Bfs_Recursive(TreeNode? root)
    {
        if (root is null) return;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        Bfs_Recursion(queue);
    }

    private static void Bfs_Recursion(Queue<TreeNode> queue)
    {
        if (queue.Count == 0) return;

        var node = queue.Dequeue();
        Console.Write($"{node.Value}  ");
        
        if(node.Left is not null) queue.Enqueue(node.Left);
        if(node.Right is not null) queue.Enqueue(node.Right);
        Bfs_Recursion(queue);
    }

    private static void PreOrder(TreeNode? root)
    {
        if (root is null) return;
        
        Console.Write($"{root.Value}  ");
        PreOrder(root.Left);
        PreOrder(root.Right);
    }

    private static void InOrder(TreeNode? root)
    {
        if (root is null) return;

        InOrder(root.Left);
        Console.Write($"{root.Value}  ");
        InOrder(root.Right);
    }

    private static void PostOrder(TreeNode? root)
    {
        if (root is null) return;
        
        PostOrder(root.Left);
        PostOrder(root.Right);
        Console.Write($"{root.Value}  ");
    }

    private static TreeNode? BuildBinaryTree(List<int?> arr)
    {
        if (arr == null || arr.Count == 0)
            throw new ArgumentException("Input array cannot be null or empty.");

        // Root
        if (arr[0] == null) return null;
        var root = new TreeNode(arr[0]!.Value);

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        var i = 1;
        while (i < arr.Count && queue.Count > 0)
        {
            var current = queue.Dequeue();

            // Left child
            if (i < arr.Count && arr[i] != null)
            {
                current.Left = new TreeNode(arr[i]!.Value);
                queue.Enqueue(current.Left);
            }
            i++;

            // Right child
            if (i < arr.Count && arr[i] != null)
            {
                current.Right = new TreeNode(arr[i]!.Value);
                queue.Enqueue(current.Right);
            }
            i++;
        }

        return root;
    }

    private static int MinDepth(TreeNode? root)
    {
        if (root is null) return 0;
        if (root.Left is null && root.Right is null) return 1;
        if (root.Right is null) return MinDepth(root.Left) + 1;
        if (root.Left is null) return MinDepth(root.Right) + 1;

        return Math.Min(MinDepth(root.Left), MinDepth(root.Right)) + 1;
    }
}


public class TreeNode
{
    public int Value { get; set; } = 0;
    public TreeNode? Left { get; set; } = null;
    public TreeNode? Right { get; set; } = null;

    public TreeNode(int value)
    {
        Value = value;
    }
}