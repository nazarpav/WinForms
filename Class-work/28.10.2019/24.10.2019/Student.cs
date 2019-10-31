using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._10._2019
{
    [Serializable]
    class Student
    {
        public string Name{get;set;}
        public string Tehnologies{get;set;}
        public string Country{get;set;}
        public Student()
        {

        }
        public Student(string name,string teh,string country)
        {
            Name = name;
            Tehnologies = teh;
            Country = country;
        }
        public override string ToString()
        {
            return "Name = "+Name+"\nTehnologies = "+ Tehnologies+"\nCountry = "+Country;
        }
    }
}
