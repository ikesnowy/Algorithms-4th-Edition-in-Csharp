using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._29
{
    class StackSteque<Item>
    {
        Stack<Item> H;
        Stack<Item> T;

        /// <summary>
        /// 初始化一个 Steque
        /// </summary>
        public StackSteque()
        {
            H = new Stack<Item>();
            T = new Stack<Item>();
        }

        /// <summary>
        /// 向栈中添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Push(Item item)
        {
            H.Push(item);
        }

        /// <summary>
        /// 将 T 中的元素弹出并压入到 H 中。
        /// </summary>
        private void Reverse()
        {
            while (!T.IsEmpty())
            {
                H.Push(T.Pop());
            }
        }

        /// <summary>
        /// 从 Steque 中弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            if (H.IsEmpty())
            {
                Reverse();
            }

            return H.Pop();
        }

        /// <summary>
        /// 在 Steque 尾部添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(Item item)
        {
            T.Push(item);
        }

        /// <summary>
        /// 检查 Steque 是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return H.IsEmpty() && T.IsEmpty();
        }
    }
}
