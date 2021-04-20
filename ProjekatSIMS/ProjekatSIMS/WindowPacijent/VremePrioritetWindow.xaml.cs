using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
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


    }
}
