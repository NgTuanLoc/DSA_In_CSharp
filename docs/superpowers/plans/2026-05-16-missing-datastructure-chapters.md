# Missing DataStructure Chapters Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Fill in six missing data structures in `src/DSA/DataStructure/`: Stack, Queue, DoublyLinkedList, MinHeap, Trie, and Graph (the existing `Graph.cs` is an empty stub). Each new structure ships with full xUnit test coverage following strict per-method TDD.

**Architecture:** All new files live in `src/DSA/DataStructure/` under `namespace DSA.DataStructure;` (matching `BinarySearchTree.cs`, `HashTable.cs`, `Heap.cs`). Tests live in `src/DSA.Tests/DataStructure/` under `namespace DSA.Tests.DataStructure;` (mirroring `LinkedListTests.cs`). The existing `Node` class in `BinarySearchTree.cs` shares this namespace, so each new structure that needs a node type uses a prefixed name (`StackNode`, `QueueNode`, `DoublyNode`, `TrieNode`) to avoid collisions. Stack/Queue/DoublyLinkedList use `int` values to match the project's educational convention (see `LinkedList.cs`, `Heap.cs`).

**Tech Stack:** .NET 10, C# with nullable reference types enabled, xUnit, coverlet for coverage.

---

## Conventions every task must follow

- **Test naming:** `MethodName_Condition_ExpectedBehavior` (e.g. `Push_OnEmptyStack_SetsTop`). See `src/DSA.Tests/DataStructure/LinkedListTests.cs` for the established pattern.
- **Test structure:** Arrange-Act-Assert with blank lines between sections.
- **Run all tests after each task:** `dotnet test` from the repo root.
- **Run a single test class while developing:** `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.<ClassName>"`.
- **Conventional commit format:** `feat: <short imperative description>` (see `git log` for examples like `test: Expand unit test coverage...`).
- **Working directory** for every command in this plan is the repo root: `D:\Projects\Data Structure and Algorithm\DSA_In_CSharp`.

---

# Section 1 — Stack

**Files:**
- Create: `src/DSA/DataStructure/Stack.cs`
- Create: `src/DSA.Tests/DataStructure/StackTests.cs`

