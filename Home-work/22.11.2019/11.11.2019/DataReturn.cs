using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._11._2019
{
    public class DataReturn
    {
        public string name { get; set; }
        public ImageFormat format { get; set; }
        public DataReturn(string name, ImageFormat format)
        {
            this.name = name;
            this.format = format;
        }
        public DataReturn()
        {
        }
    }
}
