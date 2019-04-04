using System;
using System.Diagnostics;

namespace _3._1._40
{
    /*
     * 3.1.40
     * 
     * 二分查找的临界点。
     * 找出使用二分查找比顺序查找要快 10000 倍和 1000 倍的 N 值。
     * 分析并预测 N 的大小并通过实验验证它。
     * 
     */
    class Program
    {
        static long binarySearchCompare = 0;
        static long sequentialSearchCompare = 0;

        static Random random = new Random();
        class TestNode : IComparable<TestNode>
        {
            public long Value { get; set; }

            public int CompareTo(TestNode other)
            {
                return this.Value.CompareTo(other.Value);
            }
        }

        static void Main(string[] args)
        {
            // 简单解方程，注意顺序查找平均要查询一半的元素。
            // 1000 * logN = N / 2
            // N = 29718 左右
            // 10000 * logN = N / 2
            // N = 369939 左右

            Console.WriteLine("n\tsst(compare/time)\tbst(compare/time)\tratio(compare/time)");
            Test(29718, 29718);
            Test(369939, 369939);
        }

        static void Test(int n, int trial)
        {
            binarySearchCompare = 0;
            sequentialSearchCompare = 0;
            Console.Write(n + "\t");

            Stopwatch sw = new Stopwatch();
            int[] seedData = new int[n];
            for (int i = 0; i < n; i++)
                seedData[i] = i;
            Shuffle(seedData);

            TestNode[] data = new TestNode[n];
            TestNode[] dataSorted = new TestNode[n];
            TestNode[] dataQuery = new TestNode[n];
            for (int i = 0; i < n; i++)
                data[i] = new TestNode() { Value = seedData[i] };
            
            Array.Sort(seedData);
            for (int i = 0; i < n; i++)
                dataSorted[i] = new TestNode() { Value = seedData[i] };

            Array.Copy(data, dataQuery, data.Length);
            Shuffle(dataQuery);

            long bstTime = 0, sstTime = 0;
            // 测试 sst
            sw.Start();
            for (int i = 0; i < trial; i++)
            {
                SequentialSearch(data, dataQuery[i]);
            }
            sw.Stop();
            sstTime = sw.ElapsedMilliseconds;
            Console.Write(sequentialSearchCompare + "/" + sstTime + "\t\t");

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
            Console.WriteLine((float)sequentialSearchCompare / binarySearchCompare + "/" + (float)sstTime/bstTime);
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

        static int SequentialSearch<T>(T[] a, T key) where T : IComparable<T>
        {
            for (int i = 0; i < a.Length; i++)
            {
                int compare = a[i].CompareTo(key);
                sequentialSearchCompare++;
                if (compare == 0)
                    return i;
            }
            return -1;
        }

        static int BinarySearch<T>(T[] a, T key) where T : IComparable<T>
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
    }
}
