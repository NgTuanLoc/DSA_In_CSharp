using DSA.DataStructure;

namespace DSA.Tests.DataStructure;

public class GraphTests
{
    [Fact]
    public void GetVertices_OnNewGraph_ReturnsEmpty()
    {
        var graph = new Graph();

        Assert.Empty(graph.GetVertices());
    }

    [Fact]
    public void AddVertex_NewKey_AddsVertex()
    {
        var graph = new Graph();

        graph.AddVertex("A");

        Assert.True(graph.HasVertex("A"));
        Assert.Single(graph.GetVertices());
    }

    [Fact]
    public void AddVertex_DuplicateKey_DoesNothing()
    {
        var graph = new Graph();
        graph.AddVertex("A");

        graph.AddVertex("A");

        Assert.Single(graph.GetVertices());
    }

    [Fact]
    public void HasVertex_UnknownKey_ReturnsFalse()
    {
        var graph = new Graph();

        Assert.False(graph.HasVertex("ghost"));
    }

    [Fact]
    public void AddEdge_BetweenExistingVertices_LinksBothDirections()
    {
        var graph = new Graph();
        graph.AddVertex("A");
        graph.AddVertex("B");

        graph.AddEdge("A", "B");

        Assert.True(graph.HasEdge("A", "B"));
        Assert.True(graph.HasEdge("B", "A"));
    }

    [Fact]
    public void AddEdge_AutoCreatesMissingVertices()
    {
        var graph = new Graph();

        graph.AddEdge("X", "Y");

        Assert.True(graph.HasVertex("X"));
        Assert.True(graph.HasVertex("Y"));
        Assert.True(graph.HasEdge("X", "Y"));
    }

    [Fact]
    public void AddEdge_DuplicateEdge_DoesNotDuplicateNeighbor()
    {
        var graph = new Graph();
        graph.AddEdge("A", "B");

        graph.AddEdge("A", "B");

        Assert.Single(graph.GetNeighbors("A"));
        Assert.Single(graph.GetNeighbors("B"));
    }

    [Fact]
    public void HasEdge_NonExistentVertices_ReturnsFalse()
    {
        var graph = new Graph();
        graph.AddVertex("A");

        Assert.False(graph.HasEdge("A", "Z"));
        Assert.False(graph.HasEdge("Z", "A"));
    }

    [Fact]
    public void GetNeighbors_UnknownVertex_ReturnsEmpty()
    {
        var graph = new Graph();

        Assert.Empty(graph.GetNeighbors("ghost"));
    }

    [Fact]
    public void GetNeighbors_KnownVertex_ReturnsLinkedVertices()
    {
        var graph = new Graph();
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");

        var neighbors = graph.GetNeighbors("A");

        Assert.Equal(2, neighbors.Count);
        Assert.Contains("B", neighbors);
        Assert.Contains("C", neighbors);
    }

    [Fact]
    public void RemoveEdge_ExistingEdge_RemovesBothDirections()
    {
        var graph = new Graph();
        graph.AddEdge("A", "B");

        graph.RemoveEdge("A", "B");

        Assert.False(graph.HasEdge("A", "B"));
        Assert.False(graph.HasEdge("B", "A"));
        Assert.True(graph.HasVertex("A"));
        Assert.True(graph.HasVertex("B"));
    }

    [Fact]
    public void RemoveEdge_NonExistentEdge_IsNoOp()
    {
        var graph = new Graph();
        graph.AddVertex("A");
        graph.AddVertex("B");

        graph.RemoveEdge("A", "B");

        Assert.True(graph.HasVertex("A"));
        Assert.True(graph.HasVertex("B"));
    }

    [Fact]
    public void RemoveVertex_RemovesVertexAndAllItsEdges()
    {
        var graph = new Graph();
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "C");

        graph.RemoveVertex("A");

        Assert.False(graph.HasVertex("A"));
        Assert.False(graph.HasEdge("B", "A"));
        Assert.False(graph.HasEdge("C", "A"));
        Assert.True(graph.HasEdge("B", "C"));
    }

    [Fact]
    public void RemoveVertex_Unknown_IsNoOp()
    {
        var graph = new Graph();
        graph.AddVertex("A");

        graph.RemoveVertex("ghost");

        Assert.True(graph.HasVertex("A"));
    }

    [Fact]
    public void Bfs_FromUnknownStart_ReturnsEmpty()
    {
        var graph = new Graph();

        Assert.Empty(graph.Bfs("ghost"));
    }

    [Fact]
    public void Bfs_SingleVertex_ReturnsThatVertex()
    {
        var graph = new Graph();
        graph.AddVertex("A");

        var result = graph.Bfs("A");

        Assert.Equal(new[] { "A" }, result);
    }

    [Fact]
    public void Bfs_VisitsAllReachableVerticesLevelByLevel()
    {
        var graph = new Graph();
        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "E");

        var result = graph.Bfs("A");

        Assert.Equal(5, result.Count);
        Assert.Equal("A", result[0]);
        Assert.Contains("B", result.GetRange(1, 2));
        Assert.Contains("C", result.GetRange(1, 2));
        Assert.Contains("D", result.GetRange(3, 2));
        Assert.Contains("E", result.GetRange(3, 2));
    }

    [Fact]
    public void Bfs_DisconnectedComponent_NotVisited()
    {
        var graph = new Graph();
        graph.AddEdge("A", "B");
        graph.AddVertex("X");

        var result = graph.Bfs("A");

        Assert.Equal(2, result.Count);
        Assert.DoesNotContain("X", result);
    }

    [Fact]
    public void Bfs_CycleGraph_VisitsEachVertexOnce()
    {
        var graph = new Graph();
        graph.AddEdge("A", "B");
        graph.AddEdge("B", "C");
        graph.AddEdge("C", "A");

        var result = graph.Bfs("A");

        Assert.Equal(3, result.Count);
        Assert.Contains("A", result);
        Assert.Contains("B", result);
        Assert.Contains("C", result);
    }
}
