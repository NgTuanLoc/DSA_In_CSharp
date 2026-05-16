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
}
