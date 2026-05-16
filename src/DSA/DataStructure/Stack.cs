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
}
