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

    public static int HalveArray(int[] nums)
    {
        // https://leetcode.com/problems/minimum-operations-to-halve-array-sum/description/
        int result = 0;
        double target = 0;
        var maxHeap = new Heap<double>(HeapType.MaxHeap);
        foreach (var item in nums)
        {
            target += item;
            maxHeap.Insert(item);
        }
        target /= 2;

        while (target > 0)
        {
            result++;
            double temp = maxHeap.Remove() / 2;
            maxHeap.Insert(temp);
            target -= temp;
        }
        return result;
    }
}
