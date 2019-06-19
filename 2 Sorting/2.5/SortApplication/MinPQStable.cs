using System;
using System.Collections;
using System.Collections.Generic;

namespace SortApplication
{
    /// <summary>
    /// 稳定的最小堆。（数组实现）
    /// </summary>
    /// <typeparam name="Key">最小堆中保存的元素类型。</typeparam>
    public class MinPQStable<Key> : IMinPQ<Key>, IEnumerable<Key> where Key : IComparable<Key>
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
        /// 元素的插入次序。
        /// </summary>
        /// <value>元素的插入次序。</value>
        private long[] time;
        /// <summary>
        /// 元素的插入次序计数器。
        /// </summary>
        /// <value>元素的插入次序计数器。</value>
        private long timeStamp = 1;       // 元素插入次序计数器。

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MinPQStable() : this(1) { }

        /// <summary>
        /// 建立指定容量的最小堆。
        /// </summary>
        /// <param name="capacity">最小堆的容量。</param>
        public MinPQStable(int capacity)
        {
            this.time = new long[capacity + 1];
            this.pq = new Key[capacity + 1];
            this.n = 0;
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

            Key min = this.pq[1];
            Exch(1, this.n--);
            Sink(1);
            this.pq[this.n + 1] = default(Key);
            this.time[this.n + 1] = 0;
            if ((this.n > 0) && (this.n == this.pq.Length / 4))
                Resize(this.pq.Length / 2);

            //Debug.Assert(IsMinHeap());
            return min;
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
            this.time[this.n] = ++this.timeStamp;
            Swim(this.n);
            //Debug.Assert(IsMinHeap());
        }

        /// <summary>
        /// 检查堆是否为空。
        /// </summary>
        /// <returns>如果堆为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => this.n == 0;

        /// <summary>
        /// 获得堆中最小元素。
        /// </summary>
        /// <returns>堆中最小元素。</returns>
        /// <remarks>如果希望获得并删除最小元素，请使用 <see cref="DelMin"/>。</remarks>
        public Key Min() => this.pq[1];

        /// <summary>
        /// 获得堆中元素的数量。
        /// </summary>
        /// <returns>堆中元素的数量。</returns>
        public int Size() => this.n;

        /// <summary>
        /// 获取堆的迭代器，元素以升序排列。
        /// </summary>
        /// <returns>最小堆的迭代器。</returns>
        public IEnumerator<Key> GetEnumerator()
        {
            MinPQStable<Key> copy = new MinPQStable<Key>(this.n);
            for (int i = 1; i <= this.n; i++)
                copy.Insert(this.pq[i]);

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
            while (k * 2 <= this.n)
            {
                int j = 2 * k;
                if (j < this.n && Greater(j, j + 1))
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
            Key[] temp = new Key[capacity];
            long[] timeTemp = new long[capacity];
            for (int i = 1; i <= this.n; i++)
            {
                temp[i] = this.pq[i];
                timeTemp[i] = this.time[i];
            }
            this.pq = temp;
            this.time = timeTemp;
        }

        /// <summary>
        /// 判断堆中某个元素是否大于另一元素。
        /// </summary>
        /// <param name="i">判断是否较大的元素。</param>
        /// <param name="j">判断是否较小的元素。</param>
        /// <returns>如果下标为 <paramref name="i"/> 的元素较大，则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        private bool Greater(int i, int j)
        {
            int cmp = this.pq[i].CompareTo(this.pq[j]);
            if (cmp == 0)
                return this.time[i].CompareTo(this.time[j]) > 0;
            return cmp > 0;
        }
            
        /// <summary>
        /// 交换堆中的两个元素。
        /// </summary>
        /// <param name="i">要交换的第一个元素下标。</param>
        /// <param name="j">要交换的第二个元素下标。</param>
        protected virtual void Exch(int i, int j)
        {
            Key swap = this.pq[i];
            this.pq[i] = this.pq[j];
            this.pq[j] = swap;

            long temp = this.time[i];
            this.time[i] = this.time[j];
            this.time[j] = temp;
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
            if (k > this.n)
                return true;
            int left = 2 * k;
            int right = 2 * k + 1;
            if (left <= this.n && Greater(k, left))
                return false;
            if (right <= this.n && Greater(k, right))
                return false;

            return IsMinHeap(left) && IsMinHeap(right);
        }
    }
}
