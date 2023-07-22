using System.Collections;

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
        public List<int> BFS()
        {
            var data = new List<int>();
            var node = _root;
            if (node == null) return data;

            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                var tempNode = queue.Dequeue();
                data.Add(tempNode.value);
                if (tempNode.left != null) queue.Enqueue(tempNode.left);
                if (tempNode.right != null) queue.Enqueue(tempNode.right);
            }

            return data;
        }
        public List<int> DFSPreOrder()
        {
            var data = new List<int>();
            var currentNode = _root;
            if (currentNode == null) return data;

            TraversePreOrder(data, currentNode);

            return data;
        }
        public List<int> DFSPostOrder()
        {
            var data = new List<int>();
            var currentNode = _root;
            if (currentNode == null) return data;

            TraversePostOrder(data, currentNode);
            return data;
        }
        public List<int> DFSInOrder()
        {
            var data = new List<int>();
            var currentNode = _root;
            if (currentNode == null) return data;

            TraverseInOrder(data, currentNode);
            return data;
        }
        private void TraversePreOrder(List<int> data, Node node)
        {
            data.Add(node.value);
            if (node.left != null) TraversePreOrder(data, node.left);
            if (node.right != null) TraversePreOrder(data, node.right);
        }
        private void TraversePostOrder(List<int> data, Node node)
        {
            if (node.left != null) TraversePostOrder(data, node.left);
            if (node.right != null) TraversePostOrder(data, node.right);
            data.Add(node.value);
        }
        private void TraverseInOrder(List<int> data, Node node)
        {
            if (node.left != null) TraverseInOrder(data, node.left);
            data.Add(node.value);
            if (node.right != null) TraverseInOrder(data, node.right);
        }
    }
}