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
        int num = 0;
        uint time = 0;
        List<string> text;
        int count=0;
        int countAlpha=0;
        char key;
        int countError = 0;
        public void Count(object obj)
        {
            toolStripStatusLabel2.Text=(int.Parse(toolStripStatusLabel2.Text)+1).ToString();
        }
        public Form1()
        {
            InitializeComponent();
            TimerCallback tm = new TimerCallback(Count);
            System.Threading.Timer timer = new System.Threading.Timer(tm, num, 0, 1000);
            KeyPress += KeyPress_;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = File.OpenText("text.txt"))
            {
                text = reader.ReadToEnd().Split('.').ToList();
            }
            toolStripStatusLabel2.Text = "0";
            label2.Text = text[count++];
        }

        private void KeyPress_(object sender, KeyPressEventArgs e)
        {
            key = e.KeyChar;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripProgressBar1.Maximum = text[count].Length;
            if (textBox1.Text==label2.Text)
            {
                toolStripStatusLabel2.Text = "0";
                countAlpha = 0;
                textBox1.Text = "";
                toolStripProgressBar1.Value = countAlpha;
                label2.Text = text[count++];
            }
            if (key == 8)
            {
                if (countAlpha != toolStripProgressBar1.Maximum && countAlpha != toolStripProgressBar1.Minimum)
                    countAlpha--;
                toolStripProgressBar1.Value = countAlpha;
            }
            else
            {
                if (countAlpha != toolStripProgressBar1.Maximum && countAlpha != toolStripProgressBar1.Minimum)
                    countAlpha++;
                toolStripProgressBar1.Value = countAlpha;
            }
            //if(textBox1.Text[textBox1.Text.Length ] != label2.Text[textBox1.Text.Length-1]&& textBox1.Text[textBox1.Text.Length-1] >0&& label2.Text[textBox1.Text.Length-1] > 0)
            //{
            //    label2.BackColor = Color.Red;
            //    toolStripStatusLabel5.Text = (countError+1).ToString();
            //}
            //else
            //{
                label2.BackColor = Color.White;
            
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
        }
    }
}
