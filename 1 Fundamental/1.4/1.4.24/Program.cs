using System;

namespace _1._4._24
{
    /*
     * 1.4.24
     * 
     * 扔鸡蛋。
     * 假设你面前有一栋 N 层的大楼和许多鸡蛋，
     * 假设将鸡蛋从 F 层或者更高的地方扔下鸡蛋才会摔碎，否则则不会。
     * 首先，设计一种策略来确定 F 的值，其中扔 ~ lgN 次鸡蛋后摔碎的鸡蛋数量为 ~ lgN。
     * 然后想办法将成本降低到~ 2lgF。
     * 
     */
    class Program
    {
        static int F = 100;//需要寻找的 F 值
        struct testResult
        {
            public int F;
            public int BrokenEggs;
        }
        static void Main(string[] args)
        {
            int[] building = new int[100000];
            for (int i = 0; i < 100000; ++i)
            {
                building[i] = i;
            }
            //第一问：二分查找即可
            testResult A = PlanA(building);
            Console.WriteLine($"Plan A: F={A.F}, Broken Eggs={A.BrokenEggs}");

            //第二问：按照第 1, 2, 4, 8,..., 2^k 层顺序查找，一直到 2^k > F，
            //随后在 [2^(k - 1), 2^k] 范围中二分查找。
            testResult B = PlanB(building);
            Console.WriteLine($"Plan B: F={B.F}, Broken Eggs={B.BrokenEggs}");
        }

        /// <summary>
        /// 扔鸡蛋，没碎返回 true，碎了返回 false。
        /// </summary>
        /// <param name="floor">扔鸡蛋的高度。</param>
        /// <returns></returns>
        static bool ThrowEgg(int floor)
        {
            return floor <= F;
        }

        /// <summary>
        /// 第一种方案。
        /// </summary>
        /// <param name="a">大楼。</param>
        /// <returns></returns>
        static testResult PlanA(int[] a)
        {
            int lo = 0;
            int hi = a.Length - 1;
            int mid = 0;
            int eggs = 0;
            testResult result = new testResult();

            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                if (ThrowEgg(mid))
                {
                    lo = mid + 1;
                }
                else
                {
                    eggs++;
                    hi = mid - 1;
                }
            }

            result.BrokenEggs = eggs;
            result.F = hi;
            return result;
        }

        /// <summary>
        /// 第二种方案。
        /// </summary>
        /// <param name="a">大楼。</param>
        /// <returns></returns>
        static testResult PlanB(int[] a)
        {
            int lo = 0;
            int hi = 1;
            int mid = 0;
            int eggs = 0;
            testResult result = new testResult();

            while (ThrowEgg(hi))
            {
                lo = hi;
                hi *= 2;
            }
            eggs++;

            if (hi > a.Length - 1)
            {
                hi = a.Length - 1;
            }

            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                if (ThrowEgg(mid))
                {
                    lo = mid + 1;
                }
                else
                {
                    eggs++;
                    hi = mid - 1;
                }
            }

            result.BrokenEggs = eggs;
            result.F = hi;
            return result;
        }
    }
}
