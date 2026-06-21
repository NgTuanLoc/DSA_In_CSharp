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
}
