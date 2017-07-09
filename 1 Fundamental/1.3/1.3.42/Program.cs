using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;

namespace _1._3._42
{
    /*
     * 1.3.42
     * 
     * 复制栈。
     * 为基于链表实现的栈编写一个新的构造函数，使以下代码
     * Stack t = new Stack(s);
     * 得到的 t 指向栈 s 的一个新的独立的副本。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> s = new Stack<string>();
            s.Push("third");
            s.Push("second");
            s.Push("first");

            Stack<string> t = new Stack<string>(s);

            Console.WriteLine("s:" + s);
            Console.WriteLine("t:" + t);

            t.Pop();
            s.Push("zero");

            Console.WriteLine("s:" + s);
            Console.WriteLine("t:" + t);
        }
    }
}
