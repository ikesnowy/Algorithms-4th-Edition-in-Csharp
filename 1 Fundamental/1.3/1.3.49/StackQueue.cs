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
            isRecopying = false;
            nowcopying = 0;

            H = new Stack<Item>();
            T = new Stack<Item>();
            h = new Stack<Item>();
            HH = new Stack<Item>();
            TT = new Stack<Item>();
            Hr = new Stack<Item>();
        }

        public Item Peek()
        {
            if (isRecopying)
            {
                return h.Peek();
            }
            else
            {
                return H.Peek();
            }
        }

        public void Enqueue(Item item)
        {
            if (!isRecopying && Lendiff() > 0)
            {
                nowcopying = 0;
                T.Push(item);
            }
            else if (!isRecopying && Lendiff() == 0)
            {
                T.Push(item);
                isRecopying = true;
                h = H.Copy();
                OneStep(OneStep(this));
            }
            else if (isRecopying)
            {
                TT.Push(item);
                OneStep(OneStep(this));
            }
        }

        public int Lendiff()
        {
            return H.Size() - T.Size();
        }

        public Item Dequeue()
        {
            if (!isRecopying && Lendiff() > 0)
            {
                return H.Pop();
            }
            else if (!isRecopying && Lendiff() == 0)
            {
                var temp = H.Pop();
                h = H.Copy();
                isRecopying = true;
                OneStep(OneStep(this));
                return temp;
            }
            else
            {
                var temp = h.Pop();
                nowcopying--;
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
