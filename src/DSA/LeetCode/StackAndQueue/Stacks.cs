using System.Text;

namespace DSA.LeetCode.StackAndQueue;

public static class Stacks
{
    // https://leetcode.com/problems/valid-parentheses/description/
    public static bool IsValid(string s)
    {
        var matching = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };
        var stack = new Stack<char>();

        foreach (var ch in s)
        {
            if (matching.ContainsKey(ch))
            {
                stack.Push(ch);
            }
            else
            {
                if (stack.Count == 0) return false;
                matching.TryGetValue(stack.Pop(), out char val);
                if (val != ch) return false;
            }
        }

        return stack.Count == 0;
    }

    // https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string/description/
    public static string RemoveDuplicates(string s)
    {
        var stack = new Stack<char>();

        foreach (var ch in s)
        {
            if (stack.Count != 0 && stack.Peek() == ch)
            {
                stack.Pop();
            }
            else
            {
                stack.Push(ch);
            }
        }

        // Convert stack to string (stack is in reverse order)
        var result = new char[stack.Count];
        for (int i = stack.Count - 1; i >= 0; i--)
        {
            result[i] = stack.Pop();
        }
        return new string(result);
    }

    // https://leetcode.com/problems/backspace-string-compare/description/
    public static bool BackspaceCompare(string s, string t)
    {
        var stack = new Stack<char>();
        var stack1 = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {

            if (s[i] == '#' && stack.Count != 0)
            {
                stack.Pop();
            }

            if (s[i] != '#')
            {
                stack.Push(s[i]);
            }
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == '#' && stack1.Count != 0)
            {
                stack1.Pop();
            }

            if (t[i] != '#')
            {
                stack1.Push(t[i]);
            }
        }

        if (stack.Count != stack1.Count) return false;

        while (stack.Count != 0)
        {
            if (stack.Pop() != stack1.Pop()) return false;
        }

        return true;
    }

    // https://leetcode.com/problems/simplify-path/description/
    public static string SimplifyPath(string path)
    {
        var arr = path.Split('/');
        var stack = new Stack<string>();

        foreach (var item in arr)
        {
            if (item == "" || item == ".") continue;
            if (item == "..")
            {
                if (stack.Count == 0) continue;
                stack.Pop();
            }
            else
            {
                stack.Push(item);
            }
        }

        var result = new string[stack.Count];

        for (int i = result.Length - 1; i >= 0; i--)
        {
            result[i] = stack.Pop();
        }

        return "/" + string.Join('/', result);
    }

    // https://leetcode.com/problems/make-the-string-great/
    public static string MakeGood(string s)
    {
        var stack = new Stack<char>();

        foreach (var item in s)
        {
            if (stack.Count != 0 && Math.Abs(stack.Peek() - item) == 32)
            {
                stack.Pop();
            }
            else
            {
                stack.Push(item);
            }
        }

        var result = new char[stack.Count];
        for (int i = stack.Count - 1; i >= 0; i--)
        {
            result[i] = stack.Pop();
        }

        return new string(result);
    }
}