using ProjekatSIMS.ViewModelSekretar;
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

namespace ProjekatSIMS.ViewSekretar
{
    public partial class KreiranjePacijentaView : Window
    {
        public KreiranjePacijentaView()
        {
            InitializeComponent();
            this.DataContext = new ViewModelSekretar.KreiranjePacijentaViewModel(this);
        }

        private void Otkazi(object sender, RoutedEventArgs e)
        {

        }

        private void Kreiraj(object sender, RoutedEventArgs e)
        {

        }
    }
}
