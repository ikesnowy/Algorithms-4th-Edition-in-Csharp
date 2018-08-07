using System;
using System.Windows.Forms;

namespace _2._3._31
{
    /*
     * 2.3.31
     * 
     * 运行时间直方图。
     * 编写一个程序，接受命令行参数 N 和 T，
     * 用快速排序对大小为 N 的随机浮点数数组进行 T 次排序，
     * 并将所有运行时间绘制成直方图。
     * 令 N=10^3、10^4、10^5 和 10^6，
     * 为了使曲线更平滑，T 值越大越好。
     * 这个练习最关键的地方在于找到适当的比例绘制出实验结果。
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
