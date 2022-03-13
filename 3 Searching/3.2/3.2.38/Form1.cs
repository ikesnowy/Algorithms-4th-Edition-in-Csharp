using System;
using System.Drawing;
using System.Windows.Forms;

namespace _3._2._38;

public partial class Form1 : Form
{
    private Form2 _drawPad;

    public Form1()
    {
        InitializeComponent();
    }

    /// <inheritdoc />
    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        _drawPad = new Form2
        {
            StartPosition = FormStartPosition.Manual,
            Location = new Point {X = Location.X - 800, Y = Location.Y}
        };
        _drawPad.Show();
    }

    private void AddNode_Click(object sender, EventArgs e)
    {
        _drawPad.AddNode(int.Parse(textBox1.Text));
    }

    private void DeleteNode_Click(object sender, EventArgs e)
    {
        _drawPad.DeleteNode(int.Parse(textBox2.Text));
    }
}