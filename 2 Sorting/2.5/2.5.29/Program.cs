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

        static void InsertionSort<T>(T[] keys, Comparer<T>[] comparers)
        {
            for (int i = 0; i < keys.Length; i++)
                for (int j = i; j > 0 && Less(keys, j, j - 1, comparers); j--)
                {
                    T temp = keys[j];
                    keys[j] = keys[j - 1];
                    keys[j - 1] = temp;
                }
        }

        static bool Less<T>(T[] keys, int x, int y, Comparer<T>[] comparables)
        {
            int cmp = 0;
            for (int i = 0; i < comparables.Length && cmp == 0; i++)
            {
                cmp = comparables[i].Compare(keys[x], keys[y]);
            }
            return cmp < 0;
        }

        static void Main(string[] args)
        {
            string[] arguments = Console.ReadLine().Split(' ');
            string directoryPath = arguments[0];
            string[] filenames = Directory.GetFiles(directoryPath);
            FileInfo[] fileInfos = new FileInfo[filenames.Length];
            for (int i = 0; i < filenames.Length; i++)
                fileInfos[i] = new FileInfo(filenames[i]);

            List<Comparer<FileInfo>> comparers = new List<Comparer<FileInfo>>();
            for (int i = 1; i < arguments.Length; i++)
            {
                string command = arguments[i];
                switch (command)
                {
                    case "-t":
                        comparers.Add(new FileTimeStampComparer());
                        break;
                    case "-s":
                        comparers.Add(new FileSizeComparer());
                        break;
                    case "-n":
                        comparers.Add(new FileNameComparer());
                        break;
                }
            }
            InsertionSort(fileInfos, comparers.ToArray());
            for (int i = 0; i < fileInfos.Length; i++)
            {
                Console.WriteLine(fileInfos[i].Name + "\t" + fileInfos[i].Length + "\t" + fileInfos[i].LastWriteTime);
            }
        }
    }
}
