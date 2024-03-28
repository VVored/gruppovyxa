using gruppovyxa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gruppovyxa.frames
{
    /// <summary>
    /// Логика взаимодействия для TablesResultPage.xaml
    /// </summary>
    public partial class TablesResultPage : Page
    {
        Models.User user = new Models.User();
        Controllers.Controller controller = new Controllers.Controller();
        private Ladder programmerLadder;
        private Ladder doctorLadder;
        private Ladder lawyerLadder;

        public TablesResultPage(Models.User user, Controllers.Controller controller)
        {
            InitializeComponent();
            this.user = user;
            this.controller= controller;

            programmerLadder = new Ladder();
            doctorLadder = new Ladder();
            lawyerLadder = new Ladder();

            foreach(var a in controller.users.Where(x => x.Profession == "Programmer"))
            programmerLadder.AddUser(a);

            foreach (var a in controller.users.Where(x => x.Profession == "Lawyer"))
                lawyerLadder.AddUser(a);

            foreach (var a in controller.users.Where(x => x.Profession == "Doctor"))
                doctorLadder.AddUser(a);


            UpdateLeaderboard(programmerLadder.GetTop100(), ladderDataGrid);
            prog.Opacity = 0.7;
        }



        // Метод для обновления данных в DataGrid
        private void UpdateLeaderboard(List<User> users, System.Windows.Controls.DataGrid dataGrid)
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = users;
        }

        private void prog_Click(object sender, RoutedEventArgs e)
        {
            UpdateLeaderboard(programmerLadder.GetTop100(), ladderDataGrid);
            prog.Opacity = 0.7;
        }

        private void law_Click(object sender, RoutedEventArgs e)
        {
            UpdateLeaderboard(lawyerLadder.GetTop100(), ladderDataGrid);
            law.Opacity = 0.7;
        }

        private void doc_Click(object sender, RoutedEventArgs e)
        {
            UpdateLeaderboard(doctorLadder.GetTop100(), ladderDataGrid);
            doc.Opacity = 0.7;
        }
    }
}
