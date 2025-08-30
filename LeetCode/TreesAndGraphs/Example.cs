namespace DSA.LeetCode.TreesAndGraphs;

public class TreesAndGraphsExample
{
    public static void Run_DFS()
    {
        // !Initialize a tree
        // Creating nodes for the binary tree
        TreeNode root = new(0);
        TreeNode node1 = new(1);
        TreeNode node2 = new(2);
        TreeNode node3 = new(3);
        TreeNode node4 = new(4);
        TreeNode node5 = new(5);
        TreeNode node6 = new(6);

        // // Connecting nodes to build the binary tree
        root.Left = node1;
        root.Right = node2;
        node1.Left = node3;
        node1.Right = node4;
        node4.Right = node6;
        node2.Right = node5;

        //                0
        //            /       \
        //           1         2
        //         /   \         \
        //        3     4         5
        //               \
        //                6


        // !Binary Tree Dept First Search
        // Console.WriteLine("=======PreOrder (Before Children)=======");
        // BinaryTreeDeptFirstSearch.DFS_PreOrder(root);
        // Console.WriteLine("=======InOrder======= (In The Middle Of Children)");
        // BinaryTreeDeptFirstSearch.DFS_InOrder(root);
        // Console.WriteLine("=======PostOrder======= (After Children)");
        // BinaryTreeDeptFirstSearch.DFS_PostOrder(root);
        
        // Console.WriteLine(BinaryTreeDeptFirstSearch.MaxDepth(root));
        // Console.WriteLine(BinaryTreeDeptFirstSearch.MaxDepth_Iteration(root));
        // System.Console.WriteLine("========");

        // Console.WriteLine(BinaryTreeDeptFirstSearch.HasPathSum(root, 4));
        // Console.WriteLine(BinaryTreeDeptFirstSearch.HasPathSum_Iteration(root, 4));

        int GoodNodeDfs(TreeNode? node, int maxSoFar)
        {
            if (node is null) return 0;

            var left = GoodNodeDfs(node.Left, Math.Max(maxSoFar, node.Val));
            var right = GoodNodeDfs(node.Right, Math.Max(maxSoFar, node.Val));

            var result = left + right;

            if (node.Val >= maxSoFar) return result + 1;
            
            return result;
        }
        
        Console.WriteLine(GoodNodes(root));
        Console.WriteLine(BinaryTreeDeptFirstSearch.GoodNodes(root));
        // Console.WriteLine(BinaryTreeDeptFirstSearch.GoodNodes_Iteration(root));

        // !Same Tree
        // TreeNode rootA = new(1);
        // TreeNode rootB = new(1);
        // TreeNode nodeA_2 = new(2);
        // TreeNode nodeA_3 = new(3);
        // TreeNode nodeB_2 = new(2);
        // TreeNode nodeB_3 = new(3);

        // rootA.left = nodeA_2;
        // rootA.right = nodeA_3;

        // rootB.left = nodeB_2;
        // rootB.right = nodeB_3;
        // Console.WriteLine(BinaryTreeDeptFirstSearch.IsSameTree(rootA, rootB));

        // TreeNode rootC = new(1);
        // TreeNode rootD = new(1);
        // TreeNode nodeC_2 = new(2);
        // TreeNode nodeD_2 = new(2);
        // rootC.left = nodeC_2;
        // rootD.right = nodeD_2;
        // Console.WriteLine(BinaryTreeDeptFirstSearch.IsSameTree(rootC, rootD));

        // !Lowest Common Ancestor of a Binary Tree
        // TreeNode root = new(3);
        // TreeNode node0 = new(0);
        // TreeNode node1 = new(1);
        // TreeNode node2 = new(2);
        // TreeNode node3 = new(3);
        // TreeNode node4 = new(4);
        // TreeNode node5 = new(5);
        // TreeNode node6 = new(6);
        // TreeNode node7 = new(7);
        // TreeNode node8 = new(8);

        // root.left = node5;
        // root.right = node1;
        // node5.left = node6;
        // node5.right = node2;

        // node2.left = node7;
        // node2.right = node4;

        // node1.left = node0;
        // node1.right = node8;

        // Console.WriteLine(BinaryTreeDeptFirstSearch.LowestCommonAncestor(root, node5, node1)?.val);
        // Console.WriteLine(BinaryTreeDeptFirstSearch.LowestCommonAncestor(root, node5, node4)?.val);

        // !Minimum Depth of Binary Tree
        // TreeNode rootA = new(3);
        // TreeNode node9 = new(9);
        // TreeNode node20 = new(20);
        // TreeNode node15 = new(15);
        // TreeNode node7 = new(20);

        // rootA.left = node9;
        // rootA.right = node20;

        // node20.left = node15;
        // node20.right = node7;

        // TreeNode rootB = new(2);
        // TreeNode node3 = new(3);
        // TreeNode node4 = new(4);
        // TreeNode node5 = new(5);
        // TreeNode node6 = new(6);

        // rootB.right = node3;
        // node3.right = node4;
        // node4.right = node5;
        // node5.right = node6;
        // Console.WriteLine(BinaryTreeDeptFirstSearch.MinDepth(rootA));
        // Console.WriteLine(BinaryTreeDeptFirstSearch.MinDepth(rootB));

        // !Maximum Difference Between Node and Ancestor
        // TreeNode rootA = new(8);
        // TreeNode node3 = new(3);
        // TreeNode node10 = new(10);
        // TreeNode node1 = new(1);
        // TreeNode node6 = new(6);
        // TreeNode node14 = new(14);
        // TreeNode node4 = new(4);
        // TreeNode node7 = new(7);
        // TreeNode node13 = new(13);

        // rootA.left = node3;
        // rootA.right = node10;

        // node3.left = node1;
        // node3.right = node6;

        // node6.left = node4;
        // node6.right = node7;

        // node10.right = node14;
        // node14.left = node13;
        // Console.WriteLine(BinaryTreeDeptFirstSearch.MaxAncestorDiff(rootA));

        //!Diameter of Binary 
        // TreeNode rootA = new(1);
        // TreeNode node2 = new(2);
        // TreeNode node3 = new(3);
        // TreeNode node4 = new(4);
        // TreeNode node5 = new(5);

        // rootA.left = node2;
        // rootA.right = node3;

        // node2.left = node4;
        // node2.right = node5;

        // BinaryTreeDeptFirstSearch n = new();

        // Console.WriteLine(n.DiameterOfBinaryTree(rootA));

        int GoodNodes(TreeNode node)
        {
            return GoodNodeDfs(node, int.MinValue);
        }
    }

