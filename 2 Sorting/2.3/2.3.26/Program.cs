using System;
using System.Windows.Forms;

namespace _2._3._26
{
    /*
     * 2.3.26
     * 
     * 子数组的大小。
     * 编写一个程序，在快速排序处理大小为 N 的数组的过程中，
     * 当子数组的大小小于 M 时，排序方法需要切换为插入排序。
     * 将子数组的大小绘制成直方图。
     * 用 N=10^5，M=10、20 和 50 测试你的程序。
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
