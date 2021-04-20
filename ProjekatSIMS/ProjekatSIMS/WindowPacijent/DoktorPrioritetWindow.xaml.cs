using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ProjekatSIMS.WindowPacijent
{
    public partial class DoktorPrioritetWindow : Window
    {
        private string ime;
        private string prezime;

        public List<Pregled> Pregledi { get; set; }
        private string imeDoktora { get; set; }

        private string prezimeDoktora { get; set; }

        public List<SlobodanTermin> Termini { get; set; }
        public DoktorPrioritetWindow(String imeDoktora, String prezimeDoktora, String ime, String prezime)
        {
            InitializeComponent();
            this.imeDoktora = imeDoktora;
            this.prezimeDoktora = prezimeDoktora;
            this.ime = ime;
            this.prezime = prezime;
            Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository fajl = new SlobodanTerminRepository(@"..\..\..\Fajlovi\SlobodniTermini.txt");
            Termini = fajl.DobaviSveSlobodneTermineZaDoktora(imeDoktora, prezimeDoktora);
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
            ProstorijaRepository file = new ProstorijaRepository(@"..\..\..\Fajlovi\Prostorija.txt");
            List<Prostorija> prostorije = file.DobaviSveProstorije();

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





    }
}
