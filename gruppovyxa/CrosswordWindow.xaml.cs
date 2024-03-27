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
    /// Логика взаимодействия для CrosswordWindow.xaml
    /// </summary>
    public partial class CrosswordWindow : Window
    {
        IResultCheck stage;

        public CrosswordWindow(IResultCheck stage)
        {
            InitializeComponent();

            this.stage = stage;
            crossFrame.NavigationService.Navigate(stage);
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            IResultCheck nextStage;

            if (stage.GetType() == typeof(frames.doctorCrossword))
                nextStage = new frames.doctorDragNDrop();
            else if (stage.GetType() == typeof(frames.lawyerCrossword))
                nextStage = new frames.lawyerDragNDrop();
            else
                nextStage = new frames.programmerDragNDrop();

            DragNDropWindow win = new DragNDropWindow(nextStage);
            win.ShowDialog();
        }
    }
}
