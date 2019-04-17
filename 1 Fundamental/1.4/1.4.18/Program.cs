using System;

namespace _1._4._18
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] { 5, 6, 5, 3, 5 };
            Console.WriteLine(LocalMinimum(a));
        }

        /// <summary>
        /// 寻找数组的局部最小元素。
        /// </summary>
        /// <param name="testcases">寻找范围。</param>
        /// <returns>局部最小元素的值。</returns>
        static int LocalMinimum(int[] testcases)
        {
            int lo = 0;
            int hi = testcases.Length - 1;
            while (lo <= hi)
            {
                int mid = (hi - lo) / 2 + lo;
                if (testcases[mid] < testcases[mid - 1] && testcases[mid] < testcases[mid + 1])
                    return mid;
                if (testcases[mid - 1] < testcases[mid + 1])
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }
            return -1;
        }
    }
}
