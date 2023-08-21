namespace DSA_In_CSharp.DynamicProgramming
{
    public class DynamicFibonacciSequence
    {
        private int[] _memo;
        public DynamicFibonacciSequence(int[] memo)
        {
            _memo = memo;
        }
        public int Fibonacci(int n)
        {
            if (_memo[n] != -1) return _memo[n];
            if (n < 2) return n;
            _memo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            return _memo[n];
        }
    }
}