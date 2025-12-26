namespace DSA.LeetCode.TreesAndGraphs;

// leetcode.com/problems/number-of-provinces/
public class GraphDfsFindCircleNum
{
    private readonly Dictionary<int, List<int>> graph = [];
    private readonly HashSet<int> seen = [];
    public int FindCircleNum(int[][] isConnected)
    {
        // builder the graph
        int n = isConnected.Length;

        for (int i = 0; i < n; i++)
        {
            if (!graph.ContainsKey(i))
            {
                graph.Add(i, []);
            }

            for (int j = i + 1; j < n; j++)
            {
                if (!graph.ContainsKey(j))
                {
                    graph.Add(j, []);
                }
                if (isConnected[i][j] == 1)
                {
                    graph[i].Add(j);
                    graph[j].Add(i);
                }
            }

        }
        int result = 0;

        for (int i = 0; i < n; i++)
        {
            if (seen.Add(i))
            {
                result++;
                Dfs_Iterative(i);
            }
        }

        return result;
    }

    private void Dfs(int node)
    {
        foreach (var neighbor in graph[node].Where(seen.Add))
        {
            Dfs(neighbor);
        }
    }

    private void Dfs_Iterative(int start)
    {
        var stack = new Stack<int>();
        stack.Push(start);

        while (stack.Count != 0)
        {
            var node = stack.Pop();

            foreach (var neighbor in graph[node].Where(seen.Add))
            {
                stack.Push(neighbor);
            }
        }
    }
}

// https://leetcode.com/problems/number-of-islands/description/
public class GraphDfsNumIslands
{
    private HashSet<(int, int)> seen = [];
    private readonly List<List<int>> directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];
    private int m = 0;
    private int n = 0;
    private char[][] grid = [];

    public int NumIslands(char[][] grid)
    {
        var result = 0;
        this.grid = grid;
        m = grid.Length;
        n = grid[0].Length;
        seen = [];

        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (grid[row][col] == '1' && seen.Add((row, col)))
                {
                    result++;
                    Dfs_Iterative(row, col);
                }
            }
        }

        return result;
    }

    private void Dfs(int row, int col)
    {
        foreach (var direction in directions)
        {
            int nextRow = row + direction[0];
            int nextCol = col + direction[1];

            if (IsValid(nextRow, nextCol) && seen.Add((nextRow, nextCol)))
            {
                Dfs(nextRow, nextCol);
            }
        }
    }

    private void Dfs_Iterative(int row, int col)
    {
        var stack = new Stack<(int, int)>();
        stack.Push((row, col));

        while (stack.Count != 0)
        {
            var (currentRow, currentCol) = stack.Pop();

            foreach (var direction in directions)
            {
                int nextRow = currentRow + direction[0];
                int nextCol = currentCol + direction[1];

                if (IsValid(nextRow, nextCol) && seen.Add((nextRow, nextCol)))
                {
                    stack.Push((nextRow, nextCol));
                }
            }
        }
    }

    private bool IsValid(int row, int col)
    {
        return row >= 0 && row < m && col >= 0 && col < n && grid[row][col] == '1';
    }
}

// https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero/description/
public class MinReorderToTheCityZero
{
    private readonly Dictionary<int, List<int>> graph = [];
    private readonly Dictionary<int, bool> seen = [];
    private readonly HashSet<string> roads = [];
    private int result = 0;

    public static string ConvertToHash(int row, int col)
    {
        return $"{row},{col}";
    }
    public int MinReorder(int n, int[][] connections)
    {
        for (int i = 0; i < n; i++)
        {
            graph.Add(i, []);
        }

        foreach (var item in connections)
        {
            graph[item[0]].Add(item[1]);
            graph[item[1]].Add(item[0]);
            roads.Add(ConvertToHash(item[0], item[1]));
        }

        seen.Add(0, true);
        Dfs_Iterative(0);

        return result;
    }

    public void DFS(int node)
    {
        foreach (var neighbor in graph[node])
        {
            if (seen.ContainsKey(neighbor)) continue;
            if (roads.Contains(ConvertToHash(node, neighbor))) result++;
            seen.Add(neighbor, true);
            DFS(neighbor);
        }
    }

