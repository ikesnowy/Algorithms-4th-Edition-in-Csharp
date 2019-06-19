using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2._2._17
{
    /// <summary>
    /// 链表类。
    /// </summary>
    /// <typeparam name="Item">链表存放的元素类型。</typeparam>
    public class LinkedList<Item> : IEnumerable<Item>
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 获取链表中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 将链表转化成单个字符串，元素之间用空格隔开。
        /// </summary>
        /// <returns></returns>
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
        /// 获得表头结点。
        /// </summary>
        /// <returns>表头结点</returns>
        public Node<Item> GetFirst() => first;

        /// <summary>
        /// 设置表头结点。
        /// </summary>
        /// <param name="first">新的表头结点。</param>
        public void SetFirst(Node<Item> first) => this.first = first;

        public IEnumerator<Item> GetEnumerator()
        {
            return new LinkedListEnumerator(first);
        }

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
