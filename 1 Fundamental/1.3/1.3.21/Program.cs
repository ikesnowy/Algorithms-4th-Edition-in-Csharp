using System;
using Generics;

namespace _1._3._21
{
    
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
