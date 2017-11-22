using Generics;

namespace _1._3._49
{
    /// <summary>
    /// 用六个栈模拟的队列。
    /// </summary>
    /// <typeparam name="Item">队列中保存的元素。</typeparam>
    class StackQueue<Item>
    {
        Stack<Item> H;
        Stack<Item> T;
        Stack<Item> h;
        Stack<Item> HH;
        Stack<Item> TT;
        Stack<Item> Hr;

        bool isRecopying;
        int nowcopying;

        public StackQueue()
        {
            this.isRecopying = false;
            this.nowcopying = 0;

            this.H = new Stack<Item>();
            this.T = new Stack<Item>();
            this.h = new Stack<Item>();
            this.HH = new Stack<Item>();
            this.TT = new Stack<Item>();
            this.Hr = new Stack<Item>();
        }

        public Item Peek()
        {
            if (this.isRecopying)
            {
                return this.h.Peek();
            }
            else
            {
                return this.H.Peek();
            }
        }

        public void Enqueue(Item item)
        {
            if (!this.isRecopying && Lendiff() > 0)
            {
                this.nowcopying = 0;
                this.T.Push(item);
            }
            else if (!this.isRecopying && Lendiff() == 0)
            {
                this.T.Push(item);
                this.isRecopying = true;
                this.h = this.H.Copy();
                OneStep(OneStep(this));
            }
            else if (this.isRecopying)
            {
                this.TT.Push(item);
                OneStep(OneStep(this));
            }
        }

        public int Lendiff()
        {
            return this.H.Size() - this.T.Size();
        }

        public Item Dequeue()
        {
            if (!this.isRecopying && Lendiff() > 0)
            {
                return this.H.Pop();
            }
            else if (!this.isRecopying && Lendiff() == 0)
            {
                Item temp = this.H.Pop();
                this.h = this.H.Copy();
                this.isRecopying = true;
                OneStep(OneStep(this));
                return temp;
            }
            else
            {
                Item temp = this.h.Pop();
                this.nowcopying--;
                OneStep(OneStep(this));
                return temp;
            }
        }

        private static StackQueue<Item> OneStep(StackQueue<Item> q)
        {
            if (q.isRecopying && !q.H.IsEmpty() && !q.T.IsEmpty())
            {
                q.nowcopying++;
                q.HH.Push(q.T.Pop());
                q.Hr.Push(q.H.Pop());
            }
            else if (q.isRecopying && q.H.IsEmpty() && !q.T.IsEmpty())
            {
                q.isRecopying = true;
                q.HH.Push(q.T.Pop());
            }
            else if (q.isRecopying && q.H.IsEmpty() && q.T.IsEmpty() && q.nowcopying > 1)
            {
                q.isRecopying = true;
                q.nowcopying--;
                q.HH.Push(q.Hr.Pop());
            }
            else if (q.isRecopying && q.H.IsEmpty() && q.T.IsEmpty() && q.nowcopying == 1)
            {
                q.isRecopying = false;
                q.nowcopying--;
                q.HH.Push(q.Hr.Pop());
                q.H = q.HH;
                q.T = q.TT;
                q.HH = new Stack<Item>();
                q.TT = new Stack<Item>();
                q.Hr = new Stack<Item>();
                q.h = new Stack<Item>();
            }
            else if (q.isRecopying && q.H.IsEmpty() && q.T.IsEmpty() && q.nowcopying == 0)
            {
                q.isRecopying = false;
                q.H = q.HH;
                q.T = q.TT;
                q.HH = new Stack<Item>();
                q.TT = new Stack<Item>();
                q.Hr = new Stack<Item>();
                q.h = new Stack<Item>();
            }
            return q;
        }
    }
}
