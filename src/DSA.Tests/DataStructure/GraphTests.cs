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
}
