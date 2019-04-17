using System;
using Quick;

namespace _2._3._29
{
    
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
