using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14._11._2019AddCourse
{
    public partial class Form1 : Form
    {
        uint time = 0;
        List<string> text;
        int count=0;
        int countAlpha=0;
        char key;
        int countError = 0;
        public Form1()
        {
            InitializeComponent();
            KeyPress += KeyPress_;
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            textBox1.Enabled = false;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ++time;
            toolStripStatusLabel2.Text = time.ToString();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            count = 0;
            timer1.Stop();
            time = 0;
            textBox1.Text = String.Empty;
            MessageBox.Show("GO GO GO!!1");
            StreamReader reader = File.OpenText("text.txt");
            text = reader.ReadToEnd().Split('.').ToList();
            toolStripStatusLabel2.Text = "0";
            toolStripStatusLabel5.Text = "0";
            label2.Text = text[count];
            timer1.Start();
            textBox1.Enabled = true;
        }

        private void KeyPress_(object sender, KeyPressEventArgs e)
        {
            key = e.KeyChar;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(count==text.Count-1|| textBox1.Enabled == false)
            {
                MessageBox.Show("Time = "+time+"Mistakes = "+countError);
                toolStripStatusLabel2.Text = String.Empty;
                toolStripStatusLabel5.Text = String.Empty;
                textBox1.Clear();
                timer1.Stop();
                textBox1.Enabled = false;
                return;
            }
            if(textBox1.Text == label2.Text)
            {
                label2.Text = text[++count];
                textBox1.Clear();
            }
            if (textBox1.Enabled && label2.Text.Remove(textBox1.Text.Length) == textBox1.Text)
            {
                label2.BackColor = Color.Turquoise;
            }
            else if(label2.BackColor != Color.Red)
            {
                label2.BackColor = Color.Red;
                toolStripStatusLabel5.Text= countError.ToString();
                ++countError;
            }
            if (key == 8)
            {
                if (countAlpha != toolStripProgressBar1.Maximum && countAlpha != toolStripProgressBar1.Minimum)
                    countAlpha--;
                toolStripProgressBar1.Value = countAlpha;
            } 
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
        }

    }
}
