using System;

namespace _1._1._24
{
    /*
     * 1.1.24
     * 
     * 给出使用欧几里得算法计算 105 和 24 的最大公约数的过程中得到的一系列 p 和 q 的值。
     * 扩展该算法中的代码得到一个程序 Euclid，从命令行接受两个参数，
     * 计算它们的最大公约数并打印出每次调用递归方法时的两个参数。
     * 使用你的程序计算 1111111 和 1234567 的最大公约数。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            GCD(105, 24);
            Console.WriteLine();
            GCD(111111, 1234567);
        }

        /// <summary>
        /// 返回两个数的最大公约数。
        /// </summary>
        /// <param name="a">第一个数。</param>
        /// <param name="b">第二个数。</param>
        /// <returns></returns>
        public static int GCD(int a, int b)
        {
            Console.WriteLine($"{a} {b}");
            if (b == 0)
            {
                return a;
            }

            return GCD(b, a % b);
        }
    }
}