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
            this.items = new string[2];
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
        /// 返回栈中字符串的数量。
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return this.count;
        }

        /// <summary>
        /// 向栈中压入一个字符串。
        /// </summary>
        /// <param name="s"></param>
        public void Push(string s)
        {
            if (this.count == this.items.Length)
                Resize(this.items.Length * 2);
            this.items[this.count] = s;
            this.count++;
        }

        /// <summary>
        /// 从栈中弹出一个字符串，返回被弹出的元素。
        /// </summary>
        /// <returns></returns>
        public string Pop()
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
        public string Peek()
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
            var temp = new string[capcity];
            
            for (var i = 0; i < this.count; i++)
            {
                temp[i] = this.items[i];
            }

            this.items = temp;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new StackEnumerator(this.items);
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
                this.current = -1;
            }

            string IEnumerator<string>.Current => this.items[this.current];

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
