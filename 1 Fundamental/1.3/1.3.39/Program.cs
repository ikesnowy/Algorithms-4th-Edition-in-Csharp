using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3._39
{
    /*
     * 1.3.39
     * 
     * 环形缓冲区。
     * 环形缓冲区，又称为环形队列，是一种定长为 N 的先进先出的数据结构。
     * 它在进程间的异步数据传输或记录日志文件时十分有用。
     * 当缓冲区为空时，消费者会在数据存入缓冲区前等待；
     * 当缓冲区满时，生产者会等待数据存入缓冲区。
     * 为 RingBuffer 设计一份 API 并用（回环）数组将其实现。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            RingBuffer<string> buffer = new RingBuffer<string>(5);

            try
            {
                for (int i = 0; i < 6; ++i)     //引发 OutOfMemory 异常
                {
                    buffer.Write(i.ToString());
                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("缓冲区已满");
            }

            while (!buffer.IsEmpty())
            {
                Console.WriteLine(buffer.Read());
            }

            buffer.Write("first");
            buffer.Write("second");
            Console.WriteLine(buffer.Read());
        }
    }
}
