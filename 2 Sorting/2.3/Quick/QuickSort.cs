﻿using System;
using System.Diagnostics;
// ReSharper disable CognitiveComplexity

namespace Quick;

/// <summary>
/// 快速排序类。
/// </summary>
public class QuickSort : BaseSort
{
    /// <summary>
    /// 用快速排序对数组 a 进行升序排序。
    /// </summary>
    /// <typeparam name="T">需要排序的类型。</typeparam>
    /// <param name="a">需要排序的数组。</param>
    public override void Sort<T>(T[] a)
    {
        Shuffle(a);
        Sort(a, 0, a.Length - 1);
        Debug.Assert(IsSorted(a));
    }

    /// <summary>
    /// 用快速排序对数组 a 的 lo ~ hi 范围排序。
    /// </summary>
    /// <typeparam name="T">需要排序的数组类型。</typeparam>
    /// <param name="a">需要排序的数组。</param>
    /// <param name="lo">排序范围的起始下标。</param>
    /// <param name="hi">排序范围的结束下标。</param>
    protected void Sort<T>(T[] a, int lo, int hi) where T: IComparable<T>
    {
        if (hi <= lo)                   // 别越界
            return;
        var j = Partition(a, lo, hi);
        Sort(a, lo, j - 1);
        Sort(a, j + 1, hi);
    }

    /// <summary>
    /// 对数组进行切分，返回枢轴位置。
    /// </summary>
    /// <typeparam name="T">需要切分的数组类型。</typeparam>
    /// <param name="a">需要切分的数组。</param>
    /// <param name="lo">切分的起始点。</param>
    /// <param name="hi">切分的末尾点。</param>
    /// <returns>枢轴下标。</returns>
    private int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
    {
        int i = lo, j = hi + 1;
        var v = a[lo];
        while (true)
        {
            while (Less(a[++i], v))
                if (i == hi)
                    break;
            while (Less(v, a[--j]))
                if (j == lo)
                    break;
            if (i >= j)
                break;
            Exch(a, i, j);
        }
        Exch(a, lo, j);
        return j;
    }

    /// <summary>
    /// 令 a[k] 变成第 k 小的元素。
    /// </summary>
    /// <typeparam name="T">元素类型。</typeparam>
    /// <param name="a">需要排序的数组。</param>
    /// <param name="k">序号</param>
    /// <returns>第 <paramref name="k"/> 小的元素。</returns>
    /// <exception cref="IndexOutOfRangeException">当序号超出数组范围时抛出此异常。</exception>
    public T Select<T>(T[] a, int k) where T : IComparable<T>
    {
        if (k < 0 || k > a.Length)
            throw new IndexOutOfRangeException("Select elements out of bounds");
        Shuffle(a);
        int lo = 0, hi = a.Length - 1;
        while (hi > lo)
        {
            var i = Partition(a, lo, hi);
            if (i > k)
                hi = i - 1;
            else if (i < k)
                lo = i + 1;
            else
                return a[i];
        }
        return a[lo];
    }

    /// <summary>
    /// 打乱数组。
    /// </summary>
    /// <typeparam name="T">需要打乱的数组类型。</typeparam>
    /// <param name="a">需要打乱的数组。</param>
    private void Shuffle<T>(T[] a)
    {
        var random = new Random();
        for (var i = 0; i < a.Length; i++)
        {
            var r = i + random.Next(a.Length - i);
            var temp = a[i];
            a[i] = a[r];
            a[r] = temp;
        }
    }
}