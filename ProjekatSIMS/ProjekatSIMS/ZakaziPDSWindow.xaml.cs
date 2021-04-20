using Model;
using Repository;
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
using Tulpep.NotificationWindow;

namespace ProjekatSIMS
{
    public partial class ZakaziPDSWindow : Window
    {
        public ZakaziPDSWindow(Doktor d)
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {

        }

        private void Zakazi(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
