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
        // HeapSolution.LastStoneWeight([2, 7, 4, 1, 8, 1]);
        // HeapSolution.LastStoneWeight([7, 5, 6, 9, 10, 5]);

        // !Minimum Operations to Halve Array Sum
        // Console.WriteLine(HeapSolution.HalveArray([5, 19, 8, 1]));
        Console.WriteLine(HeapSolution.HalveArray([3, 8, 20]));
    }
}
