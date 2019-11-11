using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._11._2019
{
    public class Product
    {
        private static int IdCount;
        public int ID{get;private set;}
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Country { get; set; }
        public decimal Discount { get; set; }
        public Product(string name,decimal price,decimal quantity,string country,decimal discount)
        {
            ID = IdCount++;
            Name = name;
            Price = price;
            Quantity = quantity;
            Country = country;
            Discount = discount;
        }
        public Product()
        {
            ID = IdCount++;
            Name = "None";
            Price = 0;
            Quantity = 0;
            Country = "None";
            Discount = 0;
        }
        public Product(Product p)
        {
            ID = IdCount++;
            Name = p.Name;
            Price = p.Price;
            Quantity = p.Quantity;
            Country = p.Country;
            Discount = p.Discount;
        }
    }
}
