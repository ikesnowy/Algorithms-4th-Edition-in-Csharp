using System;
using SymbolTable;

namespace _3._1._8
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // 删除末尾的版权许可： Monseigneur
            // 不删除末尾的版权许可：Gutenberg-tm
            // tale.txt:https://introcs.cs.princeton.edu/java/data/tale.txt
            ST<string, int> st = new ST<string, int>();
            string most = FrequencyCounter.MostFrequentlyWord("tale.txt", 10, st);
            Console.WriteLine(most);
        }
    }
}
