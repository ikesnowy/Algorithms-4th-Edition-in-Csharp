using System;

namespace PriorityQueue
{
    /// <summary>
    /// 面向中位数的堆。
    /// </summary>
    public class MedianPQ<Key> where Key : IComparable<Key>
    {
        /// <summary>
        /// 最大堆（保存前半段元素）。
        /// </summary>
        /// <value>最大堆（保存前半段元素）。</value>
        private MaxPQ<Key> maxPQ;
        /// <summary>
        /// 最小堆（保存后半段元素）。
        /// </summary>
        /// <value>最小堆（保存后半段元素）。</value>
        private MinPQ<Key> minPQ;
        /// <summary>
        /// 中位数。
        /// </summary>
        /// <value>中位数。</value>
        private Key median;
        /// <summary>
        /// 堆的大小。
        /// </summary>
        /// <value>堆的大小。</value>
        private int n;

        /// <summary>
        /// 默认构造函数，构造一个面向中位数的堆。
        /// </summary>
        public MedianPQ()
        {
            this.maxPQ = new MaxPQ<Key>();
            this.minPQ = new MinPQ<Key>();
            this.median = default(Key);
            this.n = 0;
        }

        /// <summary>
        /// 构造一个指定容量的面向中位数的堆。
        /// </summary>
        /// <param name="capacity">初始容量。</param>
        public MedianPQ(int capacity)
        {
            this.maxPQ = new MaxPQ<Key>((capacity - 1) / 2);
            this.minPQ = new MinPQ<Key>((capacity - 1) / 2);
            this.n = 0;
            this.median = default(Key);
        }

        /// <summary>
        /// 根据指定数组初始化面向中位数的堆。
        /// </summary>
        /// <param name="keys">初始数组。</param>
        public MedianPQ(Key[] keys)
        {
            this.minPQ = new MinPQ<Key>();
            this.maxPQ = new MaxPQ<Key>();

            if (keys.Length == 0)
            {
                this.n = 0;
                this.median = default(Key);
                return;
            }

            this.n = keys.Length;
            this.median = keys[0];
            for (int i = 1; i < keys.Length; i++)
            {
                if (this.median.CompareTo(keys[i]) < 0)
                    this.minPQ.Insert(keys[i]);
                else
                    this.maxPQ.Insert(keys[i]);
            }

            UpdateMedian();
        }

        /// <summary>
        /// 向面向中位数的堆中插入一个元素。
        /// </summary>
        /// <param name="key">需要插入的元素。</param>
        public void Insert(Key key)
        {
            if (this.n == 0)
            {
                this.n++;
                this.median = key;
                return;
            }

            if (key.CompareTo(this.median) < 0)
                this.maxPQ.Insert(key);
            else
                this.minPQ.Insert(key);

            this.n++;
            UpdateMedian();
        }

        /// <summary>
        /// 删除并返回中位数。
        /// </summary>
        /// <returns>中位数。</returns>
        /// <exception cref="ArgumentOutOfRangeException">当堆为空时抛出该异常。</exception>
        /// <remarks>如果希望获得中位数但不将其删除，请使用 <see cref="Median"/>。</remarks>
        public Key DelMedian()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException("MedianPQ underflow!");
            Key median = this.median;

            if (this.n == 1)
            {
                this.n--;
                this.median = default(Key);
                return median;
            }

            // 从较大的一侧堆中取元素作为新的中位数。
            if (this.minPQ.Size() > this.maxPQ.Size())
                this.median = this.minPQ.DelMin();
            else
                this.median = this.maxPQ.DelMax();

            this.n--;
            return median;
        }

        /// <summary>
        /// 获得中位数。
        /// </summary>
        /// <returns>中位数。</returns>
        /// <remarks>如果希望删除并返回中位数，请使用 <see cref="DelMedian"/>。</remarks>
        public Key Median() => this.median;

        /// <summary>
        /// 判断堆是否为空。
        /// </summary>
        /// <returns>若堆为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => this.n == 0;

        /// <summary>
        /// 更新中位数的值。
        /// </summary>
        private void UpdateMedian()
        {
            // 根据两个堆的大小调整中位数
            while (this.maxPQ.Size() - this.minPQ.Size() > 1)
            {
                this.minPQ.Insert(this.median);
                this.median = this.maxPQ.DelMax();
            }
            while (this.minPQ.Size() - this.maxPQ.Size() > 1)
            {
                this.maxPQ.Insert(this.median);
                this.median = this.minPQ.DelMin();
            }
        }
    }
}
