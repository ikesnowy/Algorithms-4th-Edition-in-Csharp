using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;

namespace _1._3._18
{
    /*
     * 1.3.18
     * 
     * 假设 x 是一条链表的某个结点且不是尾结点。
     * 下面这条语句的效果是什么？
     * x.next = x.next.next;
     * 
     */
    class Program
    {
        //删除 x 的后一个结点。
        static void Main(string[] args)
        {
            Node<string> x = new Node<string>();
            x.item = "first";
            Node<string> y = new Node<string>();
            y.item = "second";
            x.next = y;
            Node<string> z = new Node<string>();
            z.item = "third";
            y.next = z;

            Console.WriteLine("x: " + x.item);
            Console.WriteLine("x.next: " + x.next.item);
            x.next = x.next.next;
            Console.WriteLine();
            Console.WriteLine("x: " + x.item);
            Console.WriteLine("x.next: " + x.next.item);
        }
    }
}
