using System;
using SymbolTable;

namespace _3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "S E A R C H E X A M P L E".Split(' ');
            var arrayST = new ArrayST<string, int>();

            for (var i = 0; i < input.Length; i++)
                arrayST.Put(input[i], i);

            foreach (var s in arrayST.Keys())
                Console.WriteLine(s + " " + arrayST.Get(s));
        }
    }
}