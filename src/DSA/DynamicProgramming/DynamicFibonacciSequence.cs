namespace DSA_In_CSharp.DynamicProgramming;
public class DynamicFibonacciSequence(int[] memo)
{
    public int FibonacciMemorization(int n)
    {
        if (memo[n] != -1) return memo[n];
        if (n < 2) return n;
        memo[n] = FibonacciMemorization(n - 1) + FibonacciMemorization(n - 2);
        return memo[n];
    }
    public static int FibonacciTabulation(int n)
    {
        var result = new int[n + 1];
        result[0] = 0;
        result[1] = 1;

        for (var i = 2; i <= n; i++)
        {
            result[i] = result[i - 1] + result[i - 2];
        }

        return result[n];
    }
}