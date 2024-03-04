namespace DSA.LeetCode.TreesAndGraphs;

public class HeapExample
{
    public static void Run()
    {
        Heap<int> heap = new(HeapType.MinHeap);
        heap.Insert(3);
        heap.Insert(5);
        heap.Insert(8);
        heap.Insert(15);
        heap.Insert(17);
        heap.Insert(4);

        foreach (var item in heap.Data)
        {
            Console.WriteLine(item);
        }
        heap.Remove();

        Console.WriteLine("======");
        foreach (var item in heap.Data)
        {
            Console.WriteLine(item);
        }
    }
}
