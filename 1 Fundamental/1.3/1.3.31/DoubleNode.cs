using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _1._3._31
{
    
     /// <summary>
     /// 双向链表。
     /// </summary>
     /// <typeparam name="Item">链表中要存放的元素。</typeparam>
    public class DoubleLinkList<Item> : IEnumerable<Item>
    {
        private class DoubleNode<T>
        {
            public T item;
            public DoubleNode<T> prev;
            public DoubleNode<T> next;
        }
        DoubleNode<Item> first;
        DoubleNode<Item> last;
        int count;

        /// <summary>
        /// 建立一条双向链表。
        /// </summary>
        public DoubleLinkList()
        {
            first = null;
            last = null;
            count = 0;
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
        /// 返回链表中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 在表头插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void InsertFront(Item item)
        {
            var node = new DoubleNode<Item>()
            {
                item = item,
                next = first,
                prev = null
            };
            if (first != null)
            {
                first.prev = node;
            }
            else
            {
                last = node;
            }
            first = node;
            count++;
        }

        /// <summary>
        /// 在表尾插入一个元素。
        /// </summary>
        /// <param name="item">要插入表尾的元素。</param>
        public void InsertRear(Item item)
        {
            var node = new DoubleNode<Item>()
            {
                item = item,
                next = null,
                prev = last
            };
            if (last != null)
            {
                last.next = node;
            }
            else
            {
                first = node;
            }
            last = node;
            count++;
        }

        /// <summary>
        /// 检索指定下标的元素。
        /// </summary>
        /// <param name="index">要检索的下标。</param>
        /// <returns></returns>
        public Item At(int index)
        {
            if (index >= count || index < 0)
                throw new IndexOutOfRangeException();

            var current = first;
            for (var i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.item;
        }

        /// <summary>
        /// 返回指定下标的结点。
        /// </summary>
        /// <param name="index">要查找的下标。</param>
        /// <returns></returns>
        private DoubleNode<Item> Find(int index)
        {
            if (index >= count || index < 0)
                throw new IndexOutOfRangeException();

            var current = first;
            for (var i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current;
        }

        /// <summary>
        /// 在指定位置之前插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        /// <param name="index">插入位置的下标。</param>
        public void InsertBefore(Item item, int index)
        {
            if (index == 0)
            {
                InsertFront(item);
                return;
            }

            if (index >= count || index < 0)
                throw new IndexOutOfRangeException();

            var current = Find(index);
            var node = new DoubleNode<Item>()
            {
                next = current,
                prev = current.prev,
                item = item
            };
            current.prev.next = node;
            current.prev = node;
            count++;
        }

        /// <summary>
        /// 在指定位置之后插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        /// <param name="index">查找元素的下标。</param>
        public void InsertAfter(Item item, int index)
        {
            if (index == count - 1)
            {
                InsertRear(item);
                return;
            }

            if (index >= count || index < 0)
                throw new IndexOutOfRangeException();

            var current = Find(index);
            var node = new DoubleNode<Item>()
            {
                prev = current,
                next = current.next,
                item = item
            };
            current.next.prev = node;
            current.next = node;
            count++;
        }

        /// <summary>
        /// 删除表头元素。
        /// </summary>
        /// <returns></returns>
        public Item DeleteFront()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List underflow");

            var temp = first.item;
            first = first.next;
            count--;
            if (IsEmpty())
            {
                last = null;
            }
            return temp;
        }

        /// <summary>
        /// 删除表尾的元素。
        /// </summary>
        /// <returns></returns>
        public Item DeleteRear()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List underflow");

            var temp = last.item;
            last = last.prev;
            count--;
            if (IsEmpty())
            {
                first = null;
            }
            else
            {
                last.next = null;
            }
            return temp;
        }

        /// <summary>
        /// 删除指定位置的元素。
        /// </summary>
        /// <param name="index">要删除元素的下标。</param>
        /// <returns></returns>
        public Item Delete(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                return DeleteFront();
            }

            if (index == count - 1)
            {
                return DeleteRear();
            }

            var current = Find(index);
            var temp = current.item;
            current.prev.next = current.next;
            current.next.prev = current.prev;
            count--;
            return temp;
        }

        public override string ToString()
        {
            var s = new StringBuilder();

            foreach (var i in this)
            {
                s.Append(i.ToString());
                s.Append(" ");
            }

            return s.ToString();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new DoubleLinkListEnumerator(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class DoubleLinkListEnumerator : IEnumerator<Item>
        {
            DoubleNode<Item> current;
            DoubleNode<Item> first;

            public DoubleLinkListEnumerator(DoubleNode<Item> first)
            {
                current = new DoubleNode<Item>();
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
