namespace _1._4._28
{
    /// <summary>
    /// 用一条队列模拟的栈。
    /// </summary>
    /// <typeparam name="Item">栈中保存的元素。</typeparam>
    class QueueStack<Item>
    {
        Queue<Item> queue;

        /// <summary>
        /// 初始化一个栈。
        /// </summary>
        public QueueStack()
        {
            this.queue = new Queue<Item>();
        }

        /// <summary>
        /// 向栈中添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Push(Item item)
        {
            this.queue.Enqueue(item);
            int size = this.queue.Size();
            // 倒转队列
            for (int i = 0; i < size - 1; ++i)
            {
                this.queue.Enqueue(this.queue.Dequeue());
            }
        }

        /// <summary>
        /// 从栈中弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            return this.queue.Dequeue();
        }

        /// <summary>
        /// 确定栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.queue.IsEmpty();
        }
    }
}
