namespace _3._1._21
{
    /*
     * 3.1.21
     * 
     * 内存使用。基于 1.4 节中的假设，
     * 对于 N 对键值比较 BinarySearchST 和 SequentialSearchST 的内存使用情况。
     * 不需要记录键值本身占用的内存，只统计它们的引用。
     * 对于BinarySearchST，假设数组大小可以动态调整，数组中被占用的空间比例为 25%~100%。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // BinarySearchST
            // 包含一个键数组和一个值数组，以及一个 int 变量
            // 数组长度变化范围为 N~4N ，故总大小
            // 从 2 × (24 + 8N) + 4 = 52 + 16N 字节 （100%）
            // 到 2 × (24 + 32N) + 4 = 52 + 64N 字节（25%）之间变动。
            // SequentialSearchST
            // 包含 N 个结点以及一个 int 变量
            // (16 + 8 + 8 + 8)N + 4 = 4 + 40N 字节
        }
    }
}
