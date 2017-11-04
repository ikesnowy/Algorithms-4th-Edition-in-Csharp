using System;
using Measurement;

namespace _1._4._21
{
    /*
     * 1.4.21
     * 
     * 无重复值之中的二分查找。
     * 用二分查找实现 StaticSETofInts （参见表 1.2.15），
     * 保证 contains() 的运行时间为 ~lgR，其中 R 为参数数组中不同整数的数量。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            char[] split = new char[1] { '\n' };
            string[] input = TestCase.Properties.Resources._2Kints.Split(split, StringSplitOptions.RemoveEmptyEntries);
            int[] a = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                a[i] = int.Parse(input[i]);
            }
            StaticSETofInts array = new StaticSETofInts(a);
            Console.WriteLine(array.Contains(10000000));//False
            Console.WriteLine(array.Contains(-174307));//True
        }
    }
}
