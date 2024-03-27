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
    /// Логика взаимодействия для sequenceLawyer.xaml
    /// </summary>
    public partial class sequenceLawyer : Page
    {
        public double ball;

        public sequenceLawyer()
        {
            InitializeComponent();
        }

        public void ResultCheck()
        {
            if (tb1.Text == "2") ball += 2;
            if (tb2.Text == "2") ball += 2;
            if (tb3.Text == "1") ball += 2;
            if (tb4.Text == "1") ball += 2;
            if (tb5.Text == "3") ball += 2;
        }
    }
}
