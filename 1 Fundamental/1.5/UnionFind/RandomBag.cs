using System;
using System.Collections;
using System.Collections.Generic;

namespace UnionFind
{
    /// <summary>
    /// 随机背包。
    /// </summary>
    /// <typeparam name="Item">背包中要存放的元素。</typeparam>
    public class RandomBag<Item> : IEnumerable<Item>
    {
        private Item[] bag;
        private int count;

        /// <summary>
        /// 建立一个随机背包。
        /// </summary>
        public RandomBag()
        {
            this.bag = new Item[2];
            this.count = 0;
        }

        /// <summary>
        /// 检查背包是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 返回背包中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return this.count;
        }

        /// <summary>
        /// 向背包中添加一个元素。
        /// </summary>
        /// <param name="item">要向背包中添加的元素。</param>
        public void Add(Item item)
        {
            if (this.count == this.bag.Length)
            {
                Resize(this.count * 2);
            }

            this.bag[this.count] = item;
            this.count++;
        }

        /// <summary>
        /// 重新为背包分配内存空间。
        /// </summary>
        /// <param name="capacity"></param>
        private void Resize(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException();
            Item[] temp = new Item[capacity];
            for (int i = 0; i < this.count; i++)
            {
                temp[i] = this.bag[i];
            }
            this.bag = temp;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new RandomBagEnumerator(this.bag, this.count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class RandomBagEnumerator : IEnumerator<Item>
        {
            private Item[] bag;
            private int[] sequence;
            private int current;
            private int count;

            public RandomBagEnumerator(Item[] bag, int count)
            {
                this.bag = bag;
                this.current = -1;
                this.count = count;
                this.sequence = new int[count];
                for (int i = 0; i < this.count; i++)
                {
                    this.sequence[i] = i;
                }
                Shuffle(this.sequence, DateTime.Now.Millisecond);
            }

            /// <summary>
            /// 随机打乱数组。
            /// </summary>
            /// <param name="a">需要打乱的数组。</param>
            /// <param name="seed">随机种子值。</param>
            private void Shuffle(int[] a, int seed)
            {
                int N = a.Length;
                Random random = new Random(seed);
                for (int i = 0; i < N; i++)
                {
                    int r = i + random.Next(N - i);
                    int temp = a[i];
                    a[i] = a[r];
                    a[r] = temp;
                }
            }

            Item IEnumerator<Item>.Current => this.bag[this.sequence[this.current]];

            object IEnumerator.Current => this.bag[this.sequence[this.current]];

            void IDisposable.Dispose()
            {
                this.bag = null;
                this.sequence = null;
                this.current = -1;
            }

            bool IEnumerator.MoveNext()
            {
                if (this.current == this.count - 1)
                    return false;
                this.current++;
                return true;
            }

            void IEnumerator.Reset()
            {
                this.current = -1;
            }
        }
    }
}
