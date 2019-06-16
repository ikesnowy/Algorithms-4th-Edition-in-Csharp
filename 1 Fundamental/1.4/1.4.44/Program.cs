using System;

namespace _1._4._44
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int N = 10000;
            int[] a = new int[N];
            int dupNum = 0;
            int times = 0;
            for (times = 0; times < 500; times++)
            {
                for (int i = 0; i < N; i++)
                {
                    a[i] = random.Next(N);
                    if (IsDuplicated(a, i))
                    {
                        dupNum += i;
                        Console.WriteLine($"生成{i + 1}个数字后发生重复");
                        break;
                    }
                }
            }
            Console.WriteLine($"√(πN/2)={Math.Sqrt(Math.PI * N / 2.0)}，平均生成{dupNum / times}个数字后出现重复");
        }

        /// <summary>
        /// 检查是否有重复的数字出现。
        /// </summary>
        /// <param name="a">需要检查的数组。</param>
        /// <param name="i">当前加入数组元素的下标。</param>
        /// <returns>有重复则返回 true，否则返回 false。</returns>
        static bool IsDuplicated(int[] a, int i)
        {
            for (int j = 0; j < i; j++)
            {
                if (a[j] == a[i])
                {
                    return true;
                }
            }
            return false;
        }

    }
}
