using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _29._10._2019
{
    public partial class Form1 : Form
    {
        List<int> ListNum;
        int indexEquals=0;
        const int QuantityElementSheet = 42;
        Random rnd;
        int maxDigitInSheet = 42;
        bool isGame = false;
        public Form1()
        {
            rnd = new Random();
            InitializeComponent();
            foreach (var i in groupBox1.Controls)
            {
                ((Label)i).Click += Label_Click;
            }
            this.BackColor = Color.FromArgb(255,255,0,0);
            button1.BackColor = Color.FromArgb(255, 0, 0, 255);
            //progressBar1.ForeColor = Color.FromArgb(255, 0, 128, 128);
        }
        void Count(object obj)
        {
            progressBar1.Value++;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                isGame = false;
                label48.Text = "GameOver";
            }
            if (indexEquals == QuantityElementSheet)
            {
                isGame = false;
                label48.Text = "Win";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            isGame = true;
            progressBar1.Value = 0;
            label48.Text = "";
            switch (trackBar1.Value)
            {
                case 0:
                    progressBar1.Maximum = 50000;
                    break;
                case 1:
                    progressBar1.Maximum = 25000;

                    break;
                case 2:
                    progressBar1.Maximum = 10000;

                    break;
                default:
                    break;
            }
            int num = 0;
            TimerCallback tm = new TimerCallback(Count);
            System.Threading.Timer timer = new System.Threading.Timer(tm, num, 0, 1);
            indexEquals = 0;
            foreach (var i in groupBox1.Controls)
            {
                ((Label)i).BackColor =Color.Yellow;
            }
            ListNum = new List<int>();
            int randomNum = 0;
            for (int i = 0; i < maxDigitInSheet; i++)
            {
                randomNum = rnd.Next(0, maxDigitInSheet);
                foreach (var g in ListNum)
                {
                    if (g == randomNum)
                    {
                        randomNum = rnd.Next(0, maxDigitInSheet);
                    }
                }
                ListNum.Add(randomNum);
            }
            int j = 0;
            foreach (var i in groupBox1.Controls)
            {
                ((Label)i).Text = ListNum[j++].ToString();
            }
            ListNum.Sort();
        }
        private void Label_Click(object sender, EventArgs e)
        {
            if (!isGame) return;
            int num = int.Parse(((Label)sender).Text);
            if (num == ListNum[indexEquals])
            {
                indexEquals++;
                ((Label)sender).BackColor = Color.Green;
                label43.Text = indexEquals.ToString();
            }
            else
            {
                ((Label)sender).BackColor = Color.Red;
            }
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
