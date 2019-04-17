using System;

namespace _3._1._27
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int n = 3000;
            int[] data = new int[n];
            for (int i = 0; i < n; i++)
                data[i] = i;
            Shuffle(data);

            Console.WriteLine("\t比较\t交换\t总和");
            Console.Write("Put()\t");
            BinarySearchST<int, int> bst = new BinarySearchST<int, int>(n);
            for (int i = 0; i < n; i++)
            {
                bst.Put(data[i], i);
            }
            Console.WriteLine(bst.Compares + "\t" + bst.Exchanges + "\t" + (bst.Compares + bst.Exchanges));
            bst.Compares = 0;
            bst.Exchanges = 0;

            Console.Write("Get()\t");
            int s = (int)(n + (n * n - n) / (4 * Math.Log(n, 2)));
            int[] query = new int[s];
            for (int i = 0; i < s; i++)
            {
                query[i] = random.Next(n);
            }
            for (int i = 0; i < s; i++)
            {
                bst.Get(query[i]);
            }
            Console.WriteLine(bst.Compares + "\t" + bst.Exchanges + "\t" + (bst.Compares + bst.Exchanges));
        }

        static void Shuffle(int[] data)
        {
            Random random = new Random();
            for (int i = 0; i < data.Length; i++)
            {
                int r = i + random.Next(data.Length - i);
                int temp = data[i];
                data[i] = data[r];
                data[r] = temp;
            }
        }
    }
}
