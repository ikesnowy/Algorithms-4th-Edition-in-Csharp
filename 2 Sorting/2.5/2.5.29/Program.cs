using System;
using System.IO;
using System.Collections.Generic;

namespace _2._5._29
{
    /*
     * 2.5.29
     * 
     * 按大小和最后修改日期将文件排序。
     * 为 File 数据类型编写比较器，
     * 使之能够将文件按照大小、文件名或最后修改日期将文件升序或者降序排列。
     * 在程序 LS 中使用这些比较器，它接受一个命令行参数并根据指定的顺序列出目录的内容。
     * 例如，"-t" 指按照时间戳排序。
     * 支持多个选项以消除排序位次相同者，同时必须确保排序的稳定性。
     * 
     */
    class Program
    {
        class FileSizeComparer : Comparer<FileInfo>
        {
            public override int Compare(FileInfo x, FileInfo y)
            {
                return x.Length.CompareTo(y.Length);
            }
        }

        class FileNameComparer : Comparer<FileInfo>
        {
            public override int Compare(FileInfo x, FileInfo y)
            {
                return x.FullName.CompareTo(y.FullName);
            }
        }

        class FileTimeStampComparer : Comparer<FileInfo>
        {
            public override int Compare(FileInfo x, FileInfo y)
            {
                return x.LastWriteTime.CompareTo(y.LastWriteTime);
            }
        }

        static void Main(string[] args)
        {
            string[] arguments = Console.ReadLine().Split(' ');
            string directoryPath = arguments[0];
            string[] filenames = Directory.GetFiles(directoryPath);
            FileInfo[] fileInfos = new FileInfo[filenames.Length];
            for (int i = 0; i < filenames.Length; i++)
                fileInfos[i] = new FileInfo(filenames[i]);
            string command = arguments[1];
            switch (command)
            {
                case "-t":
                    Array.Sort(fileInfos, new FileTimeStampComparer());
                    break;
                case "-s":
                    Array.Sort(fileInfos, new FileSizeComparer());
                    break;
                case "-n":
                    Array.Sort(fileInfos, new FileNameComparer());
                    break;
            }
            for (int i = 0; i < fileInfos.Length; i++)
            {
                Console.WriteLine(fileInfos[i].Name + "\t" + fileInfos[i].Length + "\t" + fileInfos[i].LastWriteTime);
            }
        }
    }
}
