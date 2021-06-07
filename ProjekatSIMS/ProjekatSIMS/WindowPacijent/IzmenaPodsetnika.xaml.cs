using Controller;
using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class IzmenaPodsetnika : Page
    {
        public List<Podsetnik> Podsetnici
        {
            get;
            set;
        }
        public Podsetnik podsetnik { get; set; }
        public Pacijent trenutniPacijent { get; set; }
        public PodsetnikController podsetnikController = new PodsetnikController();
        
        public IzmenaPodsetnika(Pacijent pacijent)
        {

            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;
            Podsetnici = new List<Podsetnik>();
            Podsetnici = podsetnikController.DobaviSvePodsetnikeZaPacijenta(trenutniPacijent);
        }
        private void Izaberi_Click(object sender, RoutedEventArgs e)
        {
            podsetnik = (Podsetnik)dataGridPodsetnik.SelectedItems[0];
        }
        private void Izmeni(object sender, RoutedEventArgs e)
        {
            podsetnik = (Podsetnik)dataGridPodsetnik.SelectedItems[0];
            string ime = Ime.Text;
            string opis = Opis.Text;
            DateTime pocetak = (DateTime)Pocetak.SelectedDate;
            DateTime kraj = (DateTime)Kraj.SelectedDate;
            Podsetnici.Remove(podsetnik);
            podsetnik = new Podsetnik { nazivPodsetika = ime, opisPodsetnika = opis, datumPocetkaObavestenja = pocetak, datumZavrsetkaObavestenja = kraj };
            Podsetnici.Add(podsetnik);
            string newJson = JsonConvert.SerializeObject(Podsetnici);
            File.WriteAllText(@"..\..\..\Fajlovi\Podsetnik.txt", newJson);
            MessageBox.Show("Podsetnik je uspesno izmenjen."); 
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            Pocetna pocetna = new Pocetna(trenutniPacijent);
            this.NavigationService.Navigate(pocetna);
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            Podsetnik odabraniPodsetnik = (Podsetnik)dataGridPodsetnik.SelectedItems[0];
            string naziv;
            string opis;
            naziv = odabraniPodsetnik.nazivPodsetika;
            opis = odabraniPodsetnik.opisPodsetnika;

            using (StreamReader file = new StreamReader(@"..\..\..\Fajlovi\Pregled.txt"))
            {
                Podsetnici.Remove(odabraniPodsetnik);

            }
            string newJson = JsonConvert.SerializeObject(Podsetnici);
            File.WriteAllText(@"..\..\..\Fajlovi\Podsetnik.txt", newJson);
            MessageBox.Show("Podsetnik je obrisan.");
            IzmenaPodsetnika ip = new IzmenaPodsetnika(trenutniPacijent);
            this.NavigationService.Navigate(ip);
        }
    }
}
