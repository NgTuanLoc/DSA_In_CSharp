# DSA.Tests

Comprehensive unit test suite for the DSA (Data Structures and Algorithms) project.

## Overview

This test project provides extensive test coverage for LeetCode solutions and algorithm implementations, organized by pattern and problem type.

## Test Structure

### LeetCode Tests

#### ArrayAndString Tests
Located in `LeetCode/ArrayAndString/`:

- **TwoPointersTests.cs** - 50+ tests covering two-pointer pattern implementations
  - Palindrome checking
  - Target sum finding in sorted arrays
  - Array merging
  - Subsequence validation
  - String/array reversal
  - Character-specific operations
  
- **SlidingWindowTests.cs** - 40+ tests covering sliding window pattern implementations
  - Variable-size windows (expanding/contracting based on conditions)
  - Fixed-size windows
  - Subarray counting problems
  - Maximum/minimum length problems
  - Product and sum constraints
  
- **PrefixSumTests.cs** - 41 tests covering prefix sum pattern implementations
  - Range query problems
  - Subarray sum calculations
  - Split array problems
  - Running sum computations
  - Altitude and pivot index problems

#### LinkedList Tests
Located in `LeetCode/LinkedList/`:

- **FastAndSlowPointersTests.cs** - 60+ tests covering fast/slow pointer pattern
  - Cycle detection (Floyd's algorithm)
  - Finding middle nodes
  - K-th from end problems
  - Duplicate removal
  - Node swapping operations
  - Middle node deletion
  
- **ReversingLinkedListTests.cs** - 40+ tests covering linked list reversal
  - Complete list reversal
  - Range-based reversal
  - Pair swapping
  - Palindrome detection
  - Iterative reversal techniques

## Test Patterns

### Test Naming Convention
Each test follows the pattern: `MethodName_WithCondition_ExpectedBehavior`

Example: `CheckPalindrome_WithSimplePalindrome_ReturnsTrue`

### Test Documentation
Every test includes:
- **XML Summary**: Clear description of what is being tested
- **Pattern explanation**: Algorithm/technique being validated
- **LeetCode link**: Reference to original problem (when applicable)
- **Edge cases**: Specific scenarios like empty inputs, single elements, etc.

### Test Structure
```csharp
[Fact]
public void MethodName_WithCondition_ExpectedBehavior()
{
    // Arrange - Set up test data and expected results
    
    // Act - Execute the method under test
    
    // Assert - Verify the actual result matches expected
}
```

## Running Tests

### Run all tests
```bash
dotnet test
```

### Run specific test class
```bash
dotnet test --filter "FullyQualifiedName~TwoPointersTests"
```

### Run tests with detailed output
```bash
dotnet test --logger "console;verbosity=detailed"
```

### Run tests with coverage (if configured)
```bash
dotnet test --collect:"XPlat Code Coverage"
```

## Test Coverage Summary

- **Total Tests**: 131
- **ArrayAndString Tests**: 71
  - TwoPointers: 30 tests
  - SlidingWindow: 27 tests
  - PrefixSum: 14 tests
- **LinkedList Tests**: 60
  - FastAndSlowPointers: 33 tests
  - ReversingLinkedList: 27 tests

## Key Testing Principles

1. **Comprehensive Coverage**: Each public method has multiple test cases covering:
   - Happy path scenarios
   - Edge cases (empty, single element, boundary values)
   - Error conditions
   - Different input combinations

2. **Clear Documentation**: Every test is well-documented with:
   - Purpose and intent
   - Pattern explanation
   - Expected behavior
   - Related LeetCode problems

3. **Isolation**: Each test is independent and can run in any order

4. **Fast Execution**: All tests complete in under 1 second

## Future Additions

Additional test suites planned for:
- Hashing patterns
- Trees and Graphs
- Binary Search Trees
- Heap implementations
- Backtracking algorithms
- Dynamic Programming solutions

## Contributing

When adding new tests:
1. Follow the established naming conventions
2. Include comprehensive XML documentation
3. Cover edge cases and boundary conditions
4. Reference LeetCode problems when applicable
5. Ensure tests are independent and isolated
