using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace gruppovyxa.frames
{
    /// <summary>
    /// Логика взаимодействия для doctorDragNDrop.xaml
    /// </summary>
    public partial class doctorDragNDrop : Page
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

            //++баллы если отпустил элемент в нужном месте (сделайте норм масштаб для окон, а то у меня канвас не совпадает в полном экране с разметкой в xaml)

            if (a.Name == "brain")
            {
                x = Canvas.GetLeft(brain);
                y = Canvas.GetTop(brain);
                if (x >= 352 & y >= 2 & x <= 391 & y <= 40 & a.Tag != "1")
                {
                    ball += 1.7;
                    a.Tag = "1";                    
                }
                else if (a.Tag == "1")
                {
                    ball -= 1.7;
                    a.Tag = "0";
                }

            }

            if (a.Name == "heart")
            {
                x = Canvas.GetLeft(heart);
                y = Canvas.GetTop(heart);
                if (x >= 368 & y >= 132 & x <= 390 & y <= 150 & a.Tag != "1")
                {
                    ball += 1.7;
                    a.Tag = "1";
                }
                else if (a.Tag == "1")
                {
                    ball -= 1.7;
                    a.Tag = "0";
                }
            }

            if (a.Name == "liver")
            {
                x = Canvas.GetLeft(liver);
                y = Canvas.GetTop(liver);
                if (x >= 348 & y >= 184 & x <= 357 & y <= 190 & a.Tag != "1")
                {
                    ball += 1.7;
                    a.Tag = "1";
                }
                else if (a.Tag == "1")
                {
                    ball -= 1.7;
                    a.Tag = "0";
                }
            }

            if (a.Name == "stomach")
            {
                x = Canvas.GetLeft(stomach);
                y = Canvas.GetTop(stomach);
                if (x >= 366 & y >= 187 & x <= 394 & y <= 196 & a.Tag != "1")
                {
                    ball += 1.7;
                    a.Tag = "1";
                }
                else if (a.Tag == "1")
                {
                    ball -= 1.7;
                    a.Tag = "0";
                }
            }

            if (a.Name == "intestines")
            {
                x = Canvas.GetLeft(intestines);
                y = Canvas.GetTop(intestines);
                if (x >= 350 & y >= 222 & x <= 394 & y <= 250 & a.Tag != "1")
                {
                    ball += 1.7;
                    a.Tag = "1";
                }
                else if (a.Tag == "1")
                {
                    ball -= 1.7;
                    a.Tag = "0";
                }
            }

            if (a.Name == "lungs")
            {
                x = Canvas.GetLeft(lungs);
                y = Canvas.GetTop(lungs);
                if (x >= 350 & y >= 112 & x <= 381 & y <= 132 & a.Tag != "1")
                {
                    ball += 1.7;
                    a.Tag = "1";
                }
                else if (a.Tag == "1")
                {
                    ball -= 1.7;
                    a.Tag = "0";
                }
            }            
        }       
    }
}
