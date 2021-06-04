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
        public IzmenaPodsetnika(Pacijent pacijent)
        {

            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;
            Podsetnici = new List<Podsetnik>();
            PodsetnikRepository fajl = new PodsetnikRepository(@"..\..\..\Fajlovi\Podsetnik.txt");
            Podsetnici = fajl.DobaviSvePodsetnike();
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
    }
}
