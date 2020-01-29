using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _3._2._47
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void Draw(Dictionary<int, double> data)
        {
            var panel = CreateGraphics();
            var unitX = (float)ClientRectangle.Width / data.Count;
            var unitY = (float)(ClientRectangle.Height / (1.39 * Math.Log2(data.Keys.Max()) - 1.85));

            for (var i = data.Keys.Min(); i < data.Keys.Max(); i++)
            {
                var formula = 1.39 * Math.Log2(i) - 1.85;  // f = float
                // Gray
                panel.FillEllipse(Brushes.Gray, (i + 1) * unitX, ClientRectangle.Bottom - (float)data[i] * unitY, 2, 2);
                // Red
                panel.FillEllipse(Brushes.Red, (i + 1) * unitX, ClientRectangle.Bottom - (float)formula * unitY, 2, 2);
            }
        }
    }
}
