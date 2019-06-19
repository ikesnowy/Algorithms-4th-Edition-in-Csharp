using System;
using System.Windows.Forms;

namespace _2._3._25
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var panel = new Form2((int)this.numericUpDown1.Value);
            panel.ShowDialog();
        }
    }
}
