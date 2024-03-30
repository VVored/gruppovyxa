using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruppovyxa.Models
{
    public class Ladder : Subject
    {
        List<User> ProgerTop100;
        List<User> DoctorTop100;
        List<User> LawyerTop100;

        public void notifyObserver()
        {

        }

        public void registerObserver(Observer o)
        {

        }

        public void removeObserver(Observer o)
        {

        }

        public void Top100Changed()
        {

        }
    }
}
