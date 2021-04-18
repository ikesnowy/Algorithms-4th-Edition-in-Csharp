﻿using System;
using SymbolTable;

namespace _3._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "S E A R C H E X A M P L E".Split(' ');
            var arraySt = new ArraySt<string, int>();

            for (var i = 0; i < input.Length; i++)
                arraySt.Put(input[i], i);

            foreach (var s in arraySt.Keys())
                Console.WriteLine(s + " " + arraySt.Get(s));
        }
    }
}