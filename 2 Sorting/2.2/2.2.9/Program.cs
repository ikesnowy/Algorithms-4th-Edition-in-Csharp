using System;
using Merge;

namespace _2._2._9
{
    
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
