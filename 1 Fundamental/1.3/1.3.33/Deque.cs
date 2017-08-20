using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._33
{
    public class Deque<Item> : IEnumerable<Item>
    {
        private class DoubleNode<T>
        {
            public T item;
            public DoubleNode<T> next;
            public DoubleNode<T> prev;
        }

        DoubleNode<Item> first;
        DoubleNode<Item> last;
        int count;

        /// <summary>
        /// 默认构造函数，建立一个双端队列。
        /// </summary>
        public Deque()
        {
            this.first = null;
            this.last = null;
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
        /// 向左端添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素。</param>
        public void PushLeft(Item item)
        {
            DoubleNode<Item> oldFirst = this.first;
            this.first = new DoubleNode<Item>()
            {
                item = item,
                prev = null,
                next = oldFirst
            };
            if (oldFirst == null)
            {
                this.last = this.first;
            }
            else
            {
                oldFirst.prev = this.first;
            }
            this.count++;
        }

        /// <summary>
        /// 向右端添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素。</param>
        public void PushRight(Item item)
        {
            DoubleNode<Item> oldLast = this.last;
            this.last = new DoubleNode<Item>()
            {
                item = item,
                prev = oldLast,
                next = null
            };

            if (oldLast == null)
            {
                this.first = this.last;
            }
            else
            {
                oldLast.next = this.last;
            }
            this.count++;
        }

        /// <summary>
        /// 从右端删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public Item PopRight()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            Item temp = this.last.item;
            this.last = this.last.prev;
            this.count--;

            if (this.last == null)
            {
                this.first = null;
            }
            else
            {
                this.last.next.item = default(Item);
                this.last.next = null;
            }
            return temp;
        }

        /// <summary>
        /// 从左端删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public Item PopLeft()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            Item temp = this.first.item;
            this.first = this.first.next;
            this.count--;

            if (this.first == null)
            {
                this.last = null;
            }
            else
            {
                this.first.prev.item = default(Item);
                this.first.prev = null;
            }

            return temp;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new DequeEnumerator(this.first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class DequeEnumerator : IEnumerator<Item>
        {
            private DoubleNode<Item> current;
            private DoubleNode<Item> first;

            public DequeEnumerator(DoubleNode<Item> first) 
            {
                this.current = new DoubleNode<Item>();
                this.current.next = first;
                this.current.prev = null;
                this.first = this.current;
            }

            public Item Current => this.current.item;

            object IEnumerator.Current => this.current.item;

            public void Dispose()
            {
                this.current = null;
                this.first = null;
            }

            public bool MoveNext()
            {
                if (this.current.next == null)
                    return false;
                this.current = this.current.next;
                return true;
            }

            public void Reset()
            {
                this.current = this.first;
            }
        }
    }
}
