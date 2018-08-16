using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PriorityQueue
{
    /// <summary>
    /// 最大堆。（数组实现）
    /// </summary>
    /// <typeparam name="Key">最大堆中保存的元素。</typeparam>
    public class MaxPQ<Key> : IMaxPQ<Key>, IEnumerable<Key> where Key : IComparable<Key>
    {
        private Key[] pq;               // 保存元素的数组。
        private int n;                  // 堆中的元素数量。

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MaxPQ() : this(1) { }

        /// <summary>
        /// 建立指定容量的最大堆。
        /// </summary>
        /// <param name="capacity">最大堆的容量。</param>
        public MaxPQ(int capacity)
        {
            this.pq = new Key[capacity + 1];
            this.n = 0;
        }

        /// <summary>
        /// 从已有元素建立一个最大堆。（O(n)）
        /// </summary>
        /// <param name="keys">已有元素。</param>
        public MaxPQ(Key[] keys)
        {
            this.n = keys.Length;
            this.pq = new Key[keys.Length + 1];
            for (int i = 0; i < keys.Length; i++)
                this.pq[i + 1] = keys[i];
            for (int k = this.n / 2; k >= 1; k--)
                Sink(k);
            Debug.Assert(IsMaxHeap());
        }

        /// <summary>
        /// 删除并返回最大元素。
        /// </summary>
        /// <returns></returns>
        public Key DelMax()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException("Priority Queue Underflow");

            Key max = this.pq[1];
            Exch(1, this.n--);
            Sink(1);
            this.pq[this.n + 1] = default(Key);
            if ((this.n > 0) && (this.n == this.pq.Length / 4))
                Resize(this.pq.Length / 2);

            Debug.Assert(IsMaxHeap());
            return max;
        }

        /// <summary>
        /// 向堆中插入一个元素。
        /// </summary>
        /// <param name="v">需要插入的元素。</param>
        public void Insert(Key v)
        {
            if (this.n == this.pq.Length - 1)
                Resize(2 * this.pq.Length);

            this.pq[++this.n] = v;
            Swim(this.n);
            Debug.Assert(IsMaxHeap());
        }

        /// <summary>
        /// 检查堆是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => this.n == 0;

        /// <summary>
        /// 获得堆中最大元素。
        /// </summary>
        /// <returns></returns>
        public Key Max() => this.pq[1];

        /// <summary>
        /// 获得堆中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size() => this.n;

        /// <summary>
        /// 获取堆的迭代器，元素以降序排列。
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Key> GetEnumerator()
        {
            MaxPQ<Key> copy = new MaxPQ<Key>(this.n);
            for (int i = 1; i <= this.n; i++)
                copy.Insert(this.pq[i]);

            while (!copy.IsEmpty())
                yield return copy.DelMax(); // 下次迭代的时候从这里继续执行。
        }

        /// <summary>
        /// 获取堆的迭代器，元素以降序排列。
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
            while (k > 1 && Less(k / 2, k))
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
            while (k * 2 <= this.n)
            {
                int j = 2 * k;
                if (j < this.n && Less(j, j + 1))
                    j++;
                if (!Less(k, j))
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
            Key[] temp = new Key[capacity];
            for (int i = 1; i <= this.n; i++)
            {
                temp[i] = this.pq[i];
            }
            this.pq = temp;
        }

        /// <summary>
        /// 判断堆中某个元素是否小于另一元素。
        /// </summary>
        /// <param name="i">判断是否较小的元素。</param>
        /// <param name="j">判断是否较大的元素。</param>
        /// <returns></returns>
        private bool Less(int i, int j)
            => this.pq[i].CompareTo(this.pq[j]) < 0; 

        /// <summary>
        /// 交换堆中的两个元素。
        /// </summary>
        /// <param name="i">要交换的第一个元素下标。</param>
        /// <param name="j">要交换的第二个元素下标。</param>
        private void Exch(int i, int j)
        {
            Key swap = this.pq[i];
            this.pq[i] = this.pq[j];
            this.pq[j] = swap;
        }

        /// <summary>
        /// 检查当前二叉树是不是一个最大堆。
        /// </summary>
        /// <returns></returns>
        private bool IsMaxHeap() => IsMaxHeap(1);

        /// <summary>
        /// 确定以 k 为根节点的二叉树是不是一个最大堆。
        /// </summary>
        /// <param name="k">需要检查的二叉树根节点。</param>
        /// <returns></returns>
        private bool IsMaxHeap(int k)
        {
            if (k > this.n)
                return true;
            int left = 2 * k;
            int right = 2 * k + 1;
            if (left <= this.n && Less(k, left))
                return false;
            if (right <= this.n && Less(k, right))
                return false;

            return IsMaxHeap(left) && IsMaxHeap(right);
        }
    }
}
