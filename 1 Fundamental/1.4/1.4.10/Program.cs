using System;

namespace _1._4._10
{
    /*
     * 1.4.10
     * 
     * 修改二分查找算法，使之总是返回和被查找的键匹配的索引最小的元素。
     * （但仍能够保证对数级别的运行时间）
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int key = 1;
            int[] a = new int[5] { 1, 1, 3, 4, 5 };

            Console.WriteLine($"The first index of {key} is {BinarySearch.Rank(key, a, 0, a.Length - 1)}");

        }
    }
}
