namespace DSA.LeetCode.ArrayAndString;

//  TIPS
//  =========================== Sliding the window ===========================
//  function fn(nums, k):
//  left = 0
//  curr = 0
//  answer = 0
//  for (int right = 0; right < nums.length; right++):
//    curr += nums[right]
//    while (curr > k):
//        curr -= nums[left]
//        left++
//    answer = max(answer, right - left + 1)
//return answer

//function fn(arr):
//    left = 0
//    for (int right = 0; right<arr.length; right++):
//        Do some logic to "add" element at arr[right] to window

//        while WINDOW_IS_INVALID:
//            Do some logic to "remove" element at arr[left] from the window
//            left++

//        Do some logic to update the answer

//  =========================== Count number of sub-arrays ===========================
//You can fix the right bound and then choose any value between left and right inclusive for the left bound.Therefore, the number of valid windows ending at index right is equal to the size of the window, which we know is right - left + 1

//  =========================== Fixed window size ===========================
//function fn(arr, k):
//    curr = some data to track the window

//    // build the first window
//    for (int i = 0; i<k; i++)
//        Do something with curr or other variables to build the first window

//    ans = answer variable, probably equal to curr here depending on the problem
//    for (int i = k; i<arr.length; i++)
//        Add arr[i] to window
//        Remove arr[i - k] from window
//        Update ans

//    return ans

public static class SlidingWindow
{
    // Example 1: Given an array of positive integers nums and an integer k, find the length of the longest subarray whose sum is less than or equal to k. This is the problem we have been talking about above. We will now formally solve it.
    public static int FindMaxLengthOfTheSubArraySmallerThanK(List<int> nums, int k)
    {
        var left = 0;
        var curr = 0;
        var answer = 0;

        for (var right = 0; right < nums.Count; right++)
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

    public static int FindTheLongestLengthOfSubStringThatContainOnlyOne(string s)
    {
        var answer = 0;
        var left = 0;
        // Number of '0' in the subArray
        var curr = 0;

        for (var right = 0; right < s.Length; right++)
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
        // https://leetcode.com/problems/subarray-product-less-than-k/description/
        if (k <= 1) return 0;

        var answer = 0;
        var left = 0;
        var curr = 1;

        for (var right = 0; right < nums.Count; right++)
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
        var curr = 0;

        for (var i = 0; i < k; i++)
        {
            curr += nums[i];
        }

        var result = curr;

        for (var i = k; i < nums.Count; i++)
        {
            curr += nums[i] - nums[i - k];
            result = Math.Max(curr, result);
        }

        return result;
    }

    public static double FindMaxAverage(int[] nums, int k)
    {
        //https://leetcode.com/problems/maximum-average-subarray-i/description/
        double curr = 0;

        for (int i = 0; i < k; i++)
        {
            curr += nums[i];
        }

        var result = curr;
        for (var i = k; i < nums.Length; i++)
        {
            curr += nums[i] - nums[i - k];
            result = Math.Max(result, curr);
        }

        return result / 4;
    }

    public static int LongestOnes(int[] nums, int k)
    {
        //https://leetcode.com/problems/max-consecutive-ones-iii/description/
        var result = 0;
        var currentNumberOfK = 0;
        var left = 0;

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

    // !Exercises
    public static int MinSubArrayLen(int target, int[] nums)
    {
        // https://leetcode.com/problems/minimum-size-subarray-sum/
        var curr = 0;
        var left = 0;
        var answer = nums.Length + 1;

        for (var right = 0; right < nums.Length; right++)
        {
            curr += nums[right];
            while (curr >= target)
            {
                answer = Math.Min(answer, right - left + 1);
                curr -= nums[left];
                left++;
            }
        }

        return answer == nums.Length + 1 ? 0 : answer;
    }

    public static int MaxVowels(string s, int k)
    {
        // https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length/submissions/1186382760/
        var curr = 0;
        var left = 0;

        for (var i = 0; i < k; i++)
        {
            curr += IsVowel(s[i]);
        }
        var answer = curr;

        for (var right = k; right < s.Length; right++)
        {
            if (curr == k) return k;
            curr -= IsVowel(s[left]);
            curr += IsVowel(s[right]);
            left++;
            answer = Math.Max(answer, curr);
        }

        return answer;
    }

    private static int IsVowel(char ch)
    {
        // Convert the character to lowercase for easier comparison
        ch = char.ToLower(ch);

        // Check if the character is a vowel
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' ? 1 : 0;
    }

    public static int EqualSubstring(string s, string t, int maxCost)
    {
        //    https://leetcode.com/problems/get-equal-substrings-within-budget/
        var answer = 0;
        var curr = 0;
        var left = 0;
        var sum = 0;

        for (var right = 0; right < s.Length; right++)
        {
            sum += CalculateDifferenceBetweenCharacters(s[right], t[right]);
            curr++;

            while (sum > maxCost)
            {
                sum -= CalculateDifferenceBetweenCharacters(s[left], t[left]);
                left++;
                curr--;
            }

            answer = Math.Max(answer, curr);
        }

        return answer;
    }

    private static int CalculateDifferenceBetweenCharacters(char s, char t)
    {
        return Math.Abs(Convert.ToInt32(s) - Convert.ToInt32(t));
    }
}