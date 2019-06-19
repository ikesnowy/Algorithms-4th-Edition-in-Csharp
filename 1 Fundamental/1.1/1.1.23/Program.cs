using System;
using System.IO;

namespace _1._1._23
{
    class Program
    {
        static void Main(string[] args)
        {
            // 从largeW.txt中读取数据
            var whiteList = File.ReadAllLines("largeW.txt");
            var WhiteList = new int[whiteList.Length];

            for (var i = 0; i < whiteList.Length; i++)
            {
                WhiteList[i] = int.Parse(whiteList[i]);
            }

            Array.Sort<int>(WhiteList);

            Console.WriteLine("Type the numbers you want to query: ");
            // 输入样例：5 824524 478510 387221
            var input = Console.ReadLine();
            var Query = new int[input.Split(' ').Length];
            for (var i = 0; i < Query.Length; i++)
            {
                Query[i] = int.Parse(input.Split(' ')[i]);
            }

            Console.WriteLine("Type '+' to get the numbers that not in the whitelist," +
                "'-' to get the numbers that in the whitelist.");
            var operation = Console.ReadLine()[0];

            foreach (var n in Query)
            {
                if (rank(n, WhiteList) == -1)
                {
                    if (operation == '+')
                    {
                        Console.WriteLine(n);
                    }
                }
                else if (operation == '-')
                {
                    Console.WriteLine(n);
                }
            }
        }

        /// <summary>
        /// 二分查找，默认查找整个数组。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <returns></returns>
        public static int rank(int key, int[] a)
        {
            return rank(key, a, 0, a.Length - 1);
        }

        /// <summary>
        /// 二分查找。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <param name="lo">查找的下界。</param>
        /// <param name="hi">查找的上界。</param>
        /// <returns></returns>
        public static int rank(int key, int[] a, int lo, int hi)
        {

            if (lo > hi)
            {
                return -1;
            }

            var mid = lo + (hi - lo) / 2;

            if (key < a[mid])
            {
                return rank(key, a, lo, mid - 1);
            }
            else if (key > a[mid])
            {
                return rank(key, a, mid + 1, hi);
            }
            else
            {
                return mid;
            }
        }
    }
}