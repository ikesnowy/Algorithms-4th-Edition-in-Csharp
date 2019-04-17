using System;
using SymbolTable;

namespace _3._1._24
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int repeatTimes = 20;
            int multiplyBy2 = 5;
            int n = 2000;

            for (int i = 0; i < multiplyBy2; i++)
            {
                Console.WriteLine("n=" + n);
                Console.WriteLine("Binary\tInterp\tRatio");
                long bstTimes = 0, istTimes = 0;

                for (int j = 0; j < repeatTimes; j++)
                {
                    BinarySearchST<double, int> bst = new BinarySearchST<double, int>();
                    InterpolationSearchST ist = new InterpolationSearchST();
                    double[] data = SearchCompare.GetRandomArrayDouble(n);

                    bstTimes += SearchCompare.Time(bst, data);
                    istTimes += SearchCompare.Time(ist, data);
                }
                Console.WriteLine(bstTimes / repeatTimes + "\t" + istTimes / repeatTimes + "\t" + (double)bstTimes / istTimes);
                n *= 2;
            }
        }
    }
}
