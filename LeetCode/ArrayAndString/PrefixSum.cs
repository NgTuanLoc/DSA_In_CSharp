namespace DSA.LeetCode.ArrayAndString;

public class PrefixSum
{
    public static List<bool> AnswerQueries(List<int> nums, List<List<int>> queries, int limit)
    {
        List<int> prefix = [nums[0]];
        List<bool> answers = [];

        for (int i = 1; i < nums.Count; i++)
        {
            prefix.Add(nums[i] + prefix[^1]);
        }

        foreach (var item in queries)
        {
            int left = item[0];
            int right = item[1];

            int temp = prefix[right] - prefix[left] + nums[left];
            answers.Add(temp < limit);
        }

        return answers;
    }

    public static int WaysToSplitArray(List<int> nums)
    {
        List<int> prefix = [nums[0]];

        for (int i = 1; i < nums.Count; i++)
        {
            prefix.Add(nums[i] + prefix[^1]);
        }

        int result = 0;
        for (int i = 0; i < nums.Count - 1; i++)
        {
            int left = prefix[i];
            int right = prefix[nums.Count - 1] - prefix[i + 1] + nums[i + 1];
            if (left >= right) result++;
        }

        return result;
    }
    public static int[] RunningSum(int[] nums)
    {
        int[] result = new int[nums.Length];
        result[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            result[i] = nums[i] + result[i - 1];
        }

        return result;
    }

    public static int MinStartValue(int[] nums)
    {
        int[] prefix = new int[nums.Length];
        prefix[0] = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] = nums[i] + prefix[i - 1];
        }

        var result = 1 - prefix.Min();

        return result < 1 ? 1 : result;
    }

    public static int[] GetAverages(int[] nums, int k)
    {
        int[] result = new int[nums.Length];
        long[] prefix = new long[nums.Length];
        prefix[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefix[i] = prefix[i - 1] + nums[i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int leftIndex = i - k;
            int rightIndex = i + k;
            if (leftIndex < 0 || rightIndex > nums.Length - 1)
            {
                result[i] = -1;
                continue;
            }

            long n = rightIndex - leftIndex + 1;
            long sum = prefix[rightIndex] - prefix[leftIndex] + nums[i - k];
            result[i] = Convert.ToInt32(sum / n);
        }

        return result;
    }

    public static int LargestAltitude(int[] gain)
    {
        // https://leetcode.com/problems/find-the-highest-altitude/
        int answer = 0;
        List<int> altitudeList = [0];

        for (int i = 0; i < gain.Length; i++)
        {
            altitudeList.Add(altitudeList[i] + gain[i]);
            answer = Math.Max(answer, altitudeList[^1]);
        }

        return answer;
    }

    public static int PivotIndex(int[] nums)
    {
        // https://leetcode.com/problems/find-pivot-index/description/
        List<int> prefix = [nums[0]];
        int n = nums.Length;

        if (nums.Length == 1) return 0;

        for (int i = 1; i < n; i++)
        {
            prefix.Add(prefix[^1] + nums[i]);
        }

        for (int pivot = 0; pivot < n - 1; pivot++)
        {
            int sumRight = prefix[^1] - prefix[pivot + 1] + nums[pivot + 1];

            if (pivot == 0)
            {
                if (sumRight == 0) return 0;
                continue;
            }
            if (prefix[pivot - 1] == sumRight) return pivot;
        }
        if (prefix[n - 2] == 0) return n - 1;

        return -1;
    }
}
