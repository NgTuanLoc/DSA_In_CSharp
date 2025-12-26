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

        // int GoodNodes(TreeNode node)
        // {
        //     return GoodNodeDfs(node, int.MinValue);
        // }
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
        // // !Range Sum of BST
        // Console.WriteLine(BinarySearchTree.RangeSumBST(root, 7, 15));
        // Console.WriteLine(BinarySearchTree.RangeSumBST_Iteration(root, 8, 17));

        // // !Minimum Absolute Difference in BST
        // Console.WriteLine(BinarySearchTree.GetMinimumDifference(root));
        // Console.WriteLine(BinarySearchTree.GetMinimumDifference_Iteration(root));

        // // !Validate BST
        // Console.WriteLine(BinarySearchTree.IsValidBST(root));
        // Console.WriteLine(BinarySearchTree.IsValidBST_Iteration(root));

        // // !Insert into a BST
        // BinarySearchTree.InsertIntoBST(root, 5);
        // Utils.PrintBinaryTree(root);

        // // !ClosestValue
        // Console.WriteLine(BinarySearchTree.ClosestValue(Utils.BuildBinaryTree([4, 2, 5, 1, 3]), 3.714286));
        // Console.WriteLine(BinarySearchTree.ClosestValue(Utils.BuildBinaryTree([1]), 4.428571));
        // Console.WriteLine(BinarySearchTree.ClosestValue(Utils.BuildBinaryTree([1, null, 2]), 3.428571));
        // Console.WriteLine(BinarySearchTree.ClosestValue(Utils.BuildBinaryTree([4, 2, 5, 1, 3]), 4.428571));
    }

    public static void Run_Graph_DFS()
    {
        // !Number of Provinces
        // Console.WriteLine(new GraphDfsFindCircleNum().FindCircleNum([[1, 1, 0], [1, 1, 0], [0, 0, 1]]));
        // Console.WriteLine(new GraphDfsFindCircleNum().FindCircleNum([[1, 0, 0], [0, 1, 0], [0, 0, 1]]));

        // !Number of Islands
        //         Console.WriteLine(new GraphDfsNumIslands().NumIslands([
        //             ['1','1','1','1','0'],
        //             ['1','1','0','1','0'],
        //             ['1','1','0','0','0'],
        //             ['0','0','0','0','0']
        // ]));
        //         Console.WriteLine(new GraphDfsNumIslands().NumIslands([
        //             ['1','1','0','0','0'],
        //             ['1','1','0','0','0'],
        //             ['0','0','1','0','0'],
        //             ['0','0','0','1','1']
        // ]));

        // !Reorder Routes to Make All Paths Lead to the City Zero
        // Console.WriteLine(new MinReorderToTheCityZero().MinReorder(6, [[0, 1], [1, 3], [2, 3], [4, 0], [4, 5]]));
        // Console.WriteLine(new MinReorderToTheCityZero().MinReorder(5, [[1, 0], [1, 2], [3, 2], [3, 4]]));
        // Console.WriteLine(new MinReorderToTheCityZero().MinReorder(3, [[1, 0], [2, 0]]));

        // !Keys and Rooms
        // Console.WriteLine(new KeysAndRooms().CanVisitAllRooms([[1], [2], [3], []]));
        // Console.WriteLine(new KeysAndRooms().CanVisitAllRooms([[1, 3], [3, 0, 1], [2], [0]]));

        // !Minimum Number of Vertices to Reach All Nodes
        // Console.WriteLine(string.Join(",", new MiniumNumberOfVerticesToReachAllNodes().FindSmallestSetOfVertices(6, [[0, 1], [0, 2], [2, 5], [3, 4], [4, 2]])));
        // Console.WriteLine(string.Join(",", new MiniumNumberOfVerticesToReachAllNodes().FindSmallestSetOfVertices(5, [[0, 1], [2, 1], [3, 1], [1, 4], [2, 4]])));
        // Console.WriteLine(string.Join(",", MiniumNumberOfVerticesToReachAllNodes.FindSmallestSetOfVerticesWithInDegreeApproach(6, [[0, 1], [0, 2], [2, 5], [3, 4], [4, 2]])));
        // Console.WriteLine(string.Join(",", MiniumNumberOfVerticesToReachAllNodes.FindSmallestSetOfVerticesWithInDegreeApproach(5, [[0, 1], [2, 1], [3, 1], [1, 4], [2, 4]])));

        // !Find if Path Exists in Graph
        // Console.WriteLine(new FindExistedPathInGraph().ValidPath(3, [[0, 1], [1, 2], [2, 0]], 0, 2));
        // Console.WriteLine(new FindExistedPathInGraph().ValidPath(6, [[0, 1], [0, 2], [3, 5], [5, 4], [4, 3]], 0, 5));

        // !Number Of Connected Components In An Undirected Graph
        // Console.WriteLine(new ConnectedComponentsInAUnDirectedGraph().CountComponents(5, [[0, 1], [1, 2], [3, 4]]));
        // Console.WriteLine(new ConnectedComponentsInAUnDirectedGraph().CountComponents(5, [[0, 1], [1, 2], [2, 3], [3, 4]]));

        // !Max Area of Island
        // Console.WriteLine(new MaxAreaOfIslandSolution().MaxAreaOfIsland([[0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0], [0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0], [0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0], [0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0], [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0]]));
        // Console.WriteLine(new MaxAreaOfIslandSolution().MaxAreaOfIsland([[0, 0, 0, 0, 0, 0, 0, 0]]));

        // !Reachable Nodes With Restrictions
        Console.WriteLine(new ReachableNodesWithRestrictions().ReachableNodes(7, [[0, 1], [1, 2], [3, 1], [4, 0], [0, 5], [5, 6]], [4, 5]));
        Console.WriteLine(new ReachableNodesWithRestrictions().ReachableNodes(7, [[0, 1], [0, 2], [0, 5], [0, 4], [3, 2], [6, 5]], [4, 2, 1]));
        Console.WriteLine(new ReachableNodesWithRestrictions().ReachableNodes(2, [[0, 1]], [1]));
    }
}

