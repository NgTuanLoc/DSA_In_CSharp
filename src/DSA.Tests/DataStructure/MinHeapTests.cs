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

    [Fact]
    public void Peek_OnEmptyHeap_ThrowsInvalidOperationException()
    {
        var heap = new MinHeap();

        Assert.Throws<InvalidOperationException>(() => heap.Peek());
    }

    [Fact]
    public void Insert_SingleValue_PeeksThatValue()
    {
        var heap = new MinHeap();

        heap.Insert(42);

        Assert.Equal(1, heap.Count);
        Assert.Equal(42, heap.Peek());
    }

    [Fact]
    public void Insert_MultipleValues_PeekReturnsSmallest()
    {
        var heap = new MinHeap();

        heap.Insert(5);
        heap.Insert(3);
        heap.Insert(8);
        heap.Insert(1);
        heap.Insert(4);

        Assert.Equal(5, heap.Count);
        Assert.Equal(1, heap.Peek());
    }

    [Fact]
    public void Insert_DescendingValues_PeekTracksMin()
    {
        var heap = new MinHeap();

        heap.Insert(10);
        Assert.Equal(10, heap.Peek());
        heap.Insert(5);
        Assert.Equal(5, heap.Peek());
        heap.Insert(2);
        Assert.Equal(2, heap.Peek());
        heap.Insert(1);
        Assert.Equal(1, heap.Peek());
    }
}
