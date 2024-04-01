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
    /// Логика взаимодействия для ResultTableMenu.xaml
    /// </summary>
    public partial class ResultTableMenu : Page
    {
        Frame frame;
        public ResultTableMenu(Frame frame)
        {
            InitializeComponent();
            this.frame = frame;
        }

        private void Programmer_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new TablesResultPage(Controllers.Controller.ladder.ProgerTop100));
        }

        private void Lawer_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new TablesResultPage(Controllers.Controller.ladder.LawyerTop100));
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new TablesResultPage(Controllers.Controller.ladder.DoctorTop100));
        }
    }
}
