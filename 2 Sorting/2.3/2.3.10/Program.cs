using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._10
{
    /*
     * 2.3.10
     * 
     * Chebyshev 不等式表明，
     * 一个随机变量的标准差距离均值大于 k 的概率小于 1/k^2 。
     * 对于 N=100 万，
     * 用 Chebyshev 不等式计算快速排序所使用的比较次数大于 1000 亿次的概率（0.1N^2）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 切比雪夫不等式（Chebyshev's inequality）
            // P(|X-μ| ≥ kσ) ≤ 1/(k^2)
            // 其中 μ 是期望，σ 是标准差。
            // 在快速排序的比较次数中，μ=2NlnN，σ=0.65N
            // （这两个结论可以见 2.3 节的命题 K 和命题 L）
            // 题目中要求比较次数大于 0.1N^2，可以得到等式：
            // 0.65N * k = 0.1N^2
            // k = 2/13 * N
            // 将 N = 1 000 000 代入
            // P(|X-27 631 021| ≥ 100 000 000 000) ≤ 0.00000000004225
            // P ≤ 0.000000004225 %
            double N = 10000000;
            double k = 0.1 * N / 0.65;
            Console.WriteLine(1.0 / (k * k));//4.225x10^-13
        }
    }
}
