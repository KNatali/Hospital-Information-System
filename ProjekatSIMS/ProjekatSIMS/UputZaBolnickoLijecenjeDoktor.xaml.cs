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
        private IzdavanjeUputaBolnickoLijecenjeController uputController = new IzdavanjeUputaBolnickoLijecenjeController();
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
            DateTime pocetakIntervala = (DateTime)DatumPocetak.SelectedDate;
            DateTime krajIntervala = (DateTime)DatumKraj.SelectedDate;

            if ((uputController.DobaviSlobodneSobe(pocetakIntervala, krajIntervala)).Count == 0)
                MessageBox.Show("Nema slobodnih soba. Izaberi drugi interval");
            else
            {
                sobeIKreveti = uputController.DobaviSlobodneSobe(pocetakIntervala, krajIntervala);
                SlobodneSobe.ItemsSource = sobeIKreveti;
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
                    break;
                }

            }

        }

        private void SacuvajUput(object sender, RoutedEventArgs e)
        {
            DateTime pocetakIntervala = (DateTime)DatumPocetak.SelectedDate;
            DateTime krajIntervala = (DateTime)DatumKraj.SelectedDate;
            SlobodniKrevetDTO odabranaSoba = (SlobodniKrevetDTO)SlobodneSobe.SelectedItem;
            String sobaId = odabranaSoba.Soba;
            int krevetId = (int)SlobodniKreveti.SelectedItem;
            UputBolnickoLijecenje uput = new UputBolnickoLijecenje(pocetakIntervala,krajIntervala,sobaId,krevetId);
            uputController.CuvanjeUputa(uput, pacijent);

            MessageBox.Show("Uput je uspjesno sacuvan");
            this.NavigationService.GoBack();

        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();


        }





    }
}
