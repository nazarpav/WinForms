using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23._10._2019
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = (dateTimePicker1.Value.Year-DateTime.Now.Year).ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = ((dateTimePicker1.Value.Year*12+ dateTimePicker1.Value.Month) - (DateTime.Now.Year * 12+DateTime.Now.Month)).ToString();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = ((dateTimePicker1.Value.Year * 365 + dateTimePicker1.Value.Month*30+ dateTimePicker1.Value.Day) - (DateTime.Now.Year * 365 + DateTime.Now.Month * 30 + DateTime.Now.Day)).ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = ((dateTimePicker1.Value.Year * 365*24 + dateTimePicker1.Value.Month * 30*24 + dateTimePicker1.Value.Day*24) - (DateTime.Now.Year * 365*24 + DateTime.Now.Month * 30*24 + DateTime.Now.Day*24)).ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
