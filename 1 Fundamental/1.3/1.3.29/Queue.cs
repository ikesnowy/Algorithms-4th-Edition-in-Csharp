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
            last = null;
            count = 0;
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return last == null;
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
        /// 返回队列中的第一个元素（但不让它出队）。
        /// </summary>
        /// <returns></returns>
        public Item Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            return last.next.item;
        }

        /// <summary>
        /// 将一个新元素加入队列中。
        /// </summary>
        /// <param name="item">要入队的元素。</param>
        public void Enqueue(Item item)
        {
            var oldLast = last;
            last = new Node<Item>();
            last.item = item;
            last.next = last;

            if (oldLast != null)
            {
                last.next = oldLast.next;
                oldLast.next = last;
            }
            count++;
        }

        /// <summary>
        /// 将队列中的第一个元素出队并返回它。
        /// </summary>
        /// <returns></returns>
        public Item Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            Item item = last.next.item;
            last.next = last.next.next;
            count--;
            if (IsEmpty())
                last = null;
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
            return new QueueEnumerator(last);
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
                current = new Node<Item>();
                current.next = last.next;
                first = current;
            }

            Item IEnumerator<Item>.Current => current.item;

            object IEnumerator.Current => current.item;

            void IDisposable.Dispose()
            {
                first = null;
                current = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (current.next == first.next)
                    return false;
                current = current.next;
                return true;
            }

            void IEnumerator.Reset()
            {
                current = first;
            }
        }
    }

    public class Node<Item>
    {
        public Item item;
        public Node<Item> next;
    }
}
