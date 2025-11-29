namespace DSA.LeetCode.Hashing;

public class CheckForExistence
{
    // !Checking for existence
    public static List<int> TwoSum(List<int> nums, int target)
    {
        Dictionary<int, int> table = [];

        for (var i = 0; i < nums.Count; i++)
        {
            if (table.TryGetValue(nums[i], out var value)) return [i, value];

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

        foreach (var item in s.Where(item => !table.Add(item)))
        {
            return item;
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

        result.AddRange(nums.Where(item => !table.Contains(item - 1) && !table.Contains(item + 1)));

        return result;
    }

    public static bool CheckIfPangram(string sentence)
    {
        // https://leetcode.com/problems/check-if-the-sentence-is-pangram/
        var table = new int[26];

        foreach (var item in sentence)
        {
            table[item - 'a'] = 1;
        }

        return table.All(item => item != 0);
    }

    public static int MissingNumber(int[] nums)
    {
        // https://leetcode.com/problems/missing-number/description/
        HashSet<int> table = [];

        foreach (var t in nums)
        {
            table.Add(t);
        }

        for (var i = 0; i < nums.Length + 1; i++)
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

        foreach (var item in arr)
        {
            table.Add(item);
        }

        return arr.Count(item => table.Contains(item + 1));
    }
}
