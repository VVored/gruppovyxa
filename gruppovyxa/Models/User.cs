using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace gruppovyxa.Models
{
    public class User
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public string Profession { get; set; }
        public int Place { get; set; }


        public void Update(int place)
        {
            this.Place = place;
        }

    }
}
