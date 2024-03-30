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
    /// Логика взаимодействия для sequenceDoctorHard.xaml
    /// </summary>
    public partial class sequenceDoctorHard : Page, IResultCheck
    {
        public sequenceDoctorHard()
        {
            InitializeComponent();
        }

        private void canvas1_Drop(object sender, DragEventArgs e)
        {
            if (e.Source is Canvas)
            {
                TextBlock src = e.Data.GetData(typeof(TextBlock))
                as TextBlock;
            }
        }

        private void label1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var t = e.Source as TextBlock;
            if (t == null)
                return;
            if (e.ChangedButton == MouseButton.Left)
                if (DragDrop.DoDragDrop(t, t, DragDropEffects.All) ==
                DragDropEffects.Move)
                    t.Visibility = Visibility.Hidden;

            string s = "";
            for (int i = 0; i < 8; i++)
            {

                s += (grid1.Children[0] as TextBox).Text;
            }
            if (s == "")
                return;
        }

        private void canvas1_DragEnter(object sender, DragEventArgs e)
        {
            e.Handled = true;
            e.Effects = DragDropEffects.Move;
            var trg = e.Source as TextBlock;
            if (trg == null)
                return;

        }

        int a;

        private void grid1_Drop(object sender, DragEventArgs e)
        {

            var trg = e.Source as TextBox;
            if (trg == null)
                return;
            var src = e.Data.GetData(typeof(TextBlock)) as TextBlock;
            trg.Text = src.Text;
            trg.Tag = src.Tag;
            a = int.Parse((string)src.Tag);
            src.Visibility = Visibility.Hidden;
        }


        private void grid1_PreviewDragEnter(object sender, DragEventArgs e)
        {
            var trg = e.Source as TextBox;
            if (trg == null)
                return;
            e.Handled = true;
            e.Effects = trg.Text == "" ?
            DragDropEffects.Move : DragDropEffects.None;

        }

        public void ResultCheck()
        {
            if (tb1.Text == "наложение жгута выше места повреждения") Controllers.Controller.currentBall += 1.5;
            if (tb2.Text == "изменение положение тела, конечности") Controllers.Controller.currentBall += 1.5;
            if (tb3.Text == "прижатие сосуда пальцем выше места повреждения") Controllers.Controller.currentBall += 1.5;
            if (tb4.Text == "сгибание конечности, с использованием валика в месте сгиба") Controllers.Controller.currentBall += 1.5;
            if (tb5.Text == "наложение зажима на сосуд") Controllers.Controller.currentBall += 1.5;
            if (tb6.Text == "тампонада раны") Controllers.Controller.currentBall += 1.5;
            if (tb7.Text == "наложение давящей повязки") Controllers.Controller.currentBall += 1.5;
        }

    }
}
