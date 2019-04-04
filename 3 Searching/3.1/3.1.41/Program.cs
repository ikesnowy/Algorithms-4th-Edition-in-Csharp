using System;
using System.Diagnostics;

namespace _3._1._41
{
    /*
     * 3.1.41
     * 
     * 插值查找的临界点。
     * 找出使用插值查找比二分查找要快 1 倍、2 倍和 10 倍的 N 值，
     * 其中假设所有键为随机的 32 二进位整数（请见练习 3.1.24）。
     * 分析并预测 N 的大小并通过实验验证它。
     * 
     */
    class Program
    {
        static long binarySearchCompare = 0;
        static long interpolationSearchCompare = 0;
        static Random random = new Random();

        static void Main(string[] args)
        {
            // 原文：1, 2 and 10 times faster
            // 也就是一样快，快一倍和快十倍

            // 对于均匀分布的数组，插值查找的平均需要 lg(lgN)) 次比较
            // 解方程 
            // lg(lgN)) = lgN, N = 0.8..
            // 2lg(lgN)) = lgN, N = 4
            // 10lg(lgN)) = lgN, N = 58

            Console.WriteLine("n\tist(compare/time)\tbst(compare/time)\tratio(compare/time)");
            Test(1, 10000000);
            Test(4, 10000000);
            Test(58, 10000000);
        }
        static void Test(int n, int trial)
        {
            binarySearchCompare = 0;
            interpolationSearchCompare = 0;
            Console.Write(n + "\t");

            Stopwatch sw = new Stopwatch();

            int[] data = new int[n];
            int[] dataSorted = new int[n];
            int[] dataQuery = new int[trial];
            for (int i = 0; i < n; i++)
            {
                dataSorted[i] = i;
                data[i] = i;
            }
            Shuffle(data);
            for (int i = 0; i < trial; i++)
            {
                dataQuery[i] = random.Next(0, n);
            }


            long bstTime = 0, istTime = 0;
            // 测试 ist
            sw.Start();
            for (int i = 0; i < trial; i++)
            {
                InterpolationSearch(data, dataQuery[i]);
            }
            sw.Stop();
            istTime = sw.ElapsedMilliseconds;
            Console.Write(interpolationSearchCompare + "/" + istTime + "\t\t");

            // 测试 bst
            sw.Restart();
            for (int i = 0; i < trial; i++)
            {
                BinarySearch(dataSorted, dataQuery[i]);
            }
            sw.Stop();

            bstTime = sw.ElapsedMilliseconds;
            Console.Write(binarySearchCompare + "/" + bstTime + "\t\t");

            // 比例
            Console.WriteLine((float)interpolationSearchCompare / binarySearchCompare + "/" + (float)istTime / bstTime);
        }

        static void Shuffle<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int p = i + random.Next(array.Length - i);
                T temp = array[p];
                array[p] = array[i];
                array[i] = temp;
            }
        }

        static int BinarySearch(int[] a, int key)
        {
            int lo = 0, hi = a.Length - 1;
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                int compare = a[mid].CompareTo(key);
                binarySearchCompare++;
                if (compare > 0)
                    hi = mid - 1;
                else if (compare < 0)
                    lo = mid + 1;
                else
                    return mid;
            }
            return -1;
        }


        static int InterpolationSearch(int[] a, int key)
        {
            int lo = 0, hi = a.Length - 1;
            while (lo <= hi)
            {
                double percent = a[hi] == a[lo] ? 0 : (key - a[lo]) / (a[hi] - a[lo]);
                int index = lo + (int)Math.Floor((hi - lo) * percent);
                if (percent < 0)
                    index = lo;
                if (percent > 1)
                    index = hi;

                int compare = a[index].CompareTo(key);
                interpolationSearchCompare++;
                if (compare > 0)
                    hi = index - 1;
                else if (compare < 0)
                    lo = index + 1;
                else
                    return index;
            }
            return -1;
        }
    }
}
