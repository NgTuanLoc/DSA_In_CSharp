using System.Diagnostics;

namespace DSA.Algorithm.SortAlgorithm.SortStrategy;
public class InsertionSortStrategy : ISortStrategy
{
    public List<int> GetSortList(List<int> data)
    {
        var n = data.Count;
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 1; i < n; i++)
        {
            int key = data[i];
            int j = i - 1;

            while (j >= 0 && data[j] > key)
            {
                data[j + 1] = data[j];
                j--;
            }

            data[j + 1] = key;
        }
        stopWatch.Stop();
        TimeSpan elapsedTime = stopWatch.Elapsed;
        Console.WriteLine($"[INSERTION SORT] Elapsed Time: {elapsedTime.TotalMicroseconds}");
        return data;
    }
}