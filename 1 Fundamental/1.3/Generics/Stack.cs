using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Stack<Item> : IEnumerable<Item>
    {
        private Node<Item> first;
        private int count;

        public Stack()
        {
            this.first = null;
            this.count = 0;
        }

        public bool IsEmpty()
        {
            return this.first == null;
        }

        public int Size()
        {
            return this.count;
        }

        public void Push(Item item)
        {
            Node<Item> oldFirst = first;
            this.first = new Node<Item>();
            this.first.item = item;
            this.first.next = oldFirst;
            count++;
        }

        public Item Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack Underflow");
            Item item = first.item;
            first = first.next;
            count--;
            return item;
        }

        public Item Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack Underflow");
            return first.item;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (Item n in this)
            {
                s.Append(n);
                s.Append(' ');
            }
            return s.ToString();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new StackEnumerator(this.first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class StackEnumerator : IEnumerator<Item>
        {
            private Node<Item> current;
            private Node<Item> first;

            public StackEnumerator(Node<Item> first)
            {
                this.current = new Node<Item>();
                this.current.next = first;
                this.first = this.current;
            }

            Item IEnumerator<Item>.Current => current.item;

            object IEnumerator.Current => current.item;

            void IDisposable.Dispose()
            {
                this.current = null;
                this.first = null;
            }

            bool IEnumerator.MoveNext()
            {
                if (this.current.next == null)
                    return false;

                this.current = this.current.next;
                return true;
            }

            void IEnumerator.Reset()
            {
                this.current = this.first;
            }
        }
    }
}
