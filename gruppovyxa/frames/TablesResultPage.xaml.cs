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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gruppovyxa.frames
{
    /// <summary>
    /// Логика взаимодействия для TablesResultPage.xaml
    /// </summary>
    public partial class TablesResultPage : Page
    {
        public TablesResultPage(List<Models.User> source)
        {
            InitializeComponent();
            dg1.ItemsSource = source;
        }
    }
}
