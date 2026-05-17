using DSA.LeetCode.DynamicProgramming;

namespace DSA.Tests.LeetCode.DynamicProgramming;

public class MostPointsTests
{
    /// <summary>
    /// Tests MostPoints on the LeetCode canonical example.
    /// https://leetcode.com/problems/solving-questions-with-brainpower/
    /// </summary>
    [Fact]
    public void MostPoints_CanonicalExample_ReturnsFive()
    {
        int[][] questions = [[3, 2], [4, 3], [4, 4], [2, 5]];

        var result = SolvingQuestionsWithBrainpowerSolution.MostPoints(questions);

        Assert.Equal(5, result);
    }

    /// <summary>
    /// Tests MostPoints on the second LeetCode example.
    /// </summary>
    [Fact]
    public void MostPoints_SecondExample_ReturnsSeven()
    {
        int[][] questions = [[1, 1], [2, 2], [3, 3], [4, 4], [5, 5]];

        var result = SolvingQuestionsWithBrainpowerSolution.MostPoints(questions);

        Assert.Equal(7, result);
    }

    /// <summary>
    /// Tests MostPoints on a single question with zero brainpower cost.
    /// </summary>
    [Fact]
    public void MostPoints_SingleQuestion_ReturnsItsPoints()
    {
        int[][] questions = [[10, 0]];

        var result = SolvingQuestionsWithBrainpowerSolution.MostPoints(questions);

        Assert.Equal(10, result);
    }
}
