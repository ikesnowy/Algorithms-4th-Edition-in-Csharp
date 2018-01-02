using System;
using Sort;

namespace _2._1._35
{
    /*
     * 2.1.35
     * 
     * 不均匀的概率分布。编写一个测试用例，使用非均匀分布的概率来生成随机排列的数据，包括：
     * 高斯分布
     * 泊松分布
     * 几何分布
     * 离散分布（一种特殊情况见练习 2.1.28）。
     * 评估并验证这些输入数据对本节讨论的算法的影响。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            InsertionSort insertionSort = new InsertionSort();
            SelectionSort selectionSort = new SelectionSort();
            ShellSort shellSort = new ShellSort();
            int n = 10000;

            // 高斯分布（正态分布）
            double[] arrayInsertion = SortCompare.GetNormalDistributionArray(n);
            double[] arraySelection = new double[n];
            double[] arrayShell = new double[n];

            arrayInsertion.CopyTo(arraySelection, 0);
            arrayInsertion.CopyTo(arrayShell, 0);

            Console.WriteLine("Normal Distribution:");
            Console.WriteLine("Insertion: " + SortCompare.Time(insertionSort, arrayInsertion));
            Console.WriteLine("Selection: " + SortCompare.Time(selectionSort, arraySelection));
            Console.WriteLine("Shell: " + SortCompare.Time(shellSort, arrayShell));

            // 泊松分布
            arrayInsertion = SortCompare.GetPossionDistributionArray(n);
            arrayInsertion.CopyTo(arraySelection, 0);
            arrayInsertion.CopyTo(arrayShell, 0);

            Console.WriteLine("Poission Distribution:");
            Console.WriteLine("Insertion: " + SortCompare.Time(insertionSort, arrayInsertion));
            Console.WriteLine("Selection: " + SortCompare.Time(selectionSort, arraySelection));
            Console.WriteLine("Shell: " + SortCompare.Time(shellSort, arrayShell));

            // 几何分布
            arrayInsertion = SortCompare.GetGeometricDistributionArray(n, 0.3);
            arrayInsertion.CopyTo(arraySelection, 0);
            arrayInsertion.CopyTo(arrayShell, 0);

            Console.WriteLine("Geometric Distribution:");
            Console.WriteLine("Insertion: " + SortCompare.Time(insertionSort, arrayInsertion));
            Console.WriteLine("Selection: " + SortCompare.Time(selectionSort, arraySelection));
            Console.WriteLine("Shell: " + SortCompare.Time(shellSort, arrayShell));

            // 离散分布
            arrayInsertion = SortCompare.GetDiscretDistributionArray(n, new double[] { 0.1, 0.2, 0.3, 0.1, 0.1, 0.1, 0.1 });
            arrayInsertion.CopyTo(arraySelection, 0);
            arrayInsertion.CopyTo(arrayShell, 0);

            Console.WriteLine("Discret Distribution:");
            Console.WriteLine("Insertion: " + SortCompare.Time(insertionSort, arrayInsertion));
            Console.WriteLine("Selection: " + SortCompare.Time(selectionSort, arraySelection));
            Console.WriteLine("Shell: " + SortCompare.Time(shellSort, arrayShell));
        }
    }
}
