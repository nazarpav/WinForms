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

        List<Student> students;
        public Form1()
        {
            InitializeComponent();
            students = new List<Student>();
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
            if(comboBox1.SelectedItem!=null)
            MessageBox.Show("Name => "+textBox1.Text+"\nTechnologies => "+buf+"\nCountry => "+comboBox1.SelectedItem.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string buf = string.Empty;
            foreach (var i in checkedListBox1.CheckedItems)
            {
                buf += "\n" + i.ToString();
            }
            listBox1.Items.Add(new Student(textBox1.Text, buf, comboBox1.Text));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string buf = string.Empty;
            foreach (var i in checkedListBox1.CheckedItems)
            {
                buf += "\n" + i.ToString();
            }
            listBox1.SelectedValue=(new Student(textBox1.Text, buf, comboBox1.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
