using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
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
            Node<Item> oldLast = this.last;
            this.last = new Node<Item>();
            this.last.item = item;
            this.last.next = null;
            if (IsEmpty())
                this.first = this.last;
            else
                oldLast.next = this.last;
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
            Item item = this.first.item;
            this.first = this.first.next;
            this.count--;
            if (IsEmpty())
                this.last = null;
            return item;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (Item item in this)
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
