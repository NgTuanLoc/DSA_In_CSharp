namespace DSA.LeetCode.DynamicProgramming;

// https://leetcode.com/problems/house-robber/description/
public class OneDirectionSolution
{
    private readonly Dictionary<int, int> memo = [];
    public static int Rob(int[] nums)
    {
        return RobDPBottomUp(nums);
    }

    public int RobDPTopDown(int n, int[] nums)
    {
        if (n == 0) return nums[0];
        if (n == 1) return Math.Max(nums[0], nums[1]);
        if (memo.TryGetValue(n, out int value)) return value;
        memo.Add(n, Math.Max(RobDPTopDown(n - 2, nums) + nums[n], RobDPTopDown(n - 1, nums)));
        return memo[n];
    }

    public static int RobDPBottomUp(int[] nums)
    {
        var n = nums.Length;
        Dictionary<int, int> dp = [];
        dp.Add(0, nums[0]);
        dp.Add(1, Math.Max(nums[0], nums[1]));

        for (int i = 2; i < n; i++)
        {
            var max = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
            dp.Add(i, max);
        }

        return dp[n - 1];
    }
}

// https://leetcode.com/problems/longest-increasing-subsequence/description/
public class LongestIncreasingSubsequenceSolution
{
    private readonly Dictionary<int, int> memo = [];
    public int LengthOfLIS(int[] nums)
    {
        var answer = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            answer = Math.Max(answer, LengthOfLISTopDown(i, nums));
        }
        return LengthOfLISBottomUp(nums);
    }

    public int LengthOfLISTopDown(int n, int[] nums)
    {
        if (memo.TryGetValue(n, out int value)) return value;

        var answer = 1;
        for (int i = 0; i < n; i++)
        {
            if (nums[n] > nums[i]) answer = Math.Max(answer, LengthOfLISTopDown(i, nums) + 1);
        }
        memo.Add(n, answer);
        return memo[n];
    }

    public static int LengthOfLISBottomUp(int[] nums)
    {
        Dictionary<int, int> dp = [];

        for (int i = 0; i < nums.Length; i++)
        {
            var answer = 1;
            foreach (var kvp in dp)
            {
                if (nums[kvp.Key] < nums[i]) answer = Math.Max(answer, kvp.Value + 1);
            }
            dp.Add(i, answer);
        }

        return dp.Values.Max();
    }
}

// https://leetcode.com/problems/solving-questions-with-brainpower/
public class SolvingQuestionsWithBrainpowerSolution
{
    private readonly Dictionary<int, long> memo = [];
    public static long MostPoints(int[][] questions)
    {
        return MostPointsBottomUp(questions);
    }

    private long MostPointsTopDown(int n, int[][] questions)
    {
        if (n >= questions.Length) return 0;
        if (memo.TryGetValue(n, out long value)) return value;

        var nextQuestionIndex = n + 1 + questions[n][1];
        var skip = MostPointsTopDown(n + 1, questions);
        var take = questions[n][0] + MostPointsTopDown(nextQuestionIndex, questions);

        memo.Add(n, Math.Max(skip, take));
        return memo[n];
    }

    private static long MostPointsBottomUp(int[][] questions)
    {
        var n = questions.Length;
        var dp = new long[n + 1];

        for (int i = n - 1; i >= 0; i--)
        {
            var nextQuestionIndex = i + 1 + questions[i][1];
            var take = questions[i][0] + dp[Math.Min(nextQuestionIndex, n)];
            var skip = dp[i + 1];
            dp[i] = Math.Max(take, skip);
        }

        return dp.Max();
    }
}

public class ClimbStairsSolution
{
    private readonly Dictionary<int, int> memo = [];
    public static int ClimbStairs(int n)
    {
        return ClaimStairsBottomUp(n);
    }

    public int ClimbStairsTopDown(int n)
    {
        if (n <= 2) return n;
        if (memo.TryGetValue(n, out int value)) return value;

        memo.Add(n, ClimbStairsTopDown(n - 1) + ClimbStairsTopDown(n - 2));

        return memo[n];
    }

    private static int ClaimStairsBottomUp(int n)
    {
        Dictionary<int, int> dp = [];
        dp.Add(1, 1);
        dp.Add(2, 2);

        for (int i = 3; i <= n; i++)
        {
            dp.Add(i, dp[i - 2] + dp[i - 1]);
        }

        return dp[n];
    }
}

public class CoinChangeSolution
{
    private readonly Dictionary<int, int> memo = [];
    public static int CoinChange(int[] coins, int amount)
    {
        return CoinChangeBottomUp(coins, amount);
    }

    private int CoinChangeTopDown(int[] coins, int amount)
    {
        if (amount < 0) return -1;
        if (amount == 0) return 0;
        if (memo.TryGetValue(amount, out int value)) return value;

        var minCount = int.MaxValue;
        foreach (var coin in coins)
        {
            var res = CoinChangeTopDown(coins, amount - coin);
            if (res != -1) minCount = Math.Min(minCount, res + 1);
        }

        memo.Add(amount, minCount == int.MaxValue ? -1 : minCount);
        return memo[amount];
    }

    private static int CoinChangeBottomUp(int[] coins, int amount)
    {
        Dictionary<int, int> dp = [];

        for (int i = 0; i <= amount; i++)
        {
            dp.Add(i, amount + 1); // Replace infinite number
        }
        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            foreach (var coin in coins)
            {
                var rem = i - coin;
                if (rem >= 0) dp[i] = Math.Min(dp[i], 1 + dp[rem]);

            }
        }

        return dp[amount] > amount ? -1 : dp[amount];
    }
}