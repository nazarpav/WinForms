using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13._11._2019
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<string> text;
        public Form1()
        {
            InitializeComponent();
            text = new List<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text = textBox1.Text.Split(' ').ToList();

            Graphics g = this.CreateGraphics();
            foreach (var i in text)
            {
                g.DrawString(i, new Font(FontFamily.Families[rnd.Next(0, FontFamily.Families.Length)], rnd.Next(5, 50)), new SolidBrush(Color.FromArgb(rnd.Next(0,256), rnd.Next(0, 256), rnd.Next(0, 256)) ), rnd.Next(this.Size.Width), rnd.Next(this.Size.Height));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
        }
    }
}