    public static void Run_BFS()
    {
        // !BFS
        // TreeNode root = new(0);
        // TreeNode node1 = new(1);
        // TreeNode node2 = new(2);
        // TreeNode node3 = new(3);
        // TreeNode node4 = new(4);
        // TreeNode node5 = new(5);
        // TreeNode node6 = new(6);
        // TreeNode node7 = new(7);
        // TreeNode node8 = new(8);

        // root.left = node1;
        // root.right = node2;

        // node1.left = node3;
        // node1.right = node4;

        // node3.left = node6;

        // node4.left = node7;
        // node4.right = node8;

        // node2.right = node5;

        // BFS.PrintAllNodes(root);

        // !Binary Tree Right Side View
        // var result = BFS.RightSideView(root);
        // foreach (var item in result)
        // {
        //     Console.Write($"{item}  ");
        // }

        // !Find Largest Value in Each Tree Row
        // var result = BFS.LargestValues(root);
        // foreach (var item in result)
        // {
        //     Console.Write($"{item}  ");
        // }

        // !Get Deepest Leaves Sum
        // Console.WriteLine(BFS.DeepestLeavesSum(root));

        // !Binary Tree Zigzag Level Order Traversal
        // var result = BFS.ZigzagLevelOrder(root);

        // foreach (var level in result)
        // {
        //     Console.WriteLine();
        //     foreach (var item in level)
        //     {
        //         Console.Write($"{item} ");
        //     }
        //     Console.WriteLine();
        // }
    }

    public static void Run_BinarySearchTree()
    {
        // !Initialize Binary Search Tree
        TreeNode root = new(23);
        TreeNode node8 = new(8);
        TreeNode node37 = new(37);
        TreeNode node6 = new(6);
        TreeNode node17 = new(17);
        TreeNode node29 = new(29);
        TreeNode node50 = new(50);
        TreeNode node9 = new(9);
        TreeNode node20 = new(20);

        root.Left = node8;
        root.Right = node37;

        node8.Left = node6;
        node8.Right = node17;

        node37.Left = node29;
        node37.Right = node50;

        node17.Left = node9;
        node17.Right = node20;

        // !Range Sum of BST
        // Console.WriteLine(BinarySearchTree.RangeSumBST(root, 8, 17));
        // Console.WriteLine(BinarySearchTree.RangeSumBST_Iteration(root, 8, 17));

        // !Minimum Absolute Difference in BST
        // Console.WriteLine(BinarySearchTree.GetMinimumDifference(root));
        // Console.WriteLine(BinarySearchTree.GetMinimumDifference_Iteration(root));

        // !Validate BST
        Console.WriteLine(BinarySearchTree.IsValidBST(root));
        Console.WriteLine(BinarySearchTree.IsValidBST_Iteration(root));
    }
}
