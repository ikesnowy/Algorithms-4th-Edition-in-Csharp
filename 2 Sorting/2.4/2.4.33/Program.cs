using System;
using PriorityQueue;

namespace _2._4._33
{
    
    class Program
    {
        // 书中算法 2.6 给出的是最大堆，但本题自带的部分解答是最小堆形式的。
        // 这里和官网保持一致，实现最大堆。
        // 官网答案：https://algs4.cs.princeton.edu/24pq/IndexMaxPQ.java.html
        static void Main(string[] args)
        {
            string[] input = new string[] { "it", "was", "the", "best", "of", "times", "it", "was", "the", "worst" };

            IndexMaxPQ<string> pq = new IndexMaxPQ<string>(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                pq.Insert(input[i], i);
            }

            foreach (var i in pq)
            {
                Console.WriteLine(i + ". " + input[i]);
            }

            Console.WriteLine();

            Random random = new Random();
            for (int i = 0; i < input.Length; i++)
            {
                if (random.NextDouble() < 0.5)
                    pq.IncreaseKey(i, input[i] + input[i]);
                else
                    pq.DecreaseKey(i, input[i].Substring(0, 1));
            }

            while (!pq.IsEmpty())
            {
                string key = pq.MaxKey();
                int i = pq.DelMax();
                Console.WriteLine(i + "." + key);
            }

            Console.WriteLine();

            for (int i = 0; i < input.Length; i++)
            {
                pq.Insert(input[i], i);
            }

            int[] param = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                param[i] = i;
            }

            Shuffle(param);

            for (int i = 0; i < param.Length; i++)
            {
                string key = pq.KeyOf(param[i]);
                pq.Delete(param[i]);
                Console.WriteLine(param[i] + "." + key);
            }
        }

        /// <summary>
        /// 打乱数组。
        /// </summary>
        /// <param name="a">需要打乱的数组。</param>
        static void Shuffle(int[] a)
        {
            int N = a.Length;
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                int r = i + random.Next(N - i);// 等于StdRandom.uniform(N-i)
                int temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }
    }
}
