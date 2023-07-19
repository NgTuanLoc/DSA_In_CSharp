using DSA.Algorithm.SortAlgorithm;

SortDemo.Run();

var test = new List<int>()
{
    1, 2 ,3, 4, 5, 6, 7
};

var test1 = test.GetRange(1, 5);

Console.WriteLine("==============================");

foreach (var item in test1)
{
    Console.WriteLine(item);
}