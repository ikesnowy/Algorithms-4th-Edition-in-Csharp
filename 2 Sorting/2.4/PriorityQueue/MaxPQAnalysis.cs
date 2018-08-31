using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PriorityQueue
{
    /// <summary>
    /// 最大堆。（数组实现）
    /// </summary>
    /// <typeparam name="int">最大堆中保存的元素类型。</typeparam>
    public class MaxPQAnalysis : IMaxPQ<int>, IEnumerable<int>
    {
        private int[] pq;               // 保存元素的数组。
        private int n;                  // 堆中的元素数量。

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MaxPQAnalysis() : this(1) { }

        /// <summary>
        /// 建立指定容量的最大堆。
        /// </summary>
        /// <param name="capacity">最大堆的容量。</param>
        public MaxPQAnalysis(int capacity)
        {
            this.pq = new int[capacity + 1];
            this.n = 0;
        }

        /// <summary>
        /// 从已有元素建立一个最大堆。（O(n)）
        /// </summary>
        /// <param name="keys">已有元素。</param>
        public MaxPQAnalysis(int[] keys)
        {
            this.n = keys.Length;
            this.pq = new int[keys.Length + 1];
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
        public int DelMax()
        {
            if (IsEmpty())
                throw new ArgumentOutOfRangeException("Priority Queue Underflow");

            int max = this.pq[1];
            Exch(1, this.n--);
            this.pq[this.n + 1] = this.pq[1];
            Sink(1);
            this.pq[this.n + 1] = default(int);
            if ((this.n > 0) && (this.n == this.pq.Length / 4))
                Resize(this.pq.Length / 2);

            // Debug.Assert(IsMaxHeap());
            return max;
        }

        /// <summary>
        /// 向堆中插入一个元素。
        /// </summary>
        /// <param name="v">需要插入的元素。</param>
        public void Insert(int v)
        {
            if (this.n == this.pq.Length - 1)
                Resize(2 * this.pq.Length);

            this.pq[++this.n] = v;
            Swim(this.n);
            // Debug.Assert(IsMaxHeap());
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
        public int Max() => this.pq[1];

        /// <summary>
        /// 获得堆中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size() => this.n;

        /// <summary>
        /// 获取堆的迭代器，元素以降序排列。
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> GetEnumerator()
        {
            MaxPQ<int> copy = new MaxPQ<int>(this.n);
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
                if (Less(j, j + 1))
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
            int[] temp = new int[capacity];
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
            int swap = this.pq[i];
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

        public int PullDown(int i, int j)
        {
            int toReturn = this.pq[j];
            for (int m = j; m / 2 >= i; m /= 2)
            {
                this.pq[m] = this.pq[m / 2];
            }
            return toReturn;
        }

        public MaxPQAnalysis UnFixHeap(int i)
        {
            int j = (int)(i * Math.Pow(2, Math.Log10(this.n / i)));
            this.pq[i] = PullDown(i, j);
            return this;
        }

        public MaxPQAnalysis UnRemoveMax(int i)
        {
            int p = (this.n + 1) / 2;
            if (Less(p, i))
                return null;
            this.n++;
            this.pq[this.n] = PullDown(1, i);
            this.pq[1] = this.n;
            return this;
        }

        public int[] Par(int l)
        {
            int n = (int)Math.Pow(2, l) - 1;
            int[] s7 = { 0, 1, 2, 3, 4, 4, 5 };
            int[] strategy = new int[n];
            for (int i = 0; i < Math.Min(n, 7); i++)
            {
                strategy[i] = s7[i];
            }

            if (n <= 7)
                return strategy;

            for (int lev = 3; lev < l; lev++)
            {
                int i = (int)Math.Pow(2, lev) - 1;
                strategy[i] = i;
                strategy[i + 1] = i - 1;
                strategy[i + 2] = i + 1;
                strategy[i + 3] = i + 2;
                strategy[i + 4] = i + 4;
                strategy[i + 5] = i + 3;
                for (int k = i + 6; k <= 2 * i; k++)
                {
                    strategy[k] = k - 1;
                }
            }
            return strategy;
        }

        public int[] Win(int n)
        {
            int[] strategy = new int[n];
            int[] s = Par((int)Math.Floor(Math.Log10(n)) + 1);
            for (int i = 1; i <= n - 1; i++)
            {
                strategy[i] = s[i];
            }
            int I = (int)Math.Pow(2, Math.Floor(Math.Log10(n + 1))) - 1;
            if ((n == I) || (n <= 7))
                return strategy;
            strategy[I] = I;
            if (n == I + 1)
                return strategy;
            strategy[I + 1] = (I + 1) / 2;
            if (n == I + 2)
                return strategy;
            for (int i = I + 2; i <= n - 1; i++)
            {
                if (i == 2 * I - 2)
                    strategy[i] = i;
                else
                    strategy[i] = i - 1;
            }
            return strategy;
        }

        public void MakeWorst(int n)
        {
            int[] strategy = Win(n);
            for (int i = 0; i < strategy.Length; i++)
            {
                
            }
        }
    }
}
