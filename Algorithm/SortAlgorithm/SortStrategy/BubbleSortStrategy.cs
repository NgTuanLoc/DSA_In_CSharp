using System.Diagnostics;

namespace DSA.Algorithm.SortAlgorithm.SortStrategy
{
    public class BubbleSortStrategy : ISortStrategy
    {
        public List<int> GetSortList(List<int> data)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var n = data.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        (data[j + 1], data[j]) = (data[j], data[j + 1]);
                    }
                }
            }
            stopWatch.Stop();
            TimeSpan elapsedTime = stopWatch.Elapsed;
            Console.WriteLine($"[BUBBLE SORT] Elapsed Time: {elapsedTime.TotalMicroseconds}");
            return data;
        }
    }
}