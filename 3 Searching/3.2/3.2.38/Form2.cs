using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._2._38
{
    public partial class Form2 : Form
    {
        private readonly BSTDrawing<int, int> _bst = new BSTDrawing<int,int>();

        public Form2()
        {
            InitializeComponent();
        }

        public bool AddNode(int key)
        {
            try
            {
                _bst.Put(key, key);
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                RefreshPanel();
            }

            return true;
        }

        public bool DeleteNode(int key)
        {
            try
            {
                _bst.Delete(key);
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                RefreshPanel();
            }

            return true;
        }

        public void RefreshPanel()
        {
            var pen = CreateGraphics();
            pen.Clear(BackColor);
            _bst.DrawTree(pen, ClientRectangle);
            pen.Dispose();
        }
    }
}
