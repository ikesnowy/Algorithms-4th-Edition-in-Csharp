using System;

namespace _2._1._38
{
    class Pair<TKey, TValue> : IComparable<Pair<TKey, TValue>> where TKey : IComparable<TKey>
    {
        TKey key;
        TValue value;

        public Pair(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }

        public int CompareTo(Pair<TKey, TValue> other)
        {
            return key.CompareTo(other.key);
        }
    }
}
