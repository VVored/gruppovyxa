using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        int a;

        private void SMS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (phone.Text == "") throw new Exception("Введите Ваш номер телефона");
                if (!Regex.IsMatch(phone.Text, "^[0-9]+$")) throw new Exception("Немер не определен");
                if (phone.Text.Length != 11) throw new Exception("Немер не определен");
                Random ran = new Random();
                a = ran.Next(1111, 9999);
                MessageBox.Show(a.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text == "") throw new Exception("Введите Ваше имя");
                if (name.Text.Length < 3) throw new Exception("Слишком короткое имя"); 
                if (name.Text.Length > 25) throw new Exception("Слишком длинное имя"); 
                if(Regex.IsMatch(name.Text, "^[0-9]+$")) throw new Exception("Неверный формат имени");
                if (smscod.Text == "") throw new Exception("Введите код из СМС");
                if (int.Parse(smscod.Text) != a) throw new Exception("Код из СМС неверный");

                Controllers.Controller controller = new Controllers.Controller();

                Menu menu = new Menu();
                menu.Show();
                this.Close();

                Controllers.Controller.UserSignIn(name, phone);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
