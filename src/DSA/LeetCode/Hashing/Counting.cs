namespace DSA.LeetCode.Hashing;

public class Counting
{
    public static int FindLongestSubstring(string s, int k)
    {
        // Example 1: You are given a string s and an integer k. Find the length of the longest substring that contains at most k distinct characters.
        // For example, given s = "eceba" and k = 2, return 3. The longest substring with at most 2 distinct characters is "ece".

        Dictionary<char, int> table = [];
        var answer = 0;
        var left = 0;

        for (var right = 0; right < s.Length; right++)
        {
            if (table.ContainsKey(s[right]))
            {
                table[s[right]] += 1;
            }
            else
            {
                table[s[right]] = 1;
            }

            while (table.Keys.Count > k)
            {
                table[s[left]] -= 1;
                if (table[s[left]] == 0) table.Remove(s[left]);
                left++;
            }
            answer = Math.Max(answer, right - left + 1);
        }

        return answer;
    }

    public static IList<int> Intersection(int[][] nums)
    {
        // https://leetcode.com/problems/intersection-of-multiple-arrays/
        List<int> result = [];
        Dictionary<int, int> table = [];
        var n = nums.Length;

        for (var i = 0; i < nums[0].Length; i++)
        {
            table.Add(nums[0][i], 1);
        }

        for (var i = 1; i < nums.Length; i++)
        {
            var list = nums[i];
            foreach (var item in list)
            {
                if (table.ContainsKey(item)) table[item] += 1;
            }
        }

        result.AddRange(table.Keys.Where(key => table[key] == n));

        result.Sort();

        return result;
    }

    public static bool AreOccurrencesEqual(string s)
    {
        // https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences/description/
        Dictionary<char, int> table = [];

        foreach (var c in s.Where(c => !table.TryAdd(c, 1)))
        {
            table[c] += 1;
        }

        var temp = table[s[0]];

        return table.Keys.All(key => table[key] == temp);
    }
    public static int SubArraySum(int[] nums, int k)
    {
        // https://leetcode.com/problems/subarray-sum-equals-k/description/
        var answer = 0;
        var curr = 0;
        Dictionary<int, int> table = [];
        table.Add(0, 1);

        foreach (var t in nums)
        {
            curr += t;
            if (table.ContainsKey(curr - k))
            {
                answer += table[curr - k];
            }

            if (table.TryAdd(curr, 1)) continue;
            table[curr] += 1;
        }

        return answer;
    }

    public static int NumberOfSubArrays(int[] nums, int k)
    {
        // https://leetcode.com/problems/count-number-of-nice-subarrays/
        var answer = 0;
        var curr = 0;
        Dictionary<int, int> table = [];
        table.Add(0, 1);

        foreach (var t in nums)
        {
            curr += t % 2;
            if (table.ContainsKey(curr - k))
            {
                answer += table[curr - k];
            }

            if (table.TryAdd(curr, 1)) continue;
            table[curr] += 1;
        }

        return answer;
    }

    public static IList<IList<int>> FindWinners(int[][] matches)
    {
        // https://leetcode.com/problems/find-players-with-zero-or-one-losses/description/
        Dictionary<int, int> tableHistoryAboutLossMatches = [];
        IList<IList<int>> result = [[], []];

        foreach (var match in matches)
        {
            var winner = match[0];
            var loser = match[1];

            if (!tableHistoryAboutLossMatches.TryAdd(loser, 1))
            {
                tableHistoryAboutLossMatches[loser] += 1;
            }

            tableHistoryAboutLossMatches.TryAdd(winner, 0);
        }

        List<int> sortedPlayerList = [.. tableHistoryAboutLossMatches.Keys];
        sortedPlayerList.Sort();

        foreach (var player in sortedPlayerList)
        {
            if (tableHistoryAboutLossMatches[player] == 0) result[0].Add(player);
            if (tableHistoryAboutLossMatches[player] == 1) result[1].Add(player);
        }
        return result;
    }

    public static int LargestUniqueNumber(int[] nums)
    {
        // https://leetcode.com/problems/largest-unique-number/description/
        Dictionary<int, int> table = [];

        foreach (var item in nums)
        {
            if (table.TryAdd(item, 1)) continue;
            table[item] += 1;
            continue;
        }

        return table.Keys.Where(key => table[key] == 1).Prepend(-1).Max();
    }

    public static int MaxNumberOfBalloons(string text)
    {
        // https://leetcode.com/problems/maximum-number-of-balloons/
        Dictionary<char, int> table = [];

        foreach (var c in text.Where(c => !table.TryAdd(c, 1)))
        {
            table[c] += 1;
            continue;
        }

        var result = 0;
        const string s = "balloon";

        while (true)
        {
            foreach (var c in s)
            {
                if (!table.TryGetValue(c, out var value) || value == 0) return result;
                table[c] -= 1;
            }
            result++;
        }
    }

    public static int FindMaxLength(int[] nums)
    {
        // https://leetcode.com/problems/contiguous-array/description/
        var result = 0;
        var count = 0;
        Dictionary<int, int> table = [];
        table.Add(0, -1);

        for (var i = 0; i < nums.Length; i++)
        {
            count += nums[i] == 0 ? -1 : 1;
            if (table.TryGetValue(count, out int value))
            {
                result = Math.Max(result, i - value);
            }
            else
            {
                table.Add(count, i);
            }
        }
        return result;
    }
}
