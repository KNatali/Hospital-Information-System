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
    public partial class PretraziPacijenteSekretarWindow : Window
    {
        public PretraziPacijenteSekretarWindow()
        {
            InitializeComponent();
        }
        private void Pretraga(object sender, RoutedEventArgs e)
        {
            //kada unese ime i prezime pretrazice i izbaciti tabelu sa tim pacijentima u tabelapacijenata prozoru
            this.Close();
            TabelaPacijenataSWindow tp = new TabelaPacijenataSWindow();
            tp.Show();
        }
        private void Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
