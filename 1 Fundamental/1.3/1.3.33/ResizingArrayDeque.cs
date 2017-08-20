using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._33
{
    public class ResizingArrayDeque<Item> : IEnumerable<Item>
    {
        private Item[] deque;
        private int first;
        private int last;
        private int count;

        /// <summary>
        /// 默认构造函数，建立一个双向队列。
        /// </summary>
        public ResizingArrayDeque()
        {
            this.deque = new Item[2];
            this.first = 0;
            this.last = 0;
            this.count = 0;
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 返回队列中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return this.count;
        }

        /// <summary>
        /// 为队列重新分配空间。
        /// </summary>
        /// <param name="capacity">需要重新分配的空间大小。</param>
        private void Resize(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException();

            Item[] temp = new Item[capacity];
            for (int i = 0; i < this.count; ++i)
            {
                temp[i] = this.deque[(this.first + i) % this.deque.Length];
            }
            this.deque = temp;
            this.first = 0;
            this.last = this.count;
        }


        /// <summary>
        /// 在队列左侧添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素</param>
        public void PushLeft(Item item)
        {
            if (this.count == this.deque.Length)
            {
                Resize(2 * this.count);
            }

            this.first--;
            if (this.first < 0)
            {
                this.first += this.deque.Length;
            }
            this.deque[this.first] = item;
            this.count++;
        }

        public void PushRight (Item item)
        {
            if (this.count == this.deque.Length)
            {
                Resize(2 * this.count);
            }

            this.deque[this.last] = item;
            this.last = (this.last + 1) % this.deque.Length;
            this.count++;
        }

        public Item PopRight()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            this.last--;
            if (this.last < 0)
            {
                this.last += this.deque.Length;
            }
            Item temp = this.deque[this.last];
            this.count--;
            if (this.count > 0 && this.count == this.deque.Length / 4)
                Resize(this.deque.Length / 2);
            return temp;
        }

        public Item PopLeft()
        {
            if (IsEmpty())
                throw new ArgumentException();

            Item temp = this.deque[this.first];
            this.first = (this.first + 1) % this.deque.Length;
            this.count--;
            if (this.count > 0 && this.count == this.deque.Length / 4)
            {
                Resize(this.deque.Length / 2);
            }
            return temp;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new ResizingDequeEnumerator(this.deque, this.first, this.count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ResizingDequeEnumerator : IEnumerator<Item>
        {
            private Item[] deque;
            private int current;
            private int first;
            private int count;

            public ResizingDequeEnumerator(Item[] deque, int first, int count)
            {
                this.deque = deque;
                this.first = first;
                this.count = count;
                this.current = -1;
            }

            Item IEnumerator<Item>.Current => this.deque[(this.first + this.current) % this.deque.Length];

            object IEnumerator.Current => this.deque[(this.first + this.current) % this.deque.Length];

            void IDisposable.Dispose()
            {
                this.deque = null;
                this.current = -1;
            }

            bool IEnumerator.MoveNext()
            {
                if (this.current == this.count - 1)
                {
                    return false;
                }

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
