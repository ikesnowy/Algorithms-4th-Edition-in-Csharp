namespace _1._4._4
{
    /*
     * 1.4.4
     * 
     * 参照表 1.4.4 为 TwoSum 建立一张类似的表格。
     * 
     */
    class Program
    {
        public static int Count(int[] a)
        { //A                                                                               
            int n = a.Length;
            int count = 0;
            for (int i = 0; i < n; ++i)
            {//B
                for (int j = i + 1; j < n; ++j)
                {//C
                    if (a[i] + a[j] == 0)
                    {
                        count++;//D
                    }
                }
            }
            return count;
        }

        //语句块   单次执行时间    频率             总时间
        //  D        t0        x（输入相关）        xt0
        //  C        t1        N^2/2 - N/2         t1(N^2/2 - N/2)
        //  B        t2            N               t2N
        //  A        t3            1               t3
        //
        //总计
        //(N^2/2)t1
        //  + N(t2 - t1/2)
        //      + t3 + xt0
        //约为（当 x 很小时）
        //(N^2/2)t1
        //增长的数量级
        //N^2

        public static void Main(string[] args)
        {

        }
    }
}
