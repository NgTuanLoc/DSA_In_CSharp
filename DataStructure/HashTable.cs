namespace DSA.DataStructure
{
    interface IHashTable
    {

    }
    public class HashTable
    {
        private readonly int _size;
        private readonly List<string>[] _keyMap;
        public HashTable(int size = 100)
        {
            _size = size;
            _keyMap = new List<string>[_size];
        }
        public void Set(string key, string value)
        {
            var index = Hash(key);
            if (_keyMap[index] == null)
            {
                _keyMap[index] = new List<string>();
            }
            _keyMap[index].Add(value);
        }
        public List<string> Get(string key)
        {
            var value = new List<string>();
            var index = Hash(key);
            if (_keyMap[index] != null)
            {
                value = _keyMap[index];
            }
            return value;
        }
        public static int Hash(string key, int size = 100)
        {
            var total = 0;
            var salt = 31;
            for (var i = 0; i < Math.Min(key.Length, 100); i++)
            {
                ushort unicodeValue = Convert.ToUInt16(key[i]);
                total = (total * salt + unicodeValue) % size;
            }

            return total;
        }
    }
}

// Handling collision
// - Separate Chaining (array, linked list)
// - Linear Probing (check if exist => if exist => store next index)