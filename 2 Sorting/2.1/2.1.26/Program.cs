using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;
using SortData;
using System.Diagnostics;

namespace _2._1._26
{
    /*
     * 2.1.26
     * 
     * 原数数据类型。
     * 编写一个能够处理 int 值的插入排序的新版本，
     * 比较它和正文中所给出的实现
     * （能够隐式地用自动装箱和拆箱转换 Integer 值并排序）的性能。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = DataManager.GetUnsortedData();// 获得 32 K 数据
            // 耗时 1714 毫秒（@Surface Pro 3 i7 512G）
            InsertionSort sort = new InsertionSort();
            Stopwatch stopwatch = Stopwatch.StartNew();
            sort.Sort(a);
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            // 耗时 5179 毫秒（@Surface Pro 3 i7 512G）
            Sort.InsertionSort sortOrign = new Sort.InsertionSort();
            stopwatch.Restart();
            sortOrign.Sort(a);
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
