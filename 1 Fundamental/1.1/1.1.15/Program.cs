using System;
using System.Linq;

namespace _1._1._15
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[10];
            var M = 10;
            for (var i = 0; i < 10; i++)
            {
                a[i] = i;
            }

            var result = Histogram(a, M);

            Console.WriteLine($"a.length: {a.Length}");
            Console.WriteLine($"sum of result array: {result.Sum()}");
        }

        static int[] Histogram(int[] a, int M)
        {
            var result = new int[M];

            for (var i = 0; i < M; i++)
            {
                // 初始化
                result[i] = 0;

                // 遍历数组，计算数组中值为 i 的元素个数
                for (var j = 0; j < a.Length; j++)
                {
                    if (a[j] == i) // 值为 i 的元素
                    {
                        result[i]++;
                    }
                }
            }

            return result;
        }
    }
}