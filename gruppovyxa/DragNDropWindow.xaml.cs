using gruppovyxa.frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
                //clickCount++;
                //if (clickCount == 1)
                //{
                //    Controllers.Controller.currentBall -= 2;
                //}
                //else if (clickCount == 2)
                //{
                //    Controllers.Controller.currentBall -= 5;
                //    hint.Visibility = Visibility.Hidden;
                //}
                tbBall.Text = $"Количество баллов: {Math.Round(Controllers.Controller.currentBall)}";

            }

            HintWindow HW = new HintWindow();



            var programmer_hints = new Dictionary<string, string>
            {
                {"1", ""},
                {"2", ""},
                {"3", ""},
                {"4", ""},
                {"5", ""},
                {"6", ""}
            };
            var lawyer_hints = new Dictionary<string, string>
            {
                {"1", ""},
                {"2", ""},
                {"3", ""},
                {"4", ""},
                {"5", ""}
            };
            var doctor_hints = new Dictionary<string, string>
            {
                {"1", "Мозг."},
                {"2", "Печень."},
                {"3", "Сердце."},
                {"4", "Желудок."},
                {"5", "Кишечник."},
                {"6", "Легкие."}
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
                foreach (var hint in programmer_hints)
                {
                    if (allImages.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Tag.ToString() != "0"))
                    {
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }

            if (stage is doctorDragNDrop)
            {
                foreach (var hint in doctor_hints)
                {
                    if (allImages.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Tag != "0"))
                    {
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
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
