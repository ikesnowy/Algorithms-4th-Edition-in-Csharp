using System;

namespace _1._3._36
{
    /*
     * 
     * 随机迭代器。
     * 为上一题中的 RandomQueue<Card> 编写一个迭代器，随机返回队列中的所有元素。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            RandomQueue<Card> queue = new RandomQueue<Card>();

            // 建立牌组
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 1; j <= 13; ++j)
                {
                    Card card = new Card((Suit)i, j);
                    queue.Enqueue(card);
                }
            }

            // 随机输出
            foreach (Card c in queue)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
