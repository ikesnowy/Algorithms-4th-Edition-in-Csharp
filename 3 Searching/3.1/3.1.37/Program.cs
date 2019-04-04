using System;
using SymbolTable;

namespace _3._1._37
{
    /*
     * 3.1.37
     * 
     * put/get 的比例。
     * 当 FrequencyCounter 
     * 使用 BinarySearchST 
     * 在 100 万个长度为 M 个二进位的随机整数中统计每个值的出现频率时，
     * 根据经验判断 BinarySearchST 中 put() 操作和 get() 操作的耗时比，
     * 其中 M=10、20 和 30。再统计 tale.txt 并评估耗时比，并比较两次的结果。
     * 
     */
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
