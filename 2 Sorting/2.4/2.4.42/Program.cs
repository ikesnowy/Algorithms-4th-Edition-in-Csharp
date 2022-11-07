﻿using System;
using System.IO;
using PriorityQueue;
// ReSharper disable AssignNullToNotNullAttribute

var random = new Random();

Console.WriteLine("number\torigin\tpre-order\tRatio");

var n = 1000; // 当数据量到达 10^9 时会需要 2G 左右的内存
var multiTen = 7;
for (var i = 0; i < multiTen; i++)
{
    Console.Write("10^" + (i + 3) + "\t");
    var data = GetRandomArray(n);
    BackupArray(data, i); // 暂存数组
    var originCount = HeapAnalysis.Sort(data);
    Console.Write(originCount + "\t");

    RestoreArray(data, i); // 恢复数组
    var preorderCount = HeapPreorderAnalysis.Sort(data);
    Console.WriteLine(preorderCount + "\t" + (float)preorderCount / originCount + "\t");
    n *= 10;
}

void BackupArray(short[] data, int index)
{
    var sw =
        File.CreateText(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "data" + index + ".txt");
    for (var i = 0; i < data.Length; i++)
    {
        sw.WriteLine(data[i]);
    }

    sw.Flush();
    sw.Close();
}

void RestoreArray(short[] data, int index)
{
    var sr =
        File.OpenText(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "data" + index + ".txt");
    for (var i = 0; i < data.Length; i++)
    {
        data[i] = short.Parse(sr.ReadLine()!);
    }

    sr.Close();
}

short[] GetRandomArray(int number)
{
    var data = new short[number];
    for (var i = 0; i < number; i++)
    {
        data[i] = (short)random.Next();
    }

    return data;
}