using System;
using SymbolTable;

namespace _3._1._5
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // 官方实现见：https://algs4.cs.princeton.edu/31elementary/SequentialSearchST.java.html
            string[] input = "S E A R C H E X A M P L E".Split(' ');
            var st = new SequentialSearchST<string, int>();

            for (int i = 0; i < input.Length; i++)
                st.Put(input[i], i);
            foreach (string s in st.Keys())
                Console.WriteLine(s + " " + st.Get(s));
        }
    }
}
