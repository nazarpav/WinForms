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
    public partial class Form2 : Form
    {
        Product product;
        Dictionary<int, Product> DProd;
        Form1 form;
        public Form2(Dictionary<int, Product> DProd, Product product,Form1 form)
        {
            this.form = form;
            this.DProd = DProd;
            this.product = product;
            InitializeComponent();
            SetProduct(product);
        }
        public void SetProduct(Product product)
        {
            textBox1.Text = product.Name;
            numericUpDown1.Value = product.Price;
            numericUpDown2.Value = product.Quantity;
            comboBox1.Text = product.Country;
            numericUpDown3.Value = product.Discount;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            product.Name = textBox1.Text;
            product.Price = numericUpDown1.Value;
            product.Quantity = numericUpDown2.Value;
            product.Country = comboBox1.Text;
            product.Discount = numericUpDown3.Value;
            if (!(DProd.ContainsKey(product.ID)))
            {
                DProd.Add(product.ID, product);
            }
            else
                DProd[product.ID] = product;
            form.Update_();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
