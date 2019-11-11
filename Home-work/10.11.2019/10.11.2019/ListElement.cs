using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._11._2019
{
    public class ListElement
    {
        public readonly int Id;
        public string Name{get;set;}
        public ListElement (int id)
        {
            Id = id;
            Name = "None";
        }
        public ListElement(int id,string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
