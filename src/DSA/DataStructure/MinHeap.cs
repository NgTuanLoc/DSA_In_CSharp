namespace DSA.DataStructure;

public class MinHeap
{
    private readonly List<int> _data = [];

    public int Count => _data.Count;
    public bool IsEmpty => _data.Count == 0;

    public void Clear() => _data.Clear();
}
