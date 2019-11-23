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
        Point sm;
        Color _selectedColorFigure = Color.Black;
        Color _selectedColorWrap= Color.Black;
        bool isClick = false;
        public Form1()
        {
            listF = new List<baseF>();
            InitializeComponent();
            this.Paint += Form1_Paint;
            this.MouseDown += MouseDown_;
            this.MouseUp += MouseUp_;
            this.MouseMove += MouseHover_;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
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
            isClick = false;

            switch (drawableTypeSelected)
            {
                case DrawableType.Point:
                    listF.Add(new PointF(e.Location,(int)numericUpDown1.Value, checkBox1.Checked ? (int)numericUpDown2.Value : 0, _selectedColorFigure, _selectedColorWrap));
                    break;
                case DrawableType.Image:
                    listF.Add(new ImageRect(new Rectangle(sm.X, sm.Y, e.Location.X - sm.X, e.Location.Y - sm.Y), new Bitmap(toolStripTextBox1.Text)));
                    break;
                case DrawableType.Rect:
                    if (sm.X > e.Location.X && sm.Y > e.Location.Y)
                        listF.Add(new RectangleF(new Rectangle(e.Location.X, e.Location.Y, sm.X - e.Location.X, sm.Y - e.Location.Y), checkBox1.Checked ? (int)numericUpDown1.Value : 0, _selectedColorFigure, _selectedColorWrap));
                    else if (sm.X > e.Location.X && sm.Y < e.Location.Y)
                        listF.Add(new RectangleF(new Rectangle(e.Location.X, sm.Y, sm.X - e.Location.X, e.Location.Y- sm.Y), checkBox1.Checked ? (int)numericUpDown1.Value : 0, _selectedColorFigure, _selectedColorWrap));
                    else if (sm.X < e.Location.X && sm.Y > e.Location.Y)
                        listF.Add(new RectangleF(new Rectangle(sm.X, e.Location.Y, e.Location.X - sm.X, sm.Y - e.Location.Y), checkBox1.Checked ? (int)numericUpDown1.Value : 0, _selectedColorFigure, _selectedColorWrap));
                    else
                        listF.Add(new RectangleF(new Rectangle(sm.X, sm.Y, e.Location.X - sm.X, e.Location.Y - sm.Y), checkBox1.Checked ? (int)numericUpDown1.Value : 0, _selectedColorFigure, _selectedColorWrap));
                    break;
                case DrawableType.Ellipse:
                    listF.Add(new EllipseF(new Rectangle(sm.X, sm.Y, e.Location.X - sm.X, e.Location.Y - sm.Y), checkBox1.Checked ? (int)numericUpDown1.Value : 0, _selectedColorFigure, _selectedColorWrap));
                    break;
                case DrawableType.Line:
                    listF.Add(new Line(new Point(sm.X, sm.Y), new Point(e.Location.X, e.Location.Y), (int)numericUpDown1.Value, checkBox1.Checked ? (int)numericUpDown2.Value : 0, _selectedColorFigure, _selectedColorWrap));
                    break;
            }
            Invalidate();
        }
        private void MouseDown_(object sender, MouseEventArgs e)
        {
            sm = e.Location;
            isClick = true;

        }
        private void MouseHover_(object sender, MouseEventArgs e)
        {
            if(isClick&&drawableTypeSelected==DrawableType.Point)
            {
                listF.Add(new PointF(e.Location, (int)numericUpDown1.Value, checkBox1.Checked ? (int)numericUpDown2.Value : 0, _selectedColorFigure, _selectedColorWrap));
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            drawableTypeSelected = DrawableType.Line;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedColorFigure = colorDialog.Color;
                toolStripButton5.BackColor = _selectedColorFigure;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.BackColor = checkBox1.Checked ? Color.Green : Color.Red;
            numericUpDown2.Enabled = checkBox1.Checked;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedColorWrap = colorDialog.Color;
                toolStripButton6.BackColor = _selectedColorWrap;
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if(listF.Count>0)
            {
                listF.RemoveAt(listF.Count-1);
                Invalidate();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Form2 form;
            var bmpTemp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            this.DrawToBitmap(bmpTemp, ClientRectangle);
            form = new Form2(ref bmpTemp);
            form.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            listF.Clear();
            Invalidate();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            drawableTypeSelected = DrawableType.Image;
        }
    }
}
