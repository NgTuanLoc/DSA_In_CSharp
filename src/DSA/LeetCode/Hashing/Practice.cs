using System.Text;

namespace DSA.LeetCode.Hashing;

public abstract class Practice
{
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        // https://leetcode.com/problems/group-anagrams/
        IList<IList<string>> result = [];
        Dictionary<string, List<string>> dict = [];

        foreach (var item in strs)
        {
            var key = SortString(item);
            if (!dict.TryGetValue(key, out var value))
            {
                value = ([item]);
                dict.Add(key, value);
                continue;
            }

            value.Add(item);
        }

        foreach (var key in dict.Keys)
        {
            result.Add(dict[key]);
        }

        return result;
    }

    private static string SortString(string str)
    {
        var charArr = str.ToCharArray();
        Array.Sort(charArr);
        return new string(charArr);
    }

    public static int MinimumCardPickup(int[] cards)
    {
        // https://leetcode.com/problems/minimum-consecutive-cards-to-pick-up/description/
        var result = int.MaxValue;
        Dictionary<int, int> dict = [];
        // key: item, value: index

        for (var i = 0; i < cards.Length; i++)
        {
            var key = cards[i];
            if (dict.TryGetValue(key, out var value))
            {
                result = Math.Min(i - value + 1, result);
            }
            dict[key] = i;
        }

        return result != int.MaxValue ? result : -1;
    }

    public static int EqualPairs(int[][] grid)
    {
        // https://leetcode.com/problems/equal-row-and-column-pairs/
        var result = 0;
        var n = grid.Length;
        Dictionary<string, int> dictRow = [];
        Dictionary<string, int> dictCol = [];
        // key: values in row or col
        // value: number of valid pairs

        for (var row = 0; row < n; row++)
        {
            var rowValues = "";
            var colValues = "";
            for (var col = 0; col < n; col++)
            {
                rowValues += $"{grid[row][col]},";
                colValues += $"{grid[col][row]},";
            }

            if (!dictRow.TryAdd(rowValues, 1))
            {
                dictRow[rowValues] += 1;
            }

            if (!dictCol.TryAdd(colValues, 1))
            {
                dictCol[colValues] += 1;
            }
        }

        foreach (var key in dictRow.Keys)
        {
            if (dictCol.TryGetValue(key, out var value))
            {
                result += dictRow[key] * value;
            }
        }

        return result;
    }

    public static bool CanConstruct(string ransomNote, string magazine)
    {
        // https://leetcode.com/problems/ransom-note/
        Dictionary<char, int> dict = [];

        foreach (var item in magazine.Where(item => !dict.TryAdd(item, 1)))
        {
            dict[item] += 1;
            continue;
        }

        foreach (var item in ransomNote)
        {
            if (!dict.ContainsKey(item)) return false;
            if (dict[item] == 0) return false;
            dict[item] -= 1;
        }

        return true;
    }

    public static int NumJewelsInStones(string jewels, string stones)
    {
        // https://leetcode.com/problems/jewels-and-stones/description/
        HashSet<char> hashSet = [];
        foreach (var jewel in jewels)
        {
            hashSet.Add(jewel);
        }

        return stones.Count(stone => hashSet.Contains(stone));
    }

    public static int LengthOfLongestSubstring(string s)
    {
        // https://leetcode.com/problems/longest-substring-without-repeating-characters/
        if (s.Length <= 1) return s.Length;
        var result = 0;
        Dictionary<char, int> dict = [];
        dict.Add(s[0], 0);

        for (var j = 1; j < s.Length; j++)
        {
            if (!dict.TryGetValue(s[j], out var removeIndex))
            {
                removeIndex = j;
                dict[s[j]] = removeIndex;
                continue;
            }
            result = Math.Max(dict.Count, result);
            while (removeIndex >= 0)
            {
                if (dict.TryGetValue(s[removeIndex], out var value) && removeIndex == value) dict.Remove(s[removeIndex]);

                removeIndex--;
            }
            dict.Add(s[j], j);
        }

        return Math.Max(result, dict.Count);
    }

    // ! Exercises
    // * Contain Duplicate
    public static bool ContainsDuplicate(int[] nums)
    {
        // https://leetcode.com/problems/contains-duplicate/description/
        HashSet<int> hashSet = [];

        return nums.Any(num => !hashSet.Add(num));
    }
    public static string DestCity(IList<IList<string>> paths)
    {
        // https://leetcode.com/problems/destination-city/description/
        Dictionary<string, int> dict = [];
        HashSet<string> destList = [];

        foreach (var path in paths)
        {
            var cityA = path[0];
            var cityB = path[1];

            if (!dict.TryAdd(cityA, 1))
            {
                dict[cityA] += 1;
            }

            destList.Add(cityB);
        }

        foreach (var city in destList.Where(city => !dict.ContainsKey(city)))
        {
            return city;
        }

        return "";
    }

    public static bool IsPathCrossing(string path)
    {
        // https://leetcode.com/problems/path-crossing/
        Dictionary<char, List<int>> table = [];
        HashSet<string> hashSet = ["0,0"];
        table.Add('N', [1, 0]);
        table.Add('E', [0, 1]);
        table.Add('S', [-1, 0]);
        table.Add('W', [0, -1]);

        List<int> curr = [0, 0];

        foreach (var point in path.Select(item => table[item]))
        {
            curr[0] += point[0];
            curr[1] += point[1];

            var currPoint = $"{curr[0]},{curr[1]}";
            if (!hashSet.Add(currPoint)) return true;
        }

        return false;
    }

    // * Counting
    public static int SumOfUnique(int[] nums)
    {
        // https://leetcode.com/problems/sum-of-unique-elements/
        Dictionary<int, int> table = [];

        foreach (var num in nums)
        {
            if (table.TryAdd(num, 1)) continue;
            table[num] += 1;
        }

        return table.Keys.Where(key => table[key] == 1).Sum();
    }

    public static int MaxFrequencyElements(int[] nums)
    {
        // https://leetcode.com/problems/count-elements-with-maximum-frequency/description/
        var max = 1;
        Dictionary<int, int> table = [];

        foreach (var num in nums)
        {
            if (table.TryAdd(num, 1)) continue;
            table[num] += 1;
            max = Math.Max(table[num], max);
        }

        return table.Keys.Where(key => table[key] == max).Sum(key => max);
    }

    public static int FindLucky(int[] arr)
    {
        // https://leetcode.com/problems/find-lucky-integer-in-an-array/description/
        Dictionary<int, int> table = [];

        foreach (var num in arr)
        {
            if (table.TryAdd(num, 1)) continue;
            table[num] += 1;
        }

        return table.Keys.Where(key => key == table[key]).Prepend(-1).Max();
    }

    public static bool UniqueOccurrences(int[] arr)
    {
        // https://leetcode.com/problems/unique-number-of-occurrences/description/
        Dictionary<int, int> table = [];
        HashSet<int> hashSet = [];

        foreach (var item in arr)
        {
            if (table.TryAdd(item, 1)) continue;
            table[item] += 1;
        }

        return table.Keys.All(key => hashSet.Add(table[key]));
    }

    public static string FrequencySort(string s)
    {
        // https://leetcode.com/problems/sort-characters-by-frequency/description/
        StringBuilder stringBuilder = new();
        Dictionary<char, int> table = [];

        foreach (var c in s.Where(c => !table.TryAdd(c, 1)))
        {
            table[c] += 1;
        }

        var sortedTable = table.OrderByDescending(item => item.Value);

        foreach (var entry in sortedTable)
        {
            for (var i = 0; i < entry.Value; i++)
            {
                stringBuilder.Append(entry.Key);
            }
        }

        return stringBuilder.ToString();
    }

    public static int MaxSubArrayLength(int[] nums, int k)
    {
        // https://leetcode.com/problems/length-of-longest-subarray-with-at-most-k-frequency/description/
        var curr = 1;
        var max = 1;
        Dictionary<int, int> table = [];
        table.Add(nums[0], 1);
        var left = 0;

        for (var right = 1; right < nums.Length; right++)
        {
            curr += 1;
            if (!table.ContainsKey(nums[right]))
            {
                table[nums[right]] = 1;
                max = Math.Max(max, curr);
                continue;
            }

            table[nums[right]] += 1;
            while (table[nums[right]] > k)
            {
                table[nums[left]] -= 1;
                left++;
                curr -= 1;
            }
            max = Math.Max(max, curr);
        }

        return max;
    }

    public static int NumIdenticalPairs(int[] nums)
    {
        // https://leetcode.com/problems/number-of-good-pairs/description/
        var result = 0;
        Dictionary<int, int> dict = [];

        foreach (var num in nums)
        {
            if (dict.TryAdd(num, 1)) continue;
            result += dict[num];
            dict[num] += 1;
        }
        return result;
    }

    public static int NumSubArraysWithSum(int[] nums, int goal)
    {
        // https://leetcode.com/problems/binary-subarrays-with-sum/description/
        int result = 0, curr = 0;
        var dict = new Dictionary<int, int> { { 0, 1 } };

        foreach (var num in nums)
        {
            curr += num;
            result += dict.GetValueOrDefault(curr - goal, 0);
            dict[curr] = dict.GetValueOrDefault(curr, 0) + 1;
        }

        return result;
    }

    public static int MaximumUniqueSubArray(int[] nums)
    {
        // https://leetcode.com/problems/maximum-erasure-value/
        HashSet<int> hashSet = [];
        var left = 0;
        var curr = nums[left];
        var max = curr;
        hashSet.Add(nums[left]);

        for (var right = 1; right < nums.Length; right++)
        {
            if (hashSet.Add(nums[right]))
            {
                curr += nums[right];
                max = Math.Max(max, curr);
                continue;
            }
            while (true)
            {
                curr -= nums[left];
                hashSet.Remove(nums[left]);
                if (nums[left] == nums[right]) break;
                left++;
            }
            left++;
            hashSet.Add(nums[right]);
            curr += nums[right];
            max = Math.Max(max, curr);
        }

        return max;
    }

    public static bool CheckInclusion(string s1, string s2)
    {
        Dictionary<char, int> dict1 = [];
        StringBuilder stringBuilder = new();

        foreach (var item in s1.Where(item => !dict1.TryAdd(item, 1)))
        {
            dict1[item] += 1;
        }

        foreach (var t in s2)
        {
            stringBuilder.Append(t);
            if (stringBuilder.Length != s1.Length) continue;
            if (CheckPermutation(dict1, stringBuilder.ToString())) return true;
            stringBuilder.Remove(0, 1);
        }

        return false;
    }

    private static bool CheckPermutation(Dictionary<char, int> dict, string s)
    {
        Dictionary<char, int> curr = [];
        foreach (var item in s.Where(item => !curr.TryAdd(item, 1)))
        {
            curr[item] += 1;
        }

        foreach (var key in dict.Keys)
        {
            if (!curr.TryGetValue(key, out int value)) return false;
            if (value != dict[key]) return false;
        }

        return true;
    }

    // * General
    public static bool IsIsomorphic(string s, string t)
    {
        // https://leetcode.com/problems/isomorphic-strings/description/
        Dictionary<char, char> dict = [];
        HashSet<char> hashSet = [];
        StringBuilder stringBuilder = new();

        for (var i = 0; i < s.Length; i++)
        {
            if (!dict.TryGetValue(s[i], out char value))
            {
                if (!hashSet.Add(t[i])) return false;
                value = t[i];
                dict[s[i]] = value;
            }
            stringBuilder.Append(value);
        }

        return stringBuilder.ToString() == t;
    }

    public static bool WordPattern(string pattern, string s)
    {
        // https://leetcode.com/problems/word-pattern/description/
        List<string> words = [.. s.Split(" ")];
        Dictionary<char, string> dict = [];
        HashSet<string> hashSet = [];

        if (pattern.Length != words.Count) return false;

        for (var i = 0; i < words.Count; i++)
        {
            if (!dict.TryGetValue(pattern[i], out string? value))
            {
                if (!hashSet.Add(words[i])) return false;
                value = words[i];
                dict[pattern[i]] = value;
            }
            if (value != words[i]) return false;
        }

        return true;
    }

    public static string CustomSortString(string order, string s)
    {
        // https://leetcode.com/problems/custom-sort-string/description/
        StringBuilder stringBuilder = new();

        // *Store order or character
        Dictionary<char, int> dict1 = [];
        // *Store occurrences for each character in target string
        Dictionary<char, int> dict2 = [];
        List<char> otherCharacter = [];

        for (var i = 0; i < order.Length; i++)
        {
            dict1[order[i]] = i;
        }

        foreach (var target in s)
        {
            if (!dict1.ContainsKey(target))
            {
                otherCharacter.Add(target);
                continue;
            }

            if (dict2.TryAdd(target, 1)) continue;
            dict2[target] += 1;
        }

        foreach (var orderItem in order)
        {
            if (!dict2.TryGetValue(orderItem, out var count)) continue;

            while (count != 0)
            {
                stringBuilder.Append(orderItem);
                count--;
            }
        }

        foreach (var item in otherCharacter)
        {
            stringBuilder.Append(item);
        }

        return stringBuilder.ToString();
    }

    public static bool CloseStrings(string word1, string word2)
    {
        // https://leetcode.com/problems/determine-if-two-strings-are-close/
        var n = word1.Length;
        if (n != word2.Length) return false;

        Dictionary<char, int> dict1 = [];
        Dictionary<char, int> dict2 = [];

        for (var i = 0; i < n; i++)
        {
            if (dict1.ContainsKey(word1[i]))
            {
                dict1[word1[i]] += 1;
            }
            else
            {
                dict1[word1[i]] = 1;
            }
            if (dict2.ContainsKey(word2[i]))
            {
                dict2[word2[i]] += 1;
            }
            else
            {
                dict2[word2[i]] = 1;
            }
        }

        List<int> list2 = [.. dict2.Values];

        foreach (var key1 in dict1.Keys)
        {
            if (!dict2.ContainsKey(key1)) return false;
            var flag = false;

            for (var i = 0; i < list2.Count; i++)
            {
                if (list2[i] != dict1[key1]) continue;
                flag = true;
                list2.Remove(list2[i]);
                break;
            }

            if (!flag) return false;
        }

        return true;
    }

    public static bool CloseStrings2(string word1, string word2)
    {
        // https://leetcode.com/problems/determine-if-two-strings-are-close/
        var n = word1.Length;
        if (n != word2.Length) return false;

        var count1 = new int[26];
        var count2 = new int[26];
        HashSet<char> set1 = [];
        HashSet<char> set2 = [];

        for (var i = 0; i < n; i++)
        {
            count1[word1[i] - 'a']++;
            set1.Add(word1[i]);
        }

        for (var i = 0; i < n; i++)
        {
            count2[word2[i] - 'a']++;
            set2.Add(word2[i]);
        }

        Array.Sort(count1);
        Array.Sort(count2);

        System.Console.WriteLine("====");
        foreach (var item in set1)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("====");
        foreach (var item in set2)
        {
            System.Console.WriteLine(item);
        }

        return set1.SetEquals(set2) && ArraysEqual(count1, count2);
    }
    private static bool ArraysEqual(int[] arr1, int[] arr2)
    {
        return !arr1.Where((t, i) => t != arr2[i]).Any();
    }
}
