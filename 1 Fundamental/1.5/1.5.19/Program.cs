using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._5._19
{
    /*
     * 1.5.19
     * 
     * 动画。
     * 编写一个 RandomGrid（请见练习 1.5.18）的用例，
     * 和我们开发用例一样使用 UnionFind 来检查触点的连通性并在处理时用 StdDraw 将它们绘出。
     * 
     */
    static class Program
    {
        static RandomBag<Connection> bag;
        static Graphics graphics;
        static TextBox logBox;
        static PointF[] points;
        static Timer timer;
        static List<Connection> connections;
        static int count = 0;

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
        /// 绘制连接图像。
        /// </summary>
        /// <param name="n">矩阵边长。</param>
        public static void Draw(int n, TextBox log, Log WinBox)
        {
            logBox = log;

            // 生成路径。
            log.AppendText("\r\n开始生成连接……");
            bag = Generate(n);
            log.AppendText("\r\n生成连接完成");

            // 新建画布窗口。
            log.AppendText("\r\n启动画布……");
            Form2 matrix = new Form2();
            matrix.StartPosition = FormStartPosition.Manual;
            matrix.Location = new Point(WinBox.Left - matrix.ClientRectangle.Width, WinBox.Top);
            matrix.Show();
            log.AppendText("\r\n画布已启动，开始绘图……");
            graphics = matrix.CreateGraphics();

            // 获取绘图区域。
            RectangleF rect = matrix.ClientRectangle;
            float unitX = rect.Width / (n + 1);
            float unitY = rect.Height / (n + 1);

            // 绘制点。
            log.AppendText("\r\n绘制点……");
            points = new PointF[n * n];
            for (int row = 0; row < n; ++row)
            {
                for (int col = 0; col < n; ++col)
                {
                    points[row * n + col] = new PointF(unitX * (col + 1), unitY * (row + 1));
                    graphics.FillEllipse(Brushes.Black, unitX * (col + 1), unitY * (row + 1), 5, 5);
                }
            }
            log.AppendText("\r\n绘制点完成");

            // 绘制连接。
            log.AppendText("\r\n开始绘制连接……");
            connections = new List<Connection>();
            foreach (Connection c in bag)
            {
                connections.Add(c);
            }
            timer = new Timer
            {
                Interval = 500
            };
            timer.Tick += DrawOneLine;
            timer.Start();              
        }

        private static void DrawOneLine(object sender, EventArgs e)
        {
            Connection c = connections[count];
            count++;
            graphics.DrawLine(Pens.Black, points[c.GetP()], points[c.GetQ()]);
            logBox.AppendText("\r\n绘制" + "(" + c.GetP() + ", " + c.GetQ() + ")");
            if (count == bag.Size())
            {
                timer.Stop();
                logBox.AppendText("\r\n绘制结束");
                count = 0;
            }
        }

        /// <summary>
        /// 表示一条连接。
        /// </summary>
        private class Connection
        {
            int p;  // 起点
            int q;  // 终点

            /// <summary>
            /// 新建一条连接。
            /// </summary>
            /// <param name="p">连接起点。</param>
            /// <param name="q">连接终点。</param>
            public Connection(int p, int q)
            {
                this.p = p;
                this.q = q;
            }

            /// <summary>
            /// 获得起点 p。
            /// </summary>
            /// <returns>起点 p。</returns>
            public int GetP()
            {
                return this.p;
            }

            /// <summary>
            /// 获得终点 q。
            /// </summary>
            /// <returns>终点 q。</returns>
            public int GetQ()
            {
                return this.q;
            }

            /// <summary>
            /// 获得散列（哈希）值。
            /// </summary>
            /// <returns>散列（哈希）值。</returns>
            public override int GetHashCode()
            {
                return 31 * this.p + this.q;
            }
        }

        /// <summary>
        /// 随机生成 n × n 网格中的所有连接。
        /// </summary>
        /// <param name="n">网格边长。</param>
        /// <returns>随机排序的连接。</returns>
        static RandomBag<Connection> Generate(int n)
        {
            var result = new RandomBag<Connection>();
            var random = new Random();

            // 建立横向连接
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n - 1; ++j)
                {
                    if (random.Next(10) > 4)
                    {
                        result.Add(new Connection(i * n + j, (i * n) + j + 1));
                    }
                    else
                    {
                        result.Add(new Connection((i * n) + j + 1, i * n + j));
                    }
                }
            }


            // 建立纵向连接
            for (int j = 0; j < n; ++j)
            {
                for (int i = 0; i < n - 1; ++i)
                {
                    if (random.Next(10) > 4)
                    {
                        result.Add(new Connection(i * n + j, ((i + 1) * n) + j));
                    }
                    else
                    {
                        result.Add(new Connection(((i + 1) * n) + j, i * n + j));
                    }
                }
            }

            return result;
        }
    }
}
