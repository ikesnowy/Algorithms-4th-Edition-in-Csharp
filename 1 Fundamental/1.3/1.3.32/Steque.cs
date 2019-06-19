using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._3._32
{
    // API:
    // public class Steque<Item> : Ienumerable<Item>
    //    public Steque(); 默认构造函数。
    //    public bool IsEmpty(); 检查 Steque 是否为空。
    //    public int Size(); 返回 Steque 中的元素数量。
    //    public void Push(Item item); 向 Steque 中压入一个元素。
    //    public Item Pop(); 从 Steque 中弹出一个元素。
    //    public void Peek(); 返回栈顶元素（但不弹出它）。
    //    public void Enqueue(Item item); 将一个元素添加入 Steque 中。

    /// <summary>
    /// Steque。
    /// </summary>
    /// <typeparam name="Item">Steque 中要存放的元素。</typeparam>
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
            first = null;
            count = 0;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 返回栈内元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 将一个元素压入栈中。
        /// </summary>
        /// <param name="item">要压入栈中的元素。</param>
        public void Push(Item item)
        {
            var oldFirst = first;
            first = new Node<Item>();
            first.item = item;
            first.next = oldFirst;

            if (oldFirst == null)
            {
                last = first;
            }
            count++;
        }

        /// <summary>
        /// 将一个元素从栈中弹出，返回弹出的元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack Underflow");
            var item = first.item;
            first = first.next;
            count--;
            if (count == 0)
            {
                last = null;
            }
            return item;
        }

        /// <summary>
        /// 将一个元素加入队列中。
        /// </summary>
        /// <param name="item">要入队的元素。</param>
        public void Enqueue(Item item)
        {
            var oldLast = last;
            last = new Node<Item>();
            last.item = item;
            last.next = null;
            if (IsEmpty())
                first = last;
            else
                oldLast.next = last;
            count++;
        }

        /// <summary>
        /// 返回栈顶元素（但不弹出它）。
        /// </summary>
        /// <returns></returns>
        public Item Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack Underflow");
            return first.item;
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            foreach (var n in this)
            {
                s.Append(n);
                s.Append(' ');
            }
            return s.ToString();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new StackEnumerator(first);
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
                current = new Node<Item>();
                current.next = first;
                this.first = current;
            }

            Item IEnumerator<Item>.Current => current.item;

            object IEnumerator.Current => current.item;

            void IDisposable.Dispose()
            {
                current = null;
                first = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (current.next == null)
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
}
