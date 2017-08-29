using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._40
{
    /*
     * 1.4.40
     * 
     * 随机输入下的 3-sum 问题。
     * 猜测找出 N 个随机 int 值中和为 0 的整数三元组的数量所需的时间并验证你的猜想。
     * 如果你擅长数学分析，请为此问题给出一个合适的数学模型，
     * 其中所有值均匀的分布在 -M 和 M 之间，且 M 不能是一个小整数。
     * 
     */
    class Program
    {
        // 数学模型
        // 
        // N 个数可组成的三元组的总数为：
        // C(N, 3) = N(N-1)(N-2)/3! = ~ (N^3)/6 （组合数公式）
        // [-M, M]中随机 N 次，有 (2M+1)^N 种随机序列（每次随机都有 2M+1 种可能）
        // 按照分步计数方法，将随机序列分为和为零的三元组和其余 N-3 个数
        // 这些序列中，和为零的三元组有 3M^2 + 3M + 1 种可能。
        // 其他不为零的 N-3 个位置有 (2M+1)^(N-3) 种可能。
        // 总共有 ((N^3)/6) * (3M^2 + 3M + 1) * (2M+1)^(N-3) 种可能性
        // 平均值为：
        // [((N^3)/6) * (3M^2 + 3M + 1) * (2M+1)^(N-3)] / (2M+1)^N
        // (N^3) * (3M^2 + 3M + 1) / 6 * (2M+1)^3
        // ~ N^3 * 3M^2 / 6 * 8M^3
        // N^3/16M
        static void Main(string[] args)
        {
            int M = 10000;

            for (int n = 125; n < 10000; n += n)
            {
                Random random = new Random();
                int[] a = new int[n];
                for (int i = 0; i < n; ++i)
                {
                    a[i] = random.Next(2 * M) - M;
                }
                Console.WriteLine($"N={n}, 计算值={Math.Pow(n, 3) / (16 * M)}, 实际值={ThreeSum.Count(a)}");
            }
        }
    }
}
