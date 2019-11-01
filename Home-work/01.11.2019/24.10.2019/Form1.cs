using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24._10._2019
{
    public partial class Form1 : Form
    {

        Student student;
        public Form1()
        {
            InitializeComponent();
            student = new Student();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string buf = string.Empty;
            foreach (var i in checkedListBox1.CheckedItems)
            {
                buf += "\n"+i.ToString();
            }
            student.Name = textBox1.Text;
            student.Surname = textBox2.Text;
            student.ResidenceAddress = textBox3.Text;
            student.DateOfBirth = dateTimePicker1.Value;
            student.IsMale = radioButton1.Checked;
            student.Tehnologies = buf;

            MessageBox.Show(student.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
