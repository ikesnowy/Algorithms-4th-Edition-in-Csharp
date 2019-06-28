using System;
using BinarySearchTree;

namespace _3._2._10
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = "S E A R C H E X A M P L E";
            var keys = test.Split(" ");
            var n = keys.Length;
            var st = new BST<string, int>();
            for (var i = 0; i < n; i++)
            {
                st.Put(keys[i], i);
            }

            Console.WriteLine("size = " + st.Size());
            Console.WriteLine("min = " + st.Min());
            Console.WriteLine("max = " + st.Max());
            Console.WriteLine();

            Console.WriteLine("Testing keys()");
            Console.WriteLine("---------------------------");
            foreach (var key in st.Keys())
            {
                Console.WriteLine(key + " " + st.Get(key));
            }
            Console.WriteLine();

            Console.WriteLine("Testing select");
            Console.WriteLine("---------------------------");
            for (var i = 0; i < st.Size(); i++)
            {
                Console.WriteLine(i + " " + st.Select(i));
            }
            Console.WriteLine();

            Console.WriteLine("key rank floor ceil");
            Console.WriteLine("---------------------------");
            for (var i = 'A'; i <= 'Z'; i++)
            {
                var s = i + "";
                Console.WriteLine($"{s} {st.Rank(s)} {st.Floor(s)} {st.Ceiling(s)}");
            }

            var from = new[] {"A", "Z", "X", "0", "B", "C"};
            var to = new[] {"Z", "A", "X", "Z", "G", "L"};
            Console.WriteLine("range search");
            Console.WriteLine("---------------------------");
            for (var i = 0; i < from.Length; i++)
            {
                Console.Write($"{from[i]}-{to[i]} ({st.Size(from[i], to[i])})");
                foreach (var key in st.Keys(from[i], to[i]))
                    Console.Write(key + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

            for (var i = 0; i < st.Size() / 2; i++)
            {
                st.DeleteMin();
            }
            Console.WriteLine("After deleting the smallest " + st.Size() / 2 + " keys");
            Console.WriteLine("---------------------------");
            foreach (var key in st.Keys())
            {
                Console.WriteLine(key + " " + st.Get(key));
            }
            Console.WriteLine();

            while (!st.IsEmpty())
            {
                st.Delete(st.Select(st.Size() / 2));
            }
            Console.WriteLine("After deleting the remaining keys");
            Console.WriteLine("---------------------------");
            foreach (var s in st.Keys())
            {
                Console.WriteLine(s + " " + st.Get(s));
            }
            Console.WriteLine();

            for (var i = 0; i < n; i++)
            {
                st.Put(keys[i], i);
            }
            Console.WriteLine("After adding back the keys");
            Console.WriteLine("---------------------------");
            foreach (var key in st.Keys())
            {
                Console.WriteLine(key + " " + st.Get(key));
            }
            Console.WriteLine();
        }
    }
}
