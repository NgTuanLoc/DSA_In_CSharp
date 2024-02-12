namespace DSA_In_CSharp.DynamicProgramming;
public class DynamicFibonacciSequence
{
    private readonly int[] _memo;
    public DynamicFibonacciSequence(int[] memo)
    {
        _memo = memo;
    }
    public int FibonacciMemorization(int n)
    {
        if (_memo[n] != -1) return _memo[n];
        if (n < 2) return n;
        _memo[n] = FibonacciMemorization(n - 1) + FibonacciMemorization(n - 2);
        return _memo[n];
    }
    public int FibonacciTabulation(int n)
    {
        var result = new int[n + 1];
        result[0] = 0;
        result[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            result[i] = result[i - 1] + result[i - 2];
        }

        return result[n];
    }
}