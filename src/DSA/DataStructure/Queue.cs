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
}
