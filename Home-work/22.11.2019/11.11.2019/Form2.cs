using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._11._2019
{
    public partial class Form2 : Form
    {
        Bitmap bitmap;
        List<ImageFormat> _ts;
        public Form2(ref Bitmap bitmap)
        {
            InitializeComponent();
            this.bitmap = bitmap;
            _ts = new List<ImageFormat>();
            comboBox1.Items.Add("."+ImageFormat.Png);
            _ts.Add(ImageFormat.Png);
            comboBox1.Items.Add("." + ImageFormat.Jpeg);
            _ts.Add(ImageFormat.Jpeg);
            comboBox1.Items.Add("." + ImageFormat.Bmp);
            _ts.Add(ImageFormat.Bmp);
            comboBox1.Items.Add("." + ImageFormat.Icon);
            _ts.Add(ImageFormat.Icon);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           bitmap.Save(textBox1.Text+ comboBox1.SelectedItem.ToString(), _ts[comboBox1.SelectedIndex]);
            //bitmap.Save(textBox1.Text, ImageFormat.Png);
            this.Close();
        }
    }
}
