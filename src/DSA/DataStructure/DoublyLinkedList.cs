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

    public int? Pop()
    {
        if (_tail == null) return null;

        var value = _tail.Value;
        if (_length == 1)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            _tail!.Next = null;
        }
        _length--;
        return value;
    }

    public void Unshift(int value)
    {
        var node = new DoublyNode(value);
        if (_head == null)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            node.Next = _head;
            _head.Prev = node;
            _head = node;
        }
        _length++;
    }

    public int? Shift()
    {
        if (_head == null) return null;

        var value = _head.Value;
        if (_length == 1)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head!.Prev = null;
        }
        _length--;
        return value;
    }

    public bool Set(int index, int value)
    {
        if (index < 0 || index >= _length) return false;

        var current = _head;
        for (var i = 0; i < index; i++)
            current = current!.Next;
        current!.Value = value;
        return true;
    }

    public bool Insert(int index, int value)
    {
        if (index < 0 || index > _length) return false;
        if (index == 0)
        {
            Unshift(value);
            return true;
        }
        if (index == _length)
        {
            Push(value);
            return true;
        }

        var current = _head;
        for (var i = 0; i < index; i++)
            current = current!.Next;

        var node = new DoublyNode(value)
        {
            Prev = current!.Prev,
            Next = current
        };
        current.Prev!.Next = node;
        current.Prev = node;
        _length++;
        return true;
    }

    public int? Remove(int index)
    {
        if (index < 0 || index >= _length) return null;
        if (index == 0) return Shift();
        if (index == _length - 1) return Pop();

        var current = _head;
        for (var i = 0; i < index; i++)
            current = current!.Next;

        current!.Prev!.Next = current.Next;
        current.Next!.Prev = current.Prev;
        _length--;
        return current.Value;
    }
}
