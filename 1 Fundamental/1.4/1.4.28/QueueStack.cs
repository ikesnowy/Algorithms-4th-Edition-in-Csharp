using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._28
{
    class QueueStack<Item>
    {
        Queue<Item> queue;

        /// <summary>
        /// 初始化一个栈。
        /// </summary>
        public QueueStack()
        {
            queue = new Queue<Item>();
        }

        /// <summary>
        /// 向栈中添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Push(Item item)
        {
            queue.Enqueue(item);
            int size = queue.Size();
            //倒转队列
            for (int i = 0; i < size - 1; ++i)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }

        /// <summary>
        /// 从栈中弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            return queue.Dequeue();
        }

        /// <summary>
        /// 确定栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return queue.IsEmpty();
        }
    }
}
