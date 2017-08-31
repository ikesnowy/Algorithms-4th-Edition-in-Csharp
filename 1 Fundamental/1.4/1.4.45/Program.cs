using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._45
{
    /*
     * 1.4.45
     * 
     * 优惠券收集问题。
     * 用和上一题相同的方式生成随机整数。
     * 通过实验验证生成所有可能的整数值所需生成的随机数总量为 ~NHN。
     * （这里的 HN 中 N 是下标）
     * 
     */
    class Program
    {
        // HN 指的是调和级数
        static void Main(string[] args)
        {
            Random random = new Random();
            int N = 10000;
            bool[] a = new bool[N];
            int randomSize = 0;
            int times = 0;
            for (times = 0; times < 20; ++times)
            {
                for (int i = 0; i < N; ++i)
                {
                    a[i] = false;
                }
                for(int i = 0; true; ++i)
                {
                    int now = random.Next(N);
                    a[now] = true;
                    if (IsAllGenerated(a))
                    {
                        randomSize += i;
                        Console.WriteLine($"生成{i}次后所有可能均出现过了");
                        break;
                    }
                }
            }
            Console.WriteLine($"\nNHN={N * HarmonicSum(N)}，平均生成{randomSize / times}个数字后所有可能都出现");
        }

        static double HarmonicSum(int N)
        {
            double sum = 0;
            for (int i = 1; i <= N; ++i)
            {
                sum += 1.0 / i;
            }
            return sum;
        }

        static bool IsAllGenerated(bool[] a)
        {
            foreach (bool i in a)
            {
                if (!i)
                    return false;
            }
            return true;
        }
    }
}
