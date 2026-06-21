namespace DSA.DataStructure;

public class StackNode(int value)
{
    public int Value { get; set; } = value;
    public StackNode? Next { get; set; } = null;
}

public class Stack
{
    private StackNode? _top;
    private int _count;

    public int Count => _count;
    public bool IsEmpty => _count == 0;

    public void Push(int value)
    {
        var node = new StackNode(value) { Next = _top };
        _top = node;
        _count++;
    }

    public int Peek()
    {
        if (_top == null)
            throw new InvalidOperationException("Stack is empty");

        return _top.Value;
    }

    public int Pop()
    {
        if (_top == null)
            throw new InvalidOperationException("Stack is empty");

        var value = _top.Value;
        _top = _top.Next;
        _count--;
        return value;
    }
}
