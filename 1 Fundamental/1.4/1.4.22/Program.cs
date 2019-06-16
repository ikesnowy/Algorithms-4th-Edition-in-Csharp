using System;

namespace _1._4._22
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = -1; i < 11; i++)
            {
                Console.WriteLine(rank(a, i));
            }
        }

        /// <summary>
        /// 使用斐波那契数列进行的查找。
        /// </summary>
        /// <param name="a">查找范围。</param>
        /// <param name="key">关键字。</param>
        /// <returns>返回查找到的关键值下标，没有结果则返回 -1。</returns>
        static int rank(int[] a, int key)
        {
            // 使用斐波那契数列作为缩减范围的依据
            int Fk = 1;
            int Fk_1 = 1;
            int Fk_2 = 0;

            // 获得 Fk，Fk需要大于等于数组的大小，复杂度 lgN
            while (Fk < a.Length)
            {
                Fk = Fk + Fk_1;
                Fk_1 = Fk_1 + Fk_2;
                Fk_2 = Fk - Fk_1;
            }

            int lo = 0;

            // 按照斐波那契数列缩减查找范围，复杂度 lgN
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
