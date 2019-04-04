using SymbolTable;

namespace _3._1._29
{
    /*
     * 3.1.29
     * 
     * 测试用例。
     * 编写一段测试代码 TestBinarySearch.java 
     * 用来测试正文中 
     * min()、max()、floor()、ceiling()、
     * select()、rank()、deleteMin()、deleteMax() 和 keys() 的实现。
     * 可以参考 3.1.3.1 节的索引用例，添加代码使其在适当的情况下接受更多的命令行参数。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 官方实现：https://algs4.cs.princeton.edu/31elementary/TestBinarySearchST.java.html
            // 官方实现有几处会抛出异常，这份代码已做了相应修改。
            TestBinarySearchST.Test(new BinarySearchST<string, int>());
        }
    }
}
