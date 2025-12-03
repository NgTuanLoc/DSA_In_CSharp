
namespace DSA.LeetCode.StackAndQueue;

public static class Queues
{
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
