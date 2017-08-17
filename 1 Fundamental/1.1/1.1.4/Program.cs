namespace _1._1._4
{
    /*
     * 1.1.4
     * 
     * 下列语句各有什么问题（如果有的话）？
     * a. if (a > b) then c = 0;
     * b. if a > b { c = 0; }
     * c. if (a > b) c = 0;
     * d. if (a > b) c = 0 else b = 0;
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            int c = 0;

            // f (a > b) then c = 0; 
            // f 后不能跟 then

            // f a > b { c = 0; } 
            // f后必须跟括号

            if (a > b) c = 0;
            // 确

            // f (a > b) c = 0 else b = 0; 
            //  = 0后缺少分号

        }
    }
}
