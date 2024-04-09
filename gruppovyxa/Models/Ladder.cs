using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gruppovyxa.Models
{
    public class Ladder : Subject
    {
        public List<User> ProgerTop100 = new List<User>();
        public List<User> DoctorTop100 = new List<User>();
        public List<User> LawyerTop100 = new List<User>();

        public void notifyObserver()
        {

        }

        public void registerObserver(Observer o)
        {

        }

        public void removeObserver(Observer o)
        {

        }
        public Ladder(string path1, string path2, string path3)
        {
            ProgerTop100 = Controllers.Controller.getTop100(path1);
            DoctorTop100 = Controllers.Controller.getTop100(path2);
            LawyerTop100 = Controllers.Controller.getTop100(path3);

        }
        public void Top100Changed(User currentUser, string path, string job)
        {
            StreamWriter sw = new StreamWriter(path);
            var list = Controllers.Controller.getTop100(path);
            list.Add(currentUser);
            list = Enumerable.OrderByDescending(list, p => p.Points).ToList();
            

            switch (job)
            {
                case "программист":
                    foreach (User u in list)
                        ProgerTop100.Add(u);

                    if (ProgerTop100.Count > 100) ProgerTop100.RemoveAt(100);

                    foreach (User u in ProgerTop100)
                        sw.WriteLine($"{u.Name} {u.Phone} {u.Points}");
                    break;

                case "доктор":
                    foreach (User u in list)
                        DoctorTop100.Add(u);

                    if (DoctorTop100.Count > 100) DoctorTop100.RemoveAt(100);

                    foreach (User u in DoctorTop100)
                        sw.WriteLine($"{u.Name} {u.Phone} {u.Points}");
                    break;

                case "юрист":
                    foreach (User u in list)
                        LawyerTop100.Add(u);

                    if (LawyerTop100.Count > 100) LawyerTop100.RemoveAt(100);

                    foreach (User u in LawyerTop100)
                        sw.WriteLine($"{u.Name} {u.Phone} {u.Points}");
                    break;
            }
            sw.Close();

        }
    }
}
