using System.Diagnostics;

namespace DSA.Algorithm.SortAlgorithm.SortStrategy
{
    public class QuickSortStrategy : ISortStrategy
    {
        public List<int> GetSortList(List<int> data)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            QuickSort(data, 0, data.Count - 1);
            stopWatch.Stop();
            TimeSpan elapsedTime = stopWatch.Elapsed;
            Console.WriteLine($"[QUICK SORT] Elapsed Time: {elapsedTime.TotalMicroseconds}");
            return data;
        }
        private void QuickSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                var pivotIndex = Pivot(list, left, right);
                QuickSort(list, left, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, right);
            }
        }
        private int Pivot(List<int> list, int start, int end)
        {
            var pivot = list[start];
            var swapIndex = start;

            for (int i = start + 1; i <= end; i++)
            {
                if (pivot > list[i])
                {
                    swapIndex++;
                    Swap(list, swapIndex, i);
                }
            }
            Swap(list, start, swapIndex);
            return swapIndex;
        }
        private void Swap(List<int> data, int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
}