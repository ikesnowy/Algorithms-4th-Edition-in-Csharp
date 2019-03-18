using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _3._1._38
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        public void Draw(int[] data)
        {
            Graphics panel = this.CreateGraphics();
            float unitX = (float)this.ClientRectangle.Width / data.Length;
            float unitY = (float)this.ClientRectangle.Height / data.Max();

            int accumulation = 0;
            for (int i = 0; i < data.Length; i++)
            {
                // Gray
                panel.FillEllipse(Brushes.Gray, (i + 1) * unitX, this.ClientRectangle.Bottom - data[i] * unitY, 2, 2);
                // Red
                panel.FillEllipse(Brushes.Red, (i + 1) * unitX, this.ClientRectangle.Bottom - accumulation / (i + 1) * unitY, 2, 2);
                accumulation += data[i];
            }
        }
    }
}
