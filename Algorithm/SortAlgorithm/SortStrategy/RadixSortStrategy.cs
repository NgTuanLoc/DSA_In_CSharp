
using System.Diagnostics;

namespace DSA.Algorithm.SortAlgorithm.SortStrategy;
public class RadixSortStrategy : ISortStrategy
{
    public List<int> GetSortList(List<int> data)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var maxDigitCount = MostDigit(data);
        for (int i = 0; i < maxDigitCount; i++)
        {
            var digitBucket = GenerateListOfNEmptyList(10);
            var negativeBucket = GenerateListOfNEmptyList(9);
            for (int j = 0; j < data.Count; j++)
            {
                var digit = GetDigit(data[j], i);

                if (data[j] >= 0)
                {
                    digitBucket[digit].Add(data[j]);
                }
                else
                {
                    negativeBucket[Math.Abs(9 - digit)].Add(data[j]);
                }
            }

            data = negativeBucket.SelectMany(list => list).ToList();
            data = data.Concat(digitBucket.SelectMany(list => list).ToList()).ToList();
        }
        stopWatch.Stop();
        TimeSpan elapsedTime = stopWatch.Elapsed;
        Console.WriteLine($"[RADIX SORT] Elapsed Time: {elapsedTime.TotalMicroseconds}");
        return data;
    }
    private static int GetDigit(int num, int place)
    {
        return (int)Math.Floor(Math.Abs(num) / Math.Pow(10, place)) % 10;
    }
    private static int DigitCount(int num)
    {
        if (num == 0) return 1;
        return (int)Math.Floor(Math.Log10(Math.Abs(num))) + 1;
    }
    private static int MostDigit(List<int> numList)
    {
        int max = 0;
        foreach (var num in numList)
        {
            if (max < DigitCount(num)) max = DigitCount(num);
        }
        return max;
    }
    private static List<List<int>> GenerateListOfNEmptyList(int n)
    {
        var list = new List<List<int>>();

        for (int k = 0; k < 10; k++)
        {
            list.Add(new List<int>());
        }
        return list;
    }
}