using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._8
{
    /// <summary>
    /// 容量自动加倍的字符串栈。
    /// </summary>
    class DoublingStackOfStrings : IEnumerable<string>
    {
        private string[] items;
        private int count;

        /// <summary>
        /// 新建一个字符串栈。
        /// </summary>
        public DoublingStackOfStrings()
        {
            items = new string[2];
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
        /// 返回栈中字符串的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return count;
        }

        /// <summary>
        /// 向栈中压入一个字符串。
        /// </summary>
        /// <param name="s"></param>
        public void Push(string s)
        {
            if (count == items.Length)
                Resize(items.Length * 2);
            items[count] = s;
            count++;
        }

        /// <summary>
        /// 从栈中弹出一个字符串，返回被弹出的元素。
        /// </summary>
        /// <returns></returns>
        public string Pop()
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
        public string Peek()
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
            var temp = new string[capcity];
            
            for (var i = 0; i < count; i++)
            {
                temp[i] = items[i];
            }

            items = temp;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new StackEnumerator(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StackEnumerator : IEnumerator<string>
        {
            int current;
            string[] items;

            public StackEnumerator(string[] items)
            {
                this.items = items;
                current = -1;
            }

            string IEnumerator<string>.Current => items[current];

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
