namespace DSA;

public static class HeapSolution
{
    // https://leetcode.com/problems/last-stone-weight/
    public static int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> heap = new(); // element - priority order (min heap)

        foreach (var stone in stones)
        {
            heap.Enqueue(stone, -stone);
        }

        while (heap.Count > 1)
        {
            var stone1 = heap.Dequeue();
            var stone2 = heap.Dequeue();
            heap.Enqueue(Math.Abs(stone1 - stone2), -Math.Abs(stone1 - stone2));
        }

        return heap.Count != 0 ? heap.Dequeue() : 0;
    }

    public static int HalveArray(int[] nums)
    {
        // https://leetcode.com/problems/minimum-operations-to-halve-array-sum/description/
        var result = 0;
        var heap = new PriorityQueue<double, double>();
        double target = 0;

        foreach (var num in nums)
        {
            target += num;
            heap.Enqueue(num, -num);
        }

        target /= 2;

        while (target > 0)
        {
            var max = heap.Dequeue();
            var halfMax = max / 2;
            target -= halfMax;
            heap.Enqueue(halfMax, -halfMax);
            result++;
        }

        return result;
    }

    // https://leetcode.com/problems/remove-stones-to-minimize-the-total/
    public static int MinStoneSum(int[] piles, int k)
    {
        var result = 0;
        var heap = new PriorityQueue<int, int>();

        foreach (var pile in piles)
        {
            heap.Enqueue(pile, -pile);
            result += pile;
        }

        while (k != 0 && heap.Count != 0)
        {
            var max = heap.Dequeue();
            var halfMax = (int)Math.Ceiling((double)max / 2);
            result = result - max + halfMax;
            heap.Enqueue(halfMax, -halfMax);
            k--;
        }

        return result;
    }

    // https://leetcode.com/problems/minimum-cost-to-connect-sticks/
    public static int ConnectSticks(int[] sticks)
    {
        var result = 0;
        var heap = new PriorityQueue<int, int>();

        foreach (var stick in sticks)
        {
            heap.Enqueue(stick, stick);
        }

        while (heap.Count > 1)
        {
            var combinedStick = heap.Dequeue() + heap.Dequeue();
            heap.Enqueue(combinedStick, combinedStick);
            result += combinedStick;
        }

        return result;
    }
}
