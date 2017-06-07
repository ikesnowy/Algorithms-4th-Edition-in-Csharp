using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._1._32
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //新建一个文件选取窗口
            OpenFileDialog openfiledialog = new OpenFileDialog();
            //设置要读取的文件类型
            openfiledialog.Filter = "文本文档(*.txt)|*.txt";
            //设置初始位置为“我的文档”
            openfiledialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if(openfiledialog.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
