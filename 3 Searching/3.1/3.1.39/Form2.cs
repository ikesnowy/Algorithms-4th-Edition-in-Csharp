using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _3._1._39
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void Draw(int[] x, long[] y)
        {
            Graphics panel = this.CreateGraphics();

            float unitX = (float)this.ClientRectangle.Width / x.Max();
            float unitY = (float)this.ClientRectangle.Height / y.Max();

            for (int i = 0; i < x.Length; i++)
            {
                panel.FillEllipse(
                    Brushes.Black,
                    x[i] * unitX,
                    this.ClientRectangle.Height - y[i] * unitY,
                    2, 2);
            }
        }
    }
}
