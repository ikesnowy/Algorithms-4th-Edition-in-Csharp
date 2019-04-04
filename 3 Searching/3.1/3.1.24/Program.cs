using System;
using SymbolTable;

namespace _3._1._24
{
    /*
     * 3.1.24
     * 
     * 插值法查找。
     * 假设符号表的键支持算术操作
     * （例如，它们可能是 Double 或者 Integer 类型的值）。
     * 编写一个二分查找来模拟查字典的行为，
     * 例如当单词的首字母在字母表的开头时我们也会在字典的前半部分进行查找。
     * 具体来说，设 klo 为符号表的第一个键，khi 为符号表的最后一个键，
     * 当要查找 kx 时，先和 [(kx-klo)/(khi-klo)] 进行比较，而非取中间元素。
     * 用 SearchCompare 调用 FrequencyCounter 来比较你的实现和 BinarySearchST 的性能。
     * 
     */
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
