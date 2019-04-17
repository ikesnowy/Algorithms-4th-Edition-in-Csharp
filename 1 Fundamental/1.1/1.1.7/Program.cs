using System;

namespace _1._1._7
{
    
    class Program
    {
        private static void a()
        {
            Console.WriteLine("a");
            double t = 9.0;
            while (Math.Abs(t - 9.0 / t) > .001)
            {
                t = (9.0 / t + t) / 2.0;
            }
            Console.Write($"{t:N5}\n");// :N5代表保留5位小数，同理可使用N1、N2……
        }

        private static void b()
        {
            Console.WriteLine("\nb");
            int sum = 0;
            for (int i = 1; i < 1000; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    sum++;
                }
            }
            Console.WriteLine(sum);
        }

        private static void c()
        {
            Console.WriteLine("\nc");
            int sum = 0;
            for (int i = 1; i < 1000; i *= 2)
            {
                for (int j = 0; j < 1000; j++)
                {
                    sum++;
                }
            }
            Console.WriteLine(sum);
        }

        static void Main(string[] args)
        {
            // a double 计算存在误差
            a();

            // b 1000+999+998……
            b();

            // c 由于2^10 = 1024 > 1000，最终sum = 1000 * 10 = 10000
            c();
        }
    }
}
