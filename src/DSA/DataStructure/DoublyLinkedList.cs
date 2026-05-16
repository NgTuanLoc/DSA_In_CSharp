namespace DSA.DataStructure;

public class DoublyNode(int value)
{
    public int Value { get; set; } = value;
    public DoublyNode? Prev { get; set; } = null;
    public DoublyNode? Next { get; set; } = null;
}

public class DoublyLinkedList
{
    private DoublyNode? _head;
    private DoublyNode? _tail;
    private int _length;

    public int GetLength() => _length;
}
