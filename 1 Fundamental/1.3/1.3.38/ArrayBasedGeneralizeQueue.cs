using System;

namespace _1._3._38
{
    class ArrayBasedGeneralizeQueue<Item>
    {
        private Item[] queue;
        private bool[] IsVisited;
        private int count;
        private int first;
        private int last;

        /// <summary>
        /// 建立一个队列。
        /// </summary>
        public ArrayBasedGeneralizeQueue()
        {
            this.queue = new Item[2];
            this.IsVisited = new bool[2];
            this.first = 0;
            this.last = 0;
            this.count = 0;
        }

        /// <summary>
        /// 检查队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 为队列重新分配空间。
        /// </summary>
        /// <param name="capacity"></param>
        private void Resize(int capacity)
        {
            Item[] temp = new Item[capacity];
            for (int i = 0; i < this.count; ++i)
            {
                temp[i] = this.queue[i];
            }
            this.queue = temp;

            bool[] t = new bool[capacity];
            for (int i = 0; i < this.count; ++i)
            {
                t[i] = this.IsVisited[i];
            }
            this.IsVisited = t;
        }

        /// <summary>
        /// 向队列中插入一个元素。
        /// </summary>
        /// <param name="item">要插入队列的元素。</param>
        public void Insert(Item item)
        {
            if (this.count == this.queue.Length)
            {
                Resize(this.queue.Length * 2);
            }

            this.queue[this.last] = item;
            this.IsVisited[this.last] = false;
            this.last++;
            this.count++;
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

            if (k > this.last || k < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.IsVisited[k - 1] == true)
            {
                throw new ArgumentException("this node had been already deleted");
            }

            Item temp = this.queue[k - 1];
            this.IsVisited[k - 1] = true;
            this.count--;
            return temp;
        }
    }
}
