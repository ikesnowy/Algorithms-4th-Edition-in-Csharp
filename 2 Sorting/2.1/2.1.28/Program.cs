using System;
using Sort;

namespace _2._1._28
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1024;
            Random random = new Random();

            double insertionPrev = 1;
            double selectionPrev = 1;

            while (n < 65538)
            {
                int[] testInsertion = new int[n];
                int[] testSelection = new int[n];

                for (int i = 0; i < n; i++)
                {
                    testInsertion[i] = random.Next(2);
                    testSelection[i] = testInsertion[i];
                }

                Console.WriteLine("数组大小：" + n);

                Console.Write("Insertion Sort:");
                double insertionNow = SortCompare.Time(new InsertionSort(), testInsertion);
                Console.WriteLine(insertionNow + "\tNow/Prev=" + insertionNow / insertionPrev);
                Console.Write("Selection Sort:");
                double selectionNow = SortCompare.Time(new SelectionSort(), testSelection);
                Console.WriteLine(selectionNow + "\tNow/Prev=" + selectionNow / selectionPrev);
                Console.WriteLine();

                insertionPrev = insertionNow;
                selectionPrev = selectionNow;

                n *= 2;
            }
        }
    }
}
