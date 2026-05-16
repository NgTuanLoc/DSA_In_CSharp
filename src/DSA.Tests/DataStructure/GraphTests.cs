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
}
