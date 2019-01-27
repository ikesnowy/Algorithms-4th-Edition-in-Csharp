using System;
using System.Diagnostics;
using SortApplication;

namespace _2._5._33
{
    /*
     * 2.5.33
     * 
     * 随机交易。
     * 开发一个接受参数 N 的生成器，
     * 根据你能想到的任意假设条件生成 N 个随机的 Transaction 对象
     * （请见练习 2.1.21 和 2.1.22）。
     * 对于 N=10^3、10^4、10^5 和 10^6，
     * 比较用希尔排序、归并排序、快速排序和堆排序将 N 个交易排序的性能。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            ShellSort shellSort = new ShellSort();
            MergeSort mergeSort = new MergeSort();
            QuickSort quickSort = new QuickSort();

            int n = 1000;
            int nMultipleBy10 = 4;
            for (int i = 0; i < nMultipleBy10; i++)
            {
                Console.WriteLine("n=" + n);
                Transaction[] trans = TransactionGenerator.Generate(n);

                Transaction[] testCase = new Transaction[n];

                trans.CopyTo(testCase, 0);
                stopwatch.Restart();
                shellSort.Sort(testCase);
                stopwatch.Stop();
                Console.WriteLine("Shell Sort: " + stopwatch.ElapsedMilliseconds + " ms");

                trans.CopyTo(testCase, 0);
                stopwatch.Restart();
                mergeSort.Sort(testCase);
                stopwatch.Stop();
                Console.WriteLine("Merge Sort: " + stopwatch.ElapsedMilliseconds + " ms");

                trans.CopyTo(testCase, 0);
                stopwatch.Restart();
                quickSort.Sort(testCase);
                stopwatch.Stop();
                Console.WriteLine("Quick Sort: " + stopwatch.ElapsedMilliseconds + " ms");

                trans.CopyTo(testCase, 0);
                stopwatch.Restart();
                Heap.Sort(testCase);
                stopwatch.Stop();
                Console.WriteLine("Heap Sort: " + stopwatch.ElapsedMilliseconds + " ms");

                n *= 10;
            }
        }
    }
}
