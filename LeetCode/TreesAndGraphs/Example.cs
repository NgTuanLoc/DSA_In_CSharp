namespace DSA.LeetCode.TreesAndGraphs;

public class TreesAndGraphsExample
{
    public static void Run()
    {
        // !Initialize a tree
        // Creating nodes for the binary tree
        // TreeNode root = new(0);
        // TreeNode node1 = new(1);
        // TreeNode node2 = new(2);
        // TreeNode node3 = new(3);
        // TreeNode node4 = new(4);
        // TreeNode node5 = new(5);
        // TreeNode node6 = new(6);

        // // Connecting nodes to build the binary tree
        // root.left = node1;
        // root.right = node2;
        // node1.left = node3;
        // node1.right = node4;
        // node4.right = node6;
        // node2.right = node5;

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

        // Console.WriteLine(BinaryTreeDeptFirstSearch.GoodNodes(root));
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
        TreeNode rootA = new(1);
        TreeNode node2 = new(2);
        TreeNode node3 = new(3);
        TreeNode node4 = new(4);
        TreeNode node5 = new(5);

        rootA.left = node2;
        rootA.right = node3;

        node2.left = node4;
        node2.right = node5;

        BinaryTreeDeptFirstSearch n = new();

        Console.WriteLine(n.DiameterOfBinaryTree(rootA));
    }
}
