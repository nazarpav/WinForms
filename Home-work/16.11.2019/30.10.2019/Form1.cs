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
        Dictionary<int,string> pathList;
        public Form1()
        {
            InitializeComponent();
            addNewTab();
            Update_();
            pathList = new Dictionary<int, string>();
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
        private TabPage addNewTab()
        {
            TabPage tp = new TabPage();
            RichTextBox tb = new RichTextBox();
            tabControl1.Controls.Add(tp);
            tp.Controls.Add(tb);
            tp.Location = new System.Drawing.Point(0, 0);
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
            tb.AllowDrop = true;
            tb.DragEnter += tabControl1_DragEnter;
             tb.EnableAutoDragDrop = true;
            tb.DragDrop += tabControl1_DragDrop;
            return tp;
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
            switch (MessageBox.Show("Open new Tab?", "_", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    tabControl1.SelectedTab=addNewTab();
                    Update_();
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    return;
            }
            OpenFileDialog open = new OpenFileDialog();
           //open.Filter = @"All Files(*.*)|*.*|Text Files(*.rtf)|*.rtf||";
            open.FilterIndex = 1;
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (!(pathList.ContainsKey(tabControl1.SelectedIndex)))
                    pathList.Add(tabControl1.SelectedIndex, open.FileName);
                else
                    pathList[tabControl1.SelectedIndex] = open.FileName;
                getTB().LoadFile(open.FileName);
            }
            tabControl1.Text = open.Title;
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pathList.ContainsKey(tabControl1.SelectedIndex))
            {
                getTB().SaveFile(pathList[tabControl1.SelectedIndex]);
                return;
            }
            SaveFileDialog save = new SaveFileDialog(); // create instance           
            save.DefaultExt = ".rtf"; // set default extension        
            if (save.ShowDialog() == DialogResult.OK)
            {
                getTB().SaveFile(save.FileName);
            }
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog(); // create instance       
            font.ShowDialog();
            getTB().SelectionFont = font.Font;
        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog(); // create instance       
            color.ShowDialog();
            getTB().SelectionColor = color.Color;
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
            pathList.Remove(tabControl1.SelectedIndex);
        }
        private void onOffMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Enabled = !contextMenuStrip1.Enabled;
        }
        private void saveASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();   
            save.DefaultExt = ".rtf";
            if (save.ShowDialog() == DialogResult.OK)
            {
                getTB().SaveFile(save.FileName);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getTB().Paste();
        }

        private void tabControl1_DragDrop(object sender, DragEventArgs e)
        {
            string v = e.Data.GetData(DataFormats.Text, true).ToString();
            getTB(). Text = e.Data.GetData(DataFormats.Rtf,true).ToString();
        }

        private void tabControl1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            //if (e.Data.GetDataPresent(DataFormats.Text,true))
            //    e.Effect = DragDropEffects.Copy;
            //else
               // e.Effect = DragDropEffects.All;
        }
    }
}
