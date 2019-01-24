using System;

namespace _2._5._27
{
    /*
     * 2.5.27
     * 
     * 平行数组的排序。
     * 在将平行数组排序时，可以将索引排序并返回一个 index[] 数组。
     * 为 Insertion 添加一个 indirectSort 方法，
     * 接受一个 Comparable 的对象数组 a[] 作为参数，
     * 但它不会将 a[] 中的元素重新排列，
     * 而是返回一个整型数组 index[] 使得 a[index[0]] 到 a[index[N-1]] 正好是升序的。
     * 
     */
    class Program
    {
        /// <summary>
        /// 间接排序。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        static int[] IndirectSort<T>(T[] keys) where T : IComparable<T>
        {
            int n = keys.Length;
            int[] index = new int[n];
            for (int i = 0; i < n; i++)
                index[i] = i;

            for (int i = 0; i < n; i++)
                for (int j = i; j > 0 && keys[index[j]].CompareTo(keys[index[j - 1]]) < 0; j--)
                {
                    int temp = index[j];
                    index[j] = index[j - 1];
                    index[j - 1] = temp;
                }
            return index;
        }

        static void Main(string[] args)
        {
            int[] data = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] index = IndirectSort(data);
            for(int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < index.Length; i++)
            {
                Console.Write(index[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
