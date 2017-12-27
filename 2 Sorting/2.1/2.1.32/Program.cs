using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._1._32
{
    /*
     * 2.1.32
     * 
     * 运行时间曲线图。编写一个测试用例，
     * 使用 StdDraw 在各种不同规模的随机输入下将算法的平均运行时间绘制成一张曲线图。
     * 可能需要添加一两个命令行参数，
     * 请尽量设计一个实用的工具。
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
