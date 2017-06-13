using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._2._1
{
    /*
     * 1.2.1
     * 
     * 编写一个 Point2D 的用例，从命令行接受一个整数 N。
     * 在单位正方形中生成 N 个随机点，然后计算两点之间的最近距离。
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

        /// <summary>
        /// 主绘图函数
        /// </summary>
        /// <param name="N">点数 N</param>
        public static void StartDrawing(int N)
        {
            Form2 DrawPad = new Form2();
            DrawPad.Show();

            Graphics graphics = DrawPad.CreateGraphics();

            //建立随机点数组
            List<Point2D> allPoints = new List<Point2D>();
            Random random = new Random();
            //生成随机点
            for (int i = 0; i < N; ++i)
            {
                double x = random.NextDouble() * (DrawPad.Width - 10) + 5;
                double y = random.NextDouble() * (DrawPad.Height - 10) + 5;
                Point2D temp = new Point2D(x, y);
                allPoints.Add(temp);
            }

            //找到距离最近的两个点
            double minDist = allPoints[0].DistTo(allPoints[1]);
            int tempi = 0;
            int tempj = 0;
            for (int i = 0; i < allPoints.Count; ++i)
            {
                allPoints[i].Draw(graphics);
                //和其余点比较距离，并与最小距离比较
                for (int j = i + 1; j < allPoints.Count; ++j)
                {
                    if (allPoints[i].DistTo(allPoints[j]) < minDist)
                    {
                        tempi = i;
                        tempj = j;
                        minDist = allPoints[i].DistTo(allPoints[j]);
                    }
                }
            }

            //绘制最小两个点之间的线
            Pen newpen = new Pen(Brushes.Red, 3);
            graphics.DrawLine(newpen, allPoints[tempi].GetPoint(), allPoints[tempj].GetPoint());

            //释放资源
            newpen.Dispose();
            graphics.Dispose();
        }
    }
}
