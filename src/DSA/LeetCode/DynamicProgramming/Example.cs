
namespace DSA.LeetCode.DynamicProgramming;

public static class DynamicProgrammingExample
{
    public static void Run()
    {
        // *Framework of DP
        // !Min Cost Climbing Stairs
        // Console.WriteLine(MinCostClimbingStairsSolution.MinCostClimbingStairs([10, 15, 20]));
        // Console.WriteLine(MinCostClimbingStairsSolution.MinCostClimbingStairs([1, 100, 1, 1, 1, 100, 1, 1, 100, 1]));

        // *1D Problems
        // !House Robber
        // Console.WriteLine(OneDirectionSolution.Rob([1, 2, 3, 1]));
        // Console.WriteLine(OneDirectionSolution.Rob([2, 7, 9, 3, 1]));

        // !Longest Increasing Subsequence
        // Console.WriteLine(new LongestIncreasingSubsequenceSolution().LengthOfLIS([10, 9, 2, 5, 3, 7, 101, 18]));
        // Console.WriteLine(new LongestIncreasingSubsequenceSolution().LengthOfLIS([0, 1, 0, 3, 2, 3]));
        // Console.WriteLine(new LongestIncreasingSubsequenceSolution().LengthOfLIS([7, 7, 7, 7, 7, 7, 7]));

        // !Solving Questions With Brainpower
        // Console.WriteLine(SolvingQuestionsWithBrainpowerSolution.MostPoints([[3, 2], [4, 3], [4, 4], [2, 5]]));
        // Console.WriteLine(SolvingQuestionsWithBrainpowerSolution.MostPoints([[1, 1], [2, 2], [3, 3], [4, 4], [5, 5]]));

        // !Climbing Stairs
        // Console.WriteLine(ClimbStairsSolution.ClimbStairs(2));
        // Console.WriteLine(ClimbStairsSolution.ClimbStairs(3));
        // Console.WriteLine(ClimbStairsSolution.ClimbStairs(4));

        // !Coin Change
        Console.WriteLine(CoinChangeSolution.CoinChange([1, 2, 5], 11));
        Console.WriteLine(CoinChangeSolution.CoinChange([2], 3));
        Console.WriteLine(CoinChangeSolution.CoinChange([1], 0));
    }
}
