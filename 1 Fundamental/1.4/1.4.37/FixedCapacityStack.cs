using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._4._37
{
    /// <summary>
    /// 固定大小的栈。
    /// </summary>
    class FixedCapacityStack<Item> : IEnumerable<Item>
    {
        private Item[] a;
        private int N;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        /// <param name="capacity">栈的大小。</param>
        public FixedCapacityStack(int capacity)
        {
            this.a = new Item[capacity];
            this.N = 0;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.N == 0;
        }

        /// <summary>
        /// 检查栈是否已满。
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return this.N == this.a.Length;
        }

        /// <summary>
        /// 将一个元素压入栈中。
        /// </summary>
        /// <param name="item">要压入栈中的元素。</param>
        public void Push(Item item)
        {
            this.a[this.N] = item;
            this.N++;
        }

        /// <summary>
        /// 从栈中弹出一个元素，返回被弹出的元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            this.N--;
            return this.a[this.N];
        }

        /// <summary>
        /// 返回栈顶元素（但不弹出它）。
        /// </summary>
        /// <returns></returns>
        public Item Peek()
        {
            return this.a[this.N - 1];
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new ReverseEnmerator(this.a);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ReverseEnmerator : IEnumerator<Item>
        {
            private int current;
            private Item[] a;

            public ReverseEnmerator(Item[] a)
            {
                this.current = a.Length;
                this.a = a;
            }

            Item IEnumerator<Item>.Current => this.a[this.current];

            object IEnumerator.Current => this.a[this.current];

            void IDisposable.Dispose()
            {
                this.current = -1;
                this.a = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (this.current == 0)
                    return false;
                this.current--;
                return true;
            }

            void IEnumerator.Reset()
            {
                this.current = this.a.Length;
            }
        }
    }
}
