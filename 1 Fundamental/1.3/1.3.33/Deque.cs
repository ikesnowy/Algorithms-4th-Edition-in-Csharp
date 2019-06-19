using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._33
{
    /// <summary>
    /// 双端队列。
    /// </summary>
    /// <typeparam name="Item">队列中要存放的元素。</typeparam>
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
            first = null;
            last = null;
            count = 0;
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 返回队列中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 向左端添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素。</param>
        public void PushLeft(Item item)
        {
            var oldFirst = first;
            first = new DoubleNode<Item>()
            {
                item = item,
                prev = null,
                next = oldFirst
            };
            if (oldFirst == null)
            {
                last = first;
            }
            else
            {
                oldFirst.prev = first;
            }
            count++;
        }

        /// <summary>
        /// 向右端添加一个元素。
        /// </summary>
        /// <param name="item">要添加的元素。</param>
        public void PushRight(Item item)
        {
            var oldLast = last;
            last = new DoubleNode<Item>()
            {
                item = item,
                prev = oldLast,
                next = null
            };

            if (oldLast == null)
            {
                first = last;
            }
            else
            {
                oldLast.next = last;
            }
            count++;
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

            var temp = last.item;
            last = last.prev;
            count--;

            if (last == null)
            {
                first = null;
            }
            else
            {
                last.next.item = default(Item);
                last.next = null;
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

            var temp = first.item;
            first = first.next;
            count--;

            if (first == null)
            {
                last = null;
            }
            else
            {
                first.prev.item = default(Item);
                first.prev = null;
            }

            return temp;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new DequeEnumerator(first);
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
                current = new DoubleNode<Item>();
                current.next = first;
                current.prev = null;
                this.first = current;
            }

            public Item Current => current.item;

            object IEnumerator.Current => current.item;

            public void Dispose()
            {
                current = null;
                first = null;
            }

            public bool MoveNext()
            {
                if (current.next == null)
                    return false;
                current = current.next;
                return true;
            }

            public void Reset()
            {
                current = first;
            }
        }
    }
}
