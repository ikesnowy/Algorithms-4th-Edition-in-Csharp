using System;
using System.Collections.Generic;
using Merge;

namespace SymbolTable
{
    /// <summary>
    /// 符号表，基于有序表并应用了二分查找优化。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public class ItemBinarySearchST<TKey, TValue> : IST<TKey, TValue>, IOrderedST<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// 符号表的默认长度。
        /// </summary>
        /// <value>符号表的默认长度。</value>
        private static readonly int INIT_CAPACITY = 2;

        /// <summary>
        /// 符号表键值对数组。
        /// </summary>
        private Item<TKey, TValue>[] items;

        /// <summary>
        /// 符号表中的键值对数量。
        /// </summary>
        /// <value>符号表中的键值对数量。</value>
        private int n;

        /// <summary>
        /// 构造一个空的符号表。
        /// </summary>
        public ItemBinarySearchST() : this(INIT_CAPACITY) { }

        /// <summary>
        /// 构造一个指定容量的符号表。
        /// </summary>
        /// <param name="capacity">符号表初始容量。</param>
        public ItemBinarySearchST(int capacity)
        {
            this.items = new Item<TKey, TValue>[capacity];
            this.n = 0;
        }

        /// <summary>
        /// 根据已有的键值对构造一个符号表。
        /// </summary>
        /// <param name="items">已有的键值对。</param>
        public ItemBinarySearchST(Item<TKey, TValue>[] items)
        {
            this.items = new Item<TKey, TValue>[items.Length];
            Array.Copy(items, this.items, items.Length);
            this.n = items.Length;
            MergeSort merge = new MergeSort();
            merge.Sort(this.items);
        }

        /// <summary>
        /// 大于等于 <paramref name="key"/> 的最小的键。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>符号表中大于等于 <paramref name="key"/> 的最小的键。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出此异常。</exception>
        public TKey Ceiling(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Ceiling is null");
            int i = Rank(key);
            if (i == this.n)
                return default(TKey);
            else
                return this.items[i].Key;
        }

