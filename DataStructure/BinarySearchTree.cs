namespace DSA.DataStructure;
public class Node(int n)
{
    public int Value { get; set; } = n;
    public Node? Left { get; set; } = null;
    public Node? Right { get; set; } = null;
}

public class BinarySearchTree
{
    private Node? _root = null;

    public void Insert(int value)
    {
        var newNode = new Node(value);
        var currentNode = _root;

        if (currentNode == null)
        {
            _root = newNode;
            return;
        }

        while (true)
        {
            if (value == currentNode.Value) return;

            if (value < currentNode.Value)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = newNode;
                    return;
                }
                currentNode = currentNode.Left;
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = newNode;
                    return;
                }
                currentNode = currentNode.Right;
            }
        }
    }
    public bool Find(int value)
    {
        const bool found = false;
        var currentNode = _root;

        if (currentNode == null) return false;

        while (currentNode != null)
        {
            if (value == currentNode.Value) return true;
            currentNode = value < currentNode.Value ? currentNode.Left : currentNode.Right;
        }

        return found;
    }
    public List<int> Bfs()
    {
        var data = new List<int>();
        var node = _root;
        if (node == null) return data;

        var queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count != 0)
        {
            var tempNode = queue.Dequeue();
            data.Add(tempNode.Value);
            if (tempNode.Left != null) queue.Enqueue(tempNode.Left);
            if (tempNode.Right != null) queue.Enqueue(tempNode.Right);
        }

        return data;
    }
    public List<int> DfsPreOrder()
    {
        var data = new List<int>();
        var currentNode = _root;
        if (currentNode == null) return data;

        TraversePreOrder(data, currentNode);

        return data;
    }
    public List<int> DfsPostOrder()
    {
        var data = new List<int>();
        var currentNode = _root;
        if (currentNode == null) return data;

        TraversePostOrder(data, currentNode);
        return data;
    }
    public List<int> DfsInOrder()
    {
        var data = new List<int>();
        var currentNode = _root;
        if (currentNode == null) return data;

        TraverseInOrder(data, currentNode);
        return data;
    }
    private static void TraversePreOrder(List<int> data, Node node)
    {
        data.Add(node.Value);
        if (node.Left != null) TraversePreOrder(data, node.Left);
        if (node.Right != null) TraversePreOrder(data, node.Right);
    }
    private static void TraversePostOrder(List<int> data, Node node)
    {
        if (node.Left != null) TraversePostOrder(data, node.Left);
        if (node.Right != null) TraversePostOrder(data, node.Right);
        data.Add(node.Value);
    }
    private static void TraverseInOrder(List<int> data, Node node)
    {
        if (node.Left != null) TraverseInOrder(data, node.Left);
        data.Add(node.Value);
        if (node.Right != null) TraverseInOrder(data, node.Right);
    }
}