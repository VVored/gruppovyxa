﻿using System;
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

        public static void UserSignIn(TextBox name, TextBox phone)
        {
            var users = File.ReadAllText("Users.txt").Split('\n');
            File.WriteAllLines("Users.txt", users);
            StreamWriter sw = new StreamWriter("Users.txt");
            
            if (!users.Contains($"{name.Text} {phone.Text}"))
                sw.WriteLine($"{name.Text} {phone.Text}");

            sw.Close();
        }

        public void GameEnd()
        {

        }
    }
}
