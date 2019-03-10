using System;
using System.Diagnostics;
using SymbolTable;

namespace _3._1._34
{
    /*
     * 3.1.34
     * 
     * Zipf 法则。
     * 用命中第 i 小的键的概率为 1/(iHN) 的分布重新完成上一道练习，
     * 其中 Hn 为调和级数（请见表 1.4.6）。
     * 这种分布被称为 Zipf 法则。
     * 比较前移编码和上一道练习中的在特定分布下的最优安排，
     * 该安排将所有键按升序排列（即按照它们的期望频率的降序排列）。
     * 
     */
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int n = 1000;
            int multiplyBy10 = 4;

            // 调和级数
            double[] harmonicNumber = new double[n * (int)Math.Pow(10, multiplyBy10)];
            harmonicNumber[0] = 1;
            for (int i = 1; i < harmonicNumber.Length; i++)
            {
                harmonicNumber[i] = harmonicNumber[i - 1] + 1 / (i + 1);
            }

            for (int i = 0; i < multiplyBy10; i++)
            {
                Console.WriteLine("n=" + n);
                // 构造表
                MoveToFrontArrayST<string, int> mst1 = new MoveToFrontArrayST<string, int>(n);
                MoveToFrontArrayST<string, int> mst2 = new MoveToFrontArrayST<string, int>(n);
                string[] keys = SearchCompare.GetRandomArrayString(n, 3, 20);
                for (int j = 0; j < n; j++)
                {
                    mst1.Put(keys[j], j);
                    mst2.Put(keys[j], j);
                }
                // 构造查询
                Array.Sort(keys);
                string[] queryZipf = new string[10 * n];
                int queryIndex = 0, keyIndex = 0;
                while (queryIndex < queryZipf.Length)
                {
                    int searchTimes = (int)Math.Ceiling(queryZipf.Length / (harmonicNumber[keyIndex + 1] * (i + 1)));

                    for (int j = 0; j < searchTimes && queryIndex < queryZipf.Length; j++)
                    {
                        queryZipf[queryIndex++] = keys[keyIndex];
                    }
                    keyIndex++;
                }

                string[] querys = new string[10 * n];
                queryIndex = 0;
                keyIndex = 0;
                while (queryIndex < querys.Length)
                {
                    int searchTimes = (int)Math.Ceiling((Math.Pow(0.5, keyIndex + 1) * querys.Length));

                    for (int j = 0; j < searchTimes && queryIndex < querys.Length; j++)
                    {
                        querys[queryIndex++] = keys[keyIndex];
                    }
                    keyIndex++;
                }
                // Shuffle(querys);

                Stopwatch sw = new Stopwatch();
                // 测试 3.1.33 的序列
                sw.Start();
                for (int j = 0; j < queryZipf.Length; j++)
                {
                    mst1.Get(querys[j]);
                }
                sw.Stop();
                Console.WriteLine("3.1.33 Best: " + sw.ElapsedMilliseconds);

                // 测试 Zipf
                sw.Restart();
                for (int j = 0; j < queryZipf.Length; j++)
                {
                    mst2.Get(queryZipf[j]);
                }
                sw.Stop();
                Console.WriteLine("Zipf: " + sw.ElapsedMilliseconds);

                n *= 10;
            }
        }

        static void Shuffle<T>(T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                int r = i + random.Next(data.Length - i);
                T temp = data[r];
                data[r] = data[i];
                data[i] = temp;
            }
        }
    }
}
