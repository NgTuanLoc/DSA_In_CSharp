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

            var sortContext = new SortContext();

            sortContext.PrintList();

            var sortedList = sortContext.Sort();

            SortHelper.PrintList(sortedList, "BUBBLE SORT");

            sortContext.SetSortStrategy(selectionSortStrategy);

            sortedList = sortContext.Sort();

            SortHelper.PrintList(sortedList, "SELECTION SORT");

            sortContext.SetSortStrategy(insertionSortStrategy);

            sortedList = sortContext.Sort();

            SortHelper.PrintList(sortedList, "INSERTION SORT");
        }
    }
}