        /// <summary>
        /// 检查 <paramref name="key"/> 是否已在符号表中。
        /// </summary>
        /// <param name="key">要检查是否存在的键。</param>
        /// <returns>若 <paramref name="key"/> 存在则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key can't be null");
            return !Get(key).Equals(default(TKey));
        }

        /// <summary>
        /// 从符号表中删除键为 <paramref name="key"/> 的键值对。
        /// </summary>
        /// <param name="key">要删除的键。</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出。</exception>
        public void Delete(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Delete() is null");
            if (IsEmpty())
                return;

            int i = Rank(key);

            if (i == this.n && this.items[i].Key.CompareTo(key) != 0)
                return;

            for (int j = i; j < this.n - 1; j++)
            {
                this.items[j] = this.items[j + 1];
            }

            this.n--;
            this.items[this.n].Key = default(TKey);
            this.items[this.n].Value = default(TValue);

            if (this.n > 0 && this.n == this.items.Length / 4)
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
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出此异常。</exception>
        public TKey Floor(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Floor() is null");
            int i = Rank(key);
            if (i < this.n && this.items[i].Key.CompareTo(key) == 0)
                return this.items[i].Key;
            if (i == 0)
                return default(TKey);
            else
                return this.items[i - 1].Key;
        }

        /// <summary>
        /// 根据键获得对应的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns><paramref name="key"/> 对应的值。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出此异常。</exception>
        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Get() is null");
            if (IsEmpty())
                return default(TValue);
            int rank = Rank(key);
            if (rank < this.n && this.items[rank].Key.Equals(key))
                return this.items[rank].Value;
            return default(TValue);
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
        public IEnumerable<TKey> Keys() => Keys(Min(), Max());

        /// <summary>
        /// 获得所有位于区间 [<paramref name="lo"/>, <paramref name="hi"/>] 内的键。
        /// </summary>
        /// <param name="lo">区间起点。</param>
        /// <param name="hi">区间终点。</param>
        /// <returns>区间 [<paramref name="lo"/>, <paramref name="hi"/>] 内的键。</returns>
        public IEnumerable<TKey> Keys(TKey lo, TKey hi)
        {
            if (lo == null)
                throw new ArgumentNullException("first argument to Keys() is null");
            if (hi == null)
                throw new ArgumentNullException("Second argument to Keys() is null");

            List<TKey> list = new List<TKey>();
            if (lo.CompareTo(hi) > 0)
                return list;
            for (int i = Rank(lo); i < Rank(hi); i++)
                list.Add(this.items[i].Key);
            if (Contains(hi))
                list.Add(this.items[Rank(hi)].Key);
            return list;
        }

        /// <summary>
        /// 获得符号表中最大的键。
        /// </summary>
        /// <returns>符号表中最大的键。</returns>
        /// <exception cref="InvalidOperationException">当符号表为空时抛出此异常。</exception>
        public TKey Max()
        {
            if (IsEmpty())
                throw new InvalidOperationException("called Max() with empty table");
            return this.items[this.n - 1].Key;
        }

        /// <summary>
        /// 获得符号表中最小的键。
        /// </summary>
        /// <returns>符号表中最小的键。</returns>
        /// <exception cref="InvalidOperationException">当符号表为空时抛出此异常。</exception>
        public TKey Min()
        {
            if (IsEmpty())
                throw new InvalidOperationException("called Min() with empty table");
            return this.items[0].Key;
        }

        /// <summary>
        /// 向符号表插入一个新的键值对，如果键已存在则覆盖。
        /// </summary>
        /// <param name="key">要插入的键。</param>
        /// <param name="value">要插入的值。</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出。</exception>
        public void Put(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("first argument to Put() is null");
            if (value == null)
            {
                Delete(key);
                return;
            }

            int i = Rank(key);

            if (i < this.n && this.items[i].Key.CompareTo(key) == 0)
            {
                this.items[i].Value = value;
                return;
            }

            if (this.n == this.items.Length)
                Resize(this.n * 2);

            for (int j = this.n; j > i; j--)
            {
                this.items[j] = this.items[j - 1];
            }
            this.items[i] = new Item<TKey, TValue> { Key = key, Value = value };
            this.n++;
        }

        /// <summary>
        /// 小于 <paramref name="key"/> 的键的个数。
        /// </summary>
        /// <param name="key">需要比较的键。</param>
        /// <returns>小于 <paramref name="key"/> 的键的个数。</returns>
        /// <exception cref="ArgumentNullException">当 <paramref name="key"/> 为 <c>null</c> 时抛出。</exception>
        public int Rank(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("argument to Rank() is null");
            int lo = 0, hi = this.n - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int compare = this.items[mid].Key.CompareTo(key);
                if (compare > 0)
                    hi = mid - 1;
                else if (compare < 0)
                    lo = mid + 1;
                else
                    return mid;
            }
            return lo;
        }

        /// <summary>
        /// 使得符号表中的第 <paramref name="k"/> 个键正好是第 <paramref name="k"/> 小的键。
        /// </summary>
        /// <param name="k">要挑拣的排名。</param>
        /// <returns>第 <paramref name="k"/> 小的键。</returns>
        public TKey Select(int k)
        {
            if (k < 0 || k >= this.n)
                throw new ArgumentOutOfRangeException("called Select() with invaild k: " + k);
            return this.items[k].Key;
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
        /// <exception cref="ArgumentNullException">当 <paramref name="lo"/> 或 <paramref name="hi"/> 为 <c>null</c> 时抛出此异常。</exception>
        public int Size(TKey lo, TKey hi)
        {
            if (lo == null)
                throw new ArgumentNullException("first argument to Size() is null");
            if (hi == null)
                throw new ArgumentNullException("second argument to Size() is null");

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
            Item<TKey, TValue>[] temp = new Item<TKey, TValue>[capacity];
            for (int i = 0; i < this.n; i++)
            {
                temp[i] = this.items[i];
            }
            this.items = temp;
        }
    }
}
