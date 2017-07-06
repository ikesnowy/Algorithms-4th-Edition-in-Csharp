using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3._31
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkList<string> linklist = new DoubleLinkList<string>();
            linklist.InsertRear("fourth");
            linklist.InsertFront("first");
            linklist.InsertAfter("second", 0);
            linklist.InsertBefore("third", 2);

            Console.WriteLine(linklist);

            linklist.DeleteFront();
            Console.WriteLine(linklist);
            linklist.DeleteRear();
            Console.WriteLine(linklist);
            linklist.Delete(1);
            Console.WriteLine(linklist);

            Console.WriteLine(linklist.At(0)); 
        }
    }
}
