using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._26
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "128";
            Console.WriteLine(int.TryParse(s, out int result));// True
            Console.WriteLine(result);// 128
            Console.WriteLine(Convert.ToInt32(s)); //128
            
        }
    }
}
