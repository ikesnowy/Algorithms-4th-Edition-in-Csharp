using System;
using SymbolTable;

namespace _3._1._7
{
    
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            const int repeatTime = 50;
            const int multiplyBy10 = 6;
            int arraySize = 10;

            for (int i = 0; i < multiplyBy10; i++)
            {
                Console.Write("n=10^" + (i + 1) + "\t");
                int distinctSum = 0;
                for (int j = 0; j < repeatTime; j++)
                {
                    ST<int, int> st = new ST<int, int>();
                    int[] data = RandomArray(arraySize);
                    distinctSum += FrequencyCounter.CountDistinct(data, st);
                }
                Console.WriteLine(distinctSum / repeatTime);
                arraySize *= 10;
            }

        }

        static int[] RandomArray(int n)
        {
            int[] data = new int[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = random.Next(1000);
            }
            return data;
        }
    }
}
