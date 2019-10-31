using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._10._2019.Net_framework
{
    [Serializable]
    class Union
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public bool Ismale { get; set; }
        public DateTime BirthDate { get; set; }
        public Union()
        {
            ListTechnologis = new Dictionary<string, bool>();

        }
        public Dictionary<string, bool> ListTechnologis; 

    }
}
