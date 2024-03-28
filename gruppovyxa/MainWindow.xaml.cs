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

namespace gruppovyxa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controllers.Controller controller;
        public MainWindow()
        {
            InitializeComponent();

            controller = new Controllers.Controller();
        }

        private void UserSignIn(object sender, RoutedEventArgs e)
        {
            User user = controller.AuthenticateUser(Username.Text);

            if (user != null)
            {
                Menu menu = new Menu(user, controller);
                menu.Show();
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }

        }
    }
}
