namespace DSA_In_CSharp.DataStructure;
public class Node
{
    public int Value { get; set; }
    public Node? Next { get; set; }
    public Node(int data)
    {
        Value = data;
        Next = null;
    }
}
public class LinkedList
{
    private Node? _head;
    private Node? _tail;
    public LinkedList()
    {
        _head = null;
        _tail = null;
    }
    public void Push(int value)
    {
        if (_head == null)
        {
            _head = new Node(value);
            _tail = _head;
            return;
        }

        if (_tail != null)
        {
            _tail.Next = new Node(value);
            _tail = _tail.Next;
        }
    }
    public Node? Pop()
    {
        if (_head == null)
        {
            Console.WriteLine("List is empty");
            return null;
        }

        var node = _head;
        while (node != null)
        {
            if (node.Next == null)
            {
                _head = null;
                _tail = null;
            }
            if (node.Next == _tail)
            {
                _tail = node;
                _tail.Next = null;
                break;
            }
            node = node.Next;
        }
        return _tail;
    }
    public void Insert(int position, int value)
    {
        var node = _head;
        var count = 1;
        while (node != null)
        {
            if (position == 0)
            {
                var tempNode = new Node(value)
                {
                    Next = _head
                };
                _head = tempNode;
                break;
            }
            if (position - 1 == count)
            {
                var tempNode = node.Next;
                node.Next = new Node(value)
                {
                    Next = tempNode
                };
                break;
            }
            count++;
            node = node.Next;
        }
    }
    public void Remove(int position)
    {
        var node = _head;
        var count = 1;

        if (_head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        while (node != null)
        {
            if (position == 0)
            {
                var tempNode = _head.Next;
                _head = tempNode;
                break;
            }

            if (position - 1 == count)
            {
                var removeNode = node.Next;
                node.Next = removeNode?.Next;
                break;
            }
            count++;
            node = node.Next;
        }
    }
    public int GetLinkedListLength()
    {
        var count = 0;
        var node = _head;
        while (node != null)
        {
            count++;
            node = node.Next;
        }

        return count;
    }
    public void Print()
    {
        var node = _head;
        while (node != null)
        {
            Console.WriteLine(node.Value);
            node = node.Next;
        }
        Console.WriteLine("=====================");
    }
}