using System;
using Sort;

namespace _2._1._24
{
    class Program
    {
        static void Main(string[] args)
        {
            // 耗时 1019ms（@Surface Pro 3 i7 512G）
            Console.WriteLine(SortCompare.TimeRandomInput(new InsertionSort(), 10000, 3) / 3.0);
            // 耗时 925ms（@Surface Pro 3 i7 512G）
            Console.WriteLine(SortCompare.TimeRandomInput(new Sort.InsertionSort(), 10000, 3) / 3.0);
        }
    }
}
