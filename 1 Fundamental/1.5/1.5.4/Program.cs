using System;
using UnionFind;

namespace _1._5._4
{

    class Program
    {
        static void Main(string[] args)
        {
            char[] split = { '\n', '\r' };
            string[] inputReference = TestCase.Properties.Resources.tinyUF.Split(split, StringSplitOptions.RemoveEmptyEntries);
            string[] inputWorst = TestCase.Properties.Resources.worstUF.Split(split, StringSplitOptions.RemoveEmptyEntries);

            RunTest(inputReference);
            Console.WriteLine("-------------------------------------");
            RunTest(inputWorst);
        }

        static void RunTest(string[] input)
        {
            var weightedQuickUnion = new WeightedQuickUnionUF(10);
            int n = int.Parse(input[0]);
            int[] parent = weightedQuickUnion.GetParent();
            int[] size = weightedQuickUnion.GetSize();

            for (int i = 1; i < input.Length; i++)
            {
                string[] unit = input[i].Split(' ');
                int p = int.Parse(unit[0]);
                int q = int.Parse(unit[1]);

                Console.WriteLine($"{p} {q}");
                weightedQuickUnion.Union(p, q);

                Console.Write("index:\t");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();

                Console.Write("parent:\t");
                foreach (int m in parent)
                {
                    Console.Write(m + " ");
                }
                Console.WriteLine();
                Console.Write("size:\t");
                foreach (int m in size)
                {
                    Console.Write(m + " ");
                }
                Console.WriteLine();
                Console.WriteLine("parent visit count:" + weightedQuickUnion.ArrayParentVisitCount);
                Console.WriteLine("size visit count:" + weightedQuickUnion.ArraySizeVisitCount);
                Console.WriteLine();
                weightedQuickUnion.ResetArrayCount();
            }
        }
    }
}
