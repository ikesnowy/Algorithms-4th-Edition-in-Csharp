using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Measurement;

namespace _1._4._41
{
    static class DoublingRatio
    {
        /// <summary>
        /// 从指定字符串中读入按行分割的整型数据。
        /// </summary>
        /// <param name="inputString">源字符串。</param>
        /// <returns>读入的整型数组</returns>
        private static int[] ReadAllInts(string inputString)
        {
            char[] split = new char[1] { '\n' };
            string[] input = inputString.Split(split, StringSplitOptions.RemoveEmptyEntries);
            int[] a = new int[input.Length];
            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = int.Parse(input[i]);
            }
            return a;
        }

        /// <summary>
        /// 测试 ThreeSum 随数据量倍增耗时的比率。
        /// </summary>
        /// <returns>返回 ThreeSum 随数据量倍增耗时的比率。</returns>
        public static double ThreeSumTest()
        {
            double ratio = 0;

            // 1K
            int[] a = ReadAllInts(TestCase.Properties.Resources._1Kints);
            double prevTime = ThreeSum.Count(a);
            Console.WriteLine("数据量\t耗时\t比值");
            Console.WriteLine($"1000\t{prevTime}\t");

            // 2K
            a = ReadAllInts(TestCase.Properties.Resources._2Kints);
            double time = ThreeSum.Count(a);
            Console.WriteLine($"2000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 4K
            a = ReadAllInts(TestCase.Properties.Resources._4Kints);
            time = ThreeSum.Count(a);
            Console.WriteLine($"4000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 8K
            a = ReadAllInts(TestCase.Properties.Resources._8Kints);
            time = ThreeSum.Count(a);
            Console.WriteLine($"8000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 16K
            a = ReadAllInts(TestCase.Properties.Resources._16Kints);
            time = ThreeSum.Count(a);
            Console.WriteLine($"16000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 32K
            a = ReadAllInts(TestCase.Properties.Resources._32Kints);
            time = ThreeSum.Count(a);
            Console.WriteLine($"32000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            return ratio / 5;
        }

        /// <summary>
        /// 测试 ThreeSumFast 随数据量倍增耗时的比率。
        /// </summary>
        /// <returns>返回 ThreeSumFast 随数据量倍增耗时的比率。</returns>
        public static double ThreeSumFastTest()
        {
            double ratio = 0;

            // 1K
            int[] a = ReadAllInts(TestCase.Properties.Resources._1Kints);
            double prevTime = ThreeSumFast.Count(a);
            Console.WriteLine("数据量\t耗时\t比值");
            Console.WriteLine($"1000\t{prevTime}\t");

            // 2K
            a = ReadAllInts(TestCase.Properties.Resources._2Kints);
            double time = ThreeSumFast.Count(a);
            Console.WriteLine($"2000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 4K
            a = ReadAllInts(TestCase.Properties.Resources._4Kints);
            time = ThreeSumFast.Count(a);
            Console.WriteLine($"4000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 8K
            a = ReadAllInts(TestCase.Properties.Resources._8Kints);
            time = ThreeSumFast.Count(a);
            Console.WriteLine($"8000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 16K
            a = ReadAllInts(TestCase.Properties.Resources._16Kints);
            time = ThreeSumFast.Count(a);
            Console.WriteLine($"16000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 32K
            a = ReadAllInts(TestCase.Properties.Resources._32Kints);
            time = ThreeSumFast.Count(a);
            Console.WriteLine($"32000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            return ratio / 5;
        }

        /// <summary>
        /// 测试 TwoSum 随数据量倍增耗时的比率。
        /// </summary>
        /// <returns>返回 TwoSum 随数据量倍增耗时的比率。</returns>
        public static double TwoSumTest()
        {
            double ratio = 0;

            // 1K
            int[] a = ReadAllInts(TestCase.Properties.Resources._1Kints);
            double prevTime = TwoSum.Count(a);
            Console.WriteLine("数据量\t耗时\t比值");
            Console.WriteLine($"1000\t{prevTime}\t");

            // 2K
            a = ReadAllInts(TestCase.Properties.Resources._2Kints);
            double time = TwoSum.Count(a);
            Console.WriteLine($"2000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 4K
            a = ReadAllInts(TestCase.Properties.Resources._4Kints);
            time = TwoSum.Count(a);
            Console.WriteLine($"4000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 8K
            a = ReadAllInts(TestCase.Properties.Resources._8Kints);
            time = TwoSum.Count(a);
            Console.WriteLine($"8000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 16K
            a = ReadAllInts(TestCase.Properties.Resources._16Kints);
            time = TwoSum.Count(a);
            Console.WriteLine($"16000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 32K
            a = ReadAllInts(TestCase.Properties.Resources._32Kints);
            time = TwoSum.Count(a);
            Console.WriteLine($"32000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            return ratio / 5;
        }

        /// <summary>
        /// 测试 TwoSumFast 随数据量倍增耗时的比率。
        /// </summary>
        /// <returns>返回 TwoSumFast 随数据量倍增耗时的比率。</returns>
        public static double TwoSumFastTest()
        {
            double ratio = 0;

            // 1K
            int[] a = ReadAllInts(TestCase.Properties.Resources._1Kints);
            double prevTime = TwoSumFast.Count(a);
            Console.WriteLine("数据量\t耗时\t比值");
            Console.WriteLine($"1000\t{prevTime}\t");

            // 2K
            a = ReadAllInts(TestCase.Properties.Resources._2Kints);
            double time = TwoSumFast.Count(a);
            Console.WriteLine($"2000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 4K
            a = ReadAllInts(TestCase.Properties.Resources._4Kints);
            time = TwoSumFast.Count(a);
            Console.WriteLine($"4000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 8K
            a = ReadAllInts(TestCase.Properties.Resources._8Kints);
            time = TwoSumFast.Count(a);
            Console.WriteLine($"8000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 16K
            a = ReadAllInts(TestCase.Properties.Resources._16Kints);
            time = TwoSumFast.Count(a);
            Console.WriteLine($"16000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            // 32K
            a = ReadAllInts(TestCase.Properties.Resources._32Kints);
            time = TwoSumFast.Count(a);
            Console.WriteLine($"32000\t{time}\t{time / prevTime}");
            ratio += time / prevTime;
            prevTime = time;

            return ratio / 5;
        }
    }
}
