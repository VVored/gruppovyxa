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
    /// Логика взаимодействия для sequenceWindow.xaml
    /// </summary>
    public partial class sequenceWindow : Window
    {
        IResultCheck stage;

        public sequenceWindow(IResultCheck stage)
        {
            InitializeComponent();

            tbBall.Text = $"Количество баллов: {Math.Round(Controllers.Controller.currentBall)}";
            this.stage = stage;
            frame.NavigationService.Navigate(stage);
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            stage.ResultCheck();

            IResultCheck nextStage;

            if (stage.GetType() == typeof(frames.sequenceDoctor))
                nextStage = new frames.doctorCrossword();
            else if (stage.GetType() == typeof(frames.sequenceLawyer))
                nextStage = new frames.lawyerCrossword();
            else
                nextStage = new frames.programmerCrossword();

            this.Close();

            CrosswordWindow win = new CrosswordWindow(nextStage);
            win.ShowDialog();
        }
    }
}
