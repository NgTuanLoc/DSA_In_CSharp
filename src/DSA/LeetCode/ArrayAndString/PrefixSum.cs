namespace DSA.LeetCode.ArrayAndString;

// TIPS
//  =========================== Building a prefix ===========================
//Given an array nums,

//prefix = [nums[0]]
//for (int i = 1; i<nums.length; i++)
//    prefix.append(nums[i] + prefix[prefix.length - 1])
//
// Formular to calculate the sum of subArray[i, j] = prefix[j] - prefix[i] + num[i]

public class PrefixSum
{
    //Example 1: Given an integer array nums, an array queries where queries[i] = [x, y] and an integer limit, return a boolean array that represents the answer to each query.A query is true if the sum of the subarray from x to y is less than limit, or false otherwise.

    //For example, given nums = [1, 6, 3, 2, 7, 2], queries = [[0, 3], [2, 5], [2, 4]], and limit = 13, the answer is [true, false, true]. For each query, the subarray sums are [12, 14, 12].

    public static List<bool> AnswerQueries(List<int> nums, List<List<int>> queries, int limit)
    {
        List<int> prefix = [nums[0]];
        List<bool> answers = [];

        for (var i = 1; i < nums.Count; i++)
        {
            prefix.Add(nums[i] + prefix[^1]);
        }

        foreach (var item in queries)
        {
            var left = item[0];
            var right = item[1];

            var temp = prefix[right] - prefix[left] + nums[left];
            answers.Add(temp < limit);
        }

        return answers;
    }

    public static int WaysToSplitArray(List<int> nums)
    {
        //https://leetcode.com/problems/number-of-ways-to-split-array/description/
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
        //https://leetcode.com/problems/running-sum-of-1d-array/description/
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
        //https://leetcode.com/problems/minimum-value-to-get-positive-step-by-step-sum/description/
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
        // https://leetcode.com/problems/k-radius-subarray-averages/description/
        var result = new int[nums.Length];
        var prefix = new long[nums.Length];
        prefix[0] = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            prefix[i] = prefix[i - 1] + nums[i];
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var leftIndex = i - k;
            var rightIndex = i + k;
            if (leftIndex < 0 || rightIndex > nums.Length - 1)
            {
                result[i] = -1;
                continue;
            }

            var n = rightIndex - leftIndex + 1;
            var sum = prefix[rightIndex] - prefix[leftIndex] + nums[i - k];
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
        var n = nums.Length;

        if (nums.Length == 1) return 0;

        for (var i = 1; i < n; i++)
        {
            prefix.Add(prefix[^1] + nums[i]);
        }

        for (var pivot = 0; pivot < n - 1; pivot++)
        {
            var sumRight = prefix[^1] - prefix[pivot + 1] + nums[pivot + 1];

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
