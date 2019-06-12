using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2._7
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTRecursive<int, int> recursiveAvgCompare = new BSTRecursive<int, int>();
            BSTConstant<int, int> constantAvgCompare = new BSTConstant<int, int>();

            int[] testCase = { 5, 6, 2, 3, 9, 1, 0, 7 };

            foreach (int key in testCase)
            {
                recursiveAvgCompare.Put(key, key);
                constantAvgCompare.Put(key, key);
            }

            Console.WriteLine("Recursive AvgCompare Method:");
            Console.WriteLine(recursiveAvgCompare);
            Console.WriteLine("Avg Compare: " + recursiveAvgCompare.AverageCompares());

            Console.WriteLine("Constant AvgCompare Method");
            Console.WriteLine(constantAvgCompare);
            Console.WriteLine("Avg Compare: " + constantAvgCompare.AverageCompares());
        }
    }
}
