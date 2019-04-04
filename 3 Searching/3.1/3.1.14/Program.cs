namespace _3._1._14
{
    /*
     * 3.1.14
     * 
     * 对于一个会随机混合进行 10^6 次 put() 和 10^3 次 get() 操作的应用程序，
     * 你会使用本节中的哪种符号表实现？说明理由。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 根据上题给出的结论，选择 BinarySearchST。
            // 由于 BinarySearchST 和 SequentialSearchST 执行 Put() 的开销相同
            // 因此选择 Get() 开销更低的 BinarySearchST。
        }
    }
}
