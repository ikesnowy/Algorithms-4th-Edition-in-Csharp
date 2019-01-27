using System;

namespace _2._5._10
{
    /*
     * 2.5.10
     * 
     * 创建一个数据类型 Version 来表示软件的版本，
     * 例如 155.1.1、155.10.1、155.10.2。
     * 为它实现 Comparable 接口，
     * 其中 115.1.1 的版本低于 115.10.1。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Version[] versions = new Version[3];
            versions[0] = new Version("155.10.1");
            versions[1] = new Version("155.1.1");
            versions[2] = new Version("155.10.2");
            Array.Sort(versions);
            for (int i = 0; i < versions.Length; i++)
            {
                Console.WriteLine(versions[i]);
            }
        }
    }
}
