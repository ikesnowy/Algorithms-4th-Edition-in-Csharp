using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return temp;
        }
    }
}
