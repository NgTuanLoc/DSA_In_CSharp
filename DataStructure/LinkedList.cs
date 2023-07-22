namespace DSA_In_CSharp.DataStructure
{
    public class Node
    {
        public int value { get; set; }
        public Node? next { get; set; }
        public Node(int data)
        {
            value = data;
            next = null;
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
                _tail.next = new Node(value);
                _tail = _tail.next;
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
                if (node.next == null)
                {
                    _head = null;
                    _tail = null;
                }
                if (node.next == _tail)
                {
                    _tail = node;
                    _tail.next = null;
                    break;
                }
                node = node.next;
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
                    var tempNode = new Node(value);
                    tempNode.next = _head;
                    _head = tempNode;
                    break;
                }
                if (position - 1 == count)
                {
                    var tempNode = node.next;
                    node.next = new Node(value);
                    node.next.next = tempNode;
                    break;
                }
                count++;
                node = node.next;
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
                    var tempNode = _head.next;
                    _head = tempNode;
                    break;
                }

                if (position - 1 == count)
                {
                    var removeNode = node.next;
                    node.next = removeNode?.next;
                    break;
                }
                count++;
                node = node.next;
            }
        }
        private int GetLinkedListLength()
        {
            var count = 0;
            var node = _head;
            while (node != null)
            {
                count++;
                node = node.next;
            }

            return count;
        }
        public void Print()
        {
            var node = _head;
            while (node != null)
            {
                Console.WriteLine(node.value);
                node = node.next;
            }
            Console.WriteLine("=====================");
        }
    }
}