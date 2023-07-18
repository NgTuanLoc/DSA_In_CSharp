using System.Diagnostics;

namespace DSA.Algorithm.Helpers
{
    public static class SortHelper
    {
        public static void PrintList(List<int> data, string? title = null)
        {
            Console.WriteLine("========================================");
            if (title != null)
            {
                Console.WriteLine(title);
            }
            foreach (var item in data)
            {
                Console.Write($"{item} \t");
            }
            Console.WriteLine();
        }
        public static List<int> GenerateRandomArray(int length, int minValue, int maxValue)
        {
            Random random = new Random();
            List<int> data = new List<int>();

            for (int i = 0; i < length; i++)
            {
                data.Add(random.Next(minValue, maxValue + 1));
            }

            return data;
        }
    }
}