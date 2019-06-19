using System;

namespace _1._4._23
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new double[20];
            var i = 1;
            double j = 0;
            while (i <= 20)
            {
                a[i - 1] = j / i;
                i++;
                j++;
            }

            Console.WriteLine(BinarySearch(a, 7.0 / 8.0));//7
            Console.WriteLine(BinarySearch(a, 5.0 / 8.0));//-1
        }

        // 将二分查找中的相等判定条件修改为差值小于 x，其中 x = 1/N^2。
        /// <summary>
        /// 二分查找。
        /// </summary>
        /// <param name="a">查找范围。</param>
        /// <param name="key">关键字。</param>
        /// <returns>结果的下标，没有结果时返回 -1。</returns>
        static int BinarySearch(double[] a, double key)
        {
            var lo = 0;
            var hi = a.Length - 1;
            var threshold = 1.0 / (a.Length * a.Length);

            while (lo <= hi)
            {
                var mid = lo + (hi - lo) / 2;
                if (Math.Abs(a[mid] - key) <= threshold)
                {
                    return mid;
                }
                else if (a[mid] < key)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            return -1;
        }
    }
}
