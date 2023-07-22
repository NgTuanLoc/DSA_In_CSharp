// using DSA.Algorithm.SortAlgorithm;
using System.Diagnostics;
using DSA.Algorithm.Helpers;
using DSA_In_CSharp.Algorithm;
using DSA_In_CSharp.Algorithm.SearchAlgorithm;
using LinkedList = DSA_In_CSharp.DataStructure.LinkedList;
Console.Clear();

// SortDemo.Run();

// Search Algorithm
var searchList = new List<int>()
{
    19, 2, 12, -2, 123,-123, 9
};
var sortedList = new List<int>()
{
    -2, 1, 3, 12, 23, 30
};
// Console.WriteLine(LinearSearch.Sort(searchList, 0));
Console.WriteLine(BinarySearch.Sort(sortedList, 13));

// ================== Linked List ==================
// Push

// var linkedList = new LinkedList();
// linkedList.Push(1);
// linkedList.Push(2);
// linkedList.Push(3);
// linkedList.Push(4);
// linkedList.Push(5);
// linkedList.Push(6);

// // Pop
// linkedList.Pop();
// linkedList.Pop();

// // Insert
// linkedList.Insert(3, 100);
// linkedList.Insert(0, -100);
// linkedList.Print();

// // Remove
// linkedList.Remove(6);

// linkedList.Print();

// ================== Tree ==================
// var tree = new BinarySearchTree();

// //     10
// //   5      13
// //  2 7   11  16

// tree.Insert(10);
// tree.Insert(5);
// tree.Insert(13);
// tree.Insert(2);
// tree.Insert(7);
// tree.Insert(11);
// tree.Insert(16);
// Console.WriteLine(tree.Find(17));

// SortHelper.PrintList(tree.BFS());
// SortHelper.PrintList(tree.DFSPreOrder(), "DFS (PreOrder)");
// SortHelper.PrintList(tree.DFSPostOrder(), "DFS (PostOrder)");
// SortHelper.PrintList(tree.DFSInOrder(), "DFS (InOrder)");
