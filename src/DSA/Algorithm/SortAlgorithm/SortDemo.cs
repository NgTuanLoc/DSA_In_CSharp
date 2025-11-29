using DSA.Algorithm.Helpers;
using DSA.Algorithm.SortAlgorithm.SortStrategy;

namespace DSA.Algorithm.SortAlgorithm;
public static class SortDemo
{
    public static void Run()
    {
        Console.Clear();

        var bubbleSortStrategy = new BubbleSortStrategy();
        var selectionSortStrategy = new SelectionSortStrategy();
        var insertionSortStrategy = new InsertionSortStrategy();
        var radixSortStrategy = new RadixSortStrategy();
        var mergeSortStrategy = new MergeSortStrategy();
        var quickSortStrategy = new QuickSortStrategy();

        var sortContext = new SortContext();

        int choice = 0;

        switch (choice)
        {
            case 1:
                sortContext.SetSortStrategy(bubbleSortStrategy);
                SortHelper.PrintList(sortContext.Sort(), "BUBBLE SORT");
                break;
            case 2:
                sortContext.SetSortStrategy(selectionSortStrategy);
                SortHelper.PrintList(sortContext.Sort(), "SELECTION SORT");
                break;
            case 3:
                sortContext.SetSortStrategy(insertionSortStrategy);
                SortHelper.PrintList(sortContext.Sort(), "INSERTION SORT");
                break;
            case 4:
                sortContext.SetSortStrategy(radixSortStrategy);
                SortHelper.PrintList(sortContext.Sort(), "RADIX SORT");
                break;
            case 5:
                sortContext.SetSortStrategy(mergeSortStrategy);
                SortHelper.PrintList(sortContext.Sort(), "MERGE SORT");
                break;
            case 6:
                sortContext.SetSortStrategy(quickSortStrategy);
                SortHelper.PrintList(sortContext.Sort(), "QUICK SORT");
                break;
            default:
                sortContext.SetSortStrategy(bubbleSortStrategy);
                sortContext.Sort();

                sortContext.SetSortStrategy(selectionSortStrategy);
                sortContext.Sort();

                sortContext.SetSortStrategy(insertionSortStrategy);
                sortContext.Sort();

                sortContext.SetSortStrategy(radixSortStrategy);
                sortContext.Sort();

                sortContext.SetSortStrategy(mergeSortStrategy);
                sortContext.Sort();

                sortContext.SetSortStrategy(quickSortStrategy);
                sortContext.Sort();
                break;
        }
    }
}