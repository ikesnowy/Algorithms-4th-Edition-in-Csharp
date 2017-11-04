using System;
using System.Linq;

namespace _1._1._15
{
    /*
     * 1.1.15
     * 
     * 编写一个静态方法 histogram()，
     * 接受一个整型数组 a[] 和一个整数 M 作为参数并返回一个大小为 M 的数组，
     * 其中第 i 个元素的值为整数 i 在参数数组中出现的次数。
     * 如果 a[] 中的值均在 0 到 M-1 之间，
     * 返回数组中所有元素之和应该和 a.length 相等。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10];
            int M = 10;
            for (int i = 0; i < 10; i++)
            {
                a[i] = i;
            }

            int[] result = Histogram(a, M);

            Console.WriteLine($"a.length: {a.Length}");
            Console.WriteLine($"sum of result array: {result.Sum()}");
        }

        static int[] Histogram(int[] a, int M)
        {
            int[] result = new int[M];

            for (int i = 0; i < M; i++)
            {
                // 初始化
                result[i] = 0;

                // 遍历数组，计算数组中值为 i 的元素个数
                for (int j = 0; j < a.Length; j++)
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
