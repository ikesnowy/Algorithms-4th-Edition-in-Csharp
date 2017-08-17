using System;

namespace _1._3._39
{
    class RingBuffer<Item>
    {
        private Item[] buffer;
        private int count;
        private int first;  // 指针
        private int last;   // 指针

        /// <summary>
        /// 建立一个缓冲区。
        /// </summary>
        /// <param name="N">缓冲区的大小。</param>
        public RingBuffer(int N)
        {
            this.buffer = new Item[N];
            this.count = 0;
            this.first = 0;
            this.last = 0;
        }

        /// <summary>
        /// 检查缓冲区是否已满。
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return this.count == this.buffer.Length;
        }

        /// <summary>
        /// 检查缓冲区是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 向缓冲区写入数据。
        /// </summary>
        /// <param name="item">要写入的数据。</param>
        public void Write(Item item)
        {
            if (IsFull())
            {
                throw new OutOfMemoryException("buffer is full");
            }

            this.buffer[this.last] = item;
            this.last = (this.last + 1) % this.buffer.Length;
            this.count++;
        }

        /// <summary>
        /// 从缓冲区读取一个数据。
        /// </summary>
        /// <returns></returns>
        public Item Read()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            Item temp = this.buffer[this.first];
            this.first = (this.first + 1) % this.buffer.Length;
            this.count--;
            return temp;
        }
    }
}
