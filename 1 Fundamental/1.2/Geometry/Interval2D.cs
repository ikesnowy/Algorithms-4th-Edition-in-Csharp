using System.Drawing;

namespace Geometry
{
    /// <summary>
    /// 二维闭合区间。
    /// </summary>
    public class Interval2D
    {
        private readonly Interval1D X;
        private readonly Interval1D Y;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="x">x 轴上的范围。</param>
        /// <param name="y">y 轴上的范围。</param>
        public Interval2D(Interval1D x, Interval1D y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// 判断两个平面是否相交。
        /// </summary>
        /// <param name="that">需要判断的另一个平面。</param>
        /// <returns>相交则返回 true，不然返回 false。</returns>
        public bool Intersects(Interval2D that)
        {
            if (!this.X.Intersect(that.X))
            {
                return false;
            }

            if (!this.Y.Intersect(that.Y))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 判断目标区间是否被本区间包含。
        /// </summary>
        /// <param name="that">需要判断是否被包含的区间。</param>
        /// <returns>包含则返回 true，不然则返回 false。</returns>
        public bool Contains(Interval2D that)
        {
            return this.X.Contains(that.X) && this.Y.Contains(that.Y);
        }

        /// <summary>
        /// 判断一个二维点是否在该平面范围内。
        /// </summary>
        /// <param name="p">需要判断的二维点。</param>
        /// <returns>包含则返回 true，不然返回 false。</returns>
        public bool Contains(Point2D p)
        {
            return (this.X.Contains(p.X) && this.Y.Contains(p.Y));
        }

        /// <summary>
        /// 计算平面范围的面积。
        /// </summary>
        /// <returns>返回平面的面积。</returns>
        public double Area()
        {
            return this.X.Length() * this.Y.Length();
        }

        /// <summary>
        /// 在画布上绘制二维区间。
        /// </summary>
        /// <param name="g">原点在左下方，x轴向右，y轴向上的画布。</param>
        public void Draw(Graphics g)
        {
            Rectangle rect = new Rectangle((int)this.X.Min, (int)this.Y.Min, (int)this.X.Length(), (int)this.Y.Length());
            g.DrawRectangle(Pens.White, rect);
            g.FillRectangle(Brushes.Black, rect);
        }

        /// <summary>
        /// 返回形如“[xmin, xmax] x [ymin, ymax]”的字符串。
        /// </summary>
        /// <returns>返回形如“[xmin, xmax] x [ymin, ymax]”的字符串。</returns>
        public override string ToString()
        {
            return this.X + "x" + this.Y;
        }

        /// <summary>
        /// 判断两个二维区间是否相等。
        /// </summary>
        /// <param name="obj">需要比较的另一个区间。</param>
        /// <returns>相等则返回 true，不然返回 false。</returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj  == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            Interval2D that = (Interval2D)obj;

            return this.X.Equals(that.X) && this.Y.Equals(that.Y);
        }

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <returns>返回哈希值。</returns>
        public override int GetHashCode()
        {
            int hash1 = this.X.GetHashCode();
            int hash2 = this.Y.GetHashCode();

            return 31 * hash1 + hash2;
        }
    }
}
