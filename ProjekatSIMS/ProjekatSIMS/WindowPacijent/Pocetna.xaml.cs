using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Service;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ProjekatSIMS.WindowPacijent
{
    public partial class Pocetna : Page
    {
        public OtkazivanjePregledaService otkazivanjePregledaService = new OtkazivanjePregledaService();

        public List<Recept> Recepti{ get; set; }
        public Pacijent trenutniPacijent { get; set; }

        public Pocetna(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            Recepti = new List<Recept>();
            ReceptRepository fajl = new ReceptRepository(@"..\..\..\Fajlovi\Recept.txt");
            Recepti = fajl.DobaviSveRecepte();
            trenutniPacijent = pacijent;
        }

        private void OceniBolnicu(object sender, RoutedEventArgs e)
        {
            OceniBolnicuPacijent ob = new OceniBolnicuPacijent();
            this.NavigationService.Navigate(ob);


        }

        private void OceniLekara(object sender, RoutedEventArgs e)
        {
            OceniLekaraPacijent ol = new OceniLekaraPacijent();
            this.NavigationService.Navigate(ol);
        }

        private void KreirajPodsetnik(object sender, RoutedEventArgs e)
        {
            KreiranjePodsetnika kp = new KreiranjePodsetnika(trenutniPacijent);
            this.NavigationService.Navigate(kp);
        }

        private void IzmeniPodsetnik(object sender, RoutedEventArgs e)
        {
            IzmenaPodsetnika ip = new IzmenaPodsetnika();
            this.NavigationService.Navigate(ip);
        }
    }
}
