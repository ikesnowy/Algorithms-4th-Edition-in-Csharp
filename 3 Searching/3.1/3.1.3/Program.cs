using System;
using SymbolTable;

namespace _3._1._3
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = "S E A R C H E X A M P L E".Split(' ');
            var orderedST = new OrderedSequentialSearchST<string, int>();

            for (int i = 0; i < input.Length; i++)
                orderedST.Put(input[i], i);
            foreach (string s in orderedST.Keys())
                Console.WriteLine(s + " " + orderedST.Get(s));
        }
    }
}
