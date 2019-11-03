using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03._11._2019
{
    public partial class Form1 : Form
    {
        bool isEnabled1 = false;
        bool isEnabled2 = false;
        bool isEnabled3 = false;
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            foreach (var i in groupBox1.Controls)
            {
                ((RadioButton)i).Click += Changed;
            }
            foreach (var i in groupBox2.Controls)
            {
                ((RadioButton)i).Click += Changed;
            }
            foreach (var i in groupBox3.Controls)
            {
                ((RadioButton)i).Click += Changed;
            }
        }

        private void Changed(object sender, EventArgs e)
        {
            foreach (var i in groupBox1.Controls)
            {
                if (((RadioButton)i).Checked)
                {
                    isEnabled1 = true;
                    break;
                }
                else
                    isEnabled1 = false;
            }
            foreach (var i in groupBox2.Controls)
            {
                if (((RadioButton)i).Checked)
                {
                    isEnabled2 = true;
                    break;
                }
                else
                    isEnabled2 = false;
            }
            foreach (var i in groupBox3.Controls)
            {
                if (((RadioButton)i).Checked)
                {
                    isEnabled3 = true;
                    break;
                }
                else
                    isEnabled3 = false;
            }
            button1.Enabled = (isEnabled1 && isEnabled2 && isEnabled3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int AllPrice = 0;
            foreach (var i in groupBox1.Controls)
            {
                if (((RadioButton)i).Checked)
                {
                    AllPrice += int.Parse(((RadioButton)i).Text.ToString()[((RadioButton)i).Text.Length - 1].ToString());
                    break;
                }
            }
            foreach (var i in groupBox2.Controls)
            {
                if (((RadioButton)i).Checked)
                {
                    AllPrice += int.Parse(((RadioButton)i).Text.ToString()[((RadioButton)i).Text.Length - 1].ToString());
                    break;
                }
            }
            foreach (var i in groupBox3.Controls)
            {
                if (((RadioButton)i).Checked)
                {
                    AllPrice += int.Parse(((RadioButton)i).Text.ToString()[((RadioButton)i).Text.Length - 1].ToString());
                    break;
                }
            }
            MessageBox.Show("All Price = "+AllPrice);
        }
    }
}
