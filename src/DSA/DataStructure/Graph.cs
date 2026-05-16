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
}
