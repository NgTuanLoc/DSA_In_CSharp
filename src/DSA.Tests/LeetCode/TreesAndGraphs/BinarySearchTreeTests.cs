using DSA;
using DSA.LeetCode.TreesAndGraphs;

namespace DSA.Tests.LeetCode.TreesAndGraphs;

public class BinarySearchTreeTests
{
    #region RangeSumBST Tests

    /// <summary>
    /// Tests RangeSumBST with basic BST.
    /// https://leetcode.com/problems/range-sum-of-bst/description/
    /// Pattern: BST traversal - prune branches outside range
    /// </summary>
    [Fact]
    public void RangeSumBST_WithBasicBST_ReturnsCorrectSum()
    {
        var root = Utils.BuildBinaryTree([10, 5, 15, 3, 7, null, 18]);

        var result = BinarySearchTree.RangeSumBST(root, 7, 15);

        Assert.Equal(32, result);
    }

    /// <summary>
    /// Tests RangeSumBST with larger BST.
    /// </summary>
    [Fact]
    public void RangeSumBST_WithLargerBST_ReturnsCorrectSum()
    {
        var root = Utils.BuildBinaryTree([10, 5, 15, 3, 7, 13, 18, 1, null, 6]);

        var result = BinarySearchTree.RangeSumBST(root, 6, 10);

        Assert.Equal(23, result);
    }

