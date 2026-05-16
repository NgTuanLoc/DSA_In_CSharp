namespace DSA.DataStructure;

public class Graph
{
    private readonly Dictionary<string, List<string>> _adjacency = new();

    public void AddVertex(string vertex)
    {
        if (!_adjacency.ContainsKey(vertex))
            _adjacency[vertex] = new List<string>();
    }

    public bool HasVertex(string vertex) => _adjacency.ContainsKey(vertex);

    public IReadOnlyCollection<string> GetVertices() => _adjacency.Keys;

    public void AddEdge(string a, string b)
    {
        AddVertex(a);
        AddVertex(b);

        if (!_adjacency[a].Contains(b))
            _adjacency[a].Add(b);
        if (!_adjacency[b].Contains(a))
            _adjacency[b].Add(a);
    }

    public bool HasEdge(string a, string b)
    {
        return _adjacency.TryGetValue(a, out var neighbors) && neighbors.Contains(b);
    }

    public IReadOnlyList<string> GetNeighbors(string vertex)
    {
        return _adjacency.TryGetValue(vertex, out var neighbors)
            ? neighbors
            : Array.Empty<string>();
    }
}
