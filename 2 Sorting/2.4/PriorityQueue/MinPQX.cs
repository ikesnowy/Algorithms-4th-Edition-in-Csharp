﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PriorityQueue;

/// <summary>
/// 用二分查找优化的最小堆。（数组实现）
/// </summary>
public class MinPqx<TKey> : IMinPq<TKey>, IEnumerable<TKey> where TKey : IComparable<TKey>
{
    /// <summary>
    /// 保存元素的数组。
    /// </summary>
    /// <value>保存元素的数组。</value>
    protected TKey?[] Pq;
    /// <summary>
    /// 堆中元素的数量。
    /// </summary>
    /// <value>堆中元素的数量。</value>
    protected int N;

    /// <summary>
    /// 默认构造函数。
    /// </summary>
    public MinPqx() : this(1) { }

    /// <summary>
    /// 建立指定容量的最小堆。
    /// </summary>
    /// <param name="capacity">最小堆的容量。</param>
    public MinPqx(int capacity)
    {
        Pq = new TKey?[capacity + 1];
        N = 0;
    }

    /// <summary>
    /// 从已有元素建立一个最小堆。（O(n)）
    /// </summary>
    /// <param name="keys">已有元素。</param>
    public MinPqx(TKey?[] keys)
    {
        N = keys.Length;
        Pq = new TKey?[keys.Length + 1];
        for (var i = 0; i < keys.Length; i++)
            Pq[i + 1] = keys[i];
        for (var k = N / 2; k >= 1; k--)
            Sink(k);
        Debug.Assert(IsMinHeap());
    }

    /// <summary>
    /// 删除并返回最小元素。
    /// </summary>
    /// <returns></returns>
    public TKey? DelMin()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Priority Queue Underflow");

        var min = Pq[1];
        Exch(1, N--);
        Sink(1);
        Pq[N + 1] = default;
        if ((N > 0) && (N == Pq.Length / 4))
            Resize(Pq.Length / 2);

        //Debug.Assert(IsMinHeap());
        return min;
    }

    /// <summary>
    /// 删除指定元素。
    /// </summary>
    /// <param name="k">元素下标。</param>
    internal void Remove(int k)
    {
        if (k == N)
        {
            Pq[N--] = default;
            return;
        }

        if (N <= 2)
        {
            Exch(1, k);
            Pq[N--] = default;
            return;
        }
        Exch(k, N--);
        Pq[N + 1] = default;
        Swim(k);
        Sink(k);
    }

    /// <summary>
    /// 向堆中插入一个元素。
    /// </summary>
    /// <param name="v">需要插入的元素。</param>
    public void Insert(TKey? v)
    {
        if (N == Pq.Length - 1)
            Resize(2 * Pq.Length);

        Pq[++N] = v;
        Swim(N);
        Debug.Assert(IsMinHeap());
    }

    /// <summary>
    /// 检查堆是否为空。
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty() => N == 0;

    /// <summary>
    /// 获得堆中最小元素。
    /// </summary>
    /// <returns></returns>
    public TKey? Min() => Pq[1];

    /// <summary>
    /// 获得堆中元素的数量。
    /// </summary>
    /// <returns></returns>
    public int Size() => N;

    /// <summary>
    /// 获取堆的迭代器，元素以升序排列。
    /// </summary>
    /// <returns></returns>
    public IEnumerator<TKey> GetEnumerator()
    {
        var copy = new MinPq<TKey>(N);
        for (var i = 1; i <= N; i++)
            copy.Insert(Pq[i]);

        while (!copy.IsEmpty())
            yield return copy.DelMin()!; // 下次迭代的时候从这里继续执行。
    }

    /// <summary>
    /// 获取堆的迭代器，元素以升序排列。
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// 使元素上浮。
    /// </summary>
    /// <param name="k">需要上浮的元素。</param>
    private void Swim(int k)
    {
        if (k == 1)
            return;

        // 获取路径
        var path = new List<int>();
        var temp = k;
        while (temp >= 1)
        {
            path.Add(temp);
            temp /= 2;
        }

        // lo=插入结点的父结点 hi=根结点
        int lo = 1, hi = path.Count - 1;
        while (lo <= hi)
        {
            var mid = lo + (hi - lo) / 2;
            if (Greater(k, path[mid]))
                hi = mid - 1;   // 当前值比较大，应该向下走
            else
                lo = mid + 1;   // 值较小，向根结点方向走
        }

        for (var i = 1; i < lo; i++)
        {
            Exch(path[i - 1], path[i]);
        }
    }

    /// <summary>
    /// 使元素下沉。
    /// </summary>
    /// <param name="k">需要下沉的元素。</param>
    private void Sink(int k)
    {
        while (k * 2 <= N)
        {
            var j = 2 * k;
            if (j < N && Greater(j, j + 1))
                j++;
            if (!Greater(k, j))
                break;
            Exch(k, j);
            k = j;
        }
    }

    /// <summary>
    /// 重新调整堆的大小。
    /// </summary>
    /// <param name="capacity">调整后的堆大小。</param>
    private void Resize(int capacity)
    {
        var temp = new TKey?[capacity];
        for (var i = 1; i <= N; i++)
        {
            temp[i] = Pq[i];
        }
        Pq = temp;
    }

    /// <summary>
    /// 判断堆中某个元素是否大于另一元素。
    /// </summary>
    /// <param name="i">判断是否较大的元素。</param>
    /// <param name="j">判断是否较小的元素。</param>
    /// <returns></returns>
    private bool Greater(int i, int j)
        => Pq[i]?.CompareTo(Pq[j]) > 0;

    /// <summary>
    /// 交换堆中的两个元素。
    /// </summary>
    /// <param name="i">要交换的第一个元素下标。</param>
    /// <param name="j">要交换的第二个元素下标。</param>
    protected virtual void Exch(int i, int j)
    {
        var swap = Pq[i];
        Pq[i] = Pq[j];
        Pq[j] = swap;
    }

    /// <summary>
    /// 检查当前二叉树是不是一个最小堆。
    /// </summary>
    /// <returns></returns>
    private bool IsMinHeap() => IsMinHeap(1);

    /// <summary>
    /// 确定以 k 为根节点的二叉树是不是一个最小堆。
    /// </summary>
    /// <param name="k">需要检查的二叉树根节点。</param>
    /// <returns></returns>
    private bool IsMinHeap(int k)
    {
        if (k > N)
            return true;
        var left = 2 * k;
        var right = 2 * k + 1;
        if (left <= N && Greater(k, left))
            return false;
        if (right <= N && Greater(k, right))
            return false;

        return IsMinHeap(left) && IsMinHeap(right);
    }
}