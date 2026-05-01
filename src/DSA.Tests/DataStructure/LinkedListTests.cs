using DSA_In_CSharp.DataStructure;

namespace DSA.Tests.DataStructure;

public class LinkedListTests
{
    [Fact]
    public void Push_ToEmptyList_CreatesHeadAndTail()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);

        Assert.Equal(1, list.GetLinkedListLength());
    }

    [Fact]
    public void Push_MultipleValues_AppendsToEnd()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);
        list.Push(20);
        list.Push(30);

        Assert.Equal(3, list.GetLinkedListLength());
    }

    [Fact]
    public void Pop_EmptyList_ReturnsNull()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        var result = list.Pop();

        Assert.Null(result);
    }

    [Fact]
    public void Pop_SingleElement_RemovesElement()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);
        list.Pop();

        Assert.Equal(0, list.GetLinkedListLength());
    }

    [Fact]
    public void Pop_MultipleElements_RemovesLastElement()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);
        list.Push(20);
        list.Push(30);

        var popped = list.Pop();

        Assert.Equal(2, list.GetLinkedListLength());
        Assert.Equal(20, popped?.Value);
    }

    [Fact]
    public void Insert_AtPosition0_InsertsAtHead()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);
        list.Push(20);
        list.Insert(0, 5);

        Assert.Equal(3, list.GetLinkedListLength());
    }

    [Fact]
    public void Insert_InTheMiddle_InsertsCorrectly()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);
        list.Push(20);
        list.Push(30);
        list.Insert(2, 15);

        Assert.Equal(4, list.GetLinkedListLength());
    }

    [Fact]
    public void Insert_AtEnd_InsertsCorrectly()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);
        list.Push(20);
        list.Insert(2, 25);

        Assert.Equal(3, list.GetLinkedListLength());
    }

    [Fact]
    public void Insert_EmptyList_DoesNothing()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Insert(0, 10);

        // Insert on empty list does nothing because while loop never executes
        Assert.Equal(0, list.GetLinkedListLength());
    }

    [Fact]
    public void Remove_AtPosition0_RemovesHead()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);
        list.Push(20);
        list.Push(30);
        list.Remove(0);

        Assert.Equal(2, list.GetLinkedListLength());
    }

    [Fact]
    public void Remove_FromMiddle_RemovesElement()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);
        list.Push(20);
        list.Push(30);
        list.Remove(2);

        Assert.Equal(2, list.GetLinkedListLength());
    }

    [Fact]
    public void Remove_LastElement_RemovesCorrectly()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);
        list.Push(20);
        list.Push(30);
        list.Remove(2);

        Assert.Equal(2, list.GetLinkedListLength());
    }

    [Fact]
    public void Remove_EmptyList_DoesNothing()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Remove(0);

        Assert.Equal(0, list.GetLinkedListLength());
    }

    [Fact]
    public void Remove_InvalidPosition_DoesNothing()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(10);
        list.Push(20);
        list.Remove(5);

        Assert.Equal(2, list.GetLinkedListLength());
    }

    [Fact]
    public void GetLinkedListLength_EmptyList_ReturnsZero()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();

        Assert.Equal(0, list.GetLinkedListLength());
    }

    [Fact]
    public void GetLinkedListLength_WithElements_ReturnsCorrectCount()
    {
        var list = new DSA_In_CSharp.DataStructure.LinkedList();
        list.Push(1);
        list.Push(2);
        list.Push(3);
        list.Push(4);
        list.Push(5);

        Assert.Equal(5, list.GetLinkedListLength());
    }
}

public class NodeTests
{
    [Fact]
    public void Node_Constructor_SetsValue()
    {
        var node = new DSA_In_CSharp.DataStructure.Node(42);

        Assert.Equal(42, node.Value);
        Assert.Null(node.Next);
    }

    [Fact]
    public void Node_LinkedNodes_PointCorrectly()
    {
        var node1 = new DSA_In_CSharp.DataStructure.Node(10);
        var node2 = new DSA_In_CSharp.DataStructure.Node(20);
        node1.Next = node2;

        Assert.Equal(node2, node1.Next);
        Assert.Equal(20, node1.Next.Value);
    }
}
