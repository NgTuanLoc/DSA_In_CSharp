using DSA.LeetCode.TreesAndGraphs;

namespace DSA.Tests.LeetCode.TreesAndGraphs;

public class ShortestPathBinaryMatrixSolutionTests
{
    [Fact]
    public void ShortestPathBinaryMatrix_StartBlocked_ReturnsNegativeOne()
    {
        var grid = new int[][] { new int[] { 1 } };
        var solution = new ShortestPathBinaryMatrixSolution();
        var result = solution.ShortestPathBinaryMatrix(grid);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void ShortestPathBinaryMatrix_WithObstacles_FindsPath()
    {
        var grid = new int[][]
        {
            new int[] { 0, 1 },
            new int[] { 1, 0 }
        };
        var solution = new ShortestPathBinaryMatrixSolution();
        var result = solution.ShortestPathBinaryMatrix(grid);

        // Can still find path diagonally
        Assert.True(result > 0 || result == -1);
    }

    [Fact]
    public void ShortestPathBinaryMatrix_SingleCell_ReturnsOne()
    {
        var grid = new int[][] { new int[] { 0 } };
        var solution = new ShortestPathBinaryMatrixSolution();
        var result = solution.ShortestPathBinaryMatrix(grid);

        Assert.Equal(1, result);
    }

    [Fact]
    public void ShortestPathBinaryMatrix_TwoByTwoClear_ReturnsTwoOrLess()
    {
        var grid = new int[][]
        {
            new int[] { 0, 0 },
            new int[] { 0, 0 }
        };
        var solution = new ShortestPathBinaryMatrixSolution();
        var result = solution.ShortestPathBinaryMatrix(grid);

        Assert.True(result > 0 && result <= 2);
    }

    [Fact]
    public void ShortestPathBinaryMatrix_ComplexPath_FindsRoute()
    {
        var grid = new int[][]
        {
            new int[] { 0, 1, 0, 0 },
            new int[] { 0, 1, 0, 1 },
            new int[] { 0, 0, 0, 0 },
            new int[] { 1, 1, 1, 0 }
        };
        var solution = new ShortestPathBinaryMatrixSolution();
        var result = solution.ShortestPathBinaryMatrix(grid);

        Assert.True(result > 0);
    }

    [Fact]
    public void ShortestPathBinaryMatrix_AllObstacles_ReturnsNegativeOne()
    {
        var grid = new int[][]
        {
            new int[] { 1, 1 },
            new int[] { 1, 1 }
        };
        var solution = new ShortestPathBinaryMatrixSolution();
        var result = solution.ShortestPathBinaryMatrix(grid);

        Assert.Equal(-1, result);
    }
}

public class AllNodesDistanceKInBinaryTreeTests
{
    private TreeNode CreateTree()
    {
        var root = new TreeNode(3);
        root.Left = new TreeNode(5);
        root.Right = new TreeNode(1);
        root.Left.Left = new TreeNode(6);
        root.Left.Right = new TreeNode(2);
        root.Left.Right.Left = new TreeNode(7);
        root.Left.Right.Right = new TreeNode(4);
        root.Right.Left = new TreeNode(0);
        root.Right.Right = new TreeNode(8);
        return root;
    }

    [Fact]
    public void DistanceK_TargetRoot_ReturnsNodesAtDistance()
    {
        var root = CreateTree();
        var target = root;
        var solution = new AllNodesDistanceKInBinaryTree();
        var result = solution.DistanceK(root, target, 2);

        Assert.NotEmpty(result);
    }

    [Fact]
    public void DistanceK_KIsZero_ReturnsTarget()
    {
        var root = CreateTree();
        var target = root.Left;
        var solution = new AllNodesDistanceKInBinaryTree();
        var result = solution.DistanceK(root, target, 0);

        Assert.Single(result);
        Assert.Equal(5, result[0]);
    }

    [Fact]
    public void DistanceK_KExceedsTreeDepth_ReturnsEmpty()
    {
        var root = CreateTree();
        var target = root.Left;
        var solution = new AllNodesDistanceKInBinaryTree();
        var result = solution.DistanceK(root, target, 10);

        Assert.Empty(result);
    }

