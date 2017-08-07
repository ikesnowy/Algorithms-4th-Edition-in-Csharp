using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._22
{
    /*
     * 1.4.22
     * 
     * 仅用加减实现的二分查找（Mihai Patrascu）。
     * 编写一个程序，给定一个含有 N 个不同 int 值的按照升序排列的数组，
     * 判断它是否含有给定的整数。
     * 只能使用加法和减法以及常数的额外内存空间。
     * 程序的运行时间在最坏情况下应该和 logN 成正比。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {

        }

        //使用斐波那契数列作为缩减范围的依据
        static int rank(int[] a, int key)
        {
            int Fk = 1;
            int Fk_1 = 1;
            int lo = 0;
            int hi = lo + Fk;

            while (lo <= hi)
            {
                int Fk_2 = Fk - Fk_1;
                if (a[lo + Fk_2] < key)
                {
                    lo = lo + Fk_2;
                }
                else if (a[lo + Fk_2] > key)
                {
                    hi = lo + Fk_2;
                }
                else
                {
                    return lo + Fk_2;
                }

            }
        }
    }
}
