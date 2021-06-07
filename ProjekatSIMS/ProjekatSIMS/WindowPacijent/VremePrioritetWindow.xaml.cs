using Model;
using ProjekatSIMS.Controller.PregledPacijent;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class VremePrioritetWindow : Window
    {
        private DateTime datum1;
        private String ime;
        private String prezime;

        public List<SlobodanTermin> Termini { get; set; }
        public List<Pregled> Pregledi { get; set; }
        public SlobodanTerminController slobodanTerminController = new SlobodanTerminController();
        public Pacijent trenutniPacijent { get; set; }




        public VremePrioritetWindow(DateTime datum1, Pacijent pacijent)
        {

            InitializeComponent();
            this.DataContext = this;
            this.trenutniPacijent = pacijent;
            this.datum1 = datum1;
            
            Termini = new List<SlobodanTermin>();
            Termini = slobodanTerminController.DobaviSlobodneTermineZaDatum(datum1);

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

            this.Close();



        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
