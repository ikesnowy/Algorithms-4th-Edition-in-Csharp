using System;
using Sort;

namespace _2._1._31
{

    class Program
    {
        static void Main(string[] args)
        {
            int N = 1000;

            InsertionSort insertion = new InsertionSort();
            SelectionSort selection = new SelectionSort();
            ShellSort shell = new ShellSort();

            double prevInsertion = 0;
            double prevSelection = 0;
            double prevShell = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("N:" + N);
                int[] array = SortCompare.GetRandomArrayInt(N);
                int[] arrayBak = new int[N];
                array.CopyTo(arrayBak, 0);

                Console.WriteLine("\tInsertion Sort");
                double now = SortCompare.Time(insertion, array);
                Console.WriteLine("\t\tActual Time(ms):" + now);
                if (i != 0)
                {
                    Console.WriteLine("\t\tEstimate Time(ms):" + prevInsertion * 4);
                    Console.WriteLine("\t\tRatio:" + now / prevInsertion);
                }
                prevInsertion = now;

                arrayBak.CopyTo(array, 0);

                Console.WriteLine("\tSelection Sort");
                now = SortCompare.Time(selection, array);
                Console.WriteLine("\t\tActual Time(ms):" + now);
                if (i != 0)
                {
                    Console.WriteLine("\t\tEstimate Time(ms):" + prevSelection * 4);
                    Console.WriteLine("\t\tRatio:" + now / prevSelection);
                }
                prevSelection = now;

                arrayBak.CopyTo(array, 0);

                Console.WriteLine("\tShell Sort");
                now = SortCompare.Time(shell, array);
                Console.WriteLine("\t\tActual Time(ms):" + now);
                if (i != 0)
                {
                    Console.WriteLine("\t\tEstimate Time(ms):" + prevShell * 2);
                    Console.WriteLine("\t\tRatio:" + now / prevShell);
                }
                prevShell = now;

                N *= 2;
            }

        }
    }
}
