using System;

namespace _1._3._38
{
    /// <summary>
    /// 以一维数组为基础的队列。
    /// </summary>
    /// <typeparam name="Item">队列中要保存的元素。</typeparam>
    class ArrayBasedGeneralizeQueue<Item>
    {
        private Item[] queue;
        private bool[] IsVisited;
        private int count;
        private int last;

        /// <summary>
        /// 建立一个队列。
        /// </summary>
        public ArrayBasedGeneralizeQueue()
        {
            queue = new Item[2];
            IsVisited = new bool[2];
            last = 0;
            count = 0;
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 为队列重新分配空间。
        /// </summary>
        /// <param name="capacity"></param>
        private void Resize(int capacity)
        {
            var temp = new Item[capacity];
            for (var i = 0; i < count; i++)
            {
                temp[i] = queue[i];
            }
            queue = temp;

            var t = new bool[capacity];
            for (var i = 0; i < count; i++)
            {
                t[i] = IsVisited[i];
            }
            IsVisited = t;
        }

        /// <summary>
        /// 向队列中插入一个元素。
        /// </summary>
        /// <param name="item">要插入队列的元素。</param>
        public void Insert(Item item)
        {
            if (count == queue.Length)
            {
                Resize(queue.Length * 2);
            }

            queue[last] = item;
            IsVisited[last] = false;
            last++;
            count++;
        }

        /// <summary>
        /// 从队列中删除并返回第 k 个插入的元素。
        /// </summary>
        /// <param name="k">要删除元素的顺序（从 1 开始）</param>
        /// <returns></returns>
        public Item Delete(int k)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            if (k > last || k < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (IsVisited[k - 1] == true)
            {
                throw new ArgumentException("this node had been already deleted");
            }

            var temp = queue[k - 1];
            IsVisited[k - 1] = true;
            count--;
            return temp;
        }
    }
}
