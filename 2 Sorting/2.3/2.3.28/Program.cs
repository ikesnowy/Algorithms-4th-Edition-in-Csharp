using System;

namespace _2._3._28
{
    /*
     * 2.3.28
     * 
     * 递归深度。
     * 用经验性的研究估计切换阈值为 M 的快速排序
     * 在将大小为 N 的不重复数组排序时的平均递归深度，
     * 其中 M=10、20 和 50，N=10^3、10^4、10^5 和 10^6。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M\tN\tDepth");
            Trial(10);
            Trial(20);
            Trial(50);
        }

        /// <summary>
        /// 进行一次测试。
        /// </summary>
        /// <param name="m">要使用的阈值</param>
        static void Trial(int m)
        {
            QuickSortInsertion sort = new QuickSortInsertion();
            int trialTime = 5;

            // 由于排序前有 Shuffle，因此直接输入有序数组。
            // M=10
            sort.M = m;
            int totalDepth = 0;
            for (int N = 1000; N < 10000000; N *= 10)
            {
                for (int i = 0; i < trialTime; i++)
                {
                    int[] a = new int[N];
                    for (int j = 0; j < N; j++)
                    {
                        a[j] = j;
                    }
                    sort.Sort(a);
                    totalDepth += sort.Depth;
                }
                Console.WriteLine(sort.M + "\t" + N + "\t" + totalDepth / trialTime);
            }
        }
    }
}
