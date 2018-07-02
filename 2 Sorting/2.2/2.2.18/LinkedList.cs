using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _2._2._18
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
            this.first = null;
            this.count = 0;
        }

        /// <summary>
        /// 在表头插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void Insert(Item item)
        {
            Node<Item> n = new Node<Item>();
            n.item = item;
            n.next = this.first;
            this.first = n;
            this.count++;
        }

        /// <summary>
        /// 在指定位置前面插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        /// <param name="position">要插入的位置。（从 0 开始）</param>
        public void Insert(Item item, int position)
        {
            if (position > this.count)
            {
                throw new IndexOutOfRangeException();
            }
            if (position == 0)
            {
                Insert(item);
                return;
            }

            Node<Item> n = new Node<Item>();
            n.item = item;

            Node<Item> front = this.first;
            for (int i = 1; i < position; i++)
            {
                front = front.next;
            }

            n.next = front.next;
            front.next = n;
            this.count++;
        }

        /// <summary>
        /// 获取指定位置的元素。
        /// </summary>
        /// <param name="index">元素下标。</param>
        /// <returns></returns>
        public Item Find(int index)
        {
            if (index >= this.count)
            {
                throw new IndexOutOfRangeException();
            }

            Node<Item> current = this.first;
            for (int i = 0; i < index; i++)
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
            if (index >= this.count)
            {
                throw new IndexOutOfRangeException();
            }

            Node<Item> front = this.first;
            Item temp = this.first.item;
            if (index == 0)
            {
                this.first = this.first.next;
                return temp;
            }

            for (int i = 1; i < index; i++)
            {
                front = front.next;
            }

            temp = front.next.item;
            front.next = front.next.next;
            this.count--;
            return temp;
        }

        /// <summary>
        /// 获得链表的中间元素。
        /// </summary>
        /// <returns>链表的中间元素。</returns>
        public Node<Item> GetMiddle()
        {
            Node<Item> middle = this.first;
            int mid = this.count / 2;
            for (int i = 0; i < mid - 1; i++)
            {
                middle = middle.next;
            }
            return middle;
        }

        /// <summary>
        /// 检查链表是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 获取链表中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return this.count;
        }

        /// <summary>
        /// 将链表转化成单个字符串，元素之间用空格隔开。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            foreach (Item i in this)
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
        public Node<Item> GetFirst() => this.first;

        /// <summary>
        /// 设置表头结点。
        /// </summary>
        /// <param name="first">新的表头结点。</param>
        public void SetFirst(Node<Item> first) => this.first = first;

        /// <summary>
        /// 将两个链表相连接。
        /// </summary>
        /// <param name="A">第一个链表。</param>
        /// <param name="B">第二个链表。（将被清空）</param>
        public static void Merge(LinkedList<Item> A, LinkedList<Item> B)
        {
            Node<Item> pointer = A.first;
            while (pointer.next != null)
                pointer = pointer.next;
            pointer.next = B.first;
            A.count += B.count;
            B.first = null;
            B.count = 0;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new LinkedListEnumerator(this.first);
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
