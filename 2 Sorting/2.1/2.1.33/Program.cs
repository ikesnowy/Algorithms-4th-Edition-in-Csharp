using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._1._33
{
    /*
     * 2.1.33
     * 
     * 分布图。
     * 对于你为练习 2.1.33 给出的测试用例，
     * 在一个无穷循环中调用 sort() 方法将由第三个命令行参数指定大小的数组排序，
     * 记录每次排序的用时并使用 StdDraw 在图上画出所有平均运行时间，
     * 应该能够得到一张运行时间的分布图。
     * 
     */
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
