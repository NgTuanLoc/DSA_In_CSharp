using DSA.DataStructure;

namespace DSA.Tests.DataStructure;

public class StackTests
{
    [Fact]
    public void IsEmpty_OnNewStack_ReturnsTrue()
    {
        var stack = new Stack();

        Assert.True(stack.IsEmpty);
    }

    [Fact]
    public void Count_OnNewStack_ReturnsZero()
    {
        var stack = new Stack();

        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void Push_OnEmptyStack_IncrementsCountToOne()
    {
        var stack = new Stack();

        stack.Push(10);

        Assert.Equal(1, stack.Count);
        Assert.False(stack.IsEmpty);
    }

    [Fact]
    public void Push_MultipleValues_StoresInLIFOOrder()
    {
        var stack = new Stack();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(3, stack.Count);
        Assert.Equal(3, stack.Peek());
    }
}
