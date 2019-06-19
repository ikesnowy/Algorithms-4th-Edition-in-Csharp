using System;
using Merge;

namespace _2._2._9
{
    class Program
    {
        static void Main(string[] args)
        {
            var merge = new MergeSort();
            var data = SortCompare.GetRandomArrayInt(200);
            merge.Sort(data);
            for (var i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + " ");
            }
        }
    }
}