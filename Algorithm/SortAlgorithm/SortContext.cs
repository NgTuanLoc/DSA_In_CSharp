using DSA.Algorithm.Helpers;
using DSA.Algorithm.SortAlgorithm.SortStrategy;

namespace DSA.Algorithm.SortAlgorithm;
public class SortContext
{
    private ISortStrategy _sortStrategy;
    private readonly List<int> _data;
    public SortContext()
    {
        _sortStrategy = new BubbleSortStrategy();
        _data = SortHelper.GenerateRandomArray(10, -1000, 1000);
        _data = new List<int>()
            {
                4, 6,9,1, 2, -5,3
            };
    }
    public void SetSortStrategy(ISortStrategy sortStrategy)
    {
        _sortStrategy = sortStrategy;
    }
    public List<int> Sort()
    {
        return _sortStrategy.GetSortList(Clone());
    }
    private List<int> Clone()
    {
        List<int> clone = new List<int>(_data);
        return clone;
    }
    public void PrintList()
    {
        foreach (var item in _data)
        {
            Console.WriteLine(item);
        }
    }
}