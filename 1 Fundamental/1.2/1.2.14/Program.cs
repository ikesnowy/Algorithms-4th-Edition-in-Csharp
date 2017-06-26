using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commercial;

namespace _1._2._14
{
    /*
     * 1.2.14
     * 
     * 用我们对 Date 中的 equals() 方法的实现（请见 1.2.5.8 节中的 Date 代码框）作为模板，
     * 实现 Transaction 中的 equals() 方法。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Transaction a = new Transaction("Turing 01/01/1991 12.12");
            Transaction b = new Transaction("Turing 01/01/1991 12.12");
            Transaction c = new Transaction("Turing 01/01/1991 12.13");

            Console.WriteLine(a.Equals(b)); // True
            Console.WriteLine(a.Equals(c)); // False
        }
    }
}
