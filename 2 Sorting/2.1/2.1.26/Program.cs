using System;
using SortData;
using System.Diagnostics;

namespace _2._1._26
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = DataManager.GetUnsortedData();// 获得 32 K 数据
            int[] b = DataManager.GetUnsortedData();
            // 耗时 1714 毫秒（@Surface Pro 3 i7 512G）
            InsertionSort sort = new InsertionSort();
            Stopwatch stopwatch = Stopwatch.StartNew();
            sort.Sort(a);
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            // 耗时 9740 毫秒（@Surface Pro 3 i7 512G）
            Sort.InsertionSort sortOrign = new Sort.InsertionSort();
            stopwatch.Restart();
            sortOrign.Sort(b);
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
