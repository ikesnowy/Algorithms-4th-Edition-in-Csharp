using System;

namespace _1._3._14
{
    /*
     * 1.3.14
     * 
     * 编写一个类 ResizingArrayQueueOfStrings，
     * 使用定长数组实现队列的抽象，然后扩展实现，
     * 使用调整数组的方法突破大小的限制。
     * 
     */
    class Program
    {
        public static void Main(string[] args)
        {
            ResizingArrayQueueOfStrings<string> queue = new ResizingArrayQueueOfStrings<string>();
            string[] input = "to be or not to - be - - that - - - is".Split(' ');

            foreach (string s in input)
            {
                if (!s.Equals("-"))
                    queue.Enqueue(s);
                else if (!queue.IsEmpty())
                    Console.Write(queue.Dequeue() + ' ');
            }
            Console.WriteLine("(" + queue.Size() + " left on queue)");
        }
    }
}
