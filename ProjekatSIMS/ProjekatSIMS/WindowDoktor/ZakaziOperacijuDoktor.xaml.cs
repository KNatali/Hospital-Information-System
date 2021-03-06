using Controller;
using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Service;
using ProjekatSIMS.ViewDoktor;
using ProjekatSIMS.ViewModelDoktor;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{

    public partial class ZakaziOperacijuDoktor : Page
    {
        private ProstorijaRepository prostorijaRepository = new ProstorijaRepository();
        private DoktorRepository doktorRepository = new DoktorRepository();
        private PacijentRepository pacijentRepository = new PacijentRepository();
        private ZauzetostTerminaPregledaController zauzetostTerminaPregledaController = new ZauzetostTerminaPregledaController();
        private PrikazSlobodnihTerminaController prikazSlobodnihTerminaController = new PrikazSlobodnihTerminaController();
        private ManipulacijaPregledomController zakaziPregledController = new ManipulacijaPregledomController();

        private Pregled pregled { get; set; }
        public ZakaziOperacijuDoktor()
        {
            InitializeComponent();
            this.DataContext = this;

            List<Prostorija> sale = new List<Prostorija>();
            sale = prostorijaRepository.DobaviPoVrsti(VrstaProstorije.Sala);
            List<Pacijent> pacijenti = new List<Pacijent>();
            pacijenti = pacijentRepository.DobaviSve();
            Sala.ItemsSource = sale;
            Pacijent.ItemsSource = pacijenti;
        }

        private void ZakazivanjeOperacije(object sender, RoutedEventArgs e)
        {
            try
            {
            
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
               
                DateTime datum1 = ((DateTime)Date.SelectedDate).AddHours(sat).AddMinutes(minut);
                DateTime datum2 = datum1.AddMinutes(Convert.ToInt32(Trajanje.Text));
                IntervalDatuma termin = new IntervalDatuma(datum1, datum2);
               
                ZakazivanjeOperacije zakazivanjeOperacije= new ZakazivanjeOperacije();
                Doktor doktor = doktorRepository.DobaviByRegistracija(UlogovaniKorisnik.KorisnickoIme, UlogovaniKorisnik.Lozinka);
                pregled = zakazivanjeOperacije.KreiranjePregleda(termin, (Prostorija)Sala.SelectedItem, (Pacijent)Pacijent.SelectedItem,doktor);
                List<String> termini = zakazivanjeOperacije.ZauzetiTermini(termin, pregled);
                if (termini != null)
                {
                    Termin.Visibility = Visibility.Visible;
                    Izbor.Visibility = Visibility.Visible;
                    Termin.ItemsSource = termini;
                }
                else
                {
                    PrikazPregledaDoktorViewModel vm1 = new PrikazPregledaDoktorViewModel(this.NavigationService);
                    PrikazPregledaDoktorView kalendar = new PrikazPregledaDoktorView(vm1);
                    this.NavigationService.Navigate(kalendar);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Popunite sve podatke");
            }

           
        }

        private void KreiranjePregleda(int trajanje, DateTime datum1, IntervalDatuma termin, Doktor dr)
        {
            pregled.Pocetak = datum1;
            pregled.Trajanje = trajanje;
            pregled.Tip = TipPregleda.Operacija;
            pregled.StatusPregleda = StatusPregleda.Zakazan;
            pregled.prostorija = (Prostorija)Sala.SelectedItem;
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
                zakaziPregledController.ZakaziPregled(pregled);
                MessageBox.Show("Operacija je uspjesno zakazana");
                PrikazPregledaDoktorViewModel vm1 = new PrikazPregledaDoktorViewModel(this.NavigationService);
                PrikazPregledaDoktorView kalendar = new PrikazPregledaDoktorView(vm1);
                this.NavigationService.Navigate(kalendar);

            }
        }



        private void PrikazInventara(object sender, RoutedEventArgs e)
        {

            RightListBox.Items.Clear();
            Prostorija sala = (Prostorija)Sala.SelectedItem;
            List<Inventar> inventari = sala.inventar;
            if (inventari == null)
                RightListBox.Items.Add("Inventar jos nije unesen!");
            else
            {
                foreach (Inventar i in inventari)
                    RightListBox.Items.Add(i.ime + " : " + i.kolicina.ToString());


            }
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();


        }
    }
}
