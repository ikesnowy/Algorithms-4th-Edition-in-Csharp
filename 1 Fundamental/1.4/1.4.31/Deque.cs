using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._31
{
    /// <summary>
    /// 用三个栈模拟的双向队列。
    /// </summary>
    /// <typeparam name="Item">双向队列中的元素。</typeparam>
    class Deque<Item>
    {
        Stack<Item> left;
        Stack<Item> middle;
        Stack<Item> right;

        /// <summary>
        /// 构造一条新的双向队列。
        /// </summary>
        public Deque()
        {
            this.left = new Stack<Item>();
            this.middle = new Stack<Item>();
            this.right = new Stack<Item>();
        }

        /// <summary>
        /// 向双向队列左侧插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void PushLeft(Item item)
        {
            this.left.Push(item);
        }

        /// <summary>
        /// 向双向队列右侧插入一个元素。
        /// </summary>
        /// <param name="item">要插入的元素。</param>
        public void PushRight(Item item)
        {
            this.right.Push(item);
        }

        /// <summary>
        /// 当一侧栈为空时，将另一侧的下半部分元素移动过来。
        /// </summary>
        /// <param name="source">不为空的栈。</param>
        /// <param name="destination">空栈。</param>
        private void Move(Stack<Item> source, Stack<Item> destination) 
        {
            int n = source.Size();
            // 上半部分元素移动到临时栈 middle
            for (int i = 0; i < n / 2; ++i)
            {
                this.middle.Push(source.Pop());
            }
            // 下半部分移动到另一侧栈中
            while (!source.IsEmpty())
            {
                destination.Push(source.Pop());
            }
            //  middle 取回上半部分元素
            while (!this.middle.IsEmpty())
            {
                source.Push(this.middle.Pop());
            }
        }

        /// <summary>
        /// 检查双端队列是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.right.IsEmpty() && this.middle.IsEmpty() && this.left.IsEmpty();
        }

        /// <summary>
        /// 从右侧弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item PopRight()
        {
            if (this.right.IsEmpty())
            {
                Move(this.left, this.right);
            }

            return this.right.Pop();
        }

        /// <summary>
        /// 从左侧弹出一个元素。
        /// </summary>
        /// <returns></returns>
        public Item PopLeft()
        {
            if (this.left.IsEmpty())
            {
                Move(this.right, this.left);
            }

            return this.left.Pop();
        }

        /// <summary>
        /// 返回双端队列的大小。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return this.left.Size() + this.middle.Size() + this.right.Size();
        }
    }
}
