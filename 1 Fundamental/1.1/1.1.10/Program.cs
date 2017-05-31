namespace _1._1._10
{
    /*
     * 1.1.10
     * 
     * 下面这段代码有什么问题？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a;
            for (int i = 0; i < 10; i++)
            {
                a[i] = i * i; //不允许使用未赋值的局部变量
            }
        }
    }
}
