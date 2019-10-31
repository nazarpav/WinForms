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

namespace _22._10._2019.Net_framework
{
    public partial class Form1 : Form
    {
        List<string> ListProgLanguage;
        Union union;
        BinaryFormatter binFormat = new BinaryFormatter();

        public Form1()
        {
            ListProgLanguage = new List<string>();
            union = new Union();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click_1(object sender, EventArgs e)
        { 
            string buf = string.Empty;
            foreach (var i in groupBoxUnion.Controls)
            {
                CheckBox tmp = i as CheckBox;
                if (tmp.Checked==true)
                union.ListTechnologis.Add( tmp.Text+"\n", tmp.Checked);
            }
            union.Name = textBoxname.Text;
            union.Surname = textBoxSurname.Text;
            union.Country = textBoxCountry.Text;
            union.City = textBoxCity.Text;
            union.Ismale = radioButtonmale.Checked;
            union.BirthDate = dateTimePicker.Value;
            using (Stream fStream = File.Create("test.bin"))
            {
                binFormat.Serialize(fStream, union);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string buf = string.Empty;
            foreach (var i in union.ListTechnologis)
            {
                buf += i.Key;
            }
            MessageBox.Show("Name : " + union.Name+ "\nSurname : " + union.Surname+ "\nCountry :  " + union.Country+ "\nCity: " +union.City+
              "\nIs male : " + (union.Ismale ? "Male" : "Female")+buf);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (Stream fStream = File.OpenRead("test.bin"))
            {
                union = (Union)binFormat.Deserialize(fStream);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string buf = string.Empty;
            foreach (var i in groupBoxUnion.Controls)
            {
                CheckBox tmp = i as CheckBox;
                if (tmp.Checked)
                    buf += ""+tmp.Text;
            }
            MessageBox.Show(
                "Name : " + textBoxname.Text +
                "\nSurname : " + textBoxSurname.Text +
                "\nCountry :  " + textBoxCountry.Text +
                "\nCity : " + textBoxCity.Text +
                "\nIs male : " + (radioButtonmale.Checked?"Male":"Female") +
                "\nBurth Date : " + dateTimePicker.Value+
               buf
                );
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

    }
}
