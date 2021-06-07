using Controller;
using Model;
using ProjekatSIMS.DTO;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjekatSIMS
{

    public partial class UputZaBolnickoLijecenjeDoktor : Page
    {
        private Pacijent pacijent { get; set; }
        private TrazenjeSlobodnihKrevetaController uputController = new TrazenjeSlobodnihKrevetaController();
        private IzdavanjeUputaBolnickoLijecenjeController izdavanjeUputaBolnickoLijecenjeController = new IzdavanjeUputaBolnickoLijecenjeController();
        private List<SlobodniKrevetDTO> sobeIKreveti = new List<SlobodniKrevetDTO>();
        public UputZaBolnickoLijecenjeDoktor(Pacijent p)
        {
            InitializeComponent();
            pacijent = p;
            Ime.Text = p.Ime;
            Prezime.Text = p.Prezime;
        }

        private void PrikazSlobodnihSoba(object sender, RoutedEventArgs e)
        {
            if(DatumPocetak.SelectedDate==null || DatumKraj.SelectedDate == null)
            {
                MessageBox.Show("Prvo morate izabrati pocetni i krajnji datum");
                return;
            }
            DateTime pocetakIntervala = (DateTime)DatumPocetak.SelectedDate;
            DateTime krajIntervala = (DateTime)DatumKraj.SelectedDate;
           
            IntervalDatuma termin = new IntervalDatuma(pocetakIntervala, krajIntervala);

            if ((uputController.DobaviSlobodneSobe(termin)).Count == 0)
                MessageBox.Show("Nema slobodnih soba. Izaberi drugi interval");
            else
            {
                sobeIKreveti = uputController.DobaviSlobodneSobe(termin);
                SlobodneSobe.ItemsSource = sobeIKreveti;
                SlobodneSobe.Visibility = Visibility.Visible;

            }



        }
        private void KrevetiZaSobu(object sender, RoutedEventArgs e)
        {
            SlobodniKrevetDTO odabranaSoba = (SlobodniKrevetDTO)SlobodneSobe.SelectedItem;

            foreach (SlobodniKrevetDTO s in sobeIKreveti)
            {
                if (s.Soba == odabranaSoba.Soba)
                {
                    SlobodniKreveti.ItemsSource = s.Kreveti;
                    SlobodniKreveti.Visibility = Visibility.Visible;
                    break;
                }

            }

        }

       
        private void SacuvajUput(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime pocetakIntervala = (DateTime)DatumPocetak.SelectedDate;
                DateTime krajIntervala = (DateTime)DatumKraj.SelectedDate;
                IntervalDatuma interval = new IntervalDatuma(pocetakIntervala, krajIntervala);
                SlobodniKrevetDTO odabranaSoba = (SlobodniKrevetDTO)SlobodneSobe.SelectedItem;
                String sobaId = odabranaSoba.Soba;
                int krevetId = (int)SlobodniKreveti.SelectedItem;
                UputBolnickoLijecenjeDTO uput = new UputBolnickoLijecenjeDTO(interval, sobaId, krevetId, pacijent.IdKartona);
                izdavanjeUputaBolnickoLijecenjeController.CuvanjeUputa(uput, pacijent);

                MessageBox.Show("Uput je uspjesno sacuvan");
                this.NavigationService.GoBack();
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