using System;
using Measurement;

namespace _1._4._11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] { 5, 5, 5, 5, 1 };
            StaticSETofInts set = new StaticSETofInts(a);
            Console.WriteLine(set.HowMany(5));
        }
    }
}
