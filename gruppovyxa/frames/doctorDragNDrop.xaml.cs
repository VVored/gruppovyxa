using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace gruppovyxa.frames
{
    /// <summary>
    /// Логика взаимодействия для doctorDragNDrop.xaml
    /// </summary>
    public partial class doctorDragNDrop : Page, IResultCheck
    {
        Point p;
        int maxz;
        public double ball;
        double x;
        double y;

        public doctorDragNDrop()
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

            if (a.Name == "brain")
            {
                x = Canvas.GetLeft(brain);
                y = Canvas.GetTop(brain);
                if (x >= 352 & y >= -5 & x <= 384 & y <= 19 & a.Tag != "1")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "1";                    
                }
                else if (a.Tag == "1")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "0";
                }

            }

            if (a.Name == "heart")
            {
                x = Canvas.GetLeft(heart);
                y = Canvas.GetTop(heart);
                if (x >= 352 & y >= 71 & x <= 393 & y <= 99 & a.Tag != "1")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "1";
                }
                else if (a.Tag == "1")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "0";
                }
            }

            if (a.Name == "liver")
            {
                x = Canvas.GetLeft(liver);
                y = Canvas.GetTop(liver);
                if (x >= 338 & y >= 116 & x <= 357 & y <= 126 & a.Tag != "1")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "1";
                }
                else if (a.Tag == "1")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "0";
                }
            }

            if (a.Name == "stomach")
            {
                x = Canvas.GetLeft(stomach);
                y = Canvas.GetTop(stomach);
                if (x >= 366 & y >= 120 & x <= 393 & y <= 135 & a.Tag != "1")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "1";
                }
                else if (a.Tag == "1")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "0";
                }
            }

            if (a.Name == "intestines")
            {
                x = Canvas.GetLeft(intestines);
                y = Canvas.GetTop(intestines);
                if (x >= 359 & y >= 152 & x <= 390 & y <= 174 & a.Tag != "1")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "1";
                }
                else if (a.Tag == "1")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "0";
                }
            }

            if (a.Name == "lungs")
            {
                x = Canvas.GetLeft(lungs);
                y = Canvas.GetTop(lungs);
                if (x >= 345 & y >= 67 & x <= 384 & y <= 96 & a.Tag != "1")
                {
                    Controllers.Controller.currentBall += 1.7;
                    a.Tag = "1";
                }
                else if (a.Tag == "1")
                {
                    Controllers.Controller.currentBall -= 1.7;
                    a.Tag = "0";
                }
            }            
        }       

        public void ResultCheck()
        {

        }
    }
}
