using Controller;
using Model;
using ProjekatSIMS.DTO;
using ProjekatSIMS.ViewDoktor;
using ProjekatSIMS.ViewModelDoktor;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{

    public partial class IzdavanjeUputaSpecijalistiDoktor : Page
    {
        private OsobaRepository osobaRepository = new OsobaRepository((@"..\..\..\Fajlovi\Doktor.txt"));
        private SlobodniTerminiUputSpecijelistiController slobodniTerminiUputSpecijelistiController = new SlobodniTerminiUputSpecijelistiController();
        private IzdavanjeUputaSpecijalistiController izdavanjeUputaSpecijalistiController = new IzdavanjeUputaSpecijalistiController();
        private List<Doktor> sviDoktori = new List<Doktor>();
        private List<Doktor> doktoriPrikaz;
        private Pacijent izabraniPacijent;

        public IzdavanjeUputaSpecijalistiDoktor(Pacijent pacijent)
        {
            InitializeComponent();
            this.DataContext = this;
            izabraniPacijent = pacijent;
            sviDoktori = osobaRepository.DobaviDoktore();
            var specijalizacije = Enum.GetValues(typeof(Specijalizacija));
            Specijalizacije.ItemsSource = specijalizacije;

        }

        private void DoktoriOdabraneSpecijalizacije(object sender, RoutedEventArgs e)
        {
            Specijalizacija odabranaSpecijalizacija = (Specijalizacija)Specijalizacije.SelectedItem;
            doktoriPrikaz = new List<Doktor>();
            foreach (Doktor d in sviDoktori)
            {
                if (odabranaSpecijalizacija == d.Specijalizacija)

                    doktoriPrikaz.Add(d);
            }
            Doktori.ItemsSource = doktoriPrikaz;
        }

        private void PrikazSlobodnihTermina(object sender, RoutedEventArgs e)
        {
            Doktor izabraniDoktor = (Doktor)Doktori.SelectedItem;
            if( DatumPocetak.SelectedDate==null || DatumKraj.SelectedDate==null || IntervalPocetak.Text=="" || IntervalKraj.Text=="" ){
                MessageBox.Show("Izaberite datume i vrijeme");
                return;
            }
            IntervalDatuma datumi = new IntervalDatuma((DateTime)DatumPocetak.SelectedDate, (DateTime)DatumKraj.SelectedDate);
            IntervalSati sati = new IntervalSati(Convert.ToInt32(IntervalPocetak.Text), Convert.ToInt32(IntervalKraj.Text));

            SlobodniTerminiUputSpecijalistiDTO podaci = new SlobodniTerminiUputSpecijalistiDTO(izabraniDoktor, datumi, sati);
            List<DateTime> slobodniTermini = slobodniTerminiUputSpecijelistiController.PrikazSlobodnihTermina(podaci);
            Termini.ItemsSource = slobodniTermini;
            Termini.Visibility = Visibility.Visible;
        }

        private void IzdavanjeUputa(object sender, RoutedEventArgs e)
        {
            try
            {
                Doktor izabraniDoktor = (Doktor)Doktori.SelectedItem;
                DateTime izabranTermin = (DateTime)Termini.SelectedItem;

                if (izdavanjeUputaSpecijalistiController.IzdavanjeUputa(izabraniPacijent, izabraniDoktor, izabranTermin))
                {
                    MessageBox.Show("Uput je uspjesno izdat");
                    PrikazPregledaDoktorViewModel vm1 = new PrikazPregledaDoktorViewModel(this.NavigationService);
                    PrikazPregledaDoktorView kalendar = new PrikazPregledaDoktorView(vm1);
                    this.NavigationService.Navigate(kalendar);
                }
                else
                    MessageBox.Show("Neuspjesno izdavanje uputa");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Popunite sve podatke");
            }
          

        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();

        }
    }
}
