using System;
using SymbolTable;

namespace _3._1._8
{
    /*
     * 3.1.8
     * 
     * 在《双城记》中，使用频率最高的长度大于等于 10 的单词是什么？
     * 
     */
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
