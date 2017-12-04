using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;
using SortData;

namespace _2._1._24
{
    /*
     * 2.1.24
     * 
     * 插入排序的哨兵。
     * 在插入排序的实现中先找出最小的元素并将其置于数组的最左边，
     * 这样就能去掉内循环的判断条件 j>0。
     * 使用 SortCompare 来评估这种做法的效果。
     * 注意：这是一种常见的规避边界测试的方法，
     * 能够省略判断条件的元素通常称为哨兵。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = DataManager.GetUnsortedData();
            int[] b = DataManager.GetUnsortedData();
            // 耗时 9 秒（@Surface Pro 3 i7 512G）
            Console.WriteLine(SortCompare.Time(new InsertionSort(), a));
            // 耗时 5 秒（@Surface Pro 3 i7 512G）
            Console.WriteLine(SortCompare.Time(new Sort.InsertionSort(), b));
        }
    }
}
