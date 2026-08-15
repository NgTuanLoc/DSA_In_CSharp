namespace DSA.LeetCode.BinarySearch;

public class BinarySearchExample
{
    public static void Run()
    {
        // !Search Insert Position
        Console.WriteLine(SearchInsert([1, 3, 5, 6], 5));
        Console.WriteLine(SearchInsert([1, 3, 5, 6], 2));
        Console.WriteLine(SearchInsert([1, 3, 5, 6], 7));
    }

    public static int SearchInsert(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (int)Math.Floor((double)(right - left) / 2);
            if (nums[mid] == target) return mid;
            if (nums[mid] < target)
            {
                left = mid + 1;
                continue;
            }
            right = mid - 1;
        }
        return left;
    }
}