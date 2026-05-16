using DSA.DataStructure;

namespace DSA.Tests.DataStructure;

public class MinHeapTests
{
    [Fact]
    public void Count_OnNewHeap_ReturnsZero()
    {
        var heap = new MinHeap();

        Assert.Equal(0, heap.Count);
    }

    [Fact]
    public void IsEmpty_OnNewHeap_ReturnsTrue()
    {
        var heap = new MinHeap();

        Assert.True(heap.IsEmpty);
    }

    [Fact]
    public void Clear_OnNewHeap_KeepsCountZero()
    {
        var heap = new MinHeap();

        heap.Clear();

        Assert.Equal(0, heap.Count);
        Assert.True(heap.IsEmpty);
    }
}
