using Model;
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
        public List<Pregled> Pregledi { get; private set; }

        
        public VremePrioritetWindow(DateTime datum1)
        {
            this.datum1 = datum1;
            InitializeComponent();
            this.DataContext = this;


            Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository file = new SlobodanTerminRepository(@"..\..\Fajlovi\SlobodniTermini.txt");
            Termini = file.DobaviSveSlobodneTermineZaDatum(datum1);


        }

        public VremePrioritetWindow(DateTime datum1, String ime, String prezime)
        {
            this.datum1 = datum1;
            this.ime = ime;
            this.prezime = prezime;

            InitializeComponent();
            this.DataContext = this;


            Termini = new List<SlobodanTermin>();
            SlobodanTerminRepository file = new SlobodanTerminRepository(@"..\..\Fajlovi\SlobodniTermini.txt");
            Termini = file.DobaviSveSlobodneTermineZaDatum(datum1);


        }

        private void Odaberi_Click(object sender, RoutedEventArgs e)
        {
            SlobodanTermin st = (SlobodanTermin)dataGridSlobodniTermini.SelectedItems[0]; //pregled koji je odabran kao alternativan

            //preuzimam sve zakazane preglede
            Pregledi = new List<Pregled>();
            PregledRepository fajl = new PregledRepository(@"..\..\Fajlovi\Pregled.txt");
            Pregledi = fajl.DobaviSvePregledePacijent();

            Pregled p = new Pregled();
            Doktor dr = new Doktor { Ime = st.ImeDoktora, Prezime = st.PrezimeDoktora };
            p.doktor = dr;
            p.Pocetak = st.Termin;
            Pacijent pac = new Pacijent { Ime = ime, Prezime = prezime };
            p.pacijent = pac;

            Pregledi.Add(p);



        }



    }
}
