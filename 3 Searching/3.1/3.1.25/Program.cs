using System;
using System.IO;
using SymbolTable;

namespace _3._1._25
{
    /*
     * 3.1.25
     * 
     * 缓存。因为默认的 contains() 的实现中调用了 get()，所以 FrequencyCounter 的内循环会将同一个键查找两三遍：
     * if (!st.contains(word)) st.put(word, 1);
     * else st.put(word, st.get(word) + 1);
     * 为了能够提高这样的用例代码的效率，我们可以用一种叫做缓存的技术手段，
     * 即将访问最频繁的键的位置保存在一个变量中。
     * 修改 SequentialSearchST 和 BinarySearchST 来实现这个点子。
     * 
     */
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
