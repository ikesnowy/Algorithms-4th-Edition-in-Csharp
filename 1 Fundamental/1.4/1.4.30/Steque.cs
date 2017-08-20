using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._4._30
{
    //API:
    //public class Steque<Item> : Ienumerable<Item>
    //    public Steque(); 默认构造函数。
    //    public bool IsEmpty(); 检查 Steque 是否为空。
    //    public int Size(); 返回 Steque 中的元素数量。
    //    public void Push(Item item); 向 Steque 中压入一个元素。
    //    public Item Pop(); 从 Steque 中弹出一个元素。
    //    public void Peek(); 返回栈顶元素（但不弹出它）。
    //    public void Enqueue(Item item); 将一个元素添加入 Steque 中。

    public class Steque<Item> : IEnumerable<Item>
    {
        private Node<Item> first;
        private Node<Item> last;
        private int count;

        private class Node<T>
        {
            public T item;
            public Node<T> next;
        }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Steque()
        {
            this.first = null;
            this.count = 0;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 返回栈内元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return this.count;
        }

        /// <summary>
        /// 将一个元素压入栈中。
        /// </summary>
        /// <param name="item">要压入栈中的元素。</param>
        public void Push(Item item)
        {
            Node<Item> oldFirst = this.first;
            this.first = new Node<Item>();
            this.first.item = item;
            this.first.next = oldFirst;

            if (oldFirst == null)
            {
                this.last = this.first;
            }
            this.count++;
        }

        /// <summary>
        /// 将一个元素从栈中弹出，返回弹出的元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack Underflow");
            Item item = this.first.item;
            this.first = this.first.next;
            this.count--;
            if (this.count == 0)
            {
                this.last = null;
            }
            return item;
        }

        /// <summary>
        /// 将一个元素加入队列中。
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
            this.count++;
        }

        /// <summary>
        /// 返回栈顶元素（但不弹出它）。
        /// </summary>
        /// <returns></returns>
        public Item Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack Underflow");
            return this.first.item;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (Item n in this)
            {
                s.Append(n);
                s.Append(' ');
            }
            return s.ToString();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new StackEnumerator(this.first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StackEnumerator : IEnumerator<Item>
        {
            private Node<Item> current;
            private Node<Item> first;

            public StackEnumerator(Node<Item> first)
            {
                this.current = new Node<Item>();
                this.current.next = first;
                this.first = this.current;
            }

            Item IEnumerator<Item>.Current => this.current.item;

            object IEnumerator.Current => this.current.item;

            void IDisposable.Dispose()
            {
                this.current = null;
                this.first = null;
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
