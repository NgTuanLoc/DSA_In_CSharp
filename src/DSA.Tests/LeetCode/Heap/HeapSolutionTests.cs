using DSA;

namespace DSA.Tests.LeetCode.Heap;

public class HeapSolutionTests
{
    #region LastStoneWeight Tests

    [Fact]
    public void LastStoneWeight_WithTwoStones_ReturnsDifference()
    {
        var result = HeapSolution.LastStoneWeight([2, 7]);

        Assert.Equal(5, result);
    }

    [Fact]
    public void LastStoneWeight_WithExample_ReturnsOne()
    {
        var result = HeapSolution.LastStoneWeight([2, 7, 4, 1, 8, 1]);

        Assert.Equal(1, result);
    }

    // Missing: single stone → should return that stone's weight
    // Missing: all equal stones (even count) → should return 0
    // Missing: all equal stones (odd count) → should return that stone's weight

    #endregion

    #region HalveArray Tests

    [Fact]
    public void HalveArray_WithBasicInput_ReturnsMinOperations()
    {
        var result = HeapSolution.HalveArray([5, 19, 8, 1]);

        Assert.Equal(3, result);
    }

    [Fact]
    public void HalveArray_WithPowersOfTwo_ReturnsCorrectCount()
    {
        var result = HeapSolution.HalveArray([3, 8, 20]);

        Assert.Equal(3, result);
    }

    // Missing: single element array → 1 operation always needed

    #endregion

    #region MinStoneSum Tests

    [Fact]
    public void MinStoneSum_WithBasicInput_ReturnsMinSum()
    {
        var result = HeapSolution.MinStoneSum([4, 3, 6, 7], 3);

        Assert.Equal(12, result);
    }

    [Fact]
    public void MinStoneSum_WithLargeK_RemovesCorrectly()
    {
        var result = HeapSolution.MinStoneSum([4, 3, 2], 3);

        Assert.Equal(3, result);
    }

    // Missing: k = 0 → sum should be unchanged
    // Missing: single pile

    #endregion

    #region ConnectSticks Tests

    [Fact]
    public void ConnectSticks_WithBasicInput_ReturnsMinCost()
    {
        var result = HeapSolution.ConnectSticks([2, 4, 3]);

        Assert.Equal(14, result);
    }

    [Fact]
    public void ConnectSticks_WithEqualSticks_ReturnsMinCost()
    {
        var result = HeapSolution.ConnectSticks([1, 8, 3, 5]);

        Assert.Equal(30, result);
    }

    // Missing: single stick → cost should be 0
    // Missing: two sticks → cost equals their sum

    #endregion
}
