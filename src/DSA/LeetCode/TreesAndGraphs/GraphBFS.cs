namespace DSA.LeetCode.TreesAndGraphs;

// https://leetcode.com/problems/shortest-path-in-binary-matrix/description/
public class ShortestPathBinaryMatrixSolution
{
    private static bool IsValid(int[][] grid, int row, int col, int m, int n) => row >= 0 && row < m && col >= 0 && col < n && grid[row][col] == 0;
    private readonly int[][] directions = [[-1, -1], [-1, 0], [-1, 1], [0, 1], [1, 1], [1, 0], [1, -1], [0, -1]];
    private static string ConvertToHash(int row, int col) => $"{row},{col}";

    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // Check if start or end is blocked
        if (grid[0][0] == 1 || grid[m - 1][n - 1] == 1) return -1;

        Queue<List<int>> queue = [];
        HashSet<string> seen = [];

        queue.Enqueue([0, 0]);
        seen.Add(ConvertToHash(0, 0));
        int distance = 1; // Start at 1 because the starting cell counts

        while (queue.Count != 0)
        {
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                var curr = queue.Dequeue();
                var row = curr[0];
                var col = curr[1];

                // Check if we reached the destination
                if (row == m - 1 && col == n - 1) return distance;

                foreach (var direction in directions)
                {
                    var neighborRow = row + direction[0];
                    var neighborCol = col + direction[1];

                    if (!IsValid(grid, neighborRow, neighborCol, m, n) ||
                        seen.Contains(ConvertToHash(neighborRow, neighborCol))) continue;

                    seen.Add(ConvertToHash(neighborRow, neighborCol));
                    queue.Enqueue([neighborRow, neighborCol]);
                }
            }
            distance++;
        }

        return -1;
    }
}

// https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/
public class AllNodesDistanceKInBinaryTree
{
    private readonly Dictionary<TreeNode, TreeNode> parents = [];
    // Node => its parent
    private readonly HashSet<TreeNode> seen = [];
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        DFS(root, null!);
        Queue<TreeNode> queue = [];
        queue.Enqueue(target);
        seen.Add(target);

        while (queue.Count != 0 && k > 0)
        {
            var levelSize = queue.Count;
            for (int i = 0; i < levelSize; i++)
            {
                var curr = queue.Dequeue();

                TreeNode[] neighbors = [curr.Left!, curr.Right!, parents.GetValueOrDefault(curr)!];

                foreach (var neighbor in neighbors.Where(n => n != null))
                {
                    if (seen.Contains(neighbor)) continue;
                    queue.Enqueue(neighbor);
                    seen.Add(neighbor);
                }
            }
            k--;
        }

        return [.. queue.Select(node => node.Val)];
    }

    private void DFS(TreeNode? root, TreeNode? parent)
    {
        if (root == null) return;
        if (parent != null) parents.Add(root, parent);
        DFS(root.Left, root);
        DFS(root.Right, root);
    }
}