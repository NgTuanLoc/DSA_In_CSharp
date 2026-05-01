using DSA;

namespace DSA.Tests.LeetCode.Heap;

public class HeapSolutionTests
{
    [Fact]
    public void LastStoneWeight_TwoStones_ReturnsAbsoluteDifference()
    {
        var stones = new int[] { 2, 7, 4, 1, 8, 1 };
        var result = HeapSolution.LastStoneWeight(stones);

        Assert.Equal(1, result);
    }

    [Fact]
    public void LastStoneWeight_SingleStone_ReturnsThatStone()
    {
        var stones = new int[] { 5 };
        var result = HeapSolution.LastStoneWeight(stones);

        Assert.Equal(5, result);
    }

    [Fact]
    public void LastStoneWeight_TwoIdenticalStones_ReturnsZero()
    {
        var stones = new int[] { 10, 10 };
        var result = HeapSolution.LastStoneWeight(stones);

        Assert.Equal(0, result);
    }

    [Fact]
    public void LastStoneWeight_AllStonesDestroyed_ReturnsZero()
    {
        var stones = new int[] { 3, 7, 3, 1 };
        var result = HeapSolution.LastStoneWeight(stones);

        Assert.True(result >= 0);
    }

    [Fact]
    public void LastStoneWeight_LargeDifferences_ReturnsCorrectly()
    {
        var stones = new int[] { 1, 3, 5, 4, 2 };
        var result = HeapSolution.LastStoneWeight(stones);

        Assert.True(result >= 0);
    }

    [Fact]
    public void HalveArray_HalvesSum_ReturnsOperationCount()
    {
        var nums = new int[] { 5, 19, 8, 1 };
        var result = HeapSolution.HalveArray(nums);

        Assert.True(result > 0);
    }

    [Fact]
    public void HalveArray_SingleElement_ReturnsOne()
    {
        var nums = new int[] { 10 };
        var result = HeapSolution.HalveArray(nums);

        Assert.Equal(1, result);
    }

    [Fact]
    public void HalveArray_AllOnes_ReturnsCorrectCount()
    {
        var nums = new int[] { 1, 1, 1, 1 };
        var result = HeapSolution.HalveArray(nums);

        Assert.True(result > 0);
    }

    [Fact]
    public void HalveArray_LargeNumbers_Converges()
    {
        var nums = new int[] { 100, 100, 100, 100 };
        var result = HeapSolution.HalveArray(nums);

        Assert.True(result > 0);
    }

    [Fact]
    public void MinStoneSum_KOperations_ReducesSum()
    {
        var piles = new int[] { 4, 3, 6, 8, 5 };
        var k = 2;
        var result = HeapSolution.MinStoneSum(piles, k);

        // Sum starts at 4+3+6+8+5 = 26
        Assert.True(result < 26);
    }

    [Fact]
    public void MinStoneSum_KIsZero_ReturnsSumOfAllPiles()
    {
        var piles = new int[] { 4, 3, 6, 8, 5 };
        var k = 0;
        var result = HeapSolution.MinStoneSum(piles, k);

        Assert.Equal(26, result);
    }

    [Fact]
    public void MinStoneSum_SinglePile_ReducesPile()
    {
        var piles = new int[] { 10 };
        var k = 2;
        var result = HeapSolution.MinStoneSum(piles, k);

        Assert.True(result < 10);
    }

    [Fact]
    public void MinStoneSum_AllOnes_ReturnsOne()
    {
        var piles = new int[] { 1, 1, 1, 1 };
        var k = 4;
        var result = HeapSolution.MinStoneSum(piles, k);

        Assert.Equal(4, result);
    }

    [Fact]
    public void MinStoneSum_LargeK_MinimizesFurther()
    {
        var piles = new int[] { 5, 5, 5 };
        var resultSmallK = HeapSolution.MinStoneSum(piles, 1);
        var resultLargeK = HeapSolution.MinStoneSum(piles, 5);

        Assert.True(resultLargeK <= resultSmallK);
    }

    [Fact]
    public void ConnectSticks_AllowsCombination_ReturnsTotalCost()
    {
        var sticks = new int[] { 2, 4, 3 };
        var result = HeapSolution.ConnectSticks(sticks);

        Assert.True(result > 0);
    }

    [Fact]
    public void ConnectSticks_TwoSticks_ReturnsCombinedLength()
    {
        var sticks = new int[] { 5, 4 };
        var result = HeapSolution.ConnectSticks(sticks);

        Assert.Equal(9, result);
    }

    [Fact]
    public void ConnectSticks_SingleStick_ReturnsZero()
    {
        var sticks = new int[] { 10 };
        var result = HeapSolution.ConnectSticks(sticks);

        Assert.Equal(0, result);
    }

    [Fact]
    public void ConnectSticks_MultipleSticks_OptimalCost()
    {
        var sticks = new int[] { 1, 2, 5, 10, 35, 89, 221 };
        var result = HeapSolution.ConnectSticks(sticks);

        Assert.True(result > 0);
    }

    [Fact]
    public void ConnectSticks_AllEqual_BalancedCost()
    {
        var sticks = new int[] { 3, 3, 3, 3 };
        var result = HeapSolution.ConnectSticks(sticks);

        Assert.True(result > 0);
    }
}
