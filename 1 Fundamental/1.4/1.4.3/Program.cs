using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _1._4._3
{
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

        public static void PaintLinear()
        {
            //新建一个绘图窗口
            Form2 linear = new Form2();
            linear.Show();
            //新建画布
            Graphics canvas = linear.CreateGraphics();
            //获取窗口区域
            Rectangle rect = linear.ClientRectangle;
            //计算单位长度（十等分）
            int unitY = rect.Height / 10;
            int unitX = rect.Width / 10;
            //获取中心区域（上下左右增加 10% 的内补）
            Rectangle center = new Rectangle(rect.X + unitX, rect.Y + unitY, unitX * 8, unitY * 8);
            //绘制坐标系
            canvas.DrawLine(Pens.Black, center.X, center.Y, center.X, center.Y + center.Height);
            canvas.DrawLine(Pens.Black, center.X, center.Y + center.Height, center.X + center.Width, center.Y + center.Height);
            canvas.DrawString("N", linear.Font, Brushes.Black, center.X, center.Y + center.Height);

        }
    }
}
