using System;
using SymbolTable;

namespace _3._1._19
{
    /*
     * 3.1.19
     * 
     * 修改 FrequencyCounter，打印出现频率最高的所有单词，而非之一。
     * 提示：请用 Queue。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            ST<string, int> st = new ST<string, int>();
            string[] mostFrequently = FrequencyCounter.MostFrequentlyWords("tale.txt", 20, st);
            foreach (string s in mostFrequently)
                Console.WriteLine(s);
        }
    }
}
