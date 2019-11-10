using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._11._2019
{
    public partial class Form1 : Form
    {
        Dictionary<string, Product> List;
        Form2 Form2;
        public Form1()
        {
            List = new Dictionary<string, Product>();
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Form2 = new Form2(List[listBox1.SelectedItem.ToString()]);
            Form2.Show();
        }
    }
}
