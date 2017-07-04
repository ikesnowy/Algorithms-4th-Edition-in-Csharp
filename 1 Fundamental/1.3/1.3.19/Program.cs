using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;

namespace _1._3._19
{
    /*
     * 1.3.19
     * 
     * 给出一段代码，删除链表的尾结点，其中链表的首结点为 first。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> first = new Node<string>()
            {
                item = "first"
            };
            Node<string> second = new Node<string>()
            {
                item = "second"
            };
            Node<string> third = new Node<string>()
            {
                item = "third"
            };

            first.next = second;
            second.next = third;
            third.next = null;

            Node<string> current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }

            DeleteLast(first);
            Console.WriteLine();

            current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        static void DeleteLast(Node<string> first)
        {
            Node<string> current = first;

            while (current.next.next != null)
            {
                current = current.next;
            }

            current.next = null;
        }
    }
}
