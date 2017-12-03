using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._19
{
    /*
     * 2.1.19
     * 
     * 希尔排序的最坏情况。
     * 用 1 到 100 构造一个含有 100 个元素的数组并用希尔排序和
     * 递增序列 1 4 13 40 对其排序，
     * 使比较次数尽可能多。
     * 
     */
    class Program
    {
        // 参照插入排序的最坏情况
        // 每个 h 排序都可以算是插入排序，逆向构造最坏情况即可
        static void Main(string[] args)
        {
            int?[] a = new int?[100];
            int[] p = new int[4] { 40, 13, 4, 1 };
            int l = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 99; j >= 0; j -= p[i])
                {
                    if (a[j] != null)
                    {
                        continue;
                    }
                    a[j] = l;
                    l++;
                }
            }

            int[] b = new int[100];
            for (int i = 0; i < 100; i++)
            {
                b[i] = (int)a[i];
            }

            ShellSort sort = new ShellSort();
            sort.Sort(b);

            b = ShellSortWorstCase.GetWorst(p, 100);
            sort.Sort(b);
        }
    }
}
