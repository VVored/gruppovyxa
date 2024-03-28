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
    /// Логика взаимодействия для ChooseProfessionPage.xaml
    /// </summary>
    public partial class ChooseProfessionPage : Page
    {
        Models.User user = new Models.User();
        Controllers.Controller controller = new Controllers.Controller();
        public ChooseProfessionPage(Models.User user, Controllers.Controller controller)
        {
            InitializeComponent();
            this.user = user;
            this.controller = controller;
            check();
        }
        private void check()
        {
            if (user.Profession != null)
            {
                Law.IsEnabled = false;
                Prog.IsEnabled = false;
                Doc.IsEnabled = false;
            }
        }
        private void Programmer(object sender, RoutedEventArgs e)
        {
            user.Profession = "Programmer";
            programmerCrossword pC = new programmerCrossword();
            CrosswordWindow cw = new CrosswordWindow(pC, user);
            cw.crossFrame.Navigate(pC);
            cw.Show();
            check();
        }

        private void Lawyer(object sender, RoutedEventArgs e)
        {
            user.Profession = "Lawyer";
            lawyerCrossword lC = new lawyerCrossword();
            CrosswordWindow cw = new CrosswordWindow(lC, user);
            cw.crossFrame.Navigate(lC);
            cw.Show();
            check();
        }

        private void Doctor(object sender, RoutedEventArgs e)
        {
            user.Profession = "Doctor";
            doctorCrossword dC = new doctorCrossword();
            CrosswordWindow cw = new CrosswordWindow(dC, user);
            cw.crossFrame.Navigate(dC);
            cw.Show();
            check();
        }
    }
}
