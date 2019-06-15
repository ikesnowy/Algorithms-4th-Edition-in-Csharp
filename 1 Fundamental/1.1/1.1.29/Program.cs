using System;

namespace _1._1._29
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] WhiteList = new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };

            Array.Sort<int>(WhiteList);

            Console.WriteLine("Type the numbers you want to query: ");
            string input = Console.ReadLine();
            int[] Query = new int[input.Split(' ').Length];
            for (int i = 0; i < Query.Length; i++)
            {
                Query[i] = int.Parse(input.Split(' ')[i]);
            }

            Console.WriteLine("Result:");
            foreach (int n in Query)
            {
                int less = rank(n, WhiteList);
                int equal = count(n, WhiteList);
                Console.WriteLine($"Less: {less} Equal: {equal}");
            }
        }

        /// <summary>
        /// 计算数组中相等元素的个数。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <returns></returns>
        public static int count(int key, int[] a)
        {
            int lowerBound = rank(key, a);
            int upperBound = lowerBound;

            if (lowerBound == -1)
                return 0;

            int result = 0;
            while (true)
            {
                result = rank(key, a, upperBound + 1, a.Length - 1);
                if (result == -1)
                    break;
                if (result > upperBound)
                {
                    upperBound = result;
                }
            }

            return upperBound - lowerBound + 1;
        }

        /// <summary>
        /// 计算数组中小于该数的数字个数。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <returns></returns>
        public static int rank(int key, int[] a)
        {
            int mid = rank(key, a, 0, a.Length - 1);
            if (mid == -1)
                return 0;
            int result = mid;
            while (true)
            {
                result = rank(key, a, 0, mid - 1);

                if (result == -1)
                    break;
                if (result < mid)
                    mid = result;
            }
            return mid;
        }

        /// <summary>
        /// 二分查找。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <param name="lo">查找的下界。</param>
        /// <param name="hi">查找的上界。</param>
        /// <returns></returns>
        public static int rank(int key, int[] a, int lo, int hi)
        {

            if (lo > hi)
            {
                return -1;
            }

            int mid = lo + (hi - lo) / 2;

            if (key < a[mid])
            {
                return rank(key, a, lo, mid - 1);
            }
            else if (key > a[mid])
            {
                return rank(key, a, mid + 1, hi);
            }
            else
            {
                return mid;
            }
        }
    }
}