using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._11._2019
{
    
    public partial class Form1 : Form
    {
        DrawableType drawableTypeSelected;
        List<baseF> listF;
        Point saveMouseCoord;
        public Form1()
        {
            listF = new List<baseF>();
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.MouseDown += MouseClick_;
            this.MouseUp += MouseUp_;
            
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PrintFigures(e.Graphics);
        }

        private void PrintFigures(Graphics g)
        {
            foreach (var i in listF)
            {
                i.Draw(g);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            drawableTypeSelected = DrawableType.Point;
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            drawableTypeSelected = DrawableType.Rect;
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            drawableTypeSelected = DrawableType.Ellipse;
        }
        private void MouseUp_(object sender, MouseEventArgs e)
        {
            switch (drawableTypeSelected)
            {
                case DrawableType.Point:
                    listF.Add(new PointF(e.Location, (int)numericUpDown1.Value));
                    break;
                case DrawableType.Rect:
                    if (saveMouseCoord.X < e.Location.X || saveMouseCoord.Y < e.Location.Y)
                        listF.Add(new RectangleF(new Rectangle(saveMouseCoord.X, saveMouseCoord.Y, e.Location.X-saveMouseCoord.X , e.Location.Y - saveMouseCoord.Y), (int)numericUpDown1.Value));
                    else
                        listF.Add(new RectangleF(new Rectangle(e.Location.X, e.Location.Y, saveMouseCoord.X - e.Location.X, saveMouseCoord.Y - e.Location.Y), (int)numericUpDown1.Value));
                    break;
                case DrawableType.Ellipse:
                    listF.Add(new EllipseF(new Rectangle(saveMouseCoord.X,saveMouseCoord.Y, e.Location.X- saveMouseCoord.X , e.Location.Y- saveMouseCoord.Y), (int)numericUpDown1.Value));
                    break;
            }
            Invalidate();
        }
        private void MouseClick_(object sender, MouseEventArgs e)
        {
            saveMouseCoord = e.Location;
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
