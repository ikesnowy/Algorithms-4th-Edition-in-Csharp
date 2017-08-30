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
            int[] a = new int[977];
            Random random = new Random();
            for (int i = 0; i < 977; ++i)
            {
                a[i] = random.Next(977) - 489;
            }

            // ThreeSum
            Console.WriteLine("ThreeSum");
            double time = DoublingRatio.TimeTrial(ThreeSum.Count, a);
            Console.WriteLine($"数据量：977 耗时：{time / 1000}");
            double doubleRatio = DoublingRatio.Test(ThreeSum.Count);
            Console.WriteLine($"数据量：1000000 估计耗时：{time * doubleRatio * 1024 / 1000}");
            Console.WriteLine();

            //// ThreeSumFast
            Console.WriteLine("ThreeSumFast");
            time = DoublingRatio.TimeTrial(ThreeSumFast.Count, a);
            doubleRatio = DoublingRatio.Test(ThreeSumFast.Count);
            Console.WriteLine($"数据量：977 耗时：{time / 1000}");
            Console.WriteLine($"数据量：1000000 估计耗时：{time * doubleRatio * 1024 / 1000}");
            Console.WriteLine();

            //// TwoSum
            Console.WriteLine("TwoSum");
            time = DoublingRatio.TimeTrial(TwoSum.Count, a);
            doubleRatio = DoublingRatio.Test(TwoSum.Count);
            Console.WriteLine($"数据量：977 耗时：{time / 1000}");
            Console.WriteLine($"数据量：1000000 估计耗时：{time * doubleRatio * 1024 / 1000}");
            Console.WriteLine();

            // TwoSumFast
            // 速度太快，加大数据量
            a = new int[62500];
            for (int i = 0; i < 977; ++i)
            {
                a[i] = random.Next(62500) - 31250;
            }
            Console.WriteLine("TwoSumFast");
            time = DoublingRatio.TimeTrial(TwoSumFast.Count, a);
            doubleRatio = DoublingRatio.TestTwoSumFast(TwoSumFast.Count);
            Console.WriteLine($"数据量：62500 耗时：{time / 1000}");
            Console.WriteLine($"数据量：1000000 估计耗时：{time * doubleRatio * 16 / 1000}");
            Console.WriteLine();
        }
    }
}
