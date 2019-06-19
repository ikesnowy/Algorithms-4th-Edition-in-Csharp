﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PriorityQueue
{
    /// <summary>
    /// 最小堆。（数组实现）
    /// </summary>
    /// <typeparam name="Key">最小堆中保存的元素类型。</typeparam>
    public class MinPQ<Key> : IMinPQ<Key>, IEnumerable<Key> where Key : IComparable<Key>
    {
        /// <summary>
        /// 保存元素的数组。
        /// </summary>
        /// <value>保存元素的数组。</value>
        protected Key[] pq;
        /// <summary>
        /// 堆中元素的数量。
        /// </summary>
        /// <value>堆中元素的数量。</value>
        protected int n;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MinPQ() : this(1) { }

        /// <summary>
        /// 建立指定容量的最小堆。
        /// </summary>
        /// <param name="capacity">最小堆的容量。</param>
        public MinPQ(int capacity)
        {
            pq = new Key[capacity + 1];
            n = 0;
        }

        /// <summary>
        /// 从已有元素建立一个最小堆。（O(n)）
        /// </summary>
        /// <param name="keys">已有元素。</param>
        public MinPQ(Key[] keys)
        {
            n = keys.Length;
            pq = new Key[keys.Length + 1];
            for (var i = 0; i < keys.Length; i++)
                pq[i + 1] = keys[i];
            for (var k = n / 2; k >= 1; k--)
                Sink(k);
            Debug.Assert(IsMinHeap());
        }

        /// <summary>
        /// 删除并返回最小元素。
        /// </summary>
        /// <returns>最小元素。</returns>
        /// <exception cref="ArgumentOutOfRangeException">如果堆为空则抛出该异常。</exception>
        /// <remarks>如果希望获得最小值但不删除它，请使用 <see cref="Min"/>。</remarks>
        public Key DelMin()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException("Priority Queue Underflow");

            var min = pq[1];
            Exch(1, n--);
            Sink(1);
            pq[n + 1] = default(Key);
            if ((n > 0) && (n == pq.Length / 4))
                Resize(pq.Length / 2);

            //Debug.Assert(IsMinHeap());
            return min;
        }

        /// <summary>
        /// 删除指定元素。
        /// </summary>
        /// <param name="k">元素下标。</param>
        internal void Remove(int k)
        {
            if (k == n)
            {
                pq[n--] = default(Key);
                return;
            }
            else if (n <= 2)
            {
                Exch(1, k);
                pq[n--] = default(Key);
                return;
            }
            Exch(k, n--);
            pq[n + 1] = default(Key);
            Swim(k);
            Sink(k);
        }

        /// <summary>
        /// 向堆中插入一个元素。
        /// </summary>
        /// <param name="v">需要插入的元素。</param>
        public void Insert(Key v)
        {
            if (n == pq.Length - 1)
                Resize(2 * pq.Length);

            pq[++n] = v;
            Swim(n);
            //Debug.Assert(IsMinHeap());
        }

        /// <summary>
        /// 检查堆是否为空。
        /// </summary>
        /// <returns>如果堆为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => n == 0;

        /// <summary>
        /// 获得堆中最小元素。
        /// </summary>
        /// <returns>堆中最小元素。</returns>
        /// <remarks>如果希望获得并删除最小元素，请使用 <see cref="DelMin"/>。</remarks>
        public Key Min() => pq[1];

        /// <summary>
        /// 获得堆中元素的数量。
        /// </summary>
        /// <returns>堆中元素的数量。</returns>
        public int Size() => n;

        /// <summary>
        /// 获取堆的迭代器，元素以升序排列。
        /// </summary>
        /// <returns>最小堆的迭代器。</returns>
        public IEnumerator<Key> GetEnumerator()
        {
            var copy = new MinPQ<Key>(n);
            for (var i = 1; i <= n; i++)
                copy.Insert(pq[i]);

            while (!copy.IsEmpty())
                yield return copy.DelMin(); // 下次迭代的时候从这里继续执行。
        }

        /// <summary>
        /// 获取堆的迭代器，元素以升序排列。
        /// </summary>
        /// <returns>最小堆的迭代器。</returns>
        /// <remarks>该方法实际调用的是 <see cref="GetEnumerator"/> 方法。</remarks>
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
            while (k > 1 && Greater(k / 2, k))
            {
                Exch(k, k / 2);
                k /= 2;
            }
        }

        /// <summary>
        /// 使元素下沉。
        /// </summary>
        /// <param name="k">需要下沉的元素。</param>
        private void Sink(int k)
        {
            while (k * 2 <= n)
            {
                var j = 2 * k;
                if (j < n && Greater(j, j + 1))
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
            var temp = new Key[capacity];
            for (var i = 1; i <= n; i++)
            {
                temp[i] = pq[i];
            }
            pq = temp;
        }

        /// <summary>
        /// 判断堆中某个元素是否大于另一元素。
        /// </summary>
        /// <param name="i">判断是否较大的元素。</param>
        /// <param name="j">判断是否较小的元素。</param>
        /// <returns>如果下标为 <paramref name="i"/> 的元素较大，则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Greater(int i, int j)
            => pq[i].CompareTo(pq[j]) > 0;

        /// <summary>
        /// 交换堆中的两个元素。
        /// </summary>
        /// <param name="i">要交换的第一个元素下标。</param>
        /// <param name="j">要交换的第二个元素下标。</param>
        protected virtual void Exch(int i, int j)
        {
            var swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
        }

        /// <summary>
        /// 检查当前二叉树是不是一个最小堆。
        /// </summary>
        /// <returns>如果是则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool IsMinHeap() => IsMinHeap(1);

        /// <summary>
        /// 确定以 k 为根节点的二叉树是不是一个最小堆。
        /// </summary>
        /// <param name="k">需要检查的二叉树根节点。</param>
        /// <returns>如果是则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool IsMinHeap(int k)
        {
            if (k > n)
                return true;
            var left = 2 * k;
            var right = 2 * k + 1;
            if (left <= n && Greater(k, left))
                return false;
            if (right <= n && Greater(k, right))
                return false;

            return IsMinHeap(left) && IsMinHeap(right);
        }
    }
}
