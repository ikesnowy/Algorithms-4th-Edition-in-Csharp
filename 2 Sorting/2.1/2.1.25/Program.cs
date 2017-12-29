using System;
using Sort;
using SortData;

namespace _2._1._25
{
    /*
     * 2.1.25
     * 
     * 不需要交换的插入排序。
     * 在插入排序的实现中使较大元素右移一位只需要访问一次数组
     * （而不用使用 exch()）。
     * 使用 SortCompare 来评估这种做法的效果。
     * 
     */
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
