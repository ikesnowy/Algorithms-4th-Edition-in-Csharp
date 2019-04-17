using System;

namespace _2._5._31
{
    
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
