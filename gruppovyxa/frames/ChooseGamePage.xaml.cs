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
    /// Логика взаимодействия для ChooseGamePage.xaml
    /// </summary>
    public partial class ChooseGamePage : Page
    {
        public ChooseGamePage()
        {
            InitializeComponent();
        }

        private void DND_Click(object sender, RoutedEventArgs e)
        {
            DragNDropWindow dragNDropWindow = new DragNDropWindow();
            dragNDropWindow.Show();
        }

        private void Sequence_Click(object sender, RoutedEventArgs e)
        {
            sequenceWindow sequenceWindow = new sequenceWindow();
            sequenceWindow.Show();
        }

        private void Crossword_Click(object sender, RoutedEventArgs e)
        {
            CrosswordWindow crosswordWindow = new CrosswordWindow();
            crosswordWindow.Show();
        }
    }
}
