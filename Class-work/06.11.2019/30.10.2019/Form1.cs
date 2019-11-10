using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _30._10._2019
{
    public partial class Form1 : Form
    {
        SoundPlayer s;
        public Form1()
        {
            InitializeComponent();
            addNewTab();
            Update_();
            s = new SoundPlayer("UntitledMusic.wav");
            

        }
        private RichTextBox getTB()
        {
            if (tabControl1.SelectedIndex != -1)
                if (tabControl1.SelectedTab.Controls[0] is RichTextBox)
                    return (tabControl1.SelectedTab.Controls[0] as RichTextBox);
            return null;

        }
        private void Update_()
        {
            toolStripLabelquantitychar.Text = getTB().Text.Length.ToString() + "/" +
                getTB().MaxLength;
            toolStripLabeldigit.Text = "Digits " + "0";
            toolStripLabelletter.Text = "Letters " + "0";
            toolStripLabelword.Text = "Words " + "0";
        }
        private void addNewTab()
        {
            TabPage tp = new TabPage();
            RichTextBox tb = new RichTextBox();
            tabControl1.Controls.Add(tp);
            tp.Controls.Add(tb);
            tp.Location = new System.Drawing.Point(4, 0);
            tp.Padding = new System.Windows.Forms.Padding(3);
            tp.Size = new System.Drawing.Size(489, 308);
            tp.TabIndex = 0;
            tp.UseVisualStyleBackColor = true;

            tb.Font = new System.Drawing.Font("Microsoft YaHei", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            tb.Location = new System.Drawing.Point(-6, -2);
            tb.Multiline = true;
            //tb.ScrollBars = ScrollBars.Vertical;
            //tb.Size = new System.Drawing.Size(499, 334);
            tb.Width = this.Width;
            tb.Height = this.Height - 100;
            tb.TextChanged += TextChanged_;
            tp.Text = "Tab "+ tabControl1.TabPages.Count;
            tb.MaxLength = int.MaxValue;
            tb.ContextMenuStrip = contextMenuStrip1;
        }
        private void TextChanged_(object sender, EventArgs e)
        {
            toolStripLabelquantitychar.Text = getTB().Text.Length.ToString()+" / " + " Symbols";
            Regex digits = new Regex(@"[0-9]");
            Regex letters = new Regex(@"[a-z|A-Z]");
            Regex words = new Regex(@"[a-z,A-Z]+");
            MatchCollection matches = digits.Matches(getTB().Text);
            toolStripLabeldigit.Text = "Digit = " + matches.Count;
            matches = letters.Matches(getTB().Text);
            toolStripLabelletter.Text = "Laters = " + matches.Count;
            matches = words.Matches(getTB().Text);
            toolStripLabelword.Text = "Word = " +matches.Count;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog(); // create instance
            open.Filter = @"All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
            open.FilterIndex = 1; // default filter (all .txt files)
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = File.OpenText(open.FileName);
                
                getTB().Text = reader.ReadToEnd(); // read all data
                reader.Close(); // close reader
            }
            tabControl1.Text = open.Title;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog(); // create instance           
            save.DefaultExt = ".txt"; // set default extension        
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                writer.Write(getTB().Text); // write string to file 
                writer.Close(); // close reader

                
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog(); // create instance       
            color.ShowDialog();
            getTB().ForeColor = color.Color;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog color = new FontDialog(); // create instance       
            color.ShowDialog();
            getTB().Font = color.Font;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getTB().Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getTB().Paste();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getTB().SelectAll();
        }

        private void seletaAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getTB().DeselectAll();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getTB().SelectedText = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            addNewTab();
            Update_();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            tabControl1.Controls.Remove(tabControl1.SelectedTab);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Override or open new file?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OpenFileDialog open = new OpenFileDialog(); // create instance
                                                            // set filters            
                open.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
                open.FilterIndex = 1; // default filter (all .txt files)
                if (open.ShowDialog() == DialogResult.OK)
                {
                    StreamReader reader = File.OpenText(open.FileName);
                    getTB().Text = reader.ReadToEnd(); // read all data
                    reader.Close(); // close reader
                }
            }
            else
            {
                Form1 newForm = new Form1();
                OpenFileDialog open = new OpenFileDialog(); // create instance
                                                            // set filters            
                open.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt||";
                open.FilterIndex = 1; // default filter (all .txt files)
                if (open.ShowDialog() == DialogResult.OK)
                {
                    StreamReader reader = File.OpenText(open.FileName);
                    newForm.getTB().Text = reader.ReadToEnd(); // read all data
                                                               // string str = reader.ReadToEnd(); // read all data
                    reader.Close(); // close reader
                                    // Application.Run(new Form1(str));
                }
                newForm.Show();
            }
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog(); // create instance           
            save.DefaultExt = ".txt"; // set default extension        
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);
                writer.Write(getTB().Text); // write string to file 
                writer.Close(); // close reader
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowDialog();
            getTB().Font = font.Font;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog colro = new ColorDialog();
            colro.ShowDialog();
            getTB().ForeColor = colro.Color;
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            getTB().Copy();
        }

        private void onOffMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Enabled = !contextMenuStrip1.Enabled;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            s.PlayLooping();
        }


        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            s.Stop();
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = !pictureBox1.Visible;
        }
    }
}
