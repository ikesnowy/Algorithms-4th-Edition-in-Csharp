﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
    /// <summary>
    /// 链表类。
    /// </summary>
    /// <typeparam name="Item">链表存放的元素类型。</typeparam>
    internal class LinkedList<Item> : IEnumerable<Item>
    {
        private Node<Item> first;
        private int count;

        /// <summary>
        /// 建立一条链表。
        /// </summary>
        public LinkedList()
        {
            first = null;
            count = 0;
        }

        /// <summary>
        /// 在表头插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void Insert(Item item)
        {
            var n = new Node<Item>();
            n.item = item;
            n.next = first;
            first = n;
            count++;
        }

        /// <summary>
        /// 在指定位置前面插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        /// <param name="position">要插入的位置。（从 0 开始）</param>
        public void Insert(Item item, int position)
        {
            if (position > count)
            {
                throw new IndexOutOfRangeException();
            }
            if (position == 0)
            {
                Insert(item);
                return;
            }

            var n = new Node<Item>();
            n.item = item;

            var front = first;
            for (var i = 1; i < position; i++)
            {
                front = front.next;
            }

            n.next = front.next;
            front.next = n;
            count++;
        }

        /// <summary>
        /// 获取指定位置的元素。
        /// </summary>
        /// <param name="index">元素下标。</param>
        /// <returns>下标为 <paramref name="index"/> 的元素。</returns>
        /// <exception cref="IndexOutOfRangeException">当下标超出链表长度时抛出该异常。</exception>
        public Item Find(int index)
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            var current = first;
            for (var i = 0; i < index; i++)
            {
                current = current.next;
            }

            return current.item;
        }

        /// <summary>
        /// 删除指定位置的元素，返回该元素。
        /// </summary>
        /// <param name="index">需要删除元素的位置。</param>
        /// <returns>下标为 <paramref name="index"/> 的元素。</returns>
        /// <exception cref="IndexOutOfRangeException">当 <paramref name="index"/> 大于链表长度时抛出该异常。</exception>
        public Item Delete(int index)
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException();
            }

            var front = first;
            var temp = first.item;
            if (index == 0)
            {
                first = first.next;
                count--;
                return temp;
            }

            for (var i = 1; i < index; i++)
            {
                front = front.next;
            }

            temp = front.next.item;
            front.next = front.next.next;
            count--;
            return temp;
        }

        /// <summary>
        /// 检查链表是否为空。
        /// </summary>
        /// <returns>若链表为空则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 获取链表中元素的数量。
        /// </summary>
        /// <returns>链表中元素的数量。</returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 将链表转化成单个字符串，元素之间用空格隔开。
        /// </summary>
        /// <returns>形如 "1 2 3 4 5 " 的字符串。</returns>
        public override string ToString()
        {
            var s = new StringBuilder();

            foreach (var i in this)
            {
                s.Append(i);
                s.Append(" ");
            }

            return s.ToString();
        }

        /// <summary>
        /// 获得链表的迭代器。
        /// </summary>
        /// <returns>链表的迭代器。</returns>
        public IEnumerator<Item> GetEnumerator()
        {
            return new LinkedListEnumerator(first);
        }

        /// <summary>
        /// 获得链表的迭代器。
        /// </summary>
        /// <returns>链表迭代器。</returns>
        /// <remarks>该方法实际上调用的是 <see cref="GetEnumerator"/>。</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LinkedListEnumerator : IEnumerator<Item>
        {
            Node<Item> current;
            Node<Item> first;

            public LinkedListEnumerator(Node<Item> first)
            {
                current = new Node<Item>();
                current.next = first;
                this.first = current;
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
