using System;
using SymbolTable;

namespace _3._1._9
{
    /*
     * 3.1.9
     * 
     * 在 FrequencyCounter 中添加追踪 put() 方法的最后一次调用的代码。
     * 打印出最后插入的那个单词以及在此之前总共从输入中处理了多少个单词。
     * 用你的程序处理 tale.txt 中长度分别大于等于 1、8 和 10 的单词。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // tale.txt:https://introcs.cs.princeton.edu/java/data/tale.txt
            // FrequencyCounter:https://algs4.cs.princeton.edu/31elementary/FrequencyCounter.java.html
            // 已删除末尾的版权许可。
            Console.WriteLine("MinLength = 1");
            FrequencyCounter.MostFrequentlyWord("tale.txt", 1, new ST<string, int>());
            Console.WriteLine("MinLength = 8");
            FrequencyCounter.MostFrequentlyWord("tale.txt", 8, new ST<string, int>());
            Console.WriteLine("MinLength = 10");
            FrequencyCounter.MostFrequentlyWord("tale.txt", 10, new ST<string, int>());
        }
    }
}
