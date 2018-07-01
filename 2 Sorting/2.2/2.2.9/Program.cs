using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merge;

namespace _2._2._9
{
    /*
     * 2.2.9
     * 
     * 在库函数中使用 aux[] 这样的静态数组时不妥当的，
     * 因为可能会有多个程序同时使用这个类。
     * 实现一个不用静态数组的 Merge 类，
     * 但也不要将 aux[] 变为 merge() 的局部变量（请见本书的答疑部分）。
     * 提示：可以将辅助数组作为参数传递给递归的 sort() 方法。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort merge = new MergeSort();
            int[] data = SortCompare.GetRandomArrayInt(200);
            merge.Sort(data);
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + " ");
            }
        }
    }
}
