using System.Text;

namespace DSA.LeetCode.ArrayAndString;

public static class TwoPointers
{
    public static bool CheckPalindrome(string s)
    {
        var left = 0;
        var right = s.Length - 1;

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
        var left = 0;
        var right = list.Count - 1;
        while (left != right)
        {
            var sum = list[left] + list[right];
            if (sum == target) return true;

            if (sum > target) right--;
            if (sum < target) left++;
        }

        return false;
    }

    public static List<int> CombineTwoSortedList(List<int> list1, List<int> list2)
    {
        List<int> result = [];
        var i = 0;
        var j = 0;

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
        // https://leetcode.com/problems/is-subsequence/description/
        var i = 0;
        var j = 0;

        while (i < s.Length && j < t.Length)
        {
            if (s[i] == t[j])
            {
                i++;
                j++;
                continue;
            }
            j++;
        }

        return s.Length == i;
    }

    public static void ReverseString(char[] s)
    {
        // https://leetcode.com/problems/reverse-string/description/
        var i = 0;
        var j = s.Length - 1;

        while (i < j)
        {
            (s[i], s[j]) = (s[j], s[i]);
            i++;
            j--;
        }
    }

    public static int[] SortedSquares(int[] nums)
    {
        // https://leetcode.com/problems/squares-of-a-sorted-array/
        var result = new int[nums.Length];
        var i = 0;
        var j = nums.Length - 1;

        for (var count = nums.Length - 1; count >= 0; count--)
        {
            var left = nums[i] * nums[i];
            var right = nums[j] * nums[j];

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

        for (var i = 0; i < temp.Count; i++)
        {
            var item = temp[i];
            for (var j = item.Length - 1; j >= 0; j--)
            {
                stringBuilder.Append(item[j]);
            }
            if (i == temp.Count - 1) break;
            stringBuilder.Append(' ');
        }

        return stringBuilder.ToString();
    }

    public static string ReverseOnlyLetters(string s)
    {
        // https://leetcode.com/problems/reverse-only-letters/
        var l = s.ToCharArray();
        var left = 0;
        var right = s.Length - 1;
        while (left < right)
        {
            if (!char.IsLetter(s[left]))
            {
                left++;
                continue;
            }
            if (!char.IsLetter(s[right]))
            {
                right--;
                continue;
            }
            (l[left], l[right]) = (l[right], l[left]);
            left++;
            right--;
        }
        return new string(l);
    }

    public static int GetCommon(int[] nums1, int[] nums2)
    {
        // https://leetcode.com/problems/minimum-common-value/
        var i = 0;
        var j = 0;

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] == nums2[j]) return nums1[i];
            if (nums1[i] < nums2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return -1;
    }

    public static void MoveZeroes(int[] nums)
    {
        // https://leetcode.com/problems/move-zeroes/description/
        var left = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0) continue;
            (nums[left], nums[i]) = (nums[i], nums[left]);
            left++;
        }
    }
    public static string ReversePrefix(string word, char ch)
    {
        // https://leetcode.com/problems/reverse-prefix-of-word/description/
        var temp = word.ToCharArray();
        var right = -1;
        var left = 0;
        for (var i = 0; i < word.Length; i++)
        {
            if (word[i] != ch) continue;
            right = i;
            break;
        }

        if (right == -1) return word;

        while (left < right)
        {
            (temp[left], temp[right]) = (temp[right], temp[left]);
            left++;
            right--;
        }

        return new string(temp);
    }
}
