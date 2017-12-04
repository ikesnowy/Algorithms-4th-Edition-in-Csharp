using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // 耗时 8101 毫秒（@Surface Pro 3 i7 512G）
            Console.WriteLine(SortCompare.Time(new InsertionSort(), a));
            // 耗时 5623 毫秒（@Surface Pro 3 i7 512G）
            Console.WriteLine(SortCompare.Time(new Sort.InsertionSort(), a));
        }
    }
}
