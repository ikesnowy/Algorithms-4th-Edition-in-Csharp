using System;
using System.Windows.Forms;

namespace _1._4._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] testResult = Program.Test();
            Program.PaintLinear(testResult);
            double[] testResultLog = new double[testResult.Length];
            for (int i = 0; i < testResult.Length; ++i)
            {
                testResultLog[i] = Math.Log10(testResult[i]);
            }
            Program.PaintLogarithm(testResultLog);
        }
    }
}
