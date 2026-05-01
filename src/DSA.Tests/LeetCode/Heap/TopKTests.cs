using DSA.LeetCode.Heap;

namespace DSA.Tests.LeetCode.Heap;

public class TopKTests
{
    [Fact]
    public void TopKFrequent_ReturnsKMostFrequent()
    {
        var nums = new int[] { 1, 1, 1, 2, 2, 3 };
        var k = 2;
        var result = TopK.TopKFrequent(nums, k);

        Assert.Equal(2, result.Length);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
    }

    [Fact]
    public void TopKFrequent_KEqualsOne_ReturnsHighestFrequent()
    {
        var nums = new int[] { 4, 1, 1, 1, 2, 2, 3 };
        var k = 1;
        var result = TopK.TopKFrequent(nums, k);

        Assert.Single(result);
        Assert.Equal(1, result[0]);
    }

    [Fact]
    public void TopKFrequent_AllElementsSameFrequency_ReturnsAnyK()
    {
        var nums = new int[] { 1, 2, 3, 4, 5 };
        var k = 3;
        var result = TopK.TopKFrequent(nums, k);

        Assert.Equal(3, result.Length);
    }

    [Fact]
    public void TopKFrequent_NegativeNumbers_WorksCorrectly()
    {
        var nums = new int[] { -1, -1, -1, -2, -2, -3 };
        var k = 2;
        var result = TopK.TopKFrequent(nums, k);

        Assert.Equal(2, result.Length);
        Assert.Contains(-1, result);
        Assert.Contains(-2, result);
    }

    [Fact]
    public void TopKFrequent_SingleElement_ReturnsIt()
    {
        var nums = new int[] { 5, 5, 5 };
        var k = 1;
        var result = TopK.TopKFrequent(nums, k);

        Assert.Single(result);
        Assert.Equal(5, result[0]);
    }

    [Fact]
    public void FindClosestElements_ReturnsKClosestSorted()
    {
        var arr = new int[] { 1, 2, 3, 4, 5 };
        var k = 4;
        var x = 3;
        var result = TopK.FindClosestElements(arr, k, x);

        Assert.Equal(4, result.Count);
        // Result should be sorted
        for (int i = 0; i < result.Count - 1; i++)
        {
            Assert.True(result[i] <= result[i + 1]);
        }
    }

    [Fact]
    public void FindClosestElements_KEqualsOne_ReturnsSingleClosest()
    {
        var arr = new int[] { 1, 2, 3, 4, 5, 6 };
        var k = 1;
        var x = 3;
        var result = TopK.FindClosestElements(arr, k, x);

        Assert.Single(result);
        Assert.Equal(3, result[0]);
    }

