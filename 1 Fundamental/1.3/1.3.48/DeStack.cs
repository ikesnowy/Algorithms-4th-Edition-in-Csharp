using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._48
{
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
            this.first = null;
            this.last = null;
            this.leftcount = 0;
            this.rightcount = 0;
        }

        /// <summary>
        /// 检查左侧栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsLeftEmpty()
        {
            return this.leftcount == 0;
        }

        /// <summary>
        /// 检查右侧栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsRightEmpty()
        {
            return this.rightcount == 0;
        }

        /// <summary>
        /// 返回左侧栈中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int LeftSize()
        {
            return this.leftcount;
        }

        /// <summary>
        /// 返回右侧栈中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int RightSize()
        {
            return this.rightcount;
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
            this.leftcount++;
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
            this.rightcount++;
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

            Item temp = this.last.item;
            this.last = this.last.prev;
            this.rightcount--;

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
            if (IsLeftEmpty())
            {
                throw new InvalidOperationException();
            }

            Item temp = this.first.item;
            this.first = this.first.next;
            this.leftcount--;

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

            public Item Current => current.item;

            object IEnumerator.Current => current.item;

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
