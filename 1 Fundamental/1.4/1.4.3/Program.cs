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
            Form2 linear = new Form2();
            linear.Show();
            Rectangle rect = linear.ClientRectangle;
            int unitY = rect.Height / 10;
            int unitX = rect.Width / 10;
            Rectangle center = new Rectangle(rect.X + unitX, rect.Y + unitY, unitX * 8, unitY * 8);
            Graphics canvas = linear.CreateGraphics();
            canvas.DrawLine(Pens.Black, center.X, center.Y, center.X, center.Y + center.Height);
            canvas.DrawLine(Pens.Black, center.X, center.Y + center.Height, center.X + center.Width, center.Y + center.Height);


        }
    }
}
