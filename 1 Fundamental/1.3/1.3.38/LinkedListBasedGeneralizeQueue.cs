using System;

namespace _1._3._38
{
    /// <summary>
    /// 以链表为基础的队列。
    /// </summary>
    /// <typeparam name="Item">队列中要保存的元素。</typeparam>
    class LinkedListBasedGeneralizeQueue<Item>
    {
        private class Node<T>
        {
            public T item;
            public Node<T> next;
            public bool IsVisited;
        }

        private Node<Item> first;
        private Node<Item> last;
        private int count;

        /// <summary>
        /// 建立一个队列。
        /// </summary>
        public LinkedListBasedGeneralizeQueue()
        {
            first = null;
            last = null;
            count = 0;
        }

        /// <summary>
        /// 检查数组是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return first == null;
        }

        /// <summary>
        /// 在队尾插入元素。
        /// </summary>
        /// <param name="item">需要插入的元素。</param>
        public void Insert(Item item)
        {
            var oldLast = last;
            last = new Node<Item>()
            {
                item = item,
                IsVisited = false,
                next = null
            };

            if (oldLast == null)
            {
                first = last;
            }
            else
            {
                oldLast.next = last;
            }
            count++;
        }

        /// <summary>
        /// 删除第 k 个插入的结点
        /// </summary>
        /// <param name="k">结点序号（从 1 开始）</param>
        /// <returns></returns>
        public Item Delete(int k)
        {
            if (k > count || k <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            k--;

            // 找到目标结点
            var current = first;
            for (var i = 0; i < k; i++)
            {
                current = current.next;
            }

            if (current.IsVisited == true)
            {
                throw new ArgumentException("this node had been already deleted");
            }

            current.IsVisited = true;
            return current.item;
        }

    }
}
