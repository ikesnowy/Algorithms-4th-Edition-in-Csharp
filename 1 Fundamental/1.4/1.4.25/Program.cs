using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._25
{
    /*
     * 1.4.25
     * 
     * 扔两个鸡蛋。
     * 和上一题相同的问题，但现在假设你只有两个鸡蛋，而你的成本模型则是扔鸡蛋的次数。
     * 设计一种策略，最多扔 2√(N) 次鸡蛋即可判断出 F 的值，
     * 然后想办法把这个成本降低到 ~c√(F) 次。
     * 这和查找命中（鸡蛋完好无损）比未命中（鸡蛋被摔碎）的成本小得多的情形类似。
     * 
     */
    class Program
    {
        static int F = 100;//需要寻找的 F 值
        struct testResult
        {
            public int F;
            public int BrokenEggs;
            public int ThrowTimes;
        }
        static void Main(string[] args)
        {
            int[] building = new int[100000];
            for (int i = 0; i < 100000; ++i)
            {
                building[i] = i;
            }
            //第一问：第一个蛋按照 √(N), 2√(N), 3√(N), 4√(N),..., √(N) * √(N) 顺序查找直至碎掉。这里扔了 k 次，k <= √(N)
            //k-1√(N) ~ k√(N) 顺序查找直至碎掉，F 值就找到了。这里最多扔 √(N) 次。
            testResult A = PlanA(building);
            Console.WriteLine($"Plan A: F={A.F}, Broken Eggs={A.BrokenEggs}, Throw Times={A.ThrowTimes}");

            //第二问：按照第 1, 3, 6, 10,..., 1/2k^2 层顺序查找，一直到 1/2k^2 > F，
            //随后在 [1/2k^2 - k, 1/2k^2] 范围中顺序查找。
            testResult B = PlanB(building);
            Console.WriteLine($"Plan B: F={B.F}, Broken Eggs={B.BrokenEggs}, Throw Times={B.ThrowTimes}");
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
            int hi = 0; 
            int eggs = 0;
            int throwTimes = 0;
            testResult result = new testResult();

            while (ThrowEgg(hi))
            {
                throwTimes++;
                lo = hi;
                hi += (int)Math.Sqrt(a.Length);
            }
            eggs++;

            if (hi > a.Length - 1)
            {
                hi = a.Length - 1;
            }

            while (lo <= hi)
            {
                if (!ThrowEgg(lo))
                {
                    eggs++;
                    break;
                }
                throwTimes++;
                lo++;
            }

            result.BrokenEggs = eggs;
            result.F = lo - 1;
            result.ThrowTimes = throwTimes;
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
            int hi = 0;
            int eggs = 0;
            int throwTimes = 0;
            testResult result = new testResult();

            for (int i = 0; ThrowEgg(hi); ++i)
            {
                throwTimes++;
                lo = hi;
                hi += i;
            }
            eggs++;

            if (hi > a.Length - 1)
            {
                hi = a.Length - 1;
            }

            while (lo <= hi)
            {
                if (!ThrowEgg(lo))
                {
                    eggs++;
                    break;
                }
                lo++;
                throwTimes++;
            }

            result.BrokenEggs = eggs;
            result.F = lo - 1;
            result.ThrowTimes = throwTimes;
            return result;
        }
    }
}
