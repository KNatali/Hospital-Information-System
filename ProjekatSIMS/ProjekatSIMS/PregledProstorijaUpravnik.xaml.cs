using Model;
using ProjekatSIMS.Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatSIMS
{
    
    public partial class PregledProstorijaUpravnik : Page
    {
        public List<Prostorija> Prostorije = new List<Prostorija>();
        public ProstorijaService ProstorijaService = new ProstorijaService();
        public PregledProstorijaUpravnik()
        {
            InitializeComponent();
            this.DataContext = this;
            Prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            dgrProstorije.ItemsSource = Prostorije;
        }
        private void PrikaziProstoriju(object sender, RoutedEventArgs e)
        {

        }
        private void ObrisiProstoriju(object sender, RoutedEventArgs e)
        {

        }
        private void IzmeniProstoriju(object sender, RoutedEventArgs e)
        {

        }
        private void KreirajProstoriju(object sender, RoutedEventArgs e)
        {

        }
    }
}
