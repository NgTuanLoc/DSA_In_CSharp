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
