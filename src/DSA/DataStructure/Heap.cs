namespace DSA.DataStructure;

public class Heap
{
    public List<int> _data;

    public Heap()
    {
        _data = [];
    }

    public void Insert(int value)
    {
        _data.Add(value);
        BubbleUp();
    }

    public void BubbleUp()
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
}