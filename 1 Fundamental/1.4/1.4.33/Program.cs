namespace _1._4._33
{
    /*
     * 1.4.33
     * 
     * 32 位计算机中的内存需求。
     * 给出 32 位计算机中 Integer、Date、Counter、int[]、double[]、double[][]、String、Node 和 Stack（链表表示）对象所需的内存，
     * 设引用需要 4 字节，表示对象的开销为 8 字节，所需内存均会被填充为 4 字节的倍数。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // Integer = 4(int) + 8(对象开销) = 12
            // Date = 3 * 4(int * 3) + 8(对象开销) = 20
            // Counter = 4(String 的引用) + 4(int) + 8(对象开销) = 16
            // int[] = 8(对象开销) + 4(数组长度) + 4N = 12 + 4N
            // double[] = 8(对象开销) + 4(数组长度) + 8N = 12 + 8N
            // double[][] = 8(对象开销) + 4(数组长度) + 4M(引用) + M(12 + 8N)(M 个一维数组) = 12 + 16M + 8MN
            // String = 8(对象开销) + 3*4(int * 3) + 4(字符数组的引用) + 8(字符数组对象开销) + 4(字符数组长度) + 2N(字符串) = 36 + 2N
            // Node = 8(对象开销) + 4*2(引用*2) = 16
            // Stack = 8(对象开销) + 4(引用) + 4(int) + N(Node + Integer)(元素) = 16 + 28N
        }
    }
}
