using System.Linq;

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
