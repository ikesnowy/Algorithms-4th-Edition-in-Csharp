using System;
using System.Diagnostics;
using SortApplication;

namespace _2._5._33
{
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
