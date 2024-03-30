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
            {
                nextStage = new frames.sequenceDoctorHard();
                this.Close();

                sequenceWindow win = new sequenceWindow(nextStage);
                win.ShowDialog();
            }
            else if (stage.GetType() == typeof(frames.sequenceLawyer))
            {
                nextStage = new frames.sequenceLawyerHard();
                this.Close();

                sequenceWindow win = new sequenceWindow(nextStage);
                win.ShowDialog();
            }
            else if (stage.GetType() == typeof(frames.sequenceProgrammer))
            {
                nextStage = new frames.sequenceProgrammerHard();
                this.Close();

                sequenceWindow win = new sequenceWindow(nextStage);
                win.ShowDialog();
            }
            else
            {
                if (stage.GetType() == typeof(frames.sequenceDoctorHard))
                    nextStage = new frames.doctorDragNDrop();
            else if (stage.GetType() == typeof(frames.sequenceLawyerHard))
                    nextStage = new frames.lawyerDragNDrop();
                else
                    nextStage = new frames.programmerDragNDrop();

                this.Close();

                DragNDropWindow win = new DragNDropWindow(nextStage);
                win.ShowDialog();
            }



            
        }
    }
}
