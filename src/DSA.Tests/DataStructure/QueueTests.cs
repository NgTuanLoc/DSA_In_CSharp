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
}
