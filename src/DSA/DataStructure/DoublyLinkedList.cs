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

    public void Push(int value)
    {
        var node = new DoublyNode(value);
        if (_tail == null)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            node.Prev = _tail;
            _tail.Next = node;
            _tail = node;
        }
        _length++;
    }

    public int? Get(int index)
    {
        if (index < 0 || index >= _length) return null;

        DoublyNode? current;
        if (index < _length / 2)
        {
            current = _head;
            for (var i = 0; i < index; i++)
                current = current!.Next;
        }
        else
        {
            current = _tail;
            for (var i = _length - 1; i > index; i--)
                current = current!.Prev;
        }
        return current!.Value;
    }
}
