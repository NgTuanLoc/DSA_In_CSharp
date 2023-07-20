using System.Diagnostics;
using DSA.Algorithm.Helpers;

namespace DSA.Algorithm.SortAlgorithm.SortStrategy
{
    public class MergeSortStrategy : ISortStrategy
    {
        public List<int> GetSortList(List<int> data)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = MergeSort(data);
            stopWatch.Stop();
            TimeSpan elapsedTime = stopWatch.Elapsed;
            Console.WriteLine($"[MERGE SORT] Elapsed Time: {elapsedTime.TotalMicroseconds}");
            return result;
        }
        public List<int> MergeSort(List<int> data)
        {
            if (data.Count <= 1) return data;
            var mid = (int)Math.Floor((double)data.Count / 2);
            var left = MergeSort(data.Take(mid).ToList());
            var right = MergeSort(data.Skip(mid).ToList());

            return MergeTwoList(left, right);
        }
        private List<int> MergeTwoList(List<int> list1, List<int> list2)
        {
            var list = new List<int>();
            var i = 0;
            var j = 0;

            while (i < list1.Count && j < list2.Count)
            {
                if (list1[i] > list2[j])
                {
                    list.Add(list2[j]);
                    j++;
                }
                else
                {
                    list.Add(list1[i]);
                    i++;
                }
            }

            if (i < list1.Count)
            {
                var restOfDataList = list1.GetRange(i, list1.Count - i);
                list = list.Concat(restOfDataList).ToList();
            }

            if (j < list2.Count)
            {
                var restOfDataList = list2.GetRange(j, list2.Count - j);
                list = list.Concat(restOfDataList).ToList();
            }
            return list;
        }
    }
}