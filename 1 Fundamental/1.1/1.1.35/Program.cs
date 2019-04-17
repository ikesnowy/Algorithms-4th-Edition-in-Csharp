﻿using System;

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
            int SIDES = 6;
            double[] dist = new double[2 * SIDES + 1];
            for (int i = 1; i <= SIDES; i++)
                for (int j = 1; j <= SIDES; j++)
                    dist[i + j] += 1.0;

            for (int k = 2; k <= 2 * SIDES; k++)
                dist[k] /= 36.0;

            // 不断进行模拟，直至误差小于 0.001
            int N = 36;
            bool isAccepted = false;
            double[] disttemp = null;
            double error = 0.001;
            while (isAccepted == false)
            {
                disttemp = PlayDice(N);
                isAccepted = true;
                for (int i = 0; i < disttemp.Length; i++)
                {
                    if (Math.Abs(disttemp[i] - dist[i]) >= error)
                        isAccepted = false;
                }
                N++;
            }

            Console.WriteLine($"N:{N}\n");
            for (int i = 0; i < dist.Length; i++)
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

            // 掷 N 次
            int sumtemp = 0;
            for (int i = 0; i < N; i++)
            {
                sumtemp = random.Next(1, 7) + random.Next(1, 7);
                dist[sumtemp]++;
            }

            // 计算概率
            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] /= N;
            }

            return dist;
        }
    }
}