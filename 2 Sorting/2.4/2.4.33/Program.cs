using System;
using PriorityQueue;

namespace _2._4._33
{
    /*
     * 2.4.33
     * 
     * 索引优先队列的实现。
     * 按照 2.4.4.6 节的描述
     * 修改算法 2.6 来实现索引优先队列 API 中的基本操作：
     * 使用 pq[] 保存索引，添加一个数组 keys[] 来保存元素，
     * 再添加一个数组 qp[] 来保存 pq[] 的逆序——
     * qp[i] 的值是 i 在 pq[] 中的位置
     * （即索引 j，pq[j]=i）。
     * 修改算法 2.6 的代码来维护这些数据结构。
     * 若 i 不在队列之中，
     * 则总是令 qp[i] = -1 并添加一个方法 contains() 来检测这种情况。
     * 你需要修改辅助函数 exch() 和 less()，
     * 但不需要修改 sink() 和 swim()。
     * 
     */
    class Program
    {
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
