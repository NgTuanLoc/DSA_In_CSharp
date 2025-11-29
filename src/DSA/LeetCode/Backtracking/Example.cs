namespace DSA.LeetCode.Backtracking;
public class BacktrackingExample
{
    public static void Run()
    {
        // !Permutation
        // var result = Permutation_Solution.Permute([1, 2, 3]);
        // foreach (var list in result)
        // {
        //     foreach (var item in list)
        //     {
        //         Console.Write($"{item} ");
        //     }
        //     Console.WriteLine();
        // }

        // !Subsets
        // var result = Subsets_Solution.Subsets([1, 2, 3]);
        // foreach (var list in result)
        // {
        //     Console.Write("[");
        //     foreach (var item in list)
        //     {
        //         Console.Write($" {item} ");
        //     }
        //     Console.Write("]");
        //     Console.WriteLine();
        // }

        // !Combinations
        var result = Combination_Solution.Combine(4, 2);
        foreach (var list in result)
        {
            Console.Write("[");
            foreach (var item in list)
            {
                Console.Write($" {item} ");
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}
