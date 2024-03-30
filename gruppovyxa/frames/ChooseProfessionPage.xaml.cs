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
        public ChooseProfessionPage()
        {
            InitializeComponent();
        }

        private void Lawer_Click(object sender, RoutedEventArgs e)
        {
            sequenceWindow sequenceWindow = new sequenceWindow(new frames.sequenceLawyer());
            sequenceWindow.ShowDialog();
        }

        private void Programmer_Click(object sender, RoutedEventArgs e)
        {
            sequenceWindow sequenceWindow = new sequenceWindow(new frames.sequenceProgrammer());
            sequenceWindow.ShowDialog();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            sequenceWindow sequenceWindow = new sequenceWindow(new frames.sequenceDoctor());
            sequenceWindow.ShowDialog();
        }
    }
}
