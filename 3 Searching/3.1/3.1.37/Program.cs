using System;
using SymbolTable;

namespace _3._1._37
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000;
            int m = 10;
            int addBy10 = 3;

            for (int i = 0; i < addBy10; i++)
            {
                BinarySearchSTAnalysis<long, int> bst = new BinarySearchSTAnalysis<long, int>(n);
                long[] data = SearchCompare.GetRandomArrayLong(n, (long)Math.Pow(2, m), (long)Math.Pow(2, m + 1));
                FrequencyCounter.MostFrequentlyKey(bst, data);
                Console.WriteLine("m=" + m + "\t" + bst.GetTimer.ElapsedMilliseconds + "\t" + bst.PutTimer.ElapsedMilliseconds + "\t" + bst.PutTimer.ElapsedMilliseconds / (double)bst.GetTimer.ElapsedMilliseconds);
                m += 10;
            }

            BinarySearchSTAnalysis<string, int> st = new BinarySearchSTAnalysis<string, int>();
            FrequencyCounter.MostFrequentlyWord("tale.txt", 0, st);
            Console.WriteLine("tales\t" + st.GetTimer.ElapsedMilliseconds + "\t" + st.PutTimer.ElapsedMilliseconds + "\t" + st.PutTimer.ElapsedMilliseconds / (double)st.GetTimer.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