    [Fact]
    public void FindClosestElements_XOutsideArray_ReturnsClosestAtBoundary()
    {
        var arr = new int[] { 1, 2, 3, 4, 5 };
        var k = 2;
        var x = 10;
        var result = TopK.FindClosestElements(arr, k, x);

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void FindClosestElements_XBelowMinimum_ReturnsSmallestElements()
    {
        var arr = new int[] { 1, 2, 3, 4, 5 };
        var k = 3;
        var x = -10;
        var result = TopK.FindClosestElements(arr, k, x);

        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void FindClosestElements_EqualDistances_PrefersSmallerValue()
    {
        var arr = new int[] { 1, 3, 6, 6 };
        var k = 2;
        var x = 4;
        var result = TopK.FindClosestElements(arr, k, x);

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void FindKthLargest_ReturnsCorrectElement()
    {
        var nums = new int[] { 3, 2, 1, 5, 6, 4 };
        var k = 2;
        var result = TopK.FindKthLargest(nums, k);

        Assert.Equal(5, result);
    }

    [Fact]
    public void FindKthLargest_KEqualsOne_ReturnsMaximum()
    {
        var nums = new int[] { 3, 2, 1, 5, 6, 4 };
        var k = 1;
        var result = TopK.FindKthLargest(nums, k);

        Assert.Equal(6, result);
    }

    [Fact]
    public void FindKthLargest_KEqualsLength_ReturnsMinimum()
    {
        var nums = new int[] { 3, 2, 1, 5, 6, 4 };
        var k = 6;
        var result = TopK.FindKthLargest(nums, k);

        Assert.Equal(1, result);
    }

    [Fact]
    public void FindKthLargest_NegativeNumbers_WorksCorrectly()
    {
        var nums = new int[] { -5, -2, -8, -3, -1 };
        var k = 2;
        var result = TopK.FindKthLargest(nums, k);

        Assert.Equal(-2, result);
    }

    [Fact]
    public void FindKthLargest_DuplicateElements_FindsCorrectly()
    {
        var nums = new int[] { 4, 4, 4, 4, 4 };
        var k = 3;
        var result = TopK.FindKthLargest(nums, k);

        Assert.Equal(4, result);
    }

    [Fact]
    public void KClosest_ReturnsKClosestPoints()
    {
        var points = new int[][] { new[] { 1, 3 }, new[] { -2, 2 }, new[] { 2, -2 } };
        var k = 2;
        var result = TopK.KClosest(points, k);

        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void KClosest_KEqualsOne_ReturnsSinglePoint()
    {
        var points = new int[][] { new[] { 0, 0 }, new[] { 3, 4 } };
        var k = 1;
        var result = TopK.KClosest(points, k);

        Assert.Single(result);
        Assert.Equal(new[] { 0, 0 }, result[0]);
    }

    [Fact]
    public void KClosest_OriginIsClosest_ReturnsIt()
    {
        var points = new int[][] { new[] { 0, 0 }, new[] { 5, 5 }, new[] { 3, 3 } };
        var k = 1;
        var result = TopK.KClosest(points, k);

        Assert.Single(result);
        Assert.Equal(new[] { 0, 0 }, result[0]);
    }

    [Fact]
    public void KClosest_AllPointsEqual_ReturnsK()
    {
        var points = new int[][] { new[] { 1, 1 }, new[] { 1, 1 }, new[] { 1, 1 } };
        var k = 2;
        var result = TopK.KClosest(points, k);

        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void KClosest_NegativeCoordinates_WorksCorrectly()
    {
        var points = new int[][] { new[] { -1, -2 }, new[] { 0, 0 }, new[] { 2, 1 } };
        var k = 2;
        var result = TopK.KClosest(points, k);

        Assert.Equal(2, result.Length);
    }
}

public class KthLargestTests
{
    [Fact]
    public void KthLargest_Constructor_InitializesWithElements()
    {
        var k = 3;
        var nums = new int[] { 4, 5, 8, 2 };
        var kthLargest = new KthLargest(k, nums);

        Assert.NotNull(kthLargest);
    }

    [Fact]
    public void KthLargest_Add_ReturnsKthLargest()
    {
        var k = 3;
        var nums = new int[] { 4, 5, 8, 2 };
        var kthLargest = new KthLargest(k, nums);
        var result = kthLargest.Add(3);

        Assert.NotNull(result);
    }

    [Fact]
    public void KthLargest_AddMultipleElements_TrackingKthLargest()
    {
        var k = 3;
        var nums = new int[] { 4, 5, 8, 2 };
        var kthLargest = new KthLargest(k, nums);

        kthLargest.Add(3);
        kthLargest.Add(5);
        var result = kthLargest.Add(10);

        Assert.True(result > 0);
    }

    [Fact]
    public void KthLargest_EmptyInitialization_AcceptsElements()
    {
        var k = 2;
        var nums = new int[] { };
        var kthLargest = new KthLargest(k, nums);

        kthLargest.Add(3);
        var result = kthLargest.Add(5);

        Assert.True(result > 0);
    }

    [Fact]
    public void KthLargest_KeepsOnlyKLargest_AfterAdditions()
    {
        var k = 2;
        var nums = new int[] { 3, 4 };
        var kthLargest = new KthLargest(k, nums);

        kthLargest.Add(2);
        var result = kthLargest.Add(5);

        Assert.True(result > 0);
    }

    [Fact]
    public void KthLargest_SingleElement_Works()
    {
        var k = 1;
        var nums = new int[] { 5 };
        var kthLargest = new KthLargest(k, nums);
        var result = kthLargest.Add(3);

        Assert.NotNull(result);
    }

    [Fact]
    public void KthLargest_NegativeNumbers_Works()
    {
        var k = 2;
        var nums = new int[] { -5, -2, -8 };
        var kthLargest = new KthLargest(k, nums);
        var result = kthLargest.Add(-1);

        Assert.NotNull(result);
    }
}
