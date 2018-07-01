using System;

namespace _2._2._26
{
    /*
     * 2.2.26
     * 
     * 创建数组。
     * 使用 SortCompare 粗略比较在你的计算机上
     * 在 merge() 中和在 sort() 中创建 aux[] 的性能差异。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            AuxInSortMergeSort auxInSort = new AuxInSortMergeSort();
            AuxInMergeMergeSort auxInMerge = new AuxInMergeMergeSort();
            int[] data1 = SortCompare.GetRandomArrayInt(100000);
            int[] data2 = new int[data1.Length];
            data1.CopyTo(data2, 0);
            Console.WriteLine("在Sort中创建aux[]\t" + SortCompare.Time(auxInSort, data1) + "ms");
            Console.WriteLine("在Merge中创建aux[]\t" + SortCompare.Time(auxInMerge, data2) + "ms");
            
        }
    }
}
