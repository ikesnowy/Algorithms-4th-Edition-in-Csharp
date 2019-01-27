using System;

namespace _2._5._21
{
    /*
     * 2.5.21
     * 
     * 多维排序。
     * 编写一个 Vector 数据类型并将 d 维整型向量排序。
     * 排序方法是先按照一维数字排序，一维数字相同的向量则按照二维数字排序，
     * 再相同的向量则按照三维数字排序，如此这般。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] data1 = { 1, 2, 3, 4 };
            int[] data2 = { 2, 2, 3, 4 };
            int[] data3 = { 1, 3, 2, 4 };
            int[] data4 = { 1, 2, 3, 3 };
            Vector[] vectors = new Vector[4];
            vectors[0] = new Vector(data1);
            vectors[1] = new Vector(data2);
            vectors[2] = new Vector(data3);
            vectors[3] = new Vector(data4);

            Array.Sort(vectors);

            for (int i = 0; i < vectors.Length; i++)
            {
                Console.WriteLine(vectors[i]);
            }
        }
    }
}
