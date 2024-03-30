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
    /// Логика взаимодействия для sequenceLawyerHard.xaml
    /// </summary>
    public partial class sequenceLawyerHard : Page, IResultCheck
    {
        public sequenceLawyerHard()
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
            if (tb1.Text == "Разработать устав или иные учредительные документы будущей организации") Controllers.Controller.currentBall += 2;
            if (tb2.Text == "Принять решение о создании нового юрлица") Controllers.Controller.currentBall += 2;
            if (tb3.Text == "Подготовить заявление по форме № Р11001 и другие документы") Controllers.Controller.currentBall += 2;
            if (tb4.Text == "Подать документы в налоговую") Controllers.Controller.currentBall += 2;
            if (tb5.Text == "Получить лист записи из реестра в электронном виде") Controllers.Controller.currentBall += 2;
        }
    }
}
