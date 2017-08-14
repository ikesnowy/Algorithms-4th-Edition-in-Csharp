using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._27
{
    /*
     * 1.4.27
     * 
     * 两个栈实现的队列。
     * 用两个栈实现一个队列，使得每个队列操作所需要的堆栈操作均摊后为一个常数。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            StackQueue<string> queue = new StackQueue<string>();
            string[] input = "to be or not to - be - - that - - - is".Split(' ');
            
            foreach (string s in input)
            {
                if (s == "-")
                {
                    Console.WriteLine(queue.Dequeue());
                }
                else
                {
                    queue.Enqueue(s);
                }
            }
        }
    }
}
