using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _31._10._2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("We did not doubt that you think so!");
        }

        private void button2_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            Random r = new Random();
            button2.Left = r.Next(0, this.Size.Width - button1.Width);
            button2.Top = r.Next(0, this.Size.Height - button1.Height);
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ups");
        }
    }
}
