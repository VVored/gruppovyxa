﻿using System;
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
        frames.sequenceProgrammer stage = new frames.sequenceProgrammer();

        public sequenceWindow()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(stage);
        }

        private void End_Click(object sender, RoutedEventArgs e)
        {
            stage.ResultCheck();
            tbBall.Text = $"Количество баллов: {Math.Round(stage.ball)}";
        }
    }
}
