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
        double x;
        double y;

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

            if (a.Name == "mp")
            {
                x = Canvas.GetLeft(mp);
                y = Canvas.GetTop(mp);
                if (x >= 197 & y >= 110 & x <= 264 & y <= 145 & a.Tag != "0")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "0";
                }
                else if (a.Tag == "0")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "1";
                }

            }

            if (a.Name == "hd")
            {
                x = Canvas.GetLeft(hd);
                y = Canvas.GetTop(hd);
                if (x >= 410 & y >= 109 & x <= 469 & y <= 184 & a.Tag != "0")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "0";
                }
                else if (a.Tag == "0")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "2";
                }

            }

            if (a.Name == "pb")
            {
                x = Canvas.GetLeft(pb);
                y = Canvas.GetTop(pb);
                if (x >= 198 & y >= 190 & x <= 252 & y <= 331 & a.Tag != "0")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "0";
                }
                else if (a.Tag == "0")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "3";
                }

            }

            if (a.Name == "op")
            {
                x = Canvas.GetLeft(op);
                y = Canvas.GetTop(op);
                if (x >= 278 & y >= 107 & x <= 353 & y <= 190 & a.Tag != "0")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "0";
                }
                else if (a.Tag == "0")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "4";
                }

            }

            if (a.Name == "proc")
            {
                x = Canvas.GetLeft(proc);
                y = Canvas.GetTop(proc);
                if (x >= 252 & y >= 140 & x <= 356 & y <= 196 & a.Tag != "0")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "0";
                }
                else if (a.Tag == "0")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "5";
                }

            }

            if (a.Name == "vc")
            {
                x = Canvas.GetLeft(vc);
                y = Canvas.GetTop(vc);
                if (x >= 224 & y >= 199 & x <= 320 & y <= 280 & a.Tag != "0")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "0";
                }
                else if (a.Tag == "0")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "6";
                }

            }
        }

        public void ResultCheck()
        {
            //
        }

    }
}
