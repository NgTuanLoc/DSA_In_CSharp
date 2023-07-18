namespace DSA.Algorithm.SortAlgorithm.SortStrategy
{
    public class SelectionSortStrategy : ISortStrategy
    {
        public List<int> GetSortList(List<int> data)
        {
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
                int temp = data[i];
                data[i] = data[minIndex];
                data[minIndex] = temp;
            }
            return data;
        }
    }
}