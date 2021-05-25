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
    
    public partial class Lekovi : Window
    {
        public Lekovi()
        {
            InitializeComponent();
        }

        private void odobreniLekovi(object sender, RoutedEventArgs e)
        {
            OdobreniLekovi od = new OdobreniLekovi();
            od.Show();
        }

        private void odbijeniLekovi(object sender, RoutedEventArgs e)
        {
            OdbijeniLekovi ol = new OdbijeniLekovi();
            ol.Show();
        }

        private void kreiranjeLeka(object sender, RoutedEventArgs e)
        {
            DodajLek dl = new DodajLek();
            dl.Show();
        }
    }
}
