﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._4._30
{
    /// <summary>
    /// 链栈。
    /// </summary>
    /// <typeparam name="Item">链栈中保存的元素。</typeparam>
    public class Stack<Item> : IEnumerable<Item>
    {
        private Node<Item> first;
        private int count;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Stack()
        {
            first = null;
            count = 0;
        }

        /// <summary>
        /// 复制构造函数。
        /// </summary>
        /// <param name="s"></param>
        public Stack(Stack<Item> s)
        {
            if (s.first != null)
            {
                first = new Node<Item>(s.first);
                for (var x = first; x.next != null; x = x.next)
                {
                    x.next = new Node<Item>(x.next);
                }
            }
            count = s.count;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return first == null;
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
            return first.item;
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
                var last = s1.first;
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
            var temp = new Stack<Item>();
            temp.first = first;
            temp.count = count;
            return temp;
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
