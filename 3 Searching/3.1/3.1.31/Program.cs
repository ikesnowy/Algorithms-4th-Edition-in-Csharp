using System;
using SymbolTable;

namespace _3._1._31
{
    /*
     * 3.1.31
     * 
     * 性能测试。
     * 编写一段性能测试程序，
     * 先用 put() 构造一张符号表，再用 get() 进行访问，
     * 使得表中的每个键平均被命中 10 次，且有大致相同次数的未命中访问。
     * 键为长度从 2 到 50 不等的随机字符串。
     * 重复这样的测试若干遍，记录每遍的运行时间，打印平均运行时间或将它们绘制成图。
     * 
     */
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
