namespace DSA_In_CSharp.Algorithm.SearchAlgorithm
{
    public static class BinarySearch
    {
        public static int? Sort(List<int> data, int target)
        {
            var start = 0;
            var end = data.Count - 1;
            var mid = (int)Math.Floor((double)(start + end) / 2);

            while (mid != 0 && start < end)
            {
                if (data[mid] == target) return mid;
                if (data[mid] < target) start = mid + 1;
                if (data[mid] > target) end = mid - 1;
                mid = (int)Math.Floor((double)(start + end) / 2);
            }
            return -1;
        }
    }
}