    public void Dfs_Iterative(int node)
    {
        Stack<int> stack = [];
        stack.Push(node);

        while (stack.Count != 0)
        {
            var curr = stack.Pop();

            foreach (var neighbor in graph[curr])
            {
                if (seen.ContainsKey(neighbor)) continue;
                if (roads.Contains(ConvertToHash(curr, neighbor))) result++;
                seen.Add(neighbor, true);
                stack.Push(neighbor);
            }
        }
    }
}

// https://leetcode.com/problems/keys-and-rooms/description/
public class KeysAndRooms
{
    private readonly HashSet<int> seen = [];
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        seen.Add(0);
        Dfs_Iterative(0, rooms);
        return rooms.Count == seen.Count;
    }

    public void DFS(int node, IList<IList<int>> rooms)
    {
        foreach (var neighbor in rooms[node])
        {
            if (seen.Contains(neighbor)) continue;
            seen.Add(neighbor);
            DFS(neighbor, rooms);
        }
    }

    public void Dfs_Iterative(int node, IList<IList<int>> rooms)
    {
        Stack<int> stack = [];
        stack.Push(node);

        while (stack.Count != 0)
        {
            var curr = stack.Pop();
            foreach (var neighbor in rooms[curr])
            {
                if (seen.Contains(neighbor)) continue;
                seen.Add(neighbor);
                stack.Push(neighbor);
            }
        }
    }
}

// https://leetcode.com/problems/minimum-number-of-vertices-to-reach-all-nodes/description/
public class MiniumNumberOfVerticesToReachAllNodes
{
    private readonly HashSet<int> result = [];
    private readonly HashSet<int> neighbors = [];
    private readonly Dictionary<int, List<int>> graph = [];
    private readonly HashSet<int> seen = [];
    private readonly HashSet<string> roads = [];

    public static string ConvertToHash(int start, int end) => $"{start},{end}";
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        for (int i = 0; i < n; i++)
        {
            graph.Add(i, []);
        }

        foreach (var item in edges)
        {
            graph[item[0]].Add(item[1]);
            graph[item[1]].Add(item[0]);
            roads.Add(ConvertToHash(item[0], item[1]));
        }

        for (int i = 0; i < n; i++)
        {
            if (seen.Contains(i)) continue;
            Dfs_Iterative(i);
        }

        foreach (var neighbor in neighbors)
        {
            result.Remove(neighbor);
        }

        return [.. result];
    }

    public void DFS(int node)
    {
        foreach (var neighbor in graph[node])
        {
            if (roads.Contains(ConvertToHash(node, neighbor)))
            {
                result.Add(node);
                neighbors.Add(neighbor);
            }
            if (seen.Contains(neighbor)) continue;
            seen.Add(neighbor);
            DFS(neighbor);
        }
    }

    public void Dfs_Iterative(int node)
    {
        Stack<int> stack = [];
        stack.Push(node);

        while (stack.Count != 0)
        {
            var curr = stack.Pop();
            foreach (var neighbor in graph[curr])
            {
                if (roads.Contains(ConvertToHash(curr, neighbor)))
                {
                    result.Add(curr);
                    neighbors.Add(neighbor);
                }
                if (seen.Contains(neighbor)) continue;
                seen.Add(neighbor);
                stack.Push(neighbor);
            }
        }
    }

    public static IList<int> FindSmallestSetOfVerticesWithInDegreeApproach(int n, IList<IList<int>> edges)
    {
        HashSet<int> ans = [];

        for (int i = 0; i < n; i++)
        {
            ans.Add(i);
        }

        foreach (var edge in edges)
        {
            ans.Remove(edge[1]);
        }

        return [.. ans];
    }
}

// https://leetcode.com/problems/find-if-path-exists-in-graph/
public class FindExistedPathInGraph
{
    private readonly Dictionary<int, List<int>> graph = [];
    private readonly HashSet<int> seen = [];
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        for (int i = 0; i < n; i++)
        {
            graph.Add(i, []);
        }

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        seen.Add(source);
        Dfs_Iterative(source);

