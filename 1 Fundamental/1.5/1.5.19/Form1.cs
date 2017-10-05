using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._5._19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int N = int.Parse(this.InputN.Text);
                Log log = new Log(N);
                log.Show();
            }
            catch (ArgumentNullException)
            {
                this.ErrorLabel.Text = "输入值不能为空。";
            }
            catch (FormatException)
            {
                this.ErrorLabel.Text = "格式错误（是否输入了空值？）";
            }
            catch (OverflowException)
            {
                this.ErrorLabel.Text = "数据过大";
            }
        }
    }
}
