using DSA.DataStructure;

namespace DSA.Tests.DataStructure;

public class QueueTests
{
    [Fact]
    public void IsEmpty_OnNewQueue_ReturnsTrue()
    {
        var queue = new Queue();

        Assert.True(queue.IsEmpty);
    }

    [Fact]
    public void Count_OnNewQueue_ReturnsZero()
    {
        var queue = new Queue();

        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Enqueue_OnEmptyQueue_SetsHeadAndTail()
    {
        var queue = new Queue();

        queue.Enqueue(10);

        Assert.Equal(1, queue.Count);
        Assert.Equal(10, queue.Peek());
    }

    [Fact]
    public void Enqueue_MultipleValues_PeeksFirstEnqueued()
    {
        var queue = new Queue();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Assert.Equal(3, queue.Count);
        Assert.Equal(1, queue.Peek());
    }

    [Fact]
    public void Peek_OnEmptyQueue_ThrowsInvalidOperationException()
    {
        var queue = new Queue();

        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }
}
