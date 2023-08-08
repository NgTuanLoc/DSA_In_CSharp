namespace DSA.DataStructure
{
    interface IHashTable
    {

    }
    public class HashTable
    {
        public HashTable()
        {

        }
        public int Hash(string key, int size = 100)
        {
            var total = 0;
            foreach (var item in key)
            {
                ushort unicodeValue = Convert.ToUInt16(item);
                total = (total + unicodeValue) % size;
            }
            return total;
        }
    }
}