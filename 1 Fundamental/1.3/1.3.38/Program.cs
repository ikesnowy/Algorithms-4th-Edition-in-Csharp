using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3._38
{
    /*
     * 1.3.38
     * 
     * 删除第 k 个元素。
     * 实现一个类并支持下表的 API：
     * 
     * GeneralizeQueue()
     * 创建一条空队列。
     * bool isEmpty()
     * 队列是否为空。
     * void Insert(Item x)
     * 添加一个元素。
     * Item delete(int k)
     * 删除并返回最早插入的第 k 个元素。
     * 
     * 首先用数组实现该数据类型，然后用链表实现该数据类型。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            ArrayBasedGeneralizeQueue<string> a = new ArrayBasedGeneralizeQueue<string>();
            LinkedListBasedGeneralizeQueue<string> b = new LinkedListBasedGeneralizeQueue<string>();

            a.Insert("first");
            b.Insert("first");
            a.Insert("second");
            b.Insert("second");
            a.Insert("third");
            b.Insert("third");

            Console.WriteLine(a.Delete(2));
            Console.WriteLine(b.Delete(2));
            Console.WriteLine(a.Delete(3));
            Console.WriteLine(b.Delete(3));
        }
    }
}
