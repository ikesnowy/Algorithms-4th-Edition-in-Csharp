namespace _1._3._44
{
    /*
     * 1.3.44
     * 
     * 文本编辑器的缓冲区。
     * 为文本编辑器的缓冲区设计一种数据类型并实现下表中的 API。
     * Buffer()
     * 构造函数
     * void insert(char c)
     * 在光标位置插入字符 c
     * char delete()
     * 删除并返回光标位置的字符
     * void left(int k)
     * 光标向左移动 k 个位置
     * void right(int k)
     * 光标向右移动 k 个位置
     * int size()
     * 缓冲区中的字符数量
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Buffer buffer = new Buffer();
            buffer.Insert('1');
            buffer.Insert('2');
            buffer.Insert('3');
            buffer.Insert('4');

            buffer.Left(2);
            buffer.Delete();
            buffer.Insert('5');
            System.Console.WriteLine(buffer.Getstring());
        }
    }
}
