using System;
using SymbolTable;

namespace _3._1._19
{
    
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
