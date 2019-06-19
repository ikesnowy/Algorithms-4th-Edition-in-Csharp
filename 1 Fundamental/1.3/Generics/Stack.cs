using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    /// <summary>
    /// 栈类（链表实现）。
    /// </summary>
    /// <typeparam name="Item">栈中存放的元素类型。</typeparam>
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
        /// 复制构造函数，链表中的元素都是浅拷贝。
        /// </summary>
        /// <param name="s">用于复制的栈。</param>
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
        /// <returns>栈为空则返回 <c>true</c>，否则而返回 <c>false</c>。</returns>
        public bool IsEmpty()
        {
            return first == null;
        }

        /// <summary>
        /// 返回栈内元素的数量。
        /// </summary>
        /// <returns>栈中元素的数量。</returns>
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
        /// <returns>被弹出的元素。</returns>
        /// <exception cref="InvalidOperationException">当栈为空的时候抛出此异常。</exception>
        /// <remarks>如果只需要栈顶的元素，请使用 <see cref="Peek"/>。</remarks>
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
        /// <returns>栈顶元素。</returns>
        /// <remarks>如果希望获得并删除栈顶元素，请使用 <see cref="Pop"/>。</remarks>
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
        /// <returns>连接后的栈。</returns>
        /// <remarks><paramref name="s2"/> 将被置为 <c>null</c>。</remarks>
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
        /// <returns>栈的浅表副本。</returns>
        public Stack<Item> Copy()
        {
            var temp = new Stack<Item>();
            temp.first = first;
            temp.count = count;
            return temp;
        }

        /// <summary>
        /// 将栈中元素转化成字符串，用空格隔开。
        /// </summary>
        /// <returns>将栈中元素用空格分隔后的字符串。</returns>
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

        /// <summary>
        /// 获得栈的枚举器。
        /// </summary>
        /// <returns>当前栈的枚举器。</returns>
        public IEnumerator<Item> GetEnumerator()
        {
            return new StackEnumerator(first);
        }

        /// <summary>
        /// 获得栈的枚举器。
        /// </summary>
        /// <returns>当前栈的枚举器。</returns>
        /// <remarks>该方法实际上调用的是 <see cref="GetEnumerator"/>。</remarks>
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
