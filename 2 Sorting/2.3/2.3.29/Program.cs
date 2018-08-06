using System;
using Quick;

namespace _2._3._29
{
    /*
     * 2.3.29
     * 
     * 随机化。
     * 用经验性的研究对比随机选择切分元素和正文所述的一开始就将数组随机化这两种策略的效果。
     * 在子数组大小为 M 时进行切换，将大小为 N 的不重复数组排序，
     * 其中 M=10、20 和 50，N=10^3、10^4、10^5 和 10^6。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M\tN\tshuffle\trandom\tshuffle/random");
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
            QuickSortInsertion withShuffle = new QuickSortInsertion();
            QuickSortRandomPivot randomPivot = new QuickSortRandomPivot();
            int trialTime = 5;

            // M=10
            withShuffle.M = m;
            randomPivot.M = m;
            double timeShuffle = 0;
            double timeRandomPivot = 0;
            for (int N = 1000; N < 10000000; N *= 10)
            {
                for (int i = 0; i < trialTime; i++)
                {
                    int[] a = new int[N];
                    int[] b = new int[N];
                    for (int j = 0; j < N; j++)
                    {
                        a[j] = j;
                    }
                    Shuffle(a);
                    a.CopyTo(b, 0);
                    timeShuffle += SortCompare.Time(withShuffle, a);
                    timeRandomPivot += SortCompare.Time(randomPivot, b);
                }
                timeShuffle /= trialTime;
                timeRandomPivot /= trialTime;
                Console.WriteLine(withShuffle.M + "\t" + N + "\t" + timeShuffle + "\t" + timeRandomPivot + "\t" + timeShuffle / timeRandomPivot);
            }
        }

        /// <summary>
        /// 打乱数组。
        /// </summary>
        /// <typeparam name="T">需要打乱的数组类型。</typeparam>
        /// <param name="a">需要打乱的数组。</param>
        static void Shuffle<T>(T[] a)
        {
            Random random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                int r = i + random.Next(a.Length - i);
                T temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }
    }
}
