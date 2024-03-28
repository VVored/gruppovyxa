using gruppovyxa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gruppovyxa.Controllers
{
    enum Professions
    {
        Programmer,
        Lawyer,
        Doctor
    }
    public class Controller
    {
        public List<User> users;
        static Random rnd = new Random();


        // Получение случайного элемента из перечисления
        public Controller()
        {
            InitializeUsers();
        }
        private void InitializeUsers()
        {
            users = new List<User> { };
            users.Add(new User { Name = "user" });
            for (int i = 1; users.Count <= 300; i++)
            {
                Professions randomProfession = (Professions)rnd.Next(3);
                users.Add(new User { Name = $"user{i}", Points = rnd.Next(0, 60), Profession = randomProfession.ToString() });
            }

        }

        public User AuthenticateUser(string username)
        {
            return users.FirstOrDefault(u => u.Name == username);
        }

        public void GameEnded()
        {
            Ladder lad = new Ladder();
            

        }
    }
}
