using System;
using System.IO;
using SymbolTable;

namespace _3._1._25
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // 事实上指的是最近一次访问的键，而非访问最频繁的。

            StreamReader sr = new StreamReader(File.OpenRead("tale.txt"));
            string[] data = sr.ReadToEnd().Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int repeatTimes = 1;

            Console.WriteLine("BinarySearchST");
            Console.WriteLine("Origin\tCached\tRatio");
            long bstTimes = 0, bstcTimes = 0;

            BinarySearchST<string, int> bst = new BinarySearchST<string, int>();
            BinarySearchSTCached<string, int> bstc = new BinarySearchSTCached<string, int>();

            bstTimes += SearchCompare.Time(bst, data);
            bstcTimes += SearchCompare.Time(bstc, data);
            Console.WriteLine(bstTimes / repeatTimes + "\t" + bstcTimes / repeatTimes + "\t" + (double)bstTimes / bstcTimes);

            Console.WriteLine("SequentialSearchST");
            Console.WriteLine("Origin\tCached\tRatio");
            long sstTimes = 0, sstcTimes = 0;

            SequentialSearchST<string, int> sst = new SequentialSearchST<string, int>();
            SequentialSearchSTCached<string, int> sstc = new SequentialSearchSTCached<string, int>();

            sstTimes += SearchCompare.Time(sst, data);
            sstcTimes += SearchCompare.Time(sstc, data);
            Console.WriteLine(sstTimes + "\t" + sstcTimes + "\t" + (double)sstTimes / sstcTimes);
        }
    }
}
