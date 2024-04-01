using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace gruppovyxa.Controllers
{
    public class Controller
    {
        public static double currentBall = 0;
        static Models.User currentUser;
        public static Models.Ladder ladder = new Models.Ladder("..\\..\\Controllers/Top100prog.txt", "..\\..\\Controllers/Top100doctor.txt", "..\\..\\Controllers/Top100lawyer.txt");

        public static void UserSignIn(TextBox name, TextBox phone)
        {

            StreamReader sr = new StreamReader("..\\..\\Controllers/Users.txt");
            string users = sr.ReadToEnd();
            sr.Close();
            var allusers = users.Split('\n');
            StreamWriter sw = new StreamWriter("..\\..\\Controllers/Users.txt");

            currentUser = new Models.User { Name = name.Text, Phone = phone.Text };

            if (!allusers.Contains($"{name.Text} {phone.Text} "))
                users += $"{name.Text} {phone.Text} \n";


            sw.Write(users);
            sw.Close();
        }


        public static void GameEnd(string job)
        {
            currentUser.Points = currentBall;
            switch (job)
            {
                case "программист":

                    //Входит ли в топ 100
                    if (ladder.ProgerTop100.Count!= 100 || (ladder.ProgerTop100.Count == 100 && currentBall >= ladder.ProgerTop100[ladder.ProgerTop100.Count - 1].Points))
                        ladder.Top100Changed(currentUser, "..\\..\\Controllers/Top100prog.txt", job);
                    else
                        ladder.ProgerTop100 = getTop100("..\\..\\Controllers/Top100prog.txt");

                    break;

                case "доктор":
                    if (ladder.DoctorTop100.Count != 100 || (ladder.DoctorTop100.Count == 100 && currentBall >= ladder.DoctorTop100[ladder.ProgerTop100.Count - 1].Points))
                        ladder.Top100Changed(currentUser, "..\\..\\Controllers/Top100doctor.txt", job);
                    else
                        ladder.DoctorTop100 = getTop100("..\\..\\Controllers/Top100doctor.txt");

                    break;

                case "юрист":
                    if (ladder.LawyerTop100.Count != 100 || (ladder.LawyerTop100.Count == 100 && currentBall >= ladder.LawyerTop100[ladder.ProgerTop100.Count - 1].Points))
                        ladder.Top100Changed(currentUser, "..\\..\\Controllers/Top100lawyer.txt", job);
                    else
                        ladder.LawyerTop100 = getTop100("..\\..\\Controllers/Top100lawyer.txt");

                    break;
            }

            currentBall = 0;
        }

        public static List<Models.User> getTop100(string path)
        {
            StreamReader sr = new StreamReader(path);
            string allText = sr.ReadToEnd();
            sr.Close();

            var lines = allText.Split('\n');
            var top100 = new List<Models.User>();

            foreach (string s in lines)
            {
                if (!String.IsNullOrWhiteSpace(s))
                {
                    var user = s.Split(' ');

                    top100.Add(new Models.User { Name = user[0], Phone = user[1], Points = int.Parse(user[2]) });
                }
            }

            return top100;
        }
    }
}
