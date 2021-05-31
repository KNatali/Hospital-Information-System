using Model;
using Service;
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
    
    public partial class PregledInventaraUpravnik : Page
    {
        public List<Inventar> Oprema = new List<Inventar>();
        public InventarService InventarService = new InventarService();
        public PregledInventaraUpravnik()
        {
            InitializeComponent();
            this.DataContext = this;
            Oprema = InventarService.inventarRepository.DobaviSavInventar();
            dgrInventar.ItemsSource = Oprema;
        }
        private void KreirajStatickuOpremu(object sender, RoutedEventArgs e)
        {

        }
        private void KreirajDinamickuOpremu(object sender, RoutedEventArgs e)
        {

        }
        private void ObrisiOpremu(object sender, RoutedEventArgs e)
        {

        }
        private void IzmeniOpremu(object sender, RoutedEventArgs e)
        {

        }
    }
}