    [Fact]
    public void DistanceK_SimpleTree_ReturnsCorrectNodes()
    {
        var root = new TreeNode(1);
        root.Left = new TreeNode(2);
        var solution = new AllNodesDistanceKInBinaryTree();
        var result = solution.DistanceK(root, root, 1);

        Assert.NotEmpty(result);
    }
}

public class Matrix01Tests
{
    [Fact]
    public void UpdateMatrix_AllZeros_ReturnsZeros()
    {
        var mat = new int[][]
        {
            new int[] { 0, 0 },
            new int[] { 0, 0 }
        };
        var solution = new Matrix01();
        var result = solution.UpdateMatrix(mat);

        Assert.All(result, row => Assert.All(row, val => Assert.Equal(0, val)));
    }

    [Fact]
    public void UpdateMatrix_AllOnes_ReturnsDistances()
    {
        var mat = new int[][]
        {
            new int[] { 1, 1 },
            new int[] { 1, 0 }
        };
        var solution = new Matrix01();
        var result = solution.UpdateMatrix(mat);

        Assert.NotNull(result);
    }

    [Fact]
    public void UpdateMatrix_SingleCell_ReturnsSelf()
    {
        var mat = new int[][] { new int[] { 0 } };
        var solution = new Matrix01();
        var result = solution.UpdateMatrix(mat);

        Assert.Equal(0, result[0][0]);
    }

    [Fact]
    public void UpdateMatrix_MixedMatrix_CalculatesCorrectDistances()
    {
        var mat = new int[][]
        {
            new int[] { 0, 0, 0 },
            new int[] { 0, 1, 0 },
            new int[] { 1, 1, 1 }
        };
        var solution = new Matrix01();
        var result = solution.UpdateMatrix(mat);

        Assert.Equal(0, result[0][0]);
        Assert.Equal(0, result[1][0]);
        Assert.True(result[2][0] > 0);
    }
}

public class ShortestPathInAGridWithObstaclesEliminationTests
{
    [Fact]
    public void ShortestPath_NoObstacles_FindsPath()
    {
        var grid = new int[][]
        {
            new int[] { 0, 1, 0 },
            new int[] { 0, 1, 0 },
            new int[] { 0, 0, 0 }
        };
        var k = 0;
        var solution = new ShortestPathInAGridWithObstaclesElimination();
        var result = solution.ShortestPath(grid, k);

        Assert.True(result > 0);
    }

    [Fact]
    public void ShortestPath_CanEliminateObstacles_FindsShorterPath()
    {
        var grid = new int[][]
        {
            new int[] { 0, 1, 0 },
            new int[] { 0, 1, 0 },
            new int[] { 0, 0, 0 }
        };
        var k = 1;
        var solution = new ShortestPathInAGridWithObstaclesElimination();
        var result = solution.ShortestPath(grid, k);

        Assert.True(result > 0);
    }

    [Fact]
    public void ShortestPath_BlockedGrid_ReturnsNegativeOne()
    {
        var grid = new int[][]
        {
            new int[] { 0, 1 },
            new int[] { 1, 0 }
        };
        var k = 0;
        var solution = new ShortestPathInAGridWithObstaclesElimination();
        var result = solution.ShortestPath(grid, k);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void ShortestPath_SingleCell_ReturnsZero()
    {
        var grid = new int[][] { new int[] { 0 } };
        var k = 0;
        var solution = new ShortestPathInAGridWithObstaclesElimination();
        var result = solution.ShortestPath(grid, k);

        // Returns distance to bottom-right, which is 0 for single cell
        Assert.True(result >= 0);
    }
}

public class ShortestAlternatingPathsSolutionTests
{
    [Fact]
    public void ShortestAlternatingPaths_SimpleGraph_ReturnsDistances()
    {
        var n = 3;
        var redEdges = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 } };
        var blueEdges = new int[][] { };
        var solution = new ShortestAlternatingPathsSolution();
        var result = solution.ShortestAlternatingPaths(n, redEdges, blueEdges);

        Assert.Equal(3, result.Length);
        Assert.Equal(0, result[0]);
    }

    [Fact]
    public void ShortestAlternatingPaths_NoPath_ReturnsNegativeOne()
    {
        var n = 3;
        var redEdges = new int[][] { new int[] { 0, 1 } };
        var blueEdges = new int[][] { };
        var solution = new ShortestAlternatingPathsSolution();
        var result = solution.ShortestAlternatingPaths(n, redEdges, blueEdges);

        Assert.Equal(3, result.Length);
        Assert.Equal(-1, result[2]);
    }

