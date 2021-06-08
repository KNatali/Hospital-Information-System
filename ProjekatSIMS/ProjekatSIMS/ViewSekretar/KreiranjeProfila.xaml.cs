using ProjekatSIMS.Model;
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
    public partial class KreiranjeProfila : Window
    {
        public KreiranjeProfila()
        {
            InitializeComponent();
            this.DataContext = new ViewModelSekretar.KreiranjeProfila(this);
            Uloga.ItemsSource = Enum.GetValues(typeof(Uloga));
        }

        private void Otkazi_kreiranje(object sender, RoutedEventArgs e)
        {

        }

        private void Kreiraj_profil(object sender, RoutedEventArgs e)
        {

        }
    }
}
