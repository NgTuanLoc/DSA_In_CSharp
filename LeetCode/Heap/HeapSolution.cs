namespace DSA;

public class HeapSolution
{
    // https://leetcode.com/problems/last-stone-weight/
    public static int LastStoneWeight(int[] stones)
    {
        Heap<int> heap = new(HeapType.MaxHeap);
        foreach (var item in stones)
        {
            heap.Insert(item);
        }

        while (heap.Count() > 1)
        {
            int stone1 = heap.Remove();
            int stone2 = heap.Remove();
            heap.Insert(Math.Abs(stone2 - stone1));
        }

        return heap.Count() != 0 ? heap.Remove() : 0;
    }

    // https://leetcode.com/problems/minimum-operations-to-halve-array-sum/description/
    public static int HalveArray(int[] nums)
    {
        int result = 0;
        return result;
    }
}
