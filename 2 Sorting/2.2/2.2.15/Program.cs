﻿using System;
using _2._2._15;

var a = new[] { 1, 3, 5, 7, 9, 2, 4, 6, 8 };
var mergeSort = new MergeSortQueue();
mergeSort.Sort(a);
for (var i = 0; i < a.Length; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();