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

// https://leetcode.com/problems/01-matrix/description/
public class Matrix01
{
    private static bool IsValid(int[][] mat, int row, int col, int m, int n) => row >= 0 && row < m && col >= 0 && col < n && mat[row][col] == 1;
    private readonly List<List<int>> directions = [[-1, 0], [1, 0], [0, 1], [0, -1]];
    public int[][] UpdateMatrix(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        Queue<List<int>> queue = [];
        HashSet<(int, int)> seen = [];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1) continue;
                queue.Enqueue([i, j]);
                seen.Add((i, j));
            }
        }
        var count = 0;

        while (queue.Count != 0)
        {
            var levelSize = queue.Count;
            count++;

            for (int i = 0; i < levelSize; i++)
            {
                var curr = queue.Dequeue();
                foreach (var item in directions)
                {
                    var row = curr[0] + item[0];
                    var col = curr[1] + item[1];
                    if (!IsValid(mat, row, col, m, n) || seen.Contains((row, col))) continue;

                    mat[row][col] = count;
                    seen.Add((row, col));
                    queue.Enqueue([row, col]);
                }
            }
        }
        return mat;
    }
}

// https://leetcode.com/problems/shortest-path-in-a-grid-with-obstacles-elimination/description/
public class ShortestPathInAGridWithObstaclesElimination
{
    private readonly List<List<int>> directions = [[-1, 0], [1, 0], [0, -1], [0, 1]];
    private static bool IsValid(int row, int col, int m, int n) => row >= 0 && row < m && col >= 0 && col < n;
    public int ShortestPath(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        HashSet<(int row, int col, int remains)> seen = [];
        Queue<(int row, int col, int remains, int count)> queue = [];
        var step = 0;
        queue.Enqueue((0, 0, k, step));
        seen.Add((0, 0, k));

        while (queue.Count != 0)
        {
            var levelSize = queue.Count;
            step++;
            for (int i = 0; i < levelSize; i++)
            {
                var curr = queue.Dequeue();
                var (row, col, remains, count) = curr;

                if (row == m - 1 && col == n - 1) return count;

                foreach (var direction in directions)
                {
                    var nextRow = row + direction[0];
                    var nextCol = col + direction[1];
                    if (!IsValid(nextRow, nextCol, m, n)) continue;
                    var nextRemains = grid[nextRow][nextCol] == 0 ? remains : remains - 1;

                    if (nextRemains < 0) continue;
                    if (seen.Contains((nextRow, nextCol, nextRemains))) continue;
                    seen.Add((nextRow, nextCol, nextRemains));
                    queue.Enqueue((nextRow, nextCol, nextRemains, step));
                }
            }
        }

        return -1;
    }
}

