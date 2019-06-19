using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._48
{
    /// <summary>
    /// 双端栈。
    /// </summary>
    /// <typeparam name="Item">栈中所包含的元素。</typeparam>
    public class DeStack<Item> : IEnumerable<Item>
    {
        private class DoubleNode<T>
        {
            public T item;
            public DoubleNode<T> next;
            public DoubleNode<T> prev;
        }

        DoubleNode<Item> first;
        DoubleNode<Item> last;
        int leftcount;
        int rightcount;

        /// <summary>
        /// 默认构造函数，建立一个双端栈。
        /// </summary>
        public DeStack()
        {
            first = null;
            last = null;
            leftcount = 0;
            rightcount = 0;
        }

        /// <summary>
        /// 检查左侧栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsLeftEmpty()
        {
            return leftcount == 0;
        }

        /// <summary>
        /// 检查右侧栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsRightEmpty()
        {
            return rightcount == 0;
        }

        /// <summary>
        /// 返回左侧栈中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int LeftSize()
        {
            return leftcount;
        }

        /// <summary>
        /// 返回右侧栈中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int RightSize()
        {
            return rightcount;
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
            leftcount++;
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
            rightcount++;
        }

        /// <summary>
        /// 从右端删除并返回一个元素。
        /// </summary>
        /// <returns></returns>
        public Item PopRight()
        {
            if (IsRightEmpty())
            {
                throw new InvalidOperationException();
            }

            var temp = last.item;
            last = last.prev;
            rightcount--;

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
            if (IsLeftEmpty())
            {
                throw new InvalidOperationException();
            }

            var temp = first.item;
            first = first.next;
            leftcount--;

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
