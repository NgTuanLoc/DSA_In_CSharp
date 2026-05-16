using DSA.DataStructure;

namespace DSA.Tests.DataStructure;

public class DoublyLinkedListTests
{
    [Fact]
    public void GetLength_OnNewList_ReturnsZero()
    {
        var list = new DoublyLinkedList();

        Assert.Equal(0, list.GetLength());
    }
}
