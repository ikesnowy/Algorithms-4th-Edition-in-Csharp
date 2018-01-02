using System;

namespace _1._3._34
{
    /*
     * 1.3.34
     * 
     * 随机背包。
     * 随机背包能够存储一组元素并支持下表中的 API：
     * 
     * RandomBag()
     * 创建一个空随机背包。
     * bool isEmpty()
     * 背包是否为空。
     * int size()
     * 背包中的元素数量。
     * void add(Item item)
     * 添加一个元素。
     * 
     * 编写一个 RandomBag 类来实现这份 API。请注意，除了形容词随机之外，
     * 这份 API 和 Bag 的 API 是相同的，这意味着迭代应该随机访问背包中的所有元素
     * （对于每次迭代，所有的 N! 种排列出现的可能性均相同）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            RandomBag<int> bag = new RandomBag<int>();
            bag.Add(0);
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);
            bag.Add(4);
            bag.Add(5);

            double[] times = new double[6];
            int count = 100000;

            for (int i = 0; i < count; i++)
            {
                int current = 0;
                foreach(int n in bag)
                {
                    times[current] += n;
                    current++;
                }
            }

            for (int i = 0; i < 6; i++)
            {
                times[i] /= (double)count;
            }

            foreach (double d in times)
            {
                Console.Write(d + " ");
            }
            Console.WriteLine();
        }
    }
}
