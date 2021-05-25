using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    /// <summary>
    /// Interaction logic for Renoviranje.xaml
    /// </summary>
    public partial class Renoviranje : Window
    {
        public Renoviranje()
        {
            InitializeComponent();
        }

        private void naprednoRenoviranje(object sender, RoutedEventArgs e)
        {
            NaprednoRenoviranje nr = new NaprednoRenoviranje();
            nr.Show();
        }

        private void obicnoRenoviranje(object sender, RoutedEventArgs e)
        {

        }
    }
}
