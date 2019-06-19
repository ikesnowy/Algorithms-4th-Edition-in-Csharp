using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._3._29
{
    /// <summary>
    /// 队列类。
    /// </summary>
    /// <typeparam name="Item">队列中存放的元素。</typeparam>
    public class Queue<Item> : IEnumerable<Item>
    {
        private Node<Item> last;
        private int count;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Queue()
        {
            this.last = null;
            this.count = 0;
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.last == null;
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
        /// 返回队列中的第一个元素（但不让它出队）。
        /// </summary>
        /// <returns></returns>
        public Item Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            return this.last.next.item;
        }

        /// <summary>
        /// 将一个新元素加入队列中。
        /// </summary>
        /// <param name="item">要入队的元素。</param>
        public void Enqueue(Item item)
        {
            var oldLast = this.last;
            this.last = new Node<Item>();
            this.last.item = item;
            this.last.next = this.last;

            if (oldLast != null)
            {
                this.last.next = oldLast.next;
                oldLast.next = this.last;
            }
            this.count++;
        }

        /// <summary>
        /// 将队列中的第一个元素出队并返回它。
        /// </summary>
        /// <returns></returns>
        public Item Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            Item item = this.last.next.item;
            this.last.next = this.last.next.next;
            this.count--;
            if (IsEmpty())
                this.last = null;
            return item;
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            foreach (var item in this)
            {
                s.Append(item);
                s.Append(" ");
            }
            return s.ToString();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new QueueEnumerator(this.last);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QueueEnumerator : IEnumerator<Item>
        {
            private Node<Item> current;
            private Node<Item> first;

            public QueueEnumerator(Node<Item> last)
            {
                this.current = new Node<Item>();
                this.current.next = last.next;
                this.first = this.current;
            }

            Item IEnumerator<Item>.Current => this.current.item;

            object IEnumerator.Current => this.current.item;

            void IDisposable.Dispose()
            {
                this.first = null;
                this.current = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (this.current.next == this.first.next)
                    return false;
                this.current = this.current.next;
                return true;
            }

            void IEnumerator.Reset()
            {
                this.current = this.first;
            }
        }
    }

    public class Node<Item>
    {
        public Item item;
        public Node<Item> next;
    }
}
