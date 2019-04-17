using System;
using SymbolTable;

namespace _3._1._31
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            int multiplyBy2 = 5;
            int repeatTime = 3;
            int averageHit = 10;

            for (int i = 0; i < multiplyBy2; i++)
            {
                Console.WriteLine("n = " + n);
                long sumSequential = 0, sumBinary = 0;
                for (int j = 0; j < repeatTime; j++)
                {
                    sumBinary += SearchCompare.Performance(new BinarySearchST<string, int>(), n, averageHit);
                    sumSequential += SearchCompare.Performance(new SequentialSearchST<string, int>(), n, averageHit);
                }
                Console.WriteLine("BinarySearchST: " + sumBinary / repeatTime);
                Console.WriteLine("SequentialSearchST: " + sumSequential / repeatTime);
                n *= 2;
            }          
        }
    }
}
