using System;
using Measurement;

namespace _1._4._21
{
    
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
