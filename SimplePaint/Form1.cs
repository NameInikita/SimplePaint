using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class Form1 : Form
    {
        Color CurrentColor = Color.Black;
        bool isPressed = false;
        Point CurrentPoint, PrevPoint;
        Graphics g;
        Rectangle rect = new Rectangle(50, 50, 100, 100);
        Rectangle ellips = new Rectangle(150, 50, 200, 100);

        Pen pen = new Pen(Color.Red);

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = colorDialog1.ShowDialog();//coclorDialog не виден на форме
            if (d == DialogResult.OK)
                CurrentColor = colorDialog1.Color;//кладем цвет в CurrentColor
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                for_paint();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            CurrentPoint = e.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.DrawRectangle(pen,rect);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.DrawEllipse(pen, ellips);
        }

        private void for_paint()
        {
            Pen p = new Pen(CurrentColor);
            g.DrawLine(p, PrevPoint, CurrentPoint);
        }
    }
}
