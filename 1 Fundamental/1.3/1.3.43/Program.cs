using System;
using System.IO;
using System.Linq;

namespace _1._3._43
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // 获取当前目录
            string path = Directory.GetCurrentDirectory();
            path = Directory.GetParent(path).FullName;
            path = Directory.GetParent(path).FullName;
            // 获取文件
            Console.WriteLine(path + "中的所有文件");
            Search(path, 0);
        }

        static void Search(string path, int tabs)
        {
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            foreach (string p in dirs)
            {
                for (int i = 0; i < tabs; i++)
                {
                    Console.Write("  ");
                }

                Console.WriteLine(p.Split('\\').Last());
                Search(p, tabs + 1);
            }

            foreach (string f in files)
            {
                for (int i = 0; i < tabs; i++)
                {
                    Console.Write("  ");
                }

                Console.WriteLine(f.Split('\\').Last());
            }
        }
    }
}
