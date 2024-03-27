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
        public MainWindow()
        {
            InitializeComponent();
        }

        int a;

        private void SMS_Click(object sender, RoutedEventArgs e)
        {
            Random ran = new Random();
            a = ran.Next(1111, 9999);
            MessageBox.Show(a.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text == "") throw new Exception("Введите Ваше имя");
                if (phone.Text == "") throw new Exception("Введите Ваш номер телефона");
                if (smscod.Text == "") throw new Exception("Введите код из СМС");
                if (int.Parse(smscod.Text) != a) throw new Exception("Код из СМС неверный");

                Controllers.Controller controller = new Controllers.Controller();
                
                Menu menu = new Menu();
                menu.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        } 
    }
}
