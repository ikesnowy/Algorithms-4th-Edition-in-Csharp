using System;
using System.IO;

namespace _1._2._15
{
    
    static class Program
    {
        static void Main(string[] args)
        {
            int[] tinyT = ReadInts("tinyT.txt");
            foreach (int n in tinyT) 
            {
                Console.WriteLine(n);
            }
        }

        public static int[] ReadInts(string path)
        {
            string[] allLines = File.ReadAllLines(path);
            int[] result = new int[allLines.Length];
            
            for (int i = 0; i < allLines.Length; i++)
            {
                result[i] = int.Parse(allLines[i]);
            }

            return result;
        }
    }
}
