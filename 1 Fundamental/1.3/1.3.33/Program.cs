using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3._33
{
    /*
     * 1.3.33
     * 
     * Deque。
     * 一个双向队列（或称 deque）和栈或队列类似，但它同时支持在两端添加或删除元素。
     * Deque 能够存储一组元素并支持下表中的 API：
     * 
     * Deque()
     * 创建空双向队列。
     * Bool isEmpty()
     * 双向队列是否为空。
     * int size()
     * 双向队列中的元素数量。
     * void pushLeft(Item item)
     * 向左端添加一个新元素。
     * void pushRight(Item item)
     * 向右端添加一个新元素。
     * Item popLeft()
     * 从左端删除一个元素。
     * Item popRight()
     * 从右端删除一个元素。
     * 
     * 编写一个使用双向链表实现这份 API 的 Deque 类，
     * 以及一个使用动态数组调整实现这份 API 的 ResizingArrayDeque 类。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Deque<string> a = new Deque<string>();
            ResizingArrayDeque<string> b = new ResizingArrayDeque<string>();

            a.PushLeft("first");
            b.PushLeft("first");
            a.PushRight("second");
            b.PushRight("second");
            Display(a, b);

            a.PopLeft();
            b.PopLeft();
            Display(a, b);
            a.PopRight();
            b.PopRight();
            Display(a, b);
        }

        static void Display(Deque<string> a, ResizingArrayDeque<string> b)
        {
            foreach (string s in a)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            foreach (string s in b)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
