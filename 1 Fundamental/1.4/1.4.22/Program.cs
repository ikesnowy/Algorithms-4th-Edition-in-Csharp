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
            int[] a = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = -1; i < 11; ++i)
            {
                Console.WriteLine(rank(a, i));
            }
        }

        // 用斐波那契数列作为缩减范围的依据
        static int rank(int[] a, int key)
        {
            int Fk = 1;
            int Fk_1 = 1;
            int Fk_2 = 0;

            // 得 Fk，Fk需要大于等于数组的大小，复杂度 lgN
            while (Fk < a.Length)
            {
                Fk = Fk + Fk_1;
                Fk_1 = Fk_1 + Fk_2;
                Fk_2 = Fk - Fk_1;
            }

            int lo = 0;

            // 照斐波那契数列缩减查找范围，复杂度 lgN
            while (Fk_2 >= 0)
            {
                int i = lo + Fk_2 > a.Length - 1 ? a.Length - 1 : lo + Fk_2;
                if (a[i] < key)
                {
                    lo = lo + Fk_2;
                }
                else if (a[i] == key)
                {
                    return i;
                }
                Fk = Fk_1;
                Fk_1 = Fk_2;
                Fk_2 = Fk - Fk_1;
            }

            return -1;
        }
    }
}
