using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SortApplication;

namespace _2._5._26
{
    public partial class Form2 : Form
    {
        Graphics panel;
        List<Point2D> points;
        Point2D startPoint;

        double maxX = 0, maxY = 0;

        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示并初始化绘图窗口。
        /// </summary>
        public void Init()
        {
            Show();
            panel = CreateGraphics();
            points = new List<Point2D>();
            startPoint = null;
        }

        /// <summary>
        /// 向画板中添加一个点。
        /// </summary>
        /// <param name="point"></param>
        public void Add(Point2D point)
        {
            points.Add(point);
            if (startPoint == null)
            {
                startPoint = point;
                maxX = point.X * 1.1;
                maxY = point.Y * 1.1;
            }
            else if (startPoint.Y > point.Y)
                startPoint = point;
            else if (startPoint.Y == point.Y && startPoint.X > point.X)
                startPoint = point;

            if (point.X > maxX)
                maxX = point.X * 1.1;
            if (point.Y > maxY)
                maxY = point.Y * 1.1;

            points.Sort(startPoint.Polor_Order());
            RefreashPoints();
        }

        public void RefreashPoints()
        {
            var unitX = ClientRectangle.Width / maxX;
            var unitY = ClientRectangle.Height / maxY;
            double left = ClientRectangle.Left;
            double bottom = ClientRectangle.Bottom;

            panel.Clear(BackColor);
            var line = (Pen)Pens.Red.Clone();
            line.Width = 6;
            var before = startPoint;
            foreach (var p in points)
            {
                panel.FillEllipse(Brushes.Black, 
                    (float)(left + p.X * unitX - 5.0), 
                    (float)(bottom - p.Y * unitY - 5.0), 
                    (float)10.0, 
                    (float)10.0);
                panel.DrawLine(line,
                    (float)(left + before.X * unitX),
                    (float)(bottom - before.Y * unitY),
                    (float)(left + p.X * unitX),
                    (float)(bottom - p.Y * unitY));
                before = p;
            }
            panel.DrawLine(line,
                    (float)(left + before.X * unitX),
                    (float)(bottom - before.Y * unitY),
                    (float)(left + startPoint.X * unitX),
                    (float)(bottom - startPoint.Y * unitY));
        }
    }
}
