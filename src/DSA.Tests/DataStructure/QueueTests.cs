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

    [Fact]
    public void Dequeue_OnEmptyQueue_ThrowsInvalidOperationException()
    {
        var queue = new Queue();

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    [Fact]
    public void Dequeue_ReturnsFirstEnqueued_FIFO()
    {
        var queue = new Queue();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        var first = queue.Dequeue();
        var second = queue.Dequeue();

        Assert.Equal(1, first);
        Assert.Equal(2, second);
        Assert.Equal(1, queue.Count);
        Assert.Equal(3, queue.Peek());
    }

    [Fact]
    public void Dequeue_UntilEmpty_ResetsHeadAndTail()
    {
        var queue = new Queue();
        queue.Enqueue(99);

        queue.Dequeue();

        Assert.True(queue.IsEmpty);
        Assert.Equal(0, queue.Count);
        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }
}
