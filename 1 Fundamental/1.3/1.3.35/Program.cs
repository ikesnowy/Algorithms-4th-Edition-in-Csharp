using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3._35
{
    /*
     * 1.3.25
     * 
     * 随机队列。
     * 随机队列能够存储一组元素并支持下表中的 API。
     * 
     * RandomQueue()
     * 创建一条空的随机队列。
     * bool isEmpty()
     * 队列是否为空。
     * void enqueuer()
     * 添加一个元素。
     * Item dequeuer()
     * 删除并随机返回一个元素（取样且不放回）。
     * Item Sample()
     * 随机返回一个元素且不删除它（取样且放回）。
     * 
     * 编写一个 RandomQueue 类来实现这份 API。
     * 编写一个用例，使用 RandomQueue 在桥牌中发牌。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            RandomQueue<Card> queue = new RandomQueue<Card>();

            //建立牌组
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 1; j <= 13; ++j)
                {
                    Card card = new Card((Suit)i, j);
                    queue.Enqueue(card);
                }
            }

            //发牌
            for (int i = 1; i <= 4; ++i)
            {
                Console.WriteLine("Player " + i);
                for (int j = 1; j <= 13; ++j)
                {
                    Console.WriteLine(queue.Dequeue().ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
