using System;

namespace _1._1._35
{
    /*
     * 1.1.35
     * 
     * 模拟掷骰子。
     * 以下代码能够计算每种两个骰子之和的准确概率分布：
     * int SIDES = 6;
     * double[] dist = new double[2 * SIDES + 1];
     * for (int I = 1; i <= SIDES; i++)
     *     for (int j = 1; j <= SIDES; j++)
     *         dist[i + j] += 1.0;
     * 
     * for (int k = 2; k <= 2 * SIDES; k++)
     *     dist[k] /= 36.0;
     * dist[i] 的值就是两个骰子之和为 i 的概率。
     * 用实验模拟 N 次掷骰子，
     * 并在计算两个 1 到 6 之间的随机整数之和时记录每个值出现频率以验证它们的概率。
     * N 要多大才能够保证你的经验数据和准确数据的吻合程度达到小数点后 3 位？
     * 
     */
    class Program
    {
        // 序运行大概需要十几秒时间（也可能更长，看运气）
        // 的数据：
        // 4098 44448 37776 44401 32541
        static void Main(string[] args)
        {
            // 中给出的程序
            int SIDES = 6;
            double[] dist = new double[2 * SIDES + 1];
            for (int i = 1; i <= SIDES; i++)
                for (int j = 1; j <= SIDES; j++)
                    dist[i + j] += 1.0;

            for (int k = 2; k <= 2 * SIDES; k++)
                dist[k] /= 36.0;

            // 断进行模拟，直至误差小于 0.001
            int N = 36;
            bool isAccepted = false;
            double[] disttemp = null;
            double error = 0.001;
            while (isAccepted == false)
            {
                disttemp = PlayDice(N);
                isAccepted = true;
                for (int i = 0; i < disttemp.Length; ++i)
                {
                    if (Math.Abs(disttemp[i] - dist[i]) >= error)
                        isAccepted = false;
                }
                N++;
            }

            Console.WriteLine($"N:{N}\n");
            for (int i = 0; i < dist.Length; ++i)
            {
                Console.WriteLine($"{i}:\n Standerd:{dist[i]}\nSimulated:{disttemp[i]}\nOffset:{Math.Abs(disttemp[i] - dist[i])}");
            }
        }

        /// <summary>
        /// 模拟掷骰子实验。
        /// </summary>
        /// <param name="N">掷骰子的次数。</param>
        /// <returns></returns>
        static double[] PlayDice(int N)
        {
            Random random = new Random();

            int SIDES = 6;
            double[] dist = new double[2 * SIDES + 1];

            //  N 次
            int sumtemp = 0;
            for (int i = 0; i < N; ++i)
            {
                sumtemp = random.Next(1, 7) + random.Next(1, 7);
                dist[sumtemp]++;
            }

            // 算概率
            for (int i = 0; i < dist.Length; ++i)
            {
                dist[i] /= N;
            }

            return dist;
        }
    }
}