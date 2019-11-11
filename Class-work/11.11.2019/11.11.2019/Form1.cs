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
    enum DrawableType
    {
        Point=0,
        Rect,
        FillRect,
        Ellipse
    }
    public partial class Form1 : Form
    {
        DrawableType drawableTypeSelected;
        List<Point> listPoint;
        List<Rectangle> listRect;
        List<Rectangle> listFillRect;
        List<Rectangle> listEllipseRect;
        Point saveMouseCoord;
        public Form1()
        {
            listPoint = new List<Point>();
            listRect = new List<Rectangle>();
            listFillRect = new List<Rectangle>();
            listEllipseRect = new List<Rectangle>();
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

            foreach (var i in listPoint)
            {
                g.FillEllipse(Brushes.Black, i.X, i.Y, (float)numericUpDown1.Value, (float)numericUpDown1.Value);
            }
            foreach (var i in listRect)
            {
                g.DrawRectangle(new Pen(Brushes.Black, (float)numericUpDown1.Value),new Rectangle(i.X, i.Y, i.Width, i.Height));
            }
            foreach (var i in listFillRect)
            {
                g.FillRectangle(Brushes.Black, i.X, i.Y, i.Width, i.Height);
            }
            foreach (var i in listEllipseRect)
            {
                g.FillEllipse(Brushes.Black, i.X, i.Y, i.Width, i.Height);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            drawableTypeSelected = DrawableType.Point;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            drawableTypeSelected = DrawableType.FillRect;
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
                    listPoint.Add(saveMouseCoord);
                    break;
                case DrawableType.Rect:
                    if (saveMouseCoord.X < e.Location.X || saveMouseCoord.Y < e.Location.Y)
                        listRect.Add(new Rectangle(saveMouseCoord.X, saveMouseCoord.Y, e.Location.X - saveMouseCoord.X, e.Location.Y - saveMouseCoord.Y));
                    else
                        listRect.Add(new Rectangle(e.Location.X, e.Location.Y, saveMouseCoord.X - e.Location.X, saveMouseCoord.Y - e.Location.Y));
                    break;
                case DrawableType.FillRect:
                    if(saveMouseCoord.X < e.Location.X||saveMouseCoord.Y< e.Location.Y)
                        listFillRect.Add(new Rectangle(saveMouseCoord.X,saveMouseCoord.Y, e.Location.X- saveMouseCoord.X , e.Location.Y- saveMouseCoord.Y));
                    else
                        listFillRect.Add(new Rectangle(e.Location.X, e.Location.Y, saveMouseCoord.X - e.Location.X, saveMouseCoord.Y - e.Location.Y));
                    break;
                case DrawableType.Ellipse:
                    listEllipseRect.Add(new Rectangle(saveMouseCoord.X,saveMouseCoord.Y, e.Location.X- saveMouseCoord.X , e.Location.Y- saveMouseCoord.Y));
                    break;
            }
            Invalidate();
        }
        private void MouseClick_(object sender, MouseEventArgs e)
        {
            saveMouseCoord = e.Location;
        }
    }
}
