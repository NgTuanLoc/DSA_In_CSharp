namespace DSA.LeetCode.Hashing;

public class CheckForExistence
{
    // !Checking for existence
    public static List<int> TwoSum(List<int> nums, int target)
    {
        Dictionary<int, int> table = [];

        for (int i = 0; i < nums.Count; i++)
        {
            if (table.ContainsKey(nums[i])) return [i, table[nums[i]]];

            table.Add(target - nums[i], i);
        }
        foreach (var item in table.Keys)
        {
            Console.WriteLine(item);
        }
        return [-1, -1];
    }

    public static char RepeatedCharacter(string s)
    {
        // https://leetcode.com/problems/first-letter-to-appear-twice/description/
        HashSet<int> table = [];

        foreach (var item in s)
        {
            if (table.Contains(item)) return item;
            table.Add(item);
        }

        return 'a';
    }

    public static List<int> FindNumbers(List<int> nums)
    {
        List<int> result = [];
        HashSet<int> table = [];

        foreach (var item in nums)
        {
            table.Add(item);
        }

        foreach (var item in nums)
        {
            if (table.Contains(item - 1) || table.Contains(item + 1)) continue;
            result.Add(item);
        }

        return result;
    }

    public static bool CheckIfPangram(string sentence)
    {
        // https://leetcode.com/problems/check-if-the-sentence-is-pangram/
        int[] table = new int[26];

        foreach (var item in sentence)
        {
            table[item - 'a'] = 1;
        }

        foreach (var item in table)
        {
            if (item == 0) return false;
        }

        return true;
    }

    public static int MissingNumber(int[] nums)
    {
        // https://leetcode.com/problems/missing-number/description/
        HashSet<int> table = [];

        for (int i = 0; i < nums.Length; i++)
        {
            table.Add(nums[i]);
        }

        for (int i = 0; i < nums.Length + 1; i++)
        {
            if (!table.Contains(i)) return i;
        }

        return 0;
    }

    public static int CountElements(int[] arr)
    {
        // https://leetcode.com/problems/counting-elements/description/
        // Given an integer array arr, count how many elements x there are, such that x + 1 is also in arr. If there are duplicates in arr, count them separately.
        HashSet<int> table = [];
        int count = 0;

        foreach (var item in arr)
        {
            table.Add(item);
        }

        foreach (var item in arr)
        {
            if (table.Contains(item + 1)) count++;
        }

        return count;
    }
}
