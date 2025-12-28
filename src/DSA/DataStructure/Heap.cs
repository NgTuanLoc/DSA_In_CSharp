namespace DSA.DataStructure;

public class Heap
{
    private readonly List<int> _data;

    public Heap()
    {
        _data = [];
    }

    public int Count => _data.Count;

    public bool IsEmpty => _data.Count == 0;

    public void Insert(int value)
    {
        _data.Add(value);
        BubbleUp();
    }

    public int Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Heap is empty");

        return _data[0];
    }

    public int ExtractMax()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Heap is empty");

        int max = _data[0];
        int lastIndex = _data.Count - 1;
        _data[0] = _data[lastIndex];
        _data.RemoveAt(lastIndex);

        if (_data.Count > 0)
            BubbleDown();

        return max;
    }

    private void BubbleUp()
    {
        int index = _data.Count - 1;
        int insertedItem = _data[index];
        while (index > 0)
        {
            int parentIndex = (int)Math.Floor((double)(index - 1) / 2);
            int parentItem = _data[parentIndex];
            if (parentItem >= insertedItem) break;

            // swap parent to target when parent is smaller target
            _data[parentIndex] = insertedItem;
            _data[index] = parentItem;
            index = parentIndex;
        }
    }

    private void BubbleDown()
    {
        int index = 0;
        int length = _data.Count;
        int element = _data[0];

        while (true)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int largest = index;

            if (leftChildIndex < length && _data[leftChildIndex] > _data[largest])
            {
                largest = leftChildIndex;
            }

            if (rightChildIndex < length && _data[rightChildIndex] > _data[largest])
            {
                largest = rightChildIndex;
            }

            if (largest == index) break;

            // swap with the largest child
            _data[index] = _data[largest];
            _data[largest] = element;
            index = largest;
        }
    }

    public List<int> ToList()
    {
        return [.. _data];
    }

    public void Clear()
    {
        _data.Clear();
    }
}