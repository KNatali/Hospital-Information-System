﻿using Controller;
using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Model;
using ProjekatSIMS.ViewDoktor;
using ProjekatSIMS.ViewModelDoktor;
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

namespace ProjekatSIMS
{
   
    public partial class ZakaziPregledDoktor : Page
    {

        private ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        private PacijentRepository pacijentRepository = new PacijentRepository();
        private DoktorRepository doktorRepository = new DoktorRepository();
        private ZauzetostTerminaPregledaController zauzetostTerminaPregledaController = new ZauzetostTerminaPregledaController();
        private PrikazSlobodnihTerminaController prikazSlobodnihTerminaController = new PrikazSlobodnihTerminaController();
        private ManipulacijaPregledomController zakaziPregled = new ManipulacijaPregledomController();

        private Pregled pregled { get; set; }
        public ZakaziPregledDoktor()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Prostorija> ordinacije = new List<Prostorija>();
            ordinacije = prostorijaRepository.DobaviPoVrsti(VrstaProstorije.Ordinacija);
            List<Pacijent> pacijenti = new List<Pacijent>();
            pacijenti = pacijentRepository.DobaviSve();
            Ordinacija.ItemsSource = ordinacije;
            Pacijent.ItemsSource = pacijenti;
        }

        private void ZakazivanjePregleda(object sender, RoutedEventArgs e)
        {
            try
            {
                pregled = new Pregled();
                DateTime datum = (DateTime)Date.SelectedDate;
                double sat;
                double minut;
                if (Termin.Visibility == Visibility.Visible)
                {
                    sat = Convert.ToDouble(Termin.Text.Split(":")[0]);
                    minut = Convert.ToDouble(Termin.Text.Split(":")[1]);
                }
                else
                {
                    sat = Convert.ToDouble(Sat.Text);
                    minut = Convert.ToDouble(Minut.Text);
                }
                DateTime datum1 = datum.AddHours(sat).AddMinutes(minut);
                DateTime datum2 = datum1.AddMinutes(20);
                IntervalDatuma termin = new IntervalDatuma(datum1, datum2);
                Doktor dr = doktorRepository.DobaviByRegistracija(UlogovaniKorisnik.KorisnickoIme, UlogovaniKorisnik.Lozinka);
                KreiranjePregleda(datum1, termin, dr);
                ZauzetiTermini(datum1, termin);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Popunite sve podatke");
            }
           
        }

        private void KreiranjePregleda( DateTime datum1, IntervalDatuma termin, Doktor dr)
        {
            pregled.Pocetak = datum1;
            pregled.Trajanje = 20;
            pregled.Tip = TipPregleda.Operacija;
            pregled.StatusPregleda = StatusPregleda.Zakazan;
            pregled.prostorija = (Prostorija)Ordinacija.SelectedItem;
            pregled.doktor = dr;
            pregled.pacijent = (Pacijent)Pacijent.SelectedItem;

        }

        public void ZauzetiTermini(DateTime datum1, IntervalDatuma termin)
        {
            if (zauzetostTerminaPregledaController.ProvjeraZauzetostiTermina(pregled, termin))
            {
                List<String> termini = new List<String>();
                termini = prikazSlobodnihTerminaController.PrikazTermina(pregled, termin);
                MessageBox.Show("Dati termin je zauzet");
                Termin.Visibility = Visibility.Visible;
                Izbor.Visibility = Visibility.Visible;
                Termin.ItemsSource = termini;
            }
            else
            {
                zakaziPregled.ZakaziPregled(pregled);
                MessageBox.Show("Pregled je uspjesno zakazan");
                PrikazPregledaDoktorViewModel vm1 = new PrikazPregledaDoktorViewModel(this.NavigationService);
                PrikazPregledaDoktorView kalendar = new PrikazPregledaDoktorView(vm1);
                this.NavigationService.Navigate(kalendar);

            }
        }
        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();


        }

    }
}
