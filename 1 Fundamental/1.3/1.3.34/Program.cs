using System;

namespace _1._3._34
{
    
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
