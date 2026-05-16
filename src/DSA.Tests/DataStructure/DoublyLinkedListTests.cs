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

    [Fact]
    public void Pop_OnEmptyList_ReturnsNull()
    {
        var list = new DoublyLinkedList();

        Assert.Null(list.Pop());
        Assert.Equal(0, list.GetLength());
    }

    [Fact]
    public void Pop_OnSingleElementList_EmptiesList()
    {
        var list = new DoublyLinkedList();
        list.Push(42);

        var popped = list.Pop();

        Assert.Equal(42, popped);
        Assert.Equal(0, list.GetLength());
        Assert.Null(list.Get(0));
    }

    [Fact]
    public void Pop_OnMultiElementList_RemovesAndReturnsTail()
    {
        var list = new DoublyLinkedList();
        list.Push(1);
        list.Push(2);
        list.Push(3);

        var popped = list.Pop();

        Assert.Equal(3, popped);
        Assert.Equal(2, list.GetLength());
        Assert.Equal(2, list.Get(1));
        Assert.Null(list.Get(2));
    }

    [Fact]
    public void Unshift_OnEmptyList_SetsHeadAndTail()
    {
        var list = new DoublyLinkedList();

        list.Unshift(10);

        Assert.Equal(1, list.GetLength());
        Assert.Equal(10, list.Get(0));
    }

    [Fact]
    public void Unshift_OnNonEmptyList_PrependsToHead()
    {
        var list = new DoublyLinkedList();
        list.Push(2);
        list.Push(3);

        list.Unshift(1);

        Assert.Equal(3, list.GetLength());
        Assert.Equal(1, list.Get(0));
        Assert.Equal(2, list.Get(1));
    }

    [Fact]
    public void Shift_OnEmptyList_ReturnsNull()
    {
        var list = new DoublyLinkedList();

        Assert.Null(list.Shift());
    }

    [Fact]
    public void Shift_RemovesAndReturnsHead()
    {
        var list = new DoublyLinkedList();
        list.Push(1);
        list.Push(2);
        list.Push(3);

        var shifted = list.Shift();

        Assert.Equal(1, shifted);
        Assert.Equal(2, list.GetLength());
        Assert.Equal(2, list.Get(0));
    }

    [Fact]
    public void Shift_OnSingleElementList_EmptiesList()
    {
        var list = new DoublyLinkedList();
        list.Push(42);

        list.Shift();

        Assert.Equal(0, list.GetLength());
        Assert.Null(list.Get(0));
    }

    [Fact]
    public void Set_ValidIndex_UpdatesValueAndReturnsTrue()
    {
        var list = new DoublyLinkedList();
        list.Push(1);
        list.Push(2);
        list.Push(3);

        var result = list.Set(1, 99);

        Assert.True(result);
        Assert.Equal(99, list.Get(1));
    }

    [Fact]
    public void Set_InvalidIndex_ReturnsFalse()
    {
        var list = new DoublyLinkedList();
        list.Push(1);

        Assert.False(list.Set(5, 99));
        Assert.False(list.Set(-1, 99));
    }

    [Fact]
    public void Insert_AtHead_DelegatesToUnshift()
    {
        var list = new DoublyLinkedList();
        list.Push(2);
        list.Push(3);

        var result = list.Insert(0, 1);

        Assert.True(result);
        Assert.Equal(3, list.GetLength());
        Assert.Equal(1, list.Get(0));
    }

    [Fact]
    public void Insert_AtTail_DelegatesToPush()
    {
        var list = new DoublyLinkedList();
        list.Push(1);
        list.Push(2);

        var result = list.Insert(2, 3);

        Assert.True(result);
        Assert.Equal(3, list.GetLength());
        Assert.Equal(3, list.Get(2));
    }

    [Fact]
    public void Insert_AtMiddle_LinksBothNeighbors()
    {
        var list = new DoublyLinkedList();
        list.Push(1);
        list.Push(3);

        var result = list.Insert(1, 2);

        Assert.True(result);
        Assert.Equal(3, list.GetLength());
        Assert.Equal(1, list.Get(0));
        Assert.Equal(2, list.Get(1));
        Assert.Equal(3, list.Get(2));
    }

    [Fact]
    public void Insert_InvalidIndex_ReturnsFalse()
    {
        var list = new DoublyLinkedList();
        list.Push(1);

        Assert.False(list.Insert(-1, 0));
        Assert.False(list.Insert(99, 0));
    }

    [Fact]
    public void Remove_AtHead_DelegatesToShift()
    {
        var list = new DoublyLinkedList();
        list.Push(1);
        list.Push(2);

        var removed = list.Remove(0);

        Assert.Equal(1, removed);
        Assert.Equal(2, list.Get(0));
    }

    [Fact]
    public void Remove_AtTail_DelegatesToPop()
    {
        var list = new DoublyLinkedList();
        list.Push(1);
        list.Push(2);

        var removed = list.Remove(1);

        Assert.Equal(2, removed);
        Assert.Equal(1, list.GetLength());
    }

    [Fact]
    public void Remove_AtMiddle_BridgesNeighbors()
    {
        var list = new DoublyLinkedList();
        list.Push(1);
        list.Push(2);
        list.Push(3);

        var removed = list.Remove(1);

        Assert.Equal(2, removed);
        Assert.Equal(2, list.GetLength());
        Assert.Equal(1, list.Get(0));
        Assert.Equal(3, list.Get(1));
    }

    [Fact]
    public void Remove_InvalidIndex_ReturnsNull()
    {
        var list = new DoublyLinkedList();
        list.Push(1);

        Assert.Null(list.Remove(-1));
        Assert.Null(list.Remove(99));
    }
}
