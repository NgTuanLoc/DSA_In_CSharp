using DSA.Algorithm.Helpers;

namespace DSA.Algorithm.SortAlgorithm.SortStrategy
{
    public class RadixSortStrategy : ISortStrategy
    {
        public List<int> GetSortList(List<int> data)
        {
            var maxDigitCount = MostDigit(data);
            for (int i = 0; i < maxDigitCount; i++)
            {
                var digitBucket = new List<List<int>>();
                for (int k = 0; k < 10; k++)
                {
                    digitBucket.Add(new List<int>());
                }
                Console.WriteLine(i);

                for (int j = 0; j < data.Count; j++)
                {
                    var digit = GetDigit(data[j], i);
                    digitBucket[digit].Add(data[j]);
                }

                data = digitBucket.SelectMany(list => list).ToList();
            }
            return data;
        }
        private int GetDigit(int num, int place)
        {
            return (int)Math.Floor(Math.Abs(num) / Math.Pow(10, place)) % 10;
        }
        private int DigitCount(int num)
        {
            if (num == 0) return 1;
            return (int)Math.Floor(Math.Log10(Math.Abs(num))) + 1;
        }
        private int MostDigit(List<int> numList)
        {
            int max = 0;
            foreach (var num in numList)
            {
                if (max < DigitCount(num)) max = DigitCount(num);
            }
            return max;
        }
    }
}