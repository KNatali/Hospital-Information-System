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
    public partial class SekretarWindow : Window
    {
        public SekretarWindow()
        {
            InitializeComponent();
        }
        private void Kreiranje_profila(object sender, RoutedEventArgs e)
        {
            KreirajProfilWindow kp = new KreirajProfilWindow();
            kp.Show();
        }
        private void Pretrazivanje(object sender, RoutedEventArgs e)
        {
            TabelaPacijenata pp = new TabelaPacijenata();
            pp.Show();
        }
        private void Izmena_profila(object sender, RoutedEventArgs e)
        {
            
        }
        private void Brisanje(object sender, RoutedEventArgs e)
        {

        }
    }
}
