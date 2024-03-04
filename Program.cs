// using DSA.Algorithm.SortAlgorithm;
using System.Diagnostics;
using DSA.Algorithm.Helpers;
using DSA.DataStructure;
using DSA.LeetCode.ArrayAndString;
using DSA.LeetCode.Backtracking;
using DSA.LeetCode.Hashing;
using DSA.LeetCode.TreesAndGraphs;
using DSA_In_CSharp.Algorithm;
using DSA_In_CSharp.Algorithm.SearchAlgorithm;
using DSA_In_CSharp.DynamicProgramming;
using LinkedList = DSA_In_CSharp.DataStructure.LinkedList;
Console.Clear();

// SortDemo.Run();

// Search Algorithm
// var searchList = new List<int>()
// {
//     19, 2, 12, -2, 123,-123, 9
// };
// var sortedList = new List<int>()
// {
//     -2, 1, 3, 12, 23, 30
// };
// // Console.WriteLine(LinearSearch.Sort(searchList, 0));
// // Console.WriteLine(BinarySearch.Sort(sortedList, 13));

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

// ================== HashTable ==================
// var hashTable = new HashTable();
// // Console.WriteLine(HashTable.Hash("Pink", 100));
// // Console.WriteLine(HashTable.Hash("apple", 100));
// // Console.WriteLine(HashTable.Hash("paple", 100));

// hashTable.Set("a", "gdfgfd1");
// hashTable.Set("a", "gdfgffddgd1");

// var result = hashTable.Get("a");

// foreach (var item in result)
// {
//     if (item != "")
//     {
//         Console.WriteLine(item);
//     }
// }

// ================== Heap ==================
// 41, 39, 33, 18, 27, 12
// Insert: 55
// var heap = new Heap();
// heap.Insert(41);
// heap.Insert(39);
// heap.Insert(33);
// heap.Insert(18);
// heap.Insert(27);
// heap.Insert(12);
// heap.Insert(55);
// heap.Insert(100);
// heap.Insert(19);
// heap.Insert(36);
// heap.Insert(17);
// heap.Insert(3);
// heap.Insert(25);
// heap.Insert(1);
// heap.Insert(2);
// heap.Insert(7);

// foreach (var item in heap._data)
// {
//     Console.WriteLine(item);
// }

// ================== Dynamic Programming ==================
// int n = 10;
// var memo = new int[n + 1];

// for (int i = 0; i < n + 1; i++)
// {
//     memo[i] = -1;
// }

// var fibonacci = new DynamicFibonacciSequence(memo);

// Console.WriteLine(fibonacci.FibonacciMemorization(n));
// Console.WriteLine(fibonacci.FibonacciTabulation(n));


// !LEET CODE
// ArrayAndStringExample.Run();
// HashingExample.Run();
// TreesAndGraphsExample.Run_DFS();
// TreesAndGraphsExample.Run_BFS();
// TreesAndGraphsExample.Run_BinarySearchTree();
BacktrackingExample.Run();