using static DSA.LeetCode.StackAndQueue.Queues;

namespace DSA.LeetCode.StackAndQueue;

public static class StackAndQueueExample
{
    public static void Run()
    {
        Console.WriteLine("+++++++++++++Stack and Queue+++++++++++++");
        // // !=========Valid Parentheses=========
        // Console.WriteLine(Stacks.IsValid("()"));
        // Console.WriteLine(Stacks.IsValid("()[]{}"));
        // Console.WriteLine(Stacks.IsValid("(]"));
        // Console.WriteLine(Stacks.IsValid("([])"));
        // Console.WriteLine(Stacks.IsValid("([)]"));

        // // !=========Remove All Adjacent Duplicates In String=========
        // Console.WriteLine(Stacks.RemoveDuplicates("abbaca"));
        // Console.WriteLine(Stacks.RemoveDuplicates("azxxzy"));

        // // !=========Remove All Adjacent Duplicates In String=========
        // Console.WriteLine(Stacks.BackspaceCompare("ab#c", "ad#c"));
        // Console.WriteLine(Stacks.BackspaceCompare("ab##", "c#d#"));
        // Console.WriteLine(Stacks.BackspaceCompare("a#c", "b"));
        // Console.WriteLine(Stacks.BackspaceCompare("a##c", "#a#c"));

        // // !=========Simplify Path=========
        // Console.WriteLine(Stacks.SimplifyPath("/home/"));
        // Console.WriteLine(Stacks.SimplifyPath("/home//foo/"));
        // Console.WriteLine(Stacks.SimplifyPath("/home/user/Documents/../Pictures"));
        // Console.WriteLine(Stacks.SimplifyPath("/../"));
        // Console.WriteLine(Stacks.SimplifyPath("/.../a/../b/c/../d/./"));

        // // !=========Make The String Great=========
        // Console.WriteLine(Stacks.MakeGood("leEeetcode"));
        // Console.WriteLine(Stacks.MakeGood("abBAcC"));
        // Console.WriteLine(Stacks.MakeGood("s"));

        // // !=========Number of Recent Calls=========
        // var recentCounter = new RecentCounter();
        // Console.WriteLine(recentCounter.Ping(1));
        // Console.WriteLine(recentCounter.Ping(100));
        // Console.WriteLine(recentCounter.Ping(3001));
        // Console.WriteLine(recentCounter.Ping(3002));

        // // !=========Moving Average from Data Stream=========
        // var movingAverage = new MovingAverage(3);
        // Console.WriteLine(movingAverage.Next(1));
        // Console.WriteLine(movingAverage.Next(10));
        // Console.WriteLine(movingAverage.Next(3));
        // Console.WriteLine(movingAverage.Next(5));

        // // !=========Daily Temperatures=========
        // Utils.Print(Monotonic.DailyTemperatures([73, 74, 75, 71, 69, 72, 76, 73]));
        // Utils.Print(Monotonic.DailyTemperatures([30, 40, 50, 60]));
        // Utils.Print(Monotonic.DailyTemperatures([30, 60, 90]));

        // // !=========Sliding Window Maximum=========
        // Utils.Print(Monotonic.MaxSlidingWindow([1, 3, -1, -3, 5, 3, 6, 7], 3));
        // Utils.Print(Monotonic.MaxSlidingWindow([1], 1));
        // !=========Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit=========
        Console.WriteLine(Monotonic.LongestSubarray([8, 2, 4, 7], 4));
        Console.WriteLine(Monotonic.LongestSubarray([10, 1, 2, 4, 7, 2], 5));
        Console.WriteLine(Monotonic.LongestSubarray([4, 2, 2, 2, 4, 4, 2, 2], 0));
    }
}