using System;

namespace _2._2._18
{
    /*
     * 2.2.18
     * 
     * 打乱链表。
     * 实现一个分治算法，
     * 使用线性对数级别的时间和对数级别的额外空间随机打乱一条链表。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 对于两个只有一个元素的链表，打乱操作等于50%可能交换+50%可能不交换。
            // 将链表不断对半切分，再随机决定是否交换
            LinkedList<int> a = new LinkedList<int>();
            Random random = new Random();
            a.Insert(1);
            a.Insert(2);
            a.Insert(3);
            a.Insert(4);
            a.Insert(5);
            a.Insert(6);

            a = Shuffle(a, random);
            foreach (int i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 随机打乱链表。
        /// </summary>
        /// <typeparam name="T">链表中的元素类型。</typeparam>
        /// <param name="a">需要打乱的链表。</param>
        static LinkedList<T> Shuffle<T>(LinkedList<T> a, Random random)
        {
            if (a.Size() == 1)
                return a;

            a.SplitInHalf(out LinkedList<T> A, out LinkedList<T> B);

            A = Shuffle(A, random);
            B = Shuffle(B, random);
            return RandomMerge(A, B, random);
        }

        /// <summary>
        /// 随机合并两个链表，返回合并后的链表。
        /// </summary>
        /// <typeparam name="T">链表中的元素类型。</typeparam>
        /// <param name="a">需要合并的链表。</param>
        /// <param name="b">需要合并的链表。</param>
        /// <returns>合并后的链表。</returns>
        static LinkedList<T> RandomMerge<T> (LinkedList<T> a, LinkedList<T> b, Random random)
        {
            if (random.Next(10) > 4)
            {
                LinkedList<T>.Merge(a, b);
                return a;
            }
            else
            {
                LinkedList<T>.Merge(b, a);
                return b;
            }
        }
    }
}
