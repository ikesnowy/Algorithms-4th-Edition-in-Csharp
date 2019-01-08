using System;
using System.IO;
using System.Collections.Generic;

namespace _2._5._9
{
    /*
     * 2.5.9
     * 
     * 为将右侧所示的数据排序编写一个新的数据类型。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 数据示例
            // 1 - Oct - 28           3500000
            // 2 - Oct - 28           3850000
            // 3 - Oct - 28           4060000
            // 4 - Oct - 28           4330000
            // 5 - Oct - 28           4360000
            StreamReader sr = new StreamReader(File.OpenRead("DJIA.prn"));
            List<DJIA> list = new List<DJIA>();
            while (!sr.EndOfStream)
            {
                string[] blocks = sr.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                list.Add(new DJIA(blocks[0], long.Parse(blocks[1])));
            }
            DJIA[] array = list.ToArray();
            Array.Sort(array);
            for (int i = 0; i < 10; i++)
                Console.WriteLine(array[i].Date + "\t" + array[i].Volume);
        }
    }
}
