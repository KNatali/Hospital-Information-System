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
    
    public partial class IzmeniProstoriju : Page
    {
        public ProstorijaController prostorijaController { get; set; }
        public List<Prostorija> prostorije { get; set; }
        public List<String> vrste { get; set; }
        public Prostorija prostorijaZaIzmenu { get; set; }

        public IzmeniProstoriju(Prostorija p)
        {
            InitializeComponent();
            this.DataContext = this;
            prostorijaZaIzmenu = p;
            prostorije = new List<Prostorija>();
            prostorijaController = new ProstorijaController();
            prostorije = prostorijaController.prostorijaService.prostorijaRepository.DobaviSve();
            vrste = new List<String> { "Magacin", "Ordinacija", "Sala", "Soba", "Kancelarija" };
            
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            String vrsta = (String)vrstaProstorije.SelectedItem;
            if (vrstaProstorije.SelectedItem == null || prostorijaZaIzmenu.id == "0")
            {
                vrsta = Vrsta.Text;
            }
            
            
            if(prostorijaController.IzmeniProstoriju(prostorijaZaIzmenu.id, vrsta, Convert.ToInt32(Sprat.Text), Convert.ToDouble(Kvadratura.Text)))
            {
                MessageBox.Show("Uspesno ste izmenili prostoriju!");
                Upravnik uw = (Upravnik)Window.GetWindow(this);
                uw.UpravnikFrame.Content = new PregledProstorija();
            }
            else
            {
                MessageBox.Show("Greska pri odabiru vrste prostorije, morate izabrati vrstu!");
            }

        }
        private void Odustani(object sender, RoutedEventArgs e)
        {
            Upravnik uw = (Upravnik)Window.GetWindow(this);
            uw.UpravnikFrame.Content = new PregledProstorija();
        }

        }
}
