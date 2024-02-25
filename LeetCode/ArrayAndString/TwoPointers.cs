using System.Text;

namespace DSA.LeetCode.ArrayAndString;

public static class TwoPointers
{
    public static bool CheckPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] != s[right]) return false;
            left++;
            right--;
        }

        return true;
    }

    public static bool CheckForTarget(List<int> list, int target)
    {
        int left = 0;
        int right = list.Count - 1;
        while (left != right)
        {
            int sum = list[left] + list[right];
            if (sum == target) return true;

            if (sum > target) right--;
            if (sum < target) left++;
        }

        return false;
    }

    public static List<int> CombineTwoSortedList(List<int> list1, List<int> list2)
    {
        List<int> result = [];
        int i = 0;
        int j = 0;

        while (i < list1.Count && j < list2.Count)
        {
            if (list1[i] < list2[j])
            {
                result.Add(list1[i]);
                i++;
                continue;
            }
            result.Add(list2[j]);
            j++;
        }

        while (i < list1.Count)
        {
            result.Add(list1[i]);
            i++;
        }

        while (j < list2.Count)
        {
            result.Add(list2[j]);
            j++;
        }

        return result;
    }

    public static bool IsSubSequence(string s, string t)
    {
        int j = 0;

        for (int i = 0; i < t.Length; i++)
        {
            if (s[j] != t[i]) continue;
            if (j == s.Length - 1) return true;
            j++;
        }

        return false;
    }

    public static void ReverseString(char[] s)
    {
        int i = 0;
        int j = s.Length - 1;

        while (i < j)
        {
            (s[i], s[j]) = (s[j], s[i]);
            i++;
            j--;
        }
    }

    public static int[] SortedSquares(int[] nums)
    {
        int[] result = new int[nums.Length];
        int i = 0;
        int j = nums.Length - 1;

        for (int count = nums.Length - 1; count >= 0; count--)
        {
            int left = nums[i] * nums[i];
            int right = nums[j] * nums[j];

            if (left < right)
            {
                result[count] = right;
                j--;
                continue;
            }
            result[count] = left;
            i++;
        }

        return result;
    }

    // !Exercises
    public static string ReverseWords(string s)
    {
        // https://leetcode.com/problems/reverse-words-in-a-string-iii/
        List<string> temp = [.. s.Split(" ")];
        StringBuilder stringBuilder = new();

        for (int i = 0; i < temp.Count; i++)
        {
            string item = temp[i];
            for (int j = item.Length - 1; j >= 0; j--)
            {
                stringBuilder.Append(item[j]);
            }
            if (i == temp.Count - 1) break;
            stringBuilder.Append(' ');
        }

        return stringBuilder.ToString();
    }
}
