using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._18
{
    /*
     * 1.4.18
     * 
     * 数组的局部最小元素。
     * 编写一个程序，给定一个含有 N 个不同整数的数组，找到一个局部最小元素：
     * 满足 a[i] < a[i-1]，且 a[i] < a[i+1] 的索引 i。
     * 程序在最坏情况下所需的比较次数为 ~ 2lgN。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            char[] spliter = new char[] { '\n' };
            string[] temp = TestCase.Properties.Resources._2Kints.Split(spliter, StringSplitOptions.RemoveEmptyEntries);
            int[] testcases = new int[temp.Length];
            for (int i = 0; i < temp.Length; ++i)
            {
                testcases[i] = int.Parse(temp[i]);
            }

            int[] a = new int[5] { 5, 6, 5, 3, 5 };
            Console.WriteLine(LocalMinimum(a));
        }

        static int LocalMinimum(int[] testcases)
        {
            int lo = 0;
            int hi = testcases.Length - 1;
            int mid = (hi - lo) / 2 + lo;
            while (lo < hi)
            {
                mid = (hi - lo) / 2 + lo;
                if (testcases[mid] < testcases[mid - 1] && testcases[mid] < testcases[mid + 1])
                {
                    return mid;
                }
                else
                {
                    if (testcases[mid - 1] < testcases[mid + 1])
                    {
                        hi = mid - 1;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
            }
            return -1;
        }
    }
}
