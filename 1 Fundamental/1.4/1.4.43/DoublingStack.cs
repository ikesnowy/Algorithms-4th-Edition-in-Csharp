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
            items = new Item[2];
            count = 0;
        }

        /// <summary>
        /// 检查栈是否为空。
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// 返回栈中元素的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 向栈中压入一个元素。
        /// </summary>
        /// <param name="s"></param>
        public void Push(Item s)
        {
            if (count == items.Length)
                Resize(items.Length * 2);
            items[count] = s;
            count++;
        }

        /// <summary>
        /// 从栈中弹出一个元素，返回被弹出的元素。
        /// </summary>
        /// <returns></returns>
        public Item Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack underflow");
            count--;

            // 缩小长度
            if (count > 0 && count <= items.Length / 4)
                Resize(items.Length / 2);

            return items[count];

        }

        /// <summary>
        /// 返回栈顶元素（但不弹出它）。
        /// </summary>
        /// <returns></returns>
        public Item Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack underflow");
            return items[count - 1];
        }

        /// <summary>
        /// 为栈重新分配空间，超出空间的元素将被舍弃。
        /// </summary>
        /// <param name="capcity">重新分配的空间大小。</param>
        private void Resize(int capcity)
        {
            var temp = new Item[capcity];
            
            for (var i = 0; i < count; i++)
            {
                temp[i] = items[i];
            }

            items = temp;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new StackEnumerator(items);
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
                current = -1;
            }

            Item IEnumerator<Item>.Current => items[current];

            object IEnumerator.Current => items[current];

            void IDisposable.Dispose()
            {
                items = null;
                current = -1;
            }

            bool IEnumerator.MoveNext()
            {
                if (current == items.Length - 1)
                    return false;
                current++;
                return true;
            }

            void IEnumerator.Reset()
            {
                current = -1;
            }
        }
    }
}
