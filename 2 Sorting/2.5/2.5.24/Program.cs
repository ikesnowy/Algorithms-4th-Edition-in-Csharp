using System;
using SortApplication;

namespace _2._5._24
{
    class Program
    {
        // 官方解答：https://algs4.cs.princeton.edu/25applications/StableMinPQ.java.html
        class Wrapper<T> : IComparable<Wrapper<T>> where T : IComparable<T>
        {
            public T Value;
            public int Index;

            public Wrapper(T value, int index)
            {
                this.Value = value;
                this.Index = index;
            }

            public int CompareTo(Wrapper<T> other)
            {
                return this.Value.CompareTo(other.Value);
            }
        }

        static void Main(string[] args)
        {
            MinPQStable<Wrapper<string>> pq = new MinPQStable<Wrapper<string>>();
            string text = "it was the best of times it was the worst of times it was the ";
            string[] texts = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < texts.Length; i++)
                pq.Insert(new Wrapper<string>(texts[i], i + 1));

            while (!pq.IsEmpty())
            {
                Wrapper<string> w = pq.DelMin();
                Console.WriteLine(w.Value + " " + w.Index);
            }
        }
    }
}