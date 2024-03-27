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
    /// Логика взаимодействия для programmerDragNDrop.xaml
    /// </summary>
    public partial class programmerDragNDrop : Page, IResultCheck
    {
        Point p;
        int maxz;

        public programmerDragNDrop()
        {
            InitializeComponent();
        }

         private void rect1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (e.Source as FrameworkElement).CaptureMouse();
            if (e.Source == canvas1)
                return;
            var a = e.Source as FrameworkElement;
            p = e.GetPosition(a);
            Canvas.SetZIndex(a, ++maxz);
            if (e.LeftButton == MouseButtonState.Pressed)
                a.Cursor = Cursors.Hand;
        }


        private void rect1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Source == canvas1)
            {
                return;
            }
            var a = e.Source as FrameworkElement;
            Point q = e.GetPosition(a);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Canvas.SetLeft(a, Math.Max(0, Canvas.GetLeft(a) + q.X - p.X));
                Canvas.SetTop(a, Math.Max(0, Canvas.GetTop(a) + q.Y - p.Y));

            }

            e.Handled = true;
        }

        private void rect1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var a = e.Source as FrameworkElement;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (a != canvas1)
                    a.Cursor = Cursors.Hand;
            }
            else
            {
                (e.Source as FrameworkElement).ReleaseMouseCapture();
                (e.Source as FrameworkElement).Cursor = null;
            }
        }

        public void ResultCheck()
        {
            //
        }

    }
}
