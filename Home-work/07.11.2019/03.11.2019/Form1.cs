﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        BinaryFormatter binFormat = new BinaryFormatter();
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
            string buf = "";
            foreach (var i in groupBox1.Controls)
            {
                if (((RadioButton)i).Checked)
                {
                    AllPrice += int.Parse(((RadioButton)i).Text.ToString()[((RadioButton)i).Text.Length - 1].ToString());
                    buf += ((RadioButton)i).Text+ "|";
                    break;
                }
            }
            foreach (var i in groupBox2.Controls)
            {
                if (((RadioButton)i).Checked)
                {
                    AllPrice += int.Parse(((RadioButton)i).Text.ToString()[((RadioButton)i).Text.Length - 1].ToString());
                    buf += ((RadioButton)i).Text + "|";
                    break;
                }
            }
            foreach (var i in groupBox3.Controls)
            {
                if (((RadioButton)i).Checked)
                {
                    AllPrice += int.Parse(((RadioButton)i).Text.ToString()[((RadioButton)i).Text.Length - 1].ToString());
                    buf += ((RadioButton)i).Text;
                    break;
                }
            }
            MessageBox.Show("All Price = "+AllPrice);
            listBox1.Items.Add(buf+"\n Price => "+ AllPrice+"\n Time => "+DateTime.Now);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (var i in listBox1.Items)
            {
                list.Add(i.ToString());
            }
            using (Stream fStream = File.Create("test.bin"))
            {
                binFormat.Serialize(fStream, list);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            using (Stream fStream = File.OpenRead("test.bin"))
            {
                list = (List<string>)binFormat.Deserialize(fStream);
            }
            foreach (var i in list)
            {
                listBox1.Items.Add(i);
            }

        }
    }
}
