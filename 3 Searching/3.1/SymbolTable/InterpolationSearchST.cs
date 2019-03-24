using System;
using System.Collections.Generic;

namespace SymbolTable
{
    /// <summary>
    /// 符号表，基于有序表，利用插值法实现搜索。
    /// </summary>
    public class InterpolationSearchST : IST<double, int>, IOrderedST<double, int>
    {
        /// <summary>
        /// 符号表的默认长度。
        /// </summary>
        /// <value>符号表的默认长度。</value>
        private static readonly int INIT_CAPACITY = 2;
        /// <summary>
        /// 保存符号表键的数组。
        /// </summary>
        /// <value>保存符号表键的数组。</value>
        private double[] keys;
        /// <summary>
        /// 保存符号表值的数组。
        /// </summary>
        /// <value>保存符号表值的数组。</value>
        private int[] values;
        /// <summary>
        /// 符号表中的键值对数量。
        /// </summary>
        /// <value>符号表中的键值对数量。</value>
        private int n;

        /// <summary>
        /// 构造一个空的符号表。
        /// </summary>
        public InterpolationSearchST() : this(INIT_CAPACITY) { }

        /// <summary>
        /// 构造一个指定容量的符号表。
        /// </summary>
        /// <param name="capacity">符号表初始容量。</param>
        public InterpolationSearchST(int capacity)
        {
            this.keys = new double[capacity];
            this.values = new int[capacity];
            this.n = 0;
        }

        /// <summary>
        /// 大于等于 <paramref name="key"/> 的最小的键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>符号表中大于等于 <paramref name="key"/> 的最小的键。</returns>
        public double Ceiling(double key)
        {
            int i = Rank(key);
            if (i == this.n)
                return default(double);
            else
                return this.keys[i];
        }

        /// <summary>
        /// 检查 <paramref name="key"/> 是否已在符号表中。
        /// </summary>
        /// <param name="key">要检查是否存在的键。</param>
        /// <returns>若 <paramref name="key"/> 存在则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(double key)
        {
            return !Get(key).Equals(default(double));
        }

        /// <summary>
        /// 从符号表中删除键为 <paramref name="key"/> 的键值对。
        /// </summary>
        /// <param name="key">要删除的键。</param>
        public void Delete(double key)
        {
            if (IsEmpty())
                return;

            int i = Rank(key);

            if (i == this.n && this.keys[i].CompareTo(key) != 0)
                return;

            for (int j = i; j < this.n - 1; j++)
            {
                this.keys[j] = this.keys[j + 1];
                this.values[j] = this.values[j + 1];
            }

            this.n--;
            this.keys[this.n] = default(double);
            this.values[this.n] = default(int);

            if (this.n > 0 && this.n == this.keys.Length / 4)
                Resize(this.n / 2);
        }

        /// <summary>
        /// 删除键最大的键值对。
        /// </summary>
        public void DeleteMax() => Delete(Max());

        /// <summary>
        /// 删除键最小的键值对。
        /// </summary>
        public void DeleteMin() => Delete(Min());

        /// <summary>
        /// 符号表中小于等于 <paramref name="key"/> 的最大键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>小于等于 <paramref name="key"/> 的最大键。</returns>
        public double Floor(double key)
        {
            int i = Rank(key);
            if (i < this.n && this.keys[i].CompareTo(key) == 0)
                return this.keys[i];
            if (i == 0)
                return default(double);
            else
                return this.keys[i - 1];
        }

        /// <summary>
        /// 根据键获得对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns><paramref name="key"/> 对应的值。</returns>
        public int Get(double key)
        {
            if (IsEmpty())
                return default(int);
            int rank = Rank(key);
            if (rank < this.n && this.keys[rank].Equals(key))
                return this.values[rank];
            return default(int);
        }

        /// <summary>
        /// 符号表是否为空。
        /// </summary>
        /// <returns>如果符号表为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty() => this.n == 0;

        /// <summary>
        /// 获得全部键的集合。
        /// </summary>
        /// <returns>全部键的集合。</returns>
        public IEnumerable<double> Keys() => Keys(Min(), Max());

        /// <summary>
        /// 获得所有位于区间 [<paramref name="lo"/>, <paramref name="hi"/>] 内的键。
        /// </summary>
        /// <param name="lo">区间起点。</param>
        /// <param name="hi">区间终点。</param>
        /// <returns>区间 [<paramref name="lo"/>, <paramref name="hi"/>] 内的键。</returns>
        public IEnumerable<double> Keys(double lo, double hi)
        {
            List<double> list = new List<double>();
            if (lo.CompareTo(hi) > 0)
                return list;
            for (int i = Rank(lo); i < Rank(hi); i++)
                list.Add(this.keys[i]);
            if (Contains(hi))
                list.Add(this.keys[Rank(hi)]);
            return list;
        }

