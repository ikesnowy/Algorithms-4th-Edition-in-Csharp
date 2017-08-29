using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Measurement;

namespace _1._4._41
{
    /*
     * 1.4.41
     * 
     * 运行时间。
     * 使用 DoublingRatio 估计在你的计算机上用 TwoSumFast、TwoSum、ThreeSumFast 以及 ThreeSum 处理一个含有 100 万个整数的文件所需的时间。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[62500];
            Random random = new Random();
            for (int i = 0; i < 62500; ++i)
            {
                a[i] = random.Next(31250) - 31250;
            }

            // ThreeSum
            Console.WriteLine("ThreeSum");
            double time62500 = ThreeSum.Count(a);
            Console.WriteLine($"数据量：62500 耗时：{time62500}");
            double doubleRatio = DoublingRatio.ThreeSumTest();
            Console.WriteLine($"数据量：1000000 估计耗时：{time62500 * doubleRatio * 16}");
            Console.WriteLine();

            // ThreeSumFast
            Console.WriteLine("ThreeSumFast");
            time62500 = ThreeSumFast.Count(a);
            doubleRatio = DoublingRatio.ThreeSumFastTest();
            Console.WriteLine($"数据量：62500 耗时：{time62500}");
            Console.WriteLine($"数据量：1000000 估计耗时：{time62500 * doubleRatio * 16}");
            Console.WriteLine();

            // TwoSum
            Console.WriteLine("TwoSumFast");
            time62500 = TwoSum.Count(a);
            doubleRatio = DoublingRatio.TwoSumTest();
            Console.WriteLine($"数据量：62500 耗时：{time62500}");
            Console.WriteLine($"数据量：1000000 估计耗时：{time62500 * doubleRatio * 16}");
            Console.WriteLine();

            // TwoSumFast
            Console.WriteLine("TwoSumFast");
            time62500 = TwoSumFast.Count(a);
            doubleRatio = DoublingRatio.TwoSumFastTest();
            Console.WriteLine($"数据量：62500 耗时：{time62500}");
            Console.WriteLine($"数据量：1000000 估计耗时：{time62500 * doubleRatio * 16}");
            Console.WriteLine();
        }
    }
}
