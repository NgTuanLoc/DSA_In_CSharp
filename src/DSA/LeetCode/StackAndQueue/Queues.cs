
namespace DSA.LeetCode.StackAndQueue;

public static class Queues
{
    // https://leetcode.com/problems/number-of-recent-calls/description/
    public class RecentCounter
    {
        private readonly Queue<int> queue;
        public RecentCounter()
        {
            queue = new Queue<int>();
        }

        public int Ping(int t)
        {
            while (queue.Count != 0 && queue.Peek() < t - 3000)
            {
                this.queue.Dequeue();
            }
            this.queue.Enqueue(t);
            return queue.Count;
        }
    }

    // https://leetcode.com/problems/moving-average-from-data-stream/description/
    public class MovingAverage(int size)
    {
        private readonly int _size = size;
        private readonly Queue<int> queue = new();
        private double _currentSum = 0;

        public double Next(int val)
        {
            if (queue.Count == _size)
            {
                _currentSum -= queue.Peek();
                queue.Dequeue();
            }
            queue.Enqueue(val);
            _currentSum += val;
            return _currentSum / queue.Count;
        }
    }

}
