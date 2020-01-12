using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _3._2._45
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void Draw(int[] x, long[] y)
        {
            var panel = CreateGraphics();

            var unitX = (float)ClientRectangle.Width / x.Max();
            var unitY = (float)ClientRectangle.Height / y.Max();

            for (var i = 0; i < x.Length; i++)
            {
                panel.FillEllipse(
                    Brushes.Black,
                    x[i] * unitX,
                    ClientRectangle.Height - y[i] * unitY,
                    2, 2);
            }
        }
    }
}
