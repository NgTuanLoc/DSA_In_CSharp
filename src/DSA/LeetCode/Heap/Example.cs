using DSA.LeetCode.Heap;

namespace DSA.LeetCode.TreesAndGraphs;

public class HeapExample
{
    public static void Run()
    {
        // !Example of using Min Heap
        // Heap<int> heap = new(HeapType.MinHeap);
        // heap.Insert(3);
        // heap.Insert(5);
        // heap.Insert(8);
        // heap.Insert(15);
        // heap.Insert(17);
        // heap.Insert(4);

        // foreach (var item in heap.Data)
        // {
        //     Console.WriteLine(item);
        // }
        // heap.Remove();

        // Console.WriteLine("======");
        // foreach (var item in heap.Data)
        // {
        //     Console.WriteLine(item);
        // }

        // !Last Stone Weight
        // Console.WriteLine(HeapSolution.LastStoneWeight([2, 7, 4, 1, 8, 1]));
        // Console.WriteLine(HeapSolution.LastStoneWeight([1]));

        // !Minimum Operations to Halve Array Sum
        // Console.WriteLine(HeapSolution.HalveArray([5, 19, 8, 1]));
        // Console.WriteLine(HeapSolution.HalveArray([3, 8, 20]));

        // !Remove Stones to Minimize the Total
        // Console.WriteLine(HeapSolution.MinStoneSum([5, 4, 9], 2));
        // Console.WriteLine(HeapSolution.MinStoneSum([4, 3, 6, 7], 3));
        // Console.WriteLine(HeapSolution.MinStoneSum([10000], 10000));

        // !Minimum Cost to Connect Sticks
        // Console.WriteLine(HeapSolution.ConnectSticks([2, 4, 3]));
        // Console.WriteLine(HeapSolution.ConnectSticks([1, 8, 3, 5]));
        // Console.WriteLine(HeapSolution.ConnectSticks([5]));

        // *TOP K
        // !Top K Frequent Elements
        // Console.WriteLine(string.Join(",", [.. TopK.TopKFrequent([1, 1, 1, 2, 2, 3], 2)]));
        // Console.WriteLine(string.Join(",", [.. TopK.TopKFrequent([1], 1)]));
        // Console.WriteLine(string.Join(",", [.. TopK.TopKFrequent([1, 2, 1, 2, 1, 2, 3, 1, 3, 2], 2)]));

        // !Find K Closest Elements
        // Console.WriteLine(string.Join(",", TopK.FindClosestElements([1, 2, 3, 4, 5], 4, 3)));
        // Console.WriteLine(string.Join(",", TopK.FindClosestElements([1, 1, 2, 3, 4, 5], 4, -1)));

        // !Kth Largest Element in an Array
        // Console.WriteLine(TopK.FindKthLargest([3, 2, 1, 5, 6, 4], 2));
        // Console.WriteLine(TopK.FindKthLargest([3, 2, 3, 1, 2, 4, 5, 5, 6], 4));

        // !K Closest Points to Origin
        // Console.WriteLine(string.Join(", ", TopK.KClosest([[1, 3], [-2, 2]], 1).Select(p => $"[{p[0]},{p[1]}]")));
        // Console.WriteLine(string.Join(", ", TopK.KClosest([[3, 3], [5, -1], [-2, 4]], 2).Select(p => $"[{p[0]},{p[1]}]")));

        // !Kth Largest Element in a Stream
        var scores = new KthLargest(3, [4, 5, 8, 2]);
        Console.WriteLine(scores.Add(3));
        Console.WriteLine(scores.Add(5));
        Console.WriteLine(scores.Add(10));
        Console.WriteLine(scores.Add(9));
        Console.WriteLine(scores.Add(4));

        Console.WriteLine("================");
        var scores1 = new KthLargest(4, [7, 7, 7, 7, 8, 3]);
        Console.WriteLine(scores1.Add(2));
        Console.WriteLine(scores1.Add(10));
        Console.WriteLine(scores1.Add(9));
        Console.WriteLine(scores1.Add(9));
    }
}
