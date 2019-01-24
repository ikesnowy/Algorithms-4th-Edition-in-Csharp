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
            this.panel = CreateGraphics();
            this.points = new List<Point2D>();
            this.startPoint = null;
        }

        /// <summary>
        /// 向画板中添加一个点。
        /// </summary>
        /// <param name="point"></param>
        public void Add(Point2D point)
        {
            this.points.Add(point);
            if (this.startPoint == null)
            {
                this.startPoint = point;
                this.maxX = point.X * 1.1;
                this.maxY = point.Y * 1.1;
            }
            else if (this.startPoint.Y > point.Y)
                this.startPoint = point;
            else if (this.startPoint.Y == point.Y && this.startPoint.X > point.X)
                this.startPoint = point;

            if (point.X > this.maxX)
                this.maxX = point.X * 1.1;
            if (point.Y > this.maxY)
                this.maxY = point.Y * 1.1;

            this.points.Sort(this.startPoint.Polor_Order());
            RefreashPoints();
        }

        public void RefreashPoints()
        {
            double unitX = this.ClientRectangle.Width / this.maxX;
            double unitY = this.ClientRectangle.Height / this.maxY;
            double left = this.ClientRectangle.Left;
            double bottom = this.ClientRectangle.Bottom;

            this.panel.Clear(this.BackColor);
            Pen line = (Pen)Pens.Red.Clone();
            line.Width = 6;
            Point2D before = this.startPoint;
            foreach (var p in this.points)
            {
                this.panel.FillEllipse(Brushes.Black, 
                    (float)(left + p.X * unitX - 5.0), 
                    (float)(bottom - p.Y * unitY - 5.0), 
                    (float)10.0, 
                    (float)10.0);
                this.panel.DrawLine(line,
                    (float)(left + before.X * unitX),
                    (float)(bottom - before.Y * unitY),
                    (float)(left + p.X * unitX),
                    (float)(bottom - p.Y * unitY));
                before = p;
            }
            this.panel.DrawLine(line,
                    (float)(left + before.X * unitX),
                    (float)(bottom - before.Y * unitY),
                    (float)(left + this.startPoint.X * unitX),
                    (float)(bottom - this.startPoint.Y * unitY));
        }
    }
}
