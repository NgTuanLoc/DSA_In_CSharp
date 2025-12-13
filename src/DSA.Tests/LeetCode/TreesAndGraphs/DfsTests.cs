using DSA;
using DSA.LeetCode.TreesAndGraphs;

namespace DSA.Tests.LeetCode.TreesAndGraphs;

public class DfsTests
{
    #region MaxDepth Tests

    /// <summary>
    /// Tests MaxDepth with balanced tree.
    /// https://leetcode.com/problems/maximum-depth-of-binary-tree/
    /// Pattern: DFS recursion - calculate depth from each subtree
    /// </summary>
    [Fact]
    public void MaxDepth_WithBalancedTree_ReturnsCorrectDepth()
    {
        var root = Utils.BuildBinaryTree([3, 9, 20, null, null, 15, 7]);

        var result = BinaryTreeDeptFirstSearch.MaxDepth(root);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests MaxDepth with null root.
    /// </summary>
    [Fact]
    public void MaxDepth_WithNullRoot_ReturnsZero()
    {
        var result = BinaryTreeDeptFirstSearch.MaxDepth(null);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests MaxDepth with single node.
    /// </summary>
    [Fact]
    public void MaxDepth_WithSingleNode_ReturnsOne()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = BinaryTreeDeptFirstSearch.MaxDepth(root);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests MaxDepth with left-skewed tree.
    /// </summary>
    [Fact]
    public void MaxDepth_WithLeftSkewedTree_ReturnsCorrectDepth()
    {
        var root = Utils.BuildBinaryTree([1, 2, null, 3, null, 4]);

        var result = BinaryTreeDeptFirstSearch.MaxDepth(root);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests MaxDepth with right-skewed tree.
    /// </summary>
    [Fact]
    public void MaxDepth_WithRightSkewedTree_ReturnsCorrectDepth()
    {
        var root = Utils.BuildBinaryTree([1, null, 2, null, 3, null, 4]);

        var result = BinaryTreeDeptFirstSearch.MaxDepth(root);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests MaxDepth_Iteration with balanced tree.
    /// </summary>
    [Fact]
    public void MaxDepth_Iteration_WithBalancedTree_ReturnsCorrectDepth()
    {
        var root = Utils.BuildBinaryTree([3, 9, 20, null, null, 15, 7]);

        var result = BinaryTreeDeptFirstSearch.MaxDepth_Iteration(root!);

        Assert.Equal(3, result);
    }

    #endregion

    #region HasPathSum Tests

    /// <summary>
    /// Tests HasPathSum with valid path.
    /// https://leetcode.com/problems/path-sum/description/
    /// Pattern: DFS - track running sum to leaf nodes
    /// </summary>
    [Fact]
    public void HasPathSum_WithValidPath_ReturnsTrue()
    {
        var root = Utils.BuildBinaryTree([5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1]);

        var result = BinaryTreeDeptFirstSearch.HasPathSum(root, 22);

        Assert.True(result);
    }

    /// <summary>
    /// Tests HasPathSum with no valid path.
    /// </summary>
    [Fact]
    public void HasPathSum_WithNoValidPath_ReturnsFalse()
    {
        var root = Utils.BuildBinaryTree([1, 2, 3]);

        var result = BinaryTreeDeptFirstSearch.HasPathSum(root, 5);

        Assert.False(result);
    }

    /// <summary>
    /// Tests HasPathSum with null root.
    /// </summary>
    [Fact]
    public void HasPathSum_WithNullRoot_ReturnsFalse()
    {
        var result = BinaryTreeDeptFirstSearch.HasPathSum(null, 0);

        Assert.False(result);
    }

    /// <summary>
    /// Tests HasPathSum with single node matching target.
    /// </summary>
    [Fact]
    public void HasPathSum_WithSingleNodeMatchingTarget_ReturnsTrue()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = BinaryTreeDeptFirstSearch.HasPathSum(root, 1);

        Assert.True(result);
    }

    /// <summary>
    /// Tests HasPathSum with single node not matching target.
    /// </summary>
    [Fact]
    public void HasPathSum_WithSingleNodeNotMatchingTarget_ReturnsFalse()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = BinaryTreeDeptFirstSearch.HasPathSum(root, 0);

        Assert.False(result);
    }

    /// <summary>
    /// Tests HasPathSum_Iteration with valid path.
    /// </summary>
    [Fact]
    public void HasPathSum_Iteration_WithValidPath_ReturnsTrue()
    {
        var root = Utils.BuildBinaryTree([5, 4, 8, 11, null, 13, 4, 7, 2]);

        var result = BinaryTreeDeptFirstSearch.HasPathSum_Iteration(root!, 22);

        Assert.True(result);
    }

    /// <summary>
    /// Tests HasPathSum with negative numbers.
    /// </summary>
    [Fact]
    public void HasPathSum_WithNegativeNumbers_ReturnsTrue()
    {
        var root = Utils.BuildBinaryTree([1, -2, -3, 1, 3, -2, null, -1]);

        var result = BinaryTreeDeptFirstSearch.HasPathSum(root, -1);

        Assert.True(result);
    }

    #endregion

    #region GoodNodes Tests

    /// <summary>
    /// Tests GoodNodes with basic tree.
    /// https://leetcode.com/problems/count-good-nodes-in-binary-tree/description/
    /// Pattern: DFS with state - track maximum value on path
    /// </summary>
    [Fact]
    public void GoodNodes_WithBasicTree_ReturnsCorrectCount()
    {
        var root = Utils.BuildBinaryTree([3, 1, 4, 3, null, 1, 5]);

        var result = BinaryTreeDeptFirstSearch.GoodNodes(root!);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests GoodNodes with all good nodes.
    /// </summary>
    [Fact]
    public void GoodNodes_WithAllGoodNodes_ReturnsAllNodes()
    {
        var root = Utils.BuildBinaryTree([3, 3, null, 4, 2]);

        var result = BinaryTreeDeptFirstSearch.GoodNodes(root!);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests GoodNodes with single node.
    /// </summary>
    [Fact]
    public void GoodNodes_WithSingleNode_ReturnsOne()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = BinaryTreeDeptFirstSearch.GoodNodes(root!);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests GoodNodes_Iteration with basic tree.
    /// </summary>
    [Fact]
    public void GoodNodes_Iteration_WithBasicTree_ReturnsCorrectCount()
    {
        var root = Utils.BuildBinaryTree([3, 1, 4, 3, null, 1, 5]);

        var result = BinaryTreeDeptFirstSearch.GoodNodes_Iteration(root!);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests GoodNodes with increasing values.
    /// </summary>
    [Fact]
    public void GoodNodes_WithIncreasingValues_ReturnsAllNodes()
    {
        var root = Utils.BuildBinaryTree([1, 2, 3, 4, 5]);

        var result = BinaryTreeDeptFirstSearch.GoodNodes(root!);

        Assert.Equal(5, result);
    }

    #endregion

    #region IsSameTree Tests

    /// <summary>
    /// Tests IsSameTree with identical trees.
    /// https://leetcode.com/problems/same-tree/description/
    /// Pattern: DFS comparison - validate structure and values
    /// </summary>
    [Fact]
    public void IsSameTree_WithIdenticalTrees_ReturnsTrue()
    {
        var p = Utils.BuildBinaryTree([1, 2, 3]);
        var q = Utils.BuildBinaryTree([1, 2, 3]);

        var result = BinaryTreeDeptFirstSearch.IsSameTree(p, q);

        Assert.True(result);
    }

    /// <summary>
    /// Tests IsSameTree with different structure.
    /// </summary>
    [Fact]
    public void IsSameTree_WithDifferentStructure_ReturnsFalse()
    {
        var p = Utils.BuildBinaryTree([1, 2]);
        var q = Utils.BuildBinaryTree([1, null, 2]);

        var result = BinaryTreeDeptFirstSearch.IsSameTree(p, q);

        Assert.False(result);
    }

    /// <summary>
    /// Tests IsSameTree with different values.
    /// </summary>
    [Fact]
    public void IsSameTree_WithDifferentValues_ReturnsFalse()
    {
        var p = Utils.BuildBinaryTree([1, 2, 1]);
        var q = Utils.BuildBinaryTree([1, 1, 2]);

        var result = BinaryTreeDeptFirstSearch.IsSameTree(p, q);

        Assert.False(result);
    }

    /// <summary>
    /// Tests IsSameTree with both null.
    /// </summary>
    [Fact]
    public void IsSameTree_WithBothNull_ReturnsTrue()
    {
        var result = BinaryTreeDeptFirstSearch.IsSameTree(null, null);

        Assert.True(result);
    }

    /// <summary>
    /// Tests IsSameTree with one null.
    /// </summary>
    [Fact]
    public void IsSameTree_WithOneNull_ReturnsFalse()
    {
        var p = Utils.BuildBinaryTree([1]);

        var result = BinaryTreeDeptFirstSearch.IsSameTree(p, null);

        Assert.False(result);
    }

    #endregion

    #region MinDepth Tests

    /// <summary>
    /// Tests MinDepth with balanced tree.
    /// https://leetcode.com/problems/minimum-depth-of-binary-tree/description/
    /// Pattern: DFS - find shortest path to leaf
    /// </summary>
    [Fact]
    public void MinDepth_WithBalancedTree_ReturnsCorrectDepth()
    {
        var root = Utils.BuildBinaryTree([3, 9, 20, null, null, 15, 7]);

        var result = BinaryTreeDeptFirstSearch.MinDepth(root);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests MinDepth with null root.
    /// </summary>
    [Fact]
    public void MinDepth_WithNullRoot_ReturnsZero()
    {
        var result = BinaryTreeDeptFirstSearch.MinDepth(null);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests MinDepth with single node.
    /// </summary>
    [Fact]
    public void MinDepth_WithSingleNode_ReturnsOne()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = BinaryTreeDeptFirstSearch.MinDepth(root);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests MinDepth with skewed tree.
    /// </summary>
    [Fact]
    public void MinDepth_WithSkewedTree_ReturnsCorrectDepth()
    {
        var root = Utils.BuildBinaryTree([2, null, 3, null, 4, null, 5, null, 6]);

        var result = BinaryTreeDeptFirstSearch.MinDepth(root);

        Assert.Equal(5, result);
    }

    #endregion

    #region MaxAncestorDiff Tests

    /// <summary>
    /// Tests MaxAncestorDiff with basic tree.
    /// https://leetcode.com/problems/maximum-difference-between-node-and-ancestor/
    /// Pattern: DFS with state - track min and max ancestors
    /// </summary>
    [Fact]
    public void MaxAncestorDiff_WithBasicTree_ReturnsCorrectDifference()
    {
        var root = Utils.BuildBinaryTree([8, 3, 10, 1, 6, null, 14, null, null, 4, 7, 13]);

        var result = BinaryTreeDeptFirstSearch.MaxAncestorDiff(root!);

        Assert.Equal(7, result);
    }

    /// <summary>
    /// Tests MaxAncestorDiff with single path.
    /// </summary>
    [Fact]
    public void MaxAncestorDiff_WithSinglePath_ReturnsCorrectDifference()
    {
        var root = Utils.BuildBinaryTree([1, null, 2, null, 0, 3]);

        var result = BinaryTreeDeptFirstSearch.MaxAncestorDiff(root!);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests MaxAncestorDiff with two nodes.
    /// </summary>
    [Fact]
    public void MaxAncestorDiff_WithTwoNodes_ReturnsCorrectDifference()
    {
        var root = Utils.BuildBinaryTree([1, 5]);

        var result = BinaryTreeDeptFirstSearch.MaxAncestorDiff(root!);

        Assert.Equal(4, result);
    }

    #endregion

    #region LowestCommonAncestor Tests

    /// <summary>
    /// Tests LowestCommonAncestor with nodes in different subtrees.
    /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
    /// Pattern: DFS - find common ancestor by traversing both paths
    /// </summary>
    [Fact]
    public void LowestCommonAncestor_WithNodesInDifferentSubtrees_ReturnsRoot()
    {
        var root = Utils.BuildBinaryTree([3, 5, 1, 6, 2, 0, 8, null, null, 7, 4]);
        // Get actual nodes from the tree
        var p = root!.Left; // Node with value 5
        var q = root.Right; // Node with value 1

        var result = BinaryTreeDeptFirstSearch.LowestCommonAncestor(root, p!, q!);

        Assert.NotNull(result);
        Assert.Equal(3, result!.Val);
    }

    /// <summary>
    /// Tests LowestCommonAncestor with one node being ancestor of other.
    /// </summary>
    [Fact]
    public void LowestCommonAncestor_WithOneNodeBeingAncestor_ReturnsThatNode()
    {
        var root = Utils.BuildBinaryTree([3, 5, 1, 6, 2, 0, 8, null, null, 7, 4]);
        // Get actual nodes from the tree
        var p = root!.Left; // Node with value 5
        var q = root.Left!.Right!.Right; // Node with value 4

        var result = BinaryTreeDeptFirstSearch.LowestCommonAncestor(root, p!, q!);

        Assert.NotNull(result);
        Assert.Equal(5, result!.Val);
    }

    #endregion

    #region DiameterOfBinaryTree Tests

    /// <summary>
    /// Tests DiameterOfBinaryTree with basic tree.
    /// https://leetcode.com/problems/diameter-of-binary-tree/description/
    /// Pattern: DFS - calculate longest path through each node
    /// </summary>
    [Fact]
    public void DiameterOfBinaryTree_WithBasicTree_ReturnsCorrectDiameter()
    {
        var root = Utils.BuildBinaryTree([1, 2, 3, 4, 5]);
        var dfs = new BinaryTreeDeptFirstSearch();

        var result = dfs.DiameterOfBinaryTree(root);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests DiameterOfBinaryTree with single node.
    /// </summary>
    [Fact]
    public void DiameterOfBinaryTree_WithSingleNode_ReturnsZero()
    {
        var root = Utils.BuildBinaryTree([1]);
        var dfs = new BinaryTreeDeptFirstSearch();

        var result = dfs.DiameterOfBinaryTree(root);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests DiameterOfBinaryTree with left-skewed tree.
    /// </summary>
    [Fact]
    public void DiameterOfBinaryTree_WithSkewedTree_ReturnsCorrectDiameter()
    {
        var root = Utils.BuildBinaryTree([1, 2, null, 3, null, 4]);
        var dfs = new BinaryTreeDeptFirstSearch();

        var result = dfs.DiameterOfBinaryTree(root);

        Assert.Equal(3, result);
    }

    #endregion
}
