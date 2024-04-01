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
using System.Windows.Shapes;

namespace gruppovyxa
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            if (frame.CanGoBack) frame.GoBack();
        }

        private void chooseProf(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new frames.ChooseProfessionPage());
        }

        private void rating(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new frames.ResultTableMenu(frame));
        }
    }
}
