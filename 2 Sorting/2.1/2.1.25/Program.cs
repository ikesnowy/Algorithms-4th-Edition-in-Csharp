using System;
using Sort;
using SortData;

namespace _2._1._25
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = DataManager.GetUnsortedData();// 获得 32 K 数据
            int[] b = DataManager.GetUnsortedData();
            // 耗时 12354 毫秒（@Surface Pro 3 i7 512G）
            Console.WriteLine(SortCompare.Time(new InsertionSort(), a));
            // 耗时 15034 毫秒（@Surface Pro 3 i7 512G）
            Console.WriteLine(SortCompare.Time(new Sort.InsertionSort(), b));
        }
    }
}