Custom linked-node Stack of `int` (the project's existing `Stack<char>` usage in `LeetCode/StackAndQueue/Stacks.cs` is from `System.Collections.Generic`; this new class is the educational counterpart).

### Task 1: Stack scaffold + IsEmpty + Count

**Files:**
- Create: `src/DSA/DataStructure/Stack.cs`
- Create: `src/DSA.Tests/DataStructure/StackTests.cs`

- [ ] **Step 1: Write the failing test**

Create `src/DSA.Tests/DataStructure/StackTests.cs` with:

```csharp
using DSA.DataStructure;

namespace DSA.Tests.DataStructure;

public class StackTests
{
    [Fact]
    public void IsEmpty_OnNewStack_ReturnsTrue()
    {
        var stack = new Stack();

        Assert.True(stack.IsEmpty);
    }

    [Fact]
    public void Count_OnNewStack_ReturnsZero()
    {
        var stack = new Stack();

        Assert.Equal(0, stack.Count);
    }
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.StackTests"`
Expected: FAIL with build error — `Stack` type does not exist in `DSA.DataStructure`.

- [ ] **Step 3: Write minimal implementation**

Create `src/DSA/DataStructure/Stack.cs`:

```csharp
namespace DSA.DataStructure;

public class StackNode(int value)
{
    public int Value { get; set; } = value;
    public StackNode? Next { get; set; } = null;
}

public class Stack
{
    private StackNode? _top;
    private int _count;

    public int Count => _count;
    public bool IsEmpty => _count == 0;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.StackTests"`
Expected: PASS (2 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Stack.cs src/DSA.Tests/DataStructure/StackTests.cs
git commit -m "feat: add Stack scaffold with IsEmpty and Count"
```

### Task 2: Stack.Push

**Files:**
- Modify: `src/DSA/DataStructure/Stack.cs`
- Modify: `src/DSA.Tests/DataStructure/StackTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `StackTests` class:

```csharp
[Fact]
public void Push_OnEmptyStack_IncrementsCountToOne()
{
    var stack = new Stack();

    stack.Push(10);

    Assert.Equal(1, stack.Count);
    Assert.False(stack.IsEmpty);
}

[Fact]
public void Push_MultipleValues_StoresInLIFOOrder()
{
    var stack = new Stack();

    stack.Push(1);
    stack.Push(2);
    stack.Push(3);

    Assert.Equal(3, stack.Count);
    Assert.Equal(3, stack.Peek());
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.StackTests"`
Expected: FAIL with build error — `Push` and `Peek` not defined.

- [ ] **Step 3: Implement Push and a temporary Peek**

In `Stack.cs`, add inside the `Stack` class:

```csharp
public void Push(int value)
{
    var node = new StackNode(value) { Next = _top };
    _top = node;
    _count++;
}

public int Peek()
{
    if (_top == null)
        throw new InvalidOperationException("Stack is empty");

    return _top.Value;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.StackTests"`
Expected: PASS (4 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Stack.cs src/DSA.Tests/DataStructure/StackTests.cs
git commit -m "feat: add Stack.Push with LIFO ordering"
```

### Task 3: Stack.Pop

**Files:**
- Modify: `src/DSA/DataStructure/Stack.cs`
- Modify: `src/DSA.Tests/DataStructure/StackTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `StackTests`:

```csharp
[Fact]
public void Pop_OnEmptyStack_ThrowsInvalidOperationException()
{
    var stack = new Stack();

    Assert.Throws<InvalidOperationException>(() => stack.Pop());
}

[Fact]
public void Pop_OnNonEmptyStack_ReturnsTopAndDecrementsCount()
{
    var stack = new Stack();
    stack.Push(10);
    stack.Push(20);

    var popped = stack.Pop();

    Assert.Equal(20, popped);
    Assert.Equal(1, stack.Count);
    Assert.Equal(10, stack.Peek());
}

[Fact]
public void Pop_UntilEmpty_LeavesStackEmpty()
{
    var stack = new Stack();
    stack.Push(1);
    stack.Push(2);

    stack.Pop();
    stack.Pop();

    Assert.True(stack.IsEmpty);
    Assert.Equal(0, stack.Count);
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.StackTests"`
Expected: FAIL with build error — `Pop` not defined.

- [ ] **Step 3: Implement Pop**

Append inside the `Stack` class in `Stack.cs`:

```csharp
public int Pop()
{
    if (_top == null)
        throw new InvalidOperationException("Stack is empty");

    var value = _top.Value;
    _top = _top.Next;
    _count--;
    return value;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.StackTests"`
Expected: PASS (7 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Stack.cs src/DSA.Tests/DataStructure/StackTests.cs
git commit -m "feat: add Stack.Pop with empty-stack guard"
```

### Task 4: Stack.Peek edge case + full suite check

**Files:**
- Modify: `src/DSA.Tests/DataStructure/StackTests.cs`

- [ ] **Step 1: Write the failing test**

Append inside `StackTests`:

```csharp
[Fact]
public void Peek_OnEmptyStack_ThrowsInvalidOperationException()
{
    var stack = new Stack();

    Assert.Throws<InvalidOperationException>(() => stack.Peek());
}

[Fact]
public void Peek_DoesNotModifyStack()
{
    var stack = new Stack();
    stack.Push(42);

    stack.Peek();

    Assert.Equal(1, stack.Count);
    Assert.Equal(42, stack.Peek());
}
```

- [ ] **Step 2: Run test to verify it passes (or fails meaningfully)**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.StackTests"`
Expected: PASS (9 tests) — the Peek implementation from Task 2 already throws on empty, so this confirms the contract.

- [ ] **Step 3: Run full test suite**

Run: `dotnet test`
Expected: PASS, no regressions from existing tests.

- [ ] **Step 4: Commit**

```bash
git add src/DSA.Tests/DataStructure/StackTests.cs
git commit -m "test: add Stack.Peek edge case coverage"
```

---

# Section 2 — Queue

**Files:**
- Create: `src/DSA/DataStructure/Queue.cs`
- Create: `src/DSA.Tests/DataStructure/QueueTests.cs`

Linked-node Queue of `int` with head and tail pointers (O(1) Enqueue and Dequeue).

### Task 5: Queue scaffold + IsEmpty + Count

**Files:**
- Create: `src/DSA/DataStructure/Queue.cs`
- Create: `src/DSA.Tests/DataStructure/QueueTests.cs`

- [ ] **Step 1: Write the failing test**

Create `src/DSA.Tests/DataStructure/QueueTests.cs`:

```csharp
using DSA.DataStructure;

namespace DSA.Tests.DataStructure;

public class QueueTests
{
    [Fact]
    public void IsEmpty_OnNewQueue_ReturnsTrue()
    {
        var queue = new Queue();

        Assert.True(queue.IsEmpty);
    }

    [Fact]
    public void Count_OnNewQueue_ReturnsZero()
    {
        var queue = new Queue();

        Assert.Equal(0, queue.Count);
    }
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.QueueTests"`
Expected: FAIL — `Queue` not defined.

- [ ] **Step 3: Write minimal implementation**

Create `src/DSA/DataStructure/Queue.cs`:

```csharp
namespace DSA.DataStructure;

public class QueueNode(int value)
{
    public int Value { get; set; } = value;
    public QueueNode? Next { get; set; } = null;
}

public class Queue
{
    private QueueNode? _head;
    private QueueNode? _tail;
    private int _count;

    public int Count => _count;
    public bool IsEmpty => _count == 0;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.QueueTests"`
Expected: PASS (2 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Queue.cs src/DSA.Tests/DataStructure/QueueTests.cs
git commit -m "feat: add Queue scaffold with IsEmpty and Count"
```

### Task 6: Queue.Enqueue + Peek

**Files:**
- Modify: `src/DSA/DataStructure/Queue.cs`
- Modify: `src/DSA.Tests/DataStructure/QueueTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `QueueTests`:

```csharp
[Fact]
public void Enqueue_OnEmptyQueue_SetsHeadAndTail()
{
    var queue = new Queue();

    queue.Enqueue(10);

    Assert.Equal(1, queue.Count);
    Assert.Equal(10, queue.Peek());
}

[Fact]
public void Enqueue_MultipleValues_PeeksFirstEnqueued()
{
    var queue = new Queue();

    queue.Enqueue(1);
    queue.Enqueue(2);
    queue.Enqueue(3);

    Assert.Equal(3, queue.Count);
    Assert.Equal(1, queue.Peek());
}

[Fact]
public void Peek_OnEmptyQueue_ThrowsInvalidOperationException()
{
    var queue = new Queue();

    Assert.Throws<InvalidOperationException>(() => queue.Peek());
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.QueueTests"`
Expected: FAIL — `Enqueue` and `Peek` not defined.

- [ ] **Step 3: Implement Enqueue and Peek**

Append inside the `Queue` class in `Queue.cs`:

```csharp
public void Enqueue(int value)
{
    var node = new QueueNode(value);
    if (_tail == null)
    {
        _head = node;
        _tail = node;
    }
    else
    {
        _tail.Next = node;
        _tail = node;
    }
    _count++;
}

public int Peek()
{
    if (_head == null)
        throw new InvalidOperationException("Queue is empty");

    return _head.Value;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.QueueTests"`
Expected: PASS (5 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Queue.cs src/DSA.Tests/DataStructure/QueueTests.cs
git commit -m "feat: add Queue.Enqueue and Peek with FIFO ordering"
```

### Task 7: Queue.Dequeue

**Files:**
- Modify: `src/DSA/DataStructure/Queue.cs`
- Modify: `src/DSA.Tests/DataStructure/QueueTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `QueueTests`:

```csharp
[Fact]
public void Dequeue_OnEmptyQueue_ThrowsInvalidOperationException()
{
    var queue = new Queue();

    Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
}

[Fact]
public void Dequeue_ReturnsFirstEnqueued_FIFO()
{
    var queue = new Queue();
    queue.Enqueue(1);
    queue.Enqueue(2);
    queue.Enqueue(3);

    var first = queue.Dequeue();
    var second = queue.Dequeue();

    Assert.Equal(1, first);
    Assert.Equal(2, second);
    Assert.Equal(1, queue.Count);
    Assert.Equal(3, queue.Peek());
}

[Fact]
public void Dequeue_UntilEmpty_ResetsHeadAndTail()
{
    var queue = new Queue();
    queue.Enqueue(99);

    queue.Dequeue();

    Assert.True(queue.IsEmpty);
    Assert.Equal(0, queue.Count);
    Assert.Throws<InvalidOperationException>(() => queue.Peek());
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.QueueTests"`
Expected: FAIL — `Dequeue` not defined.

- [ ] **Step 3: Implement Dequeue**

Append inside the `Queue` class:

```csharp
public int Dequeue()
{
    if (_head == null)
        throw new InvalidOperationException("Queue is empty");

    var value = _head.Value;
    _head = _head.Next;
    if (_head == null)
        _tail = null;
    _count--;
    return value;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.QueueTests"`
Expected: PASS (8 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Queue.cs src/DSA.Tests/DataStructure/QueueTests.cs
git commit -m "feat: add Queue.Dequeue with tail reset on empty"
```

---

# Section 3 — DoublyLinkedList

**Files:**
- Create: `src/DSA/DataStructure/DoublyLinkedList.cs`
- Create: `src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs`

Two-way linked list of `int` with `Prev` and `Next` pointers. Methods: `Push` (append), `Pop` (remove tail), `Unshift` (prepend), `Shift` (remove head), `Get`, `Set`, `Insert`, `Remove`, `GetLength`.

### Task 8: DoublyLinkedList scaffold + GetLength

**Files:**
- Create: `src/DSA/DataStructure/DoublyLinkedList.cs`
- Create: `src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs`

- [ ] **Step 1: Write the failing test**

Create `src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs`:

```csharp
using DSA.DataStructure;

namespace DSA.Tests.DataStructure;

public class DoublyLinkedListTests
{
    [Fact]
    public void GetLength_OnNewList_ReturnsZero()
    {
        var list = new DoublyLinkedList();

        Assert.Equal(0, list.GetLength());
    }
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.DoublyLinkedListTests"`
Expected: FAIL — `DoublyLinkedList` not defined.

- [ ] **Step 3: Write minimal implementation**

Create `src/DSA/DataStructure/DoublyLinkedList.cs`:

```csharp
namespace DSA.DataStructure;

public class DoublyNode(int value)
{
    public int Value { get; set; } = value;
    public DoublyNode? Prev { get; set; } = null;
    public DoublyNode? Next { get; set; } = null;
}

public class DoublyLinkedList
{
    private DoublyNode? _head;
    private DoublyNode? _tail;
    private int _length;

    public int GetLength() => _length;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.DoublyLinkedListTests"`
Expected: PASS (1 test).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/DoublyLinkedList.cs src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs
git commit -m "feat: add DoublyLinkedList scaffold with GetLength"
```

### Task 9: DoublyLinkedList.Push + Get

**Files:**
- Modify: `src/DSA/DataStructure/DoublyLinkedList.cs`
- Modify: `src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs`

`Get(index)` is implemented alongside `Push` so subsequent operation tests have a way to inspect list contents.

- [ ] **Step 1: Write the failing tests**

Append inside `DoublyLinkedListTests`:

```csharp
[Fact]
public void Push_OnEmptyList_SetsHeadAndTailToSameNode()
{
    var list = new DoublyLinkedList();

    list.Push(10);

    Assert.Equal(1, list.GetLength());
    Assert.Equal(10, list.Get(0));
}

[Fact]
public void Push_MultipleValues_LinksTailToTail()
{
    var list = new DoublyLinkedList();

    list.Push(1);
    list.Push(2);
    list.Push(3);

    Assert.Equal(3, list.GetLength());
    Assert.Equal(1, list.Get(0));
    Assert.Equal(2, list.Get(1));
    Assert.Equal(3, list.Get(2));
}

[Fact]
public void Get_IndexOutOfRange_ReturnsNull()
{
    var list = new DoublyLinkedList();
    list.Push(1);

    Assert.Null(list.Get(5));
    Assert.Null(list.Get(-1));
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.DoublyLinkedListTests"`
Expected: FAIL — `Push` and `Get` not defined.

- [ ] **Step 3: Implement Push and Get**

Append inside the `DoublyLinkedList` class:

```csharp
public void Push(int value)
{
    var node = new DoublyNode(value);
    if (_tail == null)
    {
        _head = node;
        _tail = node;
    }
    else
    {
        node.Prev = _tail;
        _tail.Next = node;
        _tail = node;
    }
    _length++;
}

public int? Get(int index)
{
    if (index < 0 || index >= _length) return null;

    DoublyNode? current;
    if (index < _length / 2)
    {
        current = _head;
        for (var i = 0; i < index; i++)
            current = current!.Next;
    }
    else
    {
        current = _tail;
        for (var i = _length - 1; i > index; i--)
            current = current!.Prev;
    }
    return current!.Value;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.DoublyLinkedListTests"`
Expected: PASS (4 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/DoublyLinkedList.cs src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs
git commit -m "feat: add DoublyLinkedList Push and Get with bidirectional traversal"
```

### Task 10: DoublyLinkedList.Pop

**Files:**
- Modify: `src/DSA/DataStructure/DoublyLinkedList.cs`
- Modify: `src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `DoublyLinkedListTests`:

```csharp
[Fact]
public void Pop_OnEmptyList_ReturnsNull()
{
    var list = new DoublyLinkedList();

    Assert.Null(list.Pop());
    Assert.Equal(0, list.GetLength());
}

[Fact]
public void Pop_OnSingleElementList_EmptiesList()
{
    var list = new DoublyLinkedList();
    list.Push(42);

    var popped = list.Pop();

    Assert.Equal(42, popped);
    Assert.Equal(0, list.GetLength());
    Assert.Null(list.Get(0));
}

[Fact]
public void Pop_OnMultiElementList_RemovesAndReturnsTail()
{
    var list = new DoublyLinkedList();
    list.Push(1);
    list.Push(2);
    list.Push(3);

    var popped = list.Pop();

    Assert.Equal(3, popped);
    Assert.Equal(2, list.GetLength());
    Assert.Equal(2, list.Get(1));
    Assert.Null(list.Get(2));
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.DoublyLinkedListTests"`
Expected: FAIL — `Pop` not defined.

- [ ] **Step 3: Implement Pop**

Append inside the `DoublyLinkedList` class:

```csharp
public int? Pop()
{
    if (_tail == null) return null;

    var value = _tail.Value;
    if (_length == 1)
    {
        _head = null;
        _tail = null;
    }
    else
    {
        _tail = _tail.Prev;
        _tail!.Next = null;
    }
    _length--;
    return value;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.DoublyLinkedListTests"`
Expected: PASS (7 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/DoublyLinkedList.cs src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs
git commit -m "feat: add DoublyLinkedList.Pop with single-element handling"
```

### Task 11: DoublyLinkedList.Unshift + Shift

**Files:**
- Modify: `src/DSA/DataStructure/DoublyLinkedList.cs`
- Modify: `src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `DoublyLinkedListTests`:

```csharp
[Fact]
public void Unshift_OnEmptyList_SetsHeadAndTail()
{
    var list = new DoublyLinkedList();

    list.Unshift(10);

    Assert.Equal(1, list.GetLength());
    Assert.Equal(10, list.Get(0));
}

[Fact]
public void Unshift_OnNonEmptyList_PrependsToHead()
{
    var list = new DoublyLinkedList();
    list.Push(2);
    list.Push(3);

    list.Unshift(1);

    Assert.Equal(3, list.GetLength());
    Assert.Equal(1, list.Get(0));
    Assert.Equal(2, list.Get(1));
}

[Fact]
public void Shift_OnEmptyList_ReturnsNull()
{
    var list = new DoublyLinkedList();

    Assert.Null(list.Shift());
}

[Fact]
public void Shift_RemovesAndReturnsHead()
{
    var list = new DoublyLinkedList();
    list.Push(1);
    list.Push(2);
    list.Push(3);

    var shifted = list.Shift();

    Assert.Equal(1, shifted);
    Assert.Equal(2, list.GetLength());
    Assert.Equal(2, list.Get(0));
}

[Fact]
public void Shift_OnSingleElementList_EmptiesList()
{
    var list = new DoublyLinkedList();
    list.Push(42);

    list.Shift();

    Assert.Equal(0, list.GetLength());
    Assert.Null(list.Get(0));
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.DoublyLinkedListTests"`
Expected: FAIL — `Unshift` and `Shift` not defined.

- [ ] **Step 3: Implement Unshift and Shift**

Append inside the `DoublyLinkedList` class:

```csharp
public void Unshift(int value)
{
    var node = new DoublyNode(value);
    if (_head == null)
    {
        _head = node;
        _tail = node;
    }
    else
    {
        node.Next = _head;
        _head.Prev = node;
        _head = node;
    }
    _length++;
}

public int? Shift()
{
    if (_head == null) return null;

    var value = _head.Value;
    if (_length == 1)
    {
        _head = null;
        _tail = null;
    }
    else
    {
        _head = _head.Next;
        _head!.Prev = null;
    }
    _length--;
    return value;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.DoublyLinkedListTests"`
Expected: PASS (12 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/DoublyLinkedList.cs src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs
git commit -m "feat: add DoublyLinkedList Unshift and Shift"
```

### Task 12: DoublyLinkedList.Set + Insert + Remove

**Files:**
- Modify: `src/DSA/DataStructure/DoublyLinkedList.cs`
- Modify: `src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs`

These three round out the structure. `Set` mutates a value at index; `Insert` adds at index; `Remove` removes at index.

- [ ] **Step 1: Write the failing tests**

Append inside `DoublyLinkedListTests`:

```csharp
[Fact]
public void Set_ValidIndex_UpdatesValueAndReturnsTrue()
{
    var list = new DoublyLinkedList();
    list.Push(1);
    list.Push(2);
    list.Push(3);

    var result = list.Set(1, 99);

    Assert.True(result);
    Assert.Equal(99, list.Get(1));
}

[Fact]
public void Set_InvalidIndex_ReturnsFalse()
{
    var list = new DoublyLinkedList();
    list.Push(1);

    Assert.False(list.Set(5, 99));
    Assert.False(list.Set(-1, 99));
}

[Fact]
public void Insert_AtHead_DelegatesToUnshift()
{
    var list = new DoublyLinkedList();
    list.Push(2);
    list.Push(3);

    var result = list.Insert(0, 1);

    Assert.True(result);
    Assert.Equal(3, list.GetLength());
    Assert.Equal(1, list.Get(0));
}

[Fact]
public void Insert_AtTail_DelegatesToPush()
{
    var list = new DoublyLinkedList();
    list.Push(1);
    list.Push(2);

    var result = list.Insert(2, 3);

    Assert.True(result);
    Assert.Equal(3, list.GetLength());
    Assert.Equal(3, list.Get(2));
}

[Fact]
public void Insert_AtMiddle_LinksBothNeighbors()
{
    var list = new DoublyLinkedList();
    list.Push(1);
    list.Push(3);

    var result = list.Insert(1, 2);

    Assert.True(result);
    Assert.Equal(3, list.GetLength());
    Assert.Equal(1, list.Get(0));
    Assert.Equal(2, list.Get(1));
    Assert.Equal(3, list.Get(2));
}

[Fact]
public void Insert_InvalidIndex_ReturnsFalse()
{
    var list = new DoublyLinkedList();
    list.Push(1);

    Assert.False(list.Insert(-1, 0));
    Assert.False(list.Insert(99, 0));
}

[Fact]
public void Remove_AtHead_DelegatesToShift()
{
    var list = new DoublyLinkedList();
    list.Push(1);
    list.Push(2);

    var removed = list.Remove(0);

    Assert.Equal(1, removed);
    Assert.Equal(2, list.Get(0));
}

[Fact]
public void Remove_AtTail_DelegatesToPop()
{
    var list = new DoublyLinkedList();
    list.Push(1);
    list.Push(2);

    var removed = list.Remove(1);

    Assert.Equal(2, removed);
    Assert.Equal(1, list.GetLength());
}

[Fact]
public void Remove_AtMiddle_BridgesNeighbors()
{
    var list = new DoublyLinkedList();
    list.Push(1);
    list.Push(2);
    list.Push(3);

    var removed = list.Remove(1);

    Assert.Equal(2, removed);
    Assert.Equal(2, list.GetLength());
    Assert.Equal(1, list.Get(0));
    Assert.Equal(3, list.Get(1));
}

[Fact]
public void Remove_InvalidIndex_ReturnsNull()
{
    var list = new DoublyLinkedList();
    list.Push(1);

    Assert.Null(list.Remove(-1));
    Assert.Null(list.Remove(99));
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.DoublyLinkedListTests"`
Expected: FAIL — `Set`, `Insert`, `Remove` not defined.

- [ ] **Step 3: Implement Set, Insert, Remove**

Append inside the `DoublyLinkedList` class:

```csharp
public bool Set(int index, int value)
{
    if (index < 0 || index >= _length) return false;

    var current = _head;
    for (var i = 0; i < index; i++)
        current = current!.Next;
    current!.Value = value;
    return true;
}

public bool Insert(int index, int value)
{
    if (index < 0 || index > _length) return false;
    if (index == 0)
    {
        Unshift(value);
        return true;
    }
    if (index == _length)
    {
        Push(value);
        return true;
    }

    var current = _head;
    for (var i = 0; i < index; i++)
        current = current!.Next;

    var node = new DoublyNode(value)
    {
        Prev = current!.Prev,
        Next = current
    };
    current.Prev!.Next = node;
    current.Prev = node;
    _length++;
    return true;
}

public int? Remove(int index)
{
    if (index < 0 || index >= _length) return null;
    if (index == 0) return Shift();
    if (index == _length - 1) return Pop();

    var current = _head;
    for (var i = 0; i < index; i++)
        current = current!.Next;

    current!.Prev!.Next = current.Next;
    current.Next!.Prev = current.Prev;
    _length--;
    return current.Value;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.DoublyLinkedListTests"`
Expected: PASS (22 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/DoublyLinkedList.cs src/DSA.Tests/DataStructure/DoublyLinkedListTests.cs
git commit -m "feat: add DoublyLinkedList Set, Insert, Remove"
```

---

# Section 4 — MinHeap

**Files:**
- Create: `src/DSA/DataStructure/MinHeap.cs`
- Create: `src/DSA.Tests/DataStructure/MinHeapTests.cs`

Array-based min-heap mirroring the existing `Heap.cs` (max-heap). The existing `Heap` class stays untouched; this is a new sibling class. Public surface mirrors `Heap`: `Insert`, `Peek`, `ExtractMin`, `Count`, `IsEmpty`, `ToList`, `Clear`.

### Task 13: MinHeap scaffold + Count + IsEmpty + Clear

**Files:**
- Create: `src/DSA/DataStructure/MinHeap.cs`
- Create: `src/DSA.Tests/DataStructure/MinHeapTests.cs`

- [ ] **Step 1: Write the failing test**

Create `src/DSA.Tests/DataStructure/MinHeapTests.cs`:

```csharp
using DSA.DataStructure;

namespace DSA.Tests.DataStructure;

public class MinHeapTests
{
    [Fact]
    public void Count_OnNewHeap_ReturnsZero()
    {
        var heap = new MinHeap();

        Assert.Equal(0, heap.Count);
    }

    [Fact]
    public void IsEmpty_OnNewHeap_ReturnsTrue()
    {
        var heap = new MinHeap();

        Assert.True(heap.IsEmpty);
    }

    [Fact]
    public void Clear_OnNewHeap_KeepsCountZero()
    {
        var heap = new MinHeap();

        heap.Clear();

        Assert.Equal(0, heap.Count);
        Assert.True(heap.IsEmpty);
    }
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.MinHeapTests"`
Expected: FAIL — `MinHeap` not defined.

- [ ] **Step 3: Write minimal implementation**

Create `src/DSA/DataStructure/MinHeap.cs`:

```csharp
namespace DSA.DataStructure;

public class MinHeap
{
    private readonly List<int> _data = [];

    public int Count => _data.Count;
    public bool IsEmpty => _data.Count == 0;

    public void Clear() => _data.Clear();
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.MinHeapTests"`
Expected: PASS (3 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/MinHeap.cs src/DSA.Tests/DataStructure/MinHeapTests.cs
git commit -m "feat: add MinHeap scaffold with Count, IsEmpty, Clear"
```

### Task 14: MinHeap.Insert + Peek

**Files:**
- Modify: `src/DSA/DataStructure/MinHeap.cs`
- Modify: `src/DSA.Tests/DataStructure/MinHeapTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `MinHeapTests`:

```csharp
[Fact]
public void Peek_OnEmptyHeap_ThrowsInvalidOperationException()
{
    var heap = new MinHeap();

    Assert.Throws<InvalidOperationException>(() => heap.Peek());
}

[Fact]
public void Insert_SingleValue_PeeksThatValue()
{
    var heap = new MinHeap();

    heap.Insert(42);

    Assert.Equal(1, heap.Count);
    Assert.Equal(42, heap.Peek());
}

[Fact]
public void Insert_MultipleValues_PeekReturnsSmallest()
{
    var heap = new MinHeap();

    heap.Insert(5);
    heap.Insert(3);
    heap.Insert(8);
    heap.Insert(1);
    heap.Insert(4);

    Assert.Equal(5, heap.Count);
    Assert.Equal(1, heap.Peek());
}

[Fact]
public void Insert_DescendingValues_PeekTracksMin()
{
    var heap = new MinHeap();

    heap.Insert(10);
    Assert.Equal(10, heap.Peek());
    heap.Insert(5);
    Assert.Equal(5, heap.Peek());
    heap.Insert(2);
    Assert.Equal(2, heap.Peek());
    heap.Insert(1);
    Assert.Equal(1, heap.Peek());
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.MinHeapTests"`
Expected: FAIL — `Insert` and `Peek` not defined.

- [ ] **Step 3: Implement Insert, Peek, and BubbleUp**

Append inside the `MinHeap` class:

```csharp
public int Peek()
{
    if (IsEmpty)
        throw new InvalidOperationException("Heap is empty");

    return _data[0];
}

public void Insert(int value)
{
    _data.Add(value);
    BubbleUp();
}

private void BubbleUp()
{
    var index = _data.Count - 1;
    var inserted = _data[index];
    while (index > 0)
    {
        var parentIndex = (index - 1) / 2;
        var parent = _data[parentIndex];
        if (parent <= inserted) break;

        _data[parentIndex] = inserted;
        _data[index] = parent;
        index = parentIndex;
    }
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.MinHeapTests"`
Expected: PASS (7 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/MinHeap.cs src/DSA.Tests/DataStructure/MinHeapTests.cs
git commit -m "feat: add MinHeap.Insert and Peek with bubble-up"
```

### Task 15: MinHeap.ExtractMin + ToList

**Files:**
- Modify: `src/DSA/DataStructure/MinHeap.cs`
- Modify: `src/DSA.Tests/DataStructure/MinHeapTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `MinHeapTests`:

```csharp
[Fact]
public void ExtractMin_OnEmptyHeap_ThrowsInvalidOperationException()
{
    var heap = new MinHeap();

    Assert.Throws<InvalidOperationException>(() => heap.ExtractMin());
}

[Fact]
public void ExtractMin_ReturnsMinAndDecrementsCount()
{
    var heap = new MinHeap();
    heap.Insert(3);
    heap.Insert(1);
    heap.Insert(2);

    var min = heap.ExtractMin();

    Assert.Equal(1, min);
    Assert.Equal(2, heap.Count);
    Assert.Equal(2, heap.Peek());
}

[Fact]
public void ExtractMin_RepeatedCalls_ReturnsSortedAscending()
{
    var heap = new MinHeap();
    int[] input = [9, 4, 7, 1, 12, 3, 6];
    foreach (var v in input) heap.Insert(v);

    var sorted = new List<int>();
    while (!heap.IsEmpty)
        sorted.Add(heap.ExtractMin());

    Assert.Equal(new[] { 1, 3, 4, 6, 7, 9, 12 }, sorted);
}

[Fact]
public void ToList_ReturnsInternalArrayCopy()
{
    var heap = new MinHeap();
    heap.Insert(5);
    heap.Insert(3);

    var snapshot = heap.ToList();
    snapshot.Add(999);

    Assert.Equal(2, heap.Count);
}

[Fact]
public void Clear_AfterInserts_EmptiesHeap()
{
    var heap = new MinHeap();
    heap.Insert(1);
    heap.Insert(2);

    heap.Clear();

    Assert.Equal(0, heap.Count);
    Assert.True(heap.IsEmpty);
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.MinHeapTests"`
Expected: FAIL — `ExtractMin` and `ToList` not defined.

- [ ] **Step 3: Implement ExtractMin, BubbleDown, ToList**

Append inside the `MinHeap` class:

```csharp
public int ExtractMin()
{
    if (IsEmpty)
        throw new InvalidOperationException("Heap is empty");

    var min = _data[0];
    var lastIndex = _data.Count - 1;
    _data[0] = _data[lastIndex];
    _data.RemoveAt(lastIndex);

    if (_data.Count > 0)
        BubbleDown();

    return min;
}

public List<int> ToList() => [.. _data];

private void BubbleDown()
{
    var index = 0;
    var length = _data.Count;
    var element = _data[0];

    while (true)
    {
        var leftIndex = 2 * index + 1;
        var rightIndex = 2 * index + 2;
        var smallest = index;

        if (leftIndex < length && _data[leftIndex] < _data[smallest])
            smallest = leftIndex;

        if (rightIndex < length && _data[rightIndex] < _data[smallest])
            smallest = rightIndex;

        if (smallest == index) break;

        _data[index] = _data[smallest];
        _data[smallest] = element;
        index = smallest;
    }
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.MinHeapTests"`
Expected: PASS (12 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/MinHeap.cs src/DSA.Tests/DataStructure/MinHeapTests.cs
git commit -m "feat: add MinHeap.ExtractMin and ToList with bubble-down"
```

---

# Section 5 — Trie

**Files:**
- Create: `src/DSA/DataStructure/Trie.cs`
- Create: `src/DSA.Tests/DataStructure/TrieTests.cs`

String-keyed prefix tree (no value payload — set semantics). Methods: `Insert`, `Search`, `StartsWith`.

### Task 16: Trie scaffold + Insert + Search

**Files:**
- Create: `src/DSA/DataStructure/Trie.cs`
- Create: `src/DSA.Tests/DataStructure/TrieTests.cs`

- [ ] **Step 1: Write the failing test**

Create `src/DSA.Tests/DataStructure/TrieTests.cs`:

```csharp
using DSA.DataStructure;

namespace DSA.Tests.DataStructure;

public class TrieTests
{
    [Fact]
    public void Search_OnEmptyTrie_ReturnsFalse()
    {
        var trie = new Trie();

        Assert.False(trie.Search("apple"));
    }

    [Fact]
    public void Insert_ThenSearchExactWord_ReturnsTrue()
    {
        var trie = new Trie();

        trie.Insert("apple");

        Assert.True(trie.Search("apple"));
    }

    [Fact]
    public void Search_PrefixOnly_ReturnsFalse()
    {
        var trie = new Trie();
        trie.Insert("apple");

        Assert.False(trie.Search("app"));
    }

    [Fact]
    public void Insert_MultipleWords_AllSearchable()
    {
        var trie = new Trie();
        trie.Insert("cat");
        trie.Insert("car");
        trie.Insert("cart");

        Assert.True(trie.Search("cat"));
        Assert.True(trie.Search("car"));
        Assert.True(trie.Search("cart"));
        Assert.False(trie.Search("ca"));
        Assert.False(trie.Search("carts"));
    }

    [Fact]
    public void Insert_EmptyString_MarksRootAsWord()
    {
        var trie = new Trie();

        trie.Insert("");

        Assert.True(trie.Search(""));
    }

    [Fact]
    public void Insert_SameWordTwice_StillSearchable()
    {
        var trie = new Trie();

        trie.Insert("hello");
        trie.Insert("hello");

        Assert.True(trie.Search("hello"));
    }
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.TrieTests"`
Expected: FAIL — `Trie` not defined.

- [ ] **Step 3: Write minimal implementation**

Create `src/DSA/DataStructure/Trie.cs`:

```csharp
namespace DSA.DataStructure;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; } = new();
    public bool IsEndOfWord { get; set; }
}

public class Trie
{
    private readonly TrieNode _root = new();

    public void Insert(string word)
    {
        var current = _root;
        foreach (var ch in word)
        {
            if (!current.Children.TryGetValue(ch, out var next))
            {
                next = new TrieNode();
                current.Children[ch] = next;
            }
            current = next;
        }
        current.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var node = FindNode(word);
        return node != null && node.IsEndOfWord;
    }

    private TrieNode? FindNode(string prefix)
    {
        var current = _root;
        foreach (var ch in prefix)
        {
            if (!current.Children.TryGetValue(ch, out var next))
                return null;
            current = next;
        }
        return current;
    }
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.TrieTests"`
Expected: PASS (6 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Trie.cs src/DSA.Tests/DataStructure/TrieTests.cs
git commit -m "feat: add Trie with Insert and Search"
```

### Task 17: Trie.StartsWith

**Files:**
- Modify: `src/DSA/DataStructure/Trie.cs`
- Modify: `src/DSA.Tests/DataStructure/TrieTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `TrieTests`:

```csharp
[Fact]
public void StartsWith_OnEmptyTrie_ReturnsFalse()
{
    var trie = new Trie();

    Assert.False(trie.StartsWith("app"));
}

[Fact]
public void StartsWith_ExistingPrefix_ReturnsTrue()
{
    var trie = new Trie();
    trie.Insert("apple");

    Assert.True(trie.StartsWith("app"));
    Assert.True(trie.StartsWith("apple"));
    Assert.True(trie.StartsWith("a"));
}

[Fact]
public void StartsWith_NonExistentPrefix_ReturnsFalse()
{
    var trie = new Trie();
    trie.Insert("apple");

    Assert.False(trie.StartsWith("apz"));
    Assert.False(trie.StartsWith("banana"));
}

[Fact]
public void StartsWith_EmptyPrefix_ReturnsTrue()
{
    var trie = new Trie();
    trie.Insert("apple");

    Assert.True(trie.StartsWith(""));
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.TrieTests"`
Expected: FAIL — `StartsWith` not defined.

- [ ] **Step 3: Implement StartsWith**

Append inside the `Trie` class:

```csharp
public bool StartsWith(string prefix)
{
    return FindNode(prefix) != null;
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.TrieTests"`
Expected: PASS (10 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Trie.cs src/DSA.Tests/DataStructure/TrieTests.cs
git commit -m "feat: add Trie.StartsWith using shared FindNode helper"
```

---

# Section 6 — Graph

**Files:**
- Modify: `src/DSA/DataStructure/Graph.cs` (currently an empty stub: `public class Graph { }`)
- Create: `src/DSA.Tests/DataStructure/GraphTests.cs`

Undirected adjacency-list graph keyed by `string` vertex labels. Methods: `AddVertex`, `AddEdge`, `HasVertex`, `HasEdge`, `RemoveEdge`, `RemoveVertex`, `Bfs`, `Dfs`, `GetVertices`, `GetNeighbors`.

> The `Bfs`/`Dfs` method names here are the project's existing casing convention (see `BinarySearchTree.Bfs`).

### Task 18: Graph scaffold + AddVertex + HasVertex + GetVertices

**Files:**
- Modify: `src/DSA/DataStructure/Graph.cs`
- Create: `src/DSA.Tests/DataStructure/GraphTests.cs`

- [ ] **Step 1: Write the failing test**

Create `src/DSA.Tests/DataStructure/GraphTests.cs`:

```csharp
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
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.GraphTests"`
Expected: FAIL — `AddVertex`, `HasVertex`, `GetVertices` not defined.

- [ ] **Step 3: Replace Graph.cs implementation**

Overwrite `src/DSA/DataStructure/Graph.cs` with:

```csharp
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
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.GraphTests"`
Expected: PASS (4 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Graph.cs src/DSA.Tests/DataStructure/GraphTests.cs
git commit -m "feat: add Graph adjacency list with AddVertex and HasVertex"
```

### Task 19: Graph.AddEdge + HasEdge + GetNeighbors

**Files:**
- Modify: `src/DSA/DataStructure/Graph.cs`
- Modify: `src/DSA.Tests/DataStructure/GraphTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `GraphTests`:

```csharp
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
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.GraphTests"`
Expected: FAIL — `AddEdge`, `HasEdge`, `GetNeighbors` not defined.

- [ ] **Step 3: Implement AddEdge, HasEdge, GetNeighbors**

Append inside the `Graph` class:

```csharp
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
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.GraphTests"`
Expected: PASS (10 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Graph.cs src/DSA.Tests/DataStructure/GraphTests.cs
git commit -m "feat: add Graph AddEdge, HasEdge, GetNeighbors (undirected)"
```

### Task 20: Graph.RemoveEdge + RemoveVertex

**Files:**
- Modify: `src/DSA/DataStructure/Graph.cs`
- Modify: `src/DSA.Tests/DataStructure/GraphTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `GraphTests`:

```csharp
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
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.GraphTests"`
Expected: FAIL — `RemoveEdge` and `RemoveVertex` not defined.

- [ ] **Step 3: Implement RemoveEdge and RemoveVertex**

Append inside the `Graph` class:

```csharp
public void RemoveEdge(string a, string b)
{
    if (_adjacency.TryGetValue(a, out var aNeighbors))
        aNeighbors.Remove(b);
    if (_adjacency.TryGetValue(b, out var bNeighbors))
        bNeighbors.Remove(a);
}

public void RemoveVertex(string vertex)
{
    if (!_adjacency.TryGetValue(vertex, out var neighbors))
        return;

    foreach (var neighbor in neighbors.ToList())
        _adjacency[neighbor].Remove(vertex);

    _adjacency.Remove(vertex);
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.GraphTests"`
Expected: PASS (14 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Graph.cs src/DSA.Tests/DataStructure/GraphTests.cs
git commit -m "feat: add Graph RemoveEdge and RemoveVertex"
```

### Task 21: Graph.Bfs

**Files:**
- Modify: `src/DSA/DataStructure/Graph.cs`
- Modify: `src/DSA.Tests/DataStructure/GraphTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `GraphTests`:

```csharp
[Fact]
public void Bfs_FromUnknownStart_ReturnsEmpty()
{
    var graph = new Graph();

    Assert.Empty(graph.Bfs("ghost"));
}

[Fact]
public void Bfs_SingleVertex_ReturnsThatVertex()
{
    var graph = new Graph();
    graph.AddVertex("A");

    var result = graph.Bfs("A");

    Assert.Equal(new[] { "A" }, result);
}

[Fact]
public void Bfs_VisitsAllReachableVerticesLevelByLevel()
{
    var graph = new Graph();
    graph.AddEdge("A", "B");
    graph.AddEdge("A", "C");
    graph.AddEdge("B", "D");
    graph.AddEdge("C", "E");

    var result = graph.Bfs("A");

    Assert.Equal(5, result.Count);
    Assert.Equal("A", result[0]);
    Assert.Contains("B", result.GetRange(1, 2));
    Assert.Contains("C", result.GetRange(1, 2));
    Assert.Contains("D", result.GetRange(3, 2));
    Assert.Contains("E", result.GetRange(3, 2));
}

[Fact]
public void Bfs_DisconnectedComponent_NotVisited()
{
    var graph = new Graph();
    graph.AddEdge("A", "B");
    graph.AddVertex("X");

    var result = graph.Bfs("A");

    Assert.Equal(2, result.Count);
    Assert.DoesNotContain("X", result);
}

[Fact]
public void Bfs_CycleGraph_VisitsEachVertexOnce()
{
    var graph = new Graph();
    graph.AddEdge("A", "B");
    graph.AddEdge("B", "C");
    graph.AddEdge("C", "A");

    var result = graph.Bfs("A");

    Assert.Equal(3, result.Count);
    Assert.Contains("A", result);
    Assert.Contains("B", result);
    Assert.Contains("C", result);
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.GraphTests"`
Expected: FAIL — `Bfs` not defined.

- [ ] **Step 3: Implement Bfs**

Append inside the `Graph` class:

```csharp
public List<string> Bfs(string start)
{
    var result = new List<string>();
    if (!_adjacency.ContainsKey(start)) return result;

    var visited = new HashSet<string>();
    var queue = new Queue<string>();
    queue.Enqueue(start);
    visited.Add(start);

    while (queue.Count > 0)
    {
        var vertex = queue.Dequeue();
        result.Add(vertex);

        foreach (var neighbor in _adjacency[vertex])
        {
            if (visited.Add(neighbor))
                queue.Enqueue(neighbor);
        }
    }

    return result;
}
```

> Note: `Queue<string>` here is `System.Collections.Generic.Queue<T>`, not the custom `DSA.DataStructure.Queue` from Section 2. Because both live under similar namespaces, the file's implicit usings resolve to the BCL one. If a name collision warning appears, qualify as `System.Collections.Generic.Queue<string>`.

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.GraphTests"`
Expected: PASS (19 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Graph.cs src/DSA.Tests/DataStructure/GraphTests.cs
git commit -m "feat: add Graph.Bfs traversal with visited set"
```

### Task 22: Graph.Dfs

**Files:**
- Modify: `src/DSA/DataStructure/Graph.cs`
- Modify: `src/DSA.Tests/DataStructure/GraphTests.cs`

- [ ] **Step 1: Write the failing tests**

Append inside `GraphTests`:

```csharp
[Fact]
public void Dfs_FromUnknownStart_ReturnsEmpty()
{
    var graph = new Graph();

    Assert.Empty(graph.Dfs("ghost"));
}

[Fact]
public void Dfs_SingleVertex_ReturnsThatVertex()
{
    var graph = new Graph();
    graph.AddVertex("A");

    var result = graph.Dfs("A");

    Assert.Equal(new[] { "A" }, result);
}

[Fact]
public void Dfs_VisitsAllReachableVerticesDepthFirst()
{
    var graph = new Graph();
    graph.AddEdge("A", "B");
    graph.AddEdge("B", "C");
    graph.AddEdge("A", "D");

    var result = graph.Dfs("A");

    Assert.Equal(4, result.Count);
    Assert.Equal("A", result[0]);
    Assert.Contains("B", result);
    Assert.Contains("C", result);
    Assert.Contains("D", result);
    var bIndex = result.IndexOf("B");
    var cIndex = result.IndexOf("C");
    Assert.True(cIndex == bIndex + 1, "DFS should visit C immediately after B");
}

[Fact]
public void Dfs_DisconnectedComponent_NotVisited()
{
    var graph = new Graph();
    graph.AddEdge("A", "B");
    graph.AddVertex("X");

    var result = graph.Dfs("A");

    Assert.Equal(2, result.Count);
    Assert.DoesNotContain("X", result);
}

[Fact]
public void Dfs_CycleGraph_VisitsEachVertexOnce()
{
    var graph = new Graph();
    graph.AddEdge("A", "B");
    graph.AddEdge("B", "C");
    graph.AddEdge("C", "A");

    var result = graph.Dfs("A");

    Assert.Equal(3, result.Count);
}
```

- [ ] **Step 2: Run test to verify it fails**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.GraphTests"`
Expected: FAIL — `Dfs` not defined.

- [ ] **Step 3: Implement Dfs (recursive)**

Append inside the `Graph` class:

```csharp
public List<string> Dfs(string start)
{
    var result = new List<string>();
    if (!_adjacency.ContainsKey(start)) return result;

    var visited = new HashSet<string>();
    DfsVisit(start, visited, result);
    return result;
}

private void DfsVisit(string vertex, HashSet<string> visited, List<string> result)
{
    if (!visited.Add(vertex)) return;
    result.Add(vertex);

    foreach (var neighbor in _adjacency[vertex])
        DfsVisit(neighbor, visited, result);
}
```

- [ ] **Step 4: Run test to verify it passes**

Run: `dotnet test --filter "FullyQualifiedName~DSA.Tests.DataStructure.GraphTests"`
Expected: PASS (24 tests).

- [ ] **Step 5: Commit**

```bash
git add src/DSA/DataStructure/Graph.cs src/DSA.Tests/DataStructure/GraphTests.cs
git commit -m "feat: add Graph.Dfs traversal (recursive)"
```

---

# Section 7 — Final verification

### Task 23: Full suite + coverage check

**Files:** None modified (verification only).

- [ ] **Step 1: Run the full test suite**

Run: `dotnet test`
Expected: ALL tests pass, no regressions.

- [ ] **Step 2: Run coverage collection**

Run: `dotnet test --collect:"XPlat Code Coverage"`
Expected: Coverage report generated. Line coverage should be >= 69.46% baseline (CLAUDE.md) and ideally higher given the new tests.

- [ ] **Step 3: Confirm new classes compile in Release mode**

Run: `dotnet build --configuration Release`
Expected: Build succeeds with 0 errors.

- [ ] **Step 4: Final summary commit (optional, only if any coverage / docs adjustment is needed)**

If no further code changes were needed, skip this step. Otherwise:

```bash
git add <files>
git commit -m "chore: finalize datastructure chapter additions"
```

---

## Self-review notes (filled before handoff)

- **Spec coverage:** All six selected structures (Stack, Queue, DoublyLinkedList, MinHeap, Trie, Graph) each have a dedicated section. Graph fills the empty stub, addressing the most critical gap.
- **Placeholder scan:** No TBD/TODO/"add appropriate" markers. Every code step shows full code. Test code is concrete and runnable.
- **Type consistency:**
  - `StackNode`, `QueueNode`, `DoublyNode`, `TrieNode` are distinct names — no collision with the existing `Node` class in `BinarySearchTree.cs`.
  - `Stack.Pop` returns `int` (throws on empty). `Queue.Dequeue` returns `int` (throws on empty). `DoublyLinkedList.Pop/Shift/Remove` return `int?` (null on missing) because the existing `LinkedList.Pop` returns nullable — convention matches.
  - `Graph.Bfs`/`Dfs` use lowercase-suffix casing (`Bfs`, `Dfs`) to match `BinarySearchTree.Bfs`/`DfsPreOrder`.
  - `MinHeap` mirrors `Heap` (existing max-heap) public surface exactly except for the comparison direction.
- **Existing collisions checked:**
  - `DSA.DataStructure.Queue` (new) vs `System.Collections.Generic.Queue<T>` — fully-qualified inside `Graph.Bfs` if needed (noted in Task 21).
  - No conflicts with `DSA.LeetCode.*` namespaces.

---

## Execution sequence summary

| # | Task | Files | Commit message |
|---|------|-------|----------------|
| 1 | Stack scaffold | Stack.cs, StackTests.cs | feat: add Stack scaffold with IsEmpty and Count |
| 2 | Stack.Push | Stack.cs, StackTests.cs | feat: add Stack.Push with LIFO ordering |
| 3 | Stack.Pop | Stack.cs, StackTests.cs | feat: add Stack.Pop with empty-stack guard |
| 4 | Stack.Peek edge | StackTests.cs | test: add Stack.Peek edge case coverage |
| 5 | Queue scaffold | Queue.cs, QueueTests.cs | feat: add Queue scaffold with IsEmpty and Count |
| 6 | Queue Enqueue/Peek | Queue.cs, QueueTests.cs | feat: add Queue.Enqueue and Peek with FIFO ordering |
| 7 | Queue.Dequeue | Queue.cs, QueueTests.cs | feat: add Queue.Dequeue with tail reset on empty |
| 8 | DLL scaffold | DoublyLinkedList.cs, DoublyLinkedListTests.cs | feat: add DoublyLinkedList scaffold with GetLength |
| 9 | DLL Push/Get | DoublyLinkedList.cs, DoublyLinkedListTests.cs | feat: add DoublyLinkedList Push and Get with bidirectional traversal |
| 10 | DLL.Pop | DoublyLinkedList.cs, DoublyLinkedListTests.cs | feat: add DoublyLinkedList.Pop with single-element handling |
| 11 | DLL Unshift/Shift | DoublyLinkedList.cs, DoublyLinkedListTests.cs | feat: add DoublyLinkedList Unshift and Shift |
| 12 | DLL Set/Insert/Remove | DoublyLinkedList.cs, DoublyLinkedListTests.cs | feat: add DoublyLinkedList Set, Insert, Remove |
| 13 | MinHeap scaffold | MinHeap.cs, MinHeapTests.cs | feat: add MinHeap scaffold with Count, IsEmpty, Clear |
| 14 | MinHeap Insert/Peek | MinHeap.cs, MinHeapTests.cs | feat: add MinHeap.Insert and Peek with bubble-up |
| 15 | MinHeap ExtractMin | MinHeap.cs, MinHeapTests.cs | feat: add MinHeap.ExtractMin and ToList with bubble-down |
| 16 | Trie Insert/Search | Trie.cs, TrieTests.cs | feat: add Trie with Insert and Search |
| 17 | Trie.StartsWith | Trie.cs, TrieTests.cs | feat: add Trie.StartsWith using shared FindNode helper |
| 18 | Graph scaffold | Graph.cs, GraphTests.cs | feat: add Graph adjacency list with AddVertex and HasVertex |
| 19 | Graph edges | Graph.cs, GraphTests.cs | feat: add Graph AddEdge, HasEdge, GetNeighbors (undirected) |
| 20 | Graph removal | Graph.cs, GraphTests.cs | feat: add Graph RemoveEdge and RemoveVertex |
| 21 | Graph.Bfs | Graph.cs, GraphTests.cs | feat: add Graph.Bfs traversal with visited set |
| 22 | Graph.Dfs | Graph.cs, GraphTests.cs | feat: add Graph.Dfs traversal (recursive) |
| 23 | Final verify | (verification only) | (none unless adjustments needed) |
