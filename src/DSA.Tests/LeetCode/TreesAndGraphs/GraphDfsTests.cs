using DSA.LeetCode.TreesAndGraphs;

namespace DSA.Tests.LeetCode.TreesAndGraphs;

public class GraphDfsTests
{
    #region FindCircleNum Tests

    /// <summary>
    /// Tests FindCircleNum with basic connected components.
    /// https://leetcode.com/problems/number-of-provinces/
    /// Pattern: Graph DFS - count connected components in undirected graph
    /// </summary>
    [Fact]
    public void FindCircleNum_WithBasicConnectedComponents_ReturnsCorrectCount()
    {
        var isConnected = new int[][]
        {
            [1, 1, 0],
            [1, 1, 0],
            [0, 0, 1]
        };

        var solution = new GraphDfsFindCircleNum();
        var result = solution.FindCircleNum(isConnected);

        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests FindCircleNum with all nodes isolated.
    /// </summary>
    [Fact]
    public void FindCircleNum_WithAllNodesIsolated_ReturnsNodeCount()
    {
        var isConnected = new int[][]
        {
            [1, 0, 0],
            [0, 1, 0],
            [0, 0, 1]
        };

        var solution = new GraphDfsFindCircleNum();
        var result = solution.FindCircleNum(isConnected);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests FindCircleNum with all nodes connected.
    /// </summary>
    [Fact]
    public void FindCircleNum_WithAllNodesConnected_ReturnsOne()
    {
        var isConnected = new int[][]
        {
            [1, 1, 1],
            [1, 1, 1],
            [1, 1, 1]
        };

        var solution = new GraphDfsFindCircleNum();
        var result = solution.FindCircleNum(isConnected);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests FindCircleNum with single node.
    /// </summary>
    [Fact]
    public void FindCircleNum_WithSingleNode_ReturnsOne()
    {
        var isConnected = new int[][]
        {
            [1]
        };

        var solution = new GraphDfsFindCircleNum();
        var result = solution.FindCircleNum(isConnected);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests FindCircleNum with complex graph.
    /// </summary>
    [Fact]
    public void FindCircleNum_WithComplexGraph_ReturnsCorrectCount()
    {
        var isConnected = new int[][]
        {
            [1, 0, 0, 1],
            [0, 1, 1, 0],
            [0, 1, 1, 1],
            [1, 0, 1, 1]
        };

        var solution = new GraphDfsFindCircleNum();
        var result = solution.FindCircleNum(isConnected);

        Assert.Equal(1, result);
    }

    #endregion

    #region NumIslands Tests

    /// <summary>
    /// Tests NumIslands with basic grid.
    /// https://leetcode.com/problems/number-of-islands/description/
    /// Pattern: Grid DFS - count connected land components
    /// </summary>
    [Fact]
    public void NumIslands_WithBasicGrid_ReturnsCorrectCount()
    {
        var grid = new char[][]
        {
            ['1', '1', '1', '1', '0'],
            ['1', '1', '0', '1', '0'],
            ['1', '1', '0', '0', '0'],
            ['0', '0', '0', '0', '0']
        };

        var solution = new GraphDfsNumIslands();
        var result = solution.NumIslands(grid);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests NumIslands with multiple islands.
    /// </summary>
    [Fact]
    public void NumIslands_WithMultipleIslands_ReturnsCorrectCount()
    {
        var grid = new char[][]
        {
            ['1', '1', '0', '0', '0'],
            ['1', '1', '0', '0', '0'],
            ['0', '0', '1', '0', '0'],
            ['0', '0', '0', '1', '1']
        };

        var solution = new GraphDfsNumIslands();
        var result = solution.NumIslands(grid);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests NumIslands with all water.
    /// </summary>
    [Fact]
    public void NumIslands_WithAllWater_ReturnsZero()
    {
        var grid = new char[][]
        {
            ['0', '0', '0'],
            ['0', '0', '0'],
            ['0', '0', '0']
        };

        var solution = new GraphDfsNumIslands();
        var result = solution.NumIslands(grid);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests NumIslands with all land.
    /// </summary>
    [Fact]
    public void NumIslands_WithAllLand_ReturnsOne()
    {
        var grid = new char[][]
        {
            ['1', '1'],
            ['1', '1']
        };

        var solution = new GraphDfsNumIslands();
        var result = solution.NumIslands(grid);

        Assert.Equal(1, result);
    }

    /// <summary>
    /// Tests NumIslands with single cell island.
    /// </summary>
    [Fact]
    public void NumIslands_WithSingleCellIsland_ReturnsOne()
    {
        var grid = new char[][]
        {
            ['1']
        };

        var solution = new GraphDfsNumIslands();
        var result = solution.NumIslands(grid);

        Assert.Equal(1, result);
    }

    #endregion

    #region MinReorder Tests

    /// <summary>
    /// Tests MinReorder with basic tree.
    /// https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero/description/
    /// Pattern: Graph DFS with directed edges tracking
    /// </summary>
    [Fact]
    public void MinReorder_WithBasicTree_ReturnsCorrectChanges()
    {
        var connections = new int[][]
        {
            [0, 1],
            [1, 3],
            [2, 3],
            [4, 0],
            [4, 5]
        };

        var solution = new MinReorderToTheCityZero();
        var result = solution.MinReorder(6, connections);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests MinReorder with all edges pointing to zero.
    /// </summary>
    [Fact]
    public void MinReorder_WithAllEdgesPointingToZero_ReturnsZero()
    {
        var connections = new int[][]
        {
            [1, 0],
            [2, 0]
        };

        var solution = new MinReorderToTheCityZero();
        var result = solution.MinReorder(3, connections);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests MinReorder with linear chain.
    /// </summary>
    [Fact]
    public void MinReorder_WithLinearChain_ReturnsCorrectChanges()
    {
        var connections = new int[][]
        {
            [0, 1],
            [1, 2],
            [2, 3]
        };

        var solution = new MinReorderToTheCityZero();
        var result = solution.MinReorder(4, connections);

        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests MinReorder with single edge.
    /// </summary>
    [Fact]
    public void MinReorder_WithSingleEdge_ReturnsCorrectChanges()
    {
        var connections = new int[][]
        {
            [0, 1]
        };

        var solution = new MinReorderToTheCityZero();
        var result = solution.MinReorder(2, connections);

        Assert.Equal(1, result);
    }

    #endregion

    #region CanVisitAllRooms Tests

    /// <summary>
    /// Tests CanVisitAllRooms with accessible rooms.
    /// https://leetcode.com/problems/keys-and-rooms/description/
    /// Pattern: Graph DFS - check if all nodes are reachable from start
    /// </summary>
    [Fact]
    public void CanVisitAllRooms_WithAccessibleRooms_ReturnsTrue()
    {
        var rooms = new List<IList<int>>
        {
            new List<int> { 1 },
            new List<int> { 2 },
            new List<int> { 3 },
            new List<int> { }
        };

        var solution = new KeysAndRooms();
        var result = solution.CanVisitAllRooms(rooms);

        Assert.True(result);
    }

    /// <summary>
    /// Tests CanVisitAllRooms with inaccessible rooms.
    /// </summary>
    [Fact]
    public void CanVisitAllRooms_WithInaccessibleRooms_ReturnsFalse()
    {
        var rooms = new List<IList<int>>
        {
            new List<int> { 1, 3 },
            new List<int> { 3, 0, 1 },
            new List<int> { 2 },
            new List<int> { 0 }
        };

        var solution = new KeysAndRooms();
        var result = solution.CanVisitAllRooms(rooms);

        Assert.False(result);
    }

    /// <summary>
    /// Tests CanVisitAllRooms with single room.
    /// </summary>
    [Fact]
    public void CanVisitAllRooms_WithSingleRoom_ReturnsTrue()
    {
        var rooms = new List<IList<int>>
        {
            new List<int> { }
        };

        var solution = new KeysAndRooms();
        var result = solution.CanVisitAllRooms(rooms);

        Assert.True(result);
    }

    /// <summary>
    /// Tests CanVisitAllRooms with complex key distribution.
    /// </summary>
    [Fact]
    public void CanVisitAllRooms_WithComplexKeyDistribution_ReturnsTrue()
    {
        var rooms = new List<IList<int>>
        {
            new List<int> { 1, 2 },
            new List<int> { 3 },
            new List<int> { },
            new List<int> { 4 },
            new List<int> { }
        };

        var solution = new KeysAndRooms();
        var result = solution.CanVisitAllRooms(rooms);

        Assert.True(result);
    }

    #endregion

    #region FindSmallestSetOfVertices Tests

    /// <summary>
    /// Tests FindSmallestSetOfVertices with basic directed graph.
    /// https://leetcode.com/problems/minimum-number-of-vertices-to-reach-all-nodes/description/
    /// Pattern: Find nodes with no incoming edges (indegree 0)
    /// </summary>
    [Fact]
    public void FindSmallestSetOfVertices_WithBasicGraph_ReturnsCorrectVertices()
    {
        var edges = new List<IList<int>>
        {
            new List<int> { 0, 1 },
            new List<int> { 0, 2 },
            new List<int> { 2, 5 },
            new List<int> { 3, 4 },
            new List<int> { 4, 2 }
        };

        var solution = new MiniumNumberOfVerticesToReachAllNodes();
        var result = solution.FindSmallestSetOfVertices(6, edges);

        Assert.Equal(2, result.Count);
        Assert.Contains(0, result);
        Assert.Contains(3, result);
    }

    /// <summary>
    /// Tests FindSmallestSetOfVertices using InDegree approach.
    /// </summary>
    [Fact]
    public void FindSmallestSetOfVerticesWithInDegreeApproach_WithBasicGraph_ReturnsCorrectVertices()
    {
        var edges = new List<IList<int>>
        {
            new List<int> { 0, 1 },
            new List<int> { 2, 1 },
            new List<int> { 3, 1 },
            new List<int> { 1, 4 },
            new List<int> { 2, 4 }
        };

        var result = MiniumNumberOfVerticesToReachAllNodes.FindSmallestSetOfVerticesWithInDegreeApproach(5, edges);

        Assert.Equal(3, result.Count);
        Assert.Contains(0, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    /// <summary>
    /// Tests FindSmallestSetOfVertices with linear chain.
    /// </summary>
    [Fact]
    public void FindSmallestSetOfVertices_WithLinearChain_ReturnsSingleVertex()
    {
        var edges = new List<IList<int>>
        {
            new List<int> { 0, 1 },
            new List<int> { 1, 2 },
            new List<int> { 2, 3 }
        };

        var result = MiniumNumberOfVerticesToReachAllNodes.FindSmallestSetOfVerticesWithInDegreeApproach(4, edges);

        Assert.Single(result);
        Assert.Contains(0, result);
    }

    #endregion

    #region ValidPath Tests

    /// <summary>
    /// Tests ValidPath with path exists.
    /// https://leetcode.com/problems/find-if-path-exists-in-graph/
    /// Pattern: Graph DFS - check connectivity between two nodes
    /// </summary>
    [Fact]
    public void ValidPath_WithPathExists_ReturnsTrue()
    {
        var edges = new int[][]
        {
            [0, 1],
            [1, 2],
            [2, 0]
        };

        var solution = new FindExistedPathInGraph();
        var result = solution.ValidPath(3, edges, 0, 2);

        Assert.True(result);
    }

    /// <summary>
    /// Tests ValidPath with no path.
    /// </summary>
    [Fact]
    public void ValidPath_WithNoPath_ReturnsFalse()
    {
        var edges = new int[][]
        {
            [0, 1],
            [0, 2],
            [3, 5],
            [5, 4],
            [4, 3]
        };

        var solution = new FindExistedPathInGraph();
        var result = solution.ValidPath(6, edges, 0, 5);

        Assert.False(result);
    }

    /// <summary>
    /// Tests ValidPath with source equals destination.
    /// </summary>
    [Fact]
    public void ValidPath_WithSourceEqualsDestination_ReturnsTrue()
    {
        var edges = new int[][]
        {
            [0, 1],
            [1, 2]
        };

        var solution = new FindExistedPathInGraph();
        var result = solution.ValidPath(3, edges, 0, 0);

        Assert.True(result);
    }

    /// <summary>
    /// Tests ValidPath with empty graph.
    /// </summary>
    [Fact]
    public void ValidPath_WithEmptyGraph_ReturnsTrue()
    {
        var edges = Array.Empty<int[]>();

        var solution = new FindExistedPathInGraph();
        var result = solution.ValidPath(1, edges, 0, 0);

        Assert.True(result);
    }

    #endregion
}