        /// <summary>
        /// 获得符号表中最大的键。
        /// </summary>
        /// <returns>符号表中最大的键。</returns>
        public double Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException("called Max() with empty table");
            return this.keys[this.n - 1];
        }

        /// <summary>
        /// 获得符号表中最小的键。
        /// </summary>
        /// <returns>符号表中最小的键。</returns>
        /// <exception cref="InvalidOperationException">当符号表为空时抛出此异常。</exception>
        public double Min()
        {
            if (IsEmpty())
                throw new InvalidOperationException("called Min() with empty table");
            return this.keys[0];
        }

        /// <summary>
        /// 向符号表插入一个新的键值对，如果键已存在则覆盖。
        /// </summary>
        /// <param name="key">要插入的键。</param>
        /// <param name="value">要插入的值。</param>
        public void Put(double key, int value)
        {
            int i = Rank(key);

            if (i < this.n && this.keys[i].CompareTo(key) == 0)
            {
                this.values[i] = value;
                return;
            }

            if (this.n == this.keys.Length)
                Resize(this.n * 2);

            for (int j = this.n; j > i; j--)
            {
                this.keys[j] = this.keys[j - 1];
                this.values[j] = this.values[j - 1];
            }
            this.keys[i] = key;
            this.values[i] = value;
            this.n++;
        }

        /// <summary>
        /// 小于 <paramref name="key"/> 的键的个数。
        /// </summary>
        /// <param name="key">需要比较的键。</param>
        /// <returns>小于 <paramref name="key"/> 的键的个数。</returns>
        public int Rank(double key)
        {
            int lo = 0, hi = this.n - 1;
            while (lo < hi)
            {
                double percent = (key - this.keys[lo]) / (this.keys[hi] - this.keys[lo]);
                int index = lo + (int)Math.Floor((hi - lo) * percent);
                if (percent < 0)
                    index = lo;
                if (percent > 1)
                    index = hi;

                int compare = this.keys[index].CompareTo(key);
                if (compare > 0)
                    hi = index - 1;
                else if (compare < 0)
                    lo = index + 1;
                else
                    return index;
            }
            return lo;
        }

        /// <summary>
        /// 使得符号表中的第 <paramref name="k"/> 个键正好是第 <paramref name="k"/> 小的键。
        /// </summary>
        /// <param name="k">要挑拣的排名。</param>
        /// <returns>第 <paramref name="k"/> 小的键。</returns>
        /// <exception cref="ArgumentOutOfRangeException">当 <paramref name="k"/> 超出数组范围时抛出此异常。</exception>
        public double Select(int k)
        {
            if (k < 0 || k >= this.n)
                throw new ArgumentOutOfRangeException("called Select() with invaild k: " + k);
            return this.keys[k];
        }

        /// <summary>
        /// 符号表中的键值对数量。
        /// </summary>
        /// <returns>符号表中的键值对数量。</returns>
        public int Size() => this.n;

        /// <summary>
        /// 获得区间 [<paramref name="lo"/>, <paramref name="hi"/>] 之间的键的数量。
        /// </summary>
        /// <param name="lo">区间起点。</param>
        /// <param name="hi">区间末尾。</param>
        /// <returns>[<paramref name="lo"/>, <paramref name="hi"/>] 之间键的数目。</returns>
        public int Size(double lo, double hi)
        {
            if (lo.CompareTo(hi) > 0)
                return 0;
            if (Contains(hi))
                return Rank(hi) - Rank(lo) + 1;
            else
                return Rank(hi) - Rank(lo);
        }

        /// <summary>
        /// 为符号表重新分配空间。
        /// </summary>
        /// <param name="capacity">重新分配的大小。</param>
        /// <exception cref="ArgumentOutOfRangeException">当 <paramref name="capacity"/> < <see cref="n"/> 时抛出该异常。</exception>
        private void Resize(int capacity)
        {
            if (capacity < this.n)
                throw new ArgumentOutOfRangeException("分配容量不能小于表中元素数量。");
            double[] tempKeys = new double[capacity];
            int[] tempValues = new int[capacity];
            for (int i = 0; i < this.n; i++)
            {
                tempKeys[i] = this.keys[i];
                tempValues[i] = this.values[i];
            }
            this.keys = tempKeys;
            this.values = tempValues;
        }
    }
}
