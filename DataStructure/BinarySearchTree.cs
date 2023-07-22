namespace DSA_In_CSharp.Algorithm
{
    public class Node
    {
        public int value { get; set; }
        public Node? left { get; set; }
        public Node? right { get; set; }
        public Node(int n)
        {
            value = n;
            left = null;
            right = null;
        }
    }

    public class BinarySearchTree
    {
        private Node? _root;
        public BinarySearchTree()
        {
            _root = null;
        }
        public void Insert(int value)
        {
            var newNode = new Node(value);
            var currentNode = _root;

            if (currentNode == null)
            {
                _root = newNode;
            }
            else
            {
                while (true)
                {
                    if (value == currentNode.value) return;

                    if (value < currentNode.value)
                    {
                        if (currentNode.left == null)
                        {
                            currentNode.left = newNode;
                            return;
                        }
                        currentNode = currentNode.left;
                    }
                    else
                    {
                        if (currentNode.right == null)
                        {
                            currentNode.right = newNode;
                            return;
                        }
                        currentNode = currentNode.right;
                    }
                }
            }
        }
        public bool Find(int value)
        {
            var found = false;
            var currentNode = _root;

            if (currentNode == null) return false;

            while (currentNode != null)
            {
                if (value == currentNode.value) return true;
                if (value < currentNode.value)
                {
                    currentNode = currentNode.left;
                }
                else
                {
                    currentNode = currentNode.right;
                }
            }

            return found;
        }
    }
}