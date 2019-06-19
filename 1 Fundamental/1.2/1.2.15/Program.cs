using System;
using System.IO;

namespace _1._2._15
{
    static class Program
    {
        static void Main(string[] args)
        {
            var tinyT = ReadInts("tinyT.txt");
            foreach (var n in tinyT)
            {
                Console.WriteLine(n);
            }
        }

        public static int[] ReadInts(string path)
        {
            var allLines = File.ReadAllLines(path);
            var result = new int[allLines.Length];

            for (var i = 0; i < allLines.Length; i++)
            {
                result[i] = int.Parse(allLines[i]);
            }

            return result;
        }
    }
}