        return seen.Contains(destination);
    }

    private void DFS(int node)
    {
        foreach (var neighbor in graph[node])
        {
            if (seen.Contains(neighbor)) continue;
            seen.Add(neighbor);
            DFS(neighbor);
        }
    }

    private void Dfs_Iterative(int node)
    {
        Stack<int> stack = [];
        stack.Push(node);

        while (stack.Count != 0)
        {
            var curr = stack.Pop();
            foreach (var neighbor in graph[curr])
            {
                if (seen.Contains(neighbor)) continue;
                seen.Add(neighbor);
                stack.Push(neighbor);
            }
        }
    }
}

// https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/description/
class ConnectedComponentsInAUnDirectedGraph
{
    private readonly Dictionary<int, List<int>> graph = [];
    private readonly HashSet<int> seen = [];
    public int CountComponents(int n, int[][] edges)
    {
        var result = 0;

        for (int i = 0; i < n; i++)
        {
            graph.Add(i, []);
        }

        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        for (int i = 0; i < n; i++)
        {
            if (seen.Contains(i)) continue;
            result++;
            seen.Add(i);
            Dfs_Iterative(i);
        }

        return result;
    }

    private void DFS(int node)
    {
        foreach (var neighbor in graph[node])
        {
            if (seen.Contains(neighbor)) continue;
            seen.Add(neighbor);
            DFS(neighbor);
        }
    }

    private void Dfs_Iterative(int node)
    {
        Stack<int> stack = [];
        stack.Push(node);

        while (stack.Count != 0)
        {
            var curr = stack.Pop();
            foreach (var neighbor in graph[curr])
            {
                if (seen.Contains(neighbor)) continue;
                seen.Add(neighbor);
                stack.Push(neighbor);
            }
        }
    }
}

// https://leetcode.com/problems/max-area-of-island/description/
class MaxAreaOfIslandSolution
{
    private int result = 0;
    private readonly HashSet<string> seen = [];
    public int MaxAreaOfIsland(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                var key = ConvertToHash(row, col);

                if (seen.Contains(key)) continue;
                result = Math.Max(DFS(grid, row, col, m, n), result);
                seen.Add(key);
            }
        }

        return result;
    }

    private int DFS(int[][] grid, int row, int col, int m, int n)
    {
        var key = ConvertToHash(row, col);
        if (!IsValidArea(grid, row, col, m, n) || seen.Contains(key)) return 0;
        seen.Add(key);
        return DFS(grid, row + 1, col, m, n) + DFS(grid, row - 1, col, m, n) + DFS(grid, row, col + 1, m, n) + DFS(grid, row, col - 1, m, n) + 1;
    }

    private static bool IsValidArea(int[][] grid, int row, int col, int m, int n) => row >= 0 && row < m && col >= 0 && col < n && grid[row][col] == 1;

    private static string ConvertToHash(int row, int col) => $"{row},{col}";
}

// https://leetcode.com/problems/reachable-nodes-with-restrictions/description/
class ReachableNodesWithRestrictions
{
    private int result = 0;
    private readonly Dictionary<int, List<int>> graph = [];
    private readonly HashSet<int> seen = [];
    public int ReachableNodes(int n, int[][] edges, int[] restricted)
    {
        for (int i = 0; i < n; i++)
        {
            graph.Add(i, []);
        }

        foreach (var item in restricted)
        {
            seen.Add(item);
        }


        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }

        // Start DFS only from node 0 (the root)
        if (seen.Contains(0)) return result;

        seen.Add(0);
        result = 1; // Count node 0 itself
        DFS(0);

        return result;
    }

    private void DFS(int node)
    {
        foreach (var neighbor in graph[node])
        {
            if (seen.Contains(neighbor)) continue;

            seen.Add(neighbor);
            result++;
            DFS(neighbor);
        }
    }

    private void Dfs_Iterative(int node)
    {
        Stack<int> stack = [];
        stack.Push(node);

        while (stack.Count != 0)
        {
            var curr = stack.Pop();
            foreach (var neighbor in graph[curr])
            {
                if (seen.Contains(neighbor)) continue;
                result++;
                stack.Push(neighbor);
            }
        }
    }
}