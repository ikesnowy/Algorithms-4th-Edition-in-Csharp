using System;
using System.Windows.Forms;

namespace _2._1._18
{
    /*
     * 2.1.18
     * 
     * 可视轨迹。修改你为上一题给出的解答，
     * 为插入排序和选择排序生成和正文中类似的可视轨迹。
     * 提示：使用 setYscale() 函数是一个明智的选择。
     * 附加题：添加必要的代码，
     * 与正文中的图片一样用红色和灰色强调不同角色的元素。
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
