using Model;
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
    public partial class KreiranjeDoktoraView : Window
    {
        public KreiranjeDoktoraView()
        {
            InitializeComponent();
            this.DataContext = new ViewModelSekretar.KreiranjeDoktoraViewModel(this);
            Oblasti.ItemsSource = Enum.GetValues(typeof(Specijalizacija));
        }

        private void Otkazi_kreiranje(object sender, RoutedEventArgs e)
        {

        }

        private void Kreiraj_profil(object sender, RoutedEventArgs e)
        {

        }
    }
}
