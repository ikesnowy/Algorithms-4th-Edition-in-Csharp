using System;

namespace _1._4._17
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double[5] { 0.1, 0.3, 0.6, 0.8, 0 };
            double min = int.MaxValue;
            double max = int.MinValue;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
                if (a[i] < min)
                {
                    min = a[i];
                }
            }

            Console.WriteLine($"MaxDiff Pair: {min} {max}, Max Difference: {Math.Abs(max - min)}");
        }
    }
}
