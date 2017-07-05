using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;

namespace _1._3._27
{
    /*
     * 1.3.27
     * 
     * 编写一个方法 max()，接受一条链表的首结点作为参数，返回链表中键最大的节点的值。
     * 假设所有键均为正整数，如果链表为空则返回 0。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> first = new Node<int>();
            Node<int> second = new Node<int>();
            Node<int> third = new Node<int>();
            Node<int> fourth = new Node<int>();

            first.item = 1;
            second.item = 2;
            third.item = 3;
            fourth.item = 4;

            first.next = second;
            second.next = third;
            third.next = fourth;
            fourth.next = null;

            Console.WriteLine("Max:" + Max(first));
        }

        static int Max(Node<int> first)
        {
            int max = 0;

            Node<int> current = first;
            while (current != null)
            {
                if (max < current.item)
                {
                    max = current.item;
                }
                current = current.next;
            }

            return max;
        }
    }
}
