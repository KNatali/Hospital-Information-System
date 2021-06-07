using Controller;
using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Controller.PregledPacijent;
using ProjekatSIMS.Service;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class VidiPreglede : Page
    {
        public PregledController pregledController = new PregledController();
        public List<Pregled> Pregledi
        {
            get;
            set;
        }
        public List<Pacijent> Pacijenti 
        { 
            get; 
            set; 
        }
        public Pacijent trenutniPacijent { get; set; }

        public int prioritetVreme = 0;
        public int prioritetDoktor = 0;
        public OtkazivanjePregledaController otkazivanjePregledaController = new OtkazivanjePregledaController();
        public VidiPreglede(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;

            Pregledi = new List<Pregled>();
            Pregledi = pregledController.DobaviPregledeZaPacijenta(trenutniPacijent);

            Pacijenti = new List<Pacijent>();
            PacijentRepository file = new PacijentRepository(@"..\..\..\Fajlovi\Pacijent.txt");
            Pacijenti = file.DobaviSve();
            
            
    }
        private void Zatvori(object sender, RoutedEventArgs e)
        {
            PocetnaPacijent pmw = new PocetnaPacijent(trenutniPacijent);
            this.NavigationService.Navigate(pmw);
        }
        private void Otkazi_Click(object sender, RoutedEventArgs e)
        {
            Pregled odabraniPregled = (Pregled)dataGridPregledi.SelectedItems[0]; //ovo je odabrani pregled za otkazivanje
            string ime;
            string prezime;
            ime = odabraniPregled.pacijent.Ime;
            prezime = odabraniPregled.pacijent.Prezime;

            otkazivanjePregledaController.BrojacOtkazivanjaPregleda(ime, prezime);
            string newJ = JsonConvert.SerializeObject(Pacijenti);
            File.WriteAllText(@"..\..\..\Fajlovi\Pacijent.txt", newJ);
            DateTime danasnjiDatum = DateTime.UtcNow;

            otkazivanjePregledaController.ProveraVremenaZakazivanja(danasnjiDatum);

            using (StreamReader file = new StreamReader(@"..\..\..\Fajlovi\Pregled.txt"))
            {

                Pregledi.Remove(odabraniPregled);

            }
            string newJson = JsonConvert.SerializeObject(Pregledi);
            File.WriteAllText(@"..\..\..\Fajlovi\Pregled.txt", newJson);
            MessageBox.Show("Vas pregled je otkazan.");
            VidiPreglede vp = new VidiPreglede(trenutniPacijent);
            this.NavigationService.Navigate(vp);
            //this.NavigationService.GoBack();
        }
    }
}
