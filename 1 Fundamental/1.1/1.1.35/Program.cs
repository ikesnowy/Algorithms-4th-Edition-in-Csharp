using System;

namespace _1._1._35
{
    class Program
    {
        // 程序运行大概需要十几秒时间（也可能更长，看运气）
        // 我的数据：
        // 24098 44448 37776 44401 32541
        static void Main(string[] args)
        {
            // 书中给出的程序
            var SIDES = 6;
            var dist = new double[2 * SIDES + 1];
            for (var i = 1; i <= SIDES; i++)
                for (var j = 1; j <= SIDES; j++)
                    dist[i + j] += 1.0;

            for (var k = 2; k <= 2 * SIDES; k++)
                dist[k] /= 36.0;

            // 不断进行模拟，直至误差小于 0.001
            var N = 36;
            var isAccepted = false;
            double[] disttemp = null;
            var error = 0.001;
            while (isAccepted == false)
            {
                disttemp = PlayDice(N);
                isAccepted = true;
                for (var i = 0; i < disttemp.Length; i++)
                {
                    if (Math.Abs(disttemp[i] - dist[i]) >= error)
                        isAccepted = false;
                }
                N++;
            }

            Console.WriteLine($"N:{N}\n");
            for (var i = 0; i < dist.Length; i++)
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
            var random = new Random();

            var SIDES = 6;
            var dist = new double[2 * SIDES + 1];

            // 掷 N 次
            var sumtemp = 0;
            for (var i = 0; i < N; i++)
            {
                sumtemp = random.Next(1, 7) + random.Next(1, 7);
                dist[sumtemp]++;
            }

            // 计算概率
            for (var i = 0; i < dist.Length; i++)
            {
                dist[i] /= N;
            }

            return dist;
        }
    }
}