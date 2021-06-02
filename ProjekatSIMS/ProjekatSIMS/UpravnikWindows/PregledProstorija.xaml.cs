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

namespace ProjekatSIMS.UpravnikWindows
{
    /// <summary>
    /// Interaction logic for PregledProstorija.xaml
    /// </summary>
    public partial class PregledProstorija : Page
    {
        public List<Prostorija> Prostorije = new List<Prostorija>();
        public ProstorijaService ProstorijaService = new ProstorijaService();
        public PregledProstorija()
        {
            InitializeComponent();

            this.DataContext = this;
            Prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            dgrProstorije.ItemsSource = Prostorije;
        }
        private void ObrisiProstoriju(object sender, RoutedEventArgs e)
        {
            Prostorija prosrtorijaZaBrisanje = (Prostorija)dgrProstorije.SelectedItems[0];
            ProstorijaService.obrisiProstoriju(prosrtorijaZaBrisanje.id);
            MessageBox.Show("Uspesno ste obrisali prostoriju!");
            Prostorije = ProstorijaService.prostorijaRepository.DobaviSve();
            dgrProstorije.ItemsSource = Prostorije;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String pretraga = Pretraga.Text;
            // List<Prostorija> prostorije = 
        }
    }
}
