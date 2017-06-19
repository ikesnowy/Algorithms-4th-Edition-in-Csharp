using System;
using System.Windows.Forms;
using System.Drawing;
using Geometry;

namespace _1._2._3
{
    /*
     * 1.2.3
     * 
     * 编写一个 Interval2D 的用例，从命令行接受参数 N、min 和 max。
     * 生成 N 个随机的 2D 间隔，其宽和高均匀的分布在单位正方形中的 min 和 max 之间。
     * 用 StdDraw 画出它们并打印出相交的间隔对的数量以及有包含关系的间隔对数量。
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
        /// 主绘图函数。
        /// </summary>
        /// <param name="N">2D 间隔的数目。</param>
        /// <param name="Min">分布范围的下界。（大于 0 且小于 1）</param>
        /// <param name="Max">分布范围的上界。（大于 0 且小于 1）</param>
        public static void StartDrawing(int N, double Min, double Max)
        {
            Interval2D[] list = new Interval2D[N];
            Random random = new Random();

            //开始绘图
            Form2 drawPad = new Form2();
            drawPad.Show();
            Graphics graphics = drawPad.CreateGraphics();

            //生成随机二维间隔
            for (int i = 0; i < N; ++i)
            {
                double x = random.NextDouble() * (Max - Min) + Min;
                double y = random.NextDouble() * (Max - Min) + Min;
                if (x >= y)
                {
                    double temp = x;
                    x = y;
                    y = temp;
                }
                x *= drawPad.ClientRectangle.Width;
                y *= drawPad.ClientRectangle.Width;
                Interval1D tempx = new Interval1D(x, y);

                x = random.NextDouble() * (Max - Min) + Min;
                y = random.NextDouble() * (Max - Min) + Min;
                if (x >= y)
                {
                    double temp = x;
                    x = y;
                    y = temp;
                }
                x *= drawPad.ClientRectangle.Height;
                y *= drawPad.ClientRectangle.Height;
                Interval1D tempy = new Interval1D(x, y);

                list[i] = new Interval2D(tempx, tempy);
            }

            //计算相交和包含的数量
            int intersectNum = 0;
            for (int i = 0; i < N; ++i)
            {
                for (int j = i + 1; j < N; ++j)
                {
                    if (list[i].Intersects(list[j]))
                    {
                        intersectNum++;
                    }
                }
            }

            int containsNum = 0;
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    if (i == j)
                        continue;

                    if (list[i].Contains(list[j]))
                    {
                        containsNum++;
                    }
                }
            }

            //移动原点至左下方，翻转坐标系
            graphics.TranslateTransform(0, drawPad.ClientRectangle.Height);
            graphics.ScaleTransform(1, -1);

            //绘制所有区间
            foreach (Interval2D n in list)
            {
                n.Draw(graphics);
            }

            //新建一个窗口，显示计算结果
            MessageBox.Show($"相交的区间数：{intersectNum}, 包含的区间数：{containsNum}");
        }
    }
}
