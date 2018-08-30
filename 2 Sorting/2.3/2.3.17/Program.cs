using System;
using Quick;

namespace _2._3._17
{
    /*
     * 2.3.17
     * 
     * 哨兵。
     * 修改算法 2.5，去掉内循环 while 中的边界检查。
     * 由于切分元素本身就是一个哨兵（v 不可能小于 a[lo]），
     * 左侧边界检查是多余的。
     * 要去掉另一个检查，可以在打乱数组后将数组的最大元素方法 a[length - 1] 中。
     * 该元素永远不会移动（除非和相等的元素交换），
     * 可以在所有包含它的子数组中成为哨兵。
     * 注意：在处理内部子数组时，
     * 右子数组中最左侧的元素可以作为左子数组右边界的哨兵。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort quick = new QuickSort();
            QuickSortX quickSortX = new QuickSortX();
            int arrayLength = 1000000;
            int[] a = SortCompare.GetRandomArrayInt(arrayLength);
            int[] b = new int[arrayLength];
            a.CopyTo(b, 0);

            double time1 = SortCompare.Time(quick, a);
            double time2 = SortCompare.Time(quickSortX, b);
            Console.WriteLine("QSort\tQSort with Sentinels\t");
            Console.WriteLine(time1 + "\t" + time2 + "\t");
        }
    }
}
