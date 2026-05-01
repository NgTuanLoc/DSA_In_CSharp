# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**DSA_In_CSharp** is a comprehensive Data Structures and Algorithms learning project in C#. It implements core data structures (linked lists, trees, graphs, heaps) and solves LeetCode problems organized by algorithmic patterns (two-pointers, sliding window, prefix sum, fast/slow pointers, etc.). Built with .NET 10.0 and xUnit testing framework.

## Architecture

The project is organized into two main components:

### 1. Core Data Structures (`src/DSA/DataStructure/`)
- **BinarySearchTree.cs** - Self-balancing BST with BFS/DFS traversal methods
- **Graph.cs** - Adjacency list graph representation
- **LinkedList.cs** - Custom singly-linked list implementation
- **HashTable.cs** - Hash table with collision handling
- **Heap.cs** - Max heap implementation with insert/extract operations

### 2. Algorithm Implementations

#### Fundamental Algorithms (`src/DSA/Algorithm/`)
- **SortAlgorithm/** - Strategy pattern-based sorting (Bubble, Quick, Merge, Insertion, Selection, Radix)
- **SearchAlgorithm/** - Linear and binary search implementations

#### LeetCode Pattern-Based Solutions (`src/DSA/LeetCode/`)
Problems organized by algorithmic pattern, not by difficulty:
- **ArrayAndString/** - Two pointers, sliding window, prefix sum patterns
- **LinkedList/** - Fast/slow pointers, list reversal, cycle detection
- **TreesAndGraphs/** - DFS, BFS, binary search trees, graph traversal
- **StackAndQueue/** - Stack problems, monotonic stack/queue, queue applications
- **Hashing/** - Counting, checking existence, hash map techniques
- **Heap/** - Top-K problems, heap operations, priority queue patterns
- **DynamicProgramming/** - Memoization, tabulation, DP frameworks
- **Backtracking/** - Permutations, combinations, constraint satisfaction

## Common Commands

### Build & Test

```bash
# Build solution
dotnet build

# Build in Release mode (as CI does)
dotnet build --configuration Release

# Run all tests
dotnet test

# Run all tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"
```

### Run Specific Tests

```bash
# Run tests matching a pattern (e.g., all TwoPointers tests)
dotnet test --filter "FullyQualifiedName~TwoPointersTests"

# Run a single test class
dotnet test --filter "FullyQualifiedName~DSA.Tests.LeetCode.ArrayAndString.TwoPointersTests"

# Run tests matching a method name pattern
dotnet test --filter "Name~CheckPalindrome"
```

### Run Console Examples

Each LeetCode pattern has an `Example.cs` file with runnable demonstrations. Uncomment the corresponding line in `src/DSA/Program.cs` and run:

```bash
dotnet run --project src/DSA
```

Current active example is `TreesAndGraphsExample.Run_Graph_BFS()` (line 139 in Program.cs).

## Project Structure

```
src/DSA/
├── DataStructure/          # Core DS implementations
├── Algorithm/              # Fundamental algorithms
│   ├── SortAlgorithm/     # Sorting strategies
│   └── SearchAlgorithm/   # Search algorithms
├── DynamicProgramming/     # DP base classes
├── LeetCode/              # Pattern-organized problem solutions
│   ├── ArrayAndString/
│   ├── LinkedList/
│   ├── TreesAndGraphs/
│   ├── StackAndQueue/
│   ├── Hashing/
│   ├── Heap/
│   ├── DynamicProgramming/
│   ├── Backtracking/
│   └── Notes/             # Pattern documentation
└── Playground/            # Temporary experimentation

src/DSA.Tests/
├── LeetCode/              # Tests mirror LeetCode structure
│   ├── ArrayAndString/    # TwoPointersTests, SlidingWindowTests, etc.
│   ├── LinkedList/        # FastAndSlowPointersTests, etc.
│   ├── TreesAndGraphs/    # GraphBfsTests (42 tests covering all BFS problems)
│   ├── Heap/              # HeapSolutionTests (23 tests), TopKTests (41 tests)
│   └── [other patterns]   # StackAndQueue, Hashing, etc.
├── Algorithm/             # SearchAlgorithmTests (20 tests for Binary/Linear search)
└── DataStructure/         # LinkedListTests (22 tests)
```

## Key Patterns & Organization

### Adding New LeetCode Solutions

1. **Create solution class** in appropriate pattern folder: `src/DSA/LeetCode/{Pattern}/{ProblemName}.cs`
2. **Add tests** in parallel structure: `src/DSA.Tests/LeetCode/{Pattern}/{TestClass}.cs`
3. **Document with Example.cs** - Include example method in the pattern's `Example.cs`

### Adding Data Structure Tests

Tests follow xUnit conventions:
- **File naming**: `{DataStructure}Tests.cs`
- **Test naming**: `MethodName_WithCondition_ExpectedBehavior`
- **Structure**: Arrange-Act-Assert (AAA) pattern

### Running Example Code

The `Example.cs` files in each LeetCode pattern folder demonstrate:
- Problem setup and sample inputs
- Expected outputs
- Common edge cases
- Pattern-specific techniques

Toggle examples by commenting/uncommenting in `Program.cs`.

## Development Guidelines

### Test Coverage

- Minimum **80%** code coverage required (enforced by CI)
- **Current Coverage** (as of latest update):
  - Line Coverage: **69.46%** (2,751 lines covered / 3,960 total)
  - Branch Coverage: **71.89%** (1,177 branches covered / 1,637 total)
- Each public method should have multiple test cases covering:
  - Happy path scenarios
  - Edge cases (empty, single element, null)
  - Boundary conditions
  - Error paths and exceptional cases

### Test Expansion Strategy

When expanding test coverage, prioritize:
1. **Data Structure tests** - LinkedList, Heap, Graph, Tree operations (Push, Pop, Insert, Remove, etc.)
2. **Algorithm edge cases** - Empty arrays, single elements, boundary values, negative numbers
3. **LeetCode solutions** - Multiple input scenarios, invalid inputs, large datasets
4. **Branch coverage** - Conditional paths, loops with different counts, null checks

Recent expansions (March 2026):
- Added 113 new tests across 5 files
- Increased line coverage from 55.95% → 69.46% (+13.51%)
- Increased branch coverage from 57.36% → 71.89% (+14.53%)
- Full coverage achieved for: LinkedList, SearchAlgorithm, HeapSolution, TopK, GraphBFS

### Code Organization

- **Files**: Keep individual algorithm implementations focused (<400 lines typical)
- **Pattern folders**: Group related techniques together (e.g., all two-pointer solutions in ArrayAndString)
- **Helpers**: Utility methods in `SortHelper.cs` for common operations (printing, validation)

### Dependencies

- **Testing**: xUnit, coverlet for coverage
- **Framework**: .NET 10.0 with implicit usings and nullable reference types enabled
- **No external NuGet packages** for algorithm implementations (educational focus)

## CI/CD Pipeline

GitHub Actions (`.github/workflows/dotnet-ci.yml`):
- Runs on push/PR to master, main, or develop branches
- **Steps**: Build → Test → Coverage → PR comments with results
- **Coverage**: Generates markdown badge and thresholds (60% warning, 80% good)
- **Artifacts**: Test results and coverage reports uploaded

Local mirror:
```bash
# Simulate CI locally
dotnet build --configuration Release && dotnet test --collect:"XPlat Code Coverage"
```

## Common Workflows

### Adding a New Pattern Solution

1. Create solution file in `src/DSA/LeetCode/{Pattern}/`
2. Write test file in `src/DSA.Tests/LeetCode/{Pattern}/`
3. Add example/demo in pattern's `Example.cs`
4. Run tests: `dotnet test --filter "Name~YourTestClass"`
5. Verify coverage: `dotnet test --collect:"XPlat Code Coverage"`

### Debugging a Test Failure

```bash
# Run with detailed output
dotnet test --filter "Name~TestName" --logger "console;verbosity=detailed"

# Run with more context
dotnet test --filter "Name~TestName" --logger "detailed"
```

### Comparing Algorithm Performance

- Sorting algorithms use `SortDemo.cs` for comparative benchmarking
- Pattern solutions include comments on time/space complexity
- Heap visualization in `Program.cs` shows internal structure after operations

### Expanding Test Coverage

When using the unit-test-expand skill to increase coverage:

1. **Identify gaps** - Run `dotnet test --collect:"XPlat Code Coverage"` and review the coverage report
2. **Target high-impact areas** - Focus on classes with 0% coverage and complex algorithms
3. **Write comprehensive tests**:
   - **Constructors**: Initial state validation
   - **Core operations**: Add, Remove, Insert, Find, Update
   - **Edge cases**: Empty collections, single element, boundary values
   - **State transitions**: Operations that change internal structure
   - **Error conditions**: Invalid inputs, out-of-bounds access
4. **Follow naming convention**: `{Method}_{Condition}_{Expected}`
   - Example: `Insert_AtPosition0_InsertsAtHead()`
5. **Use AAA pattern**:
   ```csharp
   [Fact]
   public void Method_Scenario_ExpectedOutcome()
   {
       // Arrange
       var list = new DSA_In_CSharp.DataStructure.LinkedList();
       list.Push(10);
       
       // Act
       var length = list.GetLinkedListLength();
       
       // Assert
       Assert.Equal(1, length);
   }
   ```

### Coverage Goals

- **Short term**: Reach 80% line coverage (current: 69.46%)
- **Long term**: Reach 85%+ branch coverage for all critical paths
- **Maintenance**: Add tests for any new algorithm implementations before merging
