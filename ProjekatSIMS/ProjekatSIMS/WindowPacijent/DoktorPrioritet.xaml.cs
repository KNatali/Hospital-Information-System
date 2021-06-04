using Model;
using ProjekatSIMS.Controller.PregledPacijent;
using ProjekatSIMS.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class DoktorPrioritet : Page
    {
        private string ime;
        private string prezime;

        public List<Pregled> Pregledi { get; set; }
        private string imeDoktora { get; set; }

        private string prezimeDoktora { get; set; }

        public List<SlobodanTermin> Termini { get; set; }
        public SlobodanTerminController slobodanTerminController = new SlobodanTerminController();
        public Pacijent trenutniPacijent { get; set; }
        public DoktorPrioritet(String ime, String prezime, Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            trenutniPacijent = pacijent;
            this.imeDoktora = ime;
            this.prezimeDoktora = prezime;
            Termini = new List<SlobodanTermin>();

            Termini = slobodanTerminController.DobaviSlobodneTermineZaLekara(imeDoktora,prezimeDoktora);
        }

        private void Odaberi_Click(object sender, RoutedEventArgs e)
        {
            SlobodanTermin st = (SlobodanTermin)dataGridSlobodniTermini.SelectedItems[0]; //pregled koji je odabran kao alternativan

            //preuzimam sve zakazane preglede
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\FajloviFajlovi\Pregled.txt");
            Pregledi = fajl.DobaviSvePregledePacijent();

            Pregled p = new Pregled();
            Doktor dr = new Doktor { Ime = imeDoktora, Prezime = prezimeDoktora };
            p.doktor = dr;
            p.Pocetak = st.Termin;
            Pacijent pac = new Pacijent { Ime = ime, Prezime = prezime };
            p.pacijent = pac;
            int trajanje = 30;
            p.Trajanje = trajanje;
            ProstorijaRepository file = new ProstorijaRepository();
            List<Prostorija> prostorije = file.DobaviSve();

            foreach (Prostorija pr in prostorije)
            {
                if (pr.slobodna == true)
                {
                    p.prostorija = pr;
                    pr.slobodna = false;
                    break;
                }
            }

            Pregledi.Add(p);
            fajl.SacuvajPregledPacijent(Pregledi);

            MessageBox.Show("Pregled je uspesno zakazan.");
            this.NavigationService.GoBack();
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            Pocetna pocetna = new Pocetna(trenutniPacijent);
            this.NavigationService.Navigate(pocetna);
        }
    }
}
