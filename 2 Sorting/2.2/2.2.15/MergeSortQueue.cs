using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._15
{
    /// <summary>
    /// 利用队列归并实现的自底向上的归并排序。
    /// </summary>
    class MergeSortQueue
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MergeSortQueue() { }

        /// <summary>
        /// 利用队列归并进行自底向上的归并排序。
        /// </summary>
        /// <typeparam name="T">需要排序的元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public void Sort<T>(T[] a) where T : IComparable<T>
        {
            Queue<Queue<T>> queueList = new Queue<Queue<T>>();
            for (int i = 0; i < a.Length; i++)
            {
                Queue<T> temp = new Queue<T>();
                temp.Enqueue(a[i]);
                queueList.Enqueue(temp);
            }

            while (queueList.Size() != 1)
            {
                int times = queueList.Size() / 2;
                for (int i = 0; i < times; i++)
                {
                    Queue<T> A = queueList.Dequeue();
                    Queue<T> B = queueList.Dequeue();
                    queueList.Enqueue(Merge(A, B));
                }
            }

            Queue<T> result = queueList.Dequeue();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = result.Dequeue();
            }
        }

        /// <summary>
        /// 归并两个有序队列。输入队列将被清空。
        /// </summary>
        /// <typeparam name="T">有序队列的元素类型。</typeparam>
        /// <param name="a">需要归并的队列。</param>
        /// <param name="b">需要归并的队列。</param>
        /// <returns>归并后的新队列。</returns>
        public static Queue<T> Merge<T>(Queue<T> a, Queue<T> b) where T : IComparable<T>
        {
            Queue<T> sortedQueue = new Queue<T>();
            while (!a.IsEmpty() && !b.IsEmpty())
            {
                if (a.Peek().CompareTo(b.Peek()) < 0)
                    sortedQueue.Enqueue(a.Dequeue());
                else
                    sortedQueue.Enqueue(b.Dequeue());
            }

            while (!a.IsEmpty())
                sortedQueue.Enqueue(a.Dequeue());
            while (!b.IsEmpty())
                sortedQueue.Enqueue(b.Dequeue());

            return sortedQueue;
        }
    }
}
