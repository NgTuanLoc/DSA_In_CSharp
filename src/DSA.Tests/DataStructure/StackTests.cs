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
}