    /// <summary>
    /// Tests RangeSumBST with null root.
    /// </summary>
    [Fact]
    public void RangeSumBST_WithNullRoot_ReturnsZero()
    {
        var result = BinarySearchTree.RangeSumBST(null, 1, 10);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests RangeSumBST with single node in range.
    /// </summary>
    [Fact]
    public void RangeSumBST_WithSingleNodeInRange_ReturnsThatValue()
    {
        var root = Utils.BuildBinaryTree([10]);

        var result = BinarySearchTree.RangeSumBST(root, 5, 15);

        Assert.Equal(10, result);
    }

    /// <summary>
    /// Tests RangeSumBST with single node outside range.
    /// </summary>
    [Fact]
    public void RangeSumBST_WithSingleNodeOutsideRange_ReturnsZero()
    {
        var root = Utils.BuildBinaryTree([10]);

        var result = BinarySearchTree.RangeSumBST(root, 1, 5);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests RangeSumBST with range covering all nodes.
    /// </summary>
    [Fact]
    public void RangeSumBST_WithRangeCoveringAll_ReturnsTotalSum()
    {
        var root = Utils.BuildBinaryTree([10, 5, 15, 3, 7]);

        var result = BinarySearchTree.RangeSumBST(root, 1, 20);

        Assert.Equal(40, result);
    }

    /// <summary>
    /// Tests RangeSumBST_Iteration with basic BST.
    /// </summary>
    [Fact]
    public void RangeSumBST_Iteration_WithBasicBST_ReturnsCorrectSum()
    {
        var root = Utils.BuildBinaryTree([10, 5, 15, 3, 7, null, 18]);

        var result = BinarySearchTree.RangeSumBST_Iteration(root!, 7, 15);

        Assert.Equal(32, result);
    }

    #endregion

    #region GetMinimumDifference Tests

    /// <summary>
    /// Tests GetMinimumDifference with basic BST.
    /// https://leetcode.com/problems/minimum-absolute-difference-in-bst/description/
    /// Pattern: BST inorder traversal - sorted order for minimum diff
    /// </summary>
    [Fact]
    public void GetMinimumDifference_WithBasicBST_ReturnsMinDifference()
    {
        var root = Utils.BuildBinaryTree([4, 2, 6, 1, 3]);

        var result = BinarySearchTree.GetMinimumDifference(root!);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests GetMinimumDifference with larger values.
    /// </summary>
    [Fact]
    public void GetMinimumDifference_WithLargerValues_ReturnsMinDifference()
    {
        var root = Utils.BuildBinaryTree([1, 0, 48, null, null, 12, 49]);

        var result = BinarySearchTree.GetMinimumDifference(root!);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests GetMinimumDifference with single child.
    /// </summary>
    [Fact]
    public void GetMinimumDifference_WithSingleChild_ReturnsCorrectDifference()
    {
        var root = Utils.BuildBinaryTree([1, null, 3]);

        var result = BinarySearchTree.GetMinimumDifference(root!);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests GetMinimumDifference_Iteration with basic BST.
    /// </summary>
    [Fact]
    public void GetMinimumDifference_Iteration_WithBasicBST_ReturnsMinDifference()
    {
        var root = Utils.BuildBinaryTree([4, 2, 6, 1, 3]);

        var result = BinarySearchTree.GetMinimumDifference_Iteration(root!);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests GetMinimumDifference with three nodes.
    /// </summary>
    [Fact]
    public void GetMinimumDifference_WithThreeNodes_ReturnsMinDifference()
    {
        var root = Utils.BuildBinaryTree([5, 4, 7]);

        var result = BinarySearchTree.GetMinimumDifference(root!);

        Assert.Equal(1, result);
    }

    #endregion

    #region IsValidBST Tests

    /// <summary>
    /// Tests IsValidBST with valid BST.
    /// https://leetcode.com/problems/validate-binary-search-tree/description/
    /// Pattern: BST validation - check bounds recursively
    /// </summary>
    [Fact]
    public void IsValidBST_WithValidBST_ReturnsTrue()
    {
        var root = Utils.BuildBinaryTree([2, 1, 3]);

        var result = BinarySearchTree.IsValidBST(root);

        Assert.True(result);
    }

    /// <summary>
    /// Tests IsValidBST with invalid BST.
    /// </summary>
    [Fact]
    public void IsValidBST_WithInvalidBST_ReturnsFalse()
    {
        var root = Utils.BuildBinaryTree([5, 1, 4, null, null, 3, 6]);

        var result = BinarySearchTree.IsValidBST(root);

        Assert.False(result);
    }

    /// <summary>
    /// Tests IsValidBST with single node.
    /// </summary>
    [Fact]
    public void IsValidBST_WithSingleNode_ReturnsTrue()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = BinarySearchTree.IsValidBST(root);

        Assert.True(result);
    }

    /// <summary>
    /// Tests IsValidBST with null root.
    /// </summary>
    [Fact]
    public void IsValidBST_WithNullRoot_ReturnsTrue()
    {
        var result = BinarySearchTree.IsValidBST(null);

        Assert.True(result);
    }

    /// <summary>
    /// Tests IsValidBST with equal values (invalid).
    /// </summary>
    [Fact]
    public void IsValidBST_WithEqualValues_ReturnsFalse()
    {
        var root = Utils.BuildBinaryTree([2, 2, 2]);

        var result = BinarySearchTree.IsValidBST(root);

        Assert.False(result);
    }

    /// <summary>
    /// Tests IsValidBST_Iteration with valid BST.
    /// </summary>
    [Fact]
    public void IsValidBST_Iteration_WithValidBST_ReturnsTrue()
    {
        var root = Utils.BuildBinaryTree([2, 1, 3]);

        var result = BinarySearchTree.IsValidBST_Iteration(root!);

        Assert.True(result);
    }

    /// <summary>
    /// Tests IsValidBST_Iteration with invalid BST.
    /// </summary>
    [Fact]
    public void IsValidBST_Iteration_WithInvalidBST_ReturnsFalse()
    {
        var root = Utils.BuildBinaryTree([5, 1, 4, null, null, 3, 6]);

        var result = BinarySearchTree.IsValidBST_Iteration(root!);

        Assert.False(result);
    }

    /// <summary>
    /// Tests IsValidBST with larger tree.
    /// </summary>
    [Fact]
    public void IsValidBST_WithLargerTree_ReturnsTrue()
    {
        var root = Utils.BuildBinaryTree([10, 5, 15, 3, 7, 13, 18, 1, null, 6]);

        var result = BinarySearchTree.IsValidBST(root);

        Assert.True(result);
    }

    #endregion

    #region InsertIntoBST Tests

    /// <summary>
    /// Tests InsertIntoBST with basic BST.
    /// https://leetcode.com/problems/insert-into-a-binary-search-tree/description/
    /// Pattern: BST insertion - traverse to correct position
    /// </summary>
    [Fact]
    public void InsertIntoBST_WithBasicBST_InsertsCorrectly()
    {
        var root = Utils.BuildBinaryTree([4, 2, 7, 1, 3]);

        var result = BinarySearchTree.InsertIntoBST(root, 5);

        Assert.NotNull(result);
        Assert.True(BinarySearchTree.IsValidBST(result));
    }

    /// <summary>
    /// Tests InsertIntoBST with null root.
    /// </summary>
    [Fact]
    public void InsertIntoBST_WithNullRoot_ReturnsNull()
    {
        var result = BinarySearchTree.InsertIntoBST(null, 5);

        Assert.Null(result);
    }

    /// <summary>
    /// Tests InsertIntoBST into single node.
    /// </summary>
    [Fact]
    public void InsertIntoBST_WithSingleNode_InsertsCorrectly()
    {
        var root = Utils.BuildBinaryTree([5]);

        var result = BinarySearchTree.InsertIntoBST(root, 3);

        Assert.NotNull(result);
        Assert.Equal(5, result!.Val);
        Assert.NotNull(result.Left);
        Assert.Equal(3, result.Left!.Val);
    }

    #endregion

    #region ClosestValue Tests

    /// <summary>
    /// Tests ClosestValue with basic BST.
    /// https://leetcode.com/problems/closest-binary-search-tree-value/description/
    /// Pattern: BST search - binary search for closest value
    /// </summary>
    [Fact]
    public void ClosestValue_WithBasicBST_ReturnsClosestValue()
    {
        var root = Utils.BuildBinaryTree([4, 2, 5, 1, 3]);

        var result = BinarySearchTree.ClosestValue(root, 3.714286);

        Assert.Equal(4, result);
    }

    /// <summary>
    /// Tests ClosestValue with exact match.
    /// </summary>
    [Fact]
    public void ClosestValue_WithExactMatch_ReturnsThatValue()
    {
        var root = Utils.BuildBinaryTree([4, 2, 5, 1, 3]);

        var result = BinarySearchTree.ClosestValue(root, 3.0);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests ClosestValue with null root.
    /// </summary>
    [Fact]
    public void ClosestValue_WithNullRoot_ReturnsZero()
    {
        var result = BinarySearchTree.ClosestValue(null, 3.5);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests ClosestValue with single node.
    /// </summary>
    [Fact]
    public void ClosestValue_WithSingleNode_ReturnsThatValue()
    {
        var root = Utils.BuildBinaryTree([1]);

        var result = BinarySearchTree.ClosestValue(root, 4.428571);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests ClosestValue with tie (chooses smaller).
    /// </summary>
    [Fact]
    public void ClosestValue_WithTie_ReturnsSmallerValue()
    {
        var root = Utils.BuildBinaryTree([4, 2, 5]);

        var result = BinarySearchTree.ClosestValue(root, 3.5);

        Assert.Equal(4, result);
    }

    #endregion
}
