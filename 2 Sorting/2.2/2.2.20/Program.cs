using System;
using _2._2._20;

var mergeSort = new MergeSort();
var a = new[] { 2, 4, 6, 8, 1, 3, 5, 7, 9 };

var index = mergeSort.IndexSort(a);

Console.Write("Index \t");
for (var i = 0; i < a.Length; i++)
{
    Console.Write(i + " ");
}

Console.WriteLine();

Console.Write("Array\t");
for (var i = 0; i < a.Length; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();

Console.Write("Sorted\t");
for (var i = 0; i < index.Length; i++)
{
    Console.Write(index[i] + " ");
}

Console.WriteLine();