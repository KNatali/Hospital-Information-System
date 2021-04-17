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
    public partial class NoviAlergenSWindow : Window
    {
        public NoviAlergenSWindow()
        {
            InitializeComponent();
        }
        private void Dodavanje(object sender, RoutedEventArgs e)
        {
            //mora sacuvati novi dodati alergen
            this.Close();
            ListaAlergenaSWindow la = new ListaAlergenaSWindow();
            la.Show();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
            ListaAlergenaSWindow la = new ListaAlergenaSWindow();
            la.Show();
        }
    }
}
