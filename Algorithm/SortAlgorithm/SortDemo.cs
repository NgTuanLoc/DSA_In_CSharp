using DSA.Algorithm.Helpers;
using DSA.Algorithm.SortAlgorithm.SortStrategy;

namespace DSA.Algorithm.SortAlgorithm
{
    public static class SortDemo
    {
        public static void Run()
        {
            Console.Clear();

            var selectionSortStrategy = new SelectionSortStrategy();
            var insertionSortStrategy = new InsertionSortStrategy();
            var radixSortStrategy = new RadixSortStrategy();

            var sortContext = new SortContext();

            sortContext.PrintList();


            SortHelper.PrintList(sortContext.Sort(), "BUBBLE SORT");

            sortContext.SetSortStrategy(selectionSortStrategy);


            SortHelper.PrintList(sortContext.Sort(), "SELECTION SORT");

            sortContext.SetSortStrategy(insertionSortStrategy);

            SortHelper.PrintList(sortContext.Sort(), "INSERTION SORT");
            // SortHelper.PrintList(sortedList, "QUICK SORT");
            // SortHelper.PrintList(sortedList, "MERGE SORT");
            sortContext.SetSortStrategy(radixSortStrategy);
            SortHelper.PrintList(sortContext.Sort(), "RADIX SORT");
        }
    }
}