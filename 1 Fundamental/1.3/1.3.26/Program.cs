using System;
using Generics;

namespace _1._3._26
{
    /*
     * 1.3.26
     * 
     * 编写一个方法 remove()，接受一条链表和一个字符串 key 作为参数，
     * 删除链表中所有 item 域为 key 的结点。
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
            link.Insert("third", 3);
            link.Insert("third", 4);

            Console.WriteLine(link);
            Remove(link, "third");
            Console.WriteLine(link);
        }

        static void Remove(LinkedList<string> link, string key)
        {
            for (int i = 0; i < link.Size(); i++)
            {
                if (link.Find(i) == key)
                {
                    link.Delete(i);
                    i--;
                }
            }
        }
    }
}