// https://leetcode.com/problems/shortest-path-with-alternating-colors/
/*
 * ========================================================================================
 * PROBLEM: Shortest Path with Alternating Colors (SIMPLIFIED EXPLANATION)
 * ========================================================================================
 * 
 * IMAGINE: You're traveling between cities (nodes) using roads (edges).
 * Each road is painted either RED or BLUE.
 * 
 * THE RULE: You CANNOT take two roads of the same color in a row!
 *           If you just drove on a RED road, next you MUST use a BLUE road (and vice versa)
 * 
 * THE TASK: Starting from city 0, what's the shortest path to reach every other city?
 *           If you can't reach a city (while following the alternating rule), return -1.
 * 
 * ========================================================================================
 * SIMPLE EXAMPLE: n = 5 nodes
 * ========================================================================================
 * 
 * redEdges = [[0,1], [1,2], [2,3]]    blueEdges = [[1,3], [3,4]]
 * 
 *           0
 *           |  RED
 *           v
 *           1 --------BLUE-------> 3
 *           |  RED                 |  BLUE
 *           v                      v
 *           2                      4
 *           |  RED
 *           v
 *           3
 * 
 * Let's trace paths from node 0:
 * 
 * To Node 0: distance = 0 (we start here)
 * 
 * To Node 1: distance = 1
 *   Path: 0 --RED--> 1 ✓
 * 
 * To Node 2: distance = 2
 *   Path: 0 --RED--> 1 --RED--> 2 ✗ INVALID! (two REDs in a row)
 *   We need: 0 --???--> ? --???--> 2
 *   NO VALID PATH (we need a BLUE edge from 1 to reach 2, but none exists)
 *   Actually, we CAN'T reach node 2 directly because after RED edge 0→1, 
 *   we need BLUE but 1→2 is RED.
 * 
 * To Node 3: distance = 2
 *   Path: 0 --RED--> 1 --BLUE--> 3 ✓ (alternating colors!)
 * 
 * To Node 4: distance = 3
 *   Path: 0 --RED--> 1 --BLUE--> 3 --BLUE--> 4 ✗ INVALID! (two BLUEs)
 *   Wait, we need to alternate!
 *   Actually from the graph above, after 0→1(RED)→3(BLUE), we need RED next
 *   But 3→4 is BLUE, not valid in this path
 *   Let me reconsider...
 * 
 * ========================================================================================
 * CLEARER EXAMPLE: n = 3
 * ========================================================================================
 * 
 * redEdges = [[0,1], [1,2]]    blueEdges = [[0,1]]
 * 
 *         RED
 *     0 ======> 1 ---RED---> 2
 *      \       /
 *       BLUE /
 *         \/
 * 
 * Both RED and BLUE edges from 0 to 1!
 * 
 * To Node 0: distance = 0 (start)
 * 
 * To Node 1: distance = 1
 *   Option A: 0 --RED--> 1 ✓
 *   Option B: 0 --BLUE--> 1 ✓
 *   Both work! Distance = 1
 * 
 * To Node 2: distance = 2
 *   We need to reach 2 from 1 using a RED edge.
 *   But what color did we use to reach 1?
 *   - If we used RED (0→1), next must be BLUE, but 1→2 is RED ✗
 *   - If we used BLUE (0→1), next must be RED, and 1→2 is RED ✓
 *   Path: 0 --BLUE--> 1 --RED--> 2
 *   Distance = 2
 * 
 * THIS IS WHY we track (node, color)!
 * Reaching node 1 via RED vs BLUE gives us different options for next steps!
 * 
 * ========================================================================================
 * ALGORITHM WALKTHROUGH:
 * ========================================================================================
 * 
 * 1. Build graph by color: 
 *    graph[RED] = {0: [1], 1: [2]}    // RED edges
 *    graph[BLUE] = {0: [1]}           // BLUE edges
 * 
 * 2. Start BFS from node 0 with BOTH colors:
 *    Queue: [(0, RED, 0), (0, BLUE, 0)]
 *           node=0, just-used-color=RED/BLUE, steps=0
 * 
 * 3. Process (0, RED, 0):
 *    - We're at node 0, last color was RED, so next must be BLUE
 *    - Look at graph[BLUE][0] = [1]
 *    - Add (1, BLUE, 1) to queue
 * 
 * 4. Process (0, BLUE, 0):
 *    - We're at node 0, last color was BLUE, so next must be RED
 *    - Look at graph[RED][0] = [1]
 *    - Add (1, RED, 1) to queue
 * 
 * 5. Process (1, BLUE, 1):
 *    - We're at node 1 via BLUE edge, so next must be RED
 *    - Look at graph[RED][1] = [2]
 *    - Add (2, RED, 2) to queue
 * 
 * 6. Process (1, RED, 1):
 *    - We're at node 1 via RED edge, so next must be BLUE
 *    - Look at graph[BLUE][1] = [] (no blue edges from 1)
 *    - Nothing to add
 * 
 * 7. Process (2, RED, 2):
 *    - We reached node 2! Distance = 2
 * 
 * Result: [0, 1, 2]
 * ========================================================================================
 */
public class ShortestAlternatingPathsSolution
{
    private const int RED = 0;
    private const int BLUE = 1;

    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        // Build adjacency list: graph[color][node] = list of neighbors via that color
        // Example: graph[RED][0] = [1, 2] means node 0 has RED edges to nodes 1 and 2
        var graph = new Dictionary<int, Dictionary<int, List<int>>>
        {
            [RED] = [],
            [BLUE] = []
        };

        foreach (var edge in redEdges)
        {
            if (!graph[RED].ContainsKey(edge[0])) graph[RED][edge[0]] = [];
            graph[RED][edge[0]].Add(edge[1]);
        }

        foreach (var edge in blueEdges)
        {
            if (!graph[BLUE].ContainsKey(edge[0])) graph[BLUE][edge[0]] = [];
            graph[BLUE][edge[0]].Add(edge[1]);
        }

        // Answer array: shortest distance to each node
        var ans = new int[n];
        Array.Fill(ans, int.MaxValue);

        // BFS queue: (current node, color of edge we just used to get here, steps taken)
        Queue<(int node, int color, int steps)> queue = new();

        // Track visited states: (node, color) to avoid cycles
        // We track both node AND color because reaching node X via RED vs BLUE opens different paths
        HashSet<(int, int)> seen = [];

        // Start from node 0 with BOTH colors (we can begin with either red or blue edge)
        queue.Enqueue((0, RED, 0));
        queue.Enqueue((0, BLUE, 0));
        seen.Add((0, RED));
        seen.Add((0, BLUE));

        while (queue.Count > 0)
        {
            var (node, color, steps) = queue.Dequeue();

            // Update shortest distance to this node
            ans[node] = Math.Min(ans[node], steps);

            // Get neighbors reachable via current color edges
            if (!graph[color].ContainsKey(node)) continue;

            foreach (var neighbor in graph[color][node])
            {
                // MUST alternate colors: if we just used RED, next must be BLUE (and vice versa)
                var nextColor = 1 - color;

                if (seen.Contains((neighbor, nextColor))) continue;

                seen.Add((neighbor, nextColor));
                queue.Enqueue((neighbor, nextColor, steps + 1));
            }
        }

        // Convert unreachable nodes (still int.MaxValue) to -1
        for (int i = 0; i < n; i++)
        {
            if (ans[i] == int.MaxValue) ans[i] = -1;
        }

        return ans;
    }
}