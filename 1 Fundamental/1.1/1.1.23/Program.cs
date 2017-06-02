using System;
using System.IO;

namespace _1._1._23
{
    /*
     * 1.1.23
     * 
     * 为 BinarySearch 的测试用例添加一个参数：
     * +打印出标准输入中不在白名单上的值；
     * -则打印出标准输入中在白名单上的值。
     */
    class Program
    {
        static void Main(string[] args)
        {
            //从largeW.txt中读取数据
            string[] whiteList = File.ReadAllLines("largeW.txt");
            int[] WhiteList = new int[whiteList.Length];
            
            for (int i = 0; i < whiteList.Length; ++i)
            {
                WhiteList[i] = int.Parse(whiteList[i]);
            }

            Array.Sort<int>(WhiteList);

            Console.WriteLine("Type the numbers you want to query: ");
            //输入样例：5 824524 478510 387221
            string input = Console.ReadLine();
            int[] Query = new int[input.Split(' ').Length];
            for (int i = 0; i < Query.Length; ++i)
            {
                Query[i] = int.Parse(input.Split(' ')[i]);
            }

            Console.WriteLine("Type '+' to get the numbers that not in the whitelist," + 
                "'-' to get the numbers that in the whitelist.");
            char operation = Console.ReadLine()[0];

            foreach (int n in Query)
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

        //重载方法，用于启动二分查找
        public static int rank(int key, int[] a)
        {
            return rank(key, a, 0, a.Length - 1);
        }

        //二分查找
        public static int rank(int key, int[] a, int lo, int hi)
        {

            if (lo > hi)
            {
                return -1;
            }

            int mid = lo + (hi - lo) / 2;

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