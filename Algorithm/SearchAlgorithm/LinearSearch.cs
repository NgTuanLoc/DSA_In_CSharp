namespace DSA_In_CSharp.Algorithm.SearchAlgorithm
{
    public static class LinearSearch
    {
        public static int? Sort(List<int> data, int target)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == target) return i;
            }
            return null;
        }
    }
}