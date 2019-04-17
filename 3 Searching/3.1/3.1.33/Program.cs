using System;
using System.Diagnostics;
using SymbolTable;

namespace _3._1._33
{
    
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int n = 1000;
            int multiplyBy10 = 4;
            for (int i = 0; i < multiplyBy10; i++)
            {
                Console.WriteLine("n=" + n);
                // 构造表
                BinarySearchST<string, int> bst = new BinarySearchST<string, int>(n);
                MoveToFrontArrayST<string, int> mst = new MoveToFrontArrayST<string, int>(n);
                string[] keys = SearchCompare.GetRandomArrayString(n, 3, 20);
                for (int j = 0; j < n; j++)
                {
                    bst.Put(keys[j], j);
                    mst.Put(keys[j], j);
                }
                // 构造查询
                Array.Sort(keys);
                string[] querys = new string[10 * n];
                int queryIndex = 0, keyIndex = 0;
                while (queryIndex < querys.Length)
                {
                    int searchTimes = (int)Math.Ceiling((Math.Pow(0.5, keyIndex + 1) * querys.Length));
                    
                    for (int j = 0; j < searchTimes && queryIndex < querys.Length; j++)
                    {
                        querys[queryIndex++] = keys[keyIndex];
                    }
                    keyIndex++;
                }
                Shuffle(querys);

                Stopwatch sw = new Stopwatch();
                // 测试 MoveToFrontArrayST
                sw.Start();
                for (int j = 0; j < querys.Length; j++)
                {
                    mst.Get(querys[j]);
                }
                sw.Stop();
                Console.WriteLine("MoveToFrontArrayST: " + sw.ElapsedMilliseconds);

                // 测试 BinarySearchST
                sw.Restart();
                for (int j = 0; j < querys.Length; j++)
                {
                    bst.Get(querys[j]);
                }
                sw.Stop();
                Console.WriteLine("BinarySearchST: " + sw.ElapsedMilliseconds);

                n *= 10;
            }
        }

        static void Shuffle<T>(T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                int r = i + random.Next(data.Length - i);
                T temp = data[r];
                data[r] = data[i];
                data[i] = temp;
            }
        }
    }
}
