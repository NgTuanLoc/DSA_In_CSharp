namespace DSA.DataStructure;

public class MinHeap
{
    private readonly List<int> _data = [];

    public int Count => _data.Count;
    public bool IsEmpty => _data.Count == 0;

    public void Clear() => _data.Clear();

    public int Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Heap is empty");

        return _data[0];
    }

    public void Insert(int value)
    {
        _data.Add(value);
        BubbleUp();
    }

    private void BubbleUp()
    {
        var index = _data.Count - 1;
        var inserted = _data[index];
        while (index > 0)
        {
            var parentIndex = (index - 1) / 2;
            var parent = _data[parentIndex];
            if (parent <= inserted) break;

            _data[parentIndex] = inserted;
            _data[index] = parent;
            index = parentIndex;
        }
    }

    public int ExtractMin()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Heap is empty");

        var min = _data[0];
        var lastIndex = _data.Count - 1;
        _data[0] = _data[lastIndex];
        _data.RemoveAt(lastIndex);

        if (_data.Count > 0)
            BubbleDown();

        return min;
    }

    public List<int> ToList() => [.. _data];

    private void BubbleDown()
    {
        var index = 0;
        var length = _data.Count;
        var element = _data[0];

        while (true)
        {
            var leftIndex = 2 * index + 1;
            var rightIndex = 2 * index + 2;
            var smallest = index;

            if (leftIndex < length && _data[leftIndex] < _data[smallest])
                smallest = leftIndex;

            if (rightIndex < length && _data[rightIndex] < _data[smallest])
                smallest = rightIndex;

            if (smallest == index) break;

            _data[index] = _data[smallest];
            _data[smallest] = element;
            index = smallest;
        }
    }
}
