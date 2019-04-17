using System;

namespace _1._3._35
{
    
    class Program
    {
        static void Main(string[] args)
        {
            RandomQueue<Card> queue = new RandomQueue<Card>();

            // 建立牌组
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    Card card = new Card((Suit)i, j);
                    queue.Enqueue(card);
                }
            }

            // 发牌
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("Player " + i);
                for (int j = 1; j <= 13; j++)
                {
                    Console.WriteLine(queue.Dequeue().ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
