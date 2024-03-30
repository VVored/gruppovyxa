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
    /// Логика взаимодействия для DragNDropWindow.xaml
    /// </summary>
    public partial class DragNDropWindow : Window
    {
        IResultCheck stage;

        public DragNDropWindow(IResultCheck stage)
        {
            InitializeComponent();

            tbBall.Text = $"Количество баллов: {Math.Round(Controllers.Controller.currentBall)}";
            this.stage = stage;
            frame.NavigationService.Navigate(stage);
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            stage.ResultCheck();
            tbBall.Text = $"Количество баллов: {Math.Round(Controllers.Controller.currentBall)}";

            IResultCheck nextStage;

            if (stage.GetType() == typeof(frames.doctorDragNDrop))
                nextStage = new frames.doctorCrossword();
            else if (stage.GetType() == typeof(frames.lawyerDragNDrop))
                nextStage = new frames.lawyerCrossword();
            else
                nextStage = new frames.programmerCrossword();

            CrosswordWindow win = new CrosswordWindow(nextStage);
            this.Close();
            win.ShowDialog();
        }
    }
}
