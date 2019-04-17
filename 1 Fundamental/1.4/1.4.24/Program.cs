using System;

namespace _1._4._24
{
    
    class Program
    {
        static int F = 100;// 需要寻找的 F 值
        struct testResult
        {
            public int F;// 找到的 F 值。
            public int BrokenEggs;// 打碎的鸡蛋数。
        }
        static void Main(string[] args)
        {
            int[] building = new int[100000];
            for (int i = 0; i < 100000; i++)
            {
                building[i] = i;
            }
            // 第一问：二分查找即可
            testResult A = PlanA(building);
            Console.WriteLine($"Plan A: F={A.F}, Broken Eggs={A.BrokenEggs}");

            // 第二问：按照第 1, 2, 4, 8,..., 2^k 层顺序查找，一直到 2^k > F，
            // 随后在 [2^(k - 1), 2^k] 范围中二分查找。
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
