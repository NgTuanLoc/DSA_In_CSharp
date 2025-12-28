
namespace DSA.LeetCode.Heap;

public static class TopK
{
    // https://leetcode.com/problems/top-k-frequent-elements/description/
    public static int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> dict = [];
        PriorityQueue<int, int> heap = new();
        var result = new int[k];

        foreach (var num in nums)
        {
            if (dict.ContainsKey(num))
            {
                dict[num] += 1;
                continue;
            }
            dict[num] = 1;
        }

        foreach (var kvp in dict)
        {
            heap.Enqueue(kvp.Key, -kvp.Value);
        }

        while (k != 0)
        {
            k--;
            result[k] = heap.Dequeue();
        }

        return result;
    }

    // https://leetcode.com/problems/find-k-closest-elements/description/
    public static IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        double eps = 0.1;
        List<int> result = [];
        PriorityQueue<int, double> heap = new(); // element - diff

        foreach (var item in arr)
        {
            var priority = (double)Math.Abs(item - x);
            priority = item > x ? priority + eps : priority;
            heap.Enqueue(item, priority);
        }

        while (k != 0)
        {
            k--;
            result.Add(heap.Dequeue());
        }

        result.Sort();

        return result;
    }

    // https://leetcode.com/problems/kth-largest-element-in-an-array/description/
    public static int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> heap = new();
        var result = 0;
        foreach (var num in nums)
        {
            heap.Enqueue(num, -num);
        }

        while (k != 0)
        {
            result = heap.Dequeue();
            k--;
        }

        return result;
    }

    // https://leetcode.com/problems/k-closest-points-to-origin/description/
    public static int[][] KClosest(int[][] points, int k)
    {
        PriorityQueue<int[], double> heap = new();
        var result = new int[k][];

        foreach (var point in points)
        {
            heap.Enqueue(point, GetEuclideanDistance(point, [0, 0]));
        }

        while (k != 0)
        {
            k--;
            var point = heap.Dequeue();
            result[k] = point;
        }

        return result;
    }

    private static double GetEuclideanDistance(int[] point1, int[] point2)
    {
        return Math.Sqrt(Math.Pow(point1[0] - point2[0], 2) + Math.Pow(point1[1] - point2[1], 2));
    }
}

// https://leetcode.com/problems/kth-largest-element-in-a-stream/description/
public class KthLargest
{
    private readonly int _k;
    private readonly PriorityQueue<int, int> _minHeap;

    public KthLargest(int k, int[] nums)
    {
        _k = k;
        _minHeap = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            Add(num);
        }
    }

    public int Add(int val)
    {
        _minHeap.Enqueue(val, val);

        if (_minHeap.Count > _k)
        {
            _minHeap.Dequeue();
        }

        return _minHeap.Peek();
    }
}