using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3._43
{
    /*
     * 1.3.43
     * 
     * 文件列表。
     * 文件夹就是一列文件和文件夹的列表。
     * 编写一个程序，从命令行接受一个文件夹名作为参数，
     * 打印出该文件夹下的所有文件并用递归的方式在所有子文件夹的名下（缩进）列出其下的所有文件。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            //获取当前目录
            string path = Directory.GetCurrentDirectory();
            path = Directory.GetParent(path).FullName;
            path = Directory.GetParent(path).FullName;
            //获取文件
            Console.WriteLine(path + "中的所有文件");
            Search(path, 0);
        }

        static void Search(string path, int tabs)
        {
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            foreach (string p in dirs)
            {
                for (int i = 0; i < tabs; ++i)
                {
                    Console.Write("  ");
                }

                Console.WriteLine(p.Split('\\').Last());
                Search(p, tabs + 1);
            }

            foreach (string f in files)
            {
                for (int i = 0; i < tabs; ++i)
                {
                    Console.Write("  ");
                }

                Console.WriteLine(f.Split('\\').Last());
            }
        }
    }
}
