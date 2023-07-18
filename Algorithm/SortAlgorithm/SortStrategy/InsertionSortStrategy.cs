namespace DSA.Algorithm.SortAlgorithm.SortStrategy
{
    public class InsertionSortStrategy : ISortStrategy
    {
        public List<int> GetSortList(List<int> data)
        {
            var n = data.Count;
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
            return data;
        }
    }
}