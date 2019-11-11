using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._11._2019
{
    public partial class Form1 : Form
    {
        Dictionary<int, Product> DProd;
        Form2 Form2_;
        List<ListElement> ToListBox;
        public Form1()
        {
            DProd = new Dictionary<int, Product >();
            ToListBox = new List<ListElement>();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (DProd == null || DProd.Count == 0 || listBox1.SelectedItem == null)
                return;
            Form2_ = new Form2(DProd, DProd[GetSelectedItemID()], this);
            Form2_.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (DProd == null || DProd.Count == 0 || listBox1.SelectedItem == null)
                return;
            Form2_ = new Form2(DProd, DProd[GetSelectedItemID()], this);
            Form2_.Enabled = false;
            Form2_.Show();
        }
        private int GetSelectedItemID()
        {
            Regex regex = new Regex(@"#\d+$");
            MatchCollection matches = regex.Matches(listBox1.SelectedItem.ToString());
            foreach (var i in matches)
            {
                return int.Parse(i.ToString().Remove(0, 1));
            }
            return 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2_ = new Form2(DProd, new Product(),this);
            Form2_.Show();
        }
        public void Update_()
        {
            listBox1.Items.Clear();
            foreach (var item in DProd)
            {
                listBox1.Items.Add(item.Value.Name+ " | id = #"+item.Value.ID);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (DProd == null || DProd.Count == 0 || listBox1.SelectedItem == null)
                return;
            DProd.Remove(GetSelectedItemID());
            Update_();
        }
    }
}
