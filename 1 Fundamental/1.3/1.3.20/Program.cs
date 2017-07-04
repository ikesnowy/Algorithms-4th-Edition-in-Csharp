using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;

namespace _1._3._20
{
    /*
     * 1.3.20
     * 
     * 编写一个方法 delete()，接受一个 int 参数 k，删除链表的第 k 个元素（如果它存在的话）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.Insert("first", 0);
            linkedList.Insert("second", 1);
            linkedList.Insert("third", 2);
            linkedList.Insert("fourth", 3);

            Console.WriteLine(linkedList.ToString());
            linkedList.Delete(2);
            Console.WriteLine(linkedList.ToString());
        }
    }
}
