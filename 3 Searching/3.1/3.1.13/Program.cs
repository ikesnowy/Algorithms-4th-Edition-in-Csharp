namespace _3._1._13
{
    /*
     * 3.1.13
     * 
     * 对于一个会随机混合进行 10^3 次 put() 和 10^6 次 get() 操作的应用程序，
     * 你会使用本节中的哪种符号表的实现？说明理由。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // Get() 调用次数比 Put() 调用次数多了三个数量级，
            // BinarySearchST 和 SequentialSearchST 的平均 Put() 开销是一样的，
            // 因此选择平均 Get() 开销更小的 BinarySearchST。
        }
    }
}
