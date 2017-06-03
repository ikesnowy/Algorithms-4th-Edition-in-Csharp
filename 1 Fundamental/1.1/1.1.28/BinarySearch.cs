using System;
using System.Collections.Generic;
using System.IO;

namespace _1._1._28
{
    /*
     * 1.1.28
     * 
     * 删除重复元素。
     * 修改 BinarySearch 类中的测试用例来删去排序之后白名单中的所有重复元素。
     * 
     */
    class BinarySearch
    {
        static void Main(string[] args)
        {
            //从largeW.txt中读取数据
            //用 HashSet 的不可重复性去除重复
            HashSet<string> h = new HashSet<string>(File.ReadAllLines("largeW.txt"));
            string[] whiteList = new string[h.Count];
            h.CopyTo(whiteList);
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

            Console.WriteLine("Irrelevant:");
            foreach (int n in Query)
            {
                if (rank(n, WhiteList) == -1)
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