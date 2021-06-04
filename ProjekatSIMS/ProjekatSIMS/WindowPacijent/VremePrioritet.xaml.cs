using Model;
using ProjekatSIMS.Controller.PregledPacijent;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class VremePrioritet : Page
    {
        private DateTime datum1;

        public List<SlobodanTermin> Termini { get; set; }
        public List<Pregled> Pregledi { get; set; }
        public SlobodanTerminController slobodanTerminController = new SlobodanTerminController();
        public Pacijent trenutniPacijent { get; set; }

        public VremePrioritet(DateTime datum1,Pacijent pacijent)
        {
            this.datum1 = datum1;
            
            InitializeComponent();
            this.DataContext = this;

            Termini = new List<SlobodanTermin>();
            Termini = slobodanTerminController.DobaviSlobodneTermineZaDatum(datum1);
            trenutniPacijent = pacijent;

        }

        private void Odaberi(object sender, RoutedEventArgs e)
        {
            SlobodanTermin st = (SlobodanTermin)dataGridSlobodniTermini.SelectedItems[0]; //pregled koji je odabran kao alternativan

            //preuzimam sve zakazane preglede
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.DobaviSvePregledePacijent();

            Pregled p = new Pregled();
            Doktor dr = new Doktor { Ime = st.ImeDoktora, Prezime = st.PrezimeDoktora };
            p.doktor = dr;
            p.Pocetak = st.Termin;
            Pacijent pac = new Pacijent { Ime = trenutniPacijent.Ime, Prezime = trenutniPacijent.Prezime };
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
