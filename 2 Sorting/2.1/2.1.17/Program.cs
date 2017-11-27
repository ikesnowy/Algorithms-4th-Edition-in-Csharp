using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _2._1._17
{
    /*
     * 2.1.17
     * 
     * 动画。修改插入排序和选择排序的代码，
     * 使之将数组内容绘制成正文中所示的棒状图。
     * 在每一轮排序后重绘图片来产生动画效果，
     * 并以一张“有序”的图片作为结束，
     * 即所有的圆棒均已按照高度有序排列。
     * 提示：使用类似于正文中的用例来随机生成 Double 值，
     * 在排序代码的适当位置调用 show() 方法，
     * 并在 show() 方法中清理画布并绘制棒状图。
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
