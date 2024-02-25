namespace DSA.LeetCode.ArrayAndString;

public static class ArrayAndStringExample
{
    public static void Run()
    {
        // !=========Two Pointers=========
        // Console.WriteLine(TwoPointers.CheckPalindrome("racecar"));

        // // CheckForTarget
        // Console.WriteLine(TwoPointers.CheckForTarget([1, 2, 4, 6, 8, 9, 14, 15], 13));

        // // CombineTwoSortedList
        // Utils.Print(TwoPointers.CombineTwoSortedList([1, 4, 7, 20], [3, 5, 6]));

        // // IsSubSequence
        // Console.WriteLine(TwoPointers.IsSubSequence("ace", "abcde"));

        // // Reverse String
        // char[] reverseString = "abcde".ToCharArray();
        // TwoPointers.ReverseString(reverseString);
        // Console.WriteLine(reverseString);

        // // SortedSquares
        // var sortedSquares = TwoPointers.SortedSquares([-7, -3, 2, 3, 11]);
        // Console.WriteLine("===========");
        // foreach (var item in sortedSquares)
        // {
        //     Console.WriteLine(item);
        // }

        // !=========Sliding Window=========
        // // Find Max Length Of The SubArray Smaller Or Equal Than K
        // Console.WriteLine(SlidingWindow.FindMaxLengthOfTheSubArraySmallerThanK([3, 1, 2, 7, 4, 2, 1, 1, 5], 8));

        // // Find The Length Of The Longest SubString Achievable That Contains Only 1
        // Console.WriteLine(SlidingWindow.FindTheLongestLengthOfSubStringThatContainOnlyOne("1101100111"));

        // // Number Of SubArray Product Less Than K
        // Console.WriteLine(SlidingWindow.NumSubArrayProductLessThanK([10, 5, 2, 6], 1000000));

        // // Given an integer array nums and an integer k, find the sum of the SubArray with the largest sum whose length is k.
        // Console.WriteLine(SlidingWindow.FindBestSubArray([3, -1, 4, 12, -8, 5, 6], 4));

        // // Find Max Average SubArray With Length = k
        // Console.WriteLine(SlidingWindow.FindMaxAverage([1, 12, -5, -6, 50, 3], 4));

        // // LongestOnes
        // Console.WriteLine(SlidingWindow.LongestOnes([1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], 2));
        // Console.WriteLine(SlidingWindow.LongestOnes([0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1], 3));

        // !Prefix Sum
        // List<List<int>> queries = [[0, 3], [2, 5], [2, 4]];
        // var answers = PrefixSum.AnswerQueries([1, 6, 3, 2, 7, 2], queries, 13);
        // foreach (var item in answers)
        // {
        //     Console.WriteLine(item);
        // }

        // // WaysToSplitArray
        // Console.WriteLine(PrefixSum.WaysToSplitArray([10, 4, -8, 7]));

        // // Running Sum of 1d Array
        // Console.WriteLine("===================");
        // var answers1 = PrefixSum.RunningSum([1, 2, 3, 4]);
        // foreach (var item in answers1)
        // {
        //     Console.WriteLine(item);
        // }

        // // MinStartValue
        // Console.WriteLine("===================");
        // Console.WriteLine(PrefixSum.MinStartValue([-3, 2, -3, 4, 2]));
        // Console.WriteLine(PrefixSum.MinStartValue([1, 2]));
        // Console.WriteLine(PrefixSum.MinStartValue([1, -2, -3]));

        // // K Radius SubArray Averages
        // Console.WriteLine("===================");
        // var answers2 = PrefixSum.GetAverages([7, 4, 3, 9, 1, 8, 5, 2, 6], 3);
        // // var answers3 = PrefixSum.GetAverages([100], 0);
        // // var answers4 = PrefixSum.GetAverages([8], 10000);
        // foreach (var item in answers2)
        // {
        //     // Console.WriteLine(item);
        // }

        // !Exercises
        // *Two Pointers
        Console.WriteLine(TwoPointers.ReverseWords("Let's take LeetCode contest"));
    }
}
