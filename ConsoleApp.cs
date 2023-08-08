public static class ConsoleApp
{
    public static void Test()
    {
        string[] names = { "Tom", "Harry", "Han" };
        var filterNames = names.Where(name => name.Length >= 4);
        foreach (var item in filterNames)
        {
            Console.WriteLine(item);
        }
    }
}