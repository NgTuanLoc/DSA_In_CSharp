namespace DSA;

public enum HeapType { MinHeap, MaxHeap }

interface IHeap<T> where T : IComparable<T>
{
    bool IsEmpty();
    void Insert(T item);
    void BubbleUp();
    void BubbleDown();
    T Remove();
}

public class Heap<T>(HeapType heapType) : IHeap<T> where T : IComparable<T>
{
    public List<T> Data = [];
    private readonly HeapType _HeapType = heapType;

    public void BubbleDown()
    {
        int idx = 0;
        int length = Data.Count;
        T element = Data[0]; // *Element need to be bubble down

        while (true)
        {
            var leftChildIdx = 2 * idx + 1;
            var rightChildIdx = 2 * idx + 2;
            int? swap = null;

            if (leftChildIdx < length)
            {
                T leftChild = Data[leftChildIdx];
                if (Compare(leftChild, element) < 0) swap = leftChildIdx;
            }

            if (rightChildIdx < length)
            {
                T rightChild = Data[rightChildIdx];
                if ((swap == null && Compare(rightChild, element) < 0) || (swap != null && Compare(rightChild, element) < 0)) swap = rightChildIdx;
            }

            if (swap == null) break;

            (Data[swap.Value], Data[idx]) = (Data[idx], Data[swap.Value]);
            idx = swap.Value;
        }
    }

    public void BubbleUp()
    {
        int index = Data.Count - 1;

        while (index > 0)
        {
            int parentIndex = (int)Math.Floor((double)index - 1) / 2;
            T parentItem = Data[parentIndex];
            if (Compare(parentItem, Data[index]) < 0) break;
            Data[parentIndex] = Data[index];
            Data[index] = parentItem;
            index = parentIndex;
        }
    }

    public void Insert(T item)
    {
        Data.Add(item);
        BubbleUp();
    }

    public bool IsEmpty()
    {
        return Data.Count == 0;
    }

    public T Remove()
    {
        if (IsEmpty()) throw new InvalidOperationException("Heap is empty");

        T root = Data[0];

        if (Data.Count == 1)
        {
            Data.RemoveAt(0);
            return root;
        }

        Data[0] = Data[^1];
        Data.RemoveAt(Data.Count - 1);
        BubbleDown();
        return root;
    }

    private int Compare(T x, T y)
    {
        if (_HeapType == HeapType.MinHeap) return x.CompareTo(y);
        return y.CompareTo(x);
    }
}
