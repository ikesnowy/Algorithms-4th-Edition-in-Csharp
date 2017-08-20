using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._3._14
{
    class ResizingArrayQueueOfStrings<Item> : IEnumerable<Item>
    {
        private Item[] q;
        private int count;
        private int first;
        private int last;

        public ResizingArrayQueueOfStrings()
        {
            this.q = new Item[2];
            this.count = 0;
            this.first = 0;

        }

        public bool IsEmpty()
        {
            return this.count == 0;
        }

        public int Size()
        {
            return this.count;
        }

        private void Resize(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("capacity should be above zero");
            Item[] temp = new Item[capacity];
            for (int i = 0; i < this.count; ++i)
            {
                temp[i] = this.q[(this.first + i) % this.q.Length];
            }

            this.q = temp;
            this.first = 0;
            this.last = this.count;
        }

        public void Enqueue(Item item)
        {
            if (this.count == this.q.Length)
            {
                Resize(this.count * 2);
            }

            this.q[this.last] = item;
            this.last++;
            if (this.last == this.q.Length)
                this.last = 0;
            this.count++;
        }

        public Item Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            Item item = this.q[this.first];
            this.q[this.first] = default(Item);
            this.count--;
            this.first++;
            if (this.first == this.q.Length)
                this.first = 0;

            if (this.count > 0 && this.count <= this.q.Length / 4)
                Resize(this.q.Length / 2);
            return item;
        }

        public Item Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue underflow");
            return this.q[this.first];
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new QueueEnumerator(this.q, this.first, this.last);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class QueueEnumerator : IEnumerator<Item>
        {
            int current;
            int first;
            int last;
            Item[] q;

            public QueueEnumerator(Item[] q, int first, int last)
            {
                this.current = first - 1;
                this.first = first;
                this.last = last;
                this.q = q;
            }

            Item IEnumerator<Item>.Current => this.q[this.current];

            object IEnumerator.Current => this.q[this.current];

            void IDisposable.Dispose()
            {
                
            }

            bool IEnumerator.MoveNext()
            {
                if (this.current == this.last - 1)
                    return false;
                this.current++;
                return true;
            }

            void IEnumerator.Reset()
            {
                this.current = this.first - 1;
            }
        }
    }
}
