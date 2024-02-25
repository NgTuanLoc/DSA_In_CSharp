namespace DSA;

public static class Utils
{
    public static void Print(List<int> list)
    {
        foreach (int item in list)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine("\n====================");
    }
}
