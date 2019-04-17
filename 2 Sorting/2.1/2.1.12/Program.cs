using System;

namespace _2._1._12
{
    
    class Program
    {
        // 查看最后结果
        // 可以发现相同的 h 在数组大小不同时所产生的比值十分接近。
        static void Main(string[] args)
        {
            Random random = new Random();
            ShellSort sort = new ShellSort();

            int size = 100;
            for (int i = 0; i < 5; i++)
            {
                double[] a = new double[size];
                for (int j = 0; j < size; j++)
                {
                    a[j] = random.NextDouble() * 100;
                }
                Console.WriteLine("ArraySize:" + size);
                sort.Sort(a);
                size *= 10;
            }
        }
    }
}
