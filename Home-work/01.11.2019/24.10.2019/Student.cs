using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24._10._2019
{
    [Serializable]
    class Student
    {
        public string Name{get;set;}
        public string Surname { get; set; }
        public string ResidenceAddress { get;set;}
        public DateTime DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        public string Tehnologies {get;set;}
        public override string ToString()
        {
            return "Name = "+Name+"\nSurname => "+Surname+ "\nResidence address => "+
                ResidenceAddress+"\nDate of Birth => "+ DateOfBirth .ToShortTimeString()+
                "\nGender => " + (IsMale?"Male":"Female")+
                "\nTehnologies => " + Tehnologies;
        }
    }
}
