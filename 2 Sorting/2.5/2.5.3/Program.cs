namespace _2._5._3
{
    /*
     * 2.5.3
     * 
     * 找出下面这段账户余额 Balance 类的实现代码的错误。
     * 为什么 compareTo() 方法对 Comparable 接口的实现有缺陷？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 给出的代码相当于划定了一个范围，落在范围内的数据都算作相等。
            // 但这样的话会破坏相等的传递性，例如
            // a = 0.005, b=0.000, c=-0.005
            // 根据代码可以得出 a == b c == b，但是 a != c。
        }
    }
}
