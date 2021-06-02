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

namespace ProjekatSIMS
{
    
    public partial class IzmenaProstorije : Page
    {
        public ProstorijaController prostorijaController { get; set; }
        public ProstorijaService prostorijaService { get; set; }
        public List<Prostorija> prostorije { get; set; }
        public IzmenaProstorije()
        {
            InitializeComponent();
            this.DataContext = this;
            prostorije = new List<Prostorija>();
            prostorijaService = new ProstorijaService();
            prostorijaController = new ProstorijaController();
            prostorije = prostorijaService.prostorijaRepository.DobaviSve();
            

        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            Prostorija prostorijaZaIzmenu = (Prostorija)Prostorije.SelectedItem;
            prostorijaController.IzmeniProstoriju(prostorijaZaIzmenu.id, Vrsta.Text, Convert.ToInt32(Sprat.Text), Convert.ToDouble(Kvadratura.Text));
            
        }
    }
}
