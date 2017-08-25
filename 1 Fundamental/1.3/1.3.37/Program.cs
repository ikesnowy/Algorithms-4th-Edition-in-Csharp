using System;
using Generics;

namespace _1._3._1
{
    /*
     * 1.3.37
     * 
     * Josephus 问题。
     * 在这个古老的问题中，N 个身陷绝境的人一致同意通过以下方式减少生存人数。
     * 他们围坐成一圈（位置记作 0 到 N-1）并从第一个人开始报数，
     * 报到 M 的人会被杀死，直到最后一个人留下来。
     * 传说中 Josephus 找到了不会被杀死的位置。
     * 编写一个 Queue 的用例 Josephus，从命令行接受 N 和 M 并打印出人们被杀死的顺序
     * （这也将显示 Josephus 在圈中的位置）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPeople = 7;
            int callForDeath = 2;

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numOfPeople; ++i)
            {
                queue.Enqueue(i);
            }

            while (!queue.IsEmpty())
            {
                for (int i = 0; i < callForDeath - 1; ++i)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.Write(queue.Dequeue() + " ");
            }
            Console.WriteLine();
        }
    }
}
