using Model;
using ProjekatSIMS.Controller;
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
    
    public partial class KreirajProstoriju : Page
    {
        public ProstorijaController prostorijaController { get; set; }
      
        public List<Prostorija> prostorije { get; set; }
        public List<String> vrste { get; set; }
        public KreirajProstoriju()
        {
            InitializeComponent();
            this.DataContext = this;
            prostorijaController = new ProstorijaController();
            prostorije = new List<Prostorija>(prostorijaController.prostorijaService.prostorijaRepository.DobaviSve());
            vrste = new List<string> { "Magacin", "Ordinacija", "Sala", "Soba", "Kancelarija" };

        }
        private void Kreiraj(object sender, RoutedEventArgs e)
        {
            String vrsta = (String)vrstaProstorije.SelectedItem;
            if(prostorijaController.KreirajProstoriju(Id.Text, vrsta, Convert.ToInt32(Sprat.Text), Convert.ToDouble(Kvadratura.Text)) == false)
            {
                MessageBox.Show("Uneta sifra vec postoji!");
            }
            else
            {
                MessageBox.Show("Uspesno ste kreirali prostoriju!");
                Upravnik uw = (Upravnik)Window.GetWindow(this);
                uw.UpravnikFrame.Content = new PregledProstorija();
            }
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            Upravnik uw = (Upravnik)Window.GetWindow(this);
            uw.UpravnikFrame.Content = new PregledProstorija();
        }
    }
}
