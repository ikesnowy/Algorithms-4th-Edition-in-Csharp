using System;

namespace _1._1._6
{
    
    class Program
    {
        // 输出斐波那契数列
        static void Main(string[] args)
        {
            int f = 0;
            int g = 1;
            for (int i = 0; i <= 15; i++)
            {
                // Console.WriteLine与StdOut.println功能相同
                // 实现向控制台输出一行
                Console.WriteLine(f);
                f = f + g;
                g = f - g;
            }
        }
    }
}
