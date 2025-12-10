namespace DSA.LeetCode.StackAndQueue;

public static class Monotonic
{
    // https://leetcode.com/problems/daily-temperatures/description/
    public static int[] DailyTemperatures(int[] temperatures)
    {
        var n = temperatures.Length;
        var result = new int[n];
        Array.Clear(result, 0, n);
        var stack = new Stack<int>();

        for (var i = 0; i < n; i++)
        {
            while (stack.Count != 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                var j = stack.Pop();
                result[j] = i - j;
            }
            stack.Push(i);
        }

        return result;
    }

    // https://leetcode.com/problems/sliding-window-maximum/description/
    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        var n = nums.Length;
        var queue = new List<int>();
        var result = new List<int>();

        for (int i = 0; i < n; i++)
        {
            // maintain monotonic decreasing.
            // all elements in the deque smaller than the current one
            // have no chance of being the maximum, so get rid of them
            while (queue.Count != 0 && nums[queue[^1]] < nums[i])
            {
                queue.RemoveAt(queue.Count - 1);
            }

            queue.Add(i);

            // queue[0] is the index of the maximum element.
            // if queue[0] + k == i, then it is outside the window
            if (queue[0] + k == i)
            {
                queue.RemoveAt(0);
            }

            // only add to the answer once our window has reached size k
            if (i >= k - 1)
            {
                result.Add(nums[queue[0]]);
            }
        }

        return [.. result];
    }

    // https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/description/
    public static int LongestSubarray(int[] nums, int limit)
    {
        return 1;
    }
}