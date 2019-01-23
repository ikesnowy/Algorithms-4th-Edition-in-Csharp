using System;
using SortApplication;

namespace _2._5._24
{
    /*
     * 2.5.24
     * 
     * 稳定的优先队列。
     * 实现一个稳定的优先队列（将重复的元素按照它们被插入的顺序返回）。
     * 
     */
    class Program
    {
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
