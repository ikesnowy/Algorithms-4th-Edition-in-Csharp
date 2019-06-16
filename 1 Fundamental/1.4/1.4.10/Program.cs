using System;

namespace _1._4._10
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = 1;
            int[] a = new int[5] { 1, 1, 3, 4, 5 };

            Console.WriteLine($"The first index of {key} is {BinarySearch.Rank(key, a, 0, a.Length - 1)}");

        }
    }
}
