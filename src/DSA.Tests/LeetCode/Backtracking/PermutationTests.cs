using DSA.LeetCode.Backtracking;

namespace DSA.Tests.LeetCode.Backtracking;

public class PermutationTests
{
    /// <summary>
    /// Tests Permute returns all n! permutations of a 3-element array.
    /// https://leetcode.com/problems/permutations/description/
    /// </summary>
    [Fact]
    public void Permute_ThreeElements_ReturnsSixPermutations()
    {
        var result = Permutation_Solution.Permute([1, 2, 3]);

        Assert.Equal(6, result.Count);
        Assert.Contains(result, p => p.SequenceEqual(new[] { 1, 2, 3 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 1, 3, 2 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 2, 1, 3 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 2, 3, 1 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 3, 1, 2 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 3, 2, 1 }));
    }

    /// <summary>
    /// Tests Permute on a single-element array — only the identity permutation exists.
    /// </summary>
    [Fact]
    public void Permute_SingleElement_ReturnsOnePermutation()
    {
        var result = Permutation_Solution.Permute([42]);

        Assert.Single(result);
        Assert.Equal(new[] { 42 }, result[0]);
    }

    /// <summary>
    /// Tests Permute on a two-element array returns both orderings.
    /// </summary>
    [Fact]
    public void Permute_TwoElements_ReturnsTwoPermutations()
    {
        var result = Permutation_Solution.Permute([0, 1]);

        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.SequenceEqual(new[] { 0, 1 }));
        Assert.Contains(result, p => p.SequenceEqual(new[] { 1, 0 }));
    }

    /// <summary>
    /// Tests Permute returns 24 permutations for a 4-element array (4! = 24).
    /// </summary>
    [Fact]
    public void Permute_FourElements_ReturnsTwentyFourPermutations()
    {
        var result = Permutation_Solution.Permute([1, 2, 3, 4]);

        Assert.Equal(24, result.Count);
        Assert.Equal(24, result.Select(p => string.Join(",", p)).Distinct().Count());
    }

    /// <summary>
    /// Tests every permutation contains exactly the input elements.
    /// </summary>
    [Fact]
    public void Permute_AllResults_ContainOriginalElementsExactlyOnce()
    {
        var input = new[] { 5, 6, 7 };

        var result = Permutation_Solution.Permute(input);

        Assert.All(result, p =>
        {
            Assert.Equal(input.Length, p.Count);
            Assert.Equal(input.OrderBy(x => x), p.OrderBy(x => x));
        });
    }
}
