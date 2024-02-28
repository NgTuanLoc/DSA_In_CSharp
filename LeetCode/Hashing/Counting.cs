namespace DSA.LeetCode.Hashing;

public class Counting
{
    public static int FindLongestSubstring(string s, int k)
    {
        // Example 1: You are given a string s and an integer k. Find the length of the longest substring that contains at most k distinct characters.
        // For example, given s = "eceba" and k = 2, return 3. The longest substring with at most 2 distinct characters is "ece".

        Dictionary<char, int> table = [];
        int answer = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++)
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

    // https://leetcode.com/problems/intersection-of-multiple-arrays/
    public static IList<int> Intersection(int[][] nums)
    {
        List<int> result = [];
        Dictionary<int, int> table = [];
        int n = nums.Length;

        for (int i = 0; i < nums[0].Length; i++)
        {
            table.Add(nums[0][i], 1);
        }

        for (int i = 1; i < nums.Length; i++)
        {
            var list = nums[i];
            foreach (var item in list)
            {
                if (table.ContainsKey(item)) table[item] += 1;
            }
        }

        foreach (var key in table.Keys)
        {
            if (table[key] == n) result.Add(key);
        }

        result.Sort();

        return result;
    }

    public static bool AreOccurrencesEqual(string s)
    {
        // https://leetcode.com/problems/check-if-all-characters-have-equal-number-of-occurrences/description/
        Dictionary<char, int> table = [];

        foreach (var c in s)
        {
            if (table.ContainsKey(c))
            {
                table[c] += 1;
                continue;
            }
            table.Add(c, 1);
        }

        int temp = table[s[0]];

        foreach (var key in table.Keys)
        {
            if (table[key] != temp) return false;
        }

        return true;
    }
    public static int SubArraySum(int[] nums, int k)
    {
        // https://leetcode.com/problems/subarray-sum-equals-k/description/
        int answer = 0;
        int curr = 0;
        Dictionary<int, int> table = [];
        table.Add(0, 1);

        for (int i = 0; i < nums.Length; i++)
        {
            curr += nums[i];
            if (table.ContainsKey(curr - k))
            {
                answer += table[curr - k];
            }
            if (table.ContainsKey(curr))
            {
                table[curr] += 1;
                continue;
            }
            table[curr] = 1;
        }

        return answer;
    }

    public static int NumberOfSubArrays(int[] nums, int k)
    {
        // https://leetcode.com/problems/count-number-of-nice-subarrays/
        int answer = 0;
        int curr = 0;
        Dictionary<int, int> table = [];
        table.Add(0, 1);

        for (int i = 0; i < nums.Length; i++)
        {
            curr += nums[i] % 2;
            if (table.ContainsKey(curr - k))
            {
                answer += table[curr - k];
            }
            if (table.ContainsKey(curr))
            {
                table[curr] += 1;
                continue;
            }
            table[curr] = 1;
        }

        return answer;
    }
    // https://leetcode.com/problems/find-players-with-zero-or-one-losses/
    public static IList<IList<int>> FindWinners(int[][] matches)
    {
        // https://leetcode.com/problems/find-players-with-zero-or-one-losses/description/
        Dictionary<int, int> tableHistoryAboutLossMatches = [];
        IList<IList<int>> result = [[], []];

        for (int i = 0; i < matches.Length; i++)
        {
            var match = matches[i];
            var winner = match[0];
            var loser = match[1];

            if (!tableHistoryAboutLossMatches.ContainsKey(loser))
            {
                tableHistoryAboutLossMatches[loser] = 1;
            }
            else
            {
                tableHistoryAboutLossMatches[loser] += 1;
            }
            if (!tableHistoryAboutLossMatches.ContainsKey(winner))
            {
                tableHistoryAboutLossMatches[winner] = 0;
            }
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
            if (table.ContainsKey(item))
            {
                table[item] += 1;
                continue;
            }
            table[item] = 1;
        }

        int answer = -1;
        foreach (var key in table.Keys)
        {
            if (table[key] == 1) answer = Math.Max(answer, key);
        }

        return answer;
    }

    public static int MaxNumberOfBalloons(string text)
    {
        // https://leetcode.com/problems/maximum-number-of-balloons/
        Dictionary<char, int> table = [];

        foreach (var c in text)
        {
            if (table.ContainsKey(c))
            {
                table[c] += 1;
                continue;
            }
            table[c] = 1;
        }

        int result = 0;
        string s = "balloon";

        while (true)
        {
            foreach (var c in s)
            {
                if (!table.ContainsKey(c)) return result;
                if (table[c] == 0) return result;
                table[c] -= 1;
            }
            result++;
        }
    }

    public static int FindMaxLength(int[] nums)
    {
        // https://leetcode.com/problems/contiguous-array/description/
        int result = 0;
        int count = 0;
        Dictionary<int, int> table = [];
        table.Add(0, -1);

        for (int i = 0; i < nums.Length; i++)
        {
            count += nums[i] == 0 ? -1 : 1;
            if (table.ContainsKey(count))
            {
                result = Math.Max(result, i - table[count]);
            }
            else
            {
                table.Add(count, i);
            }
        }

        return result;
    }

}
