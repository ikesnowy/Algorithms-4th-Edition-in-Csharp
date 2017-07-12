using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._36
{
    public class RandomQueue<Item> : IEnumerable<Item>
    {
        private Item[] queue;
        private int count;

        /// <summary>
        /// 新建一个随机队列。
        /// </summary>
        public RandomQueue()
        {
            this.queue = new Item[2];
            this.count = 0;
        }

        /// <summary>
        /// 判断队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 为队列重新分配内存空间。
        /// </summary>
        /// <param name="capacity"></param>
        private void Resize(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException();
            }

            Item[] temp = new Item[capacity];
            for (int i = 0; i < this.count; ++i)
            {
                temp[i] = this.queue[i];
            }

            this.queue = temp;
        }

        /// <summary>
        /// 向队列中添加一个元素。
        /// </summary>
        /// <param name="item">要向队列中添加的元素。</param>
        public void Enqueue(Item item)
        {
            if (this.queue.Length == this.count)
            {
                Resize(this.count * 2);
            }

            this.queue[this.count] = item;
            this.count++;
        }

        /// <summary>
        /// 从队列中随机删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public Item Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            Random random = new Random(DateTime.Now.Millisecond);
            int index = random.Next(this.count);

            Item temp = this.queue[index];
            this.queue[index] = this.queue[this.count - 1];
            this.queue[this.count - 1] = temp;

            this.count--;

            if (this.count < this.queue.Length / 4)
            {
                Resize(this.queue.Length / 2);
            }

            return temp;
        }

        /// <summary>
        /// 随机返回一个队列中的元素。
        /// </summary>
        /// <returns></returns>
        public Item Sample()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            Random random = new Random();
            int index = random.Next(this.count);

            return this.queue[index];
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new RandomQueueEnumerator(this.queue, this.count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class RandomQueueEnumerator : IEnumerator<Item>
        {
            private int current;
            private int count;
            private Item[] queue;
            private int[] sequence;

            public RandomQueueEnumerator(Item[] queue, int count)
            {
                this.count = count;
                this.queue = queue;
                this.current = -1;

                this.sequence = new int[this.count];
                for (int i = 0; i < this.count; ++i)
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
                for (int i = 0; i < N; ++i)
                {
                    int r = i + random.Next(N - i);
                    int temp = a[i];
                    a[i] = a[r];
                    a[r] = temp;
                }
            }

            Item IEnumerator<Item>.Current => this.queue[this.sequence[this.current]];

            object IEnumerator.Current => this.queue[this.sequence[this.current]];

            void IDisposable.Dispose()
            {
                this.current = -1;
                this.sequence = null;
                this.queue = null;
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
