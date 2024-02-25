namespace DSA.LeetCode.ArrayAndString;

public static class SlidingWindow
{
    // !Sliding Window
    public static int FindMaxLengthOfTheSubArraySmallerThanK(List<int> nums, int k)
    {
        int left = 0;
        int curr = 0;
        int answer = 0;

        for (int right = 0; right < nums.Count; right++)
        {
            curr += nums[right];

            while (curr > k)
            {
                curr -= nums[left];
                left++;
            }
            answer = Math.Max(answer, right - left + 1);
        }

        return answer;
    }

    // !Sliding Window
    public static int FindTheLongestLengthOfSubStringThatContainOnlyOne(string s)
    {
        int answer = 0;
        int left = 0;
        // Number of '0' in the sub-array
        int curr = 0;

        for (int right = 0; right < s.Length; right++)
        {
            if (s[right] == '0') curr++;

            while (curr > 1)
            {
                if (s[left] == '0') curr--;
                left++;
            }

            answer = Math.Max(answer, right - left + 1);
        }

        return answer;
    }

    // !Number of SubArrays
    public static int NumSubArrayProductLessThanK(List<int> nums, int k)
    {
        if (k <= 1) return 0;

        int answer = 0;
        int left = 0;
        int curr = 1;

        for (int right = 0; right < nums.Count; right++)
        {
            curr *= nums[right];

            while (curr >= k)
            {
                curr /= nums[left];
                left++;
            }

            answer += right - left + 1;
        }

        return answer;
    }

    // !Fixed Window Size
    // *Given an integer array nums and an integer k, find the sum of the SubArray with the largest sum whose length is k.
    public static int FindBestSubArray(List<int> nums, int k)
    {
        int curr = 0;

        for (int i = 0; i < k; i++)
        {
            curr += nums[i];
        }

        int result = curr;

        for (int i = k; i < nums.Count; i++)
        {
            curr += nums[i] - nums[i - k];
            result = Math.Max(curr, result);
        }

        return result;
    }

    public static double FindMaxAverage(int[] nums, int k)
    {
        double curr = 0;

        for (int i = 0; i < k; i++)
        {
            curr += nums[i];
        }

        double result = curr;
        for (int i = k; i < nums.Length; i++)
        {
            curr += nums[i] - nums[i - k];
            result = Math.Max(result, curr);
        }

        return result / 4;
    }

    public static int LongestOnes(int[] nums, int k)
    {
        int result = 0;
        int currentNumberOfK = 0;
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
            {
                currentNumberOfK++;
            }

            while (currentNumberOfK > k)
            {
                if (nums[left] == 0)
                {
                    currentNumberOfK--;
                }
                left++;
            }
            result = Math.Max(result, right - left + 1);
        }

        return result;
    }
}
