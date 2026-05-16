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

    public bool StartsWith(string prefix)
    {
        return FindNode(prefix) != null;
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
