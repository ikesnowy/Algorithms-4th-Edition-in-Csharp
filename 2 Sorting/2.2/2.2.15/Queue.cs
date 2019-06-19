using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2._2._15
{
    /// <summary>
    /// 队列类。
    /// </summary>
    /// <typeparam name="Item">队列存放的元素类型。</typeparam>
    public class Queue<Item> : IEnumerable<Item>
    {
        private Node<Item> first;
        private Node<Item> last;
        private int count;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Queue()
        {
            this.first = null;
            this.last = null;
            this.count = 0;
        }

        /// <summary>
        /// 复制构造函数。
        /// </summary>
        /// <param name="r"></param>
        public Queue(Queue<Item> r)
        {
            foreach (var i in r)
            {
                Enqueue(i);
            }
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.first == null;
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
            return this.first.item;
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
            this.last.next = null;
            if (IsEmpty())
                this.first = this.last;
            else
                oldLast.next = this.last;
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
            var item = this.first.item;
            this.first = this.first.next;
            this.count--;
            if (IsEmpty())
                this.last = null;
            return item;
        }

        /// <summary>
        /// 在当前队列之后附加一个队列。
        /// </summary>
        /// <param name="q1">需要被附加的队列。</param>
        /// <param name="q2">需要附加的队列（将被删除）。</param>
        public static Queue<Item> Catenation(Queue<Item> q1, Queue<Item> q2)
        {
            if (q1.IsEmpty())
            {
                q1.first = q2.first;
                q1.last = q2.last;
                q1.count = q2.count;
            }
            else
            {
                q1.last.next = q2.first;
                q1.last = q2.last;
                q1.count += q2.count;
            }

            q2 = null;
            return q1;
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
            return new QueueEnumerator(this.first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QueueEnumerator : IEnumerator<Item>
        {
            private Node<Item> current;
            private Node<Item> first;

            public QueueEnumerator(Node<Item> first)
            {
                this.current = new Node<Item>();
                this.current.next = first;
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
                if (this.current.next == null)
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
}
