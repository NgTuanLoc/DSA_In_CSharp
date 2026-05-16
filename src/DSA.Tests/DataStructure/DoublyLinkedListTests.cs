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

    [Fact]
    public void Push_OnEmptyList_SetsHeadAndTailToSameNode()
    {
        var list = new DoublyLinkedList();

        list.Push(10);

        Assert.Equal(1, list.GetLength());
        Assert.Equal(10, list.Get(0));
    }

    [Fact]
    public void Push_MultipleValues_LinksTailToTail()
    {
        var list = new DoublyLinkedList();

        list.Push(1);
        list.Push(2);
        list.Push(3);

        Assert.Equal(3, list.GetLength());
        Assert.Equal(1, list.Get(0));
        Assert.Equal(2, list.Get(1));
        Assert.Equal(3, list.Get(2));
    }

    [Fact]
    public void Get_IndexOutOfRange_ReturnsNull()
    {
        var list = new DoublyLinkedList();
        list.Push(1);

        Assert.Null(list.Get(5));
        Assert.Null(list.Get(-1));
    }
}
