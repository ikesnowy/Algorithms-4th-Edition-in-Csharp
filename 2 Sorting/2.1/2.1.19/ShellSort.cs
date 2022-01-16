using System;
using System.Diagnostics;
using Sort;

namespace _2._1._19
{
    public class ShellSort : BaseSort
    {
        /// <summary>
        /// 利用希尔排序将数组按升序排序。
        /// </summary>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            var n = a.Length;
            var compareTime = 0;

            var h = 1;
            while (h < n / 3)
            {
                h = 3 * h + 1;
            }

            while (h >= 1)
            {
                for (var i = h; i < n; i++)
                {
                    for (var j = i; j >= h && LessAndCount(a[j], a[j - h], ref compareTime); j -= h)
                    {
                        Exch(a, j, j - h);
                    }
                }
                Debug.Assert(IsHSorted(a, h));
                h /= 3;
            }
            Console.WriteLine("CompareTime:" + compareTime);
            Debug.Assert(IsSorted(a));
        }

        private bool LessAndCount<T>(T a, T b, ref int count) where T : IComparable<T>
        {
            count++;
            return Less(a, b);
        }

        /// <summary>
        /// 检查一次希尔排序后的子数组是否有序。
        /// </summary>
        /// <param name="a">排序后的数组。</param>
        /// <param name="h">子数组间隔。</param>
        /// <returns>是否有序。</returns>
        private bool IsHSorted<T>(T[] a, int h) where T : IComparable<T>
        {
            for (var i = h; i < a.Length; i++)
            {
                if (Less(a[i], a[i - h]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
