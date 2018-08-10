using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// 不保持元素输入顺序的优先队列。
    /// </summary>
    /// <typeparam name="Key">优先队列中的元素类型。</typeparam>
    public class UnorderedArrayMaxPQ<Key> : IMaxPQ<Key> where Key : IComparable<Key>
    {
        /// <summary>
        /// 保存元素的数组。
        /// </summary>
        private readonly Key[] pq;

        /// <summary>
        /// 队列中的元素数量。
        /// </summary>
        private int n;

        /// <summary>
        /// 默认构造函数，建立一条优先队列。
        /// </summary>
        /// <param name="capacity">优先队列的初始容量。</param>
        public UnorderedArrayMaxPQ(int capacity)
        {
            this.pq = new Key[capacity];
            this.n = 0;
        }

        /// <summary>
        /// 获得（但不删除）优先队列中的最大元素。
        /// </summary>
        /// <returns></returns>
        public Key Max()
        {
            int max = 0;
            for (int i = 1; i < n; i++)
                if (Less(this.pq[max], this.pq[i]))
                    max = i;
            return this.pq[max];
        }

        /// <summary>
        /// 返回并删除优先队列中的最大值。
        /// </summary>
        /// <returns></returns>
        public Key DelMax()
        {
            int max = 0;
            for (int i = 1; i < this.n; i++)
                if (Less(this.pq[max], this.pq[i]))
                    max = i;
            Exch(this.pq[max], this.pq[this.n - 1]);

            return this.pq[--this.n];
        }

        /// <summary>
        /// 向优先队列中插入一个元素。
        /// </summary>
        /// <param name="v">需要插入的元素。</param>
        public void Insert(Key v) => this.pq[this.n++] = v;

        /// <summary>
        /// 检查优先队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => this.n == 0;

        /// <summary>
        /// 检查优先队列中含有的元素数量。
        /// </summary>
        /// <returns></returns>
        public int Size() => this.n;

        /// <summary>
        /// 比较第一个元素是否小于第二个元素。
        /// </summary>
        /// <param name="a">第一个元素。</param>
        /// <param name="b">第二个元素。</param>
        /// <returns></returns>
        private bool Less(Key a, Key b) => a.CompareTo(b) < 0;

        /// <summary>
        /// 交换两个元素。
        /// </summary>
        /// <param name="a">要交换的第一个元素。</param>
        /// <param name="b">要交换的第二个元素。</param>
        private void Exch(Key a, Key b)
        {
            Key temp = a;
            a = b;
            b = temp;
        }
    }
}
