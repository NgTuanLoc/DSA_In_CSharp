namespace DSA.LeetCode.StackAndQueue;

public static class StackAndQueueExample
{
    public static void Run()
    {
        Console.WriteLine("+++++++++++++Stack and Queue+++++++++++++");
        // // !=========Valid Parentheses=========
        // Console.WriteLine(Stacks.IsValid("()"));
        // Console.WriteLine(Stacks.IsValid("()[]{}"));
        // Console.WriteLine(Stacks.IsValid("(]"));
        // Console.WriteLine(Stacks.IsValid("([])"));
        // Console.WriteLine(Stacks.IsValid("([)]"));

        // // !=========Remove All Adjacent Duplicates In String=========
        // Console.WriteLine(Stacks.RemoveDuplicates("abbaca"));
        // Console.WriteLine(Stacks.RemoveDuplicates("azxxzy"));

        // // !=========Remove All Adjacent Duplicates In String=========
        // Console.WriteLine(Stacks.BackspaceCompare("ab#c", "ad#c"));
        // Console.WriteLine(Stacks.BackspaceCompare("ab##", "c#d#"));
        // Console.WriteLine(Stacks.BackspaceCompare("a#c", "b"));
        // Console.WriteLine(Stacks.BackspaceCompare("a##c", "#a#c"));

        // // !=========Simplify Path=========
        // Console.WriteLine(Stacks.SimplifyPath("/home/"));
        // Console.WriteLine(Stacks.SimplifyPath("/home//foo/"));
        // Console.WriteLine(Stacks.SimplifyPath("/home/user/Documents/../Pictures"));
        // Console.WriteLine(Stacks.SimplifyPath("/../"));
        // Console.WriteLine(Stacks.SimplifyPath("/.../a/../b/c/../d/./"));

        // !=========Make The String Great=========
        Console.WriteLine(Stacks.MakeGood("leEeetcode"));
        Console.WriteLine(Stacks.MakeGood("abBAcC"));
        Console.WriteLine(Stacks.MakeGood("s"));
    }
}