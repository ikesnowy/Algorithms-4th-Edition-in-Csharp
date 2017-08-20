using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._4._29
{
    public class Stack<Item> : IEnumerable<Item>
    {
        private Node<Item> first;
        private int count;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Stack()
        {
            this.first = null;
            this.count = 0;
        }

        /// <summary>
        /// 复制构造函数。
        /// </summary>
        /// <param name="s"></param>
        public Stack(Stack<Item> s)
        {
            if (s.first != null)
            {
                this.first = new Node<Item>(s.first);
                for (Node<Item> x = this.first; x.next != null; x = x.next)
                {
                    x.next = new Node<Item>(x.next);
                }
            }
            this.count = s.count;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.first == null;
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
            return item;
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

        /// <summary>
        /// 将两个栈连接。
        /// </summary>
        /// <param name="s1">第一个栈。</param>
        /// <param name="s2">第二个栈（将被删除）。</param>
        /// <returns></returns>
        public static Stack<Item> Catenation(Stack<Item> s1, Stack<Item> s2)
        {
            if (s1.IsEmpty())
            {
                s1.first = s2.first;
                s1.count = s2.count;
            }
            else
            {
                Node<Item> last = s1.first;
                while (last.next != null)
                {
                    last = last.next;
                }
                last.next = s2.first;
                s1.count += s2.count;
            }
            s2 = null;
            return s1;
        }

        /// <summary>
        /// 创建栈的浅表副本。
        /// </summary>
        /// <returns></returns>
        public Stack<Item> Copy()
        {
            Stack<Item> temp = new Stack<Item>();
            temp.first = this.first;
            temp.count = this.count;
            return temp;
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
