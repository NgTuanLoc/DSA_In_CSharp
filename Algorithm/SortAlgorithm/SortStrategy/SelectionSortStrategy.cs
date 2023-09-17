using System.Diagnostics;

namespace DSA.Algorithm.SortAlgorithm.SortStrategy
{
    public class SelectionSortStrategy : ISortStrategy
    {
        public List<int> GetSortList(List<int> data)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            int n = data.Count;

            for (int i = 0; i < n - 1; i++)
            {
                var minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (data[minIndex] > data[j])
                    {
                        minIndex = j;
                    }
                }
                (data[minIndex], data[i]) = (data[i], data[minIndex]);
            }
            stopWatch.Stop();
            TimeSpan elapsedTime = stopWatch.Elapsed;
            Console.WriteLine($"[SELECTION SORT] Elapsed Time: {elapsedTime.TotalMicroseconds}");
            return data;
        }
    }
}