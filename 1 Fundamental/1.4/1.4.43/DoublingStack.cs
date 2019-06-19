using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._4._43
{
    /// <summary>
    /// 容量自动加倍的栈。
    /// </summary>
    class DoublingStack<Item> : IEnumerable<Item>
    {
        private Item[] items;
        private int count;

        /// <summary>
        /// 新建一个栈。
        /// </summary>
        public DoublingStack()
        {
            this.items = new Item[2];
            this.count = 0;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 返回栈中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return this.count;
        }

        /// <summary>
        /// 向栈中压入一个元素。
        /// </summary>
        /// <param name="s"></param>
        public void Push(Item s)
        {
            if (this.count == this.items.Length)
                Resize(this.items.Length * 2);
            this.items[this.count] = s;
            this.count++;
        }

        /// <summary>
        /// 从栈中弹出一个元素，返回被弹出的元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack underflow");
            this.count--;

            // 缩小长度
            if (this.count > 0 && this.count <= this.items.Length / 4)
                Resize(this.items.Length / 2);

            return this.items[this.count];

        }

        /// <summary>
        /// 返回栈顶元素（但不弹出它）。
        /// </summary>
        /// <returns></returns>
        public Item Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack underflow");
            return this.items[this.count - 1];
        }

        /// <summary>
        /// 为栈重新分配空间，超出空间的元素将被舍弃。
        /// </summary>
        /// <param name="capcity">重新分配的空间大小。</param>
        private void Resize(int capcity)
        {
            var temp = new Item[capcity];
            
            for (var i = 0; i < this.count; i++)
            {
                temp[i] = this.items[i];
            }

            this.items = temp;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new StackEnumerator(this.items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StackEnumerator : IEnumerator<Item>
        {
            int current;
            Item[] items;

            public StackEnumerator(Item[] items)
            {
                this.items = items;
                this.current = -1;
            }

            Item IEnumerator<Item>.Current => this.items[this.current];

            object IEnumerator.Current => this.items[this.current];

            void IDisposable.Dispose()
            {
                this.items = null;
                this.current = -1;
            }

            bool IEnumerator.MoveNext()
            {
                if (this.current == this.items.Length - 1)
                    return false;
                this.current++;
                return true;
            }

            void IEnumerator.Reset()
            {
                this.current = -1;
            }
        }
    }
}
