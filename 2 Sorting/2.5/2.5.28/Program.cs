using System;
using System.IO;

namespace _2._5._28
{
    /*
     * 2.5.28
     * 
     * 按文件名排序。
     * 编写一个 FileSorter 程序，
     * 从命令行接受一个目录名并打印出按照文件名排序后的所有文件。
     * 提示：使用 File 数据类型。
     * 
     */
    class Program
    {
        // 官方解答：https://algs4.cs.princeton.edu/25applications/FileSorter.java.html
        static void Main(string[] args)
        {
            // 输入 ./ 获得当前目录文件。
            string directoryName = Console.ReadLine();
            if (!Directory.Exists(directoryName))
            {
                Console.WriteLine(directoryName + " doesn't exist or isn't a directory");
                return;
            }
            string[] directoryFiles = Directory.GetFiles(directoryName);
            Array.Sort(directoryFiles);
            for (int i = 0; i < directoryFiles.Length; i++)
                Console.WriteLine(directoryFiles[i]);
        }
    }
}
