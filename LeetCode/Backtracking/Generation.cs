namespace DSA.LeetCode.Backtracking;


// !https://leetcode.com/problems/permutations/description/
public class Permutation_Solution
{
    public static IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> result = [];
        Backtracking([], result, nums);
        return result;
    }

    private static void Backtracking(List<int> curr, IList<IList<int>> result, int[] nums)
    {
        if (curr.Count == nums.Length)
        {
            result.Add([.. curr]);
            return;
        }

        foreach (var item in nums)
        {
            if (!curr.Contains(item))
            {
                curr.Add(item);
                Backtracking(curr, result, nums);
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }
}

class Subsets_Solution
{

    public static IList<IList<int>> Subsets(int[] nums)
    {
        // https://leetcode.com/problems/subsets/
        IList<IList<int>> result = [];
        Backtracking([], result, nums, 0);
        return result;
    }

    private static void Backtracking(List<int> curr, IList<IList<int>> result, int[] nums, int i)
    {
        if (curr.Count > nums.Length) return;
        result.Add([.. curr]);
        for (int j = i; j < nums.Length; j++)
        {
            curr.Add(nums[j]);
            Backtracking(curr, result, nums, j + 1);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}

public class Combination_Solution
{
    public static IList<IList<int>> Combine(int n, int k)
    {
        IList<IList<int>> result = [];
        Backtracking([], result, n, k, 1);
        return result;
    }

    private static void Backtracking(List<int> curr, IList<IList<int>> result, int n, int k, int i)
    {
        if (curr.Count == k)
        {
            result.Add([.. curr]);
            return;
        }

        for (int j = i; j <= n; j++)
        {
            curr.Add(j);
            Backtracking(curr, result, n, k, j + 1);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}