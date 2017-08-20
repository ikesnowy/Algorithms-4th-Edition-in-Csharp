using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._29
{
    /// <summary>
    /// 用两个栈模拟的 Steque。
    /// </summary>
    /// <typeparam name="Item">Steque 中的元素类型。</typeparam>
    class StackSteque<Item>
    {
        Stack<Item> H;
        Stack<Item> T;

        /// <summary>
        /// 初始化一个 Steque
        /// </summary>
        public StackSteque()
        {
            this.H = new Stack<Item>();
            this.T = new Stack<Item>();
        }

        /// <summary>
        /// 向栈中添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Push(Item item)
        {
            this.H.Push(item);
        }

        /// <summary>
        /// 将 T 中的元素弹出并压入到 H 中。
        /// </summary>
        private void Reverse()
        {
            while (!this.T.IsEmpty())
            {
                this.H.Push(this.T.Pop());
            }
        }

        /// <summary>
        /// 从 Steque 中弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            if (this.H.IsEmpty())
            {
                Reverse();
            }

            return this.H.Pop();
        }

        /// <summary>
        /// 在 Steque 尾部添加一个元素。
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(Item item)
        {
            this.T.Push(item);
        }

        /// <summary>
        /// 检查 Steque 是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.H.IsEmpty() && this.T.IsEmpty();
        }
    }
}
