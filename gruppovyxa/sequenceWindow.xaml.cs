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
    /// Логика взаимодействия для sequenceWindow.xaml
    /// </summary>
    public partial class sequenceWindow : Window
    {
        IResultCheck stage;
        double stagepoint;
        public sequenceWindow(IResultCheck stage, double stagepoint)
        {
            InitializeComponent();

            tbBall.Text = $"Количество баллов: {Math.Round(Controllers.Controller.currentBall)}";
            this.stage = stage;
            this.stagepoint = stagepoint;
            frame.NavigationService.Navigate(stage);

            if (stage is sequenceDoctor) Poyas.Text += "\n Восстановите порядок классификации организмов";
            else if (stage is sequenceLawyer) Poyas.Text += "\n Установите соответствме между функциями и субъектами гос. власти РФ";
            else if (stage is sequenceProgrammer) Poyas.Text += "\n Восстановите правильный порядок этапов жизненного цикла ПО";
            else if (stage is sequenceDoctorHard) Poyas.Text += "\n Восстановите порядок действий для предотвращения кровотечения";
            else if (stage is sequenceLawyerHard) Poyas.Text += "\n Восстановите порядок регистрации юридического лица";
            else Poyas.Text += "\n Рассположите в правильном порядке этапы запуска ПК";
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            stage.ResultCheck();

            IResultCheck nextStage;
            if(stage is sequenceDoctor || stage is sequenceLawyer || stage is sequenceProgrammer)
            {
                try
                {
                    stagepoint = Controllers.Controller.currentBall;

                    if (Controllers.Controller.currentBall <= 0) throw new Exception("Этап не пройден");

                    if (stage.GetType() == typeof(frames.sequenceDoctor))
                    {
                        nextStage = new frames.sequenceDoctorHard();
                        this.Close();

                        sequenceWindow win = new sequenceWindow(nextStage, stagepoint);
                        win.ShowDialog();
                    }
                    else if (stage.GetType() == typeof(frames.sequenceLawyer))
                    {
                        nextStage = new frames.sequenceLawyerHard();
                        this.Close();

                        sequenceWindow win = new sequenceWindow(nextStage, stagepoint);
                        win.ShowDialog();
                    }
                    else
                    {
                        nextStage = new frames.sequenceProgrammerHard();
                        this.Close();

                        sequenceWindow win = new sequenceWindow(nextStage, stagepoint);
                        win.ShowDialog();
                    }
                   
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                    Controllers.Controller.currentBall = 0;
                }
            }
            else
            {
                try
                {
                    if (stage.GetType() == typeof(frames.sequenceDoctorHard))
                        nextStage = new frames.doctorDragNDrop();
                    else if (stage.GetType() == typeof(frames.sequenceLawyerHard))
                        nextStage = new frames.lawyerDragNDrop();
                    else
                        nextStage = new frames.programmerDragNDrop();

                    if (Controllers.Controller.currentBall - stagepoint <= 0) throw new Exception("Этап не пройден");

                    stagepoint = Controllers.Controller.currentBall;
                    this.Close();
                    DragNDropWindow win = new DragNDropWindow(nextStage, stagepoint);
                    win.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                    Controllers.Controller.currentBall = 0;
                }                
            }


        }

        private int clickCount = 0;
        private int clickCount2 = 0;
        private void hint_Click(object sender, RoutedEventArgs e)
        {
            if (stage is sequenceDoctor || stage is sequenceLawyer || stage is sequenceProgrammer)
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
            else
            {
                clickCount2++;
                if (clickCount2 == 1)
                {
                    Controllers.Controller.currentBall -= 2;
                }
                else if (clickCount2 == 2)
                {
                    Controllers.Controller.currentBall -= 5;
                    hint.Visibility = Visibility.Hidden;
                }
            }
            HintWindow HW = new HintWindow();



            var programmer_hints = new Dictionary<string, string>
            {
                {"1", "В первую очередь выполняется предпроектная подготовка."},
                {"2", "После предпроектной подготовки выполняется проектирование структуры ПП."},
                {"3", "Кодирование выполняется, когда спроектирова структура ПП."},
                {"4", "После окончания разработки проекта выполняется документирование ПП."},
                {"5", "Перед тем, как начать сопровождение, вступает этап эксплуатации ПП."},
                {"6", "Последним этапом является сопровождение ПП."}
            };
            var lawyer_hints = new Dictionary<string, string>
            {
                {"1", "Государственная Дума выполняет осуществление мер по обеспечению обороны страны."},
                {"2", "Государственная Дума обеспечивает проведение в РФ единой финансовой политики."},
                {"3", "объявление амнистии - это задача Правительства РФ."},
                {"4", "Правительство РФ занимается назначением и освобождением от должности Председателя Центрального банка РФ."},
                {"5", "Задача Президента - присвоение почётных званий РФ."}
            };
            var doctor_hints = new Dictionary<string, string>
            {
                {"1", "В начале идет царство."},
                {"2", "На втором уровне находится отдел."},
                {"3", "На третьем уровне находится класс."},
                {"4", "После класса идут порядок."},
                {"5", "Сразу за порядком уровень семейства."},
                {"6", "Предпоследний уровень - род."},
                {"7", "Низший уровень классификации - это вид."}
            };
            var programmerHard_hints = new Dictionary<string, string>
            {
                {"1", "Нажмите на кнопку запуска, чтобы начать загрузку пк." },
                {"2", "В первую очередь происходит запуск программы BIOS."},
                {"3", "После запуска BIOS начинает процедуру POST."},
                {"4", "После успешной проверки аппаратных компонентов, BIOS управление загрузчику ОС."},
                { "5", "Загрузчик инициирует процесс загрузки операционной системы."}
            };

            var lawyerHard_hints = new Dictionary<string, string>
            {
                 {"1", "Первым действием нужно разработать устав или иные учредительные документы будущей организации." },
                {"2", "Вторым действие нужно принять решение о создании нового юрлица."},
                {"3", "Третьим действием необходимо подготовить заявление по форме № Р11001 и другие документы."},
                {"4", "Предпоследним действием нужно подать документы в налоговую."},
                {"5", "В конце необходимо получить лист записи из реестра в электронном виде."}

            };
            var doctorHard_hints = new Dictionary<string, string>
            {
                 {"1", "Сначала наложите жгут выше места повреждения." },
                {"2", "После наложения жгута изменените положение тела, конечности."},
                {"3", "После изменения положения конечности прижмите сосуд пальцем выше места повреждения."},
                {"4", "После прижатия сосуда выполните сгибание конечности, с использованием валика в месте сгиба."},
                {"5", "После повторного сгибания конечности наложите зажим на сосуд."},
                {"6", "Перед наложение давящей повявзки выполните тампонаду раны."},
                {"7", "В конце наложите на рану давящую повязку."}
            };




            var allTextBox = FindVisualChildren<TextBox>(stage as Page);

            if (stage is sequenceLawyer)
            {
                foreach (var hint in lawyer_hints)
                {
                    if (allTextBox.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Text == ""))
                    {
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }

            var allTextBoxes = FindVisualChildren<TextBlock>(stage as Page);

            if (stage is sequenceProgrammer)
            {
                foreach (var hint in programmer_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Visibility == Visibility.Visible))
                    {
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }

            if (stage is sequenceDoctor)
            {
                foreach (var hint in doctor_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Visibility == Visibility.Visible))
                    {
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }

            if (stage is sequenceProgrammerHard)
            {
                foreach (var hint in programmerHard_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Visibility == Visibility.Visible))
                    {
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }
            if (stage is sequenceLawyerHard)
            {
                foreach (var hint in lawyerHard_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Visibility == Visibility.Visible))
                    {
                        HW.HintText.Text = hint.Value;
                        break;
                    }
                }
            }
            if (stage is sequenceDoctorHard)
            {
                foreach (var hint in doctorHard_hints)
                {
                    if (allTextBoxes.Where(p => p.Tag != null && p.Tag.ToString() == hint.Key).All(p => p.Visibility == Visibility.Visible))
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
