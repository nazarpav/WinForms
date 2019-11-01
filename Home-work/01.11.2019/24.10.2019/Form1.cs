using System;
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

namespace _24._10._2019
{
    public partial class Form1 : Form
    {

        BinaryFormatter binFormat = new BinaryFormatter();
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student studentTmp = new Student();

            studentTmp.Name = textBox1.Text;
            studentTmp.Surname = textBox2.Text;
            studentTmp.ResidenceAddress = textBox3.Text;
            studentTmp.DateOfBirth = dateTimePicker1.Value;
            studentTmp.IsMale = radioButton1.Checked;
            studentTmp.Tehnologies = checkedListBox1.Text;

            MessageBox.Show(studentTmp.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student studentTmp = new Student();

            studentTmp.Name = textBox1.Text;
            studentTmp.Surname = textBox2.Text;
            studentTmp.ResidenceAddress = textBox3.Text;
            studentTmp.DateOfBirth = dateTimePicker1.Value;
            studentTmp.IsMale = radioButton1.Checked;
            studentTmp.Tehnologies = checkedListBox1.Text;
            using (Stream fStream = File.Create("test.bin"))
            {
                binFormat.Serialize(fStream, studentTmp);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Student studentTmp = new Student();
            using (Stream fStream = File.OpenRead("test.bin"))
            {
                studentTmp = (Student) binFormat.Deserialize(fStream);
            }
            textBox1.Text = studentTmp.Name;
            textBox2.Text= studentTmp.Surname;
            textBox3.Text = studentTmp.ResidenceAddress;
            dateTimePicker1.Value = studentTmp.DateOfBirth;
            radioButton1.Checked = studentTmp.IsMale;
            radioButton2.Checked = !studentTmp.IsMale;
            checkedListBox1.Text = studentTmp.Tehnologies;
        }
    }
}
