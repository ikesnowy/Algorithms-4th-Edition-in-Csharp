using System;
using Merge;

namespace _2._2._21
{
    /*
     * 2.2.21
     * 
     * 一式三份。
     * 给定三个列表，
     * 每个列表中包含 N 个名字，
     * 编写一个线性对数级别的算法来判定三份列表中是否含有公共的名字，
     * 如果有，返回第一个被找到的这种名字。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string[] name1 = new string[] { "Noah", "Liam", "Jacob", "Mason" };
            string[] name2 = new string[] { "Sophia", "Emma", "Mason", "Ava" };
            string[] name3 = new string[] { "Mason", "Marcus", "Alexander", "Ava" };

            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(name1);
            mergeSort.Sort(name2);
            mergeSort.Sort(name3);

            for (int i = 0; i < name1.Length; i++)
            {
                if (BinarySearch(name1[i], name2, 0, name1.Length) != -1 &&
                    BinarySearch(name1[i], name3, 0, name1.Length) != -1)
                {
                    Console.WriteLine(name1[i]);
                    break;
                }
                    
            }
        }

        /// <summary>
        /// 二分查找，返回目标元素的下标，没有结果则返回 -1。
        /// </summary>
        /// <typeparam name="T">查找的元素类型。</typeparam>
        /// <param name="key">要查找的目标值。</param>
        /// <param name="array">用于查找的目标范围。</param>
        /// <param name="lo">查找的起始下标。</param>
        /// <param name="hi">查找的终止下标。</param>
        /// <returns>找到则返回元素下标，否则返回 -1。</returns>
        static int BinarySearch<T>(T key, T[] array, int lo, int hi) where T : IComparable<T>
        {
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (array[mid].Equals(key))
                    return mid;
                else if (array[mid].CompareTo(key) < 0)
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }
            return -1;
        }
    }
}