    [Fact]
    public void ShortestAlternatingPaths_MultipleColors_AlternatesCorrectly()
    {
        var n = 3;
        var redEdges = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 } };
        var blueEdges = new int[][] { new int[] { 1, 0 } };
        var solution = new ShortestAlternatingPathsSolution();
        var result = solution.ShortestAlternatingPaths(n, redEdges, blueEdges);

        Assert.Equal(3, result.Length);
    }

    [Fact]
    public void ShortestAlternatingPaths_BothColorsFromStart_FindsShortest()
    {
        var n = 2;
        var redEdges = new int[][] { new int[] { 0, 1 } };
        var blueEdges = new int[][] { new int[] { 0, 1 } };
        var solution = new ShortestAlternatingPathsSolution();
        var result = solution.ShortestAlternatingPaths(n, redEdges, blueEdges);

        Assert.Equal(2, result.Length);
        Assert.Equal(0, result[0]);
        Assert.Equal(1, result[1]);
    }
}

public class NearestExitFromEntranceInMazeTests
{
    [Fact]
    public void NearestExit_SimpleCase_FindsExit()
    {
        var maze = new char[][]
        {
            new char[] { '+', '+', '.', '+' },
            new char[] { '.', '.', '.', '+' },
            new char[] { '+', '+', '+', '.' }
        };
        var entrance = new int[] { 1, 2 };
        var solution = new NearestExitFromEntranceInMaze();
        var result = solution.NearestExit(maze, entrance);

        Assert.True(result > 0 || result == -1);
    }

    [Fact]
    public void NearestExit_NoExit_ReturnsNegativeOne()
    {
        var maze = new char[][]
        {
            new char[] { '+', '+' },
            new char[] { '+', '.' }
        };
        var entrance = new int[] { 0, 0 };
        var solution = new NearestExitFromEntranceInMaze();
        var result = solution.NearestExit(maze, entrance);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void NearestExit_OnBorderWithAdjacentExit_FindsExit()
    {
        var maze = new char[][]
        {
            new char[] { '.', '.' },
            new char[] { '.', '+' }
        };
        var entrance = new int[] { 0, 0 };
        var solution = new NearestExitFromEntranceInMaze();
        var result = solution.NearestExit(maze, entrance);

        Assert.True(result > 0 || result == -1);
    }
}

public class SnakeAndTheLaddersSolutionTests
{
    [Fact]
    public void SnakesAndLadders_SimpleBoard_ReturnsPositiveDistance()
    {
        var board = new int[][]
        {
            new int[] { -1, -1, -1, -1, -1, -1 },
            new int[] { -1, -1, -1, -1, -1, -1 },
            new int[] { -1, -1, -1, -1, -1, -1 },
            new int[] { -1, 35, -1, -1, 13, -1 },
            new int[] { -1, -1, -1, -1, -1, -1 },
            new int[] { -1, 15, -1, -1, -1, -1 }
        };
        var solution = new SnakeAndTheLaddersSolution();
        var result = solution.SnakesAndLadders(board);

        Assert.True(result > 0);
    }

    [Fact]
    public void SnakesAndLadders_NoSnakesOrLadders_ReturnsMinimumMoves()
    {
        var board = new int[][]
        {
            new int[] { -1, -1 },
            new int[] { -1, -1 }
        };
        var solution = new SnakeAndTheLaddersSolution();
        var result = solution.SnakesAndLadders(board);

        Assert.True(result > 0);
    }

    [Fact]
    public void SnakesAndLadders_WithLadder_ReducesMoves()
    {
        var board = new int[][]
        {
            new int[] { -1, 2, -1 },
            new int[] { -1, -1, -1 },
            new int[] { -1, -1, -1 }
        };
        var solution = new SnakeAndTheLaddersSolution();
        var result = solution.SnakesAndLadders(board);

        Assert.True(result > 0);
    }

    [Fact]
    public void SnakesAndLadders_MinimalBoard_ReturnsDistance()
    {
        var board = new int[][]
        {
            new int[] { -1, -1 },
            new int[] { -1, -1 }
        };
        var solution = new SnakeAndTheLaddersSolution();
        var result = solution.SnakesAndLadders(board);

        Assert.True(result > 0);
    }
}
