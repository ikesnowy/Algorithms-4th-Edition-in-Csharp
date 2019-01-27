using System;

namespace _2._5._31
{
    /*
     * 2.5.31
     * 
     * 重复元素。
     * 编写一段程序，接受命令行参数 M、N 和 T，
     * 然后使用正文中的代码进行 T 遍实验：
     * 生成 N 个 0 到 M-1 间的 int 值并计算重复值的个数。
     * 令 T=10，N=10^3、10^4、10^5 和 10^6 
     * 以及 M = N/2、N 以及 2N。
     * 根据概率论，重复值的个数应该约为 M(1-e^(-α))，
     * 其中 α=N/M。打印一张表格来确认你的实验验证了这个公式。
     * 
     */
    class Program
    {
        /// <summary>
        /// 计算数组中重复元素的个数。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a">需要计算重复元素的数组。</param>
        /// <returns></returns>
        static int Distinct<T>(T[] a) where T : IComparable<T>
        {
            if (a.Length == 0)
                return 0;
            Array.Sort(a);
            int distinct = 1;
            for (int i = 1; i < a.Length; i++)
                if (a[i].CompareTo(a[i - 1]) != 0)
                    distinct++;
            return distinct;
        }

        static void Main(string[] args)
        {
            int T = 10;                 // 重复次数
            int n = 1000;               // 数组初始大小
            int nMultipleBy10 = 4;      // 数组大小 ×10 的次数
            int mMultipleBy2 = 3;       // 数据范围 ×2  的次数

            Random random = new Random();
            for (int i = 0; i < nMultipleBy10; i++)
            {
                Console.WriteLine("n=" + n);
                Console.WriteLine("\tm\temprical\ttheoretical");
                int m = n / 2;
                for (int j = 0; j < mMultipleBy2; j++)
                {
                    int distinctSum = 0;
                    for (int k = 0; k < T; k++)
                    {
                        int[] data = new int[n];
                        for (int l = 0; l < n; l++)
                            data[l] = random.Next(m);
                        distinctSum += Distinct(data);
                    }
                    double empirical = (double)distinctSum / T;
                    double alpha = (double)n / m;
                    double theoretical = m * (1 - Math.Exp(-alpha));
                    Console.WriteLine("\t" + m + "\t" + empirical + "\t" + theoretical); 
                    m *= 2;
                }
                n *= 10;
            }
        }
    }
}
