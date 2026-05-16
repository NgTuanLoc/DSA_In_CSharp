namespace DSA.DataStructure;

public class QueueNode(int value)
{
    public int Value { get; set; } = value;
    public QueueNode? Next { get; set; } = null;
}

public class Queue
{
    private QueueNode? _head;
    private QueueNode? _tail;
    private int _count;

    public int Count => _count;
    public bool IsEmpty => _count == 0;

    public void Enqueue(int value)
    {
        var node = new QueueNode(value);
        if (_tail == null)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            _tail.Next = node;
            _tail = node;
        }
        _count++;
    }

    public int Peek()
    {
        if (_head == null)
            throw new InvalidOperationException("Queue is empty");

        return _head.Value;
    }

    public int Dequeue()
    {
        if (_head == null)
            throw new InvalidOperationException("Queue is empty");

        var value = _head.Value;
        _head = _head.Next;
        if (_head == null)
            _tail = null;
        _count--;
        return value;
    }
}
