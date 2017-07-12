using System;
using Generics;

namespace _1._3._21
{
    /*
     * 1.3.21
     * 
     * 编写一个方法 find()，接受一条链表和一个字符串 key 作为参数。
     * 如果链表中的某个结点的 item 域的值为 key，则方法返回 true，否则返回 false。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> link = new LinkedList<string>();
            link.Insert("first", 0);
            link.Insert("second", 1);
            link.Insert("third", 2);

            Console.WriteLine(Find(link, "second"));
            Console.WriteLine(Find(link, "fourth"));
        }

        static bool Find<Item>(LinkedList<Item> link, Item key)
        {
            foreach (Item i in link)
            {
                if (i.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
