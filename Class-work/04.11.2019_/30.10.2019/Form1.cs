using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _30._10._2019
{
    public partial class Form1 : Form
    {
        List<Form1> forms = new List<Form1>();
        public Form1()
        {
            InitializeComponent();
            AddTab();
            toolStripLabelquantitychar.Text = tabControl1.SelectedTab.Controls.Text.Length.ToString() + " / " + numericUpDown1.Maximum + " Symbols";
            textBox1.MaxLength = (int)numericUpDown1.Value;
            textBox1.BackColor = Color.Khaki;
            this.BackColor = textBox1.BackColor;
            numericUpDown1.BackColor = textBox1.BackColor;


        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = (int)numericUpDown1.Value;
            toolStripLabelquantitychar.Text = textBox1.Text.Length.ToString()+" / "+ (int)numericUpDown1.Value + " Symbols";
            Regex digits = new Regex(@"[0-9]");
            Regex letters = new Regex(@"[a-z|A-Z]");
            Regex words = new Regex(@"[a-z,A-Z]+");
            MatchCollection matches = digits.Matches(textBox1.Text);
            toolStripLabeldigit.Text = "Digit = " + matches.Count;
            matches = letters.Matches(textBox1.Text);
            toolStripLabelletter.Text = "Laters = " + matches.Count;
            matches = words.Matches(textBox1.Text);
            toolStripLabelword.Text = "Word = " +matches.Count;
            toolStripProgressBar1.Maximum= (int)numericUpDown1.Value;
            toolStripProgressBar1.Value = textBox1.Text.Length;
        }
        private void AddTab()
        {
            TabPage tabPage = new TabPage();
            TextBox textBox = new TextBox();

            tabPage.Location = new System.Drawing.Point(4, 34);
            tabPage.Name = "tabPage1";
            tabPage.Padding = new System.Windows.Forms.Padding(3);
            tabPage.Size = new System.Drawing.Size(1013, 0);
            tabPage.TabIndex = 0;
            tabPage.Text = "tabPage1";
            tabPage.UseVisualStyleBackColor = true;

            textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox.Font = new System.Drawing.Font("Gilroy ExtraBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox.ForeColor = System.Drawing.Color.Black;
            textBox.Location = new System.Drawing.Point(0, 66);
            textBox.Margin = new System.Windows.Forms.Padding(6);
            textBox.MinimumSize = new System.Drawing.Size(1037, 250);
            textBox.Multiline = true;
            textBox.Name = "textBox1";
            textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox.Size = new System.Drawing.Size(1037, 627);
            textBox.TabIndex = 1;
            textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            tabPage.Controls.Add(textBox);
            tabControl1.Controls.Add(tabPage);
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = (int)numericUpDown1.Value;
            if(textBox1.TextLength> (int)numericUpDown1.Value)
             textBox1.Text=textBox1.Text.Remove((int)numericUpDown1.Value);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabelquantitychar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog(); // create instance
            open.Filter = @"All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            open.FilterIndex = 1; // default filter (all .txt files)
            if (MessageBox.Show("Open new or use this form", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                forms.Add(new Form1());
                if (open.ShowDialog() == DialogResult.OK)
                {
                    StreamReader reader = File.OpenText(open.FileName);
                    forms[forms.Count - 1].textBox1.Text = reader.ReadToEnd(); // read all data
                    reader.Close(); // close reader
                }
                forms[forms.Count - 1].Show();
                return;
            }
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = File.OpenText(open.FileName);
                textBox1.Text = reader.ReadToEnd(); // read all data
                reader.Close(); // close reader
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog(); // create instance           
            save.DefaultExt = ".txt"; // set default extension        
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                writer.Write(textBox1.Text); // write string to file 
                writer.Close(); // close reader
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog(); // create instance       
            color.ShowDialog();
            textBox1.ForeColor = color.Color;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FontDialog color = new FontDialog(); // create instance       
            color.ShowDialog();
            textBox1.Font = color.Font;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddTab();
        }

        private void button6_Click(object sender, EventArgs e)
        {   
            tabControl1.Controls.Remove(tabControl1.SelectedTab);

        }
    }
}
