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
    
    public partial class RenoviranjeUpravnik : Page
    {
        public List<Prostorija> Prostorije = new List<Prostorija>();
        public ProstorijaService ProstorijaService = new ProstorijaService();
        public RenoviranjeUpravnik()
        {
            InitializeComponent();
            this.DataContext = this;
            Prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            dgrProstorije.ItemsSource = Prostorije;
        }
        private void ZakaziRenoviranje(object sender, RoutedEventArgs e)
        {

        }
        private void SpajanjeProstorija(object sender, RoutedEventArgs e)
        {

        }
        private void RazdvajanjeProstorija(object sender, RoutedEventArgs e)
        {

        }
    }
}
