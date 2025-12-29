namespace DSA.LeetCode.DynamicProgramming;

// https://leetcode.com/problems/min-cost-climbing-stairs/description/
public class MinCostClimbingStairsSolution
{
    private readonly Dictionary<int, int> memo = [];
    public static int MinCostClimbingStairs(int[] cost)
    {
        return MinCostClimbingStairsDPBottomUp(cost.Length, cost);
    }

    // !Top-Down start with n
    public int MinCostClimbingStairsDPTopDown(int n, int[] cost)
    {
        if (n <= 1) return 0;
        if (memo.TryGetValue(n, out int value)) return value;

        memo.Add(n, Math.Min(MinCostClimbingStairsDPTopDown(n - 1, cost) + cost[n - 1], MinCostClimbingStairsDPTopDown(n - 2, cost) + cost[n - 2]));
        return memo[n];
    }

    // !Bottom-Up start with base case
    public static int MinCostClimbingStairsDPBottomUp(int n, int[] cost)
    {
        // *Step1: initial dp and base case
        var dp = new int[n + 1];

        // *Step2: ReCurr Function
        for (int i = 2; i <= n; i++) dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
        return dp[n];
    }
}
