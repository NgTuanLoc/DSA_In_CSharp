using DSA;
using DSA.LeetCode.TreesAndGraphs;

namespace DSA.Tests.LeetCode.TreesAndGraphs;

public class BfsTests
{
    #region RightSideView Tests

    /// <summary>
    /// Tests RightSideView with balanced tree.
    /// https://leetcode.com/problems/binary-tree-right-side-view/
    /// Pattern: BFS level order - collect rightmost node per level
    /// </summary>
    [Fact]
    public void RightSideView_WithBalancedTree_ReturnsRightmostNodes()
    {
        var root = Utils.BuildBinaryTree([1, 2, 3, null, 5, null, 4]);

        var result = Bfs.RightSideView(root);

        Assert.Equal([1, 3, 4], result);
    }

    /// <summary>
    /// Tests RightSideView with null root.
    /// </summary>
    [Fact]
    public void RightSideView_WithNullRoot_ReturnsEmptyList()
    {
        var result = Bfs.RightSideView(null);

        Assert.Empty(result);
    }

    /// <summary>
    /// Tests RightSideView with single node.
    /// </summary>
    [Fact]
    public void RightSideView_WithSingleNode_ReturnsThatNode()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = Bfs.RightSideView(root);

        Assert.Equal([1], result);
    }

    /// <summary>
    /// Tests RightSideView with left-skewed tree.
    /// </summary>
    [Fact]
    public void RightSideView_WithLeftSkewedTree_ReturnsLeftNodes()
    {
        var root = Utils.BuildBinaryTree([1, 2, null, 3, null, 4]);

        var result = Bfs.RightSideView(root);

        Assert.Equal([1, 2, 3, 4], result);
    }

    /// <summary>
    /// Tests RightSideView with right-skewed tree.
    /// </summary>
    [Fact]
    public void RightSideView_WithRightSkewedTree_ReturnsAllNodes()
    {
        var root = Utils.BuildBinaryTree([1, null, 2, null, 3, null, 4]);

        var result = Bfs.RightSideView(root);

        Assert.Equal([1, 2, 3, 4], result);
    }

    /// <summary>
    /// Tests RightSideView with mixed tree.
    /// </summary>
    [Fact]
    public void RightSideView_WithMixedTree_ReturnsCorrectView()
    {
        var root = Utils.BuildBinaryTree([1, 2, 3, 4]);

        var result = Bfs.RightSideView(root);

        Assert.Equal([1, 3, 4], result);
    }

    #endregion

    #region LargestValues Tests

    /// <summary>
    /// Tests LargestValues with basic tree.
    /// https://leetcode.com/problems/find-largest-value-in-each-tree-row/
    /// Pattern: BFS level order - track maximum in each level
    /// </summary>
    [Fact]
    public void LargestValues_WithBasicTree_ReturnsMaxPerLevel()
    {
        var root = Utils.BuildBinaryTree([1, 3, 2, 5, 3, null, 9]);

        var result = Bfs.LargestValues(root);

        Assert.Equal([1, 3, 9], result);
    }

    /// <summary>
    /// Tests LargestValues with null root.
    /// </summary>
    [Fact]
    public void LargestValues_WithNullRoot_ReturnsEmptyList()
    {
        var result = Bfs.LargestValues(null);

        Assert.Empty(result);
    }

    /// <summary>
    /// Tests LargestValues with single node.
    /// </summary>
    [Fact]
    public void LargestValues_WithSingleNode_ReturnsThatNode()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = Bfs.LargestValues(root);

        Assert.Equal([1], result);
    }

    /// <summary>
    /// Tests LargestValues with negative numbers.
    /// </summary>
    [Fact]
    public void LargestValues_WithNegativeNumbers_ReturnsCorrectMaximums()
    {
        var root = Utils.BuildBinaryTree([0, -1, -2]);

        var result = Bfs.LargestValues(root);

        Assert.Equal([0, -1], result);
    }

    /// <summary>
    /// Tests LargestValues with increasing values.
    /// </summary>
    [Fact]
    public void LargestValues_WithIncreasingValues_ReturnsCorrectMaximums()
    {
        var root = Utils.BuildBinaryTree([1, 2, 3, 4, 5, 6, 7]);

        var result = Bfs.LargestValues(root);

        Assert.Equal([1, 3, 7], result);
    }

    /// <summary>
    /// Tests LargestValues with all same values.
    /// </summary>
    [Fact]
    public void LargestValues_WithSameValues_ReturnsAllSame()
    {
        var root = Utils.BuildBinaryTree([5, 5, 5, 5, 5]);

        var result = Bfs.LargestValues(root);

        Assert.Equal([5, 5, 5], result);
    }

    #endregion

    #region DeepestLeavesSum Tests

    /// <summary>
    /// Tests DeepestLeavesSum with basic tree.
    /// https://leetcode.com/problems/deepest-leaves-sum/description/
    /// Pattern: BFS level order - sum last level nodes
    /// </summary>
    [Fact]
    public void DeepestLeavesSum_WithBasicTree_ReturnsSumOfDeepestLeaves()
    {
        var root = Utils.BuildBinaryTree([1, 2, 3, 4, 5, null, 6, 7, null, null, null, null, 8]);

        var result = Bfs.DeepestLeavesSum(root);

        Assert.Equal(15, result);
    }

    /// <summary>
    /// Tests DeepestLeavesSum with null root.
    /// </summary>
    [Fact]
    public void DeepestLeavesSum_WithNullRoot_ReturnsZero()
    {
        var result = Bfs.DeepestLeavesSum(null);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests DeepestLeavesSum with single node.
    /// </summary>
    [Fact]
    public void DeepestLeavesSum_WithSingleNode_ReturnsThatNode()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = Bfs.DeepestLeavesSum(root);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests DeepestLeavesSum with two levels.
    /// </summary>
    [Fact]
    public void DeepestLeavesSum_WithTwoLevels_ReturnsLeafSum()
    {
        var root = Utils.BuildBinaryTree([6, 7, 8, 2, 7, 1, 3, 9, null, 1, 4, null, null, null, 5]);

        var result = Bfs.DeepestLeavesSum(root);

        Assert.Equal(19, result);
    }

    /// <summary>
    /// Tests DeepestLeavesSum with skewed tree.
    /// </summary>
    [Fact]
    public void DeepestLeavesSum_WithSkewedTree_ReturnsLastNode()
    {
        var root = Utils.BuildBinaryTree([1, 2, null, 3]);

        var result = Bfs.DeepestLeavesSum(root);

        Assert.Equal(3, result);
    }

    #endregion

    #region ZigzagLevelOrder Tests

    /// <summary>
    /// Tests ZigzagLevelOrder with basic tree.
    /// https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
    /// Pattern: BFS level order with alternating direction
    /// </summary>
    [Fact]
    public void ZigzagLevelOrder_WithBasicTree_ReturnsZigzagTraversal()
    {
        var root = Utils.BuildBinaryTree([3, 9, 20, null, null, 15, 7]);

        var result = Bfs.ZigzagLevelOrder(root);

        Assert.Equal(3, result.Count);
        Assert.Equal([3], result[0]);
        Assert.Equal([20, 9], result[1]);
        Assert.Equal([15, 7], result[2]);
    }

    /// <summary>
    /// Tests ZigzagLevelOrder with null root.
    /// </summary>
    [Fact]
    public void ZigzagLevelOrder_WithNullRoot_ReturnsEmptyList()
    {
        var result = Bfs.ZigzagLevelOrder(null);

        Assert.Empty(result);
    }

    /// <summary>
    /// Tests ZigzagLevelOrder with single node.
    /// </summary>
    [Fact]
    public void ZigzagLevelOrder_WithSingleNode_ReturnsOneLevel()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = Bfs.ZigzagLevelOrder(root);

        Assert.Single(result);
        Assert.Equal([1], result[0]);
    }

    /// <summary>
    /// Tests ZigzagLevelOrder with complete tree.
    /// </summary>
    [Fact]
    public void ZigzagLevelOrder_WithCompleteTree_ReturnsCorrectZigzag()
    {
        var root = Utils.BuildBinaryTree([1, 2, 3, 4, 5, 6, 7]);

        var result = Bfs.ZigzagLevelOrder(root);

        Assert.Equal(3, result.Count);
        Assert.Equal([1], result[0]);
        Assert.Equal([3, 2], result[1]);
        Assert.Equal([4, 5, 6, 7], result[2]);
    }

    /// <summary>
    /// Tests ZigzagLevelOrder with left-skewed tree.
    /// </summary>
    [Fact]
    public void ZigzagLevelOrder_WithLeftSkewedTree_ReturnsCorrectZigzag()
    {
        var root = Utils.BuildBinaryTree([1, 2, null, 3, null, 4]);

        var result = Bfs.ZigzagLevelOrder(root);

        Assert.Equal(4, result.Count);
        Assert.Equal([1], result[0]);
        Assert.Equal([2], result[1]);
        Assert.Equal([3], result[2]);
        Assert.Equal([4], result[3]);
    }

    /// <summary>
    /// Tests ZigzagLevelOrder with two levels.
    /// </summary>
    [Fact]
    public void ZigzagLevelOrder_WithTwoLevels_ReturnsCorrectZigzag()
    {
        var root = Utils.BuildBinaryTree([1, 2, 3]);

        var result = Bfs.ZigzagLevelOrder(root);

        Assert.Equal(2, result.Count);
        Assert.Equal([1], result[0]);
        Assert.Equal([3, 2], result[1]);
    }

    #endregion
}
