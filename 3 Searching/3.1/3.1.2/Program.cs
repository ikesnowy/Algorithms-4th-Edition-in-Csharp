using System;
using SymbolTable;

namespace _3._1._2
{
    /*
     * 3.1.2
     * 
     * 开发一个符号表的实现 ArrayST，使用（无序）数组来实现我们的基本 API。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = "S E A R C H E X A M P L E".Split(' ');
            ArrayST<string, int> arrayST = new ArrayST<string, int>();

            for (int i = 0; i < input.Length; i++)
                arrayST.Put(input[i], i);

            foreach (string s in arrayST.Keys())
                Console.WriteLine(s + " " + arrayST.Get(s));
        }
    }
}
