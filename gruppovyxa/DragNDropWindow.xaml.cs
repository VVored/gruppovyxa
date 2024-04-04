using gruppovyxa.frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace gruppovyxa
{
    /// <summary>
    /// Логика взаимодействия для DragNDropWindow.xaml
    /// </summary>
    public partial class DragNDropWindow : Window
    {
        IResultCheck stage;
        double stagepoint;
        public DragNDropWindow(IResultCheck stage, double stagepoint)
        {

            InitializeComponent();
            this.stagepoint = stagepoint;
            tbBall.Text = $"Количество баллов: {Math.Round(Controllers.Controller.currentBall)}";
            this.stage = stage;
            frame.NavigationService.Navigate(stage);
            if (stage is programmerDragNDrop) Poyas.Text += "\n Расставте комплектующие компьютера на их места";
            else if (stage is doctorDragNDrop) Poyas.Text += "\n Расположите органы челове к воответствующем для них месте";
            else Poyas.Text += "\n Сопоставте название функции с ее описанием";
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            stage.ResultCheck();
            tbBall.Text = $"Количество баллов: {Math.Round(Controllers.Controller.currentBall)}";


            IResultCheck nextStage;
            try
            {
                if (stage.GetType() == typeof(frames.doctorDragNDrop))
                    nextStage = new frames.doctorCrossword();
                else if (stage.GetType() == typeof(frames.lawyerDragNDrop))
                    nextStage = new frames.lawyerCrossword();
                else
                    nextStage = new frames.programmerCrossword();

                if (Controllers.Controller.currentBall - stagepoint <= 0) throw new Exception("Этап не пройден");

                stagepoint = Controllers.Controller.currentBall;
                CrosswordWindow win = new CrosswordWindow(nextStage, stagepoint);
                this.Close();
                win.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
                Controllers.Controller.currentBall = 0;
            }

        }
        private int clickCount = 0;
        private void hint_Click(object sender, RoutedEventArgs e)
        {
            if (stage is doctorDragNDrop || stage is programmerDragNDrop || stage is lawyerDragNDrop)
            {
                clickCount++;
                if (clickCount == 1)
                {
                    Controllers.Controller.currentBall -= 2;
                }
                else if (clickCount == 2)
                {
                    Controllers.Controller.currentBall -= 5;
                    hint.Visibility = Visibility.Hidden;
                }

            }

            HintWindow HW = new HintWindow();

            var lawyer_hints = new Dictionary<string, string>
            {
                {"1", "Мировозренческая закрепляет основы мировоззрения, основные общественные ценности, например гуманизм, равенство, правосудие, патриотизм"},
                {"2", "Правохранительная Конституция предоставляет гражданам права и свободы, а также механизмы их защиты"},
                {"3", "Системообразующая Конституция возглавляет систему нормативных актов, связывая их в единую систему"},
                {"4", "Учредительная Конституция создает основу для функционирования государства и общества, закрепляет общие принципы"}
            };

            var allTextBlocks = FindVisualChildren<TextBlock>(stage as Page);

            if (stage is lawyerDragNDrop)
            {
                foreach (var hint in lawyer_hints)
                {
                    if (allTextBlocks.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Visibility == Visibility.Visible))
                    {
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }

            var allImages = FindVisualChildren<Image>(stage as Page);

            if (stage is programmerDragNDrop)
            {
                HW.img.Height = 150;
                if(clickCount <= 1)
                HW.img.Source = new BitmapImage(new Uri("/imgs/пк_подсказка_1.png", UriKind.Relative));
                else
                    HW.img.Source = new BitmapImage(new Uri("/imgs/пк_подсказка_2.jpg", UriKind.Relative));

            }

            if (stage is doctorDragNDrop)
            {
                HW.img.Height = 150;
                if (clickCount <= 1)
                    HW.img.Source = new BitmapImage(new Uri("/imgs/органы1.jpg", UriKind.Relative));
                else
                    HW.img.Source = new BitmapImage(new Uri("/imgs/органы2.png", UriKind.Relative));
            }
            HW.Show();


        }

        private IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    if (child != null && child is T tChild)
                    {
                        yield return tChild;
                    }

                    foreach (var childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }

        }
    }